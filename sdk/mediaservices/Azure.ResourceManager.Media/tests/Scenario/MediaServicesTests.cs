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
        private MediaServicesAccountCollection mediaServiceCollection => ResourceGroup.GetMediaServicesAccounts();

        public MediaServicesTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task MediaServicesBasicTests()
        {
            // Create
            string mediaServiceName = Recording.GenerateAssetName("mediabasictest");
            var mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
            Assert.That(mediaService, Is.Not.Null);
            Assert.That(mediaService.Data.Name, Is.EqualTo(mediaServiceName));
            Assert.That(mediaService.Data.StorageAccounts.FirstOrDefault().Id, Is.EqualTo(GetStorageAccountId()));
            // Check exists
            bool flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.That(flag, Is.True);
            // Get
            var result = await mediaServiceCollection.GetAsync(mediaServiceName);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Data.Name, Is.EqualTo(mediaServiceName));
            // Get all
            var list = await mediaServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await mediaService.DeleteAsync(WaitUntil.Completed);
            flag = await mediaServiceCollection.ExistsAsync(mediaServiceName);
            Assert.That(flag, Is.False);
        }
    }
}
