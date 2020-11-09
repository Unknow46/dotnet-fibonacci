using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Fibonacci.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Execute44ShouldReturn701408733()
        {

            var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
            var dataBaseName = Guid.NewGuid().ToString(); 
            builder.UseInMemoryDatabase(dataBaseName);
            var options = builder.Options;
            var fibonacciDataContext = new FibonacciDataContext(options);
            await fibonacciDataContext.Database.EnsureCreatedAsync(); 

            var compute = new Compute(fibonacciDataContext);
            var result = compute.Execute(new[] {"44"});
            var cmp = fibonacciDataContext.TFibonacci.First();

            Assert.Equal(701408733, result.Result[0]);
            Assert.Equal(701408733, cmp.FibOutput);
        }
    }
}
