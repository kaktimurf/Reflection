using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    public interface IPlugin
    {
        string Action(string text);
        string Name();
    }
}
