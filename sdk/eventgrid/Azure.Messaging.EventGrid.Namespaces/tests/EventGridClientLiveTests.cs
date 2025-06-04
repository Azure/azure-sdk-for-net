// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Messaging.EventGrid.Namespaces;
using CloudNative.CloudEvents.SystemTextJson;
using NUnit.Framework;
using ContentType = System.Net.Mime.ContentType;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridClientLiveTests : RecordedTestBase<EventGridTestEnvironment>
    {
        public EventGridClientLiveTests(bool isAsync) : base(isAsync)
        {
            // TODO issue with JSON comparison in binary mode
            CompareBodies = false;
        }

        [RecordedTest]
        public async Task EndToEnd()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            #region Snippet:CreateNamespaceClient
#if SNIPPET
            // Construct the client using an Endpoint for a namespace as well as the shared access key
            var senderClient = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey));
#else
            var senderClient = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridSenderClientOptions())));
#endif
            #endregion

            #region Snippet:PublishSingleEvent

#if SNIPPET
            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 });
#else
            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
#endif
            await senderClient.SendAsync(evt);
            #endregion

            #region Snippet:PublishBatchOfEvents
#if SNIPPET
            await senderClient.SendAsync(
                new[] {
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Tom", Age = 55 }),
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Alice", Age = 25 })
                });
#else
            await senderClient.SendAsync(
                new[] {
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Tom", Age = 55 })
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        Time = Recording.Now
                    },
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Alice", Age = 25 })
                    {
                        Id = Recording.Random.NewGuid().ToString(),
                        Time = Recording.Now
                    }
                });
#endif
            #endregion

            #region Snippet:ReceiveAndProcessEvents
#if SNIPPET
            // Construct the client using an Endpoint for a namespace as well as the shared access key
            var receiverClient = new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey));
#else
            var receiverClient = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridReceiverClientOptions())));
#endif
            ReceiveResult result = await receiverClient.ReceiveAsync(maxEvents: 3);

            // Iterate through the results and collect the lock tokens for events we want to release/acknowledge/result
            var toRelease = new List<string>();
            var toAcknowledge = new List<string>();
            var toReject = new List<string>();
            foreach (ReceiveDetails detail in result.Details)
            {
                CloudEvent @event = detail.Event;
                BrokerProperties brokerProperties = detail.BrokerProperties;
                Console.WriteLine(@event.Data.ToString());

                // The lock token is used to acknowledge, reject or release the event
                Console.WriteLine(brokerProperties.LockToken);

                var data = @event.Data.ToObjectFromJson<TestModel>();
                // If the data from the event has Name "Bob", we are not able to acknowledge it yet,
                // so we release it, thereby allowing other consumers to receive it.
                if (data.Name == "Bob")
                {
                    toRelease.Add(brokerProperties.LockToken);
                }
                // If the data is for "Tom", we will acknowledge it thereby deleting it from the subscription.
                else if (data.Name == "Tom")
                {
                    toAcknowledge.Add(brokerProperties.LockToken);
                }
                // reject all other events which will move the event to the dead letter queue if it is configured
                else
                {
                    toReject.Add(brokerProperties.LockToken);
                }
            }

            if (toRelease.Count > 0)
            {
                ReleaseResult releaseResult = await receiverClient.ReleaseAsync(toRelease);

                // Inspect the Release result
                Console.WriteLine($"Failed count for Release: {releaseResult.FailedLockTokens.Count}");
                foreach (FailedLockToken failedLockToken in releaseResult.FailedLockTokens)
                {
                    Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
                    Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
                    Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
                }

                Console.WriteLine($"Success count for Release: {releaseResult.SucceededLockTokens.Count}");
                foreach (string lockToken in releaseResult.SucceededLockTokens)
                {
                    Console.WriteLine($"Lock Token: {lockToken}");
                }
            }

            if (toAcknowledge.Count > 0)
            {
                AcknowledgeResult acknowledgeResult = await receiverClient.AcknowledgeAsync(toAcknowledge);

                // Inspect the Acknowledge result
                Console.WriteLine($"Failed count for Acknowledge: {acknowledgeResult.FailedLockTokens.Count}");
                foreach (FailedLockToken failedLockToken in acknowledgeResult.FailedLockTokens)
                {
                    Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
                    Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
                    Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
                }

                Console.WriteLine($"Success count for Acknowledge: {acknowledgeResult.SucceededLockTokens.Count}");
                foreach (string lockToken in acknowledgeResult.SucceededLockTokens)
                {
                    Console.WriteLine($"Lock Token: {lockToken}");
                }
            }

            if (toReject.Count > 0)
            {
                RejectResult rejectResult = await receiverClient.RejectAsync(toReject);

                // Inspect the Reject result
                Console.WriteLine($"Failed count for Reject: {rejectResult.FailedLockTokens.Count}");
                foreach (FailedLockToken failedLockToken in rejectResult.FailedLockTokens)
                {
                    Console.WriteLine($"Lock Token: {failedLockToken.LockToken}");
                    Console.WriteLine($"Error Code: {failedLockToken.Error.Code}");
                    Console.WriteLine($"Error Description: {failedLockToken.Error.Message}");
                }

                Console.WriteLine($"Success count for Reject: {rejectResult.SucceededLockTokens.Count}");
                foreach (string lockToken in rejectResult.SucceededLockTokens)
                {
                    Console.WriteLine($"Lock Token: {lockToken}");
                }
            }
            #endregion
        }

        [RecordedTest]
        public async Task RenewLocks()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            #region Snippet:CreateNamespaceClientAAD
