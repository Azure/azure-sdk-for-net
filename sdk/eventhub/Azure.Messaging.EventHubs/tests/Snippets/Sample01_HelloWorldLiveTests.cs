// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample01_HelloWorld sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample01_HelloWorldLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CreateClients()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            #region Snippet:EventHubs_Sample01_CreateClients

            var producer = new EventHubProducerClient(connectionString, eventHubName);
            var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
            await consumer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishEvents()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            #region Snippet:EventHubs_Sample01_PublishEvents

            try
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                for (var counter = 0; counter < int.MaxValue; ++counter)
                {
                    var eventBody = new BinaryData($"Event Number: { counter }");
                    var eventData = new EventData(eventBody);

                    if (!eventBatch.TryAdd(eventData))
                    {
                        // At this point, the batch is full but our last event was not
                        // accepted.  For our purposes, the event is unimportant so we
                        // will intentionally ignore it.  In a real-world scenario, a
                        // decision would have to be made as to whether the event should
                        // be dropped or published on its own.

                        break;
                    }
                }

                // When the producer publishes the event, it will receive an
                // acknowledgment from the Event Hubs service; so long as there is no
                // exception thrown by this call, the service assumes responsibility for
                // delivery.  Your event data will be published to one of the Event Hub
                // partitions, though there may be a (very) slight delay until it is
                // available to be consumed.

                await producer.SendAsync(eventBatch);
            }
            catch
            {
                // Transient failures will be automatically retried as part of the
                // operation. If this block is invoked, then the exception was either
                // fatal or all retries were exhausted without a successful publish.
            }
            finally
            {
               await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadEvents()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName);

            #region Snippet:EventHubs_Sample01_ReadEvents

            try
            {
                // To ensure that we do not wait for an indeterminate length of time, we'll
                // stop reading after we receive five events.  For a fresh Event Hub, those
                // will be the first five that we had published.  We'll also ask for
                // cancellation after 90 seconds, just to be safe.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                var maximumEvents = 5;
                var eventDataRead = new List<string>();

                await foreach (PartitionEvent partitionEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    eventDataRead.Add(partitionEvent.Data.EventBody.ToString());

                    if (eventDataRead.Count >= maximumEvents)
                    {
                        break;
                    }
                }

                // At this point, the data sent as the body of each event is held
                // in the eventDataRead set.
            }
            catch
            {
                // Transient failures will be automatically retried as part of the
                // operation. If this block is invoked, then the exception was either
                // fatal or all retries were exhausted without a successful read.
            }
            finally
            {
               await consumer.CloseAsync();
            }

            #endregion
        }
    }
}
