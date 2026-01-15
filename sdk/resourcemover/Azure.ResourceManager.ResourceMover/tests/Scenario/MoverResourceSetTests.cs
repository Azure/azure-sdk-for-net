// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.ResourceMover;
using Azure.ResourceManager.ResourceMover.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.ResourceManager.ResourceMover.Tests
{
    internal class MoverResourceSetTests : ResourceMoverManagementTestBase
    {
        protected internal const string ExpectedKey = "tagKey";
        protected internal const string ExpectedValue = "tagValue";

        public MoverResourceSetTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);
            Assert.That(moverResourceSet.Data.Name, Is.EqualTo(moverResourceSetName));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            _ = await CreateMoverResourceSet(rg, moverResourceSetName);
            int count = 0;
            await foreach (var tempMoverResourceSet in rg.GetMoverResourceSets().GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);
            MoverResourceSetResource getMoverResourceSet = await rg.GetMoverResourceSets().GetAsync(moverResourceSetName);
            AssertValidMoverResourceSet(moverResourceSet, getMoverResourceSet);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);
            await moverResourceSet.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await moverResourceSet.GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);
            MoverResourceSetPatch updateOptions = new MoverResourceSetPatch
            {
                Tags = { { "newKey", "newVal" } },
                Identity = moverResourceSet.Data.Identity
            };
            MoverResourceSetResource updatedMoverResourceSet = await moverResourceSet.UpdateAsync(updateOptions);
            Assert.That(updatedMoverResourceSet.Data.Tags, Is.EqualTo(updateOptions.Tags));
            Assert.That(updatedMoverResourceSet.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(updateOptions.Identity.ManagedServiceIdentityType));
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateResourceMove()
        {
            // Get an existing moverResourceSet and please clean up the set if it already contains some resources.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            MoverResourceSetResource moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            // Add a Vnet to the moverResourceSet.
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string vnetName = Recording.GenerateAssetName("Vnet-");
            string moverResourceName = Recording.GenerateAssetName("MoverResource-");
            string targetVnetName = Recording.GenerateAssetName("targetVnet-");
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            MoverResource moverResource = await CreateMoverResource(moverResourceSet, virtualNetwork.Id, moverResourceName, targetVnetName);

            // Validate that the Vnet has an dependency.
            ArmOperation<MoverOperationStatus> lro = await moverResourceSet.ResolveDependenciesAsync(WaitUntil.Completed);

            // Retrieve a list of the dependencies and validate that there is only one unresolved dependency about the source resource group.
            int count = 0;
            ResourceIdentifier unresolvedDependencyId = null;
            await foreach (var dependency in moverResourceSet.GetUnresolvedDependenciesAsync())
            {
                ++count;
                unresolvedDependencyId = dependency.Id;
            };
            Assert.That(count, Is.EqualTo(0));

            // Prepare, initiate, discard and commit the move for the Vnet.
            IEnumerable<ResourceIdentifier> moverVnet = new List<ResourceIdentifier> { virtualNetwork.Id };
            MoverPrepareContent prepareContent = new MoverPrepareContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.PrepareAsync(WaitUntil.Completed, prepareContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);

            MoverResourceMoveContent initiateContent = new MoverResourceMoveContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.InitiateMoveAsync(WaitUntil.Completed, initiateContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);

            MoverDiscardContent discardContent = new MoverDiscardContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.DiscardAsync(WaitUntil.Completed, discardContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);

            initiateContent = new MoverResourceMoveContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.InitiateMoveAsync(WaitUntil.Completed, initiateContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);

            MoverCommitContent commitContent = new MoverCommitContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.CommitAsync(WaitUntil.Completed, commitContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);

            // Bulk remove
            MoverBulkRemoveContent bulkRemoveContent = new MoverBulkRemoveContent()
            {
                MoverResources = { virtualNetwork.Id },
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.BulkRemoveAsync(WaitUntil.Completed, bulkRemoveContent);
            Assert.That(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase), Is.True);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTagTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            var moverResourceSet = await AddTag();

            Assert.That(moverResourceSet.Data.Tags.TryGetValue(ExpectedKey, out string value), Is.True);
            Assert.That(value, Is.EqualTo(ExpectedValue));
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task SetTagsTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            var moverResourceSet = await AddTag();

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                { "tagKey1", "tagKey1" },
                { "tagKey2", "tagKey2" },
                { "tagKey3", "tagKey3" }
            };

            moverResourceSet = await moverResourceSet.SetTagsAsync(expectedTags);

            Assert.That(moverResourceSet.Data.Tags.Count, Is.EqualTo(expectedTags.Count));

            foreach (var item in expectedTags)
            {
                Assert.That(moverResourceSet.Data.Tags.TryGetValue(item.Key, out string value), Is.True);
                Assert.That(value, Is.EqualTo(item.Value));
            }
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task RemoveTagTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            var moverResourceSet = await AddTag();

            moverResourceSet = await moverResourceSet.RemoveTagAsync(ExpectedKey);

            Assert.That(moverResourceSet.Data.Tags.Count, Is.EqualTo(0));
        }

        private async Task<MoverResourceSetResource> AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
            string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
            MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);

            moverResourceSet = await moverResourceSet.AddTagAsync(ExpectedKey, ExpectedValue);
            return moverResourceSet;
        }

        private void AssertValidMoverResourceSet(MoverResourceSetResource model, MoverResourceSetResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.ETag, Is.EqualTo(model.Data.ETag));
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.That(getResult.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(model.Data.Identity.ManagedServiceIdentityType));
            }
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.That(getResult.Data.Properties.SourceLocation, Is.EqualTo(model.Data.Properties.SourceLocation));
                Assert.That(getResult.Data.Properties.TargetLocation, Is.EqualTo(model.Data.Properties.TargetLocation));
            }
        }
    }
}
