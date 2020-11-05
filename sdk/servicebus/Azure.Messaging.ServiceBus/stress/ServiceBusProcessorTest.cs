// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus.Stress.Core;
using Azure.Test.Stress;
using CommandLine;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Stress
{
    public class ServiceBusProcessorTest : ServiceBusTest<ServiceBusProcessorTest.ServiceBusProcessorTestOptions, ServiceBusProcessorTest.ServiceBusProcessorMetrics>
    {
        public ServiceBusProcessorTest(ServiceBusProcessorTestOptions options, ServiceBusProcessorMetrics metrics) : base(options, metrics)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var processCts = new CancellationTokenSource();
            var processTask = Process(processCts.Token);

            var sendTask = Send(cancellationToken);
            try
            {
                await sendTask;
            }
            catch (Exception e) when (ContainsOperationCanceledException(e))
            {
            }

            // Block until all messages have been received OR the timeout is exceeded
            using var unprocessedMessageCts = new CancellationTokenSource(TimeSpan.FromMilliseconds(Options.UnprocessedMessageTimeoutMs));
            await DelayUntil(() => Metrics.MessagesProcessed >= Metrics.MessagesSent, unprocessedMessageCts.Token);

            processCts.Cancel();
            await processTask;
        }

        private async Task Send(CancellationToken cancellationToken)
        {
            await using var sender = ServiceBusClient.CreateSender(QueueName);
            while (!cancellationToken.IsCancellationRequested)
            {
                using var batch = await sender.CreateMessageBatchAsync(cancellationToken);
                for (var i=0; i < Options.SendBatchSize; i++)
                {
                    batch.TryAddMessage(new ServiceBusMessage());
                }
                await sender.SendMessagesAsync(batch);
                Interlocked.Add(ref Metrics.MessagesSent, Options.SendBatchSize);
            }
        }

        private async Task Process(CancellationToken cancellationToken)
        {
            var options = new ServiceBusProcessorOptions() {
                MaxConcurrentCalls = Options.MaxConcurrentCalls
            };

            await using var processor = ServiceBusClient.CreateProcessor(QueueName);

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync(cancellationToken);

                // Block until token is cancelled
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                // Do not flow cancellationToken since we always want to wait for processing to finish
                await processor.StopProcessingAsync();

                processor.ProcessMessageAsync -= MessageHandler;
                processor.ProcessErrorAsync -= ErrorHandler;
            }
        }

        private Task MessageHandler(ProcessMessageEventArgs args)
        {
            Interlocked.Increment(ref Metrics.MessagesProcessed);
            return Task.CompletedTask;
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Interlocked.Increment(ref Metrics.ErrorsProcessed);
            return Task.CompletedTask;
        }

        public class ServiceBusProcessorMetrics : StressMetrics
        {
            public long MessagesSent;
            public long MessagesProcessed;
            public long ErrorsProcessed;
        }

        public class ServiceBusProcessorTestOptions : StressOptions
        {
            [Option("max-concurrent-calls", Default = 1, HelpText = "Maximum number of concurrent calls to the message handler the processor should initiate")]
            public int MaxConcurrentCalls { get; set; }

            [Option("send-batch-size", Default = 5, HelpText = "Messages per send batch")]
            public int SendBatchSize { get; set; }

            [Option("unprocessed-message-timeout-ms", Default = 10000, HelpText = "Timeout for unprocessed messages (in ms)")]
            public int UnprocessedMessageTimeoutMs { get; set; }

        }
    }
}
