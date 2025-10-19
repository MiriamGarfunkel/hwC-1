using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace HomeWork2
{
    public class Program2
    {
        const string FILENAME = @"C:\Users\Miriam\Desktop\הנדסאים שנה ב\C#\HomeWorkLesson2\file1.txt";
  
        public static void Read(List<Shelf<Book>> shelves)
        {
            
            StreamWriter streamWriter;
            streamWriter = new StreamWriter(FILENAME, true);
            foreach (Shelf<Book> shelf in shelves) { 
                     foreach (Book book in shelf.books)
            {
                    streamWriter.WriteLine(book);
                  

                }
        }
            streamWriter.Close();

        }
        public static void Write()
        {
            if (!File.Exists(FILENAME))
                throw new FileNotFoundException("not found", FILENAME);
            StreamReader streamReader;
            streamReader = new StreamReader(FILENAME);
            List<Book> info = new List<Book>();
            while (!streamReader.EndOfStream)
            {
               string ?str= streamReader.ReadLine();
                var arr = str.Split(' ');
                info.Add(new Book {BookName= arr[1] , Author = arr[2] });

            }
            streamReader.Close();
        }

    }
}
