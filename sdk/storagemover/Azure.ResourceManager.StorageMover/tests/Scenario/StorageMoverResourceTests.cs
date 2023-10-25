// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.StorageMover.Models;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class StorageMoverResourceTests : StorageMoverManagementTestBase
    {
        public StorageMoverResourceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverResource storageMover2 = (await storageMover1.GetAsync()).Value;
            Assert.AreEqual(storageMover1.Id.Name, storageMover2.Id.Name);
            Assert.AreEqual(storageMover1.Id.Location, storageMover2.Id.Location);
            Assert.AreEqual(storageMover1.Id.ResourceType, storageMover2.Id.ResourceType);
            Assert.AreEqual(storageMover1.Data.Id, storageMover2.Data.Id);
            Assert.AreEqual(storageMover1.Data.Name, storageMover2.Data.Name);
            Assert.AreEqual(storageMover1.Data.Location, storageMover2.Data.Location);
            Assert.AreEqual(storageMover1.Data.Tags, storageMover2.Data.Tags);
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverAgentTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverAgentResource agent = (await storageMover1.GetStorageMoverAgentAsync(AgentName)).Value;
            Assert.AreEqual(AgentName, agent.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverEndpointTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverEndpointResource endpoint = (await storageMover1.GetStorageMoverEndpointAsync(ContainerEndpointName)).Value;
            Assert.AreEqual(ContainerEndpointName, endpoint.Data.Name);
            Assert.AreEqual(null, endpoint.Data.Properties.Description);
            Assert.AreEqual("AzureStorageBlobContainer", endpoint.Data.Properties.EndpointType.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverProjectTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover1.GetStorageMoverProjectAsync(ProjectName)).Value;
            Assert.AreEqual(ProjectName, project.Id.Name);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAddSetRemoveTagDeletTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();

            string storageMoverName = Recording.GenerateAssetName(StorageMoverPrefix);
            StorageMoverData data = new StorageMoverData(TestLocation);
            StorageMoverResource storageMover1 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, data)).Value;
            Assert.AreEqual(storageMoverName, storageMover1.Id.Name);
            Assert.AreEqual(TestLocation, storageMover1.Data.Location);

            StorageMoverPatch patch = new()
            {
                Description = "This is an updated storage mover"
            };
            storageMover1 = (await storageMover1.UpdateAsync(patch)).Value;
            Assert.AreEqual(storageMoverName, storageMover1.Id.Name);
            Assert.AreEqual(TestLocation, storageMover1.Data.Location);
            Assert.AreEqual("This is an updated storage mover", storageMover1.Data.Description);

            storageMover1 = (await storageMover1.AddTagAsync("tag1", "val1")).Value;
            Assert.AreEqual(1, storageMover1.Data.Tags.Count);
            Assert.AreEqual("val1", storageMover1.Data.Tags["tag1"]);
            Dictionary<string, string> tags = new()
            {
                { "tag2", "val2" },
                { "tag3", "val3" }
            };
            storageMover1 = (await storageMover1.SetTagsAsync(tags)).Value;
            Assert.AreEqual(2, storageMover1.Data.Tags.Count);

            storageMover1 = (await storageMover1.RemoveTagAsync("tag2")).Value;
            Assert.AreEqual(1, storageMover1.Data.Tags.Count);

            await storageMover1.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await storageMovers.ExistsAsync(storageMoverName));
        }
    }
}
