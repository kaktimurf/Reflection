using SDK;
using System;

namespace BiggerString
{
    public class BiggerString:IPlugin
    {
        public string Action(string text)
        {
            return text.ToUpper();
        }

        public string Name()
        {
            return "Büyük Harf";
        }
    }
}
