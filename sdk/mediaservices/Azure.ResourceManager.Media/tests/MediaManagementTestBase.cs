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
        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected ResourceIdentifier GetStorageAccountId() => _storageAccountIdentifier;
        protected string MediaServiceAccountPrefix = "mediadotnetsdktests";

        private const string ResourceGroupNamePrefix = "MediaServiceRG";
        private const string StorageAccountNamePrefix = "azstorageformedia";
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;

        protected MediaManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..accessToken");
        }

        protected MediaManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..accessToken");
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient(enableDeleteAfter: true);
            ResourceGroup = Client.GetResourceGroupResource(_resourceGroupIdentifier);
        }

        [OneTimeSetUp]
        public async Task CommonGlobalSetup()
        {
            var rgName = SessionRecording.GenerateAssetName(ResourceGroupNamePrefix);
            var storageAccountName = SessionRecording.GenerateAssetName(StorageAccountNamePrefix);
            if (Mode == RecordedTestMode.Playback)
            {
                _resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName);
                _storageAccountIdentifier = StorageAccountResource.CreateResourceIdentifier(SessionRecording.GetVariable("SUBSCRIPTION_ID", null), rgName, storageAccountName);
            }
            else
            {
                using (SessionRecording.DisableRecording())
                {
                    var subscription = await GlobalClient.GetDefaultSubscriptionAsync();
                    var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _storageAccountIdentifier = storage.Id;
                }
            }
            await StopSessionRecordingAsync();
        }

        private async Task<StorageAccountResource> CreateStorageAccount(ResourceGroupResource rg, string storageAccountName)
        {
            StorageAccountCreateOrUpdateContent input = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, AzureLocation.WestUS2)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            var lro = await rg.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, input);
            return lro.Value;
        }

        protected async Task<MediaServicesAccountResource> CreateMediaService(ResourceGroupResource rg, string mediaServiceName)
        {
            MediaServicesAccountData input = new MediaServicesAccountData(AzureLocation.WestUS2);
            input.StorageAccounts.Add(new MediaServicesStorageAccount(MediaServicesStorageAccountType.Primary) { Id = _storageAccountIdentifier });
            var lro = await rg.GetMediaServicesAccounts().CreateOrUpdateAsync(WaitUntil.Completed, mediaServiceName, input);
            return lro.Value;
        }

        protected async Task<MediaTransformResource> CreateMediaTransfer(MediaServicesAccountResource mediaService, string mediaTransformName)
        {
            MediaTransformData input = new MediaTransformData();
            input.Outputs.Add(new MediaTransformOutput(new AudioAnalyzerPreset()));
            var lro = await mediaService.GetMediaTransforms().CreateOrUpdateAsync(WaitUntil.Completed, mediaTransformName, input);
            return lro.Value;
        }

        protected async Task<MediaLiveEventResource> CreateLiveEvent(MediaServicesAccountResource mediaService, string liveEventName)
        {
            MediaLiveEventData input = new MediaLiveEventData(mediaService.Data.Location)
            {
                Input = new LiveEventInput(LiveEventInputProtocol.Rtmp),
                CrossSiteAccessPolicies = new CrossSiteAccessPolicies(),
            };
            var lro = await mediaService.GetMediaLiveEvents().CreateOrUpdateAsync(WaitUntil.Completed, liveEventName, input);
            return lro.Value;
        }

        protected async Task<MediaAssetResource> CreateMediaAsset(MediaServicesAccountResource mediaService, string mediaAssetName)
        {
            var lro = await mediaService.GetMediaAssets().CreateOrUpdateAsync(WaitUntil.Completed, mediaAssetName, new MediaAssetData());
            return lro.Value;
        }
    }
}
