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
        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref randomSeed)), false);

        private static int randomSeed = Environment.TickCount;

        private Metrics metrics;

        private EventProducerTestConfig testConfiguration;

        public Publisher(EventProducerTestConfig configuration,
                         Metrics metricsIn)
        {
            testConfiguration = configuration;
            metrics = metricsIn;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var sendTasks = new List<Task>();

            while (!cancellationToken.IsCancellationRequested)
            {
                using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                try
                {
                    sendTasks.Clear();

                    var options = new EventHubProducerClientOptions
                    {
                        RetryOptions = new EventHubsRetryOptions
                        {
                            TryTimeout = testConfiguration.SendTimeout
                        }
                    };

                    var producer = new EventHubProducerClient(testConfiguration.EventHubsConnectionString, testConfiguration.EventHub, options);

                    await using (producer.ConfigureAwait(false))
                    {
                        // Create a set of background tasks to handle all but one of the concurrent sends.  The final
                        // send will be performed directly.

                        if (testConfiguration.ConcurrentSends > 1)
                        {
                            for (var index = 0; index < testConfiguration.ConcurrentSends - 1; ++index)
                            {
                                sendTasks.Add(Task.Run(async () =>
                                {
                                    while (!backgroundCancellationSource.Token.IsCancellationRequested)
                                    {
                                        await PerformSend(producer, backgroundCancellationSource.Token).ConfigureAwait(false);

                                        if ((testConfiguration.ProducerPublishingDelay.HasValue) && (testConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                                        {
                                            await Task.Delay(testConfiguration.ProducerPublishingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
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

                                if ((testConfiguration.ProducerPublishingDelay.HasValue) && (testConfiguration.ProducerPublishingDelay.Value > TimeSpan.Zero))
                                {
                                    await Task.Delay(testConfiguration.ProducerPublishingDelay.Value, cancellationToken).ConfigureAwait(false);
                                }
                            }
                            catch (TaskCanceledException)
                            {
                                backgroundCancellationSource.Cancel();
                                await Task.WhenAll(sendTasks).ConfigureAwait(false);
                            }
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

                    metrics.Client.GetMetric(Metrics.EventProducerRestarted).TrackValue(1);
                    metrics.Client.TrackException(ex);
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

            var events = EventGenerator.CreateEvents(testConfiguration.PublishBatchSize);

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
                    metrics.Client.GetMetric(metrics.PublishAttempts).TrackValue(1);
                    await producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
                }

                metrics.Client.GetMetric(metrics.EventsPublished).TrackValue(batch.Count);
                metrics.Client.GetMetric(metrics.BatchesPublished).TrackValue(1);
                metrics.Client.GetMetric(metrics.TotalPublishedSizeBytes).TrackValue(batch.SizeInBytes);
            }
            catch (TaskCanceledException)
            {
                metrics.Client.GetMetric(metrics.PublishAttempts).TrackValue(-1);
            }
            catch (Exception ex)
            {
                var eventProperties = new Dictionary<String, String>();
                eventProperties.Add("Process", "Send");

                metrics.Client.TrackException(ex, eventProperties);
            }
        }
    }
}