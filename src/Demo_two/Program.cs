using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using Fibonacci;


internal class Program
{
    private static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        // IList<Task<string>> tasks = new List<Task<string>>();
        var res = new ParallelOptions();
        var results = new ConcurrentBag<string>();

        Parallel.ForEach(args, res, (arg) =>
        {
            var result = Fibonacci.Compute.Fib(int.Parse(arg));
           // results.Add(resul);
        });

        // var h = new Hello();
        // h.parlle();
        // foreach ( var  ligne in args)
        // {
        //     //var task = Task<string>.Run(() => Fib(ligne));
        //     //tasks.Add(task);
        //     var re = Fib(ligne);
        // }
        //var ligne = Console.ReadLine();
        
        foreach (var task in results)
        {
            Console.WriteLine($"Resulte : {task}");
        }
        
        stopwatch.Stop();
        Console.WriteLine("Time seconde : "+ stopwatch.Elapsed.TotalSeconds);
        

        

        // Console.WriteLine("Fibonacci is : " + Fib_two(i));
    }

}