
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
        var results = await Compute.Execute(args);
        foreach (var result in results) Console.WriteLine($"Result: {result}");
        stopwatch.Stop();
        Console.Write($"Elapsed seconds: {stopwatch.Elapsed.TotalSeconds}");
    }
}