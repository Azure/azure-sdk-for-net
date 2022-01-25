using Microsoft.Azure.Management.HybridConnectivity.Models;
using Microsoft.Azure.Management.HybridConnectivity.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.HybridConnectivity.Tests
{
    public class OperationsTests : TestBase
    {
        [Fact]
        public void ListOperations()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridConnectivityManagementClient(context);
                IPage<Operation> response = client.Operations.List();
                Assert.NotNull(response);
                Assert.NotEmpty(response);
                foreach(Operation op in response)
                {
                    Assert.NotNull(op.Display);
                    Assert.NotNull(op.IsDataAction);
                    Assert.False(string.IsNullOrEmpty(op.Name));
                }
            }
        }

        [Fact]
        public async void ListOperationsAsync()
        {
            using (MockContext context = MockContext.Start(GetType().FullName))
            {
                var client = this.GetHybridConnectivityManagementClient(context);
                IPage<Operation> response = await client.Operations.ListAsync().ConfigureAwait(false);
                Assert.NotNull(response);
                Assert.NotEmpty(response);
                foreach (Operation op in response)
                {
                    Assert.NotNull(op.Display);
                    Assert.NotNull(op.IsDataAction);
                    Assert.False(string.IsNullOrEmpty(op.Name));
                }
            }
        }
    }
}
