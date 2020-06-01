// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Storage.Models;
using Azure.Management.Storage.Tests.Helpers;
using NUnit.Framework;
using Sku = Azure.Management.Storage.Models.Sku;

namespace Azure.Management.Storage.Tests
{
    public class StorageAccountTests : StorageTestsManagementClientBase
    {
        public StorageAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [Test]
        public async Task StorageAccountCreateTest()
        {
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");
            string accountName1 = Recording.GenerateAssetName("sto");

            try
            {
                //Create storage account
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                //Make sure a second create returns immediately
                account = await _CreateStorageAccountAsync(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                //Create storage account with only required params
                account = await _CreateStorageAccountAsync(rgname, accountName1);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);
                    await _DeleteStorageAccountAsync(rgname, accountName1);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithEncryptionTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                //Create storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                //Verify encryption settings
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.NotNull(account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.False(account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.False(account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithAccessTierTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");
            string accountName1 = Recording.GenerateAssetName("sto");

            try
            {
                //Create storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Hot;
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.AreEqual(AccessTier.Hot, account.AccessTier);
                Assert.AreEqual(Kind.BlobStorage, account.Kind);

                //Create storage account with cool
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Cool;
                account = await _CreateStorageAccountAsync(rgname, accountName1, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.AreEqual(AccessTier.Cool, account.AccessTier);
                Assert.AreEqual(Kind.BlobStorage, account.Kind);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);
                    await _DeleteStorageAccountAsync(rgname, accountName1);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountBeginCreateTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                //Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountDeleteTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            try
            {
                //Delete an account which does not exist
                await _DeleteStorageAccountAsync(rgname, "missingaccount");

                //Create storage account
                string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

                //Delete an account
                await _DeleteStorageAccountAsync(rgname, accountName);

                //Delete an account which was just deleted
                await _DeleteStorageAccountAsync(rgname, accountName);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountGetStandardTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");
            string accountName1 = Recording.GenerateAssetName("sto");
            string accountName2 = Recording.GenerateAssetName("sto");
            string accountName3 = Recording.GenerateAssetName("sto");

            try
            {
                // Create and get a LRS storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardLRS));
                await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageAccount account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a GRS storage account
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardGRS));
                await _CreateStorageAccountAsync(rgname, accountName1, parameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName1);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create and get a RAGRS storage account
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardRagrs));
                await _CreateStorageAccountAsync(rgname, accountName2, parameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName2);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a ZRS storage account
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardZRS));
                await _CreateStorageAccountAsync(rgname, accountName3, parameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName3);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);
                    await _DeleteStorageAccountAsync(rgname, accountName1);
                    await _DeleteStorageAccountAsync(rgname, accountName2);
                    await _DeleteStorageAccountAsync(rgname, accountName3);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountGetBlobTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");
            string accountName1 = Recording.GenerateAssetName("sto");
            string accountName2 = Recording.GenerateAssetName("sto");

            try
            {
                // Create and get a blob LRS storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardLRS), Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Hot;
                await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageAccount account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob GRS storage account
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardGRS), Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Hot;
                await _CreateStorageAccountAsync(rgname, accountName1, parameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName1);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);

