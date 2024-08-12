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
    internal class EventGridTopicEventSubscriptionTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventGridTopicResource _eventGridTopic;
        private TopicEventSubscriptionCollection _topicEventSubscriptionCollection;
        private const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=PASSWORDCODE";

        public EventGridTopicEventSubscriptionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            _resourceGroup = await CreateResourceGroupAsync(location);
            _eventGridTopic = await CreateEventGridTopic(_resourceGroup, Recording.GenerateAssetName("eventGridTopic"));
            _topicEventSubscriptionCollection = _eventGridTopic.GetTopicEventSubscriptions();
        }

        private async Task<TopicEventSubscriptionResource> CreateTopicEventSubscription(string eventSubscriptionName)
        {
            var data = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl)
                },
            };
            var topicEventSubscription = await _topicEventSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, data);
            return topicEventSubscription.Value;
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            var topicEventSubscription = await CreateTopicEventSubscription(eventSubscriptionName);
            ValidateTopicEventSubscription(topicEventSubscription, eventSubscriptionName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            bool flag = await _topicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            var topicEventSubscription = await _topicEventSubscriptionCollection.GetAsync(eventSubscriptionName);
            ValidateTopicEventSubscription(topicEventSubscription, eventSubscriptionName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            var list = await _topicEventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateTopicEventSubscription(list.First(item => item.Data.Name == eventSubscriptionName), eventSubscriptionName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            var topicEventSubscription = await CreateTopicEventSubscription(eventSubscriptionName);
            bool flag = await _topicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName);
            Assert.IsTrue(flag);

            await topicEventSubscription.DeleteAsync(WaitUntil.Completed);
            flag = await _topicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName);
            Assert.IsFalse(flag);
        }

        private void ValidateTopicEventSubscription(TopicEventSubscriptionResource topicEventSubscription, string eventSubscriptionName)
        {
            Assert.IsNotNull(topicEventSubscription);
            Assert.IsNotNull(topicEventSubscription.Data.Id);
            Assert.AreEqual(eventSubscriptionName, topicEventSubscription.Data.Name);
            Assert.AreEqual("Succeeded", topicEventSubscription.Data.ProvisioningState.ToString());
            Assert.AreEqual("EventGridSchema", topicEventSubscription.Data.EventDeliverySchema.ToString());
            Assert.AreEqual("Microsoft.EventGrid/topics/eventSubscriptions", topicEventSubscription.Data.ResourceType.ToString());
            Assert.AreEqual("WebHook", topicEventSubscription.Data.Destination.EndpointType.ToString());
        }
    }
}
