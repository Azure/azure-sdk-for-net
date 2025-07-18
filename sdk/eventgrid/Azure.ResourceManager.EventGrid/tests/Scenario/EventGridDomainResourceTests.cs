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
        public async Task DomainLifecycleCreateGetUpdateTagDelete()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");

            var domainData = new EventGridDomainData(DefaultLocation);

            // Create
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);
            Assert.AreEqual(DefaultLocation.Name, domainResource.Data.Location.Name);
            Assert.IsFalse(string.IsNullOrWhiteSpace(domainName));
            Assert.IsTrue(domainName.StartsWith("sdk-domain-"));

            // Get
            var getResponse = await domainResource.GetAsync();
            Assert.NotNull(getResponse.Value);
            Assert.AreEqual(domainName, getResponse.Value.Data.Name);

            // Add Tag
            var addTagResponse = await domainResource.AddTagAsync("testKey", "testValue");
            Assert.NotNull(addTagResponse);
            Assert.NotNull(addTagResponse.Value);
            Assert.NotNull(addTagResponse.Value.Data);
            Assert.NotNull(addTagResponse.Value.Data.Tags);
            Assert.IsTrue(addTagResponse.Value.Data.Tags.ContainsKey("testKey"));
            Assert.AreEqual("testValue", addTagResponse.Value.Data.Tags["testKey"]);

            // Set Tags
            var domainTags = new Dictionary<string, string>
            {
                { "environment", "production" },
                { "owner", "sdk-team" }
            };
            var setTagsResponse = await domainResource.SetTagsAsync(domainTags);
            Assert.AreEqual(2, setTagsResponse.Value.Data.Tags.Count);
            Assert.AreEqual("production", setTagsResponse.Value.Data.Tags["environment"]);
            Assert.AreEqual("sdk-team", setTagsResponse.Value.Data.Tags["owner"]);

            // Remove Tag
            await domainResource.AddTagAsync("toremove", "value");
            var removeTagResponse = await domainResource.RemoveTagAsync("toremove");
            Assert.IsFalse(removeTagResponse.Value.Data.Tags.ContainsKey("toremove"));

            // Shared Access Keys
            var keys = await domainResource.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys.Value.Key1);
            Assert.IsNotNull(keys.Value.Key2);
            Assert.AreNotEqual(keys.Value.Key1, keys.Value.Key2);

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
        public async Task DomainTopicAndPrivateEndpointAndNSPCollections()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");
            var topicName = Recording.GenerateAssetName("sdk-topic-");
            var domainData = new EventGridDomainData(DefaultLocation);
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);
            Assert.AreEqual(DefaultLocation.Name, domainResource.Data.Location.Name);

            // Domain Topic
            var topicCollection = domainResource.GetDomainTopics();
            var topic = await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName);
            Assert.NotNull(topic);
            Assert.AreEqual(topicName, topic.Value.Data.Name);

            var getTopic = await domainResource.GetDomainTopicAsync(topicName);
            Assert.AreEqual(topicName, getTopic.Value.Data.Name);

            await topic.Value.DeleteAsync(WaitUntil.Completed);
            var exists = await topicCollection.ExistsAsync(topicName);
            Assert.IsFalse(exists.Value);

            // Private Endpoint Connections
            var pecCollection = domainResource.GetEventGridDomainPrivateEndpointConnections();
            var allPecs = await pecCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(allPecs);
            Assert.IsTrue(allPecs is IEnumerable<EventGridDomainPrivateEndpointConnectionResource>);

            // Domain Network Security Perimeter Configurations
            var nspCollection = domainResource.GetDomainNetworkSecurityPerimeterConfigurations();
            var nspConfigs = await nspCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(nspConfigs);

            await domainResource.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task DomainEventSubscriptionAndPrivateEndpointNegativeScenarios()
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
        public async Task EventGridDomainPrivateEndpointConnectionResourceDeleteAsync()
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

            var result = await pecResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(result.HasCompleted);

            await domainResource.DeleteAsync(WaitUntil.Completed);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode == RecordedTestMode.Playback)
                return;

            if (ResourceGroup != null)
            {
                await ResourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