                // Create and get a blob RAGRS storage account
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardRagrs), Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Hot;
                await _CreateStorageAccountAsync(rgname, accountName2, parameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName2);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);
                    await _DeleteStorageAccountAsync(rgname, accountName1);
                    await _DeleteStorageAccountAsync(rgname, accountName2);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountGetPremiumTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create and get a Premium LRS storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardLRS), Kind: Kind.BlobStorage);
                parameters.AccessTier = AccessTier.Hot;
                await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageAccount account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListByResourceGroupTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            try
            {
                //List by resource group
                AsyncPageable<StorageAccount> accountlistAP = AccountsClient.ListByResourceGroupAsync(rgname);
                List<StorageAccount> accountlist = await accountlistAP.ToEnumerableAsync();
                Assert.False(accountlist.Any());

                // Create storage accounts
                string accountName1 = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);
                string accountName2 = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);
                accountlistAP = AccountsClient.ListByResourceGroupAsync(rgname);
                accountlist = await accountlistAP.ToEnumerableAsync();
                Assert.AreEqual(2, accountlist.Count());

                foreach (StorageAccount account in accountlist)
                {
                    StorageManagementTestUtilities.VerifyAccountProperties(account, true);
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListWithEncryptionTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                };
                await _CreateStorageAccountAsync(rgname, accountName, parameters);

                // List account and verify
                AsyncPageable<StorageAccount> accounts = AccountsClient.ListByResourceGroupAsync(rgname);
                List<StorageAccount> accountlist = await accounts.ToEnumerableAsync();
                Assert.AreEqual(1, accountlist.Count());

                StorageAccount account = accountlist.ToArray()[0];
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                if (null != account.Encryption.Services.Table)
                {
                    if (account.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.False(account.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != account.Encryption.Services.Queue)
                {
                    if (account.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.False(account.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListBySubscriptionTest()
        {
            // Create resource group and storage account
            string rgname1 = await _CreateResourceGroupAsync();
            string accountName1 = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname1, Recording);

            // Create different resource group and storage account
            string rgname2 = await _CreateResourceGroupAsync();
            string accountName2 = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname2, Recording);

            try
            {
                AsyncPageable<StorageAccount> accountlist = AccountsClient.ListAsync();
                List<StorageAccount> accountlists = accountlist.ToEnumerableAsync().Result;

                StorageAccount account1 = accountlists.First(
                        t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                StorageManagementTestUtilities.VerifyAccountProperties(account1, true);

                StorageAccount account2 = accountlists.First(
                        t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                StorageManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname1, accountName1);
                    await _DeleteStorageAccountAsync(rgname2, accountName2);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname1);
                    await _DeleteResourceGroupAsync(rgname2);
                }
            }
        }

        [Test]
        public async Task StorageAccountListKeysTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // List keys
                Response<StorageAccountListKeysResult> keys = await AccountsClient.ListKeysAsync(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                StorageAccountKey key1 = keys.Value.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key1"));
                Assert.NotNull(key1);
                Assert.AreEqual(KeyPermission.Full, key1.Permissions);
                Assert.NotNull(key1.Value);

                // Validate Key2
                StorageAccountKey key2 = keys.Value.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);
                Assert.AreEqual(KeyPermission.Full, key2.Permissions);
                Assert.NotNull(key2.Value);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountRegenerateKeyTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // List keys
                Response<StorageAccountListKeysResult> keys = await AccountsClient.ListKeysAsync(rgname, accountName);
                Assert.NotNull(keys);
                StorageAccountKey key2 = keys.Value.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                StorageAccountRegenerateKeyParameters keyParameters = new StorageAccountRegenerateKeyParameters("key2");
                Response<StorageAccountListKeysResult> regenKeys = await AccountsClient.RegenerateKeyAsync(rgname, accountName, keyParameters);
                StorageAccountKey key2Regen = regenKeys.Value.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.AreNotEqual(key2.Value, key2Regen.Value);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountRevokeUserDelegationKeysTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Revoke User DelegationKeys
                await AccountsClient.RevokeUserDelegationKeysAsync(rgname, accountName);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCheckNameTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Check valid name
                StorageAccountCheckNameAvailabilityParameters storageAccountCheckNameAvailabilityParameters = new StorageAccountCheckNameAvailabilityParameters(accountName);
                Response<CheckNameAvailabilityResult> checkNameRequest = await AccountsClient.CheckNameAvailabilityAsync(storageAccountCheckNameAvailabilityParameters);
                Assert.True(checkNameRequest.Value.NameAvailable);
                Assert.Null(checkNameRequest.Value.Reason);
                Assert.Null(checkNameRequest.Value.Message);

                // Check invalid name
                storageAccountCheckNameAvailabilityParameters = new StorageAccountCheckNameAvailabilityParameters("CAPS");
                checkNameRequest = await AccountsClient.CheckNameAvailabilityAsync(storageAccountCheckNameAvailabilityParameters);
                Assert.False(checkNameRequest.Value.NameAvailable);
                Assert.AreEqual(Reason.AccountNameInvalid, checkNameRequest.Value.Reason);
                Assert.AreEqual("CAPS is not a valid storage account name. Storage account name must be between 3 and 24 "
                    + "characters in length and use numbers and lower-case letters only.", checkNameRequest.Value.Message);

                // Check name of account that already exists
                string accountName1 = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);
                storageAccountCheckNameAvailabilityParameters = new StorageAccountCheckNameAvailabilityParameters(accountName1);
                checkNameRequest = await AccountsClient.CheckNameAvailabilityAsync(storageAccountCheckNameAvailabilityParameters);
                Assert.False(checkNameRequest.Value.NameAvailable);
                Assert.AreEqual(Reason.AlreadyExists, checkNameRequest.Value.Reason);
                Assert.AreEqual("The storage account named " + accountName1 + " is already taken.", checkNameRequest.Value.Message);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountUpdateWithCreateTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Update storage account type
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: new Sku(SkuName.StandardLRS));
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

                // Validate
                Response<StorageAccount> accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, accountProerties.Value.Sku.Name);

                // Update storage tags
                parameters.Tags = new Dictionary<string, string>
            {
                {"key3","value3"},
                {"key4","value4"},
                {"key5","value6"}
            };
                account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(account.Tags.Count, parameters.Tags.Count);

                // Validate
                accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(accountProerties.Value.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                };
                account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.NotNull(accountProerties.Value.Encryption);
                Assert.NotNull(accountProerties.Value.Encryption.Services.Blob);
                Assert.True(accountProerties.Value.Encryption.Services.Blob.Enabled);
                Assert.NotNull(accountProerties.Value.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(accountProerties.Value.Encryption.Services.File);
                Assert.True(accountProerties.Value.Encryption.Services.File.Enabled);
                Assert.NotNull(accountProerties.Value.Encryption.Services.File.LastEnabledTime);

                if (null != accountProerties.Value.Encryption.Services.Table)
                {
                    if (accountProerties.Value.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.False(accountProerties.Value.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != accountProerties.Value.Encryption.Services.Queue)
                {
                    if (accountProerties.Value.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.False(accountProerties.Value.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }

                // Update storage custom domains
                parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.CustomDomain = new CustomDomain("foo.example.com") { UseSubDomainName = true };
                try
                {
                    await AccountsClient.StartCreateAsync(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual((int)HttpStatusCode.Conflict, ex.Status);
                    Assert.True(ex.Message != null && ex.Message.Contains("The custom domain name could not be verified. CNAME mapping from foo.example.com to"));
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountUpdateTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Update storage account type
                StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters()
                {
                    Sku = new Sku(SkuName.StandardLRS),
                };
                StorageAccount account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

                // Validate
                Response<StorageAccount> accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, accountProerties.Value.Sku.Name);

                // Update storage tags
                parameters.Tags = new Dictionary<string, string> { { "key3", "value3" }, { "key4", "value4" }, { "key5", "value6" } };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(account.Tags.Count, parameters.Tags.Count);

                // Validate
                accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(accountProerties.Value.Tags.Count, parameters.Tags.Count);

                // Update storage encryption
                parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.NotNull(accountProerties.Value.Encryption);
                Assert.NotNull(accountProerties.Value.Encryption.Services.Blob);
                Assert.True(accountProerties.Value.Encryption.Services.Blob.Enabled);
                Assert.NotNull(accountProerties.Value.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(accountProerties.Value.Encryption.Services.File);
                Assert.True(accountProerties.Value.Encryption.Services.File.Enabled);
                Assert.NotNull(accountProerties.Value.Encryption.Services.File.LastEnabledTime);

                if (null != accountProerties.Value.Encryption.Services.Table)
                {
                    if (accountProerties.Value.Encryption.Services.Table.Enabled.HasValue)
                    {
                        Assert.False(accountProerties.Value.Encryption.Services.Table.LastEnabledTime.HasValue);
                    }
                }

                if (null != accountProerties.Value.Encryption.Services.Queue)
                {
                    if (accountProerties.Value.Encryption.Services.Queue.Enabled.HasValue)
                    {
                        Assert.False(accountProerties.Value.Encryption.Services.Queue.LastEnabledTime.HasValue);
                    }
                }

                // Update storage custom domains
                parameters = new StorageAccountUpdateParameters
                {
                    CustomDomain = new CustomDomain("foo.example.com")
                    {
                        UseSubDomainName = true
                    }
                };

                try
                {
                    await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                    Assert.True(false, "This request should fail with the below code.");
                }
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual((int)HttpStatusCode.Conflict, ex.Status);
                    Assert.True(ex.Message != null && ex.Message.Contains("The custom domain name could not be verified. CNAME mapping from foo.example.com to"));
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountUpdateMultipleTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Update storage account type
                StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters()
                {
                    Sku = new Sku(SkuName.StandardLRS),
                    Tags = new Dictionary<string, string> { { "key3", "value3" }, { "key4", "value4" }, { "key5", "value6" } }
                };
                StorageAccount account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
                Assert.AreEqual(account.Tags.Count, parameters.Tags.Count);

                // Validate
                Response<StorageAccount> accountProerties = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, accountProerties.Value.Sku.Name);
                Assert.AreEqual(accountProerties.Value.Tags.Count, parameters.Tags.Count);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountLocationUsageTest()
        {
            // Query usage
            string Location = StorageManagementTestUtilities.DefaultLocation;
            AsyncPageable<Usage> usages = UsagesClient.ListByLocationAsync(Location);
            List<Usage> usagelist = await usages.ToEnumerableAsync();
            Assert.AreEqual(1, usagelist.Count());
            Assert.AreEqual(UsageUnit.Count, usagelist.First().Unit);
            Assert.NotNull(usagelist.First().CurrentValue);
            Assert.AreEqual(250, usagelist.First().Limit);
            Assert.NotNull(usagelist.First().Name);
            Assert.AreEqual("StorageAccounts", usagelist.First().Name.Value);
            Assert.AreEqual("Storage Accounts", usagelist.First().Name.LocalizedValue);
        }

        [Test]
        [Ignore("The function of 'ResourceProviderOperationDetails' is not found in trach2 Management.Resource")]
        public void StorageAccountGetOperationsTest()
        {
            //var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            //using (MockContext context = MockContext.Start(this.GetType()))
            //{
            //    var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
            //    var ops = resourcesClient.ResourceProviderOperationDetails.List("Microsoft.Storage", "2015-06-15");

            //    Assert.True(ops.Count() > 1);
            //}
        }

        [Test]
        public async Task StorageAccountListAccountSASTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                AccountSasParameters accountSasParameters = new AccountSasParameters(services: "bftq", resourceTypes: "sco", permissions: "rdwlacup", sharedAccessExpiryTime: Recording.UtcNow.AddHours(1))
                {
                    Protocols = HttpProtocol.HttpsHttp,
                    SharedAccessStartTime = Recording.UtcNow,
                    KeyToSign = "key1"
                };
                Response<ListAccountSasResponse> result = await AccountsClient.ListAccountSASAsync(rgname, accountName, accountSasParameters);

                AccountSasParameters resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.Value.AccountSasToken);

                Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
                Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
                Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
                Assert.AreEqual(accountSasParameters.Protocols, resultCredentials.Protocols);

                Assert.NotNull(accountSasParameters.SharedAccessStartTime);
                Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListAccountSASWithDefaultProperties()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                // Test for default values of sas credentials.
                AccountSasParameters accountSasParameters = new AccountSasParameters(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryTime: Recording.UtcNow.AddHours(1));

                Response<ListAccountSasResponse> result = await AccountsClient.ListAccountSASAsync(rgname, accountName, accountSasParameters);

                AccountSasParameters resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.Value.AccountSasToken);

                Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
                Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
                Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
                Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListAccountSASWithMissingProperties()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                // Test for default values of sas credentials.
                AccountSasParameters accountSasParameters =
                    new AccountSasParameters(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryTime: Recording.UtcNow.AddHours(-1));
                try
                {
                    Response<ListAccountSasResponse> result = await AccountsClient.ListAccountSASAsync(rgname, accountName, accountSasParameters);
                    AccountSasParameters resultCredentials = StorageManagementTestUtilities.ParseAccountSASToken(result.Value.AccountSasToken);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message != null && ex.Message.Contains("Values for request parameters are invalid: signedExpiry."));
                    return;
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
            throw new Exception("AccountSasToken shouldn't be returned without SharedAccessExpiryTime");
        }

        [Test]
        public async Task StorageAccountListServiceSASTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
                ServiceSasParameters serviceSasParameters = new ServiceSasParameters(canonicalizedResource: canonicalizedResourceParameter)
                {
                    Resource = "c",
                    Permissions = "rdwlacup",
                    Protocols = HttpProtocol.HttpsHttp,
                    SharedAccessStartTime = Recording.UtcNow,
                    SharedAccessExpiryTime = Recording.UtcNow.AddHours(1),
                    KeyToSign = "key1"
                };

                Task<Response<ListServiceSasResponse>> result = AccountsClient.ListServiceSASAsync(rgname, accountName, serviceSasParameters);

                ServiceSasParameters resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.Result.Value.ServiceSasToken, canonicalizedResourceParameter);

                Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
                Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
                Assert.AreEqual(serviceSasParameters.Protocols, resultCredentials.Protocols);
                Assert.NotNull(serviceSasParameters.SharedAccessStartTime);
                Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListServiceSASWithDefaultProperties()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                // Test for default values of sas credentials.
                string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
                ServiceSasParameters serviceSasParameters = new ServiceSasParameters(canonicalizedResource: canonicalizedResourceParameter)
                {
                    Resource = "c",
                    Permissions = "rl",
                    SharedAccessExpiryTime = Recording.UtcNow.AddHours(1),
                };

                Response<ListServiceSasResponse> result = await AccountsClient.ListServiceSASAsync(rgname, accountName, serviceSasParameters);

                ServiceSasParameters resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);

                Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
                Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
                Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountListServiceSASWithMissingProperties()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                await _CreateStorageAccountAsync(rgname, accountName);

                // Test for default values of sas credentials.
                string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
                ServiceSasParameters serviceSasParameters = new ServiceSasParameters(canonicalizedResource: canonicalizedResourceParameter)
                {
                    Resource = "b",
                    Permissions = "rl"
                };
                try
                {
                    Response<ListServiceSasResponse> result = await AccountsClient.ListServiceSASAsync(rgname, accountName, serviceSasParameters);
                    ServiceSasParameters resultCredentials = StorageManagementTestUtilities.ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);
                }
                catch (RequestFailedException ex)
                {
                    Assert.True(ex.Message != null && ex.Message.Contains("Values for request parameters are invalid: signedExpiry."));
                    return;
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
            throw new Exception("AccountSasToken shouldn't be returned without SharedAccessExpiryTime");
        }

        [Test]
        public async Task StorageAccountUpdateEncryptionTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Update storage account type
                StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters
                {
                    Sku = new Sku(SkuName.StandardLRS)
                };
                StorageAccount account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

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
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(account.Tags.Count, parameters.Tags.Count);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(account.Tags.Count, parameters.Tags.Count);

                // 1. Update storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption(keySource: KeySource.MicrosoftStorage)
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                    }
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                // 2. Restore storage encryption
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption(keySource: KeySource.MicrosoftStorage)
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                    }
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                // 3. Remove file encryption service field.
                parameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption(keySource: KeySource.MicrosoftStorage)
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } }
                    }
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.NotNull(account.Encryption);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountUpdateWithHttpsOnlyTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with hot
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.EnableHttpsTrafficOnly = false;
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);

                //Update storage account
                StorageAccountUpdateParameters parameter = new StorageAccountUpdateParameters
                {
                    EnableHttpsTrafficOnly = true
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameter);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.True(account.EnableHttpsTrafficOnly);

                //Update storage account
                parameter = new StorageAccountUpdateParameters
                {
                    EnableHttpsTrafficOnly = false
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, parameter);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithHttpsOnlyTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");
            string accountName1 = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with hot
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.EnableHttpsTrafficOnly = true;
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.True(account.EnableHttpsTrafficOnly);

                // Create storage account with cool
                parameters.EnableHttpsTrafficOnly = false;
                account = await _CreateStorageAccountAsync(rgname, accountName1, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.False(account.EnableHttpsTrafficOnly);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);
                    await _DeleteStorageAccountAsync(rgname, accountName1);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        [Ignore("Need KeyVaultManagementClient")]
        public void StorageAccountCMKTest()
        {
            //var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            //using (MockContext context = MockContext.Start(this.GetType()))
            //{
            //    var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
            //    var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);
            //    var keyVaultMgmtClient = StorageManagementTestUtilities.GetKeyVaultManagementClient(context, handler);
            //    var keyVaultClient = StorageManagementTestUtilities.CreateKeyVaultClient();

            //    string accountName = TestUtilities.GenerateName("sto");
            //    var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);
            //    string vaultName = TestUtilities.GenerateName("keyvault");
            //    string keyName = TestUtilities.GenerateName("keyvaultkey");

            //    var parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
            //    parameters.Location = "centraluseuap";
            //    parameters.Identity = new Identity { };
            //    var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

            //    StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Identity);

            //    var accessPolicies = new List<Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry>();
            //    accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        ObjectId = account.Identity.PrincipalId,
            //        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "wrapkey", "unwrapkey" })
            //    });

            //    string servicePrincipalObjectId = StorageManagementTestUtilities.GetServicePrincipalObjectId();
            //    accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        ObjectId = servicePrincipalObjectId,
            //        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "all" })
            //    });

            //    var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(rgname, vaultName, new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters
            //    {
            //        Location = account.Location,
            //        Properties = new Microsoft.Azure.Management.KeyVault.Models.VaultProperties
            //        {
            //            TenantId = System.Guid.Parse(account.Identity.TenantId),
            //            AccessPolicies = accessPolicies,
            //            Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
            //            EnabledForDiskEncryption = false,
            //            EnabledForDeployment = false,
            //            EnabledForTemplateDeployment = false
            //        }
            //    });

            //    var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
            //        JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

            //    // Enable encryption.
            //    var updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
            //            KeySource = "Microsoft.Keyvault",
            //            KeyVaultProperties =
            //                new KeyVaultProperties
            //                {
            //                    KeyName = keyVaultKey.KeyIdentifier.Name,
            //                    KeyVaultUri = keyVault.Properties.VaultUri,
            //                    KeyVersion = keyVaultKey.KeyIdentifier.Version
            //                }
            //        }
            //    };

            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Encryption);
            //    Assert.True(account.Encryption.Services.Blob.Enabled);
            //    Assert.True(account.Encryption.Services.File.Enabled);
            //    Assert.Equal("Microsoft.Keyvault", account.Encryption.KeySource);

            //    // Disable Encryption.
            //    updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
            //            KeySource = "Microsoft.Storage"
            //        }
            //    };
            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Encryption);
            //    Assert.True(account.Encryption.Services.Blob.Enabled);
            //    Assert.True(account.Encryption.Services.File.Enabled);
            //    Assert.Equal("Microsoft.Storage", account.Encryption.KeySource);

            //    updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = false }, File = new EncryptionService { Enabled = false } },
            //            KeySource = KeySource.MicrosoftStorage
            //        }
            //    };
            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    StorageManagementTestUtilities.VerifyAccountProperties(account, false);
            //    Assert.Null(account.Encryption);
            //}
        }

        [Test]
        [Ignore("The constructor of OperationDisplay is internal")]
        public void StorageAccountOperationsTest()
        {
            //var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            //using (MockContext context = MockContext.Start(this.GetType()))
            //{
            //    var resourcesClient = StorageManagementTestUtilities.GetResourceManagementClient(context, handler);
            //    var storageMgmtClient = StorageManagementTestUtilities.GetStorageManagementClient(context, handler);
            //    var keyVaultMgmtClient = StorageManagementTestUtilities.GetKeyVaultManagementClient(context, handler);

            //    // Create storage account with hot
            //    string accountName = TestUtilities.GenerateName("sto");
            //    var rgname = StorageManagementTestUtilities.CreateResourceGroup(resourcesClient);

            //    var ops = storageMgmtClient.Operations.List();
            //    var op1 = new Operation
            //    {
            //        Name = "Microsoft.Storage/storageAccounts/write",
            //        Display = new OperationDisplay
            //        {
            //            Provider = "Microsoft Storage",
            //            Resource = "Storage Accounts",
            //            Operation = "Create/Update Storage Account"
            //        }
            //    };
            //    var op2 = new Operation
            //    {
            //        Name = "Microsoft.Storage/storageAccounts/delete",
            //        Display = new OperationDisplay
            //        {
            //            Provider = "Microsoft Storage",
            //            Resource = "Storage Accounts",
            //            Operation = "Delete Storage Account"
            //        }
            //    };
            //    bool exists1 = false;
            //    bool exists2 = false;
            //    Assert.NotNull(ops);
            //    Assert.NotNull(ops.GetEnumerator());
            //    var operation = ops.GetEnumerator();

            //    while (operation.MoveNext())
            //    {
            //        if (operation.Current.ToString().Equals(op1.ToString()))
            //        {
            //            exists1 = true;
            //        }
            //        if (operation.Current.ToString().Equals(op2.ToString()))
            //        {
            //            exists2 = true;
            //        }
            //    }
            //    Assert.True(exists1);
            //    Assert.True(exists2);
            //}
        }

        [Test]
        public async Task StorageAccountVnetACLTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with Vnet
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
                parameters.NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
                {
                    Bypass = @"Logging,AzureServices",
                    IpRules = new List<IPRule> { new IPRule(iPAddressOrRange: "23.45.67.90") }
                };
                await _CreateStorageAccountAsync(rgname, accountName, parameters);

                StorageAccount account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                // Verify the vnet rule properties.
                Assert.NotNull(account.NetworkRuleSet);
                Assert.AreEqual(@"Logging, AzureServices", account.NetworkRuleSet.Bypass.ToString());
                Assert.AreEqual(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
                Assert.IsEmpty(account.NetworkRuleSet.VirtualNetworkRules);
                Assert.NotNull(account.NetworkRuleSet.IpRules);
                Assert.IsNotEmpty(account.NetworkRuleSet.IpRules);
                Assert.AreEqual("23.45.67.90", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
                Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[0].Action);

                // Update Vnet
                StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters
                {
                    NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
                    {
                        Bypass = @"Logging, Metrics",
                        IpRules = new List<IPRule> {
                            new IPRule(iPAddressOrRange:"23.45.67.91") { Action = DefaultAction.Allow.ToString() },
                            new IPRule(iPAddressOrRange:"23.45.67.92")
                        },
                    }
                };
                await _UpdateStorageAccountAsync(rgname, accountName, updateParameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                Assert.NotNull(account.NetworkRuleSet);
                Assert.AreEqual(@"Logging, Metrics", account.NetworkRuleSet.Bypass.ToString());
                Assert.AreEqual(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
                Assert.IsEmpty(account.NetworkRuleSet.VirtualNetworkRules);
                Assert.NotNull(account.NetworkRuleSet.IpRules);
                Assert.IsNotEmpty(account.NetworkRuleSet.IpRules);
                Assert.AreEqual("23.45.67.91", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
                Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[0].Action);
                Assert.AreEqual("23.45.67.92", account.NetworkRuleSet.IpRules[1].IPAddressOrRange);
                Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[1].Action);

                // Delete vnet.
                updateParameters = new StorageAccountUpdateParameters
                {
                    NetworkRuleSet = new NetworkRuleSet(DefaultAction.Allow)
                };
                await _UpdateStorageAccountAsync(rgname, accountName, updateParameters);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);

                Assert.NotNull(account.NetworkRuleSet);
                Assert.AreEqual(@"Logging, Metrics", account.NetworkRuleSet.Bypass.ToString());
                Assert.AreEqual(DefaultAction.Allow, account.NetworkRuleSet.DefaultAction);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public void StorageSKUListTest()
        {
            AsyncPageable<SkuInformation> skulist = SkusClient.ListAsync();
            Assert.NotNull(skulist);
            Task<List<SkuInformation>> skuListTask = skulist.ToEnumerableAsync();
            Assert.AreEqual(@"storageAccounts", skuListTask.Result.ElementAt(0).ResourceType);
            Assert.NotNull(skuListTask.Result.ElementAt(0).Name);
            Assert.True(skuListTask.Result.ElementAt(0).Name.GetType() == SkuName.PremiumLRS.GetType());
            Assert.True(skuListTask.Result.ElementAt(0).Name.Equals(SkuName.PremiumLRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardGRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardLRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardRagrs)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardZRS));
            Assert.NotNull(skuListTask.Result.ElementAt(0).Kind);
            Assert.True(skuListTask.Result.ElementAt(0).Kind.Equals(Kind.BlobStorage) || skuListTask.Result.ElementAt(0).Kind.Equals(Kind.Storage) || skuListTask.Result.ElementAt(0).Kind.Equals(Kind.StorageV2));
        }

        [Test]
        public async Task StorageAccountCreateWithStorageV2()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with StorageV2
                Sku sku = new Sku(SkuName.StandardGRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: StorageManagementTestUtilities.DefaultLocation);
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.NotNull(account.PrimaryEndpoints.Web);
                Assert.AreEqual(Kind.StorageV2, account.Kind);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountUpdateKindStorageV2()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();

            // Create storage account
            string accountName = await StorageManagementTestUtilities.CreateStorageAccount(AccountsClient, rgname, Recording);

            try
            {
                // Update storage account type
                StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters
                {
                    Kind = Kind.StorageV2,
                    EnableHttpsTrafficOnly = true
                };
                StorageAccount account = await _UpdateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(Kind.StorageV2, account.Kind);
                Assert.True(account.EnableHttpsTrafficOnly);
                Assert.NotNull(account.PrimaryEndpoints.Web);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(Kind.StorageV2, account.Kind);
                Assert.True(account.EnableHttpsTrafficOnly);
                Assert.NotNull(account.PrimaryEndpoints.Web);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountSetGetDeleteManagementPolicy()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardGRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westus");
                await _CreateStorageAccountAsync(rgname, accountName, parameters);

                List<ManagementPolicyRule> rules = new List<ManagementPolicyRule>();
                ManagementPolicyAction Actions = new ManagementPolicyAction()
                {
                    BaseBlob = new ManagementPolicyBaseBlob()
                    {
                        Delete = new DateAfterModification(300),
                        TierToArchive = new DateAfterModification(90),
                        TierToCool = new DateAfterModification(1000),
                    },
                    Snapshot = new ManagementPolicySnapShot()
                    {
                        Delete = new DateAfterCreation(100)
                    }
                };
                ManagementPolicyDefinition Definition = new ManagementPolicyDefinition(Actions)
                {
                    Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
                    {
                        PrefixMatch = new List<string>() { "olcmtestcontainer", "testblob" }
                    }
                };
                ManagementPolicyRule rule1 = new ManagementPolicyRule("olcmtest", Definition)
                {
                    Enabled = true
                };
                rules.Add(rule1);


                ManagementPolicyAction Actions2 = new ManagementPolicyAction()
                {
                    BaseBlob = new ManagementPolicyBaseBlob()
                    {
                        Delete = new DateAfterModification(1000),
                    },
                };
                ManagementPolicyDefinition Definition2 = new ManagementPolicyDefinition(Actions2)
                {
                    Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
                };
                ManagementPolicyRule rule2 = new ManagementPolicyRule("olcmtest2", Definition2)
                {
                    Enabled = false
                };
                rules.Add(rule2);

                ManagementPolicyAction Actions3 = new ManagementPolicyAction()
                {
                    Snapshot = new ManagementPolicySnapShot()
                    {
                        Delete = new DateAfterCreation(200)
                    }
                };
                ManagementPolicyDefinition Definition3 = new ManagementPolicyDefinition(Actions3)
                {
                    Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
                };
                ManagementPolicyRule rule3 = new ManagementPolicyRule("olcmtest3", Definition3);
                rules.Add(rule3);

                //Set Management Policies
                ManagementPolicySchema policyToSet = new ManagementPolicySchema(rules);
                ManagementPolicy managementPolicy = new ManagementPolicy()
                {
                    Policy = policyToSet
                };
                Response<ManagementPolicy> policy = await ManagementPoliciesClient.CreateOrUpdateAsync(rgname, accountName, managementPolicy);
                CompareStorageAccountManagementPolicyProperty(policyToSet, policy.Value.Policy);

                //Get Management Policies
                policy = await ManagementPoliciesClient.GetAsync(rgname, accountName);
                CompareStorageAccountManagementPolicyProperty(policyToSet, policy.Value.Policy);

                //Delete Management Policies, and check policy not exist
                await ManagementPoliciesClient.DeleteAsync(rgname, accountName);
                bool dataPolicyExist = true;
                try
                {
                    policy = await ManagementPoliciesClient.GetAsync(rgname, accountName);
                }
                catch (RequestFailedException cloudException)
                {
                    Assert.AreEqual((int)HttpStatusCode.NotFound, cloudException.Status);
                    dataPolicyExist = false;
                }
                Assert.False(dataPolicyExist);

                //Delete not exist Management Policies will not fail
                await ManagementPoliciesClient.DeleteAsync(rgname, accountName);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        private static void CompareStorageAccountManagementPolicyProperty(ManagementPolicySchema policy1, ManagementPolicySchema policy2)
        {
            Assert.AreEqual(policy1.Rules.Count, policy2.Rules.Count);
            foreach (ManagementPolicyRule rule1 in policy1.Rules)
            {
                bool ruleFound = false;
                foreach (ManagementPolicyRule rule2 in policy2.Rules)
                {
                    if (rule1.Name == rule2.Name)
                    {
                        ruleFound = true;
                        Assert.AreEqual(rule1.Enabled is null ? true : rule1.Enabled, rule2.Enabled);
                        if (rule1.Definition.Filters != null || rule2.Definition.Filters != null)
                        {
                            Assert.AreEqual(rule1.Definition.Filters.BlobTypes, rule2.Definition.Filters.BlobTypes);
                            Assert.AreEqual(rule1.Definition.Filters.PrefixMatch, rule2.Definition.Filters.PrefixMatch);
                        }
                        if (rule1.Definition.Actions.BaseBlob != null || rule2.Definition.Actions.BaseBlob != null)
                        {
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.TierToCool, rule2.Definition.Actions.BaseBlob.TierToCool);
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.TierToArchive, rule2.Definition.Actions.BaseBlob.TierToArchive);
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.Delete, rule2.Definition.Actions.BaseBlob.Delete);
                        }

                        if (rule1.Definition.Actions.Snapshot != null || rule2.Definition.Actions.Snapshot != null)
                        {
                            CompareDateAfterCreation(rule1.Definition.Actions.Snapshot.Delete, rule1.Definition.Actions.Snapshot.Delete);
                        }
                        break;
                    }
                }
                Assert.True(ruleFound, string.Format("The set rule {0} should be found in the output.", rule1.Name));
            }
        }

        private static void CompareDateAfterModification(DateAfterModification date1, DateAfterModification date2)
        {
            if ((date1 is null) && (date2 is null))
            {
                return;
            }
            Assert.AreEqual(date1.DaysAfterModificationGreaterThan, date2.DaysAfterModificationGreaterThan);
        }

        private static void CompareDateAfterCreation(DateAfterCreation date1, DateAfterCreation date2)
        {
            if ((date1 is null) && (date2 is null))
            {
                return;
            }
            Assert.AreEqual(date1.DaysAfterCreationGreaterThan, date2.DaysAfterCreationGreaterThan);
        }

        [Test]
        public async Task StorageAccountCreateGetdfs()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardGRS);
                StorageAccountCreateParameters parameters =
                    new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: StorageManagementTestUtilities.DefaultRGLocation) { IsHnsEnabled = true };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.True(account.IsHnsEnabled = true);
                Assert.NotNull(account.PrimaryEndpoints.Dfs);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.True(account.IsHnsEnabled = true);
                Assert.NotNull(account.PrimaryEndpoints.Dfs);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithFileStorage()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with StorageV2
                Sku sku = new Sku(SkuName.PremiumLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.FileStorage, location: "centraluseuap");
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.AreEqual(Kind.FileStorage, account.Kind);
                Assert.AreEqual(SkuName.PremiumLRS, account.Sku.Name);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithBlockBlobStorage()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account with StorageV2
                Sku sku = new Sku(SkuName.PremiumLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.BlockBlobStorage, location: "centraluseuap");
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                StorageManagementTestUtilities.VerifyAccountProperties(account, false);
                Assert.AreEqual(Kind.BlockBlobStorage, account.Kind);
                Assert.AreEqual(SkuName.PremiumLRS, account.Sku.Name);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        [Ignore("Unable to locate active AAD DS for AAD tenant Id *************** associated with the storage account.")]
        public async Task StorageAccountCreateSetGetFileAadIntegration()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardGRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: StorageManagementTestUtilities.DefaultLocation)
                {
                    AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.Aadds)
                };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(DirectoryServiceOptions.Aadds, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(DirectoryServiceOptions.Aadds, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

                // Update storage account
                StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters
                {
                    AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.None),
                    EnableHttpsTrafficOnly = true
                };
                account = await _UpdateStorageAccountAsync(rgname, accountName, updateParameters);
                Assert.AreEqual(DirectoryServiceOptions.None, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(DirectoryServiceOptions.None, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountFailOver()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardRagrs);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: StorageManagementTestUtilities.DefaultLocation);
                _ = await _CreateStorageAccountAsync(rgname, accountName, parameters);

                // Wait for account ready to failover and Validate
                StorageAccount account;
                string location;
                int i = 100;
                do
                {
                    account = await AccountsClient.GetPropertiesAsync(rgname, accountName, expand: StorageAccountExpand.GeoReplicationStats);
                    Assert.AreEqual(SkuName.StandardRagrs, account.Sku.Name);
                    Assert.Null(account.FailoverInProgress);
                    location = account.SecondaryLocation;

                    //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                    if (Mode == RecordedTestMode.Record)
                    {
                        System.Threading.Thread.Sleep(10000);
                    }
                } while ((account.GeoReplicationStats.CanFailover != true) && (i-- > 0));

                // Failover storage account
                Operation<Response> failoverWait = await AccountsClient.StartFailoverAsync(rgname, accountName);
                await failoverWait.WaitForCompletionAsync();
                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
                Assert.AreEqual(location, account.PrimaryLocation);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountGetLastSyncTime()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardRagrs);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "eastus2(stage)");
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardRagrs, account.Sku.Name);
                Assert.Null(account.GeoReplicationStats);
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.Null(account.GeoReplicationStats);
                account = await AccountsClient.GetPropertiesAsync(rgname, accountName, StorageAccountExpand.GeoReplicationStats);
                Assert.NotNull(account.GeoReplicationStats);
                Assert.NotNull(account.GeoReplicationStats.Status);
                Assert.NotNull(account.GeoReplicationStats.LastSyncTime);
                Assert.NotNull(account.GeoReplicationStats.CanFailover);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountLargeFileSharesStateTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westeurope")
                {
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
                Assert.AreEqual(LargeFileSharesState.Enabled, account.LargeFileSharesState);

                // Validate
                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
                Assert.AreEqual(LargeFileSharesState.Enabled, account.LargeFileSharesState);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountPrivateEndpointTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westeurope")
                {
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
                Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

                account = await _WaitToGetAccountSuccessfullyAsync(rgname, accountName);
                IList<PrivateEndpointConnection> pes = account.PrivateEndpointConnections;
                foreach (PrivateEndpointConnection pe in pes)
                {
                    //Get from account
                    await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);

                    // Prepare data for set
                    PrivateEndpoint endpoint = new PrivateEndpoint();
                    PrivateEndpointConnection connection = new PrivateEndpointConnection()
                    {
                        PrivateEndpoint = endpoint,
                        PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionState()
                        {
                            ActionRequired = "None",
                            Description = "123",
                            Status = "Approved"
                        }
                    };

                    if (pe.PrivateLinkServiceConnectionState.Status != "Rejected")
                    {
                        //Set approve
                        connection.PrivateLinkServiceConnectionState.Status = "Approved";
                        PrivateEndpointConnection pe3 = await PrivateEndpointConnectionsClient.PutAsync(rgname, accountName, pe.Name, pe);
                        Assert.AreEqual("Approved", pe3.PrivateLinkServiceConnectionState.Status);

                        //Validate approve by get
                        pe3 = await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);
                        Assert.AreEqual("Approved", pe3.PrivateLinkServiceConnectionState.Status);
                    }

                    if (pe.PrivateLinkServiceConnectionState.Status == "Rejected")
                    {
                        //Set reject
                        connection.PrivateLinkServiceConnectionState.Status = "Rejected";
                        PrivateEndpointConnection pe4 = await PrivateEndpointConnectionsClient.PutAsync(rgname, accountName, pe.Name, pe);
                        Assert.AreEqual("Rejected", pe4.PrivateLinkServiceConnectionState.Status);

                        //Validate reject by get
                        pe4 = await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);
                        Assert.AreEqual("Rejected", pe4.PrivateLinkServiceConnectionState.Status);
                    }
                }
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountPrivateLinkTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westus")
                {
                    LargeFileSharesState = LargeFileSharesState.Enabled
                };
                await _CreateStorageAccountAsync(rgname, accountName, parameters);

                // Get private link resource
                Response<PrivateLinkResourceListResult> result = await PrivateLinkResourcesClient.ListByStorageAccountAsync(rgname, accountName);

                // Validate
                Assert.True(result.Value.Value.Count > 0);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task StorageAccountCreateWithTableQueueEcryptionKeyTypeTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "East US 2 EUAP")
                {
                    LargeFileSharesState = LargeFileSharesState.Enabled,
                    Encryption = new Encryption(keySource: KeySource.MicrosoftStorage)
                    {
                        Services = new EncryptionServices
                        {
                            Queue = new EncryptionService { KeyType = KeyType.Account },
                            Table = new EncryptionService { KeyType = KeyType.Account },
                        }
                    }
                };
                StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);

                // Verify encryption settings
                Assert.NotNull(account.Encryption);
                Assert.NotNull(account.Encryption.Services.Blob);
                Assert.True(account.Encryption.Services.Blob.Enabled);
                Assert.AreEqual(KeyType.Account, account.Encryption.Services.Blob.KeyType);
                Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.File);
                Assert.True(account.Encryption.Services.File.Enabled);
                Assert.AreEqual(KeyType.Account, account.Encryption.Services.Blob.KeyType);
                Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.Queue);
                Assert.AreEqual(KeyType.Account, account.Encryption.Services.Queue.KeyType);
                Assert.True(account.Encryption.Services.Queue.Enabled);
                Assert.NotNull(account.Encryption.Services.Queue.LastEnabledTime);

                Assert.NotNull(account.Encryption.Services.Table);
                Assert.AreEqual(KeyType.Account, account.Encryption.Services.Table.KeyType);
                Assert.True(account.Encryption.Services.Table.Enabled);
                Assert.NotNull(account.Encryption.Services.Table.LastEnabledTime);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        [Test]
        public async Task EcryptionScopeTest()
        {
            //Create resource group
            string rgname = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "East US 2 EUAP");
                await _CreateStorageAccountAsync(rgname, accountName, parameters);

                //Create EcryptionScope
                EncryptionScope EncryptionScope = new EncryptionScope()
                {
                    Source = EncryptionScopeSource.MicrosoftStorage,
                    State = EncryptionScopeState.Disabled
                };
                EncryptionScope es = await EncryptionScopesClient.PutAsync(rgname, accountName, "testscope", EncryptionScope);
                Assert.AreEqual("testscope", es.Name);
                Assert.AreEqual(EncryptionScopeState.Disabled, es.State);
                Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

                // Get EcryptionScope
                es = await EncryptionScopesClient.GetAsync(rgname, accountName, "testscope");
                Assert.AreEqual("testscope", es.Name);
                Assert.AreEqual(EncryptionScopeState.Disabled, es.State);
                Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

                // Patch EcryptionScope
                es.State = EncryptionScopeState.Enabled;
                es = await EncryptionScopesClient.PatchAsync(rgname, accountName, "testscope", es);
                Assert.AreEqual("testscope", es.Name);
                Assert.AreEqual(EncryptionScopeState.Enabled, es.State);
                Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

                //List EcryptionScope
                AsyncPageable<EncryptionScope> ess = EncryptionScopesClient.ListAsync(rgname, accountName);
                Task<List<EncryptionScope>> essList = ess.ToEnumerableAsync();
                es = essList.Result.First();
                Assert.AreEqual("testscope", es.Name);
                Assert.AreEqual(EncryptionScopeState.Enabled, es.State);
                Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);
            }
            finally
            {
                if (Mode == RecordedTestMode.Record)
                {
                    //Detele storage account
                    await _DeleteStorageAccountAsync(rgname, accountName);

                    //Delete resource group
                    await _DeleteResourceGroupAsync(rgname);
                }
            }
        }

        private async Task<string> _CreateResourceGroupAsync()
        {
            return await StorageManagementTestUtilities.CreateResourceGroup(ResourceGroupsClient, Recording);
        }

        private async Task<StorageAccount> _CreateStorageAccountAsync(string ResourceGroupName, string AccountName, StorageAccountCreateParameters Parameters = null)
        {
            StorageAccountCreateParameters saParameters = Parameters ?? StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
            Operation<StorageAccount> accountsResponse = await AccountsClient.StartCreateAsync(ResourceGroupName, AccountName, saParameters);
            StorageAccount account = (await accountsResponse.WaitForCompletionAsync()).Value;
            return account;
        }

        private async Task<Response<StorageAccount>> _WaitToGetAccountSuccessfullyAsync(string ResourceGroupName, string AccountName)
        {
            return await AccountsClient.GetPropertiesAsync(ResourceGroupName, AccountName);
        }

        private async Task<Response<StorageAccount>> _UpdateStorageAccountAsync(string ResourceGroupName, string AccountName, StorageAccountUpdateParameters Parameters)
        {
            return await AccountsClient.UpdateAsync(ResourceGroupName, AccountName, Parameters);
        }

        private async Task<Response> _DeleteStorageAccountAsync(string ResourceGroupName, string AccountName)
        {
            return await AccountsClient.DeleteAsync(ResourceGroupName, AccountName);
        }

        private async Task _DeleteResourceGroupAsync(string ResourceGroupName)
        {
            await ResourceGroupsClient.StartDeleteAsync(ResourceGroupName);
        }
    }
}
