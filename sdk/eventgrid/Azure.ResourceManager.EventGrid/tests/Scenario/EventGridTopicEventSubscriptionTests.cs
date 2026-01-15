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
        // from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

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
                    Endpoint = new Uri(LogicAppEndpointUrl)
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
                    Endpoint = new Uri(LogicAppEndpointUrl),
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
            Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo(".jpg"));
            Assert.That(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"), Is.True);

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
            Assert.That(flag, Is.True);
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
            Assert.That(flag, Is.True);

            await topicEventSubscription.DeleteAsync(WaitUntil.Completed);
            flag = await _topicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName);
            Assert.That(flag, Is.False);
        }

        //TopicEventSubscriptionResource GetAsync'
        [Test]
        public async Task TopicEventSubscriptionResourceGetAsync()
        {
            // Arrange
            string eventSubscriptionName = Recording.GenerateAssetName("topicSubscription");
            var topicEventSubscriptionResource = await CreateTopicEventSubscription(eventSubscriptionName);

            // Act
            var response = await topicEventSubscriptionResource.GetAsync();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.That(response.Value.Data.Name, Is.EqualTo(eventSubscriptionName));
            Assert.That(response.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(response.Value.Data.EventDeliverySchema.ToString(), Is.EqualTo("EventGridSchema"));
            Assert.That(response.Value.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/topics/eventSubscriptions"));
            Assert.That(response.Value.Data.Destination.EndpointType.ToString(), Is.EqualTo("WebHook"));

            // Delete the event subscription resource
            await topicEventSubscriptionResource.DeleteAsync(WaitUntil.Completed);
        }

        private void ValidateTopicEventSubscription(TopicEventSubscriptionResource topicEventSubscription, string eventSubscriptionName)
        {
            Assert.IsNotNull(topicEventSubscription);
            Assert.IsNotNull(topicEventSubscription.Data.Id);
            Assert.That(topicEventSubscription.Data.Name, Is.EqualTo(eventSubscriptionName));
            Assert.That(topicEventSubscription.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(topicEventSubscription.Data.EventDeliverySchema.ToString(), Is.EqualTo("EventGridSchema"));
            Assert.That(topicEventSubscription.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/topics/eventSubscriptions"));
            Assert.That(topicEventSubscription.Data.Destination.EndpointType.ToString(), Is.EqualTo("WebHook"));
        }
    }
}
