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
            Assert.That(domainResource, Is.Not.Null);
            Assert.That(domainResource.Data, Is.Not.Null);
            Assert.That(domainResource.Data.Location.Name, Is.EqualTo(DefaultLocation.Name));
            Assert.That(string.IsNullOrWhiteSpace(domainName), Is.False);
            Assert.That(domainName, Does.StartWith("sdk-domain-"));

            // Get
            var getResponse = await domainResource.GetAsync();
            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Value, Is.Not.Null);
            Assert.That(getResponse.Value.Data, Is.Not.Null);
            Assert.That(getResponse.Value.Data.Id, Is.Not.Null);
            Assert.That(getResponse.Value.Data.Name, Is.EqualTo(domainName));

            // Add Tag
            var addTagResponse = await domainResource.AddTagAsync(TagKeyTest, TagValueTest);
            Assert.That(addTagResponse, Is.Not.Null);
            Assert.That(addTagResponse.Value, Is.Not.Null);
            Assert.That(addTagResponse.Value.Data, Is.Not.Null);
            Assert.That(addTagResponse.Value.Data.Tags, Is.Not.Null);
            Assert.That(addTagResponse.Value.Data.Tags.ContainsKey(TagKeyTest), Is.True);
            Assert.That(addTagResponse.Value.Data.Tags[TagKeyTest], Is.EqualTo(TagValueTest));

            // Set Tags
            var domainTags = new Dictionary<string, string>
            {
                { TagKeyEnvironment, TagValueEnvironment },
                { TagKeyOwner, TagValueOwner }
            };
            var setTagsResponse = await domainResource.SetTagsAsync(domainTags);
            Assert.That(setTagsResponse.Value.Data.Tags.Count, Is.EqualTo(2));
            Assert.That(setTagsResponse.Value.Data.Tags[TagKeyEnvironment], Is.EqualTo(TagValueEnvironment));
            Assert.That(setTagsResponse.Value.Data.Tags[TagKeyOwner], Is.EqualTo(TagValueOwner));

            // Remove Tag
            await domainResource.AddTagAsync(TagKeyToRemove, TagValueToRemove);
            var removeTagResponse = await domainResource.RemoveTagAsync(TagKeyToRemove);
            Assert.That(removeTagResponse, Is.Not.Null);
            Assert.That(removeTagResponse.Value, Is.Not.Null);
            Assert.That(removeTagResponse.Value.Data.Tags.ContainsKey(TagKeyToRemove), Is.False);

            // Shared Access Keys
            var keys = await domainResource.GetSharedAccessKeysAsync();
            Assert.That(keys.Value.Key1, Is.Not.Null);
            Assert.That(keys.Value.Key2, Is.Not.Null);
            Assert.That(keys.Value.Key2, Is.Not.EqualTo(keys.Value.Key1));

            // Regenerate Key
            var regen = new EventGridDomainRegenerateKeyContent("key1");
            var newKeys = await domainResource.RegenerateKeyAsync(regen);
            // TODO: Uncomment when the bug is fixed in the service
            // Assert.AreNotEqual(keys.Value.Key1, newKeys.Value.Key1);

            // Delete
            await domainResource.DeleteAsync(WaitUntil.Completed);
            var exists = await DomainCollection.ExistsAsync(domainName);
            Assert.That(exists.Value, Is.False);
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
            Assert.That(domainResource, Is.Not.Null);
            Assert.That(domainResource.Data.Location.Name, Is.EqualTo(DefaultLocation.Name));

            // Domain Topic
            var topicCollection = domainResource.GetDomainTopics();
            var topic = await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName);
            Assert.That(topic, Is.Not.Null);
            Assert.That(topic.Value, Is.Not.Null);
            Assert.That(topic.Value.Data, Is.Not.Null);
            Assert.That(topic.Value.Data.Name, Is.EqualTo(topicName));

            var getTopic = await domainResource.GetDomainTopicAsync(topicName);
            Assert.That(getTopic, Is.Not.Null);
            Assert.That(getTopic.Value, Is.Not.Null);
            Assert.That(getTopic.Value.Data, Is.Not.Null);
            Assert.That(getTopic.Value.Data.Name, Is.EqualTo(topicName));

            await topic.Value.DeleteAsync(WaitUntil.Completed);
            var exists = await topicCollection.ExistsAsync(topicName);
            Assert.That(exists.Value, Is.False);

            // Private Endpoint Connections
            var pecCollection = domainResource.GetEventGridDomainPrivateEndpointConnections();
            var allPecs = await pecCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allPecs, Is.Not.Null);
            Assert.That(allPecs is IEnumerable<EventGridDomainPrivateEndpointConnectionResource>, Is.True);

            // Domain Network Security Perimeter Configurations
            var nspCollection = domainResource.GetDomainNetworkSecurityPerimeterConfigurations();
            var nspConfigs = await nspCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(nspConfigs, Is.Not.Null);

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
            Assert.That(domainResource, Is.Not.Null);

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
            Assert.That(domainResource, Is.Not.Null);

            var pecId = EventGridDomainPrivateEndpointConnectionResource.CreateResourceIdentifier(
                DefaultSubscription.Data.SubscriptionId, ResourceGroup.Data.Name, domainName, "pec1");
            var pecResource = new EventGridDomainPrivateEndpointConnectionResource(Client, pecId);

            var result = await pecResource.DeleteAsync(WaitUntil.Completed);
            Assert.That(result.HasCompleted, Is.True);

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
