// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventSubscriptionTests : EventGridManagementTestBase
    {
        public EventSubscriptionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=an3f31ORDSQ/llPPTaUDJiEJGoebE9ha7dODRhb1nIyg/LiYLfSVCA==";
        public const string AzureFunctionArmId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Web/sites/devexpfuncappdestination/functions/EventGridTrigger1";
        public const string SampleAzureActiveDirectoryTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public const string SampleAzureActiveDirectoryApplicationIdOrUri = "03d47d4a-7c50-43e0-ba90-89d090cc4582";

        private EventGridTopicCollection TopicCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            TopicCollection = ResourceGroup.GetEventGridTopics();
        }

        [Test]
        public async Task EventSubscriptionToCustomTopicCreateGetUpdateDelete()
        {
            await SetCollection();

            var topicName = Recording.GenerateAssetName("sdk-Topic-");

            var createTopicResponse = (await TopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName,
                new EventGridTopicData(DefaultLocation)
                {
                    Tags = {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                    }
                })).Value;

            Assert.NotNull(createTopicResponse);
            Assert.AreEqual(createTopicResponse.Data.Name, topicName);

            // Get the created topic
            var getTopicResponse = (await TopicCollection.GetAsync(topicName)).Value;
            Assert.NotNull(getTopicResponse);
            Assert.AreEqual(EventGridTopicProvisioningState.Succeeded , getTopicResponse.Data.ProvisioningState);
            Assert.AreEqual(DefaultLocation, getTopicResponse.Data.Location);

            // Create an event subscription to this topic
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            string scope = $"/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.EventGrid/topics/{topicName}";

            var subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));
            var eventSubscription = new EventSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUri = new Uri(AzureFunctionEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = true,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels ={
                        "TestLabel1",
                        "TestLabel2"
                    }
            };

            var eventSubscriptionResponse = (await subscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.AreEqual(eventSubscriptionResponse.Data.Name, eventSubscriptionName);

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.AreEqual(EventSubscriptionProvisioningState.Succeeded, eventSubscriptionResponse.Data.ProvisioningState);
            Assert.AreEqual("TestPrefix", eventSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("TestSuffix", eventSubscriptionResponse.Data.Filter.SubjectEndsWith);

            // Update the event subscription
            var eventSubscriptionUpdateParameters = new EventSubscriptionPatch()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    EndpointUri = new Uri(AzureFunctionEndpointUrl),
                    DeliveryAttributeMappings = {
                            new StaticDeliveryAttributeMapping()
                            {
                                Name = "StaticDeliveryAttribute1",
                                IsSecret = false,
                                Value = "someValue"
                            },
                            new DynamicDeliveryAttributeMapping()
                            {
                                Name = "DynamicDeliveryAttribute1",
                                SourceField = "data.field1"
                            }
                        }
                },
                Filter = {
                    IncludedEventTypes = {
                            "Event1",
                            "Event2"
                        },
                    SubjectEndsWith = ".jpg",
                    SubjectBeginsWith = "TestPrefix"
                },
                Labels = {
                        "UpdatedLabel1",
                        "UpdatedLabel2",
                    }
            };

            eventSubscriptionResponse = (await eventSubscriptionResponse.UpdateAsync(WaitUntil.Completed, eventSubscriptionUpdateParameters)).Value;
            Assert.AreEqual(".jpg", eventSubscriptionResponse.Data.Filter.SubjectEndsWith);
            Assert.IsTrue(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"));
            Assert.NotNull(((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings);
            Assert.Equal(2, ((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings.Count);
            // Assert.Equal(1, ((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Destination).DeliveryAttributeMappings.Count);
            Assert.Equal("StaticDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[0].Name);
            Assert.Equal("DynamicDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[1].Name);

            // List event subscriptions
            var eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupAsync(resourceGroup, location).Result;
            List<EventSubscription> eventSubscriptionsList = new List<EventSubscription>();
            string nextLink = null;

            if (eventSubscriptionsPage != null)
            {
                eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                nextLink = eventSubscriptionsPage.NextPageLink;
                while (nextLink != null)
                {
                    eventSubscriptionsPage = this.EventGridManagementClient.EventSubscriptions.ListRegionalByResourceGroupNextAsync(nextLink).Result;
                    eventSubscriptionsList.AddRange(eventSubscriptionsPage);
                    nextLink = eventSubscriptionsPage.NextPageLink;
                }
            }

            Assert.Contains(eventSubscriptionsList, es => es.Name == eventSubscriptionName);

            // Delete the event subscription
            EventGridManagementClient.EventSubscriptions.DeleteAsync(scope, eventSubscriptionName).Wait();

            // Delete the topic
            EventGridManagementClient.Topics.DeleteAsync(resourceGroup, topicName).Wait();
        }
    }
}
