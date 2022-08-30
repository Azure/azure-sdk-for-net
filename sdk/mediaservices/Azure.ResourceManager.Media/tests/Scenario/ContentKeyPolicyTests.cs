// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class ContentKeyPolicyTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private ContentKeyPolicyCollection contentKeyPolicyCollection => _mediaService.GetContentKeyPolicies();

        public ContentKeyPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            _mediaServiceIdentifier = mediaService.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
        }

        private async Task<ContentKeyPolicyResource> CreateDefaultContentKey(string contentKeyPolicyName)
        {
            ContentKeyPolicyPreference empty_AES_Clear_Key = new ContentKeyPolicyPreference(new ContentKeyPolicyClearKeyConfiguration(), new ContentKeyPolicyOpenRestriction());
            ContentKeyPolicyData data = new ContentKeyPolicyData();
            data.Preferences.Add(empty_AES_Clear_Key);
            var contentKey = await contentKeyPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, contentKeyPolicyName, data);
            return contentKey.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string contentKeyPolicyName = SessionRecording.GenerateAssetName("contentKeyPolicy");
            var contentKey = await CreateDefaultContentKey(contentKeyPolicyName);
            Assert.IsNotNull(contentKey);
            Assert.AreEqual(contentKeyPolicyName, contentKey.Data.Name);
            Assert.AreEqual(1, contentKey.Data.Preferences.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string contentKeyPolicyName = SessionRecording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string contentKeyPolicyName = SessionRecording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var contentKey = await contentKeyPolicyCollection.GetAsync(contentKeyPolicyName);
            Assert.IsNotNull(contentKey);
            Assert.AreEqual(contentKeyPolicyName, contentKey.Value.Data.Name);
            Assert.AreEqual(1, contentKey.Value.Data.Preferences.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string contentKeyPolicyName = SessionRecording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var list = await contentKeyPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string contentKeyPolicyName = SessionRecording.GenerateAssetName("contentKeyPolicy");
            var contentKey = await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsTrue(flag);

            await contentKey.DeleteAsync(WaitUntil.Completed);
            flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsFalse(flag);
        }
    }
}
