// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobContainerTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private BlobService _blobService;
        private BlobContainerCollection _blobContainerCollection;
        public BlobContainerTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task createStorageAccountAndGetBlobContainerContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _blobService = _storageAccount.GetBlobService();
            _blobService = await _blobService.GetAsync();
            _blobContainerCollection = _blobService.GetBlobContainers();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteBlobContainer()
        {
            //create blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainer container1 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;
            Assert.IsNotNull(container1);
            Assert.AreEqual(container1.Id.Name, containerName);

            //validate if created successfully
            BlobContainer container2 = await _blobContainerCollection.GetAsync(containerName);
            AssertBlobContainerEqual(container1, container2);
            Assert.IsTrue(await _blobContainerCollection.CheckIfExistsAsync(containerName));
            Assert.IsFalse(await _blobContainerCollection.CheckIfExistsAsync(containerName + "1"));
            BlobContainerData containerData = container1.Data;
            Assert.IsEmpty(containerData.Metadata);
            Assert.IsFalse(containerData.HasLegalHold);
            Assert.IsNull(containerData.PublicAccess);
            Assert.False(containerData.HasImmutabilityPolicy);

            //delete blob container
            BlobContainerDeleteOperation blobContainerDeleteOperation = await container1.DeleteAsync();
            await blobContainerDeleteOperation.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            BlobContainer blobContainer3 = await _blobContainerCollection.GetIfExistsAsync(containerName);
            Assert.IsNull(blobContainer3);
            Assert.IsFalse(await _blobContainerCollection.CheckIfExistsAsync(containerName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllBlobContainers()
        {
            //create two blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainer container1 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName1, new BlobContainerData())).Value;
            BlobContainer container2 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName2, new BlobContainerData())).Value;

            //validate if there are two containers
            BlobContainer container3 = null;
            BlobContainer container4 = null;
            int count = 0;
            await foreach (BlobContainer container in _blobContainerCollection.GetAllAsync())
            {
                count++;
                if (container.Id.Name == containerName1)
                    container3 = container;
                if (container.Id.Name == containerName2)
                    container4 = container;
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(container3);
            Assert.IsNotNull(container4);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateBlobContainer()
        {
            //create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //update metadata, public access
            BlobContainerData containerData = container.Data;
            containerData.Metadata.Add("key1", "value1");
            containerData.PublicAccess = PublicAccess.Container;
            BlobContainer container1 = await container.UpdateAsync(containerData);

            //validate
            Assert.NotNull(container1);
            Assert.NotNull(container1.Data.Metadata);
            Assert.AreEqual(container1.Data.Metadata["key1"], "value1");
            Assert.AreEqual(PublicAccess.Container, container.Data.PublicAccess);
            Assert.False(container1.Data.HasLegalHold);
            Assert.False(container1.Data.HasImmutabilityPolicy);
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteImmutabilityPolicy()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicy immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(parameters: immutabilityPolicyModel)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //delete immutability policy
            immutabilityPolicyModel = (await immutabilityPolicy.DeleteAsync(immutabilityPolicy.Data.Etag)).Value;

            //validate
            Assert.NotNull(immutabilityPolicyModel.Type);
            Assert.NotNull(immutabilityPolicyModel.Name);
            Assert.AreEqual(0, immutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays);
        }

        [Test]
        [RecordedTest]
        public async Task LockImmutabilityPolicy()
        {
            //update storage account to v2
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                Kind = Kind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicy immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(parameters: immutabilityPolicyModel)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Data.Etag);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            await container.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task ExtendImmutabilityPolicy()
        {
            //update storage account to v2
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                Kind = Kind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicy immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(ifMatch: "", parameters: immutabilityPolicyModel)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Data.Etag);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            //extend immutability policy
            immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 100 };
            immutabilityPolicy = await container.GetImmutabilityPolicy().ExtendImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Data.Etag, parameters: immutabilityPolicyModel);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(100, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);
            await container.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task SetClearLegalHold()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //set legal hold
            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold = await container.SetLegalHoldAsync(legalHoldModel);

            //validate
            Assert.True(legalHold.HasLegalHold);
            Assert.AreEqual(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Tags);

            //clear legal hold
            legalHold = await container.ClearLegalHoldAsync(legalHoldModel);

            //validate
            Assert.False(legalHold.HasLegalHold);
            Assert.AreEqual(0, legalHold.Tags.Count);
        }
        //[Test]
        //[RecordedTest]
        //public async Task ListBlobService()
        //{
        //    List<BlobService> blobServices = await _blobServiceCollection.GetAllAsync().ToEnumerableAsync();
        //    Assert.AreEqual(1, blobServices.Count);
        //    Assert.AreEqual("default", blobServices[0].Data.Name);
        //}

        [Test]
        [RecordedTest]
        public async Task UpdateBlobService()
        {
            //validate current file service properties
            Assert.False(_blobService.Data.DeleteRetentionPolicy.Enabled);
            Assert.Null(_blobService.Data.DeleteRetentionPolicy.Days);

            //update delete retention policy
            BlobServiceData serviceData = _blobService.Data;
            serviceData.DeleteRetentionPolicy = new DeleteRetentionPolicy
            {
                Enabled = true,
                Days = 100
            };
            BlobService service = (await _blobService.CreateOrUpdateAsync(serviceData)).Value;

            //validate update
            Assert.True(service.Data.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(service.Data.DeleteRetentionPolicy.Days, 100);
        }

        [Test]
        [RecordedTest]
        public async Task ImmutabilityPolicy_AllowProtectedAppendWrites()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerCollection.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;
            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData()
            {
                ImmutabilityPeriodSinceCreationInDays = 4,
                AllowProtectedAppendWrites = true
            };
            ImmutabilityPolicy immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(ifMatch: "", parameters: immutabilityPolicyModel)).Value;
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(4, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.True(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);

            immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays = 5;
            immutabilityPolicy.Data.AllowProtectedAppendWrites = false;
            immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(ifMatch: immutabilityPolicy.Data.Etag, immutabilityPolicy.Data)).Value;
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.False(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);

            immutabilityPolicy = await container.GetImmutabilityPolicy().GetAsync(immutabilityPolicy.Data.Etag);
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.Type);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.False(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetDeleteObjectReplicationPolicy()
        {
            //create 2 storage accounts
            string accountName1 = await CreateValidAccountNameAsync("teststoragemgmt");
            string accountName2 = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCreateParameters createParameters = GetDefaultStorageAccountParameters(kind: Kind.StorageV2);
            StorageAccount sourceAccount = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(accountName1, createParameters)).Value;
            StorageAccount destAccount = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(accountName2, createParameters)).Value;

            //update 2 accounts properties
            var updateparameter = new StorageAccountUpdateParameters
            {
                AllowCrossTenantReplication = true,
                EnableHttpsTrafficOnly = true
            };
            destAccount = await destAccount.UpdateAsync(updateparameter);
            sourceAccount = await sourceAccount.UpdateAsync(updateparameter);

            BlobService blobService1 = await destAccount.GetBlobService().GetAsync();
            BlobContainerCollection blobContainerCollection1 = blobService1.GetBlobContainers();
            BlobService blobService2 = await destAccount.GetBlobService().GetAsync();
            BlobContainerCollection blobContainerCollection2 = blobService2.GetBlobContainers();

            //enable changefeed and versoning
            blobService1.Data.IsVersioningEnabled = true;
            await blobService1.CreateOrUpdateAsync(blobService1.Data);

            //create 2 pairs of source and dest blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            string containerName3 = Recording.GenerateAssetName("testblob3");
            string containerName4 = Recording.GenerateAssetName("testblob4");
            BlobContainer container1 = (await blobContainerCollection1.CreateOrUpdateAsync(containerName1, new BlobContainerData())).Value;
            BlobContainer container2 = (await blobContainerCollection2.CreateOrUpdateAsync(containerName2, new BlobContainerData())).Value;
            BlobContainer container3 = (await blobContainerCollection1.CreateOrUpdateAsync(containerName3, new BlobContainerData())).Value;
            BlobContainer container4 = (await blobContainerCollection2.CreateOrUpdateAsync(containerName4, new BlobContainerData())).Value;

            //prepare rules and policy
            ObjectReplicationPolicyData parameter = new ObjectReplicationPolicyData()
            {
                SourceAccount = sourceAccount.Id.Name,
                DestinationAccount = destAccount.Id.Name
            };
            List<string> prefix = new List<string>();
            prefix.Add("aa");
            prefix.Add("bc d");
            prefix.Add("123");
            string minCreationTime = "2021-03-19T16:06:00Z";
            List<ObjectReplicationPolicyRule> rules = new List<ObjectReplicationPolicyRule>();
            parameter.Rules.Add(
                new ObjectReplicationPolicyRule(containerName1, containerName2)
                {
                    Filters = new ObjectReplicationPolicyFilter(prefix, minCreationTime),
                }
            );
            parameter.Rules.Add(
                new ObjectReplicationPolicyRule(containerName3, containerName4)
            );

            //create policy
            ObjectReplicationPolicyCollection objectReplicationPolicyCollection = destAccount.GetObjectReplicationPolicies();
            ObjectReplicationPolicy objectReplicationPolicy = (await objectReplicationPolicyCollection.CreateOrUpdateAsync("default", parameter)).Value;
            Assert.NotNull(objectReplicationPolicy);
            Assert.AreEqual(objectReplicationPolicy.Data.DestinationAccount, destAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.SourceAccount, sourceAccount.Id.Name);

            //get policy
            List<ObjectReplicationPolicy> policies = await objectReplicationPolicyCollection.GetAllAsync().ToEnumerableAsync();
            objectReplicationPolicy = policies[0];
            Assert.NotNull(objectReplicationPolicy);
            Assert.AreEqual(objectReplicationPolicy.Data.DestinationAccount, destAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.SourceAccount, sourceAccount.Id.Name);

            //delete policy
            await objectReplicationPolicy.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task BlobServiceCors()
        {
            BlobServiceData properties1 = _blobService.Data;
            BlobServiceData properties2 = new BlobServiceData();
            properties2.DeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties2.DeleteRetentionPolicy.Enabled = true;
            properties2.DeleteRetentionPolicy.Days = 300;
            properties2.DefaultServiceVersion = "2017-04-17";
            properties2.Cors = new CorsRules();
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET, CorsRuleAllowedMethodsItem.PUT },
                100, new string[] { "x-ms-meta-*" },
                new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }
                ));
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "*" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET },
                2, new string[] { "*" },
                new string[] { "*" }
                ));
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET, CorsRuleAllowedMethodsItem.PUT, CorsRuleAllowedMethodsItem.Post },
                2000, new string[] { "x-ms-meta-12345675754564*" },
                new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }
                ));

            _blobService = (await _blobService.CreateOrUpdateAsync(properties2)).Value;
            BlobServiceData properties3 = _blobService.Data;
            Assert.IsTrue(properties3.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(300, properties3.DeleteRetentionPolicy.Days);
            Assert.AreEqual("2017-04-17", properties3.DefaultServiceVersion);

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties3.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties3.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            _blobService = await _blobService.GetAsync();

            BlobServiceData properties4 = _blobService.Data;
            Assert.IsTrue(properties4.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(300, properties4.DeleteRetentionPolicy.Days);
            Assert.AreEqual("2017-04-17", properties4.DefaultServiceVersion);

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties4.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties4.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }

        [Test]
        [RecordedTest]
        public async Task BlobContainerSoftDelete()
        {
            //update storage account to v2
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                Kind = Kind.StorageV2
            };
            await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            BlobServiceData properties = _blobService.Data;

            //enable container softdelete
            properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.ContainerDeleteRetentionPolicy.Enabled = true;
            properties.ContainerDeleteRetentionPolicy.Days = 30;
            _blobService = (await _blobService.CreateOrUpdateAsync(properties)).Value;

            //create two blob containers and delete 1
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainer container1 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName1, new BlobContainerData())).Value;
            BlobContainer container2 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName2, new BlobContainerData())).Value;
            await container2.DeleteAsync();

            //list delete included
            List<BlobContainer> blobContainers = await _blobContainerCollection.GetAllAsync(include: ListContainersInclude.Deleted).ToEnumerableAsync();
            Assert.AreEqual(2, blobContainers.Count);
            foreach (BlobContainer con in blobContainers)
            {
                if (con.Data.Name == containerName1)
                {
                    Assert.IsFalse(con.Data.Deleted);
                }
                else
                {
                    Assert.IsTrue(con.Data.Deleted);
                    Assert.NotNull(con.Data.RemainingRetentionDays);
                }
            }
            //list without delete included
            blobContainers = await _blobContainerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, blobContainers.Count);

            //disable container softdelete
            properties = _blobService.Data;
            properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.DeleteRetentionPolicy.Enabled = false;
            _blobService = (await _blobService.CreateOrUpdateAsync(properties)).Value;
            properties = _blobService.Data;
            Assert.IsFalse(properties.ContainerDeleteRetentionPolicy.Enabled);
        }

        [Test]
        [RecordedTest]
        [Ignore("can pass locally, cost too much time on pipeline")]
        public async Task PITR()
        {
            //update storage account to v2
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                Kind = Kind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();

            BlobServiceData properties = _blobService.Data;
            properties.DeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.DeleteRetentionPolicy.Enabled = true;
            properties.DeleteRetentionPolicy.Days = 30;
            properties.ChangeFeed = new ChangeFeed();
            properties.ChangeFeed.Enabled = true;
            properties.IsVersioningEnabled = true;
            properties.RestorePolicy = new RestorePolicyProperties(true) { Days = 5 };

            _blobService = (await _blobService.CreateOrUpdateAsync(properties)).Value;

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(10000);
            }

            //create restore ranges
            List<Models.BlobRestoreRange> ranges = new List<Models.BlobRestoreRange>();
            ranges.Add(new Models.BlobRestoreRange("", "container1/blob1"));
            ranges.Add(new Models.BlobRestoreRange("container1/blob2", "container2/blob3"));
            ranges.Add(new Models.BlobRestoreRange("container3/blob3", ""));

            //start restore
            Models.BlobRestoreParameters parameters = new Models.BlobRestoreParameters(Recording.Now.AddSeconds(-1).ToUniversalTime(), ranges);
            StorageAccountRestoreBlobRangesOperation restoreOperation = _storageAccount.RestoreBlobRanges(parameters);

            //wait for restore completion
            Models.BlobRestoreStatus restoreStatus = await restoreOperation.WaitForCompletionAsync();

            Assert.IsTrue(restoreStatus.Status == BlobRestoreProgressStatus.Complete || restoreStatus.Status == BlobRestoreProgressStatus.InProgress);
        }

        [Test]
        [RecordedTest]
        [Ignore("account protected from deletion")]
        public async Task BlobContainersVLW()
        {
            //update storage account to v2
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                Kind = Kind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();

            //enable blob versioning
            BlobServiceData properties = _blobService.Data;
            properties.IsVersioningEnabled = true;
            _blobService = (await _blobService.CreateOrUpdateAsync(properties)).Value;
            Assert.IsTrue(properties.IsVersioningEnabled);

            //create container with VLW
            string containerName1 = Recording.GenerateAssetName("testblob1");
            BlobContainerData parameters1 = new BlobContainerData() { ImmutableStorageWithVersioning = new ImmutableStorageWithVersioning() { Enabled = true } };
            BlobContainer container1 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName1, parameters1)).Value;
            Assert.IsTrue(container1.Data.ImmutableStorageWithVersioning.Enabled);
            Assert.IsNull(container1.Data.ImmutableStorageWithVersioning.MigrationState);

            //update container to enabled  Immutability Policy
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainerData parameters2 = new BlobContainerData();
            BlobContainer container2 = (await _blobContainerCollection.CreateOrUpdateAsync(containerName2, parameters2)).Value;
            await container2.GetImmutabilityPolicy().CreateOrUpdateAsync(parameters: new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 1 });

            await container2.ObjectLevelWormAsync();
            container2 = await container2.GetAsync();
            Assert.IsTrue(container2.Data.ImmutableStorageWithVersioning.Enabled);
            Assert.AreEqual("Completed", container2.Data.ImmutableStorageWithVersioning.MigrationState);
        }
    }
}
