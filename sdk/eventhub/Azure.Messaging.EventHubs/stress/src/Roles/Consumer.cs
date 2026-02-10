// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventHubConsumerClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events are received and read. It stops reading events and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class Consumer
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Consumer" /> instance.</summary>
    private Metrics _metrics { get; }

    /// <summary>The <see cref="TestParameters" /> used to run this test.</summary>
    private TestParameters _testParameters { get; }

    /// <summary>The <see cref="ConsumerConfiguration" /> used to configure the instance of this role.</summary>
    private ConsumerConfiguration _consumerConfiguration { get; }

    /// <summary> The last received sequence value for each partition.</summary>
    private ConcurrentDictionary<string, int> _lastReceivedSequence = new ConcurrentDictionary<string, int>();

    /// <summary>Holds the set of events that have been read by this instance. The key is the unique Id set by the producer.</summary>
    private ConcurrentDictionary<string, byte> _readEvents { get; }

    /// <summary>Holds the last read sequence value for each partition this instance has read from so far.</summary>
    private ConcurrentDictionary<string, int> _lastReadPartitionSequence { get; }

    /// <summary>
    ///   Initializes a new <see cref="Consumer" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> used to configure the processor test scenario run.</param>
    /// <param name="consumerConfiguration">The <see cref="ConsumerConfiguration"/> instance used to configure this instance of <see cref="Processor" />.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send metrics to Application Insights.</param>
    /// <param name="readEvents">The dictionary holding the key values of the unique Id's of all the events that have been read so far.</param>
    /// <param name="lastReadPartitionSequence">The dictionary mapping each partition to the last read sequence for tbat partition.</param>
    ///
    public Consumer(TestParameters testParameters,
                     ConsumerConfiguration consumerConfiguration,
                     Metrics metrics,
                     ConcurrentDictionary<string, byte> readEvents,
                     ConcurrentDictionary<string, int> lastReadPartitionSequence)
    {
        _testParameters = testParameters;
        _consumerConfiguration = consumerConfiguration;
        _metrics = metrics;
        _readEvents = readEvents;
        _lastReadPartitionSequence = lastReadPartitionSequence;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Consumer"/> role. This role creates an <see cref="EventHubConsumerClient"/>
    ///   for each partition and monitors them while they read events that have been sent to this test's Event Hub by independent
    ///   <see cref="Publisher"/> role(s).
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var consumerTasks = new Dictionary<string, Task>();
        var partitionIds = await _testParameters.GetEventHubPartitionsAsync();

        foreach (var partitionId in partitionIds)
        {
            consumerTasks[partitionId] = ConsumePartitionAsync(partitionId, cancellationToken);
        }

        await Task.WhenAll(consumerTasks.Values).ConfigureAwait(false);
    }

    /// <summary>
    ///   Runs an <see cref="EventHubConsumerClient"/> instance that reads events from a single partition.
    /// </summary>
    ////
    /// <param name="partitionId">The Id of the partition to read events from.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task ConsumePartitionAsync(string partitionId,
                                             CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, _testParameters.EventHubsConnectionString, _testParameters.EventHub);
            try
            {
                var seenPartition = _lastReceivedSequence.TryGetValue(partitionId, out int sequenceNumber);
                var eventPosition = seenPartition ? EventPosition.FromSequenceNumber(sequenceNumber, false) : EventPosition.Latest;

                var options = new ReadEventOptions
                {
                    MaximumWaitTime = _consumerConfiguration.MaximumWaitTime
                };

                await foreach (var receivedEvent in consumerClient.ReadEventsFromPartitionAsync(partitionId, eventPosition, options, cancellationToken))
                {
                    if (receivedEvent.Data != null)
                    {
                        EventTracking.ConsumeEvent(receivedEvent, _metrics, _testParameters.Sha256Hash, _lastReadPartitionSequence, _readEvents);
                        _metrics.Client.GetMetric(Metrics.EventsRead).TrackValue(1);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // No action needed.
            }
            catch (Exception ex) when
                (ex is OutOfMemoryException
                || ex is StackOverflowException
                || ex is ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _metrics.Client.GetMetric(Metrics.ConsumerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                await consumerClient.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}