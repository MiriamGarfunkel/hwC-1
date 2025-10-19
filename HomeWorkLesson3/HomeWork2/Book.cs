using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Book : Product
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return base.Name + base.price + Id + BookName + Author;
        }
    }
}