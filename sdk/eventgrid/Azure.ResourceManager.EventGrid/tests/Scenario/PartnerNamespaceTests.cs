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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidatePartnerNamespace(list.First(item => item.Data.Name == partnerNamespaceName), partnerNamespaceName);
            Assert.That(list, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(list.Count, Is.GreaterThanOrEqualTo(1));
                Assert.That(partnerNamespaceName, Is.EqualTo(list.FirstOrDefault().Data.Name));
            });
            // Get all partner namespaces created within the subscription irrespective of the resourceGroup
            var namespacesInAzureSubscription = await DefaultSubscription.GetPartnerNamespacesAsync().ToEnumerableAsync();
            Assert.That(namespacesInAzureSubscription, Is.Not.Null);
            Assert.That(namespacesInAzureSubscription.Count, Is.GreaterThanOrEqualTo(1));
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
            Assert.That(updatedTopic.Value, Is.Not.Null);
        }

        [Test]
        public async Task ListSharedAccessKeys()
        {
            string topicName = Recording.GenerateAssetName("PartnerNamespace");
            var topic = await CreatePartnerNamespace(_resourceGroup, topicName);
            var keys = await topic.GetSharedAccessKeysAsync();
            Assert.That(keys, Is.Not.Null);
        }

        [Test]
        public async Task RegenerateSharedAccessKey()
        {
            string topicName = Recording.GenerateAssetName("PartnerNamespace");
            var namespaceResource = await CreatePartnerNamespace(_resourceGroup, topicName);
            var newKey = await namespaceResource.RegenerateKeyAsync(new PartnerNamespaceRegenerateKeyContent("key1"));
            Assert.That(newKey, Is.Not.Null);
        }

        [Test]
        public async Task Delete()
        {
            string partnerNamespaceName = Recording.GenerateAssetName("PartnerNamespace");
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, partnerNamespaceName);
            bool flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.That(flag, Is.True);

            await partnerNamespace.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerNamespaceCollection.ExistsAsync(partnerNamespaceName);
            Assert.That(flag, Is.False);
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
            Assert.That(partnerNamespace.Data.Tags, Has.Count.EqualTo(1));
            KeyValuePair<string, string> tag = partnerNamespace.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(tag.Key, Is.EqualTo("addtagkey"));
                Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
            });

            // RemoveTag
            await partnerNamespace.RemoveTagAsync("addtagkey");
            partnerNamespace = await _partnerNamespaceCollection.GetAsync(partnerNamespaceName);
            Assert.That(partnerNamespace.Data.Tags.Count, Is.EqualTo(0));
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
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Data.Name, Is.EqualTo(privateLinkResourceName));

            // Cleanup
            await partnerNamespace.DeleteAsync(WaitUntil.Completed);
        }

        private void ValidatePartnerNamespace(PartnerNamespaceResource partnerNamespace, string partnerNamespaceName)
        {
            Assert.That(partnerNamespace, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(partnerNamespace.Data.Id, Is.Not.Null);
                Assert.That(partnerNamespace.Data.Name, Is.EqualTo(partnerNamespaceName));
                Assert.That(partnerNamespace.Data.IsLocalAuthDisabled, Is.True);
                Assert.That(partnerNamespace.Data.Location, Is.EqualTo(_resourceGroup.Data.Location));
                Assert.That(partnerNamespace.Data.PartnerTopicRoutingMode, Is.EqualTo(PartnerTopicRoutingMode.ChannelNameHeader));
                Assert.That(partnerNamespace.Data.PublicNetworkAccess, Is.EqualTo(EventGridPublicNetworkAccess.Enabled));
                Assert.That(partnerNamespace.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
                Assert.That(partnerNamespace.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/partnerNamespaces"));
            });
        }
    }
}
