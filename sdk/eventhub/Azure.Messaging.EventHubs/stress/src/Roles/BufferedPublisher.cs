// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventHubBufferedProducerClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events are processed and read. It stops sending events and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class BufferedPublisher
{
    /// <summary>The <see cref="Metrics"/> instance associated with this <see cref="BufferedPublisher"/> instance.</summary>
    private readonly Metrics _metrics;

    /// <summary>The <see cref="BufferedPublisherConfiguration"/> used to configure the instance of this role.</summary>
    private readonly BufferedPublisherConfiguration _bufferedPublisherConfiguration;

    /// <summary>The <see cref="TestParameters"/> used to configure this test run.</summary>
    private readonly TestParameters _testParameters;

    /// <summary>
    ///   Initializes a new <see cref="BufferedPublisher"\> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the processor test scenario run.</param>
    /// <param name="bufferedPublisherConfiguration">The <see cref="BufferedPublisherConfiguration" /> instance used to configure this instance of <see cref="BufferedPublisher" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public BufferedPublisher(TestParameters testParameters,
                             BufferedPublisherConfiguration bufferedPublisherConfiguration,
                             Metrics metrics)
    {
        _metrics = metrics;
        _testParameters = testParameters;
        _bufferedPublisherConfiguration = bufferedPublisherConfiguration;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="BufferedPublisher"/> role. This role creates an <see cref="EventHubBufferedProducerClient"/>
    ///   and monitors it while it sends events to this test's dedicated Event Hub.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var enqueueTasks = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Create the buffered producer client and register the success and failure handlers

            var options = new EventHubBufferedProducerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    TryTimeout = _bufferedPublisherConfiguration.SendTimeout,
                    MaximumRetries = 15
                },
                MaximumWaitTime = _bufferedPublisherConfiguration.MaxWaitTime
            };
            var producer = new EventHubBufferedProducerClient(_testParameters.EventHubsConnectionString, _testParameters.EventHub, options);

            try
            {
                producer.SendEventBatchSucceededAsync += args =>
                {
                    var numEvents = args.EventBatch.Count;

                    _metrics.Client.GetMetric(Metrics.SuccessfullySentFromQueue, Metrics.PartitionId).TrackValue(numEvents, args.PartitionId);
                    _metrics.Client.GetMetric(Metrics.BatchesPublished).TrackValue(1);

                    return Task.CompletedTask;
                };

                producer.SendEventBatchFailedAsync += args =>
                {
                    var numEvents = args.EventBatch.Count;

                    _metrics.Client.GetMetric(Metrics.EventsNotSentAfterEnqueue, Metrics.PartitionId).TrackValue(numEvents, args.PartitionId);
                    _metrics.Client.TrackException(args.Exception);

                    return Task.CompletedTask;
                };

                // Start concurrent enqueuing tasks

                if (_bufferedPublisherConfiguration.ConcurrentSends > 1)
                {
                    for (var index = 0; index < _bufferedPublisherConfiguration.ConcurrentSends - 1; ++index)
                    {
                        enqueueTasks.Add(Task.Run(async () =>
                        {
                            while (!cancellationToken.IsCancellationRequested)
                            {
                                await PerformEnqueue(producer, cancellationToken).ConfigureAwait(false);

                                if ((_bufferedPublisherConfiguration.ProducerPublishingDelay.HasValue) && (_bufferedPublisherConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                                {
                                    await Task.Delay(_bufferedPublisherConfiguration.ProducerPublishingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
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
                        await PerformEnqueue(producer, cancellationToken).ConfigureAwait(false);

                        if ((_bufferedPublisherConfiguration.ProducerPublishingDelay.HasValue) && (_bufferedPublisherConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                        {
                            await Task.Delay(_bufferedPublisherConfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        backgroundCancellationSource.Cancel();
                        await Task.WhenAll(enqueueTasks).ConfigureAwait(false);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // No action needed, the cancellation token has been cancelled.
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
                // If this catch is hit, it means the producer has restarted, collect metrics.

                _metrics.Client.GetMetric(Metrics.ProducerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                await producer.CloseAsync(false);
            }
        }
    }

    /// <summary>
    ///   Generates events using the <see cref= "BufferedPublisherConfiguration" /> instance associated with this role instance.
    ///   It then enqueues these events for send to the Event Hub. Any caught exceptions are sent to Application Insights.
    /// </summary>
    ///
    /// <param name="producer">The <see cref="EventHubBufferedProducerClient" /> to enqueue events to for this test scenario run.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private async Task PerformEnqueue(EventHubBufferedProducerClient producer,
                                      CancellationToken cancellationToken)
    {
        var events = EventGenerator.CreateEvents(_bufferedPublisherConfiguration.MaximumEventListSize,
                                                 _bufferedPublisherConfiguration.EventEnqueueListSize,
                                                 _bufferedPublisherConfiguration.LargeMessageRandomFactorPercent,
                                                 _bufferedPublisherConfiguration.PublishingBodyMinBytes,
                                                 _bufferedPublisherConfiguration.PublishingBodyRegularMaxBytes);

        try
        {
            await producer.EnqueueEventsAsync(events, cancellationToken).ConfigureAwait(false);

            _metrics.Client.GetMetric(Metrics.EventsEnqueued).TrackValue(_bufferedPublisherConfiguration.EventEnqueueListSize);
        }
        catch (TaskCanceledException)
        {
            // Run is completed.
        }
        catch (Exception ex)
        {
            var exceptionProperties = new Dictionary<String, String>();

            // Track that the exception took place during the enqueuing of an event

            exceptionProperties.Add("Process", "Enqueue");

            _metrics.Client.TrackException(ex, exceptionProperties);
        }
    }
}