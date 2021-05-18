using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    public class Kit
    {

        public static  List<Plug>  GetAllPlugins(string path)
        {
            List<Plug> plugs = new List<Plug>();
            if (!Directory.Exists(path))
            {
                return plugs;
            }

            string[] dlls = Directory.GetFiles(path,"*.dll");
            foreach (var dll in dlls)
            {
                Assembly asm = Assembly.LoadFile(dll);
                Type[] types = asm.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface("IPlugin")!=null)
                    {
                        Plug myPlug = new Plug();
                        myPlug.pFName = type.FullName;
                        myPlug.pPath = dll;
                        object obj = asm.CreateInstance(type.FullName);
                        myPlug.pName = obj.GetType().InvokeMember("Name",BindingFlags.InvokeMethod,null,obj,null).ToString();
                        plugs.Add(myPlug);
                    }
                }
            }
            return plugs;
        }

        public static object CreateObject(Plug p)
        {
            Assembly asm=Assembly.LoadFile(p.pPath);
            object obj = asm.CreateInstance(p.pFName);
            return obj;
        }
    }
}
