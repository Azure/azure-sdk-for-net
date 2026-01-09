// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridTopicTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventGridTopicCollection _eventGridTopicCollection;

        public EventGridTopicTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private const string EnvTag = "env";
        private const string OwnerTag = "owner";
        private const string TestTag = "test";
        private const string SdkTestTag = "sdk-test";
        private const string StickerTagKey = "stickerKey";
        private const string StickerTagValue = "stickerValue";
        private const string RemoveStickerTagKey = "removeSticker";
        public const string RemoveStickerTagValue = "removeMe";
        public const string TeamTagKey = "team";
        public const string TeamTagValue = "sdk";

        [SetUp]
        public async Task TestSetUp()
        {
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            _resourceGroup = await CreateResourceGroupAsync(location);
            _eventGridTopicCollection = _resourceGroup.GetEventGridTopics();
        }

        private void ValidateEventGridTopic(EventGridTopicResource topic, string expectedName)
        {
            Assert.That(topic, Is.Not.Null);
            Assert.That(topic.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(topic.Data.Id, Is.Not.Null);
                Assert.That(topic.Data.Name, Is.EqualTo(expectedName));
                Assert.That(topic.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/topics"));
                Assert.That(topic.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
                Assert.That(topic.Data.Location, Is.EqualTo(_resourceGroup.Data.Location));
            });
        }

        [Test]
        public async Task TopicLifecycleCreateGetUpdateDelete()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            ValidateEventGridTopic(topic, topicName);

            // Get
            var getTopic = await _eventGridTopicCollection.GetAsync(topicName);
            ValidateEventGridTopic(getTopic, topicName);

            // Update
            var patch = new EventGridTopicPatch
            {
                Tags = { { EnvTag, TestTag }, { OwnerTag, SdkTestTag } }
            };
            await topic.UpdateAsync(WaitUntil.Completed, patch);
            var updatedTopic = await _eventGridTopicCollection.GetAsync(topicName);
            Assert.That(updatedTopic.Value.Data.Tags.ContainsKey(EnvTag), Is.True);

            // AddTag
            var addTagResult = await topic.AddTagAsync(StickerTagKey, StickerTagValue);
            Assert.That(addTagResult, Is.Not.Null);
            Assert.That(addTagResult.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(addTagResult.Value.Data.Tags.ContainsKey(StickerTagKey), Is.True);
                Assert.That(addTagResult.Value.Data.Tags[StickerTagKey], Is.EqualTo(StickerTagValue));
            });

            // SetTags
            var tags = new Dictionary<string, string> { { EnvTag, TestTag }, { TeamTagKey, TeamTagValue }, { StickerTagKey, StickerTagValue } };
            var setTagsResult = await topic.SetTagsAsync(tags);
            Assert.That(setTagsResult, Is.Not.Null);
            Assert.That(setTagsResult.Value, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(setTagsResult.Value.Data.Tags.ContainsKey(StickerTagKey), Is.True);
                Assert.That(setTagsResult.Value.Data.Tags[StickerTagKey], Is.EqualTo(StickerTagValue));
            });

            // RemoveTag
            await topic.AddTagAsync(RemoveStickerTagKey, RemoveStickerTagValue);
            var removeTagResult = await topic.RemoveTagAsync(RemoveStickerTagKey);
            Assert.That(removeTagResult, Is.Not.Null);
            Assert.That(removeTagResult.Value, Is.Not.Null);
            Assert.That(removeTagResult.Value.Data.Tags.ContainsKey(RemoveStickerTagKey), Is.False);

            // Exists
            bool exists = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.That(exists, Is.True);

            // GetAll
            var topicsInResourceGroup = await _eventGridTopicCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(topicsInResourceGroup, Is.Not.Null);
            Assert.That(topicsInResourceGroup.Any(t => t.Data.Name == topicName), Is.True);
            var topicsInSubscription = await DefaultSubscription.GetEventGridTopicsAsync().ToEnumerableAsync();
            Assert.That(topicsInSubscription, Is.Not.Null);
            Assert.That(topicsInSubscription.Any(t => t.Data.Name == topicName), Is.True);

            // ListSharedAccessKeys
            var keys = await topic.GetSharedAccessKeysAsync();
            Assert.That(keys, Is.Not.Null);

            // RegenerateSharedAccessKey
            var key = await topic.RegenerateKeyAsync(WaitUntil.Completed, new TopicRegenerateKeyContent("key1"));
            Assert.That(key, Is.Not.Null);

            // GetAsync
            var getAsyncResult = await topic.GetAsync();
            Assert.That(getAsyncResult, Is.Not.Null);
            Assert.That(getAsyncResult.Value.Data.Name, Is.EqualTo(topic.Data.Name));

            // Delete
            await topic.DeleteAsync(WaitUntil.Completed);
            bool existsAfterDelete = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.That(existsAfterDelete, Is.False);
        }

        [Test]
        public async Task TopicNegativeScenarios()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await topic.GetTopicEventSubscriptionAsync("nonexistent-subscription");
            });

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await topic.GetTopicNetworkSecurityPerimeterConfigurationAsync("perimeter-guid", "association");
            });

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await topic.GetEventGridTopicPrivateEndpointConnectionAsync("pec-name");
            });

            await topic.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task PrivateLinkResourcesGetAndList()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            ValidateEventGridTopic(topic, topicName);
            // get private link resources
            var linkResource = await topic.GetEventGridTopicPrivateLinkResourceAsync("topic");
            Assert.That(linkResource, Is.Not.Null);
            // list all private link resources
            System.Collections.Generic.List<EventGridTopicPrivateLinkResource> list = await topic.GetEventGridTopicPrivateLinkResources().ToEnumerableAsync();
            Assert.That(list, Is.Not.Null);

            await topic.DeleteAsync(WaitUntil.Completed);
        }
    }
}
