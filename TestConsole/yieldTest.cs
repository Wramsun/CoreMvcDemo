using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public static class yieldTest
    {
        static Random r = new Random();
        public static IEnumerable<int> GetList(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return r.Next(10);
            }
        }
    }
}
