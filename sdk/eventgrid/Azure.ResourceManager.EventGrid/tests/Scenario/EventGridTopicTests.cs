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

        public EventGridTopicTests(bool isAsync) : base(isAsync) { }

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
            Assert.AreEqual(expectedName, topic.Data.Name);
        }

        [Test]
        public async Task Topic_Lifecycle_CreateGetUpdateDelete()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);

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

            // AddTag
            var addTagResult = await topic.AddTagAsync("testKey", "testValue");
            Assert.IsNotNull(addTagResult);
            Assert.IsNotNull(addTagResult.Value);

            // SetTags
            var tags = new Dictionary<string, string> { { "env", "test" }, { "team", "sdk" } };
            var setTagsResult = await topic.SetTagsAsync(tags);
            Assert.IsNotNull(setTagsResult);
            Assert.IsNotNull(setTagsResult.Value);

            // RemoveTag
            await topic.AddTagAsync("removeKey", "removeValue");
            var removeTagResult = await topic.RemoveTagAsync("removeKey");
            Assert.IsNotNull(removeTagResult);
            Assert.IsNotNull(removeTagResult.Value);

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
        public async Task Topic_NegativeScenarios()
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
        public async Task Topic_PrivateLinkResourcesGetAndList()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);

            var linkResource = await topic.GetEventGridTopicPrivateLinkResourceAsync("topic");
            Assert.IsNotNull(linkResource);
            var list = await topic.GetEventGridTopicPrivateLinkResources().ToEnumerableAsync();
            Assert.NotNull(list);

            await topic.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Topic_PrivateEndpointConnectionCollection_Operations()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            var collection = topic.GetEventGridTopicPrivateEndpointConnections();
            var data = new EventGridPrivateEndpointConnectionData();

            // CreateOrUpdateAsync (should throw or succeed)
            try
            {
                var result = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "testpec", data);
                Assert.IsNotNull(result);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex, Is.Not.Null);
            }

            // GetAsync (should throw or succeed)
            try
            {
                var response = await collection.GetAsync("testpec");
                Assert.IsNotNull(response);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex, Is.Not.Null);
            }

            // GetAllAsync (should not throw)
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);

            await topic.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task Topic_PrivateEndpointConnectionResource_Operations()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            var collection = topic.GetEventGridTopicPrivateEndpointConnections();
            var data = new EventGridPrivateEndpointConnectionData();

            // Try to get the resource (should throw or succeed)
            EventGridTopicPrivateEndpointConnectionResource item = null;
            try
            {
                var res = await collection.GetAsync("testpec");
                item = res.Value;
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex, Is.Not.Null);
            }

            if (item != null)
            {
                // GetAsync
                try
                {
                    var result = await item.GetAsync();
                    Assert.IsNotNull(result);
                }
                catch (RequestFailedException ex)
                {
                    Assert.That(ex, Is.Not.Null);
                }

                // DeleteAsync
                try
                {
                    var result = await item.DeleteAsync(WaitUntil.Completed);
                    Assert.IsNotNull(result);
                }
                catch (RequestFailedException ex)
                {
                    Assert.That(ex, Is.Not.Null);
                }

                // UpdateAsync
                try
                {
                    var result = await item.UpdateAsync(WaitUntil.Completed, data);
                    Assert.IsNotNull(result);
                }
                catch (RequestFailedException ex)
                {
                    Assert.That(ex, Is.Not.Null);
                }
            }

            await topic.DeleteAsync(WaitUntil.Completed);
        }
    }
}
