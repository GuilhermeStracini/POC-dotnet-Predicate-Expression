using System;

namespace POCPredicate;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");

        Test.Resolve<Teste>(t =>
            (t.IsActive && t.Name == "Test" && t.Document == "1")
            || (t.Name == "or" && t.Document == "2")
            || t.Document == "3"
            || !t.IsActive
        );
    }
}
