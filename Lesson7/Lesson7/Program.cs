using Lesson7;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        var manager = new Calls("..\\..\\..\\..\\phone.xml");

        var miriamCalls = manager.func1();
        Console.WriteLine("length of calls to miriam from phone 1");
        miriamCalls.ForEach(Console.WriteLine);

        var shiraPhones = manager.func2();
        Console.WriteLine("\nphones that somone spoke to shira:");
        shiraPhones.ForEach(Console.WriteLine);

        var longCalls = manager.func3();
        Console.WriteLine("\nphones that spoke over 10 min");
        longCalls.ForEach(Console.WriteLine);

        manager.AddCall("2", "09:44", "40", "chaya");
        manager.DeleteCall("1", "dina");
    }
}




