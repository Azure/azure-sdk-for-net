// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.EventGrid.Tests.TestHelper;
using Microsoft.Azure.EventGrid.Tests.Tests;
using Microsoft.Azure.Management.EventGrid;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Microsoft.Azure.EventGrid.Tests.ScenarioTests
{
    public partial class ScenarioTests
    {
        [Fact(Skip = "Requires interactive login")]
        public void PublishEventsToTopic()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var topicName = TestUtilities.GenerateName(EventGridManagementHelper.TopicPrefix);

                var originalTagsDictionary = new Dictionary<string, string>()
                {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                };

                Topic topic = new Topic()
                {
                    Location = location,
                    Tags = originalTagsDictionary
                };

                var createTopicResponse = this.EventGridManagementClient.Topics.CreateOrUpdate(resourceGroup, topicName, topic);

                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                TestUtilities.Wait(TimeSpan.FromSeconds(60));

                // Get the topic key
                TopicSharedAccessKeys keys = this.EventGridManagementClient.Topics.ListSharedAccessKeys(resourceGroup, topicName);

                // Publish events to topic
                string topicHostname = new Uri(createTopicResponse.Endpoint).Host;
                ResourceCredentials credentials = new ResourceCredentials(keys.Key1);

                EventGridClient client = EventGridManagementHelper.GetEventGridClient(
                    context,
                    credentials,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                Console.WriteLine("Publishing to Azure Event Grid Topic");
                client.PublishEventsAsync(topicHostname, GetEventsList()).GetAwaiter().GetResult();
                Console.WriteLine("Published successfully!");

                // Delete topic
                this.EventGridManagementClient.Topics.Delete(resourceGroup, topicName);
            }
        }

        [Fact(Skip = "Requires interactive login")]
        public void PublishEventsToDomain()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventGridManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var domainName = TestUtilities.GenerateName(EventGridManagementHelper.DomainPrefix);
                var originalTagsDictionary = new Dictionary<string, string>()
                {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                };

                Domain domain = new Domain()
                {
                    Location = location,
                    Tags = originalTagsDictionary
                };

                var createDomainResponse = this.EventGridManagementClient.Domains.CreateOrUpdate(resourceGroup, domainName, domain);

                Assert.NotNull(createDomainResponse);
                Assert.Equal(createDomainResponse.Name, domainName);

                TestUtilities.Wait(TimeSpan.FromSeconds(60));

                // Get the domain key
                DomainSharedAccessKeys keys = this.EventGridManagementClient.Domains.ListSharedAccessKeys(resourceGroup, domainName);

                // Publish events to domain
                string domainHostname = new Uri(createDomainResponse.Endpoint).Host;
                ResourceCredentials credentials = new ResourceCredentials(keys.Key1);

                EventGridClient client = EventGridManagementHelper.GetEventGridClient(
                    context,
                    credentials,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                Console.WriteLine("Publishing to Azure Event Grid Domain");
                client.PublishEventsAsync(domainHostname, GetEventsList()).GetAwaiter().GetResult();
                Console.WriteLine("Published successfully!");

                // Delete Domain
                this.EventGridManagementClient.Domains.Delete(resourceGroup, domainName);
            }
        }

        static IList<EventGridEvent> GetEventsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new EventGridEvent()
                {
                    Topic = $"Topic-{i}",
                    Subject = $"Subject-{i}",
                    Id = Guid.NewGuid().ToString(),
                    Data = new EventSpecificData()
                    {
                        Field1 = "Value1",
                        Field2 = "Value2",
                        Field3 = "Value3"
                    },
                    EventTime = DateTime.Now,
                    EventType = "Microsoft.MockPublisher.TestEvent",
                    DataVersion = "1.0"
                });
            }

            return eventsList;
        }
    }
}
