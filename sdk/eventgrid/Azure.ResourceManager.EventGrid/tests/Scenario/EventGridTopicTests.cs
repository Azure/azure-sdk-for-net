// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public EventGridTopicTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _eventGridTopicCollection = _resourceGroup.GetEventGridTopics();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            ValidateEventGridTopic(topic, topicName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            bool flag = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            var topic = await _eventGridTopicCollection.GetAsync(topicName);
            ValidateEventGridTopic(topic, topicName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            await CreateEventGridTopic(_resourceGroup, topicName);
            var list = await _eventGridTopicCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateEventGridTopic(list.First(item => item.Data.Name == topicName), topicName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string topicName = Recording.GenerateAssetName("EventGridTopic");
            var topic = await CreateEventGridTopic(_resourceGroup, topicName);
            bool flag = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsTrue(flag);

            await topic.DeleteAsync(WaitUntil.Completed);
            flag = await _eventGridTopicCollection.ExistsAsync(topicName);
            Assert.IsFalse(flag);
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
