// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        private MediaServicesAccountResource _mediaService;

        private ContentKeyPolicyCollection contentKeyPolicyCollection => _mediaService.GetContentKeyPolicies();

        public ContentKeyPolicyTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName(MediaServiceAccountPrefix);
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        private async Task<ContentKeyPolicyResource> CreateDefaultContentKey(string contentKeyPolicyName)
        {
            ContentKeyPolicyOption empty_AES_Clear_Key = new ContentKeyPolicyOption(new ContentKeyPolicyClearKeyConfiguration(), new ContentKeyPolicyOpenRestriction());
            ContentKeyPolicyData data = new ContentKeyPolicyData();
            data.Options.Add(empty_AES_Clear_Key);
            var contentKey = await contentKeyPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, contentKeyPolicyName, data);
            return contentKey.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            var contentKey = await CreateDefaultContentKey(contentKeyPolicyName);
            Assert.IsNotNull(contentKey);
            Assert.AreEqual(contentKeyPolicyName, contentKey.Data.Name);
            Assert.AreEqual(1, contentKey.Data.Options.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var contentKey = await contentKeyPolicyCollection.GetAsync(contentKeyPolicyName);
            Assert.IsNotNull(contentKey);
            Assert.AreEqual(contentKeyPolicyName, contentKey.Value.Data.Name);
            Assert.AreEqual(1, contentKey.Value.Data.Options.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var list = await contentKeyPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            var contentKey = await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsTrue(flag);

            await contentKey.DeleteAsync(WaitUntil.Completed);
            flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.IsFalse(flag);
        }
    }
}
