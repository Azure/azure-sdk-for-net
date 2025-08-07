// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   README.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class ReadMeSnippetsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CreateWithConnectionString()
        {
            #region Snippet:EventHubs_ReadMe_Create_ConnectionString

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = "fake";
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using var producer = new EventHubProducerClient(connectionString, eventHubName);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Inspect()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_ReadMe_Inspect

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
            {
                string[] partitionIds = await producer.GetPartitionIdsAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Publish()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_ReadMe_Publish

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                if ((!eventBatch.TryAdd(new EventData("First"))) ||
                    (!eventBatch.TryAdd(new EventData("Second"))))
                {
                   throw new ApplicationException("Not all events could be added to the batch!");
                }

                await producer.SendAsync(eventBatch);
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Read()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            try
            {
                #region Snippet:EventHubs_ReadMe_Read

#if SNIPPET
                var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
                var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
                var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                var eventHubName = scope.EventHubName;
#endif

                string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

                // It is recommended that you cache the Event Hubs clients for the lifetime of your
                // application, closing or disposing when application ends.  This example disposes
                // after the immediate scope for simplicity.

                await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
                {
                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                    {
                        // At this point, the loop will wait for events to be available in the Event Hub.  When an event
                        // is available, the loop will iterate with the event that was received.  Because we did not
                        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                        // the cancellation token.
                    }
                }

                #endregion
            }
            catch (TaskCanceledException)
            {
                // Expected
            }
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            try
            {
                #region Snippet:EventHubs_ReadMe_ReadPartition

#if SNIPPET
                var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
                var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
                var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                var eventHubName = scope.EventHubName;
#endif

                string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

                // It is recommended that you cache the Event Hubs clients for the lifetime of your
                // application, closing or disposing when application ends.  This example disposes
                // after the immediate scope for simplicity.

                await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
                {
                    EventPosition startingPosition = EventPosition.Earliest;
                    string partitionId = (await consumer.GetPartitionIdsAsync()).First();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsFromPartitionAsync(partitionId, startingPosition, cancellationSource.Token))
                    {
                        // At this point, the loop will wait for events to be available in the partition.  When an event
                        // is available, the loop will iterate with the event that was received.  Because we did not
                        // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                        // the cancellation token.
                    }
                }

                #endregion
            }
            catch (TaskCanceledException)
            {
                // Expected
            }
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task PublishIdentity()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_ReadMe_PublishIdentity

#if SNIPPET
            var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = scope.EventHubName;
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            // It is recommended that you cache the Event Hubs clients for the lifetime of your
            // application, closing or disposing when application ends.  This example disposes
            // after the immediate scope for simplicity.

            await using (var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential))
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                if ((!eventBatch.TryAdd(new EventData("First"))) ||
                    (!eventBatch.TryAdd(new EventData("Second"))))
                {
                   throw new ApplicationException("Not all events could be added to the batch!");
                }

                await producer.SendAsync(eventBatch);
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ExceptionFilter()
        {
            #region Snippet:EventHubs_ReadMe_ExceptionFilter

            try
            {
                // Read events using the consumer client
            }
            catch (EventHubsException ex) when
                (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
            {
                // Take action based on a consumer being disconnected
            }

            #endregion
        }
    }
}
