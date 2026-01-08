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

            Assert.Multiple(() =>
            {
                Assert.That(createTopicResponse, Is.Not.Null);
                Assert.That(topicName, Is.EqualTo(createTopicResponse.Data.Name));
            });

            // Get the created topic
            var getTopicResponse = (await TopicCollection.GetAsync(topicName)).Value;
            Assert.That(getTopicResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getTopicResponse.Data.ProvisioningState, Is.EqualTo(EventGridTopicProvisioningState.Succeeded));
                Assert.That(getTopicResponse.Data.Location, Is.EqualTo(DefaultLocation));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse, Is.Not.Null);
                Assert.That(eventSubscriptionName, Is.EqualTo(eventSubscriptionResponse.Data.Name));
            });

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.That(eventSubscriptionResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo(".jpg"));
                Assert.That(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"), Is.True);
                Assert.That(((WebHookEventSubscriptionDestination)eventSubscriptionResponse.Data.Destination).DeliveryAttributeMappings, Has.Count.EqualTo(2));
                Assert.That(((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[0].Name, Is.EqualTo("StaticDeliveryAttribute1"));
                Assert.That(((WebHookEventSubscriptionDestination)eventSubscriptionUpdateParameters.Destination).DeliveryAttributeMappings[1].Name, Is.EqualTo("DynamicDeliveryAttribute1"));
            });

            string topicTypeName = "Microsoft.EventGrid.Topics";

            // Get regional event subscriptions at resource group level from given location
            var regionalEventSubscriptionsByResourceGroup = ResourceGroup.GetRegionalEventSubscriptionsDataAsync(DefaultLocation).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(regionalEventSubscriptionsByResourceGroup, Is.Not.Null);

            // Get regional event subscriptions at subscription level for given location
            var regionalEventSubscriptionsBySubscription = DefaultSubscription.GetRegionalEventSubscriptionsDataAsync(DefaultLocation).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(regionalEventSubscriptionsByResourceGroup, Is.Not.Null);

            // Get regional event subscriptions by topic type at resource group level from given location
            var regionalEventSubscriptionsByTopicTypeResourceGroup =  ResourceGroup.GetRegionalEventSubscriptionsDataForTopicTypeAsync(DefaultLocation, topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(regionalEventSubscriptionsByTopicTypeResourceGroup, Is.Not.Null);

            // Get regional event subscriptions by topic type at subscription level for given location
            var regionalEventSubscriptionsByTopicTypeBySubscription = DefaultSubscription.GetRegionalEventSubscriptionsDataForTopicTypeAsync(DefaultLocation, topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(regionalEventSubscriptionsByTopicTypeBySubscription, Is.Not.Null);

            // Get global event subscriptions by topic type at resource group level
            var globalEventSubscriptionsByResourceGroup = ResourceGroup.GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(globalEventSubscriptionsByResourceGroup, Is.Not.Null);

            // Get global event subscriptions by topic type at subscription level
            var globalEventSubscriptionsBySubscription = DefaultSubscription.GetGlobalEventSubscriptionsDataForTopicTypeAsync(topicTypeName, filter: null, top: null).WithCancellation(CancellationToken.None).ConfigureAwait(false);
            Assert.That(globalEventSubscriptionsBySubscription, Is.Not.Null);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(falseResult, Is.False);

            // Delete the topic
            await getTopicResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await TopicCollection.ExistsAsync(topicName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(createDomainResponse, Is.Not.Null);
                Assert.That(domainName, Is.EqualTo(createDomainResponse.Data.Name));
            });

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.That(getDomainResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getDomainResponse.Data.ProvisioningState, Is.EqualTo(EventGridDomainProvisioningState.Succeeded));
                Assert.That(getDomainResponse.Data.Location, Is.EqualTo(DefaultLocation));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse, Is.Not.Null);
                Assert.That(eventSubscriptionName, Is.EqualTo(eventSubscriptionResponse.Data.Name));
            });

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;

            Assert.That(eventSubscriptionResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));
            });

            // Get the created event subscription using nested API
            var domainEventSubscriptionCollection = getDomainResponse.GetDomainEventSubscriptions();
            var domainEventSubscriptionResponse = (await domainEventSubscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.That(domainEventSubscriptionResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(domainEventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
                Assert.That(domainEventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
                Assert.That(domainEventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo(".jpg"));
                Assert.That(eventSubscriptionResponse.Data.Labels.Contains("UpdatedLabel1"), Is.True);
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse, Is.Not.Null);
                Assert.That(eventSubscriptionName, Is.EqualTo(eventSubscriptionResponse.Data.Name));
            });

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.That(eventSubscriptionResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectBeginsWith, Is.EqualTo("TestPrefix"));
                Assert.That(eventSubscriptionResponse.Data.Filter.SubjectEndsWith, Is.EqualTo("TestSuffix"));
            });

            // List all event subscriptions for a domain topic
            var domainTopicEventSubscriptions = await domainTopic.GetDomainTopicEventSubscriptions().GetAllAsync().ToEnumerableAsync();
            Assert.That(domainTopicEventSubscriptions, Is.Not.Null);
            Assert.That(domainTopicEventSubscriptions.Count(), Is.EqualTo(1));

            // List event subscriptions
            var eventSubscriptionsPage = await subscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(eventSubscriptionsPage.FirstOrDefault(x => x.Data.Name.Equals(eventSubscriptionName)), Is.Not.Null);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(falseResult, Is.False);

            // Delete the Domain
            await getDomainResponse.DeleteAsync(WaitUntil.Completed);
            falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(eventSubscriptionResponse, Is.Not.Null);
                Assert.That(eventSubscriptionName, Is.EqualTo(eventSubscriptionResponse.Data.Name));
            });

            // Get the created event subscription
            eventSubscriptionResponse = (await subscriptionCollection.GetAsync(eventSubscriptionName)).Value;
            Assert.That(eventSubscriptionResponse, Is.Not.Null);
            Assert.That(eventSubscriptionResponse.Data.ProvisioningState, Is.EqualTo(EventSubscriptionProvisioningState.Succeeded));

            // List event subscriptions by Azure subscription
            var eventSubscriptionsList = await subscriptionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(eventSubscriptionsList.FirstOrDefault(x => x.Data.Name.Equals(eventSubscriptionName)), Is.Not.Null);

            // Delete the event subscription
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await subscriptionCollection.ExistsAsync(eventSubscriptionName)).Value;
            Assert.That(falseResult, Is.False);
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
            Assert.That(getResult, Is.Not.Null);
            Assert.That(getResult.Value, Is.Not.Null);
            Assert.That(getResult.Value.Data.Name, Is.EqualTo(eventSubscriptionName));

            // GetDeliveryAttributesAsync
            int count = 0;
            await foreach (var attr in eventSubResource.GetDeliveryAttributesAsync())
            {
                Assert.That(attr, Is.Not.Null);
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(2));

            // GetFullUriAsync
            var fullUriResult = await eventSubResource.GetFullUriAsync();
            Assert.That(fullUriResult, Is.Not.Null);
            Assert.That(fullUriResult.Value, Is.Not.Null);
            Assert.That(fullUriResult.Value.Endpoint, Is.Not.Null);

            // Cleanup
            await eventSubscriptionResponse.DeleteAsync(WaitUntil.Completed);
            await createTopicResponse.DeleteAsync(WaitUntil.Completed);
        }
    }
}
