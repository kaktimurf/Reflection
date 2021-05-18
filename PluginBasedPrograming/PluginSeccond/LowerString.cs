using System;
using SDK;

namespace PluginSeccond
{
    public class LowerString:IPlugin
    {
        public string Action(string text)
        {
            return text.ToLower();
        }

        public string Name()
        {
            return "Küçük Harf";
        }
    }
}
