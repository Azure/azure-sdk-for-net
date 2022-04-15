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

        public BufferedPublisher(string connectionStringIn, string eventHubNameIn, Metrics metricsIn)
        {
            connectionString = connectionStringIn;
            eventHubName = eventHubNameIn;
            metrics = metricsIn;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
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
                        metrics.Client.TrackEvent("EventsNotSentAfterEnqueue", eventProperties);

                        return Task.CompletedTask;
                    };

                    await using (producer.ConfigureAwait(false))
                    {
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            await PerformSend(producer, cancellationToken).ConfigureAwait(false);
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

                    metrics.Client.GetMetric(metrics.BufferedProducerRestarted).TrackValue(1);
                    metrics.Client.TrackException(ex);
                }
            }
        }

        private async Task PerformSend(EventHubBufferedProducerClient producer,
                                       CancellationToken cancellationToken)
        {
            var events = EventGenerator.CreateEvents(100);

            try
            {
                await producer.EnqueueEventsAsync(events, cancellationToken).ConfigureAwait(false);
                metrics.Client.GetMetric(metrics.EventsEnqueuedPerTest).TrackValue(100);
            }
            catch (TaskCanceledException)
            {
                // Run is completed.
            }
            catch (EventHubsException ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
                metrics.Client.GetMetric(metrics.SendExceptions).TrackValue(1);
            }
            catch (OperationCanceledException ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.SendExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.CanceledSendExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }
            catch (TimeoutException ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.SendExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.TimeoutExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }
            catch (Exception ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.SendExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.GeneralExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }
        }
    }
}