namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class OperationsTest : HybridDataTestBase
    {
        public OperationsTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        //Operations_List
        [Fact]
        public void Operations_List()
        {
            try
            {
                //operations allowed
                var operations = Client.Operations.List();
                Assert.NotNull(operations);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}

