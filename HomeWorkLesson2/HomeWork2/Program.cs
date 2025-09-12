namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
       


            List<Shelf<Book>> shelves = new List<Shelf<Book>>
            {
                new Shelf<Book> { NumberShelf = 1, NumberRow = 1, Weight = 2, Items = new List<Book>
                {
                    new Book { Id = 1, Name = "Book", price = 120, BookName = "kids story", Author = "Miriam" },
                    new Book { Id = 2, Name = "Book", price = 40, BookName = "fun", Author = "Chaya" }
                }},
                new Shelf<Book> { NumberShelf = 2, NumberRow = 1, Weight = 1, Items = new List<Book>
                {
                    new Book { Id = 3, Name = "Book", price = 150, BookName = "nice", Author = "Leah" }
                }},
                new Shelf<Book> { NumberShelf = 3, NumberRow = 2, Weight = 3, Items = new List<Book>
                {
                    new Book { Id = 4, Name = "Book", price = 30, BookName = "Story", Author = "Dina" },
                    new Book { Id = 5, Name = "Book", price = 200, BookName = "Bove", Author = "Miriam" }
                }}
            };
            var fullShelves =
             from s in shelves
             where s.Items.Count >= s.Weight
             select s;

            var kidsShelves =
              from s in shelves
              where s.Items.Any(b => b.price <= 50)
              select s;

            var expensiveShelves =
              from s in shelves
              where s.Items.Any(b => b.price > 100)
              select s;

            var multipleBooks =
             from s in shelves
             where s.Items.Count > 1
             select s;

            var alephBooks =
            from s in shelves
            where s.Items.Any(b => b.BookName.StartsWith("B"))
            select s;

            Console.WriteLine("full shelves");
            foreach (var shelf in fullShelves)
                Console.WriteLine($"shelf {shelf.NumberShelf}/{shelf.NumberRow}");
            Console.WriteLine("\nshelves with kids books");
            foreach (var shelf in kidsShelves)
                Console.WriteLine($"shelf {shelf.NumberShelf}/{shelf.NumberRow}");
            Console.WriteLine("\nshelfs with exspensive books");
            foreach (var shelf in expensiveShelves)
                Console.WriteLine($"shelf {shelf.NumberShelf}/{shelf.NumberRow}");


            Console.WriteLine("\nshelves with more then one book");
            foreach (var shelf in multipleBooks)
                Console.WriteLine($"shelf {shelf.NumberShelf}/{shelf.NumberRow}");
            Console.WriteLine("\nshelfs with a book that starts with the latter B");
            foreach (var shelf in alephBooks)
                Console.WriteLine($"shelf {shelf.NumberShelf}/{shelf.NumberRow}");
        }
    }
}
