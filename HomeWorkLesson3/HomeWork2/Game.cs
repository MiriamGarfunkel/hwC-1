using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Game:Product
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public bool Hard { get; set; }

        public override string ToString()
        {
            return base.Name + base.price + Id + Age + Hard;
        }
    }
}
