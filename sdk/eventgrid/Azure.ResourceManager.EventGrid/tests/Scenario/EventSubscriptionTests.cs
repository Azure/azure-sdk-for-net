// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
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
        // for live tests, replace passcode with actual code from portal for this this function devexpfuncappdestination and function EventGridTrigger1
        // for live tests, replace SANITIZED_FUNCTION_KEY with actual code from from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        public const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";
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
                    Endpoint = new Uri(LogicAppEndpointUrl),
                    DeliveryAttributeMappings = {
                        new StaticDeliveryAttributeMapping
                        {
                            Name = "StaticAttribute",
                            IsSecret = false,
                            Value = "value"
                        },
                        new DynamicDeliveryAttributeMapping
                        {
                            Name = "DynamicAttribute",
                            SourceField = "data.field"
                        }
                    }
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
                    Endpoint = new Uri(LogicAppEndpointUrl),
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

            string topicTypeName = "Microsoft.EventGrid.Topics";

            // Get regional event subscriptions at resource group level from given location
            var regionalEventSubscriptionsByResourceGroup = ResourceGroup.GetRegionalEventSubscriptionsDataAsync(DefaultLocation).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(regionalEventSubscriptionsByResourceGroup);

            // Get regional event subscriptions at subscription level for given location
            var regionalEventSubscriptionsBySubscription = DefaultSubscription.GetRegionalEventSubscriptionsDataAsync(DefaultLocation).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(regionalEventSubscriptionsByResourceGroup);

            // Get regional event subscriptions by topic type at resource group level from given location
            var regionalEventSubscriptionsByTopicTypeResourceGroup =  ResourceGroup.GetRegionalEventSubscriptionsDataForTopicTypeAsync(DefaultLocation, topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(regionalEventSubscriptionsByTopicTypeResourceGroup);

            // Get regional event subscriptions by topic type at subscription level for given location
            var regionalEventSubscriptionsByTopicTypeBySubscription = DefaultSubscription.GetRegionalEventSubscriptionsDataForTopicTypeAsync(DefaultLocation, topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(regionalEventSubscriptionsByTopicTypeBySubscription);

            // Get global event subscriptions by topic type at resource group level
            var globalEventSubscriptionsByResourceGroup = ResourceGroup.GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(globalEventSubscriptionsByResourceGroup);

            // Get global event subscriptions by topic type at subscription level
            var globalEventSubscriptionsBySubscription = DefaultSubscription.GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.NotNull(globalEventSubscriptionsBySubscription);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.IsFalse(falseResult);

            // Delete the topic
            await getTopicResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await TopicCollection.ExistsAsync(topicName)).Value;
            Assert.IsFalse(falseResult);
        }

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
                    Endpoint = new Uri(LogicAppEndpointUrl),
                    DeliveryAttributeMappings = {
                        new StaticDeliveryAttributeMapping
                        {
                            Name = "StaticAttribute",
                            IsSecret = false,
                            Value = "value"
                        },
                        new DynamicDeliveryAttributeMapping
                        {
                            Name = "DynamicAttribute",
                            SourceField = "data.field"
                        }
                    }
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
                    Endpoint = new Uri(LogicAppEndpointUrl),
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
                    Endpoint = new Uri(LogicAppEndpointUrl),
                    DeliveryAttributeMappings = {
                        new StaticDeliveryAttributeMapping
                        {
                            Name = "StaticAttribute",
                            IsSecret = false,
                            Value = "value"
                        },
                        new DynamicDeliveryAttributeMapping
                        {
                            Name = "DynamicAttribute",
                            SourceField = "data.field"
                        }
                    }
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

            // List all event subscriptions for a domain topic
            var domainTopicEventSubscriptions = await domainTopic.GetDomainTopicEventSubscriptions().GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(domainTopicEventSubscriptions);
            Assert.AreEqual(domainTopicEventSubscriptions.Count(), 1);

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
                    Endpoint = new Uri(LogicAppEndpointUrl),
                    DeliveryAttributeMappings = {
                        new StaticDeliveryAttributeMapping
                        {
                            Name = "StaticAttribute",
                            IsSecret = false,
                            Value = "value"
                        },
                        new DynamicDeliveryAttributeMapping
                        {
                            Name = "DynamicAttribute",
                            SourceField = "data.field"
                        }
                    }
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

        [Test]
        public async Task EventSubscriptionResourceCRUD()
        {
            await SetCollection();

            // Create topic and event subscription
            var topicName = Recording.GenerateAssetName("sdk-Topic-");
            var createTopicResponse = (await TopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new EventGridTopicData(DefaultLocation))).Value;
            var eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-");
            string scope = $"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/resourceGroups/{ResourceGroup.Data.Name}/providers/Microsoft.EventGrid/topics/{topicName}";
            var subscriptionCollection = Client.GetEventSubscriptions(new ResourceIdentifier(scope));
            var eventSubscription = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination()
                {
                    Endpoint = new Uri(LogicAppEndpointUrl),
                    DeliveryAttributeMappings = {
                        new StaticDeliveryAttributeMapping
                        {
                            Name = "StaticAttribute",
                            IsSecret = false,
                            Value = "value"
                        },
                        new DynamicDeliveryAttributeMapping
                        {
                            Name = "DynamicAttribute",
                            SourceField = "data.field"
                        }
                    }
                }
            };
            var eventSubscriptionResponse = (await subscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscription)).Value;

            // Get the EventSubscriptionResource
            var eventSubResourceId = EventSubscriptionResource.CreateResourceIdentifier(scope, eventSubscriptionName);
            var eventSubResource = Client.GetEventSubscriptionResource(eventSubResourceId);

            // GetAsync
            var getResult = await eventSubResource.GetAsync();
            Assert.IsNotNull(getResult);
            Assert.IsNotNull(getResult.Value);
            Assert.AreEqual(eventSubscriptionName, getResult.Value.Data.Name);

            // GetDeliveryAttributesAsync
            int count = 0;
            await foreach (var attr in eventSubResource.GetDeliveryAttributesAsync())
            {
                Assert.IsNotNull(attr);
                count++;
            }
            Assert.GreaterOrEqual(count, 2);

            // GetFullUriAsync
            var fullUriResult = await eventSubResource.GetFullUriAsync();
            Assert.IsNotNull(fullUriResult);
            Assert.IsNotNull(fullUriResult.Value);
            Assert.IsNotNull(fullUriResult.Value.Endpoint);

            // Cleanup
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            await createTopicResponse.DeleteAsync(WaitUntil.Completed);
        }
    }
}
