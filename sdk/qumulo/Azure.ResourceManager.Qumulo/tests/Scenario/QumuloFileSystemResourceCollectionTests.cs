// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Qumulo.Tests
{
    internal class QumuloFileSystemResourceCollectionTests : QumuloManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public QumuloFileSystemResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public QumuloFileSystemResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
                ResGroup = await CreateResourceGroup(subscription, ResourceGroupPrefix, Location);
            }
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task CreateOrUpdate()
        {
            string resourceName = Recording.GenerateAssetName("testResource-");
            var qumuloResource = await CreateQumuloFileSystemResource(ResGroup, Location, resourceName);
            Assert.IsTrue(resourceName.Equals(qumuloResource.Data.Name));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await ResGroup.GetQumuloFileSystemResources().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, null)).Value);
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Get()
        {
            QumuloFileSystemResourceCollection collection = ResGroup.GetQumuloFileSystemResources();
            string qumuloFileSystemName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource qumuloFileSystem1 = await CreateQumuloFileSystemResource(ResGroup, Location, qumuloFileSystemName);
            QumuloFileSystemResource qumuloFileSystem2 = await collection.GetAsync(qumuloFileSystemName);

            AssertTrackedResource(qumuloFileSystem1.Data, qumuloFileSystem2.Data);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(qumuloFileSystemName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetAsync(null));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Exists()
        {
            QumuloFileSystemResourceCollection collection = ResGroup.GetQumuloFileSystemResources();
            string qumuloFileSystemName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource qumuloFileSystem = await CreateQumuloFileSystemResource(ResGroup, Location, qumuloFileSystemName);

            Assert.IsTrue(await collection.ExistsAsync(qumuloFileSystemName));
            Assert.IsFalse(await collection.ExistsAsync(qumuloFileSystemName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task GetAll()
        {
            QumuloFileSystemResourceCollection collection = ResGroup.GetQumuloFileSystemResources();

            int count = 0;
            await foreach (QumuloFileSystemResource fileSystemResource in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 0);

            string qumuloFileSystemName1 = Recording.GenerateAssetName("testResource-");
            string qumuloFileSystemName2 = Recording.GenerateAssetName("testResource-");
            _ = await CreateQumuloFileSystemResource(ResGroup, Location, qumuloFileSystemName1);
            _ = await CreateQumuloFileSystemResource(ResGroup, Location, qumuloFileSystemName2);

            await foreach (QumuloFileSystemResource fileSystemResource in collection.GetAllAsync())
            {
                count++;
            }

            Assert.GreaterOrEqual(count, 2);
        }

        private void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }
    }
}
