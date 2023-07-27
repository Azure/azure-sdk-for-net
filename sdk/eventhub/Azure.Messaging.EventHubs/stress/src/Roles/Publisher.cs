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

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventHubProducerClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events and batches are published. It stops sending events and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class Publisher
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Publisher" /> instance.</summary>
    private readonly Metrics _metrics;

    /// <summary>The <see cref="TestParameters" /> used to run the test scenario running this role.</summary>
    private readonly TestParameters _testParameters;

    /// <summary>The <see cref="PublisherConfiguration" /> used to configure the instance of this role.</summary>
    private readonly PublisherConfiguration _publisherconfiguration;

    /// <summary>
    ///   Initializes a new <see cref="Publisher" \> instance.
    /// </summary>
    ///
    /// <param name="publisherConfiguration">The <see cref="PublisherConfiguration" /> instance used to configure this instance of <see cref="Publisher" />.</param>
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the test scenario running this publishing role.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public Publisher(PublisherConfiguration publisherConfiguration,
                     TestParameters testParameters,
                     Metrics metrics)
    {
        _testParameters = testParameters;
        _publisherconfiguration = publisherConfiguration;
        _metrics = metrics;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Publisher"/> role. This role creates an <see cref="EventHubProducerClient"/>
    ///   and monitors it while it sends events to this test's dedicated Event Hub.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var sendTasks = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            var options = new EventHubProducerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    TryTimeout = _publisherconfiguration.SendTimeout
                }
            };
            var producer = new EventHubProducerClient(_testParameters.EventHubsConnectionString, _testParameters.EventHub, options);

            try
            {
                sendTasks.Clear();

                // Create a set of background tasks to handle all but one of the concurrent sends.  The final
                // send will be performed directly.

                if (_publisherconfiguration.ConcurrentSends > 1)
                {
                    for (var index = 0; index < _publisherconfiguration.ConcurrentSends - 1; ++index)
                    {
                        sendTasks.Add(Task.Run(async () =>
                        {
                            while (!backgroundCancellationSource.Token.IsCancellationRequested)
                            {
                                await PerformSendAsync(producer, backgroundCancellationSource.Token).ConfigureAwait(false);

                                if ((_publisherconfiguration.ProducerPublishingDelay.HasValue) && (_publisherconfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                                {
                                    await Task.Delay(_publisherconfiguration.ProducerPublishingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
                                }
                            }
                        }));
                    }
                }
                // Perform one of the sends in the foreground, which will allow easier detection of a
                // processor-level issue.

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await PerformSendAsync(producer, cancellationToken).ConfigureAwait(false);

                        if ((_publisherconfiguration.ProducerPublishingDelay.HasValue) && (_publisherconfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                        {
                            await Task.Delay(_publisherconfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        backgroundCancellationSource.Cancel();
                        await Task.WhenAll(sendTasks).ConfigureAwait(false);
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
                // If this catch is hit, there's a problem with the producer itself; cancel the
                // background sending and wait before allowing the producer to restart.

                backgroundCancellationSource.Cancel();
                await Task.WhenAll(sendTasks).ConfigureAwait(false);

                _metrics.Client.GetMetric(Metrics.ProducerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                _metrics.Client.TrackEvent("Stopping publishing events.");
                await producer.CloseAsync();
            }
        }
    }

    /// <summary>
    ///   Performs the actual sends to the Event Hub for this particular test, using the <see cref="EventHubProducerClient" /> parameter.
    ///   This method generates events using the <see cref="PublisherConfiguration" />  configurations.
    /// </summary>
    ///
    /// <param name="producer">The <see cref="EventHubProducerClient" /> to send events to.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToke"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task PerformSendAsync(EventHubProducerClient producer,
                                        CancellationToken cancellationToken)
    {
        // Create the batch and generate a set of random events, keeping only those that were able to fit into the batch.
        // Because there is a side-effect of TryAdd in the statement, ensure that ToList is called to materialize the set
        // or the batch will be empty at send.

        using var batch = await producer.CreateBatchAsync().ConfigureAwait(false);

        var events = EventGenerator.CreateEvents(batch.MaximumSizeInBytes,
                                                 _publisherconfiguration.PublishBatchSize,
                                                 _publisherconfiguration.LargeMessageRandomFactorPercent,
                                                 _publisherconfiguration.PublishingBodyMinBytes,
                                                 _publisherconfiguration.PublishingBodyRegularMaxBytes);

        foreach (var currentEvent in events)
        {
            if (!batch.TryAdd(currentEvent))
            {
                break;
            }
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
        }
    }
}