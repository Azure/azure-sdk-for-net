// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DataFactory.Tests
{
    public class DataFactoryManagementTestBase : ManagementRecordedTestBase<DataFactoryManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DataFactoryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.keys.[*].value");
        }

        protected DataFactoryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DataFactoryResource> CreateDataFactory(ResourceGroupResource resourceGroup, string dataFactoryName)
        {
            DataFactoryData data = new DataFactoryData(resourceGroup.Data.Location);
            var dataFactory = await resourceGroup.GetDataFactories().CreateOrUpdateAsync(WaitUntil.Completed, dataFactoryName, data);
            return dataFactory.Value;
        }

        protected async Task<DataFactoryLinkedServiceResource> CreateLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey)
        {
            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = BinaryData.FromString($"\"{accessKey}\""),
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<string> GetStorageAccountAccessKey(ResourceGroupResource resourceGroup)
        {
            string storageAccountName = Recording.GenerateAssetName($"{DateTime.Now.ToString("yyMMdd")}datafactory");
            StorageAccountCreateOrUpdateContent data = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, resourceGroup.Data.Location)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, data);
            var key = await storage.Value.GetKeysAsync().FirstOrDefaultAsync(_ => true);
            return key.Value;
        }
    }
}
