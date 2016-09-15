using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class StorageAccountsTests
    {
        private string rgName = "rgstg123";
        private string stgName = "stgbnc732";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDStorageAccount()
        {
            try
            {
                var storageManager = CreateStorageManager();

                // Check name availability
                CheckNameAvailabilityResult result = storageManager.StorageAccounts
                    .CheckNameAvailability(stgName);

                // Create
                IStorageAccount storageAccount = storageManager.StorageAccounts
                    .Define(stgName)
                    .WithRegion(Region.US_EAST)
                    .WithNewResourceGroup(rgName)
                    .Create();
                Assert.True(string.Equals(storageAccount.ResourceGroupName, rgName));
                Assert.True(storageAccount.Sku.Name == SkuName.StandardGRS);

                // List
                var accounts = storageManager.StorageAccounts.ListByGroup(rgName);
                bool found = accounts.Any((IStorageAccount stg) => { return string.Equals(stg.Name, stgName); });
                Assert.True(found);

                // Get
                storageAccount = storageManager.StorageAccounts.GetByGroup(rgName, stgName);
                Assert.NotNull(storageAccount);

                // Get keys 
                Assert.True(storageAccount.Keys.Count() > 0);

                // Regen Key
                StorageAccountKey oldKey = storageAccount.Keys.FirstOrDefault();
                var updatedKeys = storageAccount.RegenerateKey(oldKey.KeyName);
                Assert.True(updatedKeys.Count() > 0);
                var updatedKey = updatedKeys.FirstOrDefault((StorageAccountKey key) => { return string.Equals(key.KeyName, oldKey.KeyName); });
                Assert.NotNull(updatedKey);
                Assert.NotEqual(updatedKey.Value, oldKey.Value);

                // Update
                storageAccount = storageAccount.Update()
                    .WithSku(SkuName.StandardLRS)
                    .Apply();
                Assert.Equal(storageAccount.Sku.Name, SkuName.StandardLRS);
            }
            finally
            {
                try
                {
                    CreateResourceManager().ResourceGroups.Delete(rgName);
                }
                catch
                {}
            }
        }

        private IStorageManager CreateStorageManager()
        {
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            return StorageManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        private IResourceManager CreateResourceManager()
        {
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
