// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.ApplicationInsights;

// TODO: update all documentation

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventHubProducerClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events are processed and read. It stops sending events and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class PartitionPublisher
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Publisher" /> instance.</summary>
    private readonly Metrics _metrics;

    /// <summary>The <see cref="TestConfiguration" /> used to configure this test run.</summary>
    private readonly TestConfiguration _testConfiguration;

    /// <summary>The <see cref="PublisherConfiguration" /> used to configure the instance of this role.</summary>
    private readonly PublisherConfiguration _publisherconfiguration;

    private readonly string[] _assignedPartitions;

    private ConcurrentDictionary<string, int> _lastSentPerPartition;

    /// <summary>
    ///   Initializes a new <see cref="Publisher" \> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> used to configure the processor test scenario run.</param>
    /// <param name="publisherConfiguration">The <see cref="PublisherConfiguration" /> instance used to configure this instance of <see cref="Publisher" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public PartitionPublisher(PublisherConfiguration publisherConfiguration,
                              TestConfiguration testConfiguration,
                              Metrics metrics,
                              string[] assignedPartitions)
    {
        _testConfiguration = testConfiguration;
        _publisherconfiguration = publisherConfiguration;
        _metrics = metrics;
        _assignedPartitions = assignedPartitions;

        _lastSentPerPartition = new ConcurrentDictionary<string, int>();

        foreach(var partition in _assignedPartitions)
        {
            _lastSentPerPartition[partition] = -1;
        }
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Publisher"/> role. This role creates an <see cref="EventHubProducerClient"/>
    ///   and monitors it while it sends events to this test's dedicated Event Hub.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task Start(CancellationToken cancellationToken)
    {
        var producersRunning = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            foreach(var partition in _assignedPartitions)
            {
                producersRunning.Add(RunPartitionSpecificProducer(partition, backgroundCancellationSource.Token));
            }

            await Task.WhenAll(producersRunning).ConfigureAwait(false);
        }
    }

    private async Task RunPartitionSpecificProducer(string partitionId, CancellationToken cancellationToken)
    {
        var options = new EventHubProducerClientOptions
        {
            RetryOptions = new EventHubsRetryOptions
            {
                TryTimeout = _publisherconfiguration.SendTimeout
            }
        };
        var producer = new EventHubProducerClient(_testConfiguration.EventHubsConnectionString, _testConfiguration.EventHub, options);
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // send 
                await PerformSend(producer, partitionId, cancellationToken).ConfigureAwait(false);
                // 
                if ((_publisherconfiguration.ProducerPublishingDelay.HasValue) && (_publisherconfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                {
                    await Task.Delay(_publisherconfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                _metrics.Client.GetMetric(Metrics.ProducerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                await producer.CloseAsync().ConfigureAwait(false);
            }
        }

    }

    /// <summary>
    ///   Performs the actual sends to the Event Hub for this particular test, using the <see cref="EventHubProducerClient" /> parameter.
    ///   This method generates events using the <see cref="PublisherConfiguration" />  configurations.
    /// </summary>
    ///
    /// <param name="producer">The <see cref="EventHubProducerClient" /> to send events to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task PerformSend(EventHubProducerClient producer,
                                   string partitionId,
                                   CancellationToken cancellationToken)
    {
        // Create the batch and generate a set of random events, keeping only those that were able to fit into the batch.
        // Because there is a side-effect of TryAdd in the statement, ensure that ToList is called to materialize the set
        // or the batch will be empty at send.

        var batchOptions = new CreateBatchOptions
        {
            PartitionId = partitionId
        };

        using var batch = await producer.CreateBatchAsync(batchOptions).ConfigureAwait(false);

        var observableBatch = new List<EventData>();

        var events = EventGenerator.CreateEvents(batch.MaximumSizeInBytes,
                                                 _publisherconfiguration.PublishBatchSize,
                                                 _publisherconfiguration.LargeMessageRandomFactorPercent,
                                                 _publisherconfiguration.PublishingBodyMinBytes,
                                                 _publisherconfiguration.PublishingBodyRegularMaxBytes);

        foreach (var currentEvent in events)
        {
            var currentSequenceNumber = _lastSentPerPartition.AddOrUpdate(partitionId, -1, (k,v) => v++);
            EventTracking.AugmentEvent(currentEvent, currentSequenceNumber, partitionId);

            if (!batch.TryAdd(currentEvent))
            {
                _lastSentPerPartition.AddOrUpdate(partitionId, -1, (k,v) => v--);
                break;
            }

            observableBatch.Add(currentEvent);
        }

        // Publish the events and report them, capturing any failures specific to the send operation.

        try
        {
            if (batch.Count > 0)
            {
                _metrics.Client.GetMetric(Metrics.PublishAttempts).TrackValue(1);

                await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
            }

            _metrics.Client.GetMetric(Metrics.EventsPublished).TrackValue(batch.Count);
            _metrics.Client.GetMetric(Metrics.BatchesPublished).TrackValue(1);
            _metrics.Client.GetMetric(Metrics.TotalPublishedSizeBytes).TrackValue(batch.SizeInBytes);
        }
        catch (TaskCanceledException)
        {
            _metrics.Client.GetMetric(Metrics.PublishAttempts).TrackValue(-1);
        }
        catch (Exception ex)
        {
            var exceptionProperties = new Dictionary<String, String>();
            exceptionProperties.Add("Process", "Send");

            _metrics.Client.TrackException(ex, exceptionProperties);

            foreach (var failedEvent in observableBatch)
            {
                failedEvent.Properties.TryGetValue(EventTracking.SequencePropertyName, out var failedSequenceNumber);
                var eventProperties = new Dictionary<String, String>();
                eventProperties.Add(Metrics.PartitionId, partitionId);
                eventProperties.Add(Metrics.PublisherAssignedSequenceValue, failedSequenceNumber.ToString());

                _metrics.Client.TrackEvent(Metrics.EventsFailedToPublish, eventProperties);
            }
        }
    }
}