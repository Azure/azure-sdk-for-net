// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ProcessorLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Receive_Event(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);

                // use double the number of threads so we can make sure we test that we don't
                // retrieve more messages than expected when there are more messages available
                await sender.SendBatchAsync(GetMessages(numThreads * 2));
                await using var processor = new ServiceBusProcessorClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int messageCt = 0;

                var options = new ProcessingOptions()
                {
                    MaxConcurrentCalls = numThreads
                };

                TaskCompletionSource<bool>[] completionSources = Enumerable
                .Range(0, numThreads)
                .Select(index => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously))
                .ToArray();
                var completionSourceIndex = -1;

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync(options);

                async Task ProcessMessage(ServiceBusMessage message, ServiceBusSession session)
                {
                    await processor.CompleteAsync(message.SystemProperties.LockToken);
                    Interlocked.Increment(ref messageCt);
                    var setIndex = Interlocked.Increment(ref completionSourceIndex);
                    completionSources[setIndex].TrySetResult(true);
                }
                await Task.WhenAll(completionSources.Select(source => source.Task));

                // we complete each thread after one message being processed, so the total number of messages
                // processed should equal the number of threads
                Assert.AreEqual(numThreads, messageCt);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public async Task Receive_StopProcessing(int numThreads)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int numMessages = 50;
                await sender.SendBatchAsync(GetMessages(numMessages));

                await using var processor = new ServiceBusProcessorClient(
                    TestEnvironment.ServiceBusConnectionString,
                    scope.QueueName);
                int messageProcessedCt = 0;

                // stop processing halfway through
                int stopAfterMessagesCt = numMessages / 2;
                var options = new ProcessingOptions()
                {
                    MaxConcurrentCalls = numThreads
                };

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync(options);

                async Task ProcessMessage(ServiceBusMessage message, ServiceBusSession session)
                {
                    Interlocked.Increment(ref messageProcessedCt);
                    if (messageProcessedCt == stopAfterMessagesCt)
                    {
                        await processor.StopProcessingAsync();
                        tcs.TrySetResult(true);
                    }
                }
                await tcs.Task;
                var remainingCt = 0;
                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);

                foreach (ServiceBusMessage message in await receiver.ReceiveBatchAsync(numMessages))
                {
                    remainingCt++;
                }

                // can't assert on the exact amount processed due to threads that
                // are already in flight when calling StopProcessingAsync, but we can at least verify that there are remaining messages
                Assert.IsTrue(remainingCt > 0);
                Assert.IsTrue(messageProcessedCt < numMessages);

            }
        }
    }
}
