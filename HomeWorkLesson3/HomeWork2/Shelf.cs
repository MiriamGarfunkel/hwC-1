using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Shelf<T>
    {
        internal IEnumerable<Book> books;

        public int NumberShelf { get; set; }
        public int NumberRow { get; set; }
        public int Weight { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
