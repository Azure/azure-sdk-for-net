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
            Assert.That(contentKey, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(contentKey.Data.Name, Is.EqualTo(contentKeyPolicyName));
                Assert.That(contentKey.Data.Options, Has.Count.EqualTo(1));
            });
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.That(flag, Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var contentKey = await contentKeyPolicyCollection.GetAsync(contentKeyPolicyName);
            Assert.That(contentKey, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(contentKey.Value.Data.Name, Is.EqualTo(contentKeyPolicyName));
                Assert.That(contentKey.Value.Data.Options, Has.Count.EqualTo(1));
            });
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            await CreateDefaultContentKey(contentKeyPolicyName);
            var list = await contentKeyPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string contentKeyPolicyName = Recording.GenerateAssetName("contentKeyPolicy");
            var contentKey = await CreateDefaultContentKey(contentKeyPolicyName);
            bool flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.That(flag, Is.True);

            await contentKey.DeleteAsync(WaitUntil.Completed);
            flag = await contentKeyPolicyCollection.ExistsAsync(contentKeyPolicyName);
            Assert.That(flag, Is.False);
        }
    }
}
