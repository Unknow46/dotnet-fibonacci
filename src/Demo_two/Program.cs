
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Fibonacci;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        using (var fibonacciDataContext = new FibonacciDataContext())
        {
            var compute = new Compute(fibonacciDataContext);
            var results = await compute.Execute(args);
            foreach (var result in results) Console.WriteLine($"Result: {result}");
            stopwatch.Stop();
            Console.Write($"Elapsed seconds: {stopwatch.Elapsed.TotalSeconds}");
        }
    }
}