// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.RabbitMQ.Client.Performance
{
    using global::RabbitMQ.Client;
    using global::RabbitMQ.Client.Events;
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        private static readonly Stopwatch _stopwatch = Stopwatch.StartNew();

        private static readonly byte[] _payload = new byte[1024];
        private const string _consumerTag = "testConsumerTag";

        private static long _messages;
        private static long _messagesReceived;

        static async Task Main(string[] args)
        {
            var messages = (args.Length >= 1 ? long.Parse(args[0]) : 10);

            var receive = (args.Length >= 2 && String.Equals(args[1], "receive", StringComparison.OrdinalIgnoreCase));

            var connectionString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING");
            var entityPath = Environment.GetEnvironmentVariable("SERVICE_BUS_QUEUE_NAME");

            var writeResultsTask = WriteResults(messages);

            RunTest(connectionString, entityPath, messages, receive);

            await writeResultsTask;
        }

        private static void RunTest(string connectionString, string entityPath, long messages, bool receive)
        {
            var hostname = Regex.Match(connectionString, "//([^/]*)/").Groups[1].Value;

            var factory = new ConnectionFactory() { HostName = hostname, Port = 5671 };
            factory.Ssl.Enabled = true;

            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("SERVICE_BUS_ALLOW_UNAUTHORIZED")))
            {
                // Allow self-signed certs
                factory.Ssl.CertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            }

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: entityPath, durable: false, exclusive: false, autoDelete: false, arguments: null);

                if (receive)
                {
                    ExecuteReceives(channel, entityPath, messages);
                }
                else
                {
                    ExecuteSends(channel, entityPath, messages);
                }
            }
        }

        private static void ExecuteSends(IModel channel, string entityPath, long messages)
        {
            while (Interlocked.Increment(ref _messages) <= messages)
            {
                channel.BasicPublish(exchange: "", routingKey: entityPath, basicProperties: null, body: _payload);
            }

            // Undo last increment, since a message was never sent on the final loop iteration
            Interlocked.Decrement(ref _messages);
        }

        private static void ExecuteReceives(IModel channel, string entityPath, long messages)
        {
            var mre = new ManualResetEvent(false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var messagesReceived = Interlocked.Increment(ref _messagesReceived);

                if (messagesReceived <= messages)
                {
                    channel.BasicAck(ea.DeliveryTag, multiple: false);

                    if (Interlocked.Increment(ref _messages) == messages)
                    {
                        channel.BasicCancel(consumerTag: _consumerTag);
                    }                    
                }
                else
                {
                    channel.BasicReject(ea.DeliveryTag, requeue: true);
                }
            };
            channel.BasicConsume(queue: entityPath, autoAck: false, consumerTag: _consumerTag, consumer: consumer);

            consumer.Unregistered += (model, ea) => mre.Set();

            // Block until final message is received
            mre.WaitOne();
        }

        private static void Consumer_Unregistered(object sender, ConsumerEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static async Task WriteResults(long messages)
        {
            var lastMessages = (long)0;
            var lastElapsed = TimeSpan.Zero;
            var maxMessages = (long)0;
            var maxElapsed = TimeSpan.MaxValue;

            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                var sentMessages = _messages;
                var currentMessages = sentMessages - lastMessages;
                lastMessages = sentMessages;

                var elapsed = _stopwatch.Elapsed;
                var currentElapsed = elapsed - lastElapsed;
                lastElapsed = elapsed;

                if ((currentMessages / currentElapsed.TotalSeconds) > (maxMessages / maxElapsed.TotalSeconds))
                {
                    maxMessages = currentMessages;
                    maxElapsed = currentElapsed;
                }

                WriteResult(sentMessages, elapsed, currentMessages, currentElapsed, maxMessages, maxElapsed);
            }
            while (Interlocked.Read(ref _messages) < messages);
        }

        private static void WriteResult(long totalMessages, TimeSpan totalElapsed,
            long currentMessages, TimeSpan currentElapsed, long maxMessages, TimeSpan maxElapsed)
        {
            Log($"\tTot Msg\t{totalMessages}" +
                $"\tCur MPS\t{Math.Round(currentMessages / currentElapsed.TotalSeconds)}" +
                $"\tAvg MPS\t{Math.Round(totalMessages / totalElapsed.TotalSeconds)}" +
                $"\tMax MPS\t{Math.Round(maxMessages / maxElapsed.TotalSeconds)}"
            );
        }

        private static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss.fff")}] {message}");
        }
    }
}
