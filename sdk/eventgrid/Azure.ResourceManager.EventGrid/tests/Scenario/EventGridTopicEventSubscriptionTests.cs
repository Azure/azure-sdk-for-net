// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
        // For live tests, replace "SANITIZED_FUNCTION_KEY" with the actual function key
        // from the Azure Portal for the function "EventGridTrigger1" in "devexpfuncappdestination".
        private const string AzureFunctionEndpointUrl = "https://prod-71.eastus.logic.azure.com:443/workflows/b60c5432896846608c05de3a96be6de2/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

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
            var eventSubscriptionResponse = await CreateTopicEventSubscription(eventSubscriptionName);
            ValidateTopicEventSubscription(eventSubscriptionResponse, eventSubscriptionName);
            // Update the event subscription
            var eventSubscriptionUpdateParameters = new EventGridSubscriptionPatch()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl),
                },
                Filter = new EventSubscriptionFilter()
                {
                    IncludedEventTypes = { "Event1", "Event2" },
                    SubjectEndsWith = ".jpg",
                    SubjectBeginsWith = "TestPrefix"
                },
                Labels = { "UpdatedLabel1", "UpdatedLabel2" }
            };

            eventSubscriptionResponse = (await eventSubscriptionResponse.UpdateAsync(WaitUntil.Completed, eventSubscriptionUpdateParameters)).Value;
            Assert.AreEqual(".jpg", eventSubscriptionResponse.Data.Filter.SubjectEndsWith);
            Assert.IsTrue(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"));

            // Test getting full URL and delivery attributes
            var fullUrlResponse = (await eventSubscriptionResponse.GetFullUriAsync()).Value;
            Assert.NotNull(fullUrlResponse);
            Assert.NotNull(fullUrlResponse.Endpoint);

            var deliveryAttributesResponse = await eventSubscriptionResponse.GetDeliveryAttributesAsync().ToEnumerableAsync();
            Assert.NotNull(deliveryAttributesResponse);
        }

        [Test]
        public async Task Exist()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            bool flag = await _topicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            var topicEventSubscription = await _topicEventSubscriptionCollection.GetAsync(eventSubscriptionName);
            ValidateTopicEventSubscription(topicEventSubscription, eventSubscriptionName);
        }

        [Test]
        public async Task GetAll()
        {
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            await CreateTopicEventSubscription(eventSubscriptionName);
            var list = await _topicEventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateTopicEventSubscription(list.First(item => item.Data.Name == eventSubscriptionName), eventSubscriptionName);
        }

        [Test]
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
