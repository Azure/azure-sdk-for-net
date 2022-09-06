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
        protected const string ResourceGroupNamePrefix = "MediaServiceRG";
        protected const string StorageAccountNamePrefix = "azstorageformedia";

        protected MediaManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.properties.input.accessToken");
            JsonPathSanitizers.Add("$.value.[*].properties.input.accessToken");
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

        protected async Task<ResourceGroupResource> CreateResourceGroup(AzureLocation location)
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
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

        protected async Task<MediaServicesAccountResource> CreateMediaService(ResourceGroupResource resourceGroup, string mediaServiceName, ResourceIdentifier storageAccountIdentifier)
        {
            MediaServicesAccountData data = new MediaServicesAccountData(resourceGroup.Data.Location);
            data.StorageAccounts.Add(new MediaServicesStorageAccount(MediaServicesStorageAccountType.Primary) { Id = storageAccountIdentifier });
            var mediaService = await resourceGroup.GetMediaServicesAccounts().CreateOrUpdateAsync(WaitUntil.Completed, mediaServiceName, data);
            return mediaService.Value;
        }

        protected async Task<MediaTransformResource> CreateMediaTransfer(MediaTransformCollection mediaTransformCollection, string mediaTransformName)
        {
            MediaTransformData data = new MediaTransformData();
            data.Outputs.Add(new MediaTransformOutput(new AudioAnalyzerPreset()));
            var mediaTransfer = await mediaTransformCollection.CreateOrUpdateAsync(WaitUntil.Completed, mediaTransformName, data);
            return mediaTransfer.Value;
        }

        protected async Task<LiveEventResource> CreateLiveEvent(MediaServicesAccountResource mediaService, string liveEventName)
        {
            LiveEventData data = new LiveEventData(mediaService.Data.Location)
            {
                Input = new LiveEventInput(LiveEventInputProtocol.Rtmp),
                CrossSiteAccessPolicies = new CrossSiteAccessPolicies(),
            };
            var liveEvent = await mediaService.GetLiveEvents().CreateOrUpdateAsync(WaitUntil.Completed, liveEventName, data);
            return liveEvent.Value;
        }
    }
}
