using FluentAssertions;
using System;
using Xunit;

namespace ShopWAUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = "true";
            //Assert.Equal("false", result);
            result.Should().Be("false");
        }
    }
}
