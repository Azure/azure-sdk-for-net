// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
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

        protected async Task<MediaServiceResource> CreateMediaService(ResourceGroupResource resourceGroup, string mediaServiceName, ResourceIdentifier storageAccountIdentifier)
        {
            MediaServiceData data = new MediaServiceData(resourceGroup.Data.Location);
            data.StorageAccounts.Add(new MediaServiceStorageAccount(MediaServiceStorageAccountType.Primary) { Id = storageAccountIdentifier });
            var mediaService = await resourceGroup.GetMediaServices().CreateOrUpdateAsync(WaitUntil.Completed, mediaServiceName, data);
            return mediaService.Value;
        }
    }
}
