using System;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(123);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(random.Next(1, 50));
            }
        }
    }
}
