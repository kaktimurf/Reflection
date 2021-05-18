using System;
using System.Reflection;
using System.Threading.Channels;

namespace Reflection
{
    class Program
    {
        static void Main()//string[] args
        {
            #region A small example about reflection 

            string path = @"C:\Windows\Microsoft.NET\Framework64\v2.0.50727\System.dll";
            var asm= Assembly.LoadFile(path);
            var thisasm = Assembly.GetExecutingAssembly();
            //GetAssembly(asm);
            //GetAssembly(thisasm);

            #endregion

            #region We are In this example getting fields of student class  at runetime
            
            var student = new Student
            {
                FirstName = "Ferit",
                LastName = "Kaktimur"
            };

            Type stdType = typeof(Student);
           // var stdFieldInfos = stdType.GetFields(BindingFlags.Public | BindingFlags.CreateInstance); //NET v4.0
            var stdFieldInfos = stdType.GetRuntimeFields();//.Net v5.0
            Console.WriteLine(stdFieldInfos);
            foreach (FieldInfo fieldInfo in stdFieldInfos)
            {
                //Console.WriteLine("Field Name :"+fieldInfo.Name);
               // Console.WriteLine("Field Value :"+fieldInfo.GetValue(student));
            }
            #endregion

            #region In this example we are getting about informations is methods at MyClass class

            Type type = typeof(MyClass);
            Console.WriteLine("İncelenecek Class :"+type.Name);
            Console.WriteLine("------------------------------");

            MethodInfo[] methodInfo = type.GetMethods();
            foreach (var info in methodInfo)
            {
                Console.Write("   "+ info.ReturnType.Name +" "+info.Name + "(");
                ParameterInfo[] parameterInfo = info.GetParameters();
                for (int i = 0; i < parameterInfo.Length-1; i++)
                {
                    Console.Write(parameterInfo[i].ParameterType.Name +" "+parameterInfo[i].Name);
                    
                }
                Console.WriteLine(")");
                Console.ReadLine();

            }

            #endregion

            #region In this example we are runing methods of MyClass with reflection at runtime

            Type _type = typeof(MyClass);
            MyClass reflection = new MyClass(10,20);
            int val;

            Console.WriteLine("Used Class :"+_type.Name);
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            MethodInfo[] method = _type.GetMethods();
            foreach (MethodInfo info in method)
            {
                ParameterInfo[] pi = info.GetParameters();

                if (info.Name.Equals("Set",StringComparison.Ordinal)&&pi[0].ParameterType==typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    info.Invoke(reflection, args);
                }
                else if (info.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(double))
                {
                    object[] args = new object[2];
                    args[0] = 9.5;
                    args[1] = 18.9;
                    info.Invoke(reflection, args);
                }
                else if (info.Name.Equals("Sum", StringComparison.Ordinal))
                {
                    // ReSharper disable once PossibleNullReferenceException
                    val = (int)info.Invoke(reflection, null);
                    Console.WriteLine("Sum() Sonuç :"+val);
                    
                }
                else if (info.Name.Equals("IsBetween", StringComparison.Ordinal))
                {
                    object[] args = new object[1];
                    args[0] = 15;

                    // ReSharper disable once PossibleNullReferenceException
                    if ((bool)info.Invoke(reflection, args))
                    {
                        Console.WriteLine("X between Y : 15");   
                    }
                }
                else if (info.Name.Equals("Show", StringComparison.Ordinal))
                {
                   
                    info.Invoke(reflection, null);
                }

            }


            #endregion

            Console.ReadLine();
        }

        static void GetAssembly(Assembly assembly)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Name :" + assembly.FullName);
            Console.WriteLine("GAC'ta mı :" + (assembly.GlobalAssemblyCache ? "Evet" : "Hayır"));
            Console.WriteLine("Path :" + assembly.Location);
            Console.WriteLine("Version :" + assembly.ImageRuntimeVersion);
            Console.WriteLine();
        }
    }
}
