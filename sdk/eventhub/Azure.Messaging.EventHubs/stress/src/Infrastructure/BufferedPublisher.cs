// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class BufferedPublisher
    {
        private readonly string _connectionString;
        private readonly string _eventHubName;
        private readonly Metrics _metrics;
        private readonly BufferedProducerTestConfig _testConfiguration;

        public BufferedPublisher(BufferedProducerTestConfig testConfiguration,
                                 Metrics metrics)
        {
            _connectionString = testConfiguration.EventHubsConnectionString;
            _eventHubName = testConfiguration.EventHub;
            _metrics = metrics;
            _testConfiguration = testConfiguration;
        }

        public async Task Start(CancellationToken cancellationToken)
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
                        TryTimeout = _testConfiguration.SendTimeout,
                        MaximumRetries = 15
                    },
                    MaximumWaitTime = _testConfiguration.MaxWaitTime
                };
                var producer = new EventHubBufferedProducerClient(_connectionString, _eventHubName, options);

                try
                {
                    producer.SendEventBatchSucceededAsync += args =>
                    {
                        var numEvents = args.EventBatch.Count;

                        _metrics.Client.GetMetric(_metrics.SuccessfullySentFromQueue, "PartitionId").TrackValue(numEvents, args.PartitionId);
                        _metrics.Client.GetMetric(_metrics.BatchesPublished).TrackValue(1);

                        return Task.CompletedTask;
                    };

                    producer.SendEventBatchFailedAsync += args =>
                    {
                        var numEvents = args.EventBatch.Count;

                        _metrics.Client.GetMetric(_metrics.EventsNotSentAfterEnqueue, "PartitionId").TrackValue(numEvents, args.PartitionId);
                        _metrics.Client.TrackException(args.Exception);

                        return Task.CompletedTask;
                    };

                    // Start concurrent enqueuing tasks

                    if (_testConfiguration.ConcurrentSends > 1)
                    {
                        for (var index = 0; index < _testConfiguration.ConcurrentSends - 1; ++index)
                        {
                            enqueueTasks.Add(Task.Run(async () =>
                            {
                                while (!cancellationToken.IsCancellationRequested)
                                {
                                    await PerformEnqueue(producer, cancellationToken).ConfigureAwait(false);

                                    if ((_testConfiguration.ProducerPublishingDelay.HasValue) && (_testConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                                    {
                                        await Task.Delay(_testConfiguration.ProducerPublishingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
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

                            if ((_testConfiguration.ProducerPublishingDelay.HasValue) && (_testConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                            {
                                await Task.Delay(_testConfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
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

                    _metrics.Client.GetMetric(_metrics.ProducerRestarted).TrackValue(1);
                    _metrics.Client.TrackException(ex);
                }
                finally
                {
                    await producer.CloseAsync(false);
                }
            }
        }

        private async Task PerformEnqueue(EventHubBufferedProducerClient producer,
                                          CancellationToken cancellationToken)
        {
            var events = EventGenerator.CreateEvents(_testConfiguration.MaximumEventListSize,
                                                     _testConfiguration.EventEnqueueListSize,
                                                     _testConfiguration.LargeMessageRandomFactorPercent,
                                                     _testConfiguration.PublishingBodyMinBytes,
                                                     _testConfiguration.PublishingBodyRegularMaxBytes);

            try
            {
                await producer.EnqueueEventsAsync(events, cancellationToken).ConfigureAwait(false);

                _metrics.Client.GetMetric(_metrics.EventsEnqueued).TrackValue(_testConfiguration.EventEnqueueListSize);
            }
            catch (TaskCanceledException)
            {
                // Run is completed.
            }
            catch (Exception ex)
            {
                var eventProperties = new Dictionary<String, String>();

                // Track that the exception took place during the enqueuing of an event

                eventProperties.Add("Process", "Enqueue");

                _metrics.Client.TrackException(ex, eventProperties);
            }
        }
    }
}