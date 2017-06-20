// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Storage
{
    public class StorageAccountsTests
    {
        [Fact]
        public void CanCRUDStorageAccount()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var stgName = TestUtilities.GenerateName("stgbnc");
                try
                {
                    var storageManager = TestHelper.CreateStorageManager();

                    // Check name availability
                    CheckNameAvailabilityResult result = storageManager.StorageAccounts
                        .CheckNameAvailability(stgName);

                    // Create
                    IStorageAccount storageAccount = storageManager.StorageAccounts
                        .Define(stgName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithTag("tag1", "value1")
                        .Create();

                    Assert.True(string.Equals(storageAccount.ResourceGroupName, rgName));
                    Assert.True(storageAccount.Sku.Name == SkuName.StandardGRS);
                    Assert.NotNull(storageAccount.Tags);
                    Assert.Equal(1, storageAccount.Tags.Count);

                    // List
                    var accounts = storageManager.StorageAccounts.ListByResourceGroup(rgName);
                    bool found = accounts.Any((IStorageAccount stg) => { return string.Equals(stg.Name, stgName); });
                    Assert.True(found);

                    // Get
                    storageAccount = storageManager.StorageAccounts.GetByResourceGroup(rgName, stgName);
                    Assert.NotNull(storageAccount);
                    Assert.NotNull(storageAccount.Tags);
                    Assert.Equal(storageAccount.Tags.Count, 1);

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
                        .WithoutTag("tag1")
                        .Apply();

                    Assert.Equal(storageAccount.Sku.Name, SkuName.StandardLRS);
                    Assert.NotNull(storageAccount.Tags);
                    Assert.Equal(2, storageAccount.Tags.Count);
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
