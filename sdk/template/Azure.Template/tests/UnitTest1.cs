using Azure.Runtime;
using System;
using Xunit;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var c = new Class1();

            Assert.NotNull(c);
        }
    }
}
