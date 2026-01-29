// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

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
            Assert.That(storageMover2.Id.Name, Is.EqualTo(storageMover1.Id.Name));
            Assert.That(storageMover2.Id.Location, Is.EqualTo(storageMover1.Id.Location));
            Assert.That(storageMover2.Id.ResourceType, Is.EqualTo(storageMover1.Id.ResourceType));
            Assert.That(storageMover2.Data.Id, Is.EqualTo(storageMover1.Data.Id));
            Assert.That(storageMover2.Data.Name, Is.EqualTo(storageMover1.Data.Name));
            Assert.That(storageMover2.Data.Location, Is.EqualTo(storageMover1.Data.Location));
            Assert.That(storageMover2.Data.Tags, Is.EqualTo(storageMover1.Data.Tags));
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverAgentTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverAgentResource agent = (await storageMover1.GetStorageMoverAgentAsync(AgentName)).Value;
            Assert.That(agent.Data.Name, Is.EqualTo(AgentName));
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverEndpointTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverEndpointResource endpoint = (await storageMover1.GetStorageMoverEndpointAsync(ContainerEndpointName)).Value;
            Assert.That(endpoint.Data.Name, Is.EqualTo(ContainerEndpointName));
            Assert.That(endpoint.Data.Properties.Description, Is.EqualTo(null));
            Assert.That(endpoint.Data.Properties.EndpointType.ToString(), Is.EqualTo("AzureStorageBlobContainer"));
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageMoverProjectTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();
            StorageMoverResource storageMover1 = (await storageMovers.GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover1.GetStorageMoverProjectAsync(ProjectName)).Value;
            Assert.That(project.Id.Name, Is.EqualTo(ProjectName));
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAddSetRemoveTagDeletTest()
        {
            StorageMoverCollection storageMovers = (await GetResourceGroupAsync(ResourceGroupName)).GetStorageMovers();

            string storageMoverName = Recording.GenerateAssetName(StorageMoverPrefix);
            StorageMoverData data = new StorageMoverData(TestLocation);
            StorageMoverResource storageMover1 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, data)).Value;
            Assert.That(storageMover1.Id.Name, Is.EqualTo(storageMoverName));
            Assert.That(storageMover1.Data.Location, Is.EqualTo(TestLocation));

            StorageMoverPatch patch = new()
            {
                Description = "This is an updated storage mover"
            };
            storageMover1 = (await storageMover1.UpdateAsync(patch)).Value;
            Assert.That(storageMover1.Id.Name, Is.EqualTo(storageMoverName));
            Assert.That(storageMover1.Data.Location, Is.EqualTo(TestLocation));
            Assert.That(storageMover1.Data.Description, Is.EqualTo("This is an updated storage mover"));

            storageMover1 = (await storageMover1.AddTagAsync("tag1", "val1")).Value;
            Assert.That(storageMover1.Data.Tags.Count, Is.EqualTo(1));
            Assert.That(storageMover1.Data.Tags["tag1"], Is.EqualTo("val1"));
            Dictionary<string, string> tags = new()
            {
                { "tag2", "val2" },
                { "tag3", "val3" }
            };
            storageMover1 = (await storageMover1.SetTagsAsync(tags)).Value;
            Assert.That(storageMover1.Data.Tags.Count, Is.EqualTo(2));

            storageMover1 = (await storageMover1.RemoveTagAsync("tag2")).Value;
            Assert.That(storageMover1.Data.Tags.Count, Is.EqualTo(1));

            await storageMover1.DeleteAsync(WaitUntil.Completed);
            Assert.That((bool)await storageMovers.ExistsAsync(storageMoverName), Is.False);
        }
    }
}
