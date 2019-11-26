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

        
        protected override void ValidateClient(StorageAdminClient client)
        {
            // validate creation
            Assert.NotNull(client);

            // validate objects
            Assert.NotNull(client.StorageQuotas);
            Assert.NotNull(client.StorageSettings);
            Assert.NotNull(client.StorageAccounts);
        }
    }
}
