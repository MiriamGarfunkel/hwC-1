
using lesson8;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CUsersMiriamDesktopהנדסאיםשנהבCLesson7MydbMdfContext())
            {
                Console.WriteLine("apartments:");
                var apartments = db.Apartments.ToList();
                foreach (var a in apartments)
                {
                    Console.WriteLine($"{a.Id}: {a.Rooms} - {a.Floor} ");
                }

                Console.WriteLine("\nmoshes apartments:");
                var mosheInterests = db.Users
                    .Where(u => u.Name == "moshe")
                    .SelectMany(u => u.Rents)       // כל ההשכרות של משה
                    .Select(r => r.Apartment)       // כל דירה מתוך כל השכרה
                    .Where(a => a != null);         // לוודא שלא null

                foreach (var apt in mosheInterests)
                {
                    Console.WriteLine($"{apt.Id}: {apt.Rooms} rooms, floor {apt.Floor}");
                }


                Console.WriteLine("\nadd apartment");

                var newApart = new Apartment
                {
                    Id=9,
                   Rooms =6,
                   Floor = 2,
 
                };

                db.Apartments.Add(newApart);
                db.SaveChanges();

                Console.WriteLine("added successfully!!");

                Console.WriteLine("\nadd user:");

                var newCustomer = new User
                {
                    Id=172,
                    Name = "leah",
                    PhoneNunber = "0501234567"
                };

                db.Users.Add(newCustomer);
                db.SaveChanges();

                Console.WriteLine(" added sucssefully!!!");
            }

        }
    }
}

