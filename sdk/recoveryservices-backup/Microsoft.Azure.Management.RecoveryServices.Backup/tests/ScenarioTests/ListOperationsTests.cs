using System;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class ListOperationsTests: TestBase, IDisposable
    {

        [Fact]
        public void ListOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var backupClient = context.GetServiceClient<RecoveryServicesBackupClient>();
                IPage<ClientDiscoveryValueForSingleApi> operations = backupClient.Operations.List();

                Assert.NotNull(operations);
                Assert.True(operations.Any());
            }
        }

        public void Dispose()
        {
        }
    }
}
