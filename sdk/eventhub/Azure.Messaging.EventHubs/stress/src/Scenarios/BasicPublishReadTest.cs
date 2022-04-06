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

namespace Azure.Messaging.EventHubs.Stress
{
    public class BasicPublishReadTest
    {
        private int consumersToConnect;
        private int batchesCount;
        private int sentEventsCount;
        private int successfullyReceivedEventsCount;
        private int producerFailureCount;
        private int consumerFailureCount;
        private int corruptedBodyFailureCount;
        private int corruptedPropertiesFailureCount;

        private Metrics metrics;

        private readonly Random RandomNumberGenerator = new Random(Environment.TickCount);

        private DateTimeOffset StartDate;
        private ConcurrentDictionary<string, EventData> MissingEvents;
        private ConcurrentDictionary<string, long> LastReceivedSequenceNumber;

        public async Task Run(string connectionString, string eventHubName, string appInsightsKey, int durationInHours)
        {
            // Want to remove these?
            //Console.WriteLine($"Setting up.");

            metrics = new Metrics(appInsightsKey);

            var duration = TimeSpan.FromHours(durationInHours);

            consumersToConnect = 0;
            batchesCount = 0;
            sentEventsCount = 0;
            successfullyReceivedEventsCount = 0;
            producerFailureCount = 0;
            consumerFailureCount = 0;
            corruptedBodyFailureCount = 0;
            corruptedPropertiesFailureCount = 0;

            MissingEvents = new ConcurrentDictionary<string, EventData>();
            LastReceivedSequenceNumber = new ConcurrentDictionary<string, long>();

            Task sendTask;
            Dictionary<string, Task> receiveTasks = new Dictionary<string, Task>();

            CancellationToken timeoutToken = (new CancellationTokenSource(duration)).Token;
            Exception capturedException;
            var producerClient = new EventHubProducerClient(connectionString, eventHubName);

            foreach (var partitionId in await producerClient.GetPartitionIdsAsync())
            {
                receiveTasks[partitionId] = BackgroundReceive(connectionString, eventHubName, partitionId, timeoutToken);
                Interlocked.Increment(ref consumersToConnect);
            }

            while (consumersToConnect > 0)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(200));
            }

            await Task.Delay(5000);
            sendTask = BackgroundSend(producerClient, timeoutToken);

            //Console.WriteLine($"Starting a { duration.ToString(@"dd\.hh\:mm\:ss") } run.\n");

            StartDate = DateTimeOffset.UtcNow;
            Stopwatch reportStatus = Stopwatch.StartNew();

            while (!timeoutToken.IsCancellationRequested)
            {
                if (sendTask.IsCompleted && !timeoutToken.IsCancellationRequested)
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
                sendTask = BackgroundSend(producerClient, timeoutToken);
            }

