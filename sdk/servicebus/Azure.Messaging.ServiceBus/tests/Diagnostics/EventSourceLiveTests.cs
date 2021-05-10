﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Tests.Plugins;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
    [NonParallelizable]
    public class EventSourceLiveTests : ServiceBusLiveTestBase
    {
        private TestEventListener _listener;

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(ServiceBusEventSource.Log, EventLevel.Verbose);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [Test]
        public async Task LogsEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateNoRetryClient();
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.FullyQualifiedNamespace));
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                _listener.EventsById(ServiceBusEventSource.ClientCreateStartEvent).Where(e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.FullyQualifiedNamespace) && e.Payload.Contains(sender.EntityPath));
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                _listener.SingleEventById(ServiceBusEventSource.CreateMessageBatchStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateMessageBatchCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);
                _listener.SingleEventById(ServiceBusEventSource.CreateSendLinkStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationCompleteEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateSendLinkCompleteEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.SendMessageStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.SendMessageCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                Assert.That(
                    async () => await client.AcceptNextSessionAsync(scope.QueueName),
                    Throws.InstanceOf<InvalidOperationException>());
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusSessionReceiver)) && e.Payload.Contains(client.FullyQualifiedNamespace) && e.Payload.Contains(scope.QueueName));
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateExceptionEvent, e => e.Payload.Contains(nameof(ServiceBusSessionReceiver)) && e.Payload.Contains(client.FullyQualifiedNamespace) && e.Payload.Contains(scope.QueueName));

                var receiver = client.CreateReceiver(scope.QueueName);
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(client.FullyQualifiedNamespace));

                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(item.DeliveryCount, 1);
                    }
                }
                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationCompleteEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkCompleteEvent, e => e.Payload.Contains(receiver.Identifier));
                Assert.IsTrue(_listener.EventsById(ServiceBusEventSource.ReceiveMessageStartEvent).Any());
                Assert.IsTrue(_listener.EventsById(ServiceBusEventSource.ReceiveMessageCompleteEvent).Any());
                Assert.AreEqual(0, remainingMessages);
                messageEnum.Reset();

                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }

                _listener.SingleEventById(ServiceBusEventSource.CreateManagementLinkStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateManagementLinkCompleteEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.PeekMessageStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.PeekMessageCompleteEvent, e => e.Payload.Contains(receiver.Identifier));

                var seq = await sender.ScheduleMessageAsync(new ServiceBusMessage(), DateTimeOffset.UtcNow.AddMinutes(1));
                _listener.SingleEventById(ServiceBusEventSource.ScheduleMessageStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ScheduleMessageCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                await sender.CancelScheduledMessageAsync(seq);
                _listener.SingleEventById(ServiceBusEventSource.CancelScheduledMessageStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CancelScheduledMessageCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                await receiver.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(receiver.Identifier));
                // link closed event is fired asynchronously, so add a small delay
                await Task.Delay(TimeSpan.FromSeconds(5));
                _listener.SingleEventById(ServiceBusEventSource.ReceiveLinkClosedEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ManagementLinkClosedEvent, e => e.Payload.Contains(receiver.Identifier));

                Assert.IsFalse(_listener.EventsById(ServiceBusEventSource.MaxMessagesExceedsPrefetchEvent).Any());
                receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions { PrefetchCount = 10 });
                await receiver.ReceiveMessagesAsync(20, TimeSpan.FromSeconds(1));
                _listener.SingleEventById(ServiceBusEventSource.MaxMessagesExceedsPrefetchEvent, e => e.Payload.Contains(receiver.Identifier));

                await sender.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.Identifier));

                await client.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.Identifier));
            }
        }

        [Test]
        public async Task LogsSessionEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateNoRetryClient();
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.FullyQualifiedNamespace));
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.FullyQualifiedNamespace) && e.Payload.Contains(sender.EntityPath));
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                _listener.SingleEventById(ServiceBusEventSource.CreateMessageBatchStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateMessageBatchCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount, "sessionId").AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);
                _listener.SingleEventById(ServiceBusEventSource.CreateSendLinkStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.RequestAuthorizationCompleteEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateSendLinkCompleteEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.SendMessageStartEvent, e => e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.SendMessageCompleteEvent, e => e.Payload.Contains(sender.Identifier));

                var receiver = client.CreateReceiver(scope.QueueName);
                _listener.SingleEventById(ServiceBusEventSource.ClientCreateStartEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(client.FullyQualifiedNamespace));

                // can't use a non-session receiver for session queue
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<InvalidOperationException>());

                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkExceptionEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ReceiveMessageStartEvent, e => e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ReceiveMessageExceptionEvent, e => e.Payload.Contains(receiver.Identifier));

                var sessionReceiver = await client.AcceptNextSessionAsync(scope.QueueName);
                _listener.EventsById(ServiceBusEventSource.ClientCreateStartEvent).Where(e => e.Payload.Contains(nameof(ServiceBusSessionReceiver)) && e.Payload.Contains(client.FullyQualifiedNamespace)).Any();
                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkStartEvent, e => e.Payload.Contains(sessionReceiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateReceiveLinkCompleteEvent, e => e.Payload.Contains(sessionReceiver.Identifier));

                var msg = await sessionReceiver.ReceiveMessageAsync();
                _listener.SingleEventById(ServiceBusEventSource.ReceiveMessageStartEvent, e => e.Payload.Contains(sessionReceiver.Identifier));

                msg = await sessionReceiver.PeekMessageAsync();
                _listener.SingleEventById(ServiceBusEventSource.CreateManagementLinkStartEvent, e => e.Payload.Contains(sessionReceiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.CreateManagementLinkCompleteEvent, e => e.Payload.Contains(sessionReceiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.PeekMessageStartEvent, e => e.Payload.Contains(sessionReceiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.PeekMessageCompleteEvent, e => e.Payload.Contains(sessionReceiver.Identifier));

                await receiver.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(receiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusReceiver)) && e.Payload.Contains(receiver.Identifier));

                await sessionReceiver.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusSessionReceiver)) && e.Payload.Contains(sessionReceiver.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusSessionReceiver)) && e.Payload.Contains(sessionReceiver.Identifier));
                await Task.Delay(TimeSpan.FromSeconds(2));
                _listener.SingleEventById(ServiceBusEventSource.ReceiveLinkClosedEvent, e => e.Payload.Contains(sessionReceiver.Identifier) &&
                  e.Payload.Contains(sessionReceiver.SessionId));

                await sender.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusSender)) && e.Payload.Contains(sender.Identifier));

                await client.DisposeAsync();
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseStartEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.Identifier));
                _listener.SingleEventById(ServiceBusEventSource.ClientCloseCompleteEvent, e => e.Payload.Contains(nameof(ServiceBusClient)) && e.Payload.Contains(client.Identifier));
            }
        }

        [Test]
        public async Task LogsTransactionEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                ServiceBusMessage message = GetMessage();

                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(message);
                    ts.Complete();
                }
                // Adding delay since transaction Commit/Rollback is an asynchronous operation.
                await Task.Delay(TimeSpan.FromSeconds(2));
                _listener.SingleEventById(ServiceBusEventSource.TransactionDeclaredEvent);
                _listener.SingleEventById(ServiceBusEventSource.TransactionDischargedEvent);
            };
        }

        [Test]
        public async Task LogsPluginEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                options.AddPlugin(new PluginLiveTests.SendReceivePlugin());
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage message = GetMessage();
                await sender.SendMessageAsync(message);
                _listener.SingleEventById(ServiceBusEventSource.PluginStartEvent);
                _listener.SingleEventById(ServiceBusEventSource.PluginCompleteEvent);
                var receiver = client.CreateReceiver(scope.QueueName);
                await receiver.ReceiveMessageAsync();
                Assert.AreEqual(2, _listener.EventsById(ServiceBusEventSource.PluginStartEvent).Count());
                Assert.AreEqual(2, _listener.EventsById(ServiceBusEventSource.PluginCompleteEvent).Count());
            };
        }

        [Test]
        public async Task LogsPluginExceptionEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                options.AddPlugin(new PluginLiveTests.SendExceptionPlugin());
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage message = GetMessage();
                Assert.That(
                    async () => await sender.SendMessageAsync(message),
                    Throws.InstanceOf<NotImplementedException>());
                _listener.SingleEventById(ServiceBusEventSource.PluginStartEvent);
                _listener.SingleEventById(ServiceBusEventSource.PluginExceptionEvent);

                options = new ServiceBusClientOptions();
                options.AddPlugin(new PluginLiveTests.ReceiveExceptionPlugin());
                client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, options);
                sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(message);
                Assert.AreEqual(2, _listener.EventsById(ServiceBusEventSource.PluginStartEvent).Count());
                Assert.AreEqual(1, _listener.EventsById(ServiceBusEventSource.PluginExceptionEvent).Count());

                var receiver = client.CreateReceiver(scope.QueueName);
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(),
                    Throws.InstanceOf<NotImplementedException>());
                Assert.AreEqual(3, _listener.EventsById(ServiceBusEventSource.PluginStartEvent).Count());
                Assert.AreEqual(2, _listener.EventsById(ServiceBusEventSource.PluginExceptionEvent).Count());
            };
        }

        [Test]
        public async Task LogsProcessorEvents()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
                await using var processor = client.CreateProcessor(scope.QueueName);
                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    tcs.SetResult(true);
                    return Task.CompletedTask;
                }

                Task ExceptionHandler(ProcessErrorEventArgs args)
                {
                    return Task.CompletedTask;
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                _listener.SingleEventById(ServiceBusEventSource.ProcessorMessageHandlerStartEvent);
                _listener.SingleEventById(ServiceBusEventSource.ProcessorMessageHandlerCompleteEvent);
            }
        }

        [Test]
        public async Task LogsProcessorExceptionEvent()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());
                await using var processor = client.CreateProcessor(scope.QueueName);
                var tcs = new TaskCompletionSource<bool>();

                Task ProcessMessage(ProcessMessageEventArgs args)
                {
                    tcs.SetResult(true);
                    throw new Exception();
                }

                Task ExceptionHandler(ProcessErrorEventArgs args)
                {
                    throw new Exception();
                }

                processor.ProcessMessageAsync += ProcessMessage;
                processor.ProcessErrorAsync += ExceptionHandler;

                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                _listener.SingleEventById(ServiceBusEventSource.ProcessorMessageHandlerStartEvent);
                _listener.SingleEventById(ServiceBusEventSource.ProcessorMessageHandlerExceptionEvent);
                _listener.SingleEventById(ServiceBusEventSource.ProcessorErrorHandlerThrewExceptionEvent);
            }
        }

        [Test]
        public async Task LogsProcessorClientClosedExceptionEvent()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var messageCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

                await using var client = CreateClient(60);
                await SendMessagesAsync(client, scope.QueueName, 100);

                await using var processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = true,
                    PrefetchCount = 20
                });

                processor.ProcessMessageAsync += args =>
                {
                    messageCompletionSource.TrySetResult(true);
                    return Task.CompletedTask;
                };

                processor.ProcessErrorAsync += args => Task.CompletedTask;

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromMinutes(10));

                await processor.StartProcessingAsync(cancellationSource.Token);
                await messageCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
                await client.DisposeAsync();

                while (processor.IsProcessing)
                {
                    await Task.Delay(500, cancellationSource.Token);
                }

                _listener.SingleEventById(ServiceBusEventSource.ProcessorClientClosedExceptionEvent);
            }
        }

        [Test]
        public async Task DoesNotLogAcceptSessionTimeoutAsError()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateNoRetryClient(5);
                await using var processor = client.CreateSessionProcessor(scope.QueueName);

                processor.ProcessMessageAsync += args => Task.CompletedTask;
                processor.ProcessErrorAsync += args => Task.CompletedTask;

                await processor.StartProcessingAsync();

                // wait twice as long as the try timeout to ensure that the Accept session will timeout
                await Task.Delay(TimeSpan.FromSeconds(10));

                await processor.StopProcessingAsync();

                Assert.False(_listener.EventsById(ServiceBusEventSource.CreateReceiveLinkExceptionEvent).Any());
                Assert.False(_listener.EventsById(ServiceBusEventSource.ClientCreateExceptionEvent).Any());
                Assert.True(_listener.EventsById(ServiceBusEventSource.ProcessorAcceptSessionTimeoutEvent).Any());
                Assert.True(_listener.EventsById(ServiceBusEventSource.ProcessorStoppingAcceptSessionCanceledEvent).Any());
            }
        }

        [Test]
        public async Task StoppingProcessorDoesNotLogTaskCanceledExceptions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateNoRetryClient(5);
                await using var processor = client.CreateProcessor(scope.QueueName);

                processor.ProcessMessageAsync += args => Task.CompletedTask;
                processor.ProcessErrorAsync += args => Task.CompletedTask;

                await processor.StartProcessingAsync();

                // wait twice as long as the try timeout to ensure that the Accept session will timeout
                await Task.Delay(TimeSpan.FromSeconds(10));

                await processor.StopProcessingAsync();

                Assert.False(_listener.EventsById(ServiceBusEventSource.CreateReceiveLinkExceptionEvent).Any());
                Assert.False(_listener.EventsById(ServiceBusEventSource.ClientCreateExceptionEvent).Any());
                Assert.True(_listener.EventsById(ServiceBusEventSource.ProcessorStoppingReceiveCanceledEvent).Any());
            }
        }

        [Test]
        public async Task StoppingSessionProcessorDoesNotLogTaskCanceledExceptions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateNoRetryClient(5);
                await using var processor = client.CreateSessionProcessor(
                    scope.QueueName,
                    new ServiceBusSessionProcessorOptions
                {
                    // specify a session so that we can establish the link without sending messages
                    SessionIds = { "sessionId "}
                });

                processor.ProcessMessageAsync += args => Task.CompletedTask;
                processor.ProcessErrorAsync += args => Task.CompletedTask;

                await processor.StartProcessingAsync();

                // wait twice as long as the try timeout to ensure that the Accept session will timeout
                await Task.Delay(TimeSpan.FromSeconds(10));

                await processor.StopProcessingAsync();

                Assert.False(_listener.EventsById(ServiceBusEventSource.CreateReceiveLinkExceptionEvent).Any());
                Assert.False(_listener.EventsById(ServiceBusEventSource.ClientCreateExceptionEvent).Any());
                Assert.True(_listener.EventsById(ServiceBusEventSource.ProcessorStoppingReceiveCanceledEvent).Any());
            }
        }
    }
}
