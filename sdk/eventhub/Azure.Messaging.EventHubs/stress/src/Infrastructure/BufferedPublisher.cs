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
        public int ProducerCount = 2;
        public int ConcurrentSends = 5;
        public int PublishBatchSize = 50;
        public int PublishingBodyMinBytes = 100;
        public int PublishingBodyRegularMaxBytes = 757760;
        public int LargeMessageRandomFactorPercent = 50;
        public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
        public TimeSpan? PublishingDelay = TimeSpan.FromMilliseconds(15);

        private static readonly ThreadLocal<Random> RandomNumberGenerator = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref randomSeed)), false);
        private static int randomSeed = Environment.TickCount;
        //private long currentSequence = 0;
        private string connectionString;
        private string eventHubName;
        private Metrics metrics;

        public BufferedPublisher(string connectionStringIn, string eventHubNameIn, Metrics metricsIn)
        {
            connectionString = connectionStringIn;
            eventHubName = eventHubNameIn;
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

                    var options = new EventHubBufferedProducerClientOptions
                    {
                        RetryOptions = new EventHubsRetryOptions
                        {
                            TryTimeout = SendTimeout
                        }
                    };

                    var producer = new EventHubBufferedProducerClient(connectionString, eventHubName, options);
                    producer.SendEventBatchSucceededAsync += args =>
                    {
                        Console.WriteLine("received");

                        return Task.CompletedTask;
                    };

                    producer.SendEventBatchFailedAsync += args =>
                    {
                        Console.WriteLine("not received");

                        return Task.CompletedTask;
                    };

                    await using (producer.ConfigureAwait(false))
                    {
                        // Create a set of background tasks to handle all but one of the concurrent sends.  The final
                        // send will be performed directly.

                        if (ConcurrentSends > 1)
                        {
                            for (var index = 0; index < ConcurrentSends - 1; ++index)
                            {
                                sendTasks.Add(Task.Run(async () =>
                                {
                                    while (!backgroundCancellationSource.Token.IsCancellationRequested)
                                    {
                                        await PerformSend(producer, backgroundCancellationSource.Token).ConfigureAwait(false);

                                        if ((PublishingDelay.HasValue) && (PublishingDelay.Value > TimeSpan.Zero))
                                        {
                                            await Task.Delay(PublishingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
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

                                if ((PublishingDelay.HasValue) && (PublishingDelay.Value > TimeSpan.Zero))
                                {
                                    await Task.Delay(PublishingDelay.Value, cancellationToken).ConfigureAwait(false);
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

                    metrics.Client.GetMetric(metrics.BufferedProducerRestarted).TrackValue(1);
                    metrics.Client.TrackTrace(ex.Message);
                    //ErrorsObserved.Add(ex);
                }
            }
        }

        private async Task PerformSend(EventHubBufferedProducerClient producer,
                                       CancellationToken cancellationToken)
        {
            var events = EventGenerator.CreateEvents(100);

            try
            {
                //Interlocked.Increment(ref Metrics.PublishAttempts);
                await producer.EnqueueEventsAsync(events, cancellationToken).ConfigureAwait(false);

                metrics.Client.GetMetric(metrics.EventsEnqueuedPerTest).TrackValue(100);

                //Interlocked.Increment(ref Metrics.BatchesPublished);
                //Interlocked.Add(ref Metrics.EventsPublished, batch.Count);
                // Interlocked.Add(ref Metrics.TotalPublshedSizeBytes, batch.SizeInBytes);
            }
            catch (TaskCanceledException)
            {
                //Interlocked.Decrement(ref Metrics.PublishAttempts);
            }
            catch (EventHubsException)
            {
                // Interlocked.Increment(ref Metrics.TotalExceptions);
                // Interlocked.Increment(ref Metrics.SendExceptions);
                // ex.TrackMetrics(Metrics);
                // ErrorsObserved.Add(ex);
            }
            catch (OperationCanceledException)
            {
                // Interlocked.Increment(ref Metrics.TotalExceptions);
                // Interlocked.Increment(ref Metrics.SendExceptions);
                // Interlocked.Increment(ref Metrics.CanceledSendExceptions);
                // ErrorsObserved.Add(ex);
            }
            catch (TimeoutException)
            {
                // Interlocked.Increment(ref Metrics.TotalExceptions);
                // Interlocked.Increment(ref Metrics.SendExceptions);
                // Interlocked.Increment(ref Metrics.TimeoutExceptions);
                // ErrorsObserved.Add(ex);
            }
            catch (Exception)
            {
                // Interlocked.Increment(ref Metrics.TotalExceptions);
                // Interlocked.Increment(ref Metrics.SendExceptions);
                // Interlocked.Increment(ref Metrics.GeneralExceptions);
                // ErrorsObserved.Add(ex);
            }
        }
    }
}