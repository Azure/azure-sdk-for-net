// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid.Namespaces;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridNamespaceClientLiveTests : EventGridLiveTestBase
    {
        public EventGridNamespaceClientLiveTests(bool isAsync) : base(isAsync)
        {
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
            var client = new EventGridClient(new Uri(namespaceTopicHost), new AzureKeyCredential(namespaceKey));
#else
            var client = InstrumentClient(new EventGridClient(new Uri(namespaceTopicHost), new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridClientOptions())));
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
            await client.PublishCloudEventAsync(topicName, evt);
            #endregion

            #region Snippet:PublishBatchOfEvents
#if SNIPPET
            await client.PublishCloudEventsAsync(
                topicName,
                new[] {
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Tom", Age = 55 }),
                    new CloudEvent("employee_source", "type", new TestModel { Name = "Alice", Age = 25 })
                });
#else
            await client.PublishCloudEventsAsync(
                topicName,
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
            ReceiveResult result = await client.ReceiveCloudEventsAsync(topicName, subscriptionName, maxEvents: 3);

            // Iterate through the results and collect the lock tokens for events we want to release/acknowledge/result
            var toRelease = new List<string>();
            var toAcknowledge = new List<string>();
            var toReject = new List<string>();
            foreach (ReceiveDetails detail in result.Value)
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
                ReleaseResult releaseResult = await client.ReleaseCloudEventsAsync(topicName, subscriptionName, new ReleaseOptions(toRelease));

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
                AcknowledgeResult acknowledgeResult = await client.AcknowledgeCloudEventsAsync(topicName, subscriptionName, new AcknowledgeOptions(toAcknowledge));

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
                RejectResult rejectResult = await client.RejectCloudEventsAsync(topicName, subscriptionName, new RejectOptions(toReject));

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
            var namespaceKey = TestEnvironment.NamespaceKey;
            var topicName = TestEnvironment.NamespaceTopicName;
            var subscriptionName = TestEnvironment.NamespaceSubscriptionName;

            var client = InstrumentClient(new EventGridClient(new Uri(namespaceTopicHost),
                new AzureKeyCredential(namespaceKey), InstrumentClientOptions(new EventGridClientOptions())));

            var evt = new CloudEvent("employee_source", "type", new TestModel { Name = "Bob", Age = 18 })
            {
                Id = Recording.Random.NewGuid().ToString(),
                Time = Recording.Now
            };
            await client.PublishCloudEventAsync(topicName, evt);

            ReceiveResult result = await client.ReceiveCloudEventsAsync(topicName, subscriptionName, maxEvents: 1);
            RenewCloudEventLocksResult renewResult = await client.RenewCloudEventLocksAsync(topicName, subscriptionName,
                new RenewLockOptions(new[] { result.Value.First().BrokerProperties.LockToken }));
            Assert.IsEmpty(renewResult.FailedLockTokens);
        }

        public class TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}