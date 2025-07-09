// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridDomainResourceTests : EventGridManagementTestBase
    {
        public EventGridDomainResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        private EventGridDomainCollection DomainCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            DomainCollection = ResourceGroup.GetEventGridDomains();
        }

        [Test]
        public async Task Domain_Lifecycle_CreateGetUpdateTagDelete()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");
            var domainData = new EventGridDomainData(DefaultLocation);

            // Create
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);

            // Get
            var getResponse = await domainResource.GetAsync();
            Assert.NotNull(getResponse.Value);

            // Add Tag
            var addTagResponse = await domainResource.AddTagAsync("testKey", "testValue");
            Assert.IsTrue(addTagResponse.Value.Data.Tags.ContainsKey("testKey"));

            // Set Tags
            var tags = new Dictionary<string, string> { { "k", "v" }, { "k2", "v2" } };
            var setTagsResponse = await domainResource.SetTagsAsync(tags);
            Assert.IsTrue(setTagsResponse.Value.Data.Tags.ContainsKey("k"));
            Assert.IsTrue(setTagsResponse.Value.Data.Tags.ContainsKey("k2"));

            // Remove Tag
            await domainResource.AddTagAsync("toremove", "value");
            var removeTagResponse = await domainResource.RemoveTagAsync("toremove");
            Assert.IsFalse(removeTagResponse.Value.Data.Tags.ContainsKey("toremove"));

            // Shared Access Keys
            var keys = await domainResource.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys.Value.Key1);
            Assert.IsNotNull(keys.Value.Key2);

            // Regenerate Key
            var regen = new EventGridDomainRegenerateKeyContent("key1");
            var newKeys = await domainResource.RegenerateKeyAsync(regen);
            Assert.AreNotEqual(keys.Value.Key1, newKeys.Value.Key1);

            // Delete
            await domainResource.DeleteAsync(WaitUntil.Completed);
            var exists = await DomainCollection.ExistsAsync(domainName);
            Assert.IsFalse(exists.Value);
        }

        [Test]
        public async Task Domain_Topic_And_PrivateEndpoint_And_NSP_Collections()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");
            var topicName = Recording.GenerateAssetName("sdk-topic-");
            var domainData = new EventGridDomainData(DefaultLocation);
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);

            // Domain Topic
            var topicCollection = domainResource.GetDomainTopics();
            var topic = await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName);
            var getTopic = await domainResource.GetDomainTopicAsync(topicName);
            Assert.AreEqual(topicName, getTopic.Value.Data.Name);
            await topic.Value.DeleteAsync(WaitUntil.Completed);

            // Private Endpoint Connections
            var pecCollection = domainResource.GetEventGridDomainPrivateEndpointConnections();
            var allPecs = await pecCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allPecs);

            // Domain Network Security Perimeter Configurations
            var nspCollection = domainResource.GetDomainNetworkSecurityPerimeterConfigurations();
            var nspConfigs = await nspCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(nspConfigs);

            await domainResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Domain_NegativeScenarios()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");
            var domainData = new EventGridDomainData(DefaultLocation);
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);

            // GetDomainEventSubscriptionAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetDomainEventSubscriptionAsync("notexistingsub");
            });

            // GetDomainNetworkSecurityPerimeterConfigurationAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetDomainNetworkSecurityPerimeterConfigurationAsync("perimeterGuid", "association");
            });

            // GetEventGridDomainPrivateEndpointConnectionAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetEventGridDomainPrivateEndpointConnectionAsync("pec1");
            });

            // PrivateEndpointConnectionCollection GetAsync (should throw)
            var pecCollection = domainResource.GetEventGridDomainPrivateEndpointConnections();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecCollection.GetAsync("pec1");
            });

            // PrivateEndpointConnectionCollection CreateOrUpdateAsync (should throw)
            var pecData = new EventGridPrivateEndpointConnectionData();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecCollection.CreateOrUpdateAsync(WaitUntil.Completed, "pec1", pecData);
            });

            // PrivateEndpointConnectionResource GetAsync (should throw)
            var pecId = EventGridDomainPrivateEndpointConnectionResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "pec1");
            var pecResource = new EventGridDomainPrivateEndpointConnectionResource(Client, pecId);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecResource.GetAsync();
            });

            // PrivateEndpointConnectionResource UpdateAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecResource.UpdateAsync(WaitUntil.Completed, pecData);
            });

            // DomainNetworkSecurityPerimeterConfigurationCollection GetAsync (should throw)
            var nspCollection = domainResource.GetDomainNetworkSecurityPerimeterConfigurations();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await nspCollection.GetAsync("perimeterGuid", "association");
            });

            // DomainNetworkSecurityPerimeterConfigurationResource GetAsync (should throw)
            var nspResourceId = DomainNetworkSecurityPerimeterConfigurationResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "perimeterGuid", "association");
            var nspResource = new DomainNetworkSecurityPerimeterConfigurationResource(Client, nspResourceId);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await nspResource.GetAsync();
            });

            // DomainNetworkSecurityPerimeterConfigurationResource ReconcileAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await nspResource.ReconcileAsync(WaitUntil.Completed);
            });

            await domainResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task EventGridDomainPrivateEndpointConnectionResource_DeleteAsync_Works()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");
            var domainData = new EventGridDomainData(DefaultLocation);
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);

            var pecId = EventGridDomainPrivateEndpointConnectionResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "pec1");
            var pecResource = new EventGridDomainPrivateEndpointConnectionResource(Client, pecId);

            // Just call delete and assert it completes (no exception expected)
            var result = await pecResource.DeleteAsync(WaitUntil.Completed);
            Assert.NotNull(result);

            await domainResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
