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
    public class EventSubscriptionTests : EventGridManagementTestBase
    {
        public EventSubscriptionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=PASSWORDCODE";
        public const string AzureFunctionArmId = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Web/sites/devexpfuncappdestination/functions/EventGridTrigger1";
        public const string SampleAzureActiveDirectoryTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public const string SampleAzureActiveDirectoryApplicationIdOrUri = "03d47d4a-7c50-43e0-ba90-89d090cc4582";

        private EventGridTopicCollection TopicCollection { get; set; }

        private EventGridDomainCollection DomainCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), location);
            TopicCollection = ResourceGroup.GetEventGridTopics();
            DomainCollection = ResourceGroup.GetEventGridDomains();
        }

        [Ignore("TODO: 06/21/2023 - EventSubscription not available in global for this API version, enable this test after ARM deployment")]
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
            Assert.AreEqual(EventGridTopicProvisioningState.Succeeded, getTopicResponse.Data.ProvisioningState);
            Assert.AreEqual(DefaultLocation, getTopicResponse.Data.Location);

            // Create an event subscription to this topic
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            string scope = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.EventGrid/topics/{topicName}";

            var subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));
            var eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl)
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
            var eventSubscriptionUpdateParameters = new EventGridSubscriptionPatch()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl),
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
                Filter = new EventSubscriptionFilter()
                {
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
            Assert.AreEqual(2, ((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Data.Destination).DeliveryAttributeMappings.Count);
            Assert.AreEqual("StaticDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[0].Name);
            Assert.AreEqual("DynamicDeliveryAttribute1", ((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[1].Name);

            // List event subscriptions
            var eventSubscriptionsPage = await ResourceGroup.GetRegionalEventSubscriptionsDataAsync(DefaultLocation).ToEnumerableAsync();
            Assert.NotNull(eventSubscriptionsPage.FirstOrDefault(x => x.Name.Equals(eventSubscriptionName)));

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(falseResult);

            // Delete the topic
            await getTopicResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await TopicCollection.ExistsAsync(topicName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Ignore("TODO: 06/21/2023 - EventSubscription not available in global for this API version, enable this test after ARM deployment")]
        [Test]
        public async Task EventSubscriptionToDomainCreateGetUpdateDelete()
        {
            await SetCollection();

            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            var domainTopicName = Recording.GenerateAssetName("sdk-DomainTopic-");

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName,
                new EventGridDomainData(DefaultLocation)
                {
                    Tags =
                    {
                        {"tag1", "value1"},
                        {"tag2", "value2"}
                    }
                })).Value;

            Assert.NotNull(createDomainResponse);
            Assert.AreEqual(createDomainResponse.Data.Name, domainName);

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.NotNull(getDomainResponse);
            Assert.AreEqual(EventGridDomainProvisioningState.Succeeded, getDomainResponse.Data.ProvisioningState);
            Assert.AreEqual(DefaultLocation, getDomainResponse.Data.Location);

            // Create Domain Topic
            var domainTopic = (await getDomainResponse.GetDomainTopics().CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName)).Value;

            // Create an event subscription to this domain
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            string scope = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.EventGrid/domains/{domainName}";

            var subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));
            var eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = true,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels =
                    {
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

            // Get the created event subscription using nested API
            var domainEventSubscriptionCollection = getDomainResponse.GetDomainEventSubscriptions();
            var domainEventSubscriptionResponse = (await domainEventSubscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.NotNull(domainEventSubscriptionResponse);
            Assert.AreEqual(EventSubscriptionProvisioningState.Succeeded, domainEventSubscriptionResponse.Data.ProvisioningState);
            Assert.AreEqual("TestPrefix", domainEventSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("TestSuffix", domainEventSubscriptionResponse.Data.Filter.SubjectEndsWith);

            // Update the event subscription
            var eventSubscriptionUpdateParameters = new EventGridSubscriptionPatch()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl),
                },
                Filter = new EventSubscriptionFilter()
                {
                    IncludedEventTypes =
                        {
                            "Event1",
                            "Event2"
                        },
                    SubjectEndsWith = ".jpg",
                    SubjectBeginsWith = "TestPrefix"
                },
                Labels =
                    {
                        "UpdatedLabel1",
                        "UpdatedLabel2",
                    }
            };

            eventSubscriptionResponse = (await eventSubscriptionResponse.UpdateAsync(WaitUntil.Completed, eventSubscriptionUpdateParameters)).Value;
            Assert.AreEqual(".jpg", eventSubscriptionResponse.Data.Filter.SubjectEndsWith);
            Assert.IsTrue(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"));

            // Create an event subscription to a domain topic scope
            eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            scope = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{domainTopicName}";

            subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));
            eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = true,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels =
                    {
                        "TestLabel1",
                        "TestLabel2"
                    }
            };

            eventSubscriptionResponse = (await subscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.AreEqual(eventSubscriptionResponse.Data.Name, eventSubscriptionName);

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.AreEqual(EventSubscriptionProvisioningState.Succeeded, eventSubscriptionResponse.Data.ProvisioningState);
            Assert.AreEqual("TestPrefix", eventSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("TestSuffix", eventSubscriptionResponse.Data.Filter.SubjectEndsWith);

            // List event subscriptions
            var eventSubscriptionsPage = await subscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(eventSubscriptionsPage.FirstOrDefault(x => x.Data.Name.Equals(eventSubscriptionName)));

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(falseResult);

            // Delete the Domain
            await getDomainResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Ignore("TODO: 06/21/2023 - EventSubscription not available in global for this API version, enable this test after ARM deployment")]
        [Test]
        public async Task EventSubscriptionToAzureSubscriptionCreateGetUpdateDelete()
        {
            await SetCollection();

            // Create an event subscription to an Azure subscription
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");

            string scope = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}";
            var subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));

            var eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(AzureFunctionEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = false,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels =
                    {
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

            // List event subscriptions by Azure subscription
            var eventSubscriptionsList = await subscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(eventSubscriptionsList.FirstOrDefault(x => x.Data.Name.Equals(eventSubscriptionName)));

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
