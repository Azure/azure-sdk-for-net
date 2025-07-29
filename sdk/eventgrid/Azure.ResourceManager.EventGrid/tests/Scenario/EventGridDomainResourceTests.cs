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

        private const string TagKeyTest = "testKey";
        private const string TagValueTest = "testValue";
        private const string TagKeyEnvironment = "environment";
        private const string TagValueEnvironment = "production";
        private const string TagKeyOwner = "owner";
        private const string TagValueOwner = "sdk-team";
        private const string TagKeyToRemove = "toremove";
        private const string TagValueToRemove = "value";

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            DomainCollection = ResourceGroup.GetEventGridDomains();
        }

        [Test]
        public async Task DomainCRUDTagsAndKeysOperations()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-domain-");

            var domainData = new EventGridDomainData(DefaultLocation);

            // Create
            var createResponse = await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domainData);
            var domainResource = createResponse.Value;
            Assert.NotNull(domainResource);
            Assert.NotNull(domainResource.Data);
            Assert.AreEqual(DefaultLocation.Name, domainResource.Data.Location.Name);
            Assert.IsFalse(string.IsNullOrWhiteSpace(domainName));
            Assert.IsTrue(domainName.StartsWith("sdk-domain-"));

            // Get
            var getResponse = await domainResource.GetAsync();
            Assert.NotNull(getResponse);
            Assert.NotNull(getResponse.Value);
            Assert.NotNull(getResponse.Value.Data);
            Assert.NotNull(getResponse.Value.Data.Id);
            Assert.AreEqual(domainName, getResponse.Value.Data.Name);

            // Add Tag
            var addTagResponse = await domainResource.AddTagAsync(TagKeyTest, TagValueTest);
            Assert.NotNull(addTagResponse);
            Assert.NotNull(addTagResponse.Value);
            Assert.NotNull(addTagResponse.Value.Data);
            Assert.NotNull(addTagResponse.Value.Data.Tags);
            Assert.IsTrue(addTagResponse.Value.Data.Tags.ContainsKey(TagKeyTest));
            Assert.AreEqual(TagValueTest, addTagResponse.Value.Data.Tags[TagKeyTest]);

            // Set Tags
            var domainTags = new Dictionary<string, string>
            {
                { TagKeyEnvironment, TagValueEnvironment },
                { TagKeyOwner, TagValueOwner }
            };
            var setTagsResponse = await domainResource.SetTagsAsync(domainTags);
            Assert.AreEqual(2, setTagsResponse.Value.Data.Tags.Count);
            Assert.AreEqual(TagValueEnvironment, setTagsResponse.Value.Data.Tags[TagKeyEnvironment]);
            Assert.AreEqual(TagValueOwner, setTagsResponse.Value.Data.Tags[TagKeyOwner]);

            // Remove Tag
            await domainResource.AddTagAsync(TagKeyToRemove, TagValueToRemove);
            var removeTagResponse = await domainResource.RemoveTagAsync(TagKeyToRemove);
            Assert.NotNull(removeTagResponse);
            Assert.NotNull(removeTagResponse.Value);
            Assert.IsFalse(removeTagResponse.Value.Data.Tags.ContainsKey(TagKeyToRemove));

            // Shared Access Keys
            var keys = await domainResource.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys.Value.Key1);
            Assert.IsNotNull(keys.Value.Key2);
            Assert.AreNotEqual(keys.Value.Key1, keys.Value.Key2);

            // Regenerate Key
            var regen = new EventGridDomainRegenerateKeyContent("key1");
            var newKeys = await domainResource.RegenerateKeyAsync(regen);
            // TODO: Uncomment when the bug is fixed in the service
            // Assert.AreNotEqual(keys.Value.Key1, newKeys.Value.Key1);

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
            Assert.NotNull(topic.Value);
            Assert.NotNull(topic.Value.Data);
            Assert.AreEqual(topicName, topic.Value.Data.Name);

            var getTopic = await domainResource.GetDomainTopicAsync(topicName);
            Assert.NotNull(getTopic);
            Assert.NotNull(getTopic.Value);
            Assert.NotNull(getTopic.Value.Data);
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

            // All the following calls are expected to throw RequestFailedException
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetDomainEventSubscriptionAsync("notexistingsub");
            });

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetDomainNetworkSecurityPerimeterConfigurationAsync("perimeterGuid", "association");
            });

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await domainResource.GetEventGridDomainPrivateEndpointConnectionAsync("pec1");
            });

            var pecCollection = domainResource.GetEventGridDomainPrivateEndpointConnections();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecCollection.GetAsync("pec1");
            });

            var pecData = new EventGridPrivateEndpointConnectionData();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecCollection.CreateOrUpdateAsync(WaitUntil.Completed, "pec1", pecData);
            });

            var pecId = EventGridDomainPrivateEndpointConnectionResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "pec1");
            var pecResource = new EventGridDomainPrivateEndpointConnectionResource(Client, pecId);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecResource.GetAsync();
            });

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await pecResource.UpdateAsync(WaitUntil.Completed, pecData);
            });

            var nspCollection = domainResource.GetDomainNetworkSecurityPerimeterConfigurations();
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await nspCollection.GetAsync("perimeterGuid", "association");
            });

            var nspResourceId = DomainNetworkSecurityPerimeterConfigurationResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "perimeterGuid", "association");
            var nspResource = new DomainNetworkSecurityPerimeterConfigurationResource(Client, nspResourceId);
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await nspResource.GetAsync();
            });

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
