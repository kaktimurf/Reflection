using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class MyClass
    {
        private int x, y;

        public MyClass(int i,int j)
        {
            x = i;
            y = j;
        }

        public int Sum()
        {
            return x + y;
        }

        public bool IsBetween(int i)
        {
            if (x<i && i<y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Set(int a, int b)
        {
            Console.Write("Inside Set(int,int)");
            x = a;
            y = b;
            Show();
        }

        public void Set(double a, double b)
        {
            Console.Write("Inside Set(double,double)");
            x = (int)a;
            y = (int)b;
            Show();
        }

        public void Show()
        {
            Console.WriteLine("x: {0}, y:{1}",x,y);
        }
    }
}
