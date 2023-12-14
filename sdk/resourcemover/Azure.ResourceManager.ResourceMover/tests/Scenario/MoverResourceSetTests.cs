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
            Assert.AreEqual(moverResourceSetName, moverResourceSet.Data.Name);
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
            Assert.AreEqual(count, 1);
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

        //[TestCase]
        //[RecordedTest]
        //public async Task Delete()
        //{
        //    SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
        //    string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
        //    ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.WestUS);
        //    string moverResourceSetName = Recording.GenerateAssetName("MoverResourceSet-");
        //    MoverResourceSetResource moverResourceSet = await CreateMoverResourceSet(rg, moverResourceSetName);
        //    await moverResourceSet.DeleteAsync(WaitUntil.Completed);
        //    var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await moverResourceSet.GetAsync());
        //    Assert.AreEqual(404, ex.Status);
        //}

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
            Assert.AreEqual(updateOptions.Tags, updatedMoverResourceSet.Data.Tags);
            Assert.AreEqual(updateOptions.Identity.ManagedServiceIdentityType, updatedMoverResourceSet.Data.Identity.ManagedServiceIdentityType);
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
            Assert.AreEqual(count, 0);

            // Prepare, initiate, discard and commit the move for the Vnet.
            IEnumerable<ResourceIdentifier> moverVnet = new List<ResourceIdentifier> { virtualNetwork.Id };
            MoverPrepareContent prepareContent = new MoverPrepareContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.PrepareAsync(WaitUntil.Completed, prepareContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            MoverResourceMoveContent initiateContent = new MoverResourceMoveContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.InitiateMoveAsync(WaitUntil.Completed, initiateContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            MoverDiscardContent discardContent = new MoverDiscardContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.DiscardAsync(WaitUntil.Completed, discardContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            initiateContent = new MoverResourceMoveContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.InitiateMoveAsync(WaitUntil.Completed, initiateContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            MoverCommitContent commitContent = new MoverCommitContent(moverVnet)
            {
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.CommitAsync(WaitUntil.Completed, commitContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            // Bulk remove
            MoverBulkRemoveContent bulkRemoveContent = new MoverBulkRemoveContent()
            {
                MoverResources = { virtualNetwork.Id },
                MoverResourceInputType = MoverResourceInputType.MoverResourceSourceId
            };
            lro = await moverResourceSet.BulkRemoveAsync(WaitUntil.Completed, bulkRemoveContent);
            Assert.IsTrue(lro.Value.Status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTagTest(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);

            var moverResourceSet = await AddTag();

            Assert.IsTrue(moverResourceSet.Data.Tags.TryGetValue(ExpectedKey, out string value));
            Assert.AreEqual(ExpectedValue, value);
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

            Assert.AreEqual(expectedTags.Count, moverResourceSet.Data.Tags.Count);

            foreach (var item in expectedTags)
            {
                Assert.IsTrue(moverResourceSet.Data.Tags.TryGetValue(item.Key, out string value));
                Assert.AreEqual(item.Value, value);
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

            Assert.AreEqual(0, moverResourceSet.Data.Tags.Count);
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
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ETag, getResult.Data.ETag);
            if (model.Data.Identity != null || getResult.Data.Identity != null)
            {
                Assert.NotNull(model.Data.Identity);
                Assert.NotNull(getResult.Data.Identity);
                Assert.AreEqual(model.Data.Identity.ManagedServiceIdentityType, getResult.Data.Identity.ManagedServiceIdentityType);
            }
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.SourceLocation, getResult.Data.Properties.SourceLocation);
                Assert.AreEqual(model.Data.Properties.TargetLocation, getResult.Data.Properties.TargetLocation);
            }
        }
    }
}
