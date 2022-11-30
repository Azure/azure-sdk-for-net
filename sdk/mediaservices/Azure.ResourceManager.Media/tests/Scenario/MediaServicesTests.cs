// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaServicesTests : MediaManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        private MediaServicesAccountCollection mediaServiceCollection => _resourceGroup.GetMediaServicesAccounts();

        public MediaServicesTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
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
                    var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, rgName, new ResourceGroupData(AzureLocation.WestUS2));
                    var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
                    _resourceGroupIdentifier = rgLro.Value.Data.Id;
                    _storageAccountIdentifier = storage.Id;
                }
            };
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task MediaServicesBasicTests()
        {
            // Create
            string mediaServiceName = Recording.GenerateAssetName("mediabasic");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            Assert.IsNotNull(mediaService);
            Assert.AreEqual(mediaServiceName, mediaService.Data.Name);
            Assert.AreEqual(_storageAccountIdentifier, mediaService.Data.StorageAccounts.FirstOrDefault().Id);
            // Check exists
            bool flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.IsTrue(flag);
            // Get
            var result = await mediaServiceCollection.GetAsync(mediaServiceName);
            Assert.IsNotNull(result);
            Assert.AreEqual(mediaServiceName, result.Value.Data.Name);
            // Get all
            var list = await mediaServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await mediaService.DeleteAsync(WaitUntil.Completed);
            flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.IsFalse(flag);
        }
    }
}
