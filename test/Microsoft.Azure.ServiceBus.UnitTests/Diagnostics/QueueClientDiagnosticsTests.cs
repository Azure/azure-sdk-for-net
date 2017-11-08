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
        protected override string EntityName => TestConstants.NonPartitionedQueueName;
        private QueueClient queueClient;
        private bool disposed = false;

        [Fact]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabled()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);

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
        }

        [Fact]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabledForQueue()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.ReceiveAndDelete);

            Activity processActivity = null;

            ManualResetEvent processingDone = new ManualResetEvent(false);
            this.listener.Enable((name, queueName, arg) =>
                queueName == null || queueName.ToString() != TestConstants.NonPartitionedQueueName);

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
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendAndHandlerFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);

            Activity parentActivity = new Activity("test").AddBaggage("k1", "v1").AddBaggage("k2", "v2");
            Activity processActivity = null;
            bool exceptionCalled = false;
            ManualResetEvent processingDone = new ManualResetEvent(false);
            this.listener.Enable((name, queueName, arg) => !name.Contains("Receive") && !name.Contains("Exception"));

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
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, parentActivity);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

            Assert.True(this.events.TryDequeue(out var processStart));
            AssertProcessStart(processStart.eventName, processStart.payload, processStart.activity,
                sendStart.activity);

            // message is processed, but complete happens after that
            // let's wat until Complete starts and ends and Process ends
            int wait = 0;
            while (wait++ < maxWaitSec && this.events.Count < 3)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Assert.True(this.events.TryDequeue(out var completeStart));
            AssertCompleteStart(completeStart.eventName, completeStart.payload, completeStart.activity,
                processStart.activity);

            Assert.True(this.events.TryDequeue(out var completeStop));
            AssertCompleteStop(completeStop.eventName, completeStop.payload, completeStop.activity,
                completeStart.activity, processStart.activity);

            Assert.True(this.events.TryDequeue(out var processStop));
            AssertProcessStop(processStop.eventName, processStop.payload, processStop.activity,
                processStart.activity);

            Assert.False(this.events.TryDequeue(out var evnt));

            Assert.Equal(processStop.activity, processActivity);
            Assert.False(exceptionCalled);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendAndHandlerFireExceptionEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);

            bool exceptionCalled = false;

            ManualResetEvent processingDone = new ManualResetEvent(false);
            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);

            this.listener.Enable((name, queueName, arg) => !name.EndsWith(".Start") && !name.Contains("Receive") );

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
            AssertAbandonStop(abandonStop.eventName, abandonStop.payload, abandonStop.activity, null);

            Assert.True(this.events.TryDequeue(out var exception));
            AssertException(exception.eventName, exception.payload, exception.activity, null);

            Assert.True(this.events.TryDequeue(out var processStop));
            AssertProcessStop(processStop.eventName, processStop.payload, processStop.activity, null);

            Assert.Equal(processStop.activity, abandonStop.activity.Parent);
            Assert.Equal(processStop.activity, exception.activity);

            // message will be processed and compelted again
            wait = 0;
            while (wait++ < maxWaitSec && this.events.Count < 2 )
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Assert.True(this.events.TryDequeue(out var completeStop));
            AssertCompleteStop(completeStop.eventName, completeStop.payload, completeStop.activity, null, null);

            Assert.True(this.events.TryDequeue(out processStop));
            AssertProcessStop(processStop.eventName, processStop.payload, processStop.activity, null);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task AbandonCompleteFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);

            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
            var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

            this.listener.Enable((name, queueName, arg) => name.Contains("Abandon") || name.Contains("Complete"));
            await TestUtility.AbandonMessagesAsync(this.queueClient.InnerReceiver, messages);

            messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

            await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

            Assert.True(this.events.TryDequeue(out var abandonStart));
            AssertAbandonStart(abandonStart.eventName, abandonStart.payload, abandonStart.activity, null);

            Assert.True(this.events.TryDequeue(out var abandonStop));
            AssertAbandonStop(abandonStop.eventName, abandonStop.payload, abandonStop.activity,
                abandonStart.activity);

            Assert.True(this.events.TryDequeue(out var completeStart));
            AssertCompleteStart(completeStart.eventName, completeStart.payload, completeStart.activity, null);

            Assert.True(this.events.TryDequeue(out var completeStop));
            AssertCompleteStop(completeStop.eventName, completeStop.payload, completeStop.activity,
                completeStart.activity, null);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task BatchSendReceiveFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.ReceiveAndDelete);

            this.listener.Enable( (name, queuName, arg) => name.Contains("Send") || name.Contains("Receive") );
            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 2);
            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 3);
            var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 5);

            Assert.True(this.events.TryDequeue(out var sendStart1));
            AssertSendStart(sendStart1.eventName, sendStart1.payload, sendStart1.activity, null, 2);

            Assert.True(this.events.TryDequeue(out var sendStop1));
            AssertSendStop(sendStop1.eventName, sendStop1.payload, sendStop1.activity, sendStop1.activity, 2);

            Assert.True(this.events.TryDequeue(out var sendStart2));
            AssertSendStart(sendStart2.eventName, sendStart2.payload, sendStart2.activity, null, 3);

            Assert.True(this.events.TryDequeue(out var sendStop2));
            AssertSendStop(sendStop2.eventName, sendStop2.payload, sendStop2.activity, sendStop2.activity, 3);

            int receivedStopCount = 0;
            string relatedTo = "";
            while (this.events.TryDequeue(out var receiveStart))
            {
                var startCount = AssertReceiveStart(receiveStart.eventName, receiveStart.payload, receiveStart.activity,
                    -1);

                Assert.True(this.events.TryDequeue(out var receiveStop));
                receivedStopCount += AssertReceiveStop(receiveStop.eventName, receiveStop.payload, receiveStop.activity,
                    receiveStart.activity, null, startCount, -1);
                relatedTo += receiveStop.activity.Tags.Single(t => t.Key == "RelatedTo").Value;
            }

            Assert.Equal(5, receivedStopCount);
            Assert.Contains(sendStart1.activity.Id, relatedTo);
            Assert.Contains(sendStart2.activity.Id, relatedTo);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PeekFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.PeekLock);
            this.listener.Enable((name, queuName, arg) => name.Contains("Send") || name.Contains("Peek"));

            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
            await TestUtility.PeekMessageAsync(this.queueClient.InnerReceiver);

            this.listener.Disable();

            var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);
            await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

            Assert.True(this.events.TryDequeue(out var sendStart));
            AssertSendStart(sendStart.eventName, sendStart.payload, sendStart.activity, null);

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, sendStart.activity);

            Assert.True(this.events.TryDequeue(out var peekStart));
            AssertPeekStart(peekStart.eventName, peekStart.payload, peekStart.activity);

            Assert.True(this.events.TryDequeue(out var peekStop));
            AssertPeekStop(peekStop.eventName, peekStop.payload, peekStop.activity, peekStart.activity, sendStart.activity);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task DeadLetterFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);
            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
            var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

            this.listener.Enable((name, queuName, arg) => name.Contains("DeadLetter"));
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
            AssertDeadLetterStart(deadLetterStart.eventName, deadLetterStart.payload, deadLetterStart.activity, null);

            Assert.True(this.events.TryDequeue(out var deadLetterStop));
            AssertDeadLetterStop(deadLetterStop.eventName, deadLetterStop.payload, deadLetterStop.activity,
                deadLetterStart.activity);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task RenewLockFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);

            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
            var messages = await TestUtility.ReceiveMessagesAsync(this.queueClient.InnerReceiver, 1);

            this.listener.Enable((name, queuName, arg) => name.Contains("RenewLock"));
            await this.queueClient.InnerReceiver.RenewLockAsync(messages[0]);
            this.listener.Disable();

            await TestUtility.CompleteMessagesAsync(this.queueClient.InnerReceiver, messages);

            Assert.True(this.events.TryDequeue(out var renewStart));
            AssertRenewLockStart(renewStart.eventName, renewStart.payload, renewStart.activity, null);

            Assert.True(this.events.TryDequeue(out var renewStop));
            AssertRenewLockStop(renewStop.eventName, renewStop.payload, renewStop.activity, renewStart.activity);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task DeferReceiveDeferredFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.PeekLock);

            this.listener.Enable((name, queuName, arg) => name.Contains("Send") || name.Contains("Defer") || name.Contains("Receive"));

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
            AssertDeferStart(deferStart.eventName, deferStart.payload, deferStart.activity, null);

            Assert.True(this.events.TryDequeue(out var deferStop));
            AssertDeferStop(deferStop.eventName, deferStop.payload, deferStop.activity, deferStart.activity);

            Assert.True(this.events.TryDequeue(out var receiveDeferredStart));
            AssertReceiveDeferredStart(receiveDeferredStart.eventName, receiveDeferredStart.payload,
                receiveDeferredStart.activity);

            Assert.True(this.events.TryDequeue(out var receiveDeferredStop));
            AssertReceiveDeferredStop(receiveDeferredStop.eventName, receiveDeferredStop.payload,
                receiveDeferredStop.activity, receiveDeferredStart.activity, sendStart.activity);

            Assert.True(this.events.IsEmpty);
        }


        [Fact]
        [DisplayTestMethodName]
        async Task SendAndHandlerFilterOutStartEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);

            ManualResetEvent processingDone = new ManualResetEvent(false);
            this.listener.Enable((name, queueName, arg) => !name.EndsWith("Start") && !name.Contains("Receive") && !name.Contains("Exception"));

            await TestUtility.SendMessagesAsync(this.queueClient.InnerSender, 1);
            this.queueClient.RegisterMessageHandler((msg, ct) =>
                {
                    processingDone.Set();
                    return Task.CompletedTask;
                },
                exArgs => Task.CompletedTask);
            processingDone.WaitOne(TimeSpan.FromSeconds(maxWaitSec));

            Assert.True(this.events.TryDequeue(out var sendStop));
            AssertSendStop(sendStop.eventName, sendStop.payload, sendStop.activity, null);

            int wait = 0;
            while (wait++ < maxWaitSec && this.events.Count < 1)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Assert.True(this.events.TryDequeue(out var processStop));
            AssertProcessStop(processStop.eventName, processStop.payload, processStop.activity, null);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task ScheduleAndCancelFireEvents()
        {
            this.queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName,
                ReceiveMode.ReceiveAndDelete);

            Activity parentActivity = new Activity("test");
            this.listener.Enable((name, queuName, arg) => name.Contains("Schedule") || name.Contains("Cancel"));

            parentActivity.Start();

            var sequenceNumber = await this.queueClient.InnerSender.ScheduleMessageAsync(new Message(), DateTimeOffset.UtcNow.AddHours(1));
            await this.queueClient.InnerSender.CancelScheduledMessageAsync(sequenceNumber);

            Assert.True(this.events.TryDequeue(out var scheduleStart));
            AssertScheduleStart(scheduleStart.eventName, scheduleStart.payload, scheduleStart.activity,
                parentActivity);

            Assert.True(this.events.TryDequeue(out var scheduleStop));
            AssertScheduleStop(scheduleStop.eventName, scheduleStop.payload, scheduleStop.activity,
                scheduleStart.activity);

            Assert.True(this.events.TryDequeue(out var cancelStart));
            AssertCancelStart(cancelStart.eventName, cancelStart.payload, cancelStart.activity, parentActivity);

            Assert.True(this.events.TryDequeue(out var cancelStop));
            AssertCancelStop(cancelStop.eventName, cancelStop.payload, cancelStop.activity, cancelStart.activity);

            Assert.True(this.events.IsEmpty);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.queueClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
            }

            this.disposed = true;

            base.Dispose(disposing);
        }
    }
}