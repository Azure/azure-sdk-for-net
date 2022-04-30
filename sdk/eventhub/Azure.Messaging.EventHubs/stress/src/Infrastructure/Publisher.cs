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

namespace Azure.Messaging.EventHubs.Stress
{
    internal class Publisher
    {
        private readonly Metrics _metrics;
        private readonly EventProducerTestConfig _testConfiguration;

        public Publisher(EventProducerTestConfig configuration,
                         Metrics metrics)
        {
            _testConfiguration = configuration;
            _metrics = metrics;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var sendTasks = new List<Task>();

            while (!cancellationToken.IsCancellationRequested)
            {
                using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                var options = new EventHubProducerClientOptions
                {
                    RetryOptions = new EventHubsRetryOptions
                    {
                        TryTimeout = _testConfiguration.SendTimeout
                    }
                };
                var producer = new EventHubProducerClient(_testConfiguration.EventHubsConnectionString, _testConfiguration.EventHub, options);

                try
                {
                    sendTasks.Clear();

                    // Create a set of background tasks to handle all but one of the concurrent sends.  The final
                    // send will be performed directly.

                    if (_testConfiguration.ConcurrentSends > 1)
                    {
                        for (var index = 0; index < _testConfiguration.ConcurrentSends - 1; ++index)
                        {
                            sendTasks.Add(Task.Run(async () =>
                            {
                                while (!backgroundCancellationSource.Token.IsCancellationRequested)
                                {
                                    await PerformSend(producer, backgroundCancellationSource.Token).ConfigureAwait(false);

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
                            await PerformSend(producer, cancellationToken).ConfigureAwait(false);

                            if ((_testConfiguration.ProducerPublishingDelay.HasValue) && (_testConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                            {
                                await Task.Delay(_testConfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
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

                    _metrics.Client.GetMetric(_metrics.ProducerRestarted).TrackValue(1);
                    _metrics.Client.TrackException(ex);
                }
                finally
                {
                    await producer.CloseAsync();
                }
            }
        }

        private async Task PerformSend(EventHubProducerClient producer,
                                       CancellationToken cancellationToken)
        {
            // Create the batch and generate a set of random events, keeping only those that were able to fit into the batch.
            // Because there is a side-effect of TryAdd in the statement, ensure that ToList is called to materialize the set
            // or the batch will be empty at send.

            using var batch = await producer.CreateBatchAsync().ConfigureAwait(false);

            var events = EventGenerator.CreateEvents(batch.MaximumSizeInBytes,
                                                     _testConfiguration.PublishBatchSize,
                                                     _testConfiguration.LargeMessageRandomFactorPercent,
                                                     _testConfiguration.PublishingBodyMinBytes,
                                                     _testConfiguration.PublishingBodyRegularMaxBytes);

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
                    _metrics.Client.GetMetric(_metrics.PublishAttempts).TrackValue(1);
                    await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
                }

                _metrics.Client.GetMetric(_metrics.EventsPublished).TrackValue(batch.Count);
                _metrics.Client.GetMetric(_metrics.BatchesPublished).TrackValue(1);
                _metrics.Client.GetMetric(_metrics.TotalPublishedSizeBytes).TrackValue(batch.SizeInBytes);
            }
            catch (TaskCanceledException)
            {
                _metrics.Client.GetMetric(_metrics.PublishAttempts).TrackValue(-1);
            }
            catch (Exception ex)
            {
                var eventProperties = new Dictionary<String, String>();
                eventProperties.Add("Process", "Send");

                _metrics.Client.TrackException(ex, eventProperties);
            }
        }
    }
}