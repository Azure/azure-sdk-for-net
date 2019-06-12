using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Rest.Azure;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DataBox.Tests.Tests
{
    public class OperationsTests : DataBoxTestBase
    {
        public OperationsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestOperationsAPI()
        {
            try
            {
                //operations allowed
                var operations = GetOperations();
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private IPage<Operation> GetOperations()
        {
            var operations = this.Client.Operations.List();

            Assert.True(operations != null, "List call for Operations was not successful.");

            return operations;
        }
    }
}
