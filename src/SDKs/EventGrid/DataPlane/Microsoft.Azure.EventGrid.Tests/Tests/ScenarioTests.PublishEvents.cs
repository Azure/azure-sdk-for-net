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
        [Fact]
        public void PublishEventsToTopic()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                TopicCredentials topicCredentials = new TopicCredentials(keys.Key1);

                EventGridClient client =  EventGridManagementHelper.GetEventGridClient(
                    context,
                    topicCredentials,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                Console.WriteLine("Publishing to Azure Event Grid");
                client.PublishEventsAsync(topicHostname, GetEventsList()).GetAwaiter().GetResult();
                Console.WriteLine("Published successfully!");

                // Delete topic
                this.EventGridManagementClient.Topics.Delete(resourceGroup, topicName);
            }
        }

        static IList<EventGridEvent> GetEventsList()
        {
            List<EventGridEvent> eventsList = new List<EventGridEvent>();

            for (int i = 0; i < 10; i++)
            {
                eventsList.Add(new EventGridEvent()
                {
                    Id = Guid.NewGuid().ToString(),
                    Data = new EventSpecificData()
                    {
                        Field1 = "Value1",
                        Field2 = "Value2",
                        Field3 = "Value3"
                    },
                    EventTime = DateTime.Now,
                    EventType = "Microsoft.MockPublisher.TestEvent",
                    Subject = "TestSubject",
                    DataVersion = "1.0"
                });
            }

            return eventsList;
        }
    }
}
