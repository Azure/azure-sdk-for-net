using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class OperationsTests : VMTestBase
    {
        [Fact]
        [Trait("Name", "TestCrpOperations")]
        public void TestCrpOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, "TestCrpOperations"))
            {
                EnsureClientsInitialized(context);
                AzureOperationResponse<IEnumerable<ComputeOperationValue>> operations = m_CrpClient.Operations.ListWithHttpMessagesAsync().GetAwaiter().GetResult();

                Assert.NotNull(operations);
                Assert.NotNull(operations.Body);
            }
        }
    }
}
