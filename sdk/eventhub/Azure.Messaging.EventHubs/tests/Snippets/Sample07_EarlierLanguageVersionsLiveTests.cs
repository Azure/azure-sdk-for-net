// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    ///   Sample07_EarlierLanguageVersions sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample07_EarlierLanguageVersionsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Publish()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample07_Publish

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using (var eventBatch = await producer.CreateBatchAsync())
                {
                  var eventBody = new BinaryData("This is an event body");
                  var eventData = new EventData(eventBody);

                  if (!eventBatch.TryAdd(eventData))
                  {
                      throw new Exception($"The event could not be added.");
                  }
                }
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
        public async Task ReadAllPartitions()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample07_ReadAllPartitions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName);

            try
            {
                using (CancellationTokenSource cancellationSource = new CancellationTokenSource())
                {
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                    int eventsRead = 0;
                    int maximumEvents = 50;

                    IAsyncEnumerator<PartitionEvent> iterator =
                        consumer.ReadEventsAsync(cancellationSource.Token).GetAsyncEnumerator();

                    try
                    {
                        while (await iterator.MoveNextAsync())
                        {
                            PartitionEvent partitionEvent = iterator.Current;
                            string readFromPartition = partitionEvent.Partition.PartitionId;
                            byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                            Debug.WriteLine($"Read event of length { eventBodyBytes.Length } from { readFromPartition }");
                            eventsRead++;

                            if (eventsRead >= maximumEvents)
                            {
                                break;
                            }
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // This is expected if the cancellation token is
                        // signaled.
                    }
                    finally
                    {
                        await iterator.DisposeAsync();
                    }
                }
            }
            finally
            {
                await consumer.CloseAsync();
            }

            #endregion
        }
    }
}