#if SNIPPET
            // Construct the sender client using an Endpoint for a namespace as well as the DefaultAzureCredential
            var senderClient = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new DefaultAzureCredential());
#else
            var senderClient = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, TestEnvironment.Credential, InstrumentClientOptions(new EventGridSenderClientOptions())));
#endif
            #endregion

            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
            await senderClient.SendAsync(evt);

#if SNIPPET
            // Construct the receiver client using an Endpoint for a namespace as well as the DefaultAzureCredential
            var receiverClient = new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new DefaultAzureCredential());
#else
            var receiverClient = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, TestEnvironment.Credential, InstrumentClientOptions(new EventGridReceiverClientOptions())));
#endif

            ReceiveResult result = await receiverClient.ReceiveAsync(maxEvents: 1);
            RenewLocksResult renewResult = await receiverClient.RenewLocksAsync(new[] { result.Details.First().BrokerProperties.LockToken });
            Assert.IsEmpty(renewResult.FailedLockTokens);
        }

        [RecordedTest]
        public async Task ReleaseWithDelay()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            var client = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridSenderClientOptions())));

            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
            await client.SendAsync(evt);

            var receiver = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridReceiverClientOptions())));
            ReceiveResult result = await receiver.ReceiveAsync(maxEvents: 1);
            ReleaseResult releaseResult = await receiver.ReleaseAsync(
                new[] { result.Details.First().BrokerProperties.LockToken },
                delay: ReleaseDelay.TenSeconds);
            Assert.IsEmpty(releaseResult.FailedLockTokens);
        }

        [RecordedTest]
        public async Task Reject()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            var client = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridSenderClientOptions())));

            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
            await client.SendAsync(evt);

            var receiver = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridReceiverClientOptions())));
            ReceiveResult result = await receiver.ReceiveAsync(maxEvents: 1);
            RejectResult rejectResult = await receiver.RejectAsync(new[] { result.Details.First().BrokerProperties.LockToken });
            Assert.IsEmpty(rejectResult.FailedLockTokens);
        }

        [RecordedTest]
        public async Task Acknowledge()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            var client = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridSenderClientOptions())));

            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
            await client.SendAsync(evt);

            var receiver = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridReceiverClientOptions())));
            ReceiveResult result = await receiver.ReceiveAsync(maxEvents: 1);
            AcknowledgeResult acknowledgeResult = await receiver.AcknowledgeAsync(new[] { result.Details.First().BrokerProperties.LockToken });
            Assert.IsEmpty(acknowledgeResult.FailedLockTokens);
        }

        [RecordedTest]
        public async Task RoundTripCNCFEvent()
        {
            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            #region Snippet:SendCNCFEvent
            var evt = new CloudNative.CloudEvents.CloudEvent
            {
                Source = new Uri("http://localHost"),
                Type = "type",
                Data = new TestModel { Name = "Bob", Age = 18 },
                Id = Recording.Random.NewGuid().ToString()
            };
            var jsonFormatter = new JsonEventFormatter();
#if SNIPPET
            var sender = new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey));
#else
            var sender = InstrumentClient(new EventGridSenderClient(new Uri(namespaceTopicHost), topicName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridSenderClientOptions())));
#endif
            await sender.SendEventAsync(RequestContent.Create(jsonFormatter.EncodeStructuredModeMessage(evt, out _)));
            #endregion
            #region Snippet:ReceiveCNCFEvent
#if SNIPPET
            var receiver = new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey));
#else
            var receiver = InstrumentClient(new EventGridReceiverClient(new Uri(namespaceTopicHost), topicName, subscriptionName, new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridReceiverClientOptions())));
#endif
            Response response = await receiver.ReceiveAsync(maxEvents: 1, maxWaitTime: TimeSpan.FromSeconds(10), new RequestContext());

            var eventResponse = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase).Value[0];
            var receivedCloudEvent = jsonFormatter.DecodeStructuredModeMessage(
                Encoding.UTF8.GetBytes(eventResponse.Event.ToString()),
                new ContentType("application/cloudevents+json"),
                null);
            #endregion
            Assert.AreEqual(evt.Source, receivedCloudEvent.Source);
            Assert.AreEqual(evt.Type, receivedCloudEvent.Type);
            Assert.AreEqual(evt.Id, receivedCloudEvent.Id);

            #region Snippet:AcknowledgeCNCFEvent
            AcknowledgeResult acknowledgeResult = await receiver.AcknowledgeAsync(new string[] { eventResponse.BrokerProperties.LockToken.ToString() });
            #endregion
            Assert.IsEmpty(acknowledgeResult.FailedLockTokens);
        }

        public class TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [SetUp]
        public async Task InitializeTest()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            var namespaceTopicHost = TestEnvironment.NamespaceTopicHost;
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            var client = new EventGridReceiverClient(
                new Uri(namespaceTopicHost),
                topicName,
                subscriptionName, new AzureKeyCredential(namespaceKey));

            ReceiveResult results;
            do
            {
                results = await client.ReceiveAsync(maxEvents: 100, maxWaitTime: TimeSpan.FromSeconds(10));
                await client.AcknowledgeAsync(results.Details.Select(r => r.BrokerProperties.LockToken).ToList());
            } while (results.Details.Count > 0);
        }
    }
}
