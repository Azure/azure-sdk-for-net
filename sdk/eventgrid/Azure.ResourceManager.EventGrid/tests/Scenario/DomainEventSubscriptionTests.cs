// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class DomainEventSubscriptionTests : EventGridManagementTestBase
    {
        public DomainEventSubscriptionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private const string AzureFunctionEndpointUrl = "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=an3f31ORDSQ/llPPTaUDJiEJGoebE9ha7dODRhb1nIyg/LiYLfSVCA==";

        private EventGridDomainCollection DomainCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            DomainCollection = ResourceGroup.GetEventGridDomains();
        }

        [Test]
        public async Task CRUD()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            var domainTopicName = Recording.GenerateAssetName("sdk-DomainTopic-");

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName,
                new EventGridDomainData(DefaultLocation)
                {
                    Tags = { { "tag1", "value1" }, { "tag2", "value2" } }
                })).Value;

            Assert.NotNull(createDomainResponse);
            Assert.AreEqual(createDomainResponse.Data.Name, domainName);

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.NotNull(getDomainResponse);
            Assert.AreEqual(EventGridDomainProvisioningState.Succeeded, getDomainResponse.Data.ProvisioningState);
            Assert.AreEqual(DefaultLocation, getDomainResponse.Data.Location);

            // Create an event subscription to this domain
            var domainEventSubscriptionsCollection = getDomainResponse.GetDomainEventSubscriptions();
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
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
                Labels = { "TestLabel1", "TestLabel2" }
            };

            var eventSubscriptionResponse = (await domainEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.AreEqual(eventSubscriptionResponse.Data.Name, eventSubscriptionName);

            // Get the created event subscription
            eventSubscriptionResponse = await domainEventSubscriptionsCollection.GetAsync(eventSubscriptionName);
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

            // List domain event subscriptions
            var listDomainEventSubscriptionsResponse = await domainEventSubscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listDomainEventSubscriptionsResponse);
            Assert.GreaterOrEqual(listDomainEventSubscriptionsResponse.Count, 1);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await domainEventSubscriptionsCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(resultFalse);

            // Create an event subscription to a domain topic scope
            var domainTopicCollection = getDomainResponse.GetDomainTopics();
            var domainTopic = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName)).Value;
            var domainTopicEventSubscriptionCollection = domainTopic.GetDomainTopicEventSubscriptions();
            eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
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
                Labels = { "TestLabel1", "TestLabel2" }
            };

            var domainTopicEventSubscriptionResponse = (await domainTopicEventSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(domainTopicEventSubscriptionResponse);
            Assert.AreEqual(domainTopicEventSubscriptionResponse.Data.Name, eventSubscriptionName);

            // Get the created event subscription
            domainTopicEventSubscriptionResponse = await domainTopicEventSubscriptionCollection.GetAsync(eventSubscriptionName);
            Assert.NotNull(domainTopicEventSubscriptionResponse);
            Assert.AreEqual(EventSubscriptionProvisioningState.Succeeded, domainTopicEventSubscriptionResponse.Data.ProvisioningState);
            Assert.AreEqual("TestPrefix", domainTopicEventSubscriptionResponse.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("TestSuffix", domainTopicEventSubscriptionResponse.Data.Filter.SubjectEndsWith);

            // List domain topic event subscriptions
            var listDomainTopicEventSubscriptionsResponse = await domainTopicEventSubscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listDomainTopicEventSubscriptionsResponse);
            Assert.GreaterOrEqual(listDomainTopicEventSubscriptionsResponse.Count, 1);

            // Test getting full URL and delivery attributes
            fullUrlResponse = (await domainTopicEventSubscriptionResponse.GetFullUriAsync()).Value;
            Assert.NotNull(fullUrlResponse);
            Assert.NotNull(fullUrlResponse.Endpoint);

            deliveryAttributesResponse = await domainTopicEventSubscriptionResponse.GetDeliveryAttributesAsync().ToEnumerableAsync();
            Assert.NotNull(deliveryAttributesResponse);

            // Delete the domain topic event subscription
            await domainTopicEventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            resultFalse = (await domainTopicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(resultFalse);

            // Delete the Domain
            await getDomainResponse.DeleteAsync(WaitUntil.Completed);
            resultFalse = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}
