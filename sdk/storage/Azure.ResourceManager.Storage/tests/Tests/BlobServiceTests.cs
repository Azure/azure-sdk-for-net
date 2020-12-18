// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public class BlobServiceTests : StorageTestsManagementClientBase
    {
        public BlobServiceTests(bool isAsync) : base(isAsync)
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        // create container
        // delete container
        [Test]
        public async Task BlobContainersCreateDeleteTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            blobContainer = await BlobContainersClient.GetAsync(rgName, accountName, containerName);
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.AreEqual(PublicAccess.None, blobContainer.Value.PublicAccess);
            Assert.False(blobContainer.Value.HasImmutabilityPolicy);
            Assert.False(blobContainer.Value.HasLegalHold);

            //Delete container, then no container in the storage account
            await BlobContainersClient.DeleteAsync(rgName, accountName, containerName);
            AsyncPageable<ListContainerItem> blobContainers = BlobContainersClient.ListAsync(rgName, accountName, include: ListContainersInclude.Deleted);
            Task<List<ListContainerItem>> blobContainersList = blobContainers.ToEnumerableAsync();
            Assert.IsEmpty(blobContainersList.Result);

            //Delete not exist container, won't fail (return 204)
            await BlobContainersClient.DeleteAsync(rgName, accountName, containerName);
        }

        // update container
        // get container properties
        [Test]
        public async Task BlobContainersUpdateTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            blobContainer.Value.Metadata.Add("metadata", "true" );

            blobContainer.Value.PublicAccess = PublicAccess.Container;
            var container = new BlobContainer() { PublicAccess = blobContainer.Value.PublicAccess };
            container.Metadata.InitializeFrom(blobContainer.Value.Metadata);

            Response<BlobContainer> blobContainerSet = await BlobContainersClient.UpdateAsync(rgName, accountName, containerName,
                container);
            Assert.NotNull(blobContainerSet.Value.Metadata);
            Assert.AreEqual(PublicAccess.Container, blobContainerSet.Value.PublicAccess);
            Assert.AreEqual(blobContainerSet.Value.Metadata, blobContainerSet.Value.Metadata);
            Assert.AreEqual(blobContainerSet.Value.PublicAccess, blobContainerSet.Value.PublicAccess);
            Assert.False(blobContainerSet.Value.HasImmutabilityPolicy);
            Assert.False(blobContainerSet.Value.HasLegalHold);

            //TODO:In track1 the function use "CloudStorageAccount" class, the class depend on  "Microsoft.WindowsAzure.Storage ".
            //var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, storageMgmtClient.StorageAccounts.ListKeys(rgName, accountName).Keys.ElementAt(0).Value), false);
            //var container = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName);
            //container.AcquireLeaseAsync(TimeSpan.FromSeconds(45)).Wait();

            Response<BlobContainer> blobContainerGet = await BlobContainersClient.GetAsync(rgName, accountName, containerName);
            Assert.AreEqual(blobContainerGet.Value.PublicAccess, blobContainerGet.Value.PublicAccess);
            Assert.AreEqual(blobContainerGet.Value.Metadata, blobContainerGet.Value.Metadata);
            Assert.False(blobContainerGet.Value.HasImmutabilityPolicy);
            Assert.False(blobContainerGet.Value.HasLegalHold);
        }

        // create/update container with EncryptionScope
        [Test]
        public async Task BlobContainersEncryptionScopeTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            //Create EcryptionScope
            string scopeName1 = "testscope1";
            await EncryptionScopesClient.PutAsync(rgName, accountName, scopeName1,
                new EncryptionScope()
                {
                    Source = EncryptionScopeSource.MicrosoftStorage,
                    State = EncryptionScopeState.Disabled
                });

            string scopeName2 = "testscope2";
            await EncryptionScopesClient.PutAsync(rgName, accountName, scopeName2,
                new EncryptionScope()
                {
                    Source = EncryptionScopeSource.MicrosoftStorage,
                    State = EncryptionScopeState.Disabled
                });

            //Create container
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer() { DefaultEncryptionScope = scopeName1, DenyEncryptionScopeOverride = false });
            Assert.AreEqual(scopeName1, blobContainer.Value.DefaultEncryptionScope);
            Assert.False(blobContainer.Value.DenyEncryptionScopeOverride.Value);

            //Update container not support Encryption scope
            Response<BlobContainer> blobContainer2 = await BlobContainersClient.UpdateAsync(rgName, accountName, containerName, new BlobContainer() { DefaultEncryptionScope = scopeName2, DenyEncryptionScopeOverride = true });
            Assert.AreEqual(scopeName2, blobContainer2.Value.DefaultEncryptionScope);
            Assert.True(blobContainer2.Value.DenyEncryptionScopeOverride.Value);
        }

        // list containers
        [Test]
        public async Task BlobContainersListTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName1 = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName1, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            blobContainer.Value.Metadata.Add("metadata", "true");
            blobContainer.Value.PublicAccess = PublicAccess.Container;
            var container = new BlobContainer()
            {
                PublicAccess = blobContainer.Value.PublicAccess
            };
            container.Metadata.InitializeFrom(blobContainer.Value.Metadata);

            Response<BlobContainer> blobContainerSet =
                await BlobContainersClient.UpdateAsync(rgName, accountName, containerName1,
                                                       container);
            Assert.NotNull(blobContainer.Value.Metadata);
            Assert.NotNull(blobContainer.Value.PublicAccess);
            Assert.AreEqual(blobContainer.Value.Metadata, blobContainerSet.Value.Metadata);
            Assert.AreEqual(blobContainer.Value.PublicAccess, blobContainerSet.Value.PublicAccess);
            Assert.False(blobContainerSet.Value.HasImmutabilityPolicy);
            Assert.False(blobContainerSet.Value.HasLegalHold);

            string containerName2 = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer2 = await BlobContainersClient.CreateAsync(rgName, accountName, containerName2, new BlobContainer());
            Assert.IsEmpty(blobContainer2.Value.Metadata);
            Assert.Null(blobContainer2.Value.PublicAccess);

            string containerName3 = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer3 = await BlobContainersClient.CreateAsync(rgName, accountName, containerName3, new BlobContainer());
            Assert.IsEmpty(blobContainer3.Value.Metadata);
            Assert.Null(blobContainer3.Value.PublicAccess);

            //TODO:In track1 the function use "CloudStorageAccount" class, the class depend on  "Microsoft.WindowsAzure.Storage ".
            //var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, storageMgmtClient.StorageAccounts.ListKeys(rgName, accountName).Keys.ElementAt(0).Value), false);
            //var container = storageAccount.CreateCloudBlobClient().GetContainerReference(containerName2);
            //container.AcquireLeaseAsync(TimeSpan.FromSeconds(45)).Wait();

            //List container
            AsyncPageable<ListContainerItem> containerList = BlobContainersClient.ListAsync(rgName, accountName, include: ListContainersInclude.Deleted);
            Task<List<ListContainerItem>> containerLists = containerList.ToEnumerableAsync();
            Assert.AreEqual(3, containerLists.Result.Count());
            foreach (ListContainerItem blobContainerList in containerLists.Result)
            {
                Assert.NotNull(blobContainerList.Name);
                Assert.NotNull(blobContainerList.PublicAccess);
                Assert.False(blobContainerList.HasImmutabilityPolicy);
                Assert.False(blobContainerList.HasLegalHold);
            }

            //List container with next link
            containerList = BlobContainersClient.ListAsync(rgName, accountName, "2", include: ListContainersInclude.Deleted);
            Task<List<Page<ListContainerItem>>> pages = containerList.AsPages().ToEnumerableAsync();
            Assert.AreEqual(2, pages.Result.Count());
        }

        [Test]
        public async Task BlobContainersGetTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            LegalHold LegalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            Response<LegalHold> legalHold = await BlobContainersClient.SetLegalHoldAsync(rgName, accountName, containerName, LegalHoldModel);
            Assert.True(legalHold.Value.HasLegalHold);
            Assert.AreEqual(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Value.Tags);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            immutabilityPolicy = await BlobContainersClient.LockImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Value.State);

            ImmutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays = 100;
            immutabilityPolicy = await BlobContainersClient.ExtendImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(100, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Value.State);

            blobContainer = await BlobContainersClient.GetAsync(rgName, accountName, containerName);
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.AreEqual(PublicAccess.None, blobContainer.Value.PublicAccess);
            Assert.AreEqual(3, blobContainer.Value.ImmutabilityPolicy.UpdateHistory.Count);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Put, blobContainer.Value.ImmutabilityPolicy.UpdateHistory[0].Update);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Lock, blobContainer.Value.ImmutabilityPolicy.UpdateHistory[1].Update);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Extend, blobContainer.Value.ImmutabilityPolicy.UpdateHistory[2].Update);
            Assert.True(blobContainer.Value.LegalHold.HasLegalHold);
            Assert.AreEqual(3, blobContainer.Value.LegalHold.Tags.Count);
            Assert.AreEqual("tag1", blobContainer.Value.LegalHold.Tags[0].Tag);
            Assert.AreEqual("tag2", blobContainer.Value.LegalHold.Tags[1].Tag);
            Assert.AreEqual("tag3", blobContainer.Value.LegalHold.Tags[2].Tag);

            legalHold = await BlobContainersClient.ClearLegalHoldAsync(rgName, accountName, containerName, LegalHoldModel);
            Assert.False(legalHold.Value.HasLegalHold);

            await BlobContainersClient.DeleteAsync(rgName, accountName, containerName);
        }

        // set/clear legal hold.
        [Test]
        public async Task BlobContainersSetLegalHoldTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            LegalHold LegalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            Response<LegalHold> legalHold = await BlobContainersClient.SetLegalHoldAsync(rgName, accountName, containerName, LegalHoldModel);
            Assert.True(legalHold.Value.HasLegalHold);
            Assert.AreEqual(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Value.Tags);

            legalHold = await BlobContainersClient.ClearLegalHoldAsync(rgName, accountName, containerName, LegalHoldModel);
            Assert.False(legalHold.Value.HasLegalHold);
            Assert.AreEqual(0, legalHold.Value.Tags.Count);
        }

        //TODO:In track1 the function is comment out.
        // Lease Blob Containers
        //[Test]
        //public async Task BlobContainersLeaseTest()
        //{
        //    var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

        //    using (MockContext context = MockContext.Start(this.GetType()))
        //    {
        //        var resourcesClient = GetResourceManagementClient(context, handler);
        //        var storageMgmtClient = GetStorageManagementClient(context, handler);

        //        //// Create resource group
        //        //var rgName = CreateResourceGroup(resourcesClient);

        //        //// Create storage account
        //        //string accountName = TestUtilities.GenerateName("sto");
        //        //var parameters = GetDefaultStorageAccountParameters();
        //        //parameters.Kind = Kind.StorageV2;
        //        //var account = storageMgmtClient.StorageAccounts.Create(rgName, accountName, parameters);
        //        //VerifyAccountProperties(account, false);

        //        var rgName = "weitry";
        //        string accountName = "weiacl3";
        //        string containerName = TestUtilities.GenerateName("container");

        //        // implement case
        //        try
        //        {
        //            BlobContainer blobContainer = storageMgmtClient.BlobContainers.Create(rgName, accountName, containerName);
        //            Assert.Null(blobContainer.Metadata);
        //            Assert.Null(blobContainer.PublicAccess);

        //            //LeaseContainerResponse leaseResponse = storageMgmtClient.BlobContainers.Lease(rgName, accountName, containerName, new LeaseContainerRequest("Acquire", null, 40, 9));
        //            LeaseContainerResponse leaseResponse = storageMgmtClient.BlobContainers.Lease(rgName, accountName, containerName);
        //            Assert.NotNull(leaseResponse.LeaseId);

        //            blobContainer = storageMgmtClient.BlobContainers.Get(rgName, accountName, containerName);
        //            Assert.Equal("Leased", blobContainer.LeaseState);
        //        }
        //        finally
        //        {
        //            storageMgmtClient.BlobContainers.Delete(rgName, accountName, containerName);
        //            //// clean up
        //            //storageMgmtClient.StorageAccounts.Delete(rgName, accountName);
        //            //resourcesClient.ResourceGroups.Delete(rgName);
        //        }
        //    }
        //}

        // create and delete immutability policies.
        [Test]
        public async Task BlobContainersCreateDeleteImmutabilityPolicyTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            immutabilityPolicy = await BlobContainersClient.DeleteImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(0, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual("Deleted", immutabilityPolicy.Value.State.ToString());
        }

        // update and get immutability policies.
        [Test]
        public async Task BlobContainersUpdateImmutabilityPolicyTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            ImmutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays = 5;
            immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(5, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            immutabilityPolicy = await BlobContainersClient.GetImmutabilityPolicyAsync(rgName, accountName, containerName);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(5, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);
        }

        // create/update immutability policies with AllowProtectedAppendWrites.
        [Test]
        public async Task ImmutabilityPolicyTest_AllowProtectedAppendWrites()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 4, AllowProtectedAppendWrites = true };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(4, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);
            Assert.True(immutabilityPolicy.Value.AllowProtectedAppendWrites.Value);

            ImmutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays = 5;
            ImmutabilityPolicyModel.AllowProtectedAppendWrites = false;
            immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(5, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);
            Assert.False(immutabilityPolicy.Value.AllowProtectedAppendWrites.Value);

            immutabilityPolicy = await BlobContainersClient.GetImmutabilityPolicyAsync(rgName, accountName, containerName);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(5, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);
            Assert.False(immutabilityPolicy.Value.AllowProtectedAppendWrites.Value);
        }

        // lock immutability policies.
        [Test]
        public async Task BlobContainersLockImmutabilityPolicyTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            immutabilityPolicy = await BlobContainersClient.LockImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Value.State);

            await BlobContainersClient.DeleteAsync(rgName, accountName, containerName);
        }

        // extend immutability policies.
        [Test]
        public async Task BlobContainersExtendImmutabilityPolicyTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            VerifyAccountProperties(account, false);

            // implement case
            string containerName = Recording.GenerateAssetName("container");
            Response<BlobContainer> blobContainer = await BlobContainersClient.CreateAsync(rgName, accountName, containerName, new BlobContainer());
            Assert.IsEmpty(blobContainer.Value.Metadata);
            Assert.Null(blobContainer.Value.PublicAccess);

            ImmutabilityPolicy ImmutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            Response<ImmutabilityPolicy> immutabilityPolicy = await BlobContainersClient.CreateOrUpdateImmutabilityPolicyAsync(rgName, accountName, containerName, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Value.State);

            immutabilityPolicy = await BlobContainersClient.LockImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(3, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Value.State);

            ImmutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays = 100;
            immutabilityPolicy = await BlobContainersClient.ExtendImmutabilityPolicyAsync(rgName, accountName, containerName, ifMatch: immutabilityPolicy.Value.Etag, parameters: ImmutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Value.Id);
            Assert.NotNull(immutabilityPolicy.Value.Type);
            Assert.NotNull(immutabilityPolicy.Value.Name);
            Assert.AreEqual(100, immutabilityPolicy.Value.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Value.State);

            await BlobContainersClient.DeleteAsync(rgName, accountName, containerName);
        }

        // Get/Set Blob Service Properties
        [Test]
        public async Task BlobServiceTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            Response<BlobServiceProperties> properties1 = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            Assert.False(properties1.Value.DeleteRetentionPolicy.Enabled);
            Assert.Null(properties1.Value.DeleteRetentionPolicy.Days);
            Assert.Null(properties1.Value.DefaultServiceVersion);
            Assert.AreEqual(0, properties1.Value.Cors.CorsRulesValue.Count);
            Assert.AreEqual(SkuName.StandardGRS, properties1.Value.Sku.Name);
            BlobServiceProperties properties2 = properties1;
            properties2.DeleteRetentionPolicy = new DeleteRetentionPolicy
            {
                Enabled = true,
                Days = 300
            };
            properties2.DefaultServiceVersion = "2017-04-17";
            await BlobServicesClient.SetServicePropertiesAsync(rgName, accountName, properties2);
            Response<BlobServiceProperties> properties3 = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            Assert.True(properties3.Value.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(300, properties3.Value.DeleteRetentionPolicy.Days);
            Assert.AreEqual("2017-04-17", properties3.Value.DefaultServiceVersion);
        }

        // Get/Set Cors rules in Blob Service Properties
        [Test]
        public async Task BlobServiceCorsTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            Response<BlobServiceProperties> properties1 = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            BlobServiceProperties properties2 = new BlobServiceProperties
            {
                DeleteRetentionPolicy = new DeleteRetentionPolicy
                {
                    Enabled = true,
                    Days = 300
                },
                DefaultServiceVersion = "2017-04-17",
                Cors = new CorsRules()
            };
            properties2.Cors.CorsRulesValue.Add(
                    new CorsRule(allowedOrigins:new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                    allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                    maxAgeInSeconds:100,
                    exposedHeaders:new string[] { "x-ms-meta-*" },
                    allowedHeaders:new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }));

            properties2.Cors.CorsRulesValue.Add(new CorsRule(allowedOrigins: new string[] { "*" },
                allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET" },
                maxAgeInSeconds: 2,
                exposedHeaders: new string[] { "*" },
                allowedHeaders: new string[] { "*" }));

            properties2.Cors.CorsRulesValue.Add(new CorsRule(allowedOrigins: new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "PUT", "CONNECT" },
                maxAgeInSeconds: 2000,
                exposedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x -ms-meta-target*" },
                allowedHeaders: new string[] { "x-ms-meta-12345675754564*" }));

            Response<BlobServiceProperties> properties3 = await BlobServicesClient.SetServicePropertiesAsync(rgName, accountName, properties2);
            Assert.True(properties3.Value.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(300, properties3.Value.DeleteRetentionPolicy.Days);
            Assert.AreEqual("2017-04-17", properties3.Value.DefaultServiceVersion);

            //Validate CORS Rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties3.Value.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties3.Value.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            Response<BlobServiceProperties> properties4 = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            Assert.True(properties4.Value.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(300, properties4.Value.DeleteRetentionPolicy.Days);
            Assert.AreEqual("2017-04-17", properties4.Value.DefaultServiceVersion);

            //Validate CORS Rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties4.Value.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties4.Value.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }

        // List Blob Service
        [Test]
        public async Task ListBlobServiceTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName);
            VerifyAccountProperties(account, true);

            // implement case
            AsyncPageable<BlobServiceProperties> properties = BlobServicesClient.ListAsync(rgName, accountName);
            Task<List<BlobServiceProperties>> propertiesList = properties.ToEnumerableAsync();
            Assert.AreEqual(1, propertiesList.Result.Count);
            Assert.AreEqual("default", propertiesList.Result[0].Name);
        }

        // Point In Time Restore test
        [Test]
        [Ignore("Track2: Response<BlobRestoreStatus> restoreStatusResponse = await WaitForCompletionAsync(restoreStatus); Always timeout")]
        public async Task PITRTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku Sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: Sku, kind: Kind.StorageV2);
            StorageAccount account = await CreateStorageAccountAsync(rgName, accountName, parameters);
            Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

            account = await AccountsClient.GetPropertiesAsync(rgName, accountName, StorageAccountExpand.BlobRestoreStatus);
            Assert.Null(account.BlobRestoreStatus);

            // implement case
            //enable changefeed and softdelete, and enable restore policy
            Response<BlobServiceProperties> properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            properties.Value.DeleteRetentionPolicy = new DeleteRetentionPolicy
            {
                Enabled = true,
                Days = 30
            };
            properties.Value.ChangeFeed = new ChangeFeed
            {
                Enabled = true
            };
            properties.Value.RestorePolicy = new RestorePolicyProperties(true) { Days = 5 };
            properties.Value.IsVersioningEnabled = true;
            await BlobServicesClient.SetServicePropertiesAsync(rgName, accountName, properties);
            properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, accountName);
            Assert.True(properties.Value.RestorePolicy.Enabled);
            Assert.AreEqual(5, properties.Value.RestorePolicy.Days);
            Assert.True(properties.Value.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(30, properties.Value.DeleteRetentionPolicy.Days);
            Assert.True(properties.Value.ChangeFeed.Enabled);

            // restore blobs
            //Don't need sleep when playback, or Unit test will be slow.
            if (Mode == RecordedTestMode.Record)
            {
                System.Threading.Thread.Sleep(10000);
            }
            List<BlobRestoreRange> ranges = new List<BlobRestoreRange>
                {
                    new BlobRestoreRange("", "container1/blob1"),
                    new BlobRestoreRange("container1/blob2", "container2/blob3"),
                    new BlobRestoreRange("container3/blob3", "")
                };
            DateTimeOffset dateTimeOffset = DateTime.UtcNow.AddSeconds(-1);
            BlobRestoreParameters BlobRestoreParametersModel = new BlobRestoreParameters(dateTimeOffset, ranges);
            Operation<BlobRestoreStatus> restoreStatus = await AccountsClient.StartRestoreBlobRangesAsync(rgName, accountName, BlobRestoreParametersModel);
            Response<BlobRestoreStatus> restoreStatusResponse = await WaitForCompletionAsync(restoreStatus);
            Assert.AreEqual("Complete", restoreStatusResponse.Value.Status.ToString());

            account = await AccountsClient.GetPropertiesAsync(rgName, accountName, StorageAccountExpand.BlobRestoreStatus);
            Assert.AreEqual("Complete", account.BlobRestoreStatus.Status.ToString());
        }

        // Object replication test
        [Test]
        public async Task ORSTest()
        {
            // Create resource group
            string rgName = await CreateResourceGroupAsync();
            string sourceAccountName = Recording.GenerateAssetName("sto");
            string destAccountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku Sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: Sku, kind: Kind.StorageV2);
            StorageAccount sourceAccount = await CreateStorageAccountAsync(rgName, sourceAccountName, parameters);
            StorageAccount destAccount = await CreateStorageAccountAsync(rgName, destAccountName, parameters);
            Assert.AreEqual(SkuName.StandardLRS, sourceAccount.Sku.Name);
            Assert.AreEqual(SkuName.StandardLRS, destAccount.Sku.Name);

            // implement case
            //enable changefeed and versioning
            Response<BlobServiceProperties> properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, sourceAccountName);
            properties.Value.ChangeFeed = new ChangeFeed { Enabled = true };
            properties.Value.IsVersioningEnabled = true;
            await BlobServicesClient.SetServicePropertiesAsync(rgName, sourceAccountName, properties);
            properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, sourceAccountName);
            Assert.True(properties.Value.IsVersioningEnabled);
            Assert.True(properties.Value.ChangeFeed.Enabled);

            properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, destAccountName);
            properties.Value.ChangeFeed = new ChangeFeed { Enabled = true };
            properties.Value.IsVersioningEnabled = true;
            await BlobServicesClient.SetServicePropertiesAsync(rgName, destAccountName, properties);
            properties = await BlobServicesClient.GetServicePropertiesAsync(rgName, destAccountName);
            Assert.True(properties.Value.IsVersioningEnabled);
            Assert.True(properties.Value.ChangeFeed.Enabled);

            //Create Source and dest container
            string sourceContainerName1 = "src1";
            string sourceContainerName2 = "src2";
            string destContainerName1 = "dest1";
            string destContainerName2 = "dest2";
            await BlobContainersClient.CreateAsync(rgName, sourceAccountName, sourceContainerName1, new BlobContainer());
            await BlobContainersClient.CreateAsync(rgName, sourceAccountName, sourceContainerName2, new BlobContainer());
            await BlobContainersClient.CreateAsync(rgName, destAccountName, destContainerName1, new BlobContainer());
            await BlobContainersClient.CreateAsync(rgName, destAccountName, destContainerName2, new BlobContainer());

            //new rules
            string minCreationTime = "2020-03-19T16:06:00Z";
            List<ObjectReplicationPolicyRule> rules = new List<ObjectReplicationPolicyRule>
                {
                    new ObjectReplicationPolicyRule(sourceContainer: sourceContainerName1, destinationContainer: destContainerName1)
                    {
                        Filters = new ObjectReplicationPolicyFilter()
                        {
                            PrefixMatch = { "aa", "bc d", "123" },
                            MinCreationTime = minCreationTime
                        }
                    },
                    new ObjectReplicationPolicyRule(sourceContainer: sourceContainerName2, destinationContainer: destContainerName2)
                };

            //New policy
            ObjectReplicationPolicy policy = new ObjectReplicationPolicy()
            {
                SourceAccount = sourceAccountName,
                DestinationAccount = destAccountName,
            };
            policy.Rules.InitializeFrom(rules);
            //Set and list policy
            await ObjectReplicationPoliciesClient.CreateOrUpdateAsync(rgName, destAccountName, "default", policy);
            ObjectReplicationPolicy destpolicy = ObjectReplicationPoliciesClient.ListAsync(rgName, destAccountName).ToEnumerableAsync().Result.First();

            // Fix the MinCreationTime format, since deserilize the request the string MinCreationTime will be taken as DateTime, so the format will change. But server only allows format "2020-03-19T16:06:00Z"
            // This issue can be resolved in the future, when server change MinCreationTime type from string to Datatime
            FixMinCreationTimeFormat(destpolicy);
            CompareORsPolicy(policy, destpolicy);

            await ObjectReplicationPoliciesClient.CreateOrUpdateAsync(rgName, sourceAccountName, destpolicy.PolicyId, destpolicy);
            ObjectReplicationPolicy sourcepolicy = ObjectReplicationPoliciesClient.ListAsync(rgName, sourceAccountName).ToEnumerableAsync().Result.First();
            FixMinCreationTimeFormat(sourcepolicy);
            CompareORsPolicy(destpolicy, sourcepolicy, skipIDCompare: false);

            // Get policy
            destpolicy = await ObjectReplicationPoliciesClient.GetAsync(rgName, destAccountName, destpolicy.PolicyId);
            FixMinCreationTimeFormat(destpolicy);
            CompareORsPolicy(policy, destpolicy);
            sourcepolicy = await ObjectReplicationPoliciesClient.GetAsync(rgName, sourceAccountName, destpolicy.PolicyId);
            FixMinCreationTimeFormat(sourcepolicy);
            CompareORsPolicy(policy, sourcepolicy);

            // remove policy
            await ObjectReplicationPoliciesClient.DeleteAsync(rgName, sourceAccountName, destpolicy.PolicyId);
            await ObjectReplicationPoliciesClient.DeleteAsync(rgName, destAccountName, destpolicy.PolicyId);
        }

        /// <summary>
        /// Fix the MinCreationTime format, since deserilize the request the string MinCreationTime will be taken as DateTime, so the format will change.
        /// But server only allows format "2020-03-19T16:06:00Z"
        /// This issue can be resolved in the future, when server change MinCreationTime type from string to Datatime.
        /// </summary>
        /// <param name="getPolicy"></param>
        private static void FixMinCreationTimeFormat(ObjectReplicationPolicy getPolicy)
        {
            if (getPolicy != null && getPolicy.Rules != null)
            {
                foreach (ObjectReplicationPolicyRule rule in getPolicy.Rules)
                {
                    if (rule != null && rule.Filters != null && !string.IsNullOrEmpty(rule.Filters.MinCreationTime))
                    {
                        if (rule.Filters.MinCreationTime.ToUpper()[rule.Filters.MinCreationTime.Length - 1] != 'Z')
                        {
                            rule.Filters.MinCreationTime = Convert.ToDateTime(rule.Filters.MinCreationTime + "Z").ToUniversalTime().ToString("s") + "Z";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Compare 2 ORS policy, check if they are same.
        /// </summary>
        /// <param name="skipIDCompare">skip compare policyID and rule ID.</param>
        private static void CompareORsPolicy(ObjectReplicationPolicy setPolicy, ObjectReplicationPolicy getPolicy, bool skipIDCompare = true)
        {
            Assert.AreEqual(setPolicy.SourceAccount, getPolicy.SourceAccount);
            Assert.AreEqual(setPolicy.DestinationAccount, getPolicy.DestinationAccount);
            Assert.AreEqual(setPolicy.Rules.Count, getPolicy.Rules.Count);
            if (!skipIDCompare)
            {
                Assert.AreEqual(setPolicy.PolicyId, getPolicy.PolicyId);
            }
            else
            {
                Assert.NotNull(getPolicy.PolicyId);
            }

            ObjectReplicationPolicyRule[] setRuleArray = setPolicy.Rules.ToArray();
            ObjectReplicationPolicyRule[] getRuleArray = getPolicy.Rules.ToArray();
            for (int i = 0; i < setRuleArray.Length; i++)
            {
                ObjectReplicationPolicyRule setrule = setRuleArray[i];
                ObjectReplicationPolicyRule getrule = getRuleArray[i];
                Assert.AreEqual(setrule.SourceContainer, getrule.SourceContainer);
                Assert.AreEqual(setrule.DestinationContainer, getrule.DestinationContainer);
                if (setrule.Filters == null)
                {
                    Assert.Null(getrule.Filters);
                }
                else
                {
                    Assert.AreEqual(setrule.Filters.MinCreationTime, getrule.Filters.MinCreationTime);
                    Assert.AreEqual(setrule.Filters.PrefixMatch, getrule.Filters.PrefixMatch);
                }
                if (!skipIDCompare)
                {
                    Assert.AreEqual(setrule.RuleId, getrule.RuleId);
                }
                else
                {
                    Assert.NotNull(getrule.RuleId);
                }
            }
        }

        private async Task<string> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(ResourceGroupsClient, Recording);
        }

        private async Task<StorageAccount> CreateStorageAccountAsync(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters = null)
        {
            StorageAccountCreateParameters saParameters = parameters ?? GetDefaultStorageAccountParameters();
            Operation<StorageAccount> accountsResponse = await AccountsClient.StartCreateAsync(resourceGroupName, accountName, saParameters);
            StorageAccount account = (await WaitForCompletionAsync(accountsResponse)).Value;
            return account;
        }
    }
}
