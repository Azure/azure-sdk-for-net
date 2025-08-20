// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    [Collection(nameof(DiagnosticsTests))]
    public sealed class QueueClientDiagnosticsTests : DiagnosticsTests
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndHandlerFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, arg) => !name.Contains("Receive") && !name.Contains("Exception"));

                        var parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");

                        parentActivity.Start();
                        await TestUtility.SendSessionMessagesAsync(queueClient.InnerSender, 1, 1);
                        parentActivity.Stop();

                        var exceptionCalled = false;
                        var tcs = new TaskCompletionSource<Activity>(TaskCreationOptions.RunContinuationsAsynchronously);

                        queueClient.RegisterMessageHandler((msg, ct) =>
                        {
                            tcs.TrySetResult(Activity.Current);
                            return Task.CompletedTask;
                        },
                        exArgs =>
                        {
                            // Do not set the completion source exception to avoid throwing
                            // when the task is awaited.  The sentinal variable is checked to detect
                            // exception cases.
                            exceptionCalled = true;
                            return Task.CompletedTask;
                        });

                        var processActivity = await tcs.Task.WithTimeout(DefaultTimeout);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var processStart));
                        AssertProcessStart(queueName, processStart.eventName, processStart.payload, processStart.activity, sendStart.activity);

                        // message is processed, but complete happens after that
                        // let's wat until Complete starts and ends and Process ends
                        int wait = 0;
                        while (wait++ < MaxWaitSec && eventQueue.Count < 3)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }

                        Assert.True(eventQueue.TryDequeue(out var completeStart));
                        AssertCompleteStart(queueName, completeStart.eventName, completeStart.payload, completeStart.activity, processStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var completeStop));
                        AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity, completeStart.activity, processStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var processStop));
                        AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, processStart.activity);

                        Assert.False(eventQueue.TryDequeue(out var evnt));

                        Assert.Equal(processStop.activity, processActivity);
                        Assert.False(exceptionCalled);
                    }
                }
                finally
                {
                    await queueClient?.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndHandlerFireExceptionEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        listener.Enable((name, queue, arg) => !name.EndsWith(".Start") && !name.Contains("Receive") );

                        var count = 0;
                        var exceptionCalled = false;
                        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                        queueClient.RegisterMessageHandler((msg, ct) =>
                        {
                            if (count++ == 0)
                            {
                                throw new Exception("123");
                            }
                            tcs.TrySetResult(count);
                            return Task.CompletedTask;
                        },
                        exArgs =>
                        {
                            // Do not set the completion source exception to avoid throwing
                            // when the task is awaited.  The sentinal variable is checked to detect
                            // exception cases.
                            exceptionCalled = true;
                            return Task.CompletedTask;
                        });

                        await tcs.Task.WithTimeout(DefaultTimeout);
                        Assert.True(exceptionCalled);

                        // message is processed, but abandon happens after that
                        // let's spin until Complete call starts and ends
                        int wait = 0;
                        while (wait++ < MaxWaitSec && eventQueue.Count < 3)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }

                        Assert.True(eventQueue.TryDequeue(out var abandonStop));
                        AssertAbandonStop(queueName, abandonStop.eventName, abandonStop.payload, abandonStop.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var exception));
                        AssertException(queueName, exception.eventName, exception.payload, exception.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var processStop));
                        AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, null);

                        Assert.Equal(processStop.activity, abandonStop.activity.Parent);
                        Assert.Equal(processStop.activity, exception.activity);

                        // message will be processed and compelted again
                        wait = 0;
                        while (wait++ < MaxWaitSec && eventQueue.Count < 2 )
                        {
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }

                        Assert.True(eventQueue.TryDequeue(out var completeStop));
                        AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity, null, null);

                        Assert.True(eventQueue.TryDequeue(out processStop));
                        AssertProcessStop(queueName, processStop.eventName, processStop.payload, processStop.activity, null);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient?.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task AbandonCompleteFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);

                        listener.Enable((name, queue, arg) => name.Contains("Abandon") || name.Contains("Complete"));
                        await TestUtility.AbandonMessagesAsync(queueClient.InnerReceiver, messages);

                        messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);

                        await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);

                        Assert.True(eventQueue.TryDequeue(out var abandonStart));
                        AssertAbandonStart(queueName, abandonStart.eventName, abandonStart.payload, abandonStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var abandonStop));
                        AssertAbandonStop(queueName, abandonStop.eventName, abandonStop.payload, abandonStop.activity, abandonStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var completeStart));
                        AssertCompleteStart(queueName, completeStart.eventName, completeStart.payload, completeStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var completeStop));
                        AssertCompleteStop(queueName, completeStop.eventName, completeStop.payload, completeStop.activity, completeStart.activity, null);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveNoMessageFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, arg) => name.Contains("Send") || name.Contains("Receive"));
                        var messages = await queueClient.InnerReceiver.ReceiveAsync(2, TimeSpan.FromSeconds(5));

                        int receivedStopCount = 0;
                        Assert.Equal(2, eventQueue.Count);
                        while (eventQueue.TryDequeue(out var receiveStart))
                        {
                            var startCount = AssertReceiveStart(queueName, receiveStart.eventName, receiveStart.payload, receiveStart.activity, -1);

                            Assert.True(eventQueue.TryDequeue(out var receiveStop));
                            receivedStopCount += AssertReceiveStop(queueName, receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity, null, startCount, -1);
                        }

                        Assert.Equal(0, receivedStopCount);
                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task BatchSendReceiveFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable( (name, queue, arg) => name.Contains("Send") || name.Contains("Receive") );
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 2);
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 3);
                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 5);

                        Assert.True(eventQueue.TryDequeue(out var sendStart1));
                        AssertSendStart(queueName, sendStart1.eventName, sendStart1.payload, sendStart1.activity, null, 2);

                        Assert.True(eventQueue.TryDequeue(out var sendStop1));
                        AssertSendStop(queueName, sendStop1.eventName, sendStop1.payload, sendStop1.activity, sendStop1.activity, 2);

                        Assert.True(eventQueue.TryDequeue(out var sendStart2));
                        AssertSendStart(queueName, sendStart2.eventName, sendStart2.payload, sendStart2.activity, null, 3);

                        Assert.True(eventQueue.TryDequeue(out var sendStop2));
                        AssertSendStop(queueName, sendStop2.eventName, sendStop2.payload, sendStop2.activity, sendStop2.activity, 3);

                        int receivedStopCount = 0;
                        string relatedTo = "";
                        while (eventQueue.TryDequeue(out var receiveStart))
                        {
                            var startCount = AssertReceiveStart(queueName, receiveStart.eventName, receiveStart.payload, receiveStart.activity, -1);

                            Assert.True(eventQueue.TryDequeue(out var receiveStop));

                            receivedStopCount +=
                                AssertReceiveStop(queueName, receiveStop.eventName, receiveStop.payload, receiveStop.activity, receiveStart.activity, null, startCount, -1);

                            relatedTo += receiveStop.activity.Tags.Single(t => t.Key == "RelatedTo").Value;
                        }

                        Assert.Equal(5, receivedStopCount);
                        Assert.Contains(sendStart1.activity.Id, relatedTo);
                        Assert.Contains(sendStart2.activity.Id, relatedTo);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queuName, arg) => name.Contains("Send") || name.Contains("Peek"));

                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        await TestUtility.PeekMessageAsync(queueClient.InnerReceiver);

                        listener.Disable();

                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                        await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        AssertSendStart(queueName, sendStart.eventName, sendStart.payload, sendStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        AssertSendStop(queueName, sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var peekStart));
                        AssertPeekStart(queueName, peekStart.eventName, peekStart.payload, peekStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var peekStop));
                        AssertPeekStop(queueName, peekStop.eventName, peekStop.payload, peekStop.activity, peekStart.activity, sendStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        private async Task DeadLetterFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);

                        listener.Enable((name, queue, arg) => name.Contains("DeadLetter"));
                        await TestUtility.DeadLetterMessagesAsync(queueClient.InnerReceiver, messages);
                        listener.Disable();

                        QueueClient deadLetterQueueClient = null;
                        try
                        {
                            deadLetterQueueClient = new QueueClient(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName), ReceiveMode.ReceiveAndDelete);
                            await TestUtility.ReceiveMessagesAsync(deadLetterQueueClient.InnerReceiver, 1);
                        }
                        finally
                        {
                            await deadLetterQueueClient?.CloseAsync();
                        }

                        Assert.True(eventQueue.TryDequeue(out var deadLetterStart));
                        AssertDeadLetterStart(queueName, deadLetterStart.eventName, deadLetterStart.payload, deadLetterStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var deadLetterStop));
                        AssertDeadLetterStop(queueName, deadLetterStop.eventName, deadLetterStop.payload, deadLetterStop.activity, deadLetterStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task RenewLockFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);

                        listener.Enable((name, queue, arg) => name.Contains("RenewLock"));
                        await queueClient.InnerReceiver.RenewLockAsync(messages[0]);
                        listener.Disable();

                        await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);

                        Assert.True(eventQueue.TryDequeue(out var renewStart));
                        AssertRenewLockStart(queueName, renewStart.eventName, renewStart.payload, renewStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var renewStop));
                        AssertRenewLockStop(queueName, renewStop.eventName, renewStop.payload, renewStop.activity, renewStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DeferReceiveDeferredFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, arg) => name.Contains("Send") || name.Contains("Defer") || name.Contains("Receive"));

                        await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                        var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                        await TestUtility.DeferMessagesAsync(queueClient.InnerReceiver, messages);
                        var message = await queueClient.InnerReceiver.ReceiveDeferredMessageAsync(messages[0].SystemProperties.SequenceNumber);

                        listener.Disable();
                        await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, new[] {message});

                        Assert.True(eventQueue.TryDequeue(out var sendStart));
                        Assert.True(eventQueue.TryDequeue(out var sendStop));
                        Assert.True(eventQueue.TryDequeue(out var receiveStart));
                        Assert.True(eventQueue.TryDequeue(out var receiveStop));

                        Assert.True(eventQueue.TryDequeue(out var deferStart));
                        AssertDeferStart(queueName, deferStart.eventName, deferStart.payload, deferStart.activity, null);

                        Assert.True(eventQueue.TryDequeue(out var deferStop));
                        AssertDeferStop(queueName, deferStop.eventName, deferStop.payload, deferStop.activity, deferStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var receiveDeferredStart));
                        AssertReceiveDeferredStart(queueName, receiveDeferredStart.eventName, receiveDeferredStart.payload, receiveDeferredStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var receiveDeferredStop));
                        AssertReceiveDeferredStop(queueName, receiveDeferredStop.eventName, receiveDeferredStop.payload,
                            receiveDeferredStop.activity, receiveDeferredStart.activity, sendStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ScheduleAndCancelFireEvents()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();

                try
                {
                    using (var listener = this.CreateEventListener(queueName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        Activity parentActivity = new Activity("test");
                        listener.Enable((name, queue, arg) => name.Contains("Schedule") || name.Contains("Cancel"));

                        parentActivity.Start();

                        var sequenceNumber = await queueClient.InnerSender.ScheduleMessageAsync(new Message(), DateTimeOffset.UtcNow.AddHours(1));
                        await queueClient.InnerSender.CancelScheduledMessageAsync(sequenceNumber);

                        Assert.True(eventQueue.TryDequeue(out var scheduleStart));
                        AssertScheduleStart(queueName, scheduleStart.eventName, scheduleStart.payload, scheduleStart.activity,
                            parentActivity);

                        Assert.True(eventQueue.TryDequeue(out var scheduleStop));
                        AssertScheduleStop(queueName, scheduleStop.eventName, scheduleStop.payload, scheduleStop.activity,
                            scheduleStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var cancelStart));
                        AssertCancelStart(queueName, cancelStart.eventName, cancelStart.payload, cancelStart.activity, parentActivity);

                        Assert.True(eventQueue.TryDequeue(out var cancelStop));
                        AssertCancelStop(queueName, cancelStop.eventName, cancelStop.payload, cancelStop.activity, cancelStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }
    }
}