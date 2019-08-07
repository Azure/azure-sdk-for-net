using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

// BLOCKER: Do not include in final code.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    public class BrandonTempTests
    {
        private const string queueName = "test-queue";

        private readonly ITestOutputHelper _output;

        public BrandonTempTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task BrandonAddNewMessages()
        {
            var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);

            var messages = Enumerable.Range(1, 1000)
                .Select(i => new Message(Encoding.UTF8.GetBytes($"test " + i)))
                .ToList();

            await sender.SendAsync(messages);


        }

        [Fact]
        public async Task BrandonAmqpMultiRenewal()
        {
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

            var messages1 = await receiver.ReceiveAsync(2);

            await Task.Delay(TimeSpan.FromSeconds(5));

            var messages2 = await receiver.ReceiveAsync(2);

            var messages = messages1.Concat(messages2).ToList();


            var initialExpirations = messages.Select(m => m.SystemProperties.LockedUntilUtc).ToArray();

            _output.WriteLine(string.Join(", ", initialExpirations));

            //await receiver.CompleteAsync(messages1.Select(m => m.SystemProperties.LockToken));

            await Task.Delay(TimeSpan.FromSeconds(5));

            foreach (var message in messages)
                await receiver.RenewLockAsync(message);

            var renewedExpirations = messages.Select(m => m.SystemProperties.LockedUntilUtc).ToArray();

            _output.WriteLine(string.Join(", ", renewedExpirations));


            for (int i = 0; i < messages.Count; i++)
            {
                Assert.True(initialExpirations[i] < renewedExpirations[i]);
            }

            foreach (var message in messages)
            {
                await receiver.AbandonAsync(message.SystemProperties.LockToken);
            }
        }

        [Fact]
        public async Task BrandonTestProcessingSpeed()
        {
            //async Task AddMessages(int count)
            //{
            //    var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);

            //    var messages = Enumerable.Range(1, count)
            //        .Select(i => new Message(Encoding.UTF8.GetBytes($"test " + i)))
            //        .ToList();

            //    await sender.SendAsync(messages);
            //}


            // Single
            {
                //for (int x = 0; x < 15; ++x)
                //    await AddMessages(2500);


                var messagesReceived = 0;

                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock, prefetchCount: 800);

                var stopwatch = Stopwatch.StartNew();

                receiver.RegisterMessageHandler(
                    async (message, cancellationToken) => {
                        Interlocked.Add(ref messagesReceived, 1);

                        await Task.Delay(5);
                    }, 
                    new MessageHandlerOptions((args) => Task.CompletedTask) {
                        MaxConcurrentCalls = 8
                    });


                await Task.Delay(TimeSpan.FromSeconds(30));

                await receiver.CloseAsync();

                stopwatch.Stop();

                _output.WriteLine($"Single processed {messagesReceived} messages in {stopwatch.Elapsed} ({messagesReceived / stopwatch.Elapsed.TotalSeconds:N3} messages/sec).");
            }


            // Batch
            {
                //for (int x = 0; x < 15; ++x)
                //    await AddMessages(2500);


                var batchesReceived = 0;
                var messagesReceived = 0;

                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock, prefetchCount: 800);

                var stopwatch = Stopwatch.StartNew();

                receiver.RegisterMessageBatchHandler(
                    async (messages, cancellationToken) => {
                        Interlocked.Add(ref batchesReceived, 1);
                        Interlocked.Add(ref messagesReceived, messages.Count);

                        await Task.Delay(500);
                    },
                    new MessageBatchHandlerOptions((args) => Task.CompletedTask) {
                        MaxConcurrentCalls = 8
                    });


                await Task.Delay(TimeSpan.FromSeconds(30));

                await receiver.CloseAsync();

                stopwatch.Stop();

                _output.WriteLine($"Batch processed {messagesReceived} messages via {batchesReceived} batches in {stopwatch.Elapsed} ({messagesReceived / stopwatch.Elapsed.TotalSeconds:N3} messages/sec, {batchesReceived / stopwatch.Elapsed.TotalSeconds:N3} batches/sec).");
            }

        }

    }
}
