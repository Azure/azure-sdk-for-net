// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

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
            JsonPathSanitizers.Add("$.keys.[*].value");
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
            DataFactoryData data = new DataFactoryData(AzureLocation.WestUS2);
            var dataFactory = await resourceGroup.GetDataFactories().CreateOrUpdateAsync(WaitUntil.Completed, dataFactoryName, data);
            return dataFactory.Value;
        }

        protected async Task<FactoryLinkedServiceResource> CreateLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey)
        {
            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = BinaryData.FromString($"\"{accessKey}\""),
            };
            FactoryLinkedServiceData data = new FactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<string> GetStorageAccountAccessKey(ResourceGroupResource resourceGroup, string storageAccountName)
        {
            StorageAccountCreateOrUpdateContent data = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, AzureLocation.WestUS2)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, data);
            var key = await storage.Value.GetKeysAsync().FirstOrDefaultAsync(_ => true);
            return key.Value;
        }
    }
}
