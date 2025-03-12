// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
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

        [Test]
        public async Task CreateOrUpdate()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            ValidateEventGridTopic(topic, topicName);
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
        }

        [Test]
        public async Task Exists()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            bool exists = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task Get()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            var topic = await _eventGridTopicCollection.GetAsync(topicName);
            ValidateEventGridTopic(topic, topicName);
        }

        [Test]
        public async Task GetAll()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            var topicsInResourceGroup = await _eventGridTopicCollection.GetAllAsync().ToEnumerableAsync();
            // Get all topics created within a resourceGroup
            Assert.NotNull(topicsInResourceGroup);
            Assert.GreaterOrEqual(topicsInResourceGroup.Count, 1);
            Assert.AreEqual(topicsInResourceGroup.FirstOrDefault().Data.Name, topicName);
            // Get all topics created within the subscription irrespective of the resourceGroup
            var topicsInAzureSubscription = await DefaultSubscription.GetEventGridTopicsAsync().ToEnumerableAsync();
            Assert.NotNull(topicsInAzureSubscription);
            Assert.GreaterOrEqual(topicsInAzureSubscription.Count, 1);
            var falseFlag = false;
            foreach (var item in topicsInAzureSubscription)
            {
                if (item.Data.Name == topicName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.IsTrue(falseFlag);
        }

        [Test]
        public async Task Delete()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            await topic.DeleteAsync(WaitUntil.Completed);
            bool exists = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Update()
        {
            // Arrange
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            var patch = new EventGridTopicPatch
            {
                Tags = { { "env", "test" }, { "owner", "sdk-test" } }
            };
            await topic.UpdateAsync(WaitUntil.Completed, patch);
            // Retrieve the updated topic
            var updatedTopic = await _eventGridTopicCollection.GetAsync(topicName);
            Assert.IsNotNull(updatedTopic.Value);
        }

        [Test]
        public async Task ListSharedAccessKeys()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            var keys = await topic.GetSharedAccessKeysAsync();
            Assert.IsNotNull(keys);
        }

        [Test]
        public async Task RegenerateSharedAccessKey()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            var newKey = await topic.RegenerateKeyAsync(WaitUntil.Completed, new TopicRegenerateKeyContent("key1"));
            Assert.IsNotNull(newKey);
        }

        private void ValidateEventGridTopic(EventGridTopicResource topic, string topicName)
        {
            Assert.IsNotNull(topic);
            Assert.IsNotNull(topic.Data.Id);
            Assert.AreEqual(topicName, topic.Data.Name);
            Assert.AreEqual("Microsoft.EventGrid/topics", topic.Data.ResourceType.ToString());
            Assert.AreEqual("Succeeded", topic.Data.ProvisioningState.ToString());
            Assert.AreEqual(_resourceGroup.Data.Location, topic.Data.Location);
        }
    }
}
