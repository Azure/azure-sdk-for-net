// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.V2.Batch;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class BatchTests
    {
        private string rgName = "rgstg1558";
        private string batchAccountName = "batchaccount732";
        private string storageAccountName = "sa732";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public async Task CanCRUDBatchAccounts()
        {
            try
            {
                var batchManager = CreateBatchManager();
                var batchAccount = await batchManager.BatchAccounts
                    .Define(batchAccountName)
                    .WithRegion(Region.JAPAN_WEST)
                    .WithNewResourceGroup(rgName)
                    .WithNewStorageAccount(storageAccountName + new Random().Next() % 100)
                    .CreateAsync();

                Assert.NotNull(batchAccount.AutoStorage);
                Assert.NotNull(batchAccount.AutoStorage.StorageAccountId);

                batchAccount = await batchAccount.Update().WithoutStorageAccount().ApplyAsync();

                Assert.Null(batchAccount.AutoStorage);
                batchAccount.Refresh();
                var keys = batchAccount.Keys();

                Assert.NotNull(keys.Primary);
                Assert.NotNull(keys.Secondary);

                var newKeys = batchAccount.RegenerateKeys(AccountKeyType.Primary);

                Assert.NotEqual(keys.Primary, newKeys.Primary);
                Assert.Equal(keys.Secondary, newKeys.Secondary);

                try
                {
                    await batchManager.BatchAccounts.DeleteAsync(batchAccount.Id);
                }
                catch
                {
                }

                var batchAccounts = batchManager.BatchAccounts.ListByGroup(rgName);

                Assert.Equal(batchAccounts.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.True(false, "Should not have caught any exception - " + ex);
            }
            finally
            {
                try
                {
                    var resourceManager = CreateResourceManager();
                    resourceManager.ResourceGroups.Delete(rgName);
                }
                catch { }
            }
        }

        private IBatchManager CreateBatchManager()
        {
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            return BatchManager
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