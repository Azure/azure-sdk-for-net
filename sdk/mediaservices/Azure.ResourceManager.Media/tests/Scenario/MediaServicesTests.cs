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
            Assert.IsNotNull(mediaService);
            Assert.AreEqual(mediaServiceName, mediaService.Data.Name);
            Assert.AreEqual(GetStorageAccountId(), mediaService.Data.StorageAccounts.FirstOrDefault().Id);
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
