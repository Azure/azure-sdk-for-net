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
    public class BasicBufferedProducerTest
    {
        private ConcurrentDictionary<string, long> LastReceivedSequenceNumber;
        private ConcurrentDictionary<string, EventData> MissingEvents;
        private Metrics metrics;
        private DateTimeOffset StartDate;
        private readonly Random RandomNumberGenerator = new Random(Environment.TickCount);
        private readonly string metricDimension = "Basic Buffered Producer Test";

        private int consumersToConnect;

        public async Task Run(string connectionString, string eventHubName, string appInsightsKey, int durationInHours)
        {
            metrics = new Metrics(appInsightsKey);
            LastReceivedSequenceNumber = new ConcurrentDictionary<string, long>();
            MissingEvents = new ConcurrentDictionary<string, EventData>();
            StartDate = DateTimeOffset.UtcNow;

            Dictionary<string, Task> receiveTasks = new Dictionary<string, Task>();
            var producer = new EventHubBufferedProducerClient(connectionString, eventHubName);
            CancellationToken cancellationSource = (new CancellationTokenSource(TimeSpan.FromHours(durationInHours))).Token;
            Exception capturedException;
            Task sendTask;

            consumersToConnect = 0;

            foreach (var partitionId in await producer.GetPartitionIdsAsync())
            {
                receiveTasks[partitionId] = BackgroundReceive(connectionString, eventHubName, partitionId, cancellationSource);
                Interlocked.Increment(ref consumersToConnect);
            }
            while (consumersToConnect > 0)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(200));
            }

            await Task.Delay(5000);
            sendTask = BackgroundSend(producer, cancellationSource);

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

            while (!cancellationSource.IsCancellationRequested)
            {
                if (sendTask.IsCompleted && !cancellationSource.IsCancellationRequested)
                {
                    capturedException = null;

                    try
                    {
                        await sendTask;
                    }
                    catch (Exception ex)
                    {
                        capturedException = ex;
                    }

                    ReportProducerFailure(capturedException);
                    sendTask = BackgroundSend(producer, cancellationSource);
                }

                foreach (var kvp in receiveTasks.ToList())
                {
                    var receiveTask = kvp.Value;

                    if (receiveTask.IsCompleted && !cancellationSource.IsCancellationRequested)
                    {
                        capturedException = null;

                        try
                        {
                            await receiveTask;
                        }
                        catch (Exception ex)
                        {
                            capturedException = ex;
                        }

                        ReportConsumerFailure(kvp.Key, capturedException);
                        receiveTasks[kvp.Key] = BackgroundReceive(connectionString, eventHubName, kvp.Key, cancellationSource);
                    }
                }

                await Task.Delay(1000);
            }

            await sendTask;
            await Task.WhenAll(receiveTasks.Values.ToList());

            foreach (var eventData in GetLostEvents())
            {
                ReportLostEvent(eventData);
            }
        }

        private async Task BackgroundSend(EventHubBufferedProducerClient producer, CancellationToken cancellationSource)
        {
            int delayInSec;
            var partitionCount = 2;
            var eventsPerPartition = 50;
            string key;
            EventData eventData;
            List<EventData> events = new List<EventData>();

            while (!cancellationSource.IsCancellationRequested)
            {
                for (int i = 0; i < (eventsPerPartition * partitionCount); i++)
                {
                    key = Guid.NewGuid().ToString();
                    eventData = new EventData(Encoding.UTF8.GetBytes(key));
                    eventData.Properties["Index"] = i;

                    MissingEvents[key]= eventData;
                    events.Add(eventData);
                }

                await producer.EnqueueEventsAsync(events, cancellationSource);
                // change to enqueued
                metrics.Client.GetMetric(metrics.EventsEnqueued).TrackValue(eventsPerPartition*partitionCount, metricDimension);

                delayInSec = RandomNumberGenerator.Next(1, 10);
                await Task.Delay(TimeSpan.FromSeconds(delayInSec));
            }
        }

        private async Task BackgroundReceive(string connectionString, string eventHubName, string partitionId, CancellationToken cancellationToken)
        {
            EventPosition eventPosition;

            if (LastReceivedSequenceNumber.TryGetValue(partitionId, out long sequenceNumber))
            {
                eventPosition = EventPosition.FromSequenceNumber(sequenceNumber, false);
            }
            else
            {
                eventPosition = EventPosition.Latest;
            }

            await using (var consumerClient = new EventHubConsumerClient("$Default", connectionString, eventHubName))
            {
                Interlocked.Decrement(ref consumersToConnect);

                await foreach (var receivedEvent in consumerClient.ReadEventsFromPartitionAsync(partitionId, eventPosition, new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(5) }))
                {
                    if (receivedEvent.Data != null)
                    {
                        var key = Encoding.UTF8.GetString(receivedEvent.Data.Body.ToArray());

                        if (MissingEvents.TryRemove(key, out var expectedEvent))
                        {
                            if (HaveSameProperties(expectedEvent, receivedEvent.Data))
                            {
                                metrics.Client.GetMetric(metrics.SuccessfullyReceivedEventsCount).TrackValue(1, metricDimension);
                            }
                            else
                            {
                                ReportCorruptedPropertiesEvent(partitionId, expectedEvent, receivedEvent.Data);
                            }
                        }
                        else
                        {
                            ReportCorruptedBodyEvent(partitionId, receivedEvent.Data);
                        }

                        LastReceivedSequenceNumber[partitionId] = receivedEvent.Data.SequenceNumber;
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }
        }

        private List<EventData> GetLostEvents()
        {
            var list = new List<EventData>();

            foreach (var eventData in MissingEvents.Values)
            {
                if (eventData.Properties.TryGetValue("CreatedAt", out var createdAt))
                {
                    if (DateTimeOffset.UtcNow.Subtract((DateTimeOffset)createdAt) > TimeSpan.FromMinutes(2))
                    {
                        list.Add(eventData);
                    }
                }
            }

            return list;
        }

        private void ReportCorruptedBodyEvent(string partitionId, EventData eventData)
        {
            metrics.Client.GetMetric(metrics.CorruptedBodyFailureCount).TrackValue(1);

            var output =
                $"Partition '{ partitionId }' received an event that has not been sent (corrupted body)." + Environment.NewLine +
                GetPrintableEvent(eventData);

            metrics.Client.TrackTrace(output);
        }

        private void ReportCorruptedPropertiesEvent(string partitionId, EventData expectedEvent, EventData receivedEvent)
        {
            metrics.Client.GetMetric(metrics.CorruptedPropertiesFailureCount).TrackValue(1);

            var output =
                $"Partition '{ partitionId }' received an event with unexpected properties." + Environment.NewLine +
                $"Expected:" + Environment.NewLine +
                GetPrintableEvent(expectedEvent) +
                $"Received:" +
                GetPrintableEvent(receivedEvent);

            metrics.Client.TrackTrace(output);
        }

        private bool HaveSameProperties(EventData e1, EventData e2) => e1.Properties.OrderBy(kvp => kvp.Key).SequenceEqual(e2.Properties.OrderBy(kvp => kvp.Key));

        private void ReportProducerFailure(Exception ex)
        {
            metrics.Client.GetMetric(metrics.ProducerFailureCount).TrackValue(1);

            var output =
                $"The producer has stopped unexpectedly." + Environment.NewLine +
                GetPrintableException(ex);

            metrics.Client.TrackTrace(output);
        }

        private void ReportConsumerFailure(string partitionId, Exception ex)
        {
            metrics.Client.GetMetric(metrics.ConsumerFailureCount).TrackValue(1);

            var output =
                $"The consumer associated with partition '{ partitionId }' has stopped unexpectedly." + Environment.NewLine +
                GetPrintableException(ex);

            metrics.Client.TrackTrace(output);
        }

        private void ReportLostEvent(EventData eventData)
        {
            var output =
                $"The following event was sent but it hasn't been received." + Environment.NewLine +
                GetPrintableEvent(eventData);

            metrics.Client.TrackTrace(output);
        }

        private string GetPrintableEvent(EventData eventData)
        {
            var str =
                $"  Body: { Encoding.UTF8.GetString(eventData.Body.ToArray()) }" + Environment.NewLine +
                $"  Properties:" + Environment.NewLine;

            foreach (var property in eventData.Properties)
            {
                str += $"    { property.Key }: { property.Value }" + Environment.NewLine;
            }

            return str;
        }

        private string GetPrintableException(Exception ex)
        {
            if (ex == null)
            {
                return $"No expection has been thrown." + Environment.NewLine;
            }
            else
            {
                return
                    $"Message:" + Environment.NewLine +
                    ex.Message + Environment.NewLine +
                    $"Stack trace:" + Environment.NewLine +
                    ex.StackTrace + Environment.NewLine;
            }
        }
    }
}
