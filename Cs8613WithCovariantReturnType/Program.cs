using ClassLibrary;
using System;

namespace Cs8613WithCovariantReturnType
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new TestClassCollection();

            foreach (IBaseInterface? y in x)
            { Console.WriteLine(y?.ToString() ?? "<NULL>"); }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
