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
        private string connectionString;
        private string eventHubName;
        private Metrics metrics;
        private ProducerConfiguration testConfiguration;

        public BufferedPublisher(ProducerConfiguration testConfigurationIn, Metrics metricsIn)
        {
            connectionString = testConfigurationIn.EventHubsConnectionString;
            eventHubName = testConfigurationIn.EventHub;
            testConfiguration = testConfigurationIn;
            metrics = metricsIn;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var enqueueTasks = new List<Task>();

            while (!cancellationToken.IsCancellationRequested)
            {
                using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                try
                {
                    var producer = new EventHubBufferedProducerClient(connectionString, eventHubName);
                    producer.SendEventBatchSucceededAsync += args =>
                    {
                        var numEvents = args.EventBatch.ToList().Count;

                        var eventProperties = new Dictionary<String, String>();
                        eventProperties.Add("PartitionId", args.PartitionId);

                        metrics.Client.GetMetric(metrics.SuccessfullyPublishedFromQueue).TrackValue(numEvents);
                        metrics.Client.TrackEvent("SuccessfullyPublishedFromQueue", eventProperties);

                        return Task.CompletedTask;
                    };

                    producer.SendEventBatchFailedAsync += args =>
                    {
                        var numEvents = args.EventBatch.ToList().Count;

                        var eventProperties = new Dictionary<String, String>();
                        eventProperties.Add("Exception", args.Exception.Message);
                        eventProperties.Add("PartitionId", args.PartitionId);

                        metrics.Client.GetMetric(metrics.EventsNotSentAfterEnqueue).TrackValue(numEvents);
                        metrics.Client.TrackException(args.Exception);
                        metrics.Client.TrackEvent("EventsNotSentAfterEnqueue", eventProperties);

                        return Task.CompletedTask;
                    };

                    await using (producer.ConfigureAwait(false))
                    {
                        // Create a set of background tasks to handle all but one of the concurrent sends.  The final
                        // send will be performed directly.

                        if (testConfiguration.ConcurrentSends > 1)
                        {
                            for (var index = 0; index < testConfiguration.ConcurrentSends - 1; ++index)
                            {
                                enqueueTasks.Add(Task.Run(async () =>
                                {
                                    while (!cancellationToken.IsCancellationRequested)
                                    {
                                        await PerformSend(producer, cancellationToken).ConfigureAwait(false);

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
                                await Task.WhenAll(enqueueTasks).ConfigureAwait(false);
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
                    metrics.Client.TrackException(ex);
                }
            }
        }

        private async Task PerformSend(EventHubBufferedProducerClient producer,
                                       CancellationToken cancellationToken)
        {
            var events = EventGenerator.CreateEvents(10);

            try
            {
                await producer.EnqueueEventsAsync(events, cancellationToken).ConfigureAwait(false);
                metrics.Client.GetMetric(metrics.EventsEnqueuedPerTest).TrackValue(10);
            }
            catch (TaskCanceledException)
            {
                // Run is completed.
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