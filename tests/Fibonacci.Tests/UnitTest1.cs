using System;
using Xunit;
using Fibonacci;

namespace Fibonacci.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Execute44ShouldReturn701408733()
        {
            var result = Fibonacci.Compute.Execute(new[] { "44" });
            Assert.Equal(701408733, result[0]);
        }
    }
}
