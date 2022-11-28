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

        protected DataFactoryManagementTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.keys.[*].value");
            JsonPathSanitizers.Add("$.properties.typeProperties.connectionString.value");
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

        protected async Task<DataFactoryResource> CreateDataFactory(ResourceGroupResource resourceGroup)
        {
            //data factory names are global so this might take a few tries
            DataFactoryData data = new DataFactoryData(resourceGroup.Data.Location);
            int retry = 0;
            do
            {
                try
                {
                    var dataFactory = await resourceGroup.GetDataFactories().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("DataFactory"), data);
                    return dataFactory.Value;
                }
                catch (RequestFailedException ex) when (ex.Status == 409 && ex.Message.Contains("The specified resource name"))
                {
                    retry++;
                }
            } while (retry < 10);
            throw new Exception("Tried to find a datafactory name 10 times and all of them were taken");
        }

        protected async Task<FactoryLinkedServiceResource> CreateLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey, string storageAccountName)
        {
            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = BinaryData.FromObjectAsJson(new { type = "SecureString", value = $"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={accessKey}" }),
            };
            FactoryLinkedServiceData data = new FactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<StorageAccountResource> GetStorageAccountAsync(ResourceGroupResource resourceGroup, string containerName = null)
        {
            StorageAccountCreateOrUpdateContent data = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, resourceGroup.Data.Location)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            int retry = 0;
            do
            {
                string storageAccountName = Recording.GenerateAssetName("storageaccount");
                try
                {
                    var storageAccount = (await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, data)).Value;
                    if (containerName is not null)
                        await storageAccount.GetBlobService().GetBlobContainers().CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData());

                    return storageAccount;
                }
                catch (RequestFailedException ex) when (ex.Status == 409 && ex.Message.Contains("The storage account named"))
                {
                    retry++;
                }
            } while (retry < 10);
            throw new Exception("Tried to find a storageaccount name 10 times and all of them were taken");
        }
    }
}
