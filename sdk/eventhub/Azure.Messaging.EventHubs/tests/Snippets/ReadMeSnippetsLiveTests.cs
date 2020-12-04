// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
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
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class ReadMeSnippetsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Inspect()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_ReadMe_Inspect

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

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

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();
                eventBatch.TryAdd(new EventData(new BinaryData("First")));
                eventBatch.TryAdd(new EventData(new BinaryData("Second")));

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

                var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
                var eventHubName = "<< NAME OF THE EVENT HUB >>";
                /*@@*/
                /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                /*@@*/ eventHubName = scope.EventHubName;

                string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

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

                var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
                var eventHubName = "<< NAME OF THE EVENT HUB >>";
                /*@@*/
                /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                /*@@*/ eventHubName = scope.EventHubName;

                string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

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

            TokenCredential credential = new DefaultAzureCredential();
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = scope.EventHubName;

            await using (var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential))
            {
                using EventDataBatch eventBatch = await producer.CreateBatchAsync();
                eventBatch.TryAdd(new EventData(new BinaryData("First")));
                eventBatch.TryAdd(new EventData(new BinaryData("Second")));

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
