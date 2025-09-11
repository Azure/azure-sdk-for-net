// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class PartnerNamespaceTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PartnerNamespaceCollection _partnerNamespaceCollection;

        public PartnerNamespaceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            _resourceGroup = await CreateResourceGroupAsync(location);
            _partnerNamespaceCollection = _resourceGroup.GetPartnerNamespaces();
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            ValidatePartnerNamespace(partnerNamespace, partnerNamespaceName);
        }

        [Test]
        public async Task Exist()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            bool flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            var partnerNamespace = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            ValidatePartnerNamespace(partnerNamespace, partnerNamespaceName);
        }

        [Test]
        public async Task GetAll()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            // Get all partner namespaces created within a resourceGroup
            var list = await _partnerNamespaceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePartnerNamespace(list.First(item => item.Data.Name == partnerNamespaceName), partnerNamespaceName);
            Assert.NotNull(list);
            Assert.GreaterOrEqual(list.Count, 1);
            Assert.AreEqual(list.FirstOrDefault().Data.Name, partnerNamespaceName);
            // Get all partner namespaces created within the subscription irrespective of the resourceGroup
            var namespacesInAzureSubscription = await DefaultSubscription.GetPartnerNamespacesAsync().ToEnumerableAsync();
            Assert.NotNull(namespacesInAzureSubscription);
            Assert.GreaterOrEqual(namespacesInAzureSubscription.Count, 1);
        }

        [Test]
        public async Task Update()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var topic = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            var patch = new PartnerNamespacePatch
            {
                Tags = { { "env", "test" }, { "owner", "sdk-test" } }
            };
            await topic.UpdateAsync(WaitUntil.Completed, patch);
            // Retrieve the updated partner namespace
            var updatedTopic = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            Assert.IsNotNull(updatedTopic.Value);
        }

        [Test]
        public async Task ListSharedAccessKeys()
        {
            string topicName = Recording.GenerateAssetName("PartnerNamespace");
            var topic = await CreatePartnerNamespace(_resourceGroup, topicName);
            var keys = await topic.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys);
        }

        [Test]
        public async Task RegenerateSharedAccessKey()
        {
            string topicName = Recording.GenerateAssetName("PartnerNamespace");
            var namespaceResource = await CreatePartnerNamespace(_resourceGroup, topicName);
            var newKey = await namespaceResource.RegenerateKeyAsync(new PartnerNamespaceRegenerateKeyContent("key1"));
            Assert.IsNotNull(newKey);
        }

        [Test]
        public async Task Delete()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            bool flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsTrue(flag);

            await partnerNamespace.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.IsFalse(flag);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);

            // AddTag
            await partnerNamespace.AddTagAsync("addtagkey", "addtagvalue");
            partnerNamespace = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            Assert.AreEqual(1, partnerNamespace.Data.Tags.Count);
            KeyValuePair<string, string> tag = partnerNamespace.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await partnerNamespace.RemoveTagAsync("addtagkey");
            partnerNamespace = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            Assert.AreEqual(0, partnerNamespace.Data.Tags.Count);
        }

        [Test]
        public async Task GetPartnerNamespacePrivateLinkResourceAsync()
        {
            // Arrange
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);

            // The private link resource name is typically "partnerNamespace"
            string privateLinkResourceName = "partnerNamespace";

            // Act
            var response = await partnerNamespace.GetPartnerNamespacePrivateLinkResourceAsync(privateLinkResourceName);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(privateLinkResourceName, response.Value.Data.Name);

            // Cleanup
            await partnerNamespace.DeleteAsync(WaitUntil.Completed);
        }

        private void ValidatePartnerNamespace(PartnerNamespaceResource partnerNamespace, string partnerNamespaceName)
        {
            Assert.IsNotNull(partnerNamespace);
            Assert.IsNotNull(partnerNamespace.Data.Id);
            Assert.AreEqual(partnerNamespaceName, partnerNamespace.Data.Name);
            Assert.IsTrue(partnerNamespace.Data.IsLocalAuthDisabled);
            Assert.AreEqual(_resourceGroup.Data.Location, partnerNamespace.Data.Location);
            Assert.AreEqual(PartnerTopicRoutingMode.ChannelNameHeader, partnerNamespace.Data.PartnerTopicRoutingMode);
            Assert.AreEqual(EventGridPublicNetworkAccess.Enabled, partnerNamespace.Data.PublicNetworkAccess);
            Assert.AreEqual("Succeeded", partnerNamespace.Data.ProvisioningState.ToString());
            Assert.AreEqual("Microsoft.EventGrid/partnerNamespaces", partnerNamespace.Data.ResourceType.ToString());
        }
    }
}
