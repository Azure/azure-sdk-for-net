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

        [Fact]
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
                    .WithTag("t1", "v1")
                    .WithTag("t2", "v2")
                    .Create();

                Assert.True(string.Equals(storageAccount.ResourceGroupName, rgName));
                Assert.True(storageAccount.Sku.Name == SkuName.StandardGRS);
                Assert.NotNull(storageAccount.Tags);
                Assert.Equal(storageAccount.Tags.Count, 2);

                // List
                var accounts = storageManager.StorageAccounts.ListByGroup(rgName);
                bool found = accounts.Any((IStorageAccount stg) => { return string.Equals(stg.Name, stgName); });
                Assert.True(found);

                // Get
                storageAccount = storageManager.StorageAccounts.GetByGroup(rgName, stgName);
                Assert.NotNull(storageAccount);
                Assert.NotNull(storageAccount.Tags);
                Assert.Equal(storageAccount.Tags.Count, 2);

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
                    .WithTag("t3", "v3")
                    .WithTag("t4", "v4")
                    .WithoutTag("t2")
                    .Apply();

                Assert.Equal(storageAccount.Sku.Name, SkuName.StandardLRS);
                Assert.NotNull(storageAccount.Tags);
                Assert.Equal(storageAccount.Tags.Count, 3);
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
