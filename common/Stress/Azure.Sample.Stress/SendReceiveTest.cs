// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Stress;
using CommandLine;
using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Sample.Stress
{
    public class SendReceiveTest : StressTest<SendReceiveTest.SendReceiveOptions, SendReceiveTest.SendReceiveMetrics>
    {
        private Channel<int> _channel = Channel.CreateUnbounded<int>();

        public SendReceiveTest(SendReceiveOptions options, SendReceiveMetrics metrics) : base(options, metrics)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var senderTask = Sender(cancellationToken);

            var receiverCts = new CancellationTokenSource();

            var receiverTasks = new Task[Options.Receivers];
            for (var i = 0; i < Options.Receivers; i++)
            {
                receiverTasks[i] = Receiver(receiverCts.Token);
            }

            try
            {
                await senderTask;
            }
            catch (Exception e) when (ContainsOperationCanceledException(e))
            {
            }

            // Block until all messages have been received
            await DelayUntil(() => Metrics.Unprocessed == 0);

            receiverCts.Cancel();

            await Task.WhenAll(receiverTasks);
        }

        private async Task Sender(CancellationToken cancellationToken)
        {
            var index = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Send(index, cancellationToken);
                    Interlocked.Increment(ref Metrics.Sends);
                    index++;
                }
                catch (Exception e) when (!ContainsOperationCanceledException(e))
                {
                    Metrics.Exceptions.Enqueue(e);
                }
            }
        }

        private async Task Receiver(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Receive(cancellationToken);
                    Interlocked.Increment(ref Metrics.Receives);
                }
                catch (Exception e) when (!ContainsOperationCanceledException(e))
                {
                    Metrics.Exceptions.Enqueue(e);
                }
            }
        }

        // Simulates method in SDK
        private async Task Send(int index, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(Random.Next(0, Options.MaxSendDelayMs)), cancellationToken);
            var d = Random.NextDouble();
            if (d < Options.SendExceptionRate)
            {
                throw new SendException(d.ToString());
            }
            else
            {
                await _channel.Writer.WriteAsync(index, cancellationToken);
            }
        }

        // Simulates method in SDK
        private async Task Receive(CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(Random.Next(0, Options.MaxReceiveDelayMs)), cancellationToken);
            var d = Random.NextDouble();
            if (d < Options.ReceiveExceptionRate)
            {
                throw new ReceiveException(d.ToString());
            }
            else
            {
                await _channel.Reader.ReadAsync(cancellationToken);
            }
        }

        public class SendReceiveOptions : StressOptions
        {
            [Option("maxSendDelayMs", Default = 50, HelpText = "Max send delay (in milliseconds)")]
            public int MaxSendDelayMs { get; set; }

            [Option("maxReceiveDelayMs", Default = 200, HelpText = "Max send delay (in milliseconds)")]
            public int MaxReceiveDelayMs { get; set; }

            [Option("receivers", Default = 3, HelpText = "Number of receivers")]
            public int Receivers { get; set; }

            [Option("sendExceptionRate", Default = .01, HelpText = "Rate of send exceptions")]
            public double SendExceptionRate { get; set; }

            [Option("receiveExceptionRate", Default = .02, HelpText = "Rate of receive exceptions")]
            public double ReceiveExceptionRate { get; set; }
        }

        public class SendReceiveMetrics : StressMetrics
        {
            public long Sends;
            public long Receives;
            public long Unprocessed => (Interlocked.Read(ref Sends) - Interlocked.Read(ref Receives));
        }

        public class SendException : Exception
        {
            public SendException()
            {
            }

            public SendException(string message) : base(message)
            {
            }
        }

        public class ReceiveException : Exception
        {
            public ReceiveException()
            {
            }

            public ReceiveException(string message) : base(message)
            {
            }
        }
    }
}
