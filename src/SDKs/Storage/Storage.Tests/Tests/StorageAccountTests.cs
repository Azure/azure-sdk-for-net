// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ResourceGroups.Tests;
using Storage.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using Microsoft.Azure.KeyVault.WebKey;
using System.Text.RegularExpressions;

namespace Storage.Tests
{
    public class StorageAccountTests
    {
        [Fact]
        public void StorageAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Make sure a second create returns immediately
                var createRequest = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create storage account with only required params
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountCreateWithEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                    KeySource = KeySource.MicrosoftStorage
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Verify encryption settings
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }
            }
        }

        [Fact]
        public void StorageAccountCreateWithAccessTierTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with hot
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.BlobStorage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    AccessTier = AccessTier.Hot
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.Equal(AccessTier.Hot, account.AccessTier);
                Assert.Equal(Kind.BlobStorage, account.Kind);

                // Create storage account with cool
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.BlobStorage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    AccessTier = AccessTier.Cool
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.Equal(AccessTier.Cool, account.AccessTier);
                Assert.Equal(Kind.BlobStorage, account.Kind);
            }
        }

        [Fact]
        public void StorageAccountBeginCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                var response = storageMgmtClient.StorageAccounts.BeginCreate(rgname, accountName, parameters);
            }
        }

        [Fact]
        public void StorageAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                storageMgmtClient.StorageAccounts.Delete(rgname, "missingaccount");

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Delete an account
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                storageMgmtClient.StorageAccounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void StorageAccountGetStandardTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create and get a RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardRAGRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a ZRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardZRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountGetBlobTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a blob LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardLRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob GRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardGRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob RAGRS storage account
                accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardRAGRS;
                parameters.Kind = Kind.BlobStorage;
                parameters.AccessTier = AccessTier.Hot;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountGetPremiumTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();

                // Create and get a Premium LRS storage account
                string accountName = TestUtilities.GenerateName("sto");
                parameters.Sku.Name = SkuName.StandardLRS;
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
        }

        [Fact]
        public void StorageAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create storage accounts
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                StorageManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                StorageManagementTestUtilities.VerifyAccountProperties(accounts.ToArray()[1], true);
            }
        }

        [Fact]
        public void StorageAccountListWithEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption()
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                    KeySource = KeySource.MicrosoftStorage
                };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                // List account and verify
                var accounts = storageMgmtClient.StorageAccounts.ListByResourceGroup(rgname);
                Assert.Equal(1, accounts.Count());

                var account = accounts.ToArray()[0];
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }
            }
        }

        [Fact]
        public void StorageAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);


                // Create resource group and storage account
                var rgname1 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname1);

                // Create different resource group and storage account
                var rgname2 = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname2);

                var accounts = storageMgmtClient.StorageAccounts.List();

                StorageAccount account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                StorageManagementTestUtilities.VerifyAccountProperties(account1, true);

                StorageAccount account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                StorageManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void StorageAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // List keys
                var keys = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                StorageAccountKey key1 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key1"));
                Assert.NotNull(key1);
                Assert.Equal(KeyPermission.Full, key1.Permissions);
                Assert.NotNull(key1.Value);

                // Validate Key2
                StorageAccountKey key2 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);
                Assert.Equal(KeyPermission.Full, key2.Permissions);
                Assert.NotNull(key2.Value);
            }
        }

        [Fact]
        public void StorageAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // List keys
                var keys = storageMgmtClient.StorageAccounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                StorageAccountKey key2 = keys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = storageMgmtClient.StorageAccounts.RegenerateKey(rgname, accountName, "key2");
                StorageAccountKey key2Regen = regenKeys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2.Value, key2Regen.Value);
            }
        }

        [Fact]
        public void StorageAccountCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                string rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Check valid name
                string accountName = TestUtilities.GenerateName("sto");
                var checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.Equal(true, checkNameRequest.NameAvailable);
                Assert.Null(checkNameRequest.Reason);
                Assert.Null(checkNameRequest.Message);

                // Check invalid name
                accountName = "CAPS";
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.Equal(false, checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AccountNameInvalid, checkNameRequest.Reason);
                Assert.Equal("CAPS is not a valid storage account name. Storage account name must be between 3 and 24 "
                    + "characters in length and use numbers and lower-case letters only.", checkNameRequest.Message);

                // Check name of account that already exists
                accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);
                checkNameRequest = storageMgmtClient.StorageAccounts.CheckNameAvailability(accountName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal(Reason.AlreadyExists, checkNameRequest.Reason);
                Assert.Equal("The storage account named " + accountName + " is already taken.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void StorageAccountUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Kind = Kind.Storage,
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Update storage tags
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }

                // Update storage custom domains
                parameters = new StorageAccountCreateParameters
                {
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    Sku = new Sku { Name = StorageManagementTestUtilities.DefaultSkuName },
                    Kind = Kind.Storage,
                    CustomDomain = new CustomDomain
                    {
                        Name = "foo.example.com",
                        UseSubDomain = true
                    }
                };

                try
                {
                    storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Body.Code);
                    Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }

        [Fact]
        public void StorageAccountUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Update storage tags
                parameters = new StorageAccountUpdateParameters
                {
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.Equal(false, account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }

                // Update storage custom domains
                parameters = new StorageAccountUpdateParameters
                {
                    CustomDomain = new CustomDomain
                    {
                        Name = "foo.example.com",
                        UseSubDomain = true
                    }
                };

                try
                {
                    storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                    Assert.Equal("StorageDomainNameCouldNotVerify", ex.Body.Code);
                    Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "));
                }
            }
        }

        [Fact]
        public void StorageAccountUpdateMultipleTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardLRS },
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);
            }
        }

        [Fact]
        public void StorageAccountUsageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Query usage
                var usages = storageMgmtClient.Usages.List();
                Assert.Equal(1, usages.Count());
                Assert.Equal(UsageUnit.Count, usages.First().Unit);
                Assert.NotNull(usages.First().CurrentValue);
                Assert.Equal(250, usages.First().Limit);
                Assert.NotNull(usages.First().Name);
                Assert.Equal("StorageAccounts", usages.First().Name.Value);
                Assert.Equal("Storage Accounts", usages.First().Name.LocalizedValue);
            }
        }

        // [Fact]
        public void StorageAccountGetOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var ops = resourcesClient.ResourceProviderOperationDetails.List("Microsoft.Storage", "2015-06-15");

                Assert.Equal(ops.Count(), 7);
            }
        }

        [Fact]
        public void StorageAccountListAccountSASTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                var accountSasParameters = new AccountSasParameters()
                {
                    Services = "bftq",
                    ResourceTypes = "sco",
                    Permissions = "rdwlacup",
                    Protocols = HttpProtocol.Httpshttp,
                    SharedAccessStartTime = DateTime.UtcNow,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                    KeyToSign = "key1"
                };
                var result = storageMgmtClient.StorageAccounts.ListAccountSAS(rgname, accountName, accountSasParameters);

                var resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.AccountSasToken);

                Assert.Equal(accountSasParameters.Services, resultCredentials.Services);
                Assert.Equal(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
                Assert.Equal(accountSasParameters.Permissions, resultCredentials.Permissions);
                Assert.Equal(accountSasParameters.Protocols, resultCredentials.Protocols);

                //Assert.Equal(accountSasParameters.SharedAccessStartTime, resultCredentials.SharedAccessStartTime);

                Assert.NotNull(accountSasParameters.SharedAccessStartTime);
                Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
            }
        }

        [Fact]
        public void StorageAccountListAccountSASWithDefaultProperties()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                // Test for default values of sas credentials.
                var accountSasParameters = new AccountSasParameters()
                {
                    Services = "b",
                    ResourceTypes = "sco",
                    Permissions = "rl",
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                };

                var result = storageMgmtClient.StorageAccounts.ListAccountSAS(rgname, accountName, accountSasParameters);

                var resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.AccountSasToken);

                Assert.Equal(accountSasParameters.Services, resultCredentials.Services);
                Assert.Equal(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
                Assert.Equal(accountSasParameters.Permissions, resultCredentials.Permissions);

                Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
            }
        }

        [Fact]
        public void StorageAccountListAccountSASWithMissingProperties()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                // Test for default values of sas credentials.
                var accountSasParameters = new AccountSasParameters()
                {
                    Services = "b",
                    ResourceTypes = "sco",
                    Permissions = "rl",
                };
                try
                {
                    var result = storageMgmtClient.StorageAccounts.ListAccountSAS(rgname, accountName, accountSasParameters);
                    var resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.AccountSasToken);
                }
                catch (Exception ex)
                {
                    Assert.Equal("Values for request parameters are invalid: signedExpiry.", ex.Message);
                    return;
                }
                throw new Exception("AccountSasToken shouldn't be returned without SharedAccessExpiryTime");
            }
        }
        [Fact]
        public void StorageAccountListServiceSASTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                var serviceSasParameters = new ServiceSasParameters()
                {
                    CanonicalizedResource = "/blob/" + accountName + "/music",
                    Resource = "c",
                    Permissions = "rdwlacup",
                    Protocols = HttpProtocol.Httpshttp,
                    SharedAccessStartTime = DateTime.UtcNow,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                    KeyToSign = "key1"
                };
                var result = storageMgmtClient.StorageAccounts.ListServiceSAS(rgname, accountName, serviceSasParameters);

                var resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.ServiceSasToken);

                Assert.Equal(serviceSasParameters.Resource, resultCredentials.Resource);
                Assert.Equal(serviceSasParameters.Permissions, resultCredentials.Permissions);
                Assert.Equal(serviceSasParameters.Protocols, resultCredentials.Protocols);

                Assert.NotNull(serviceSasParameters.SharedAccessStartTime);
                Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
            }
        }

        [Fact]
        public void StorageAccountListServiceSASWithDefaultProperties()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                // Test for default values of sas credentials.
                var serviceSasParameters = new ServiceSasParameters()
                {
                    CanonicalizedResource = "/blob/" + accountName + "/music",
                    Resource = "c",
                    Permissions = "rl",
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),
                };

                var result = storageMgmtClient.StorageAccounts.ListServiceSAS(rgname, accountName, serviceSasParameters);

                var resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.ServiceSasToken);

                Assert.Equal(serviceSasParameters.Resource, resultCredentials.Resource);
                Assert.Equal(serviceSasParameters.Permissions, resultCredentials.Permissions);

                Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
            }
        }

        [Fact]
        public void StorageAccountListServiceSASWithMissingProperties()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, StorageManagementTestUtilities.GetDefaultStorageAccountParameters());

                // Test for default values of sas credentials.
                var serviceSasParameters = new ServiceSasParameters()
                {
                    CanonicalizedResource = "/blob/" + accountName + "/music",
                    Resource = "b",
                    Permissions = "rl",
                };
                try
                {
                    var result = storageMgmtClient.StorageAccounts.ListServiceSAS(rgname, accountName, serviceSasParameters);
                    var resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.ServiceSasToken);
                }
                catch (Exception ex)
                {
                    Assert.Equal("Values for request parameters are invalid: signedExpiry.", ex.Message);
                    return;
                }
                throw new Exception("AccountSasToken shouldn't be returned without SharedAccessExpiryTime");
            }
        }

        [Fact]
        public void StorageAccountUpdateEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardLRS }
                };
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Sku.Name, SkuName.StandardLRS);

                // Update storage tags
                parameters = new StorageAccountUpdateParameters
                {
                    Tags = new Dictionary<string, string>
                    {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Tags.Count, parameters.Tags.Count);

                // 1. Update storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                // 2. Restore storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                // 3. Remove file encryption service field.
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.Equal(true, account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.Equal(true, account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

            }
        }

        [Fact]
        public void StorageAccountUpdateWithHttpsOnlyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with hot
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.Storage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    EnableHttpsTrafficOnly = false
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);

                var parameter = new StorageAccountUpdateParameters
                {
                    EnableHttpsTrafficOnly = true
                };
                storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameter);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.True(account.EnableHttpsTrafficOnly);

                parameter = new StorageAccountUpdateParameters
                {
                    EnableHttpsTrafficOnly = false
                };
                storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameter);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);
            }
        }

        [Fact]
        public void StorageAccountCreateWithHttpsOnlyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with hot
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.Storage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    EnableHttpsTrafficOnly = true
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.True(account.EnableHttpsTrafficOnly);

                // Create storage account with cool
                accountName = TestUtilities.GenerateName("sto");
                parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.Storage,
                    Location = StorageManagementTestUtilities.DefaultLocation,
                    EnableHttpsTrafficOnly = false
                };
                account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);
            }
        }

        [Fact]
        public void StorageAccountCMKTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);
                var keyVaultMgmtClient = StorageManagementTestUtilities.GetKeyVaultManagementClient(context, handler);
                var keyVaultClient = StorageManagementTestUtilities.CreateKeyVaultClient();

                string accountName = TestUtilities.GenerateName("sto");
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string vaultName = TestUtilities.GenerateName("keyvault");
                string keyName = TestUtilities.GenerateName("keyvaultkey");

                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Identity = new Identity { };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.NotNull(account.Identity);

                var accessPolicies = new List<Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry>();
                accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
                {
                    TenantId = System.Guid.Parse(account.Identity.TenantId),
                    ObjectId = account.Identity.PrincipalId,
                    Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "wrapkey", "unwrapkey" })
                });

                string servicePrincipalObjectId = StorageManagementTestUtilities.GetServicePrincipalObjectId();
                accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
                {
                    TenantId = System.Guid.Parse(account.Identity.TenantId),
                    ObjectId = servicePrincipalObjectId,
                    Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "all" })
                });

                var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(rgname, vaultName, new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters
                {
                    Location = account.Location,
                    Properties = new Microsoft.Azure.Management.KeyVault.Models.VaultProperties
                    {
                        TenantId = System.Guid.Parse(account.Identity.TenantId),
                        AccessPolicies = accessPolicies,
                        Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
                        EnabledForDiskEncryption = false,
                        EnabledForDeployment = false,
                        EnabledForTemplateDeployment = false
                    }
                });

                var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
                    JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

                // Enable encryption.
                var updateParameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = "Microsoft.Keyvault",
                        KeyVaultProperties =
                            new KeyVaultProperties
                            {
                                KeyName = keyVaultKey.KeyIdentifier.Name,
                                KeyVaultUri = keyVault.Properties.VaultUri,
                                KeyVersion = keyVaultKey.KeyIdentifier.Version
                            }
                    }
                };

                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.NotNull(account.Encryption);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.Equal("Microsoft.Keyvault", account.Encryption.KeySource);

                // Disable Encryption.
                updateParameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = "Microsoft.Storage"
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.NotNull(account.Encryption);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.Equal("Microsoft.Storage", account.Encryption.KeySource);

                updateParameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = false }, File = new EncryptionService { Enabled = false } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.Null(account.Encryption);
            }
        }

        [Fact]
        public void StorageAccountOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);
                var keyVaultMgmtClient = StorageManagementTestUtilities.GetKeyVaultManagementClient(context, handler);

                // Create storage account with hot
                string accountName = TestUtilities.GenerateName("sto");
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var ops = storageMgmtClient.Operations.List();
                var op1 = new Operation
                {
                    Name = "Microsoft.Storage/storageAccounts/write",
                    Display = new OperationDisplay
                    {
                        Provider = "Microsoft Storage",
                        Resource = "Storage Accounts",
                        Operation = "Create/Update Storage Account"
                    }
                };
                var op2 = new Operation
                {
                    Name = "Microsoft.Storage/storageAccounts/delete",
                    Display = new OperationDisplay
                    {
                        Provider = "Microsoft Storage",
                        Resource = "Storage Accounts",
                        Operation = "Delete Storage Account"
                    }
                };
                bool exists1 = false;
                bool exists2 = false;
                Assert.NotNull(ops);
                Assert.NotNull(ops.GetEnumerator());
                var operation = ops.GetEnumerator();

                while (operation.MoveNext())
                {
                    if (operation.Current.ToString().Equals(op1.ToString()))
                    {
                        exists1 = true;
                    }
                    if (operation.Current.ToString().Equals(op2.ToString()))
                    {
                        exists2 = true;
                    }
                }
                Assert.True(exists1);
                Assert.True(exists2);
            }
        }

        [Fact]
        public void StorageAccountVnetACLTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with Vnet
                string accountName = TestUtilities.GenerateName("sto");

                var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.NetworkRuleSet = new NetworkRuleSet { Bypass = @"Logging,AzureServices", DefaultAction = DefaultAction.Deny, IpRules = new List<IPRule> { new IPRule { IPAddressOrRange = "23.45.67.90" } } };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                var account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                // Verify the vnet rule properties.
                Assert.NotNull(account.NetworkRuleSet);
                Assert.Equal(@"Logging, AzureServices", account.NetworkRuleSet.Bypass);
                Assert.Equal(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
                Assert.Empty(account.NetworkRuleSet.VirtualNetworkRules);
                Assert.NotNull(account.NetworkRuleSet.IpRules);
                Assert.NotEmpty(account.NetworkRuleSet.IpRules);
                Assert.Equal("23.45.67.90", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
                Assert.Equal(Microsoft.Azure.Management.Storage.Models.Action.Allow, account.NetworkRuleSet.IpRules[0].Action);

                // Update Vnet
                var updateParameters = new StorageAccountUpdateParameters
                {
                    NetworkRuleSet = new NetworkRuleSet
                    {
                        Bypass = @"Logging, Metrics",
                        IpRules = new List<IPRule> {
                            new IPRule { IPAddressOrRange = "23.45.67.91", Action = Microsoft.Azure.Management.Storage.Models.Action.Allow },
                            new IPRule { IPAddressOrRange = "23.45.67.92" }
                        },
                        DefaultAction = DefaultAction.Deny
                    }
                };
                storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                Assert.NotNull(account.NetworkRuleSet);
                Assert.Equal(@"Logging, Metrics", account.NetworkRuleSet.Bypass);
                Assert.Equal(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
                Assert.Empty(account.NetworkRuleSet.VirtualNetworkRules);
                Assert.NotNull(account.NetworkRuleSet.IpRules);
                Assert.NotEmpty(account.NetworkRuleSet.IpRules);
                Assert.Equal("23.45.67.91", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
                Assert.Equal(Microsoft.Azure.Management.Storage.Models.Action.Allow, account.NetworkRuleSet.IpRules[0].Action);
                Assert.Equal("23.45.67.92", account.NetworkRuleSet.IpRules[1].IPAddressOrRange);
                Assert.Equal(Microsoft.Azure.Management.Storage.Models.Action.Allow, account.NetworkRuleSet.IpRules[1].Action);

                // Delete vnet.
                updateParameters = new StorageAccountUpdateParameters
                {
                    NetworkRuleSet = new NetworkRuleSet { }
                };
                storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);

                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);

                Assert.NotNull(account.NetworkRuleSet);
                Assert.Equal(@"AzureServices", account.NetworkRuleSet.Bypass);
                Assert.Equal(DefaultAction.Allow, account.NetworkRuleSet.DefaultAction);
            }
        }

        [Fact]
        public void StorageSKUListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                var skulist = storageMgmtClient.Skus.List();
                Assert.NotNull(skulist);
                Assert.Equal(@"storageAccounts", skulist.ElementAt(0).ResourceType);
                Assert.NotNull(skulist.ElementAt(0).Name);
                Assert.IsType<SkuName>(skulist.ElementAt(0).Name);
                Assert.True(skulist.ElementAt(0).Name.Equals(SkuName.PremiumLRS)
                    || skulist.ElementAt(0).Name.Equals(SkuName.StandardGRS)
                    || skulist.ElementAt(0).Name.Equals(SkuName.StandardLRS)
                    || skulist.ElementAt(0).Name.Equals(SkuName.StandardRAGRS)
                    || skulist.ElementAt(0).Name.Equals(SkuName.StandardZRS));
                Assert.NotNull(skulist.ElementAt(0).Kind);
                Assert.True(skulist.ElementAt(0).Kind.Equals(Kind.BlobStorage) || skulist.ElementAt(0).Kind.Equals(Kind.Storage));
            }
        }

        [Fact]
        public void StorageAccountCreateWithStorageV2()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account with StorageV2
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.StorageV2,
                    Location = StorageManagementTestUtilities.DefaultLocation
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.NotNull(account.PrimaryEndpoints.Web);
                Assert.Equal(Kind.StorageV2, account.Kind);
            }
        }

        [Fact]
        public void StorageAccountUpdateKindStorageV2()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = StorageManagementTestUtilities.CreateStorageAccount(storageMgmtClient, rgname);

                // Update storage account type
                var parameters = new StorageAccountUpdateParameters
                {
                    Kind = Kind.StorageV2,
                    EnableHttpsTrafficOnly = true
                };
                var account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, parameters);
                Assert.Equal(account.Kind, Kind.StorageV2);
                Assert.True(account.EnableHttpsTrafficOnly);
                Assert.NotNull(account.PrimaryEndpoints.Web);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.Equal(account.Kind, Kind.StorageV2);
                Assert.True(account.EnableHttpsTrafficOnly);
                Assert.NotNull(account.PrimaryEndpoints.Web);
            }
        }

        [Fact]
        public void StorageAccountSetGetDeleteManagementPolicy()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.StorageV2,
                    Location = StorageManagementTestUtilities.DefaultLocation
                };
                storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

                string rules = @"{
    ""version"":""0.5"",
    ""rules"":
    [{
        ""name"": ""olcmtest"",
        ""type"": ""Lifecycle"",
        ""definition"": {
            ""filters"":
            {
                ""blobTypes"":[""blockBlob""],
                ""prefixMatch"":[""olcmtestcontainer""]
            },
            ""actions"":
            {
                ""baseBlob"":
                {
                    ""tierToCool"":
                    {
                        ""daysAfterModificationGreaterThan"":1000
                    },
					""tierToArchive"" : {
						""daysAfterModificationGreaterThan"" : 90
					},
                    ""delete"":
                    {
                        ""daysAfterModificationGreaterThan"":1000
                    }
                },
				""snapshot"":
                {
                    ""delete"":
                    {
                        ""daysAfterCreationGreaterThan"":5000
                    }
                }
            }
        }
    }]
}";
                //Set Management Policies
                Newtonsoft.Json.Linq.JObject rule1 = Newtonsoft.Json.Linq.JObject.Parse(rules);
                StorageAccountManagementPolicies policy = storageMgmtClient.StorageAccounts.CreateOrUpdateManagementPolicies(rgname, accountName, rule1);
                Assert.Equal(Regex.Replace(rules, @"\r\n?|\n|\t| ", ""), Regex.Replace(policy.Policy.ToString(), @"\r\n?|\n|\t| ", ""));

                //Get Management Policies
                policy = storageMgmtClient.StorageAccounts.GetManagementPolicies(rgname, accountName);
                Assert.Equal(Regex.Replace(rules, @"\r\n?|\n|\t| ", ""), Regex.Replace(policy.Policy.ToString(), @"\r\n?|\n|\t| ", ""));

                //Delete Management Policies, and check policy not exist 
                storageMgmtClient.StorageAccounts.DeleteManagementPolicies(rgname, accountName);
                bool dataPolicyExist = true;
                try
                {
                    policy = storageMgmtClient.StorageAccounts.GetManagementPolicies(rgname, accountName);
                }
                catch (Microsoft.Rest.Azure.CloudException cloudException)
                {
                    Assert.Equal(System.Net.HttpStatusCode.NotFound, cloudException.Response.StatusCode);
                    dataPolicyExist = false;
                }
                Assert.False(dataPolicyExist);

                //Delete not exist Management Policies will not fail
                storageMgmtClient.StorageAccounts.DeleteManagementPolicies(rgname, accountName);
            }
        }

        [Fact]
        public void StorageAccountCreateGetdfs()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
                var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);

                // Create resource group
                var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create storage account
                string accountName = TestUtilities.GenerateName("sto");
                var parameters = new StorageAccountCreateParameters
                {
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.StorageV2,
                    IsHnsEnabled = true,
                    Location = "centraluseuap"
                };
                var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);
                Assert.True(account.IsHnsEnabled = true);
                Assert.NotNull(account.PrimaryEndpoints.Dfs);

                // Validate
                account = storageMgmtClient.StorageAccounts.GetProperties(rgname, accountName);
                Assert.True(account.IsHnsEnabled = true);
                Assert.NotNull(account.PrimaryEndpoints.Dfs);
            }
        }
    }
}