// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests.Scenario
{
    public class NamespaceTopicTests : EventGridManagementTestBase
    {
        public NamespaceTopicTests(bool isAsync) : base(isAsync) { }

        // Decoded ampersands in the URL
        // from the Azure Portal for "sdk-test-logic-app" -> workflowUrl.
        private const string LogicAppEndpointUrl = "https://prod-16.centraluseuap.logic.azure.com:443/workflows/9ace43ec97744a61acea5db9feaae8af/triggers/When_a_HTTP_request_is_received/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_a_HTTP_request_is_received%2Frun&sv=SANITIZED_FUNCTION_KEY&sig=SANITIZED_FUNCTION_KEY";

        private ResourceGroupResource _resourceGroup;
        private EventGridNamespaceResource _namespace;
        private NamespaceTopicResource _topic;
        private NamespaceTopicEventSubscriptionResource _subscription;

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-rg-"), DefaultLocation);
            var namespaceCollection = _resourceGroup.GetEventGridNamespaces();

            var nsName = Recording.GenerateAssetName("sdk-ns-");
            var nsData = new EventGridNamespaceData(DefaultLocation);

            _namespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nsName, nsData)).Value;

            var topicCollection = _namespace.GetNamespaceTopics();
            var topicName = Recording.GenerateAssetName("sdk-topic-");
            _topic = (await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new NamespaceTopicData())).Value;

            var subCollection = _topic.GetNamespaceTopicEventSubscriptions();
            var subName = Recording.GenerateAssetName("sdk-sub-");

            var eventSubscription = new NamespaceTopicEventSubscriptionData
            {
                DeliveryConfiguration = new DeliveryConfiguration
                {
                    DeliveryMode = DeliveryMode.Push,
                    Push = new PushInfo
                    {
                        Destination = new WebHookEventSubscriptionDestination
                        {
                            Endpoint = new Uri(LogicAppEndpointUrl)
                        }
                    }
                },
                FiltersConfiguration = new FiltersConfiguration
                {
                    Filters =
                    {
                        new StringBeginsWithFilter(FilterOperatorType.StringBeginsWith, "subject", null, new List<string> { "TestPrefix" }),
                        new StringEndsWithFilter(FilterOperatorType.StringEndsWith, "subject", null, new List<string> { "TestSuffix" })
                    }
                },
                EventDeliverySchema = DeliverySchema.CloudEventSchemaV10,
            };

            var operation = await subCollection.CreateOrUpdateAsync(WaitUntil.Completed, subName, eventSubscription);
            _subscription = operation.Value;
        }

        [Test]
        public async Task NamespaceTopicCollection_GetAsync()
        {
            var topicCollection = _namespace.GetNamespaceTopics();
            var fetched = (await topicCollection.GetAsync(_topic.Data.Name)).Value;
            Assert.NotNull(fetched);
            Assert.AreEqual(_topic.Data.Name, fetched.Data.Name);
        }

        [Test]
        public async Task NamespaceTopicEventSubscriptionResource_GetAsync()
        {
            var fetched = (await _subscription.GetAsync()).Value;
            Assert.NotNull(fetched);
            Assert.AreEqual(_subscription.Data.Name, fetched.Data.Name);
        }

        [Test]
        public async Task NamespaceTopicEventSubscriptionResource_RemoveTagAsync()
        {
            await _subscription.AddTagAsync("removeMe", "yes");
            await _subscription.RemoveTagAsync("removeMe");
            var updated = (await _subscription.GetAsync()).Value;
            Assert.IsFalse(updated.Data.Tags.ContainsKey("removeMe"));
        }

        [Test]
        public async Task NamespaceTopicResource_GetNamespaceTopicEventSubscriptionAsync()
        {
            var fetched = (await _topic.GetNamespaceTopicEventSubscriptionAsync(_subscription.Data.Name)).Value;
            Assert.NotNull(fetched);
            Assert.AreEqual(_subscription.Data.Name, fetched.Data.Name);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_subscription != null)
                    await _subscription.DeleteAsync(WaitUntil.Completed);
                if (_topic != null)
                    await _topic.DeleteAsync(WaitUntil.Completed);
                if (_namespace != null)
                    await _namespace.DeleteAsync(WaitUntil.Completed);
                if (_resourceGroup != null)
                    await _resourceGroup.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
