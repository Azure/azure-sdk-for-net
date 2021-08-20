// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;

namespace Azure.ResourceManager.Storage.Tests.Helpers
{
    [ClientTestFixture]
    public class StorageTestBase:ManagementRecordedTestBase<StorageManagementTestEnvironment>
    {
        public static Location DefaultLocation => Location.EastUS2;
        public static string DefaultLocationString= "eastus2";
        public static bool IsTestTenant = false;
        // These are used to create default accounts
        public static Sku DefaultSkuNameStandardGRS = new Sku(SkuName.StandardGRS);
        public static Kind DefaultKindStorage = Kind.Storage;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };
        protected ArmClient Client { get; private set; }
        protected Subscription DefaultSubscription => Client.DefaultSubscription;
        protected StorageTestBase(bool isAsync) : base(isAsync)
        {
        }
        public StorageTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
        public static StorageAccountCreateParameters GetDefaultStorageAccountParameters(Sku sku = null, Kind? kind = null, string location = null)
        {
            Sku skuParameters = sku ?? DefaultSkuNameStandardGRS;
            Kind kindParameters = kind ?? DefaultKindStorage;
            string locationParameters = location ?? DefaultLocationString;
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(skuParameters, kindParameters, locationParameters);
            parameters.Tags.InitializeFrom(DefaultTags);
            return parameters;
        }
        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        public async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            string resourceGroupName = Recording.GenerateAssetName("teststorageRG-");
            return await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
        }
        public static void VerifyAccountProperties(StorageAccount account,bool useDefaults)
        {
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Id.Name);
            Assert.NotNull(account.Data.Location);
            Assert.NotNull(account.Data);
            Assert.NotNull(account.Data.CreationTime);
            Assert.NotNull(account.Data.Sku);
            Assert.NotNull(account.Data.Sku.Name);
            Assert.NotNull(account.Data.Sku.Tier);
            Assert.NotNull(account.Data.PrimaryEndpoints);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, account.Data.Location);
                Assert.AreEqual(DefaultSkuNameStandardGRS.Name, account.Data.Sku.Name);
                Assert.AreEqual(SkuTier.Standard, account.Data.Sku.Tier);
                Assert.AreEqual(DefaultKindStorage, account.Data.Kind);

                Assert.NotNull(account.Data.Tags);
                Assert.AreEqual(2, account.Data.Tags.Count);
                Assert.AreEqual("value1", account.Data.Tags["key1"]);
                Assert.AreEqual("value2", account.Data.Tags["key2"]);
            }
        }

        public static void AssertStorageAccountEqual(StorageAccount account1, StorageAccount account2)
        {
            Assert.AreEqual(account1.Id.Name, account2.Id.Name);
            Assert.AreEqual(account1.Id.Location, account2.Id.Location);
        }
        public static void AssertBlobContainerEqual(BlobContainer blobContainer1, BlobContainer blobContainer2)
        {
            Assert.AreEqual(blobContainer1.Id.Name, blobContainer2.Id.Name);
            Assert.AreEqual(blobContainer1.Id.Location, blobContainer2.Id.Location);
        }
        public static void AssertFileShareEqual(FileShare fileShare1, FileShare fileShare2)
        {
            Assert.AreEqual(fileShare1.Id.Name, fileShare2.Id.Name);
            Assert.AreEqual(fileShare1.Id.Location, fileShare2.Id.Location);
        }
        public static void AssertStorageQueueEqual(StorageQueue storageQueue1, StorageQueue storageQueue2)
        {
            Assert.AreEqual(storageQueue1.Id.Name, storageQueue2.Id.Name);
            Assert.AreEqual(storageQueue1.Id.Location, storageQueue2.Id.Location);
        }
        public static void AssertTableEqual(Table table1, Table table2)
        {
            Assert.AreEqual(table1.Id.Name, table2.Id.Name);
            Assert.AreEqual(table1.Id.Location, table2.Id.Location);
        }
    }
}
