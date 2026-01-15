// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridDomainEventSubscriptionTests : EventGridManagementTestBase
    {
        public EventGridDomainEventSubscriptionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        // For live tests, replace "SANITIZED_FUNCTION_KEY" with the actual function key
        // from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";
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
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            var domainTopicName = Recording.GenerateAssetName("sdk-DomainTopic-");

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName,
                new EventGridDomainData(location)
                {
                    Tags = { { "tag1", "value1" }, { "tag2", "value2" } }
                })).Value;

            Assert.NotNull(createDomainResponse);
            Assert.That(domainName, Is.EqualTo(createDomainResponse.Data.Name));

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.NotNull(getDomainResponse);
            Assert.That(getDomainResponse.Data.ProvisioningState, Is.EqualTo(EventGridDomainProvisioningState.Succeeded));
            Assert.That(getDomainResponse.Data.Location, Is.EqualTo(location));

            // Create an event subscription to this domain
            var domainEventSubscriptionsCollection = getDomainResponse.GetDomainEventSubscriptions();
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            var eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = true,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels = { "TestLabel1", "TestLabel2" }
            };

            var domainEventSubscriptionExistsBeforeCreate = (await domainEventSubscriptionsCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(domainEventSubscriptionExistsBeforeCreate, Is.False);

            var eventSubscriptionResponse = (await domainEventSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(eventSubscriptionResponse);
            Assert.That(eventSubscriptionName, Is.EqualTo(eventSubscriptionResponse.Data.Name));

            var domainEventSubscriptionExistsAfterCreate = (await domainEventSubscriptionsCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(domainEventSubscriptionExistsAfterCreate, Is.True);

            // Get the created event subscription
            eventSubscriptionResponse = await domainEventSubscriptionsCollection.GetAsync(eventSubscriptionName);
            Assert.NotNull(eventSubscriptionResponse);
            Assert.That(eventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
            Assert.That(eventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
            Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));

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

            // List domain event subscriptions
            var listDomainEventSubscriptionsResponse = await domainEventSubscriptionsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(listDomainEventSubscriptionsResponse);
            Assert.GreaterOrEqual(listDomainEventSubscriptionsResponse.Count, 1);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var resultFalse = (await domainEventSubscriptionsCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(resultFalse, Is.False);

            // Create an event subscription to a domain topic scope
            var domainTopicCollection = getDomainResponse.GetDomainTopics();
            var domainTopic = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName)).Value;
            var domainTopicEventSubscriptionCollection = domainTopic.GetDomainTopicEventSubscriptions();
            eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    IsSubjectCaseSensitive = true,
                    SubjectBeginsWith = "TestPrefix",
                    SubjectEndsWith = "TestSuffix"
                },
                Labels = { "TestLabel1", "TestLabel2" }
            };

            var domainTopicEventSubscriptionExistsBeforeCreate = (await domainEventSubscriptionsCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(domainTopicEventSubscriptionExistsBeforeCreate, Is.False);
            var domainTopicEventSubscriptionResponse = (await domainTopicEventSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;
            Assert.NotNull(domainTopicEventSubscriptionResponse);
            Assert.That(eventSubscriptionName, Is.EqualTo(domainTopicEventSubscriptionResponse.Data.Name));
            var domainTopicEventSubscriptionExistsAfterCreate = (await domainTopicEventSubscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(domainTopicEventSubscriptionExistsAfterCreate, Is.True);

            // Get the created event subscription
            domainTopicEventSubscriptionResponse = await domainTopicEventSubscriptionCollection.GetAsync(eventSubscriptionName);
            Assert.NotNull(domainTopicEventSubscriptionResponse);
            Assert.That(domainTopicEventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
            Assert.That(domainTopicEventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
            Assert.That(domainTopicEventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));

            // Update the domain topic event subscription
            var domainTopicEventSubscriptionUpdateParameters = new EventGridSubscriptionPatch()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(LogicAppEndpointUrl),
                },
                Filter = new EventSubscriptionFilter()
                {
                    IncludedEventTypes = { "UpdatedEvent1", "UpdatedEvent2" },
                    SubjectEndsWith = ".png",
                    SubjectBeginsWith = "UpdatedPrefix"
                },
                Labels = { "UpdatedDomainTopicLabel1", "UpdatedDomainTopicLabel2" }
            };

            // Apply the update
            domainTopicEventSubscriptionResponse = (await domainTopicEventSubscriptionResponse.UpdateAsync(WaitUntil.Completed, domainTopicEventSubscriptionUpdateParameters)).Value;

            // Validate update
            Assert.NotNull(domainTopicEventSubscriptionResponse);
            Assert.That(domainTopicEventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo(".png"));
            Assert.That(domainTopicEventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("UpdatedPrefix"));
            Assert.That(domainTopicEventSubscriptionResponse.Data.Labels.Contains("UpdatedDomainTopicLabel1"), Is.True);

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
            Assert.That(resultFalse, Is.False);

            // Delete the Domain
            await getDomainResponse.DeleteAsync(WaitUntil.Completed);
            resultFalse = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.That(resultFalse, Is.False);
        }

        [Test]
        public async Task DomainEventSubscriptionNegativeScenarios()
        {
            await SetCollection();
            var domainName = Recording.GenerateAssetName("sdk-Domain-");

            var domain = (await DomainCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, domainName, new EventGridDomainData(DefaultLocation))).Value;

            var eventSubscriptions = domain.GetDomainEventSubscriptions();

            // Get non-existent event subscription
            var response = await eventSubscriptions.GetIfExistsAsync("notexistentsub");
            Assert.That(response.HasValue, Is.False);

            // GetAsync on non-existent subscription should throw
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await eventSubscriptions.GetAsync("notexistentsub");
            });

            // Create subscription with invalid URI
            var invalidSubscriptionName = Recording.GenerateAssetName("sdk-BadSub-");
            var badSub = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri("http://invalid.local")
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "Invalid",
                    SubjectEndsWith = "Data"
                }
            };

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, invalidSubscriptionName, badSub);
            });

            // Create valid subscription
            var validSubscriptionName = Recording.GenerateAssetName("sdk-ValidSub-");
            var validSub = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "A",
                    SubjectEndsWith = "Z"
                }
            };

            var createdValidSub = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, validSubscriptionName, validSub)).Value;
            Assert.NotNull(createdValidSub);

            // Delete the valid subscription
            await createdValidSub.DeleteAsync(WaitUntil.Completed);
            var exists = await eventSubscriptions.ExistsAsync(validSubscriptionName);
            Assert.That(exists.Value, Is.False);

            // Patch after deletion should throw (either 400 or 404)
            var emptyPatch = new EventGridSubscriptionPatch();

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await createdValidSub.UpdateAsync(WaitUntil.Completed, emptyPatch);
            });

            Assert.That(ex.Status == 404 || ex.Status == 400, Is.True, $"Expected 404 or 400, but was {ex.Status}");

            // Delete domain
            await domain.DeleteAsync(WaitUntil.Completed);
        }
    }
}
