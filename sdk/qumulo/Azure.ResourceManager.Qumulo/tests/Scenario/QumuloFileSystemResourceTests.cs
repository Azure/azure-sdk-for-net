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

            Assert.That(fileResourceIdentifier.ResourceType.Equals(QumuloFileSystemResource.ResourceType), Is.True);
            Assert.That(fileResourceIdentifier.Equals($"{ResGroup.Id}/providers/{QumuloFileSystemResource.ResourceType}/{fileResourceName}"), Is.True);
            Assert.Throws<ArgumentException>(() => QumuloFileSystemResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Data()
        {
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);

            Assert.That(fileSystemResource.HasData, Is.True);
            Assert.NotNull(fileSystemResource.Data);
            Assert.That(fileSystemResource.Data.Name.Equals(fileResourceName), Is.True);
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task Delete()
        {
            QumuloFileSystemResourceCollection collection = ResGroup.GetQumuloFileSystemResources();
            string fileResourceName = Recording.GenerateAssetName("testResource-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);
            await fileSystemResource.DeleteAsync(WaitUntil.Completed);

            Assert.That((bool)await collection.ExistsAsync(fileResourceName), Is.False);
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

            Assert.That(fileSystemResource2.Data.Tags["Counter"], Is.EqualTo("1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.UpdateAsync( null)).Value);
        }

        [RecordedTest]
        [Ignore("The tests aren't recordable and will need to be fixed in the future.")]
        public async Task AddTag()
        {
            string fileResourceName = Recording.GenerateAssetName("testDeployment-");
            QumuloFileSystemResource fileSystemResource = await CreateQumuloFileSystemResource(ResGroup, Location, fileResourceName);
            QumuloFileSystemResource fileSystemResource2 = await fileSystemResource.AddTagAsync("Counter", "1");

            Assert.That(fileSystemResource2.Data.Tags["Counter"], Is.EqualTo("1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.AddTagAsync(null, "1")).Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await fileSystemResource.AddTagAsync("Counter", null)).Value);
        }

        private void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            Assert.That(r2.Location, Is.EqualTo(r1.Location));
            Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
        }
    }
}
