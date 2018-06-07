using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class StorageTestBase : AzureStackTestBase<StorageAdminClient>
    {
        public StorageTestBase()
        {
        }

        public string ResourceGroupName = "System.local";
        
        protected override void ValidateClient(StorageAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.BlobServices);
            Assert.NotNull(client.Containers);
            Assert.NotNull(client.Farms);
            Assert.NotNull(client.QueueServices);
            Assert.NotNull(client.StorageQuotas);
            Assert.NotNull(client.Shares);
            Assert.NotNull(client.StorageAccounts);
            Assert.NotNull(client.TableServices);
        }
    }
}
