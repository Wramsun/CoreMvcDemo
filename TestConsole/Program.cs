using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in yieldTest.GetList(5))
                Console.Write(item);

            Console.ReadKey();

        }
    }
}
