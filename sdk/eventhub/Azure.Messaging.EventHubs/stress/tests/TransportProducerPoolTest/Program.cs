// ======================================================================================================================
// NOTE:  This can be used to test the transport pool functionality, but requires access to non-public types.  As a
//        result, it can't be run directly against the packaged build and requires local modifications to references and
//        internals visibility.
// ======================================================================================================================

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;

namespace TransportProducerPoolTest
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await Task.Delay(1);

            //            try
            //            {
            //                int durationInHours = 72;

            //                if (args.Length < 2)
            //                {
            //                    Console.WriteLine("There should be at least 2 arguments: connection string and event hub name.");
            //                    return;
            //                }

            //                string connectionString = args[0];
            //                string eventHubName = args[1];

            //                Console.WriteLine($"Using connection string: '{ connectionString }'");
            //                Console.WriteLine($"Using event hub name: '{ eventHubName }'");

            //                if (args.Length > 2 && Int32.TryParse(args[2], out var result))
            //                {
            //                    durationInHours = result;
            //                }

            //                var test = new TransportProducerPoolTest();
            //                await test.Run(connectionString, eventHubName, TimeSpan.FromHours(durationInHours));
            //            }
            //            catch (global::System.Exception e)
            //            {
            //                Console.WriteLine(e);
            //            }

            //            Console.ReadLine();
            }
        }

        //    public class TransportProducerPoolTest
        //    {
        //        private int batchesCount;
        //        private int sentEventsCount;
        //        private int producerFailureCount;

        //        private readonly Random RandomNumberGenerator = new Random(Environment.TickCount);
        //        private readonly string LogPath = Path.Combine(Environment.CurrentDirectory, "log.txt");

        //        private DateTimeOffset StartDate;
        //        private TextWriter Log;

        //        public ConcurrentDictionary<string, KeyValuePair<int, Task>> SendingTasks;

        //        public async Task Run(string connectionString, string eventHubName, TimeSpan duration)
        //        {
        //            Console.WriteLine($"Setting up.");

        //            batchesCount = 0;
        //            sentEventsCount = 0;
        //            producerFailureCount = 0;

        //            SendingTasks = new ConcurrentDictionary<string, KeyValuePair<int, Task>>();
        //            List<Task> reportTasks = new List<Task>();

        //            using (var streamWriter = File.CreateText(LogPath))
        //            {
        //                Log = TextWriter.Synchronized(streamWriter);

        //                DiagnosticListener.AllListeners.Subscribe(new TransportProducerPoolReceiver(this, reportTasks));

        //                Task sendTaskProducer;
        //                Task DefaultProducerSendingTask;

        //                CancellationToken timeoutToken = (new CancellationTokenSource(duration)).Token;
        //                Exception capturedException;
        //                await using var producerClient = new EventHubProducerClient(connectionString, eventHubName);

        //                DefaultProducerSendingTask = SendRandomBatch(producerClient, timeoutToken, timeoutToken, null);
        //                sendTaskProducer = ProduceSendingTasks(producerClient, timeoutToken);

        //                Console.WriteLine($"Starting a { duration.ToString(@"dd\.hh\:mm\:ss") } run.\n");
        //                Console.WriteLine($"Log output can be found at '{ LogPath }'.\n");

        //                StartDate = DateTimeOffset.UtcNow;
        //                Stopwatch reportStatus = Stopwatch.StartNew();

        //                while (!timeoutToken.IsCancellationRequested)
        //                {
        //                    if (sendTaskProducer.IsCompleted && !timeoutToken.IsCancellationRequested)
        //                    {
        //                        capturedException = null;

        //                        try
        //                        {
        //                            await sendTaskProducer;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            capturedException = ex;
        //                        }

        //                        reportTasks.Add(ReportProducerFailure(capturedException));
        //                        sendTaskProducer = ProduceSendingTasks(producerClient, timeoutToken);
        //                    }

        //                    if(DefaultProducerSendingTask.IsCompleted && !timeoutToken.IsCancellationRequested)
        //                    {
        //                        capturedException = null;

        //                        try
        //                        {
        //                            await DefaultProducerSendingTask;
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            capturedException = ex;
        //                        }

        //                        reportTasks.Add(ReportProducerFailure(capturedException));
        //                        DefaultProducerSendingTask = SendRandomBatch(producerClient, timeoutToken, timeoutToken, null);
        //                    }

        //                    foreach (var sendTask in SendingTasks.ToList())
        //                    {
        //                        if(sendTask.Value.Value.IsCompleted)
        //                        {
        //                            capturedException = null;

        //                            try
        //                            {
        //                                await sendTask.Value.Value;
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                capturedException = ex;
        //                            }

        //                            if(capturedException != null)
        //                            {
        //                                reportTasks.Add(ReportProducerFailure(capturedException));
        //                            }

        //                            SendingTasks.TryRemove(sendTask.Key, out _);
        //                        }
        //                    }

        //                    if (reportStatus.Elapsed > TimeSpan.FromMinutes(1))
        //                    {
        //                        reportTasks.Add(ReportStatus());
        //                        reportStatus = Stopwatch.StartNew();
        //                    }

        //                    reportTasks.RemoveAll(t => t.IsCompleted);

        //                    await Task.Delay(1000);
        //                }

        //                try
        //                {
        //                    await DefaultProducerSendingTask;
        //                }
        //                catch (Exception e)
        //                {
        //                    reportTasks.Add(ReportProducerFailure(e));
        //                }

        //                foreach (var sendTask in SendingTasks.ToList())
        //                {
        //                    try
        //                    {
        //                        await sendTask.Value.Value;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        reportTasks.Add(ReportProducerFailure(ex));
        //                    }

        //                    SendingTasks.TryRemove(sendTask.Key, out _);
        //                }

        //                reportTasks.Add(ReportStatus(true));

        //                await Task.WhenAll(reportTasks);

        //                Console.WriteLine($"Log output can be found at '{ LogPath }'.");
        //            }
        //        }

        //        private async Task ProduceSendingTasks(EventHubProducerClient producer, CancellationToken timeoutToken)
        //        {
        //            int numberOfPartitions = (await producer.GetEventHubPropertiesAsync()).PartitionIds.Length;

        //            while (!timeoutToken.IsCancellationRequested)
        //            {
        //                var id = Guid.NewGuid().ToString();
        //                int partitionId = RandomNumberGenerator.Next(numberOfPartitions);

        //                int sendTaskDurationInMins = RandomNumberGenerator.Next(3, 10);

        //                CancellationToken sendTaskCancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(sendTaskDurationInMins)).Token;

        //                SendingTasks.TryAdd(id, new KeyValuePair<int, Task>(partitionId, SendRandomBatch(producer, timeoutToken, sendTaskCancellationToken, partitionId)));

        //                int delayInSec = RandomNumberGenerator.Next(120);

        //                await Task.Delay(TimeSpan.FromSeconds(delayInSec), timeoutToken);
        //            }
        //        }

        //        private async Task SendRandomBatch(EventHubProducerClient producer, CancellationToken timeoutToken, CancellationToken sendTaskCancellationToken, int? partitionId)
        //        {
        //            int batchSize, delayInSec;
        //            string key;
        //            EventData eventData;
        //            EventDataBatch batch;

        //            while (!sendTaskCancellationToken.IsCancellationRequested && !timeoutToken.IsCancellationRequested)
        //            {
        //                var batchOptions = new CreateBatchOptions
        //                {
        //                    PartitionId = partitionId.ToString()
        //                };

        //                batch = await producer.CreateBatchAsync(batchOptions);

        //                batchSize = RandomNumberGenerator.Next(20, 100);

        //                for (int i = 0; i < batchSize; i++)
        //                {
        //                    key = Guid.NewGuid().ToString();

        //                    eventData = new EventData(Encoding.UTF8.GetBytes(key));

        //                    eventData.Properties["CreatedAt"] = DateTimeOffset.UtcNow;
        //                    eventData.Properties["BatchIndex"] = batchesCount;
        //                    eventData.Properties["BatchSize"] = batchSize;
        //                    eventData.Properties["Index"] = i;

        //                    batch.TryAdd(eventData);
        //                }

        //                await producer.SendAsync(batch);

        //                batchesCount++;
        //                sentEventsCount += batchSize;

        //                delayInSec = RandomNumberGenerator.Next(1, 10);

        //                await Task.Delay(TimeSpan.FromSeconds(delayInSec));
        //            }
        //        }

        //        private string GetPrintableException(Exception ex)
        //            {
        //                if (ex == null)
        //                {
        //                    return $"No expection has been thrown." + Environment.NewLine;
        //                }
        //                else
        //                {
        //                    return
        //                        $"Message:" + Environment.NewLine +
        //                        ex.Message + Environment.NewLine +
        //                        $"Stack trace:" + Environment.NewLine +
        //                        ex.StackTrace + Environment.NewLine;
        //                }
        //            }

        //        private Task ReportProducerFailure(Exception ex)
        //        {
        //            Interlocked.Increment(ref producerFailureCount);

        //            var output =
        //                $"The producer has stopped unexpectedly." + Environment.NewLine +
        //                GetPrintableException(ex);

        //            return Log.WriteLineAsync(output);
        //        }

        //        private Task ReportStatus(bool log = false)
        //        {
        //            var elapsedTime = DateTimeOffset.UtcNow.Subtract(StartDate);

        //            var output =
        //                $"Elapsed time: { elapsedTime.ToString(@"dd\.hh\:mm\:ss") }" + Environment.NewLine +
        //                $"Batches sent: { batchesCount }" + Environment.NewLine +
        //                $"Events sent: { sentEventsCount } " + Environment.NewLine +
        //                $"Producer failure: { producerFailureCount }" + Environment.NewLine +
        //                $"Active partitions: { string.Join(", ", SendingTasks.Values.Select(kvp => kvp.Key).OrderBy(key => key)) }" + Environment.NewLine;

        //            Console.WriteLine(output);

        //            return log
        //                ? Log.WriteLineAsync(output)
        //                : Task.CompletedTask;
        //        }
        //    }

        //    class TransportProducerPoolReceiver : IObserver<DiagnosticListener>, IObserver<KeyValuePair<string, object>>
        //    {
        //        private readonly TransportProducerPoolTest test;
        //        private readonly List<Task> reportTasks;

        //        public TransportProducerPoolReceiver(TransportProducerPoolTest test, List<Task> reportTasks)
        //        {
        //            this.test = test;
        //            this.reportTasks = reportTasks;
        //        }

        //        public void OnCompleted()
        //        {
        //        }

        //        public void OnError(Exception error)
        //        {
        //        }

        //        public void OnNext(KeyValuePair<string, object> value)
        //        {
        //            try
        //            {
        //                if (value.Key == $"{ nameof(TransportProducerPool) }.{ nameof(TransportProducerPool.PoolItem) }.Start")
        //                {
        //                    reportTasks.Add(ReportPoolItemCreated(value));
        //                }
        //                else if (value.Key == $"{ nameof(TransportProducerPool) }.PoolItem.Stop")
        //                {
        //                    reportTasks.Add(ReportPoolItemEvicted(value));
        //                }
        //                else if (value.Key == $"{ nameof(TransportProducerPool) }.CreateExpirationTimerCallback.Start")
        //                {
        //                    reportTasks.Add(ReportExpirationCallBackStarted(value));
        //                }
        //                else if (value.Key == $"{ nameof(TransportProducerPool) }.CreateExpirationTimerCallback.Stop")
        //                {
        //                    reportTasks.Add(ReportExpirationCallBackEnded(value));
        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine($"An error occurred handling events { e.ToString() }" + Environment.NewLine);
        //            }
        //        }

        //        public void OnNext(DiagnosticListener value)
        //        {
        //            if (value.Name == nameof(TransportProducerPool))
        //            {
        //                value.Subscribe(this);
        //            }
        //        }

        //        private Task ReportExpirationCallBackEnded(KeyValuePair<string, object> value)
        //        {
        //            ConcurrentDictionary<string, TransportProducerPool.PoolItem> pool = value.Value as ConcurrentDictionary<string, TransportProducerPool.PoolItem>;

        //            string message =
        //                $"The ExpirationTimerCallback finished." + Environment.NewLine +
        //                $"The pool snapshot is: { CreatePoolSnapshot(pool) }" + Environment.NewLine;

        //            Console.WriteLine(message);

        //            return Task.CompletedTask;
        //        }

        //        private Task ReportExpirationCallBackStarted(KeyValuePair<string, object> value)
        //        {
        //            ConcurrentDictionary<string, TransportProducerPool.PoolItem> pool = value.Value as ConcurrentDictionary<string, TransportProducerPool.PoolItem>;

        //            string message =
        //                $"The ExpirationTimerCallback started at { DateTimeOffset.UtcNow }." + Environment.NewLine +
        //                $"The pool snapshot is: { CreatePoolSnapshot(pool) }" + Environment.NewLine;

        //            Console.WriteLine(message);

        //            return Task.CompletedTask;
        //        }

        //        private Task ReportPoolItemEvicted(KeyValuePair<string, object> value)
        //        {
        //            string message =
        //                $"A PoolItem was evicted." + Environment.NewLine +
        //                $"The partition id is: { value.Value }" + Environment.NewLine +
        //                $"Actively sending to: { string.Join(", ", test.SendingTasks.Values.Select(kvp => kvp.Key)) }" + Environment.NewLine;

        //            Console.WriteLine(message);

        //            return Task.CompletedTask;
        //        }

        //        private Task ReportPoolItemCreated(KeyValuePair<string, object> value)
        //        {
        //            string partitionId = Activity.Current.Tags.FirstOrDefault(t => t.Key == "PartitionId").Value;
        //            ConcurrentDictionary<string, TransportProducerPool.PoolItem> pool = value.Value as ConcurrentDictionary<string, TransportProducerPool.PoolItem>;

        //            string message =
        //                $"A new PoolItem was created." + Environment.NewLine +
        //                $"The partition id is: { partitionId }" + Environment.NewLine +
        //                $"Actively sending to: { string.Join(", ", test.SendingTasks.Values.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Key)) }" + Environment.NewLine +
        //                $"The pool snapshot is: { CreatePoolSnapshot(pool) }" + Environment.NewLine;

        //            Console.WriteLine(message);

        //            return Task.CompletedTask;
        //        }

        //        private string CreatePoolSnapshot(ConcurrentDictionary<string, TransportProducerPool.PoolItem> pool)
        //        {
        //            string result = string.Empty;

        //            foreach(var pair in pool.ToList().OrderBy(p => p.Key))
        //            {
        //                result += Environment.NewLine + Environment.NewLine +
        //                    "\t" + $"PartitionId: { pair.Key }" + Environment.NewLine +
        //                    "\t" + $"Status: { GetStatus(pair.Key) }" + Environment.NewLine +
        //                    "\t" + $"Number of Active Instances: { pair.Value.ActiveInstances.Count }" + Environment.NewLine +
        //                    "\t" + $"Estimated Eviction Time: { pair.Value.RemoveAfter }" + Environment.NewLine;
        //            }

        //            return result;
        //        }

        //        private string GetStatus(string partitionId)
        //        {
        //            int partitionIdAsInt = int.Parse(partitionId);

        //            return test.SendingTasks.Values.Any(kp => kp.Key == partitionIdAsInt) ? "ACTIVE" : "INACTIVE";
        //        }
      //}
}