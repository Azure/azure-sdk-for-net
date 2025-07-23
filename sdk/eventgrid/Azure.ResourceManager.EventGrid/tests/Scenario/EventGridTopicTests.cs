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

        [SetUp]
        public async Task TestSetUp()
        {
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            _resourceGroup = await CreateResourceGroupAsync(location);
            _eventGridTopicCollection = _resourceGroup.GetEventGridTopics();
        }

        private void ValidateEventGridTopic(EventGridTopicResource topic, string expectedName)
        {
            Assert.IsNotNull(topic);
            Assert.IsNotNull(topic.Data);
            Assert.IsNotNull(topic.Data.Id);
            Assert.AreEqual(expectedName, topic.Data.Name);
            Assert.AreEqual("Microsoft.EventGrid/topics", topic.Data.ResourceType.ToString());
            Assert.AreEqual("Succeeded", topic.Data.ProvisioningState.ToString());
            Assert.AreEqual(_resourceGroup.Data.Location, topic.Data.Location);
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
                Tags = { { "env", "test" }, { "owner", "sdk-test" } }
            };
            await topic.UpdateAsync(WaitUntil.Completed, patch);
            var updatedTopic = await _eventGridTopicCollection.GetAsync(topicName);
            Assert.IsTrue(updatedTopic.Value.Data.Tags.ContainsKey("env"));

            // AddTag
            var addTagResult = await topic.AddTagAsync("stickerKey", "stickerValue");
            Assert.IsNotNull(addTagResult);
            Assert.IsNotNull(addTagResult.Value);
            Assert.IsTrue(addTagResult.Value.Data.Tags.ContainsKey("stickerKey"));
            Assert.AreEqual("stickerValue", addTagResult.Value.Data.Tags["stickerKey"]);

            // SetTags
            var tags = new Dictionary<string, string> { { "env", "test" }, { "team", "sdk" }, { "stickerKey", "stickerValue" } };
            var setTagsResult = await topic.SetTagsAsync(tags);
            Assert.IsNotNull(setTagsResult);
            Assert.IsNotNull(setTagsResult.Value);
            Assert.IsTrue(setTagsResult.Value.Data.Tags.ContainsKey("stickerKey"));
            Assert.AreEqual("stickerValue", setTagsResult.Value.Data.Tags["stickerKey"]);

            // RemoveTag
            await topic.AddTagAsync("removeSticker", "removeMe");
            var removeTagResult = await topic.RemoveTagAsync("removeSticker");
            Assert.IsNotNull(removeTagResult);
            Assert.IsNotNull(removeTagResult.Value);
            Assert.IsFalse(removeTagResult.Value.Data.Tags.ContainsKey("removeSticker"));

            // Exists
            bool exists = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsTrue(exists);

            // GetAll
            var topicsInResourceGroup = await _eventGridTopicCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(topicsInResourceGroup);
            Assert.IsTrue(topicsInResourceGroup.Any(t => t.Data.Name == topicName));
            var topicsInSubscription = await DefaultSubscription.GetEventGridTopicsAsync().ToEnumerableAsync();
            Assert.NotNull(topicsInSubscription);
            Assert.IsTrue(topicsInSubscription.Any(t => t.Data.Name == topicName));

            // ListSharedAccessKeys
            var keys = await topic.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys);

            // RegenerateSharedAccessKey
            var key = await topic.RegenerateKeyAsync(WaitUntil.Completed, new TopicRegenerateKeyContent("key1"));
            Assert.IsNotNull(key);

            // GetAsync
            var getAsyncResult = await topic.GetAsync();
            Assert.IsNotNull(getAsyncResult);
            Assert.AreEqual(topic.Data.Name, getAsyncResult.Value.Data.Name);

            // Delete
            await topic.DeleteAsync(WaitUntil.Completed);
            bool existsAfterDelete = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsFalse(existsAfterDelete);
        }

        [Test]
        public async Task TopicNegativeScenarios()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);

            // GetTopicEventSubscriptionAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await topic.GetTopicEventSubscriptionAsync("nonexistent-subscription");
            });

            // GetTopicNetworkSecurityPerimeterConfigurationAsync (should throw)
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await topic.GetTopicNetworkSecurityPerimeterConfigurationAsync("perimeter-guid", "association");
            });

            // GetEventGridTopicPrivateEndpointConnectionAsync (should throw)
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
            Assert.IsNotNull(linkResource);
            // list all private link resources
            System.Collections.Generic.List<EventGridTopicPrivateLinkResource> list = await topic.GetEventGridTopicPrivateLinkResources().ToEnumerableAsync();
            Assert.NotNull(list);

            await topic.DeleteAsync(WaitUntil.Completed);
        }
    }
}
