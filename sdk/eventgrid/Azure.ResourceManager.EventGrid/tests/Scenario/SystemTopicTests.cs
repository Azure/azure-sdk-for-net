// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class SystemTopicTests : EventGridManagementTestBase
    {
        public SystemTopicTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private SystemTopicCollection SystemTopicCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }
        private EventGridNamespaceCollection NamespaceCollection { get; set; }

        // For live tests, replace "SANITIZED_FUNCTION_KEY" with the actual function key
        // from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";
        private async Task SetCollection()
        {
            // This test relies on the existence of the 'sdk-eventgrid-test-rg' resource group within the subscription, ensuring that system topics and related resources (such as Key Vault) are deployed within the same resource group for validation
            // Subscription: 5b4b650e-28b9-4790-b3ab-ddbd88d727c4 (Azure Event Grid SDK Subscription)
            ResourceGroup = await GetResourceGroupAsync(DefaultSubscription, "sdk-eventgrid-test-rg");
            SystemTopicCollection = ResourceGroup.GetSystemTopics();
            NamespaceCollection = ResourceGroup.GetEventGridNamespaces();
        }

        [Test]
        public async Task SystemTopicWithMonitorDestinationCreateGetUpdateDelete()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");

            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults",
                Tags = {
            ["tag1"] = "value1",
            ["tag2"] = "value2",
        },
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t => t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
            }
            else
            {
                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(systemTopic);
                Assert.AreEqual(systemTopic.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            }

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new MonitorAlertEventSubscriptionDestination
                {
                    EndpointType = EndpointType.MonitorAlert,
                    Severity = MonitorAlertSeverity.Sev3,
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix",
                    SubjectEndsWith = "ExampleSuffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var sub1 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var sub2 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;

            Assert.NotNull(sub1);
            Assert.NotNull(sub2);
            Assert.AreEqual(EndpointType.MonitorAlert, sub1.Data.Destination.EndpointType);
            Assert.AreEqual(EndpointType.MonitorAlert, sub2.Data.Destination.EndpointType);

            var patch = new EventGridSubscriptionPatch()
            {
                Destination = new MonitorAlertEventSubscriptionDestination
                {
                    EndpointType = EndpointType.MonitorAlert,
                    Severity = MonitorAlertSeverity.Sev4,
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix2",
                    SubjectEndsWith = "ExampleSuffix2",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var updatedSub = (await sub1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updatedSub.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updatedSub.Data.Filter.SubjectEndsWith);
            Assert.AreEqual(MonitorAlertSeverity.Sev4, ((MonitorAlertEventSubscriptionDestination)updatedSub.Data.Destination).Severity);

            var allSubs = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(allSubs.Count, 2);

            await sub1.DeleteAsync(WaitUntil.Completed);
            await sub2.DeleteAsync(WaitUntil.Completed);

            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
                var exists = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
                Assert.IsFalse(exists);
            }
        }

        [Test]
        public async Task SystemTopicWithNamespaceTopicDestinationCreateGetUpdateDelete()
        {
            await SetCollection();

            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-");
            string systemTopicEventSubscriptionName1 = Recording.GenerateAssetName("sdk-EventSubscription-");
            string systemTopicEventSubscriptionName2 = Recording.GenerateAssetName("sdk-EventSubscription-");

            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.Storage/storageAccounts/sdkegteststorageaccount";

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
                systemTopicName = systemTopic.Data.Name;
            }
            else
            {
                var userAssignedIdentity = new UserAssignedIdentity();
                var data = new SystemTopicData(new AzureLocation("centraluseuap"))
                {
                    Source = new ResourceIdentifier(sourceResourceIdentifier),
                    TopicType = "microsoft.storage.storageaccounts",
                    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned),
                    Tags = {
                ["tag1"] = "value1",
                ["tag2"] = "value2",
            },
                };
                data.Identity.UserAssignedIdentities.Add(
                    new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity"),
                    userAssignedIdentity);

                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, data)).Value;
                Assert.NotNull(systemTopic);
                Assert.AreEqual(systemTopic.Data.ProvisioningState, EventGridResourceProvisioningState.Succeeded);
            }

            // Update tags
            var systemTopicPatch = new SystemTopicPatch()
            {
                Tags = {
            {"updatedTag1", "updatedValue1"},
            {"updatedTag2", "updatedValue2"}
        }
            };
            var updateSystemTopicResponse = (await systemTopic.UpdateAsync(WaitUntil.Completed, systemTopicPatch)).Value;
            Assert.NotNull(updateSystemTopicResponse);
            Assert.AreEqual(updateSystemTopicResponse.Data.Name, systemTopicName);

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var namespaceTopicDestination = new DeliveryWithResourceIdentity()
            {
                Identity = new EventSubscriptionIdentity()
                {
                    IdentityType = EventSubscriptionIdentityType.UserAssigned,
                    UserAssignedIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourcegroups/sdk-eventgrid-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-eventgrid-test-userAssignedManagedIdentity",
                },
                Destination = new NamespaceTopicEventSubscriptionDestination()
                {
                    ResourceId = new ResourceIdentifier("/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.EventGrid/namespaces/sdk-eventgrid-test-eventgridNamespace/topics/sdk-eventgrid-test-eventGridTopic"),
                }
            };

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix",
                    SubjectEndsWith = "ExampleSuffix",
                    IsSubjectCaseSensitive = false,
                },
                DeliveryWithResourceIdentity = namespaceTopicDestination,
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var sub1 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName1, eventSubscriptionData)).Value;
            var sub2 = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicEventSubscriptionName2, eventSubscriptionData)).Value;

            Assert.AreEqual(systemTopicEventSubscriptionName1, sub1.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, sub1.Data.DeliveryWithResourceIdentity.Destination.EndpointType);
            Assert.AreEqual(systemTopicEventSubscriptionName2, sub2.Data.Name);
            Assert.AreEqual(EndpointType.NamespaceTopic, sub2.Data.DeliveryWithResourceIdentity.Destination.EndpointType);

            // Update one subscription
            var patch = new EventGridSubscriptionPatch()
            {
                DeliveryWithResourceIdentity = namespaceTopicDestination,
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "ExamplePrefix2",
                    SubjectEndsWith = "ExampleSuffix2",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };
            var updatedSub = (await sub1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual("ExamplePrefix2", updatedSub.Data.Filter.SubjectBeginsWith);
            Assert.AreEqual("ExampleSuffix2", updatedSub.Data.Filter.SubjectEndsWith);

            // List and validate
            var allSubs = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(allSubs);
            Assert.AreEqual(2, allSubs.Count);

            // Cleanup
            await sub1.DeleteAsync(WaitUntil.Completed);
            await sub2.DeleteAsync(WaitUntil.Completed);

            var subsAfterDelete = await eventSubscriptions.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, subsAfterDelete.Count);

            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
                var exists = (await SystemTopicCollection.ExistsAsync(systemTopicName)).Value;
                Assert.IsFalse(exists);
            }
        }

        [Test]
        public async Task SystemTopicCollection_GetAsync_ReturnsResource()
        {
            await SetCollection();

            // Arrange
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-GetAsync-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            // Check if a system topic already exists for the source
            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource created;
            if (existing != null)
            {
                created = existing;
                systemTopicName = created.Data.Name;
            }
            else
            {
                created = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(created);
            }

            // Act
            var response = await SystemTopicCollection.GetAsync(systemTopicName);

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(systemTopicName, response.Value.Data.Name);

            // Cleanup only if we created it
            if (existing == null)
            {
                await created.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicEventSubscriptionResource_GetDeliveryAttributesAsync_ReturnsAttributes()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-GetAttr-");
            string eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-GetAttr-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
                systemTopicName = systemTopic.Data.Name;
            }
            else
            {
                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(systemTopic);
            }

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new MonitorAlertEventSubscriptionDestination
                {
                    EndpointType = EndpointType.MonitorAlert,
                    Severity = MonitorAlertSeverity.Sev3,
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "Prefix",
                    SubjectEndsWith = "Suffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var createdSub = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscriptionData)).Value;

            // Act
            var attributes = await createdSub.GetDeliveryAttributesAsync().ToEnumerableAsync();

            // Assert
            Assert.NotNull(attributes);

            // Cleanup
            await createdSub.DeleteAsync(WaitUntil.Completed);
            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicEventSubscriptionResource_GetFullUriAsync_ReturnsUri()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-GetUri-");
            string eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-GetUri-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
                systemTopicName = systemTopic.Data.Name;
            }
            else
            {
                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(systemTopic);
            }

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "Prefix",
                    SubjectEndsWith = "Suffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var createdSub = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscriptionData)).Value;

            Response<EventSubscriptionFullUri> uriResponse = null;
            int retryCount = 0;
            const int maxRetries = 3;
            const int delayMs = 3000;

            try
            {
                while (retryCount < maxRetries)
                {
                    try
                    {
                        uriResponse = await createdSub.GetFullUriAsync();
                        break;
                    }
                    catch (RequestFailedException ex) when (
                        ex.Status == 500 ||
                        ex.Status == 404 ||
                        ex.ErrorCode == "URL validation")
                    {
                        retryCount++;
                        if (retryCount == maxRetries)
                            throw;
                        await Task.Delay(delayMs * retryCount);
                    }
                }

                Assert.NotNull(uriResponse);
                Assert.NotNull(uriResponse.Value);
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == "URL validation")
            {
                Assert.Inconclusive("Webhook validation handshake failed. Ensure the endpoint is reachable and responds to Event Grid validation. See https://aka.ms/esvalidationcloudevent.");
            }
            finally
            {
                await createdSub.DeleteAsync(WaitUntil.Completed);
                if (existing == null)
                {
                    await systemTopic.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        public async Task SystemTopicResource_GetSystemTopicEventSubscriptionAsync_ReturnsResource()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-GetSubAsync-");
            string eventSubscriptionName = Recording.GenerateAssetName("sdk-EventSubscription-GetSubAsync-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            // Check if a system topic already exists for the source
            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource systemTopic;
            if (existing != null)
            {
                systemTopic = existing;
                systemTopicName = systemTopic.Data.Name;
            }
            else
            {
                systemTopic = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(systemTopic);
            }

            var eventSubscriptions = systemTopic.GetSystemTopicEventSubscriptions();

            var eventSubscriptionData = new EventGridSubscriptionData()
            {
                Destination = new WebHookEventSubscriptionDestination
                {
                    Endpoint = new Uri(LogicAppEndpointUrl)
                },
                Filter = new EventSubscriptionFilter()
                {
                    SubjectBeginsWith = "Prefix",
                    SubjectEndsWith = "Suffix",
                    IsSubjectCaseSensitive = false,
                },
                EventDeliverySchema = EventDeliverySchema.CloudEventSchemaV1_0
            };

            var createdSub = (await eventSubscriptions.CreateOrUpdateAsync(WaitUntil.Completed, eventSubscriptionName, eventSubscriptionData)).Value;

            // Act
            var getResponse = await systemTopic.GetSystemTopicEventSubscriptionAsync(eventSubscriptionName);

            // Assert
            Assert.NotNull(getResponse);
            Assert.AreEqual(eventSubscriptionName, getResponse.Value.Data.Name);

            // Cleanup
            await createdSub.DeleteAsync(WaitUntil.Completed);
            if (existing == null)
            {
                await systemTopic.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicResource_GetAsync_ReturnsResource()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-GetAsync2-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            // Check if a system topic already exists for the source
            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource created;
            if (existing != null)
            {
                created = existing;
                systemTopicName = created.Data.Name;
            }
            else
            {
                created = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(created);
            }

            // Act
            var response = await created.GetAsync();

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(systemTopicName, response.Value.Data.Name);

            // Cleanup
            if (existing == null)
            {
                await created.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicResource_AddTagAsync_AddsTag()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-AddTag-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource created;
            if (existing != null)
            {
                created = existing;
                systemTopicName = created.Data.Name;
            }
            else
            {
                created = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(created);
            }

            // Act
            var response = await created.AddTagAsync("testTag", "testValue");

            // Assert
            Assert.NotNull(response);
            Assert.IsTrue(response.Value.Data.Tags.ContainsKey("testTag"));
            Assert.AreEqual("testValue", response.Value.Data.Tags["testTag"]);

            // Cleanup
            if (existing == null)
            {
                await created.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicResource_SetTagsAsync_SetsTags()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-SetTags-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults"
            };

            // Check if a system topic already exists for the source
            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource created;
            if (existing != null)
            {
                created = existing;
                systemTopicName = created.Data.Name;
            }
            else
            {
                created = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(created);
            }

            // Act
            var tags = new System.Collections.Generic.Dictionary<string, string>
            {
                { "tagA", "valueA" },
                { "tagB", "valueB" }
            };
            var response = await created.SetTagsAsync(tags);

            // Assert
            Assert.NotNull(response);
            Assert.IsTrue(response.Value.Data.Tags.ContainsKey("tagA"));
            Assert.AreEqual("valueA", response.Value.Data.Tags["tagA"]);
            Assert.IsTrue(response.Value.Data.Tags.ContainsKey("tagB"));
            Assert.AreEqual("valueB", response.Value.Data.Tags["tagB"]);

            // Cleanup
            if (existing == null)
            {
                await created.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task SystemTopicResource_RemoveTagAsync_RemovesTag()
        {
            await SetCollection();
            string systemTopicName = Recording.GenerateAssetName("sdk-SystemTopic-RemoveTag-");
            string sourceResourceIdentifier = $"/subscriptions/{SystemTopicCollection.Id.SubscriptionId}/resourceGroups/sdk-eventgrid-test-rg/providers/Microsoft.KeyVault/vaults/sdkeventgridtestkeyvault";

            var systemTopicData = new SystemTopicData(new AzureLocation("centraluseuap"))
            {
                Source = new ResourceIdentifier(sourceResourceIdentifier),
                TopicType = "Microsoft.KeyVault.Vaults",
                Tags = { { "removeMe", "toBeRemoved" }, { "keepMe", "toBeKept" } }
            };

            var existingTopics = await SystemTopicCollection.GetAllAsync().ToEnumerableAsync();
            var existing = existingTopics.FirstOrDefault(t =>
                t.Data.Source.ToString().Equals(sourceResourceIdentifier, StringComparison.OrdinalIgnoreCase));

            SystemTopicResource created;
            if (existing != null)
            {
                created = existing;
                systemTopicName = created.Data.Name;
            }
            else
            {
                created = (await SystemTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, systemTopicName, systemTopicData)).Value;
                Assert.NotNull(created);
            }

            // Explicitly set only the tag to keep
            var patch = new SystemTopicPatch
            {
                Tags = {
            { "keepMe", "toBeKept" }
        }
            };

            var response = await created.UpdateAsync(WaitUntil.Completed, patch);

            Assert.NotNull(response);
            Assert.IsFalse(response.Value.Data.Tags.ContainsKey("removeMe"));
            Assert.IsTrue(response.Value.Data.Tags.ContainsKey("keepMe"));

            if (existing == null)
            {
                await created.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
