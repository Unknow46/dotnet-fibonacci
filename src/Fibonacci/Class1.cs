using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibonacci
{
    //public class Hello
    //{
    //    public void parlle()
    //    {
    //        Console.WriteLine("Hello de la lib!");
    //    }
        
    //    public static string Fib(string ligne)
    //    {
    //        int i = short.Parse(ligne);
        
    //        int Fib_two(int i)
    //        {
    //            return i switch
    //            {
    //                int when i <= 2 => 1,
    //                _ => Fib_two(i - 1) + Fib_two(i - 2)
    //            };
    //        }

    //        var res = Fib_two(i);
    //        Console.WriteLine("Fibonacci for "+i+" is find");
    //        return "For "+i+" Fibonacci is : " + res;
    //    }
    //}


    public static class Compute
    {
        public static int Fib(int i)
        {
            if (i <= 2) return 1;
            return Fib(i - 2) + Fib(i - 1);
        }

        public static IList<int> Execute(string[] args)
        {
            var results = new ConcurrentBag<int>();
            Parallel.ForEach(args, (arg) =>
            {
                var result = Fib(int.Parse(arg));
                results.Add(result);
            });
            return results.ToList();
        }


    }
}
