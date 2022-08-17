// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaManagementTestBase : ManagementRecordedTestBase<MediaManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "MediaServiceRG";
        protected const string StorageAccountNamePrefix = "azstorageformedia";

        protected MediaManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MediaManagementTestBase(bool isAsync)
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

        protected async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource resourceGroup, string storageAccountName)
        {
            StorageAccountCreateOrUpdateContent storagedata = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, resourceGroup.Data.Location)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, storagedata);
            return storage.Value;
        }

        protected async Task<VirtualNetworkResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            VirtualNetworkData data = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
            };
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }

        protected async Task<MediaServiceResource> CreateMediaService(ResourceGroupResource resourceGroup, string mediaServiceName, ResourceIdentifier storageAccountIdentifier)
        {
            MediaServiceData data = new MediaServiceData(resourceGroup.Data.Location);
            data.StorageAccounts.Add(new MediaServiceStorageAccount(MediaServiceStorageAccountType.Primary) { Id = storageAccountIdentifier });
            var mediaService = await resourceGroup.GetMediaServices().CreateOrUpdateAsync(WaitUntil.Completed, mediaServiceName, data);
            return mediaService.Value;
        }

        protected async Task<MediaTransformResource> CreateMediaTransfer(MediaTransformCollection mediaTransformCollection, string mediaTransformName)
        {
            MediaTransformData data = new MediaTransformData();
            data.Outputs.Add(new MediaTransformOutput(new AudioAnalyzerPreset()));
            var mediaTransfer = await mediaTransformCollection.CreateOrUpdateAsync(WaitUntil.Completed, mediaTransformName, data);
            return mediaTransfer.Value;
        }
    }
}
