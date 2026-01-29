// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Qumulo.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Qumulo.Tests
{
    public class QumuloFileSystemResourceTests : QumuloManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public QumuloFileSystemResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public QumuloFileSystemResourceTests(bool isAsync) : base(isAsync)
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
        public void CreateResourceIdentifier()
        {
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            ResourceIdentifier fileResourceIdentifier = QumuloFileSystemResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, fileResourceName);
            QumuloFileSystemResource.ValidateResourceId(fileResourceIdentifier);

            Assert.IsTrue(fileResourceIdentifier.ResourceType.Equals(QumuloFileSystemResource.ResourceType));
            Assert.IsTrue(fileResourceIdentifier.Equals($"{ResGroup.Id}/providers/{QumuloFileSystemResource.ResourceType}/{fileResourceName}"));
            Assert.Throws<ArgumentException>(() => QumuloFileSystemResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Data()
        {
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);

            Assert.IsTrue(fileSystemResource.HasData);
            Assert.NotNull(fileSystemResource.Data);
            Assert.IsTrue(fileSystemResource.Data.Name.Equals(fileResourceName));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Delete()
        {
            QumuloFileSystemResourceCollection collection = ResGroup.GetQumuloFileSystemResources();
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);
            await fileSystemResource.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await collection.ExistsAsync(fileResourceName));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Update()
        {
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);

            QumuloFileSystemResourcePatch fileSystemResourcePatch = new QumuloFileSystemResourcePatch();
            fileSystemResourcePatch.Tags.Add("Counter", "1");
            QumuloFileSystemResource fileSystemResource2 = (await fileSystemResource.UpdateAsync(fileSystemResourcePatch)).Value;

            Assert.AreEqual(fileSystemResource2.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.UpdateAsync( null)).Value);
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task AddTag()
        {
            string fileResourceName = Recording.GenerateAssetName("testDeployment-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);
            QumuloFileSystemResource fileSystemResource2 = await fileSystemResource.AddTagAsync("Counter", "1");

            Assert.AreEqual(fileSystemResource2.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.AddTagAsync(null, "1")).Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.AddTagAsync("Counter", null)).Value);
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
