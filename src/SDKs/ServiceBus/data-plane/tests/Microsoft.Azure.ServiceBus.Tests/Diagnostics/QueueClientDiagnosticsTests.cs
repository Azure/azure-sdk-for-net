// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class QueueClientDiagnosticsTests : DiagnosticsTests
    {
        private QueueClient queueClient;        
        private bool disposed = false;

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabled()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {                
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                Activity processActivity = null;

                ManualResetEvent processingDone = new ManualResetEvent(false);
                this.listener.Disable();

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                this.queueClient.RegisterMessageHandler((msg, ct) => {
                        processActivity = Activity.Current;
                        processingDone.Set();
                        return Task.CompletedTask;
                    },
                    exArgs => Task.CompletedTask);

                processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));
                Assert.True(this.events.IsEmpty);
                Assert.Null(processActivity);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabledForQueue()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                Activity processActivity = null;
                ManualResetEvent processingDone = new ManualResetEvent(false);

                this.listener.Enable((name, queue, arg) =>
                    queueName == null || queue.ToString() != queueName);

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                this.queueClient.RegisterMessageHandler((msg, ct) =>
                    {
                        processActivity = Activity.Current;
                        processingDone.Set();
                        return Task.CompletedTask;
                    },
                    exArgs => Task.CompletedTask);

                processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));

                Assert.True(this.events.IsEmpty);
                Assert.Null(processActivity);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task SendAndHandlerFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
                Activity processActivity = null;
                bool exceptionCalled = false;
                ManualResetEvent processingDone = new ManualResetEvent(false);
                this.listener.Enable((name, queue, arg) => !name.Contains("Receive") && !name.Contains("Exception"));

                parentActivity.Start();

                await TestUtility.SendSessionMessagesAsync(this.queueClient.InnerSender, 1, 1);
                parentActivity.Stop();

                this.queueClient.RegisterMessageHandler((msg, ct) =>
                    {
                        processActivity = Activity.Current;
                        processingDone.Set();
                        return Task.CompletedTask;
                    },
                    exArgs =>
                    {
                        exceptionCalled = true;
                        return Task.CompletedTask;
                    });

                processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));

                Assert.True(this.events.TryDequeue(out var sendStart));
                AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity);

                Assert.True(this.events.TryDequeue(out var sendStop));
                AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                Assert.True(this.events.TryDequeue(out var processStart));
                AssertProcessStart(queueName, processStart.eventName, processStart.payload, processStart.activity,
                    sendStart.activity);

                // message is processed, but complete happens after that
                // let's wat until Complete starts and ends and Process ends
                int wait = 0;
                while (wait++ < maxWaitSec && this.events.Count < 3)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(this.events.TryDequeue(out var completeStart));
                AssertCompleteStart(queueName, completeStart.eventName, completeStart.payload, completeStart.activity,
                    processStart.activity);

                Assert.True(this.events.TryDequeue(out var completeStop));
                AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity,
                    completeStart.activity, processStart.activity);

                Assert.True(this.events.TryDequeue(out var processStop));
                AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity,
                    processStart.activity);

                Assert.False(this.events.TryDequeue(out var evnt));

                Assert.Equal(processStop.activity, processActivity);
                Assert.False(exceptionCalled);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task SendAndHandlerFireExceptionEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                bool exceptionCalled = false;

                ManualResetEvent processingDone = new ManualResetEvent(false);
                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);

                this.listener.Enable((name, queue, arg) => !name.EndsWith(".Start") && !name.Contains("Receive") );

                int count = 0;
                this.queueClient.RegisterMessageHandler((msg, ct) =>
                    {
                        if (count++ == 0)
                        {
                            throw new Exception("123");
                        }

                        processingDone.Set();
                        return Task.CompletedTask;
                    },
                    exArgs =>
                    {
                        exceptionCalled = true;
                        return Task.CompletedTask;
                    });
                processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));
                Assert.True(exceptionCalled);

                // message is processed, but abandon happens after that
                // let's spin until Complete call starts and ends
                int wait = 0;
                while (wait++ < maxWaitSec && this.events.Count < 3)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(this.events.TryDequeue(out var abandonStop));
                AssertAbandonStop(queueName, abandonStop.eventName, abandonStop.payload, abandonStop.activity, null);

                Assert.True(this.events.TryDequeue(out var exception));
                AssertException(queueName, exception.eventName, exception.payload, exception.activity, null);

                Assert.True(this.events.TryDequeue(out var processStop));
                AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, null);

                Assert.Equal(processStop.activity, abandonStop.activity.Parent);
                Assert.Equal(processStop.activity, exception.activity);

                // message will be processed and compelted again
                wait = 0;
                while (wait++ < maxWaitSec && this.events.Count < 2 )
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(this.events.TryDequeue(out var completeStop));
                AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity, null, null);

                Assert.True(this.events.TryDequeue(out processStop));
                AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, null);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task AbandonCompleteFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                
                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

                this.listener.Enable((name, queue, arg) => name.Contains("Abandon") || name.Contains("Complete"));
                await TestUtility.AbandonMessagesAsync(this.queueClient.InnerReceiver, messages);

                messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

                await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

                Assert.True(this.events.TryDequeue(out var abandonStart));
                AssertAbandonStart(queueName, abandonStart.eventName, abandonStart.payload, abandonStart.activity, null);

                Assert.True(this.events.TryDequeue(out var abandonStop));
                AssertAbandonStop(queueName, abandonStop.eventName, abandonStop.payload, abandonStop.activity,
                    abandonStart.activity);

                Assert.True(this.events.TryDequeue(out var completeStart));
                AssertCompleteStart(queueName, completeStart.eventName, completeStart.payload, completeStart.activity, null);

                Assert.True(this.events.TryDequeue(out var completeStop));
                AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity,
                    completeStart.activity, null);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task ReceiveNoMessageFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                this.listener.Enable((name, queue, arg) => name.Contains("Send") || name.Contains("Receive"));
                var messages = await this.queueClient.InnerReceiver.ReceiveAsync(2, TimeSpan.FromSeconds(5));

                int receivedStopCount = 0;
                Assert.Equal(2, this.events.Count);
                while (this.events.TryDequeue(out var receiveStart))
                {
                    var startCount = AssertReceiveStart(queueName, receiveStart.eventName, receiveStart.payload, receiveStart.activity, -1);

                    Assert.True(this.events.TryDequeue(out var receiveStop));
                    receivedStopCount += AssertReceiveStop(queueName, receiveStop.eventName, receiveStop.payload, receiveStop.activity,
                        receiveStart.activity, null, startCount, -1);
                }

                Assert.Equal(0, receivedStopCount);
                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task BatchSendReceiveFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                this.listener.Enable( (name, queueu, arg) => name.Contains("Send") || name.Contains("Receive") );
                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 2);
                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 3);
                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 5);

                Assert.True(this.events.TryDequeue(out var sendStart1));
                AssertSendStart(queueName, sendStart1.eventName, sendStart1.payload, sendStart1.activity, null, 2);

                Assert.True(this.events.TryDequeue(out var sendStop1));
                AssertSendStop(queueName, sendStop1.eventName, sendStop1.payload, sendStop1.activity, sendStop1.activity, 2);

                Assert.True(this.events.TryDequeue(out var sendStart2));
                AssertSendStart(queueName, sendStart2.eventName, sendStart2.payload, sendStart2.activity, null, 3);

                Assert.True(this.events.TryDequeue(out var sendStop2));
                AssertSendStop(queueName, sendStop2.eventName, sendStop2.payload, sendStop2.activity, sendStop2.activity, 3);

                int receivedStopCount = 0;
                string relatedTo = "";
                while (this.events.TryDequeue(out var receiveStart))
                {
                    var startCount = AssertReceiveStart(queueName, receiveStart.eventName, receiveStart.payload, receiveStart.activity, -1);

                    Assert.True(this.events.TryDequeue(out var receiveStop));
                    receivedStopCount += AssertReceiveStop(queueName, receiveStop.eventName, receiveStop.payload, receiveStop.activity,
                        receiveStart.activity, null, startCount, -1);
                    relatedTo += receiveStop.activity.Tags.Single(t => t.Key == "RelatedTo").Value;
                }

                Assert.Equal(5, receivedStopCount);
                Assert.Contains(sendStart1.activity.Id, relatedTo);
                Assert.Contains(sendStart2.activity.Id, relatedTo);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                this.listener.Enable((name, queuName, arg) => name.Contains("Send") || name.Contains("Peek"));

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                await TestUtility.PeekMessageAsync(this.queueClient.InnerReceiver);

                this.listener.Disable();

                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);
                await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

                Assert.True(this.events.TryDequeue(out var sendStart));
                AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, null);

                Assert.True(this.events.TryDequeue(out var sendStop));
                AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                Assert.True(this.events.TryDequeue(out var peekStart));
                AssertPeekStart(queueName, peekStart.eventName, peekStart.payload, peekStart.activity);

                Assert.True(this.events.TryDequeue(out var peekStop));
                AssertPeekStop(queueName, peekStop.eventName, peekStop.payload, peekStop.activity, peekStart.activity, sendStart.activity);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task DeadLetterFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

                this.listener.Enable((name, queue, arg) => name.Contains("DeadLetter"));
                await TestUtility.DeadLetterMessagesAsync(this.queueClient.InnerReceiver, messages);
                this.listener.Disable();

                QueueClient deadLetterQueueClient = null;
                try
                {
                    deadLetterQueueClient = new QueueClient(TestUtility.NamespaceConnectionString,
                        EntityNameHelper.FormatDeadLetterPath(this.queueClient.QueueName), ReceiveMode.ReceiveAndDelete);
                    await TestUtility.ReceiveMessagesAsync(deadLetterQueueClient.InnerReceiver, 1);
                }
                finally
                {
                    deadLetterQueueClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
                }

                Assert.True(this.events.TryDequeue(out var deadLetterStart));
                AssertDeadLetterStart(queueName, deadLetterStart.eventName, deadLetterStart.payload, deadLetterStart.activity, null);

                Assert.True(this.events.TryDequeue(out var deadLetterStop));
                AssertDeadLetterStop(queueName, deadLetterStop.eventName, deadLetterStop.payload, deadLetterStop.activity,
                    deadLetterStart.activity);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task RenewLockFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

                this.listener.Enable((name, queue, arg) => name.Contains("RenewLock"));
                await this.queueClient.InnerReceiver.RenewLockAsync(messages[0]);
                this.listener.Disable();

                await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

                Assert.True(this.events.TryDequeue(out var renewStart));
                AssertRenewLockStart(queueName, renewStart.eventName, renewStart.payload, renewStart.activity, null);

                Assert.True(this.events.TryDequeue(out var renewStop));
                AssertRenewLockStop(queueName, renewStop.eventName, renewStop.payload, renewStop.activity, renewStart.activity);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task DeferReceiveDeferredFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                this.listener.Enable((name, queue, arg) => name.Contains("Send") || name.Contains("Defer") || name.Contains("Receive"));

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);
                await TestUtility.DeferMessagesAsync(this.queueClient.InnerReceiver, messages);
                var message = await this.queueClient.InnerReceiver.ReceiveDeferredMessageAsync(messages[0]
                    .SystemProperties
                    .SequenceNumber);

                this.listener.Disable();
                await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, new[] {message});

                Assert.True(this.events.TryDequeue(out var sendStart));
                Assert.True(this.events.TryDequeue(out var sendStop));
                Assert.True(this.events.TryDequeue(out var receiveStart));
                Assert.True(this.events.TryDequeue(out var receiveStop));

                Assert.True(this.events.TryDequeue(out var deferStart));
                AssertDeferStart(queueName, deferStart.eventName, deferStart.payload, deferStart.activity, null);

                Assert.True(this.events.TryDequeue(out var deferStop));
                AssertDeferStop(queueName, deferStop.eventName, deferStop.payload, deferStop.activity, deferStart.activity);

                Assert.True(this.events.TryDequeue(out var receiveDeferredStart));
                AssertReceiveDeferredStart(queueName, receiveDeferredStart.eventName, receiveDeferredStart.payload,
                    receiveDeferredStart.activity);

                Assert.True(this.events.TryDequeue(out var receiveDeferredStop));
                AssertReceiveDeferredStop(queueName, receiveDeferredStop.eventName, receiveDeferredStop.payload,
                    receiveDeferredStop.activity, receiveDeferredStart.activity, sendStart.activity);

                Assert.True(this.events.IsEmpty);
            });
        }


        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task SendAndHandlerFilterOutStartEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                ManualResetEvent processingDone = new ManualResetEvent(false);
                this.listener.Enable((name, queue, arg) => !name.EndsWith("Start") && !name.Contains("Receive") && !name.Contains("Exception"));

                await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
                this.queueClient.RegisterMessageHandler((msg, ct) =>
                    {
                        processingDone.Set();
                        return Task.CompletedTask;
                    },
                    exArgs => Task.CompletedTask);
                processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));

                Assert.True(this.events.TryDequeue(out var sendStop));
                AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, null);

                int wait = 0;
                while (wait++ < maxWaitSec && this.events.Count < 1)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }

                Assert.True(this.events.TryDequeue(out var processStop));
                AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, null);

                Assert.True(this.events.IsEmpty);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task ScheduleAndCancelFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                Activity parentActivity = new Activity("test");
                this.listener.Enable((name, queue, arg) => name.Contains("Schedule") || name.Contains("Cancel"));

                parentActivity.Start();

                var sequenceNumber = await this.queueClient.InnerSender.ScheduleMessageAsync(new Message(), DateTimeOffset.UtcNow.AddHours(1));
                await this.queueClient.InnerSender.CancelScheduledMessageAsync(sequenceNumber);

                Assert.True(this.events.TryDequeue(out var scheduleStart));
                AssertScheduleStart(queueName, scheduleStart.eventName, scheduleStart.payload, scheduleStart.activity,
                    parentActivity);

                Assert.True(this.events.TryDequeue(out var scheduleStop));
                AssertScheduleStop(queueName, scheduleStop.eventName, scheduleStop.payload, scheduleStop.activity,
                    scheduleStart.activity);

                Assert.True(this.events.TryDequeue(out var cancelStart));
                AssertCancelStart(queueName, cancelStart.eventName, cancelStart.payload, cancelStart.activity, parentActivity);

                Assert.True(this.events.TryDequeue(out var cancelStop));
                AssertCancelStop(queueName, cancelStop.eventName, cancelStop.payload, cancelStop.activity, cancelStart.activity);

                Assert.True(this.events.IsEmpty);
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.queueClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
            }

            base.Dispose(disposing);
            this.disposed = true;
        }
    }
}