            foreach (var kvp in receiveTasks.ToList())
            {
                var receiveTask = kvp.Value;

                if (receiveTask.IsCompleted && !timeoutToken.IsCancellationRequested)
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
                    receiveTasks[kvp.Key] = BackgroundReceive(connectionString, eventHubName, kvp.Key, timeoutToken);
                }
            }

            if (reportStatus.Elapsed > TimeSpan.FromSeconds(30))
            {
                ReportStatus(true);
                reportStatus = Stopwatch.StartNew();
            }

            await Task.Delay(1000);
        }

        await sendTask;
        await Task.WhenAll(receiveTasks.Values.ToList());

        foreach (var eventData in GetLostEvents())
        {
            ReportLostEvent(eventData);
        }

        ReportStatus(true);
        }

        private async Task BackgroundSend(EventHubProducerClient producer, CancellationToken cancellationToken)
        {
            int batchSize, delayInSec;
            string key;
            EventData eventData;
            EventDataBatch batch;

            while (!cancellationToken.IsCancellationRequested)
            {
                batch = await producer.CreateBatchAsync();

                batchSize = RandomNumberGenerator.Next(20, 100);

                for (int i = 0; i < batchSize; i++)
                {
                    key = Guid.NewGuid().ToString();

                    eventData = new EventData(Encoding.UTF8.GetBytes(key));

                    eventData.Properties["CreatedAt"] = DateTimeOffset.UtcNow;
                    eventData.Properties["BatchIndex"] = batchesCount;
                    eventData.Properties["BatchSize"] = batchSize;
                    eventData.Properties["Index"] = i;

                    MissingEvents[key] = eventData;

                    batch.TryAdd(eventData);
                }

                await producer.SendAsync(batch);

                batchesCount++;
                sentEventsCount += batchSize;

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
                                Interlocked.Increment(ref successfullyReceivedEventsCount);
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

        private bool HaveSameProperties(EventData e1, EventData e2) => e1.Properties.OrderBy(kvp => kvp.Key).SequenceEqual(e2.Properties.OrderBy(kvp => kvp.Key));

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

        private void ReportCorruptedBodyEvent(string partitionId, EventData eventData)
        {
            Interlocked.Increment(ref corruptedBodyFailureCount);

            var output =
                $"Partition '{ partitionId }' received an event that has not been sent (corrupted body)." + Environment.NewLine +
                GetPrintableEvent(eventData);

            metrics.Client.GetMetric(metrics.CorruptedBodyFailureCount).TrackValue(1);
            metrics.Client.TrackTrace(output);
        }

        private void ReportCorruptedPropertiesEvent(string partitionId, EventData expectedEvent, EventData receivedEvent)
        {
            Interlocked.Increment(ref corruptedPropertiesFailureCount);

            var output =
                $"Partition '{ partitionId }' received an event with unexpected properties." + Environment.NewLine +
                $"Expected:" + Environment.NewLine +
                GetPrintableEvent(expectedEvent) +
                $"Received:" +
                GetPrintableEvent(receivedEvent);

            metrics.Client.GetMetric(metrics.CorruptedPropertiesFailureCount).TrackValue(1);
            metrics.Client.TrackTrace(output);
        }

        private void ReportProducerFailure(Exception ex)
        {
            Interlocked.Increment(ref producerFailureCount);

            var output =
                $"The producer has stopped unexpectedly." + Environment.NewLine +
                GetPrintableException(ex);

            metrics.Client.GetMetric(metrics.ProducerFailureCount).TrackValue(1);
            metrics.Client.TrackTrace(output);
        }

        private void ReportConsumerFailure(string partitionId, Exception ex)
        {
            Interlocked.Increment(ref consumerFailureCount);

            var output =
                $"The consumer associated with partition '{ partitionId }' has stopped unexpectedly." + Environment.NewLine +
                GetPrintableException(ex);

            metrics.Client.GetMetric(metrics.ConsumerFailureCount).TrackValue(1);
            metrics.Client.TrackTrace(output);
        }

        private void ReportLostEvent(EventData eventData)
        {
            var output =
                $"The following event was sent but it hasn't been received." + Environment.NewLine +
                GetPrintableEvent(eventData);

            metrics.Client.TrackTrace(output);
        }

        private void ReportStatus(bool log = false)
        {
            var elapsedTime = DateTimeOffset.UtcNow.Subtract(StartDate);

            var output =
                $"Elapsed time: { elapsedTime.ToString(@"dd\.hh\:mm\:ss") }" + Environment.NewLine +
                $"Batches sent: { batchesCount }" + Environment.NewLine +
                $"Events sent: { sentEventsCount } " + Environment.NewLine +
                $"Events successfully received: { successfullyReceivedEventsCount }" + Environment.NewLine +
                $"Lost events: { GetLostEvents().Count }" + Environment.NewLine +
                $"Corrupted body failure: { corruptedBodyFailureCount }" + Environment.NewLine +
                $"Corrupted properties failure: { corruptedPropertiesFailureCount }" + Environment.NewLine +
                $"Producer failure: { producerFailureCount }" + Environment.NewLine +
                $"Consumer failure: { consumerFailureCount }" + Environment.NewLine;

            //Console.WriteLine(output);

            if (log)
            {
                metrics.Client.TrackTrace(output);
            }
        }
    }
}