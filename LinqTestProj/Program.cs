using System;
namespace LinqTestProj
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Channels;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(i);
            }
            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
            PrintCollection(firstAndLastFive);
            Console.WriteLine("\n");
         //---------------------------------------------------
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result =
                from v in values
                where v < 37
                orderby -v
                select v;
            PrintCollection(result);
            Console.WriteLine("\n");
         //---------------------------------------------------
            AddSubtract addSubtract = new AddSubtract() { Value = 10 }
               .Add(1)
               .Sub(2)
               .Add(3)
               .Sub(4);

            Console.WriteLine($"{addSubtract.Value}");
        }
        private static void PrintCollection(IEnumerable<int> coll) {
            foreach (var item in coll)
            {
                Console.WriteLine($"{item} ");
            }
        }       
    }
    class AddSubtract { 
        public int Value { get; set; }
        public AddSubtract Add(int i) { 
            return new AddSubtract { Value = Value + i};
        }
        public AddSubtract Sub(int i) { 
            return new AddSubtract{ Value = Value - i};
        }
    }
}