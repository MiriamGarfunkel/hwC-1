using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle[] c=new Circle[10];
            var Circle1 = from Circle in c
                          where Circle.radious > 3
                          select Circle;

        }
    }
}
