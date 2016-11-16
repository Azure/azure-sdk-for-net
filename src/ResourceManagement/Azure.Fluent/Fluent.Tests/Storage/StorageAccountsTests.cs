// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Xunit;

namespace Fluent.Tests.Storage
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
                Assert.True(storageAccount.GetKeys().Count() > 0);

                // Regen Key
                StorageAccountKey oldKey = storageAccount.GetKeys().FirstOrDefault();
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
                    CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                }
                catch
                {}
            }
        }

        private IStorageManager CreateStorageManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            return StorageManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        private IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IResourceManager resourceManager = Microsoft.Azure.Management.Resource.Fluent.ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
