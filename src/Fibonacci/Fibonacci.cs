﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fibonacci
{
    public static class Compute
    {
        public static int Fib(int i)
        {
            if (i <= 2) return 1;
            return Fib(i - 2) + Fib(i - 1);
        }

        public static async Task<IList<int>> Execute(string[] args)
        {
            var results = new List<int>();
            using (var fibonacciDataContext = new FibonacciDataContext())
            {
                IList<Task<int>> tasks = new List<Task<int>>();
                foreach (var arg in args)
                {
                    var i = int.Parse(arg);
                    var output = await fibonacciDataContext.TFibonacci.Where(f => f.FibInput == i).Select(f => f.FibOutput).FirstOrDefaultAsync();
                    Task<int> task;
                    if (output == default)
                    {
                        task = Task.Run(() => Fib(i));
                    }
                    else
                    {
                        task = Task.FromResult((int)output);
                    }
                    tasks.Add(task);
                };

                foreach (var task in tasks)
                {
                    var indexOf = tasks.IndexOf(task);
                    var arg = args[indexOf];
                    results.Add(task.Result);
                    fibonacciDataContext.TFibonacci.Add(new TFibonacci()
                    {
                        FibInput = int.Parse(arg),
                        FibOutput = task.Result,
                        FibCreatedTimeStamp = DateTime.Now
                    });
                }
                await fibonacciDataContext.SaveChangesAsync();
                return results;
            }
        }
    }
}