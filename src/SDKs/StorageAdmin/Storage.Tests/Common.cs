using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.AzureStack.Storage.Admin;
using TestCommon;

namespace Storage.Tests
{
    class Common
    {
        public static StorageAdminClient CreateAndValidateStorageAdminClient(TestCommon.TestingParameters parameters)
        {
            // Create client using parametes from file
            StorageAdminClient client = new StorageAdminClient(parameters.BaseUri, TestCommon.Authentification.GetCredentials(parameters)) {
                SubscriptionId = parameters.SubscriptionId
            };

            // validate creation
            Assert.IsNotNull(client);

            // validate objects
            Assert.IsNotNull(client.Blobs);
            Assert.IsNotNull(client.Containers);
            Assert.IsNotNull(client.Farms);
            Assert.IsNotNull(client.Queues);
            Assert.IsNotNull(client.Quotas);
            Assert.IsNotNull(client.Shares);
            Assert.IsNotNull(client.StorageAccounts);
            Assert.IsNotNull(client.Tables);

            // validate properties
            Assert.AreEqual(parameters.SubscriptionId, client.SubscriptionId);

            return client;
        }
    }
}
