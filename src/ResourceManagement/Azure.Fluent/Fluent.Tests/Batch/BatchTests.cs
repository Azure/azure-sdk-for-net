// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Batch.Fluent.Models;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Batch
{
    public class BatchTests
    {
        private string rgName = "rgstg158";
        private string batchAccountName = "batchaccount733";
        private string storageAccountName = "sa733";

        [Fact]
        public async Task CanCRUDBatchAccounts()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var batchAccountName = TestUtilities.GenerateName("batchaccount");
                var storageAccountName = TestUtilities.GenerateName("sa");
                try
                {
                    var batchManager = TestHelper.CreateBatchManager();
                    // Create
                    var batchAccount = await batchManager.BatchAccounts
                            .Define(batchAccountName)
                            .WithRegion(Region.ASIA_EAST)
                            .WithNewResourceGroup(rgName)
                            .CreateAsync();

                    Assert.Equal(rgName, batchAccount.ResourceGroupName);
                    Assert.Null(batchAccount.AutoStorage);
                    // List
                    var accounts = batchManager.BatchAccounts.ListByGroup(rgName);
                    Assert.True(accounts.Any(account => StringComparer.OrdinalIgnoreCase.Equals(account.Name, batchAccountName)));
                    // Get
                    batchAccount = batchManager.BatchAccounts.GetByGroup(rgName, batchAccountName);
                    Assert.NotNull(batchAccount);

                    // Get Keys
                    BatchAccountKeys keys = batchAccount.GetKeys();
                    Assert.NotNull(keys.Primary);
                    Assert.NotNull(keys.Secondary);

                    BatchAccountKeys newKeys = batchAccount.RegenerateKeys(AccountKeyType.Primary);
                    Assert.NotNull(newKeys.Primary);
                    Assert.NotNull(newKeys.Secondary);

                    Assert.NotEqual(newKeys.Primary, keys.Primary);
                    Assert.Equal(newKeys.Secondary, keys.Secondary);

                    batchAccount = batchAccount.Update()
                            .WithNewStorageAccount(storageAccountName)
                            .Apply();

                    Assert.NotNull(batchAccount.AutoStorage.StorageAccountId);
                    Assert.NotNull(batchAccount.AutoStorage.LastKeySync);
                    var lastSync = batchAccount.AutoStorage.LastKeySync;

                    batchAccount.SynchronizeAutoStorageKeys();
                    batchAccount.Refresh();

                    Assert.NotEqual(lastSync, batchAccount.AutoStorage.LastKeySync);

                    // Test applications.
                    var applicationId = "myApplication";
                    var applicationDisplayName = "displayName";
                    var applicationPackageName = "applicationPackage";

                    var updatesAllowed = true;

                    batchAccount.Update()
                            .DefineNewApplication(applicationId)
                                .DefineNewApplicationPackage(applicationPackageName)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(updatesAllowed)
                            .Attach()
                            .Apply();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));

                    // Refresh to fetch batch account and application again.
                    batchAccount.Refresh();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));

                    var application = batchAccount.Applications[applicationId];
                    Assert.Equal(application.DisplayName, applicationDisplayName);
                    Assert.Equal(application.UpdatesAllowed, updatesAllowed);
                    Assert.Equal(1, application.ApplicationPackages.Count);
                    var applicationPackage = application.ApplicationPackages[applicationPackageName];
                    Assert.Equal(applicationPackage.Name, applicationPackageName);

                    // Delete application package directly.
                    applicationPackage.Delete();
                    batchAccount
                            .Update()
                            .WithoutApplication(applicationId)
                            .Apply();

                    batchAccount.Refresh();
                    Assert.False(batchAccount.Applications.ContainsKey(applicationId));

                    var applicationPackage1Name = "applicationPackage1";
                    var applicationPackage2Name = "applicationPackage2";
                    batchAccount.Update()
                            .DefineNewApplication(applicationId)
                                .DefineNewApplicationPackage(applicationPackage1Name)
                                .DefineNewApplicationPackage(applicationPackage2Name)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(updatesAllowed)
                            .Attach()
                            .Apply();
                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));
                    application.Refresh();
                    Assert.Equal(2, application.ApplicationPackages.Count);

                    var newApplicationDisplayName = "newApplicationDisplayName";
                    batchAccount
                            .Update()
                            .UpdateApplication(applicationId)
                                .WithoutApplicationPackage(applicationPackage2Name)
                            .WithDisplayName(newApplicationDisplayName)
                            .Parent()
                            .Apply();
                    application = batchAccount.Applications[applicationId];
                    Assert.Equal(application.DisplayName, newApplicationDisplayName);

                    batchAccount.Refresh();
                    application = batchAccount.Applications[applicationId];

                    Assert.Equal(application.DisplayName, newApplicationDisplayName);
                    Assert.Equal(1, application.ApplicationPackages.Count);

                    applicationPackage = application.ApplicationPackages[applicationPackage1Name];

                    Assert.NotNull(applicationPackage);
                    Assert.NotNull(applicationPackage.Id);
                    Assert.Equal(applicationPackage.Name, applicationPackage1Name);
                    Assert.Null(applicationPackage.Format);

                    batchAccount
                            .Update()
                            .UpdateApplication(applicationId)
                                .WithoutApplicationPackage(applicationPackage1Name)
                            .Parent()
                            .Apply();

                    try
                    {
                        await batchManager.BatchAccounts.DeleteByIdAsync(batchAccount.Id);
                    }
                    catch
                    {
                    }

                    var batchAccounts = batchManager.BatchAccounts.ListByGroup(rgName);

                    Assert.Equal(batchAccounts.Count, 0);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public async Task CanCreateBatchAccountWithApplication()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var applicationId = "myApplication";
                    var applicationDisplayName = "displayName";
                    var allowUpdates = true;

                    var batchManager = TestHelper.CreateBatchManager();

                    // Create
                    var batchAccount = await batchManager.BatchAccounts
                        .Define(batchAccountName)
                        .WithRegion(Region.ASIA_SOUTHEAST)
                        .WithNewResourceGroup(rgName)
                        .DefineNewApplication(applicationId)
                            .WithDisplayName(applicationDisplayName)
                            .WithAllowUpdates(allowUpdates)
                            .Attach()
                        .WithNewStorageAccount(storageAccountName)
                        .CreateAsync();
                    Assert.Equal(rgName, batchAccount.ResourceGroupName);
                    Assert.NotNull(batchAccount.AutoStorage);
                    Assert.Equal(ResourceUtils.NameFromResourceId(batchAccount.AutoStorage.StorageAccountId), storageAccountName);

                    // List
                    var accounts = batchManager.BatchAccounts.ListByGroup(rgName);
                    Assert.True(accounts.Any(account => StringComparer.OrdinalIgnoreCase.Equals(account.Name, batchAccountName)));

                    // Get
                    batchAccount = batchManager.BatchAccounts.GetByGroup(rgName, batchAccountName);
                    Assert.NotNull(batchAccount);

                    Assert.True(batchAccount.Applications.ContainsKey(applicationId));
                    var application = batchAccount.Applications[applicationId];

                    Assert.NotNull(application);
                    Assert.Equal(application.DisplayName, applicationDisplayName);
                    Assert.Equal(application.UpdatesAllowed, allowUpdates);

                    try
                    {
                        await batchManager.BatchAccounts.DeleteByGroupAsync(batchAccount.ResourceGroupName, batchAccountName);
                    }
                    catch
                    {
                    }
                    var batchAccounts = batchManager.BatchAccounts.ListByGroup(rgName);

                    Assert.Equal(batchAccounts.Count, 0);
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}