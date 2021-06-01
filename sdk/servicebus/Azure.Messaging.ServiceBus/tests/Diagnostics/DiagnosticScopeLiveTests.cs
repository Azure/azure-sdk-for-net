﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
    [NonParallelizable]
    public class DiagnosticScopeLiveTests : ServiceBusLiveTestBase
    {
        private ClientDiagnosticListener _listener;

        [SetUp]
        public void Setup()
        {
            _listener = new ClientDiagnosticListener(EntityScopeFactory.DiagnosticNamespace);
        }

        [TearDown]
        public void TearDown()
        {
            _listener.Dispose();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SenderReceiverActivities(bool useSessions)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                string sessionId = null;
                if (useSessions)
                {
                    sessionId = "sessionId";
                }
                int numMessages = 5;
                var msgs = GetMessages(numMessages, sessionId);
                await sender.SendMessagesAsync(msgs);
                Activity[] sendActivities = AssertSendActivities(useSessions, sender, msgs);

                ServiceBusReceiver receiver = null;
                if (useSessions)
                {
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                }
                else
                {
                    receiver = client.CreateReceiver(scope.QueueName);
                }

                var remaining = numMessages;
                List<ServiceBusReceivedMessage> receivedMsgs = new List<ServiceBusReceivedMessage>();
                while (remaining > 0)
                {
                    // loop in case we don't receive all messages in one attempt
                    var received = await receiver.ReceiveMessagesAsync(remaining);
                    receivedMsgs.AddRange(received);
                    var receiveScope = _listener.AssertAndRemoveScope(DiagnosticProperty.ReceiveActivityName);
                    AssertCommonTags(receiveScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                    var receiveLinkedActivities = receiveScope.LinkedActivities;
                    for (int i = 0; i < receiveLinkedActivities.Count; i++)
                    {
                        Assert.AreEqual(sendActivities[i].ParentId, receiveLinkedActivities[i].ParentId);
                    }
                    remaining -= received.Count;
                }

                var msgIndex = 0;

                var completed = receivedMsgs[msgIndex];
                await receiver.CompleteMessageAsync(completed);
                var completeScope = _listener.AssertAndRemoveScope(DiagnosticProperty.CompleteActivityName);
                AssertCommonTags(completeScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                var deferred = receivedMsgs[++msgIndex];
                await receiver.DeferMessageAsync(deferred);
                var deferredScope = _listener.AssertAndRemoveScope(DiagnosticProperty.DeferActivityName);
                AssertCommonTags(deferredScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                var deadLettered = receivedMsgs[++msgIndex];
                await receiver.DeadLetterMessageAsync(deadLettered);
                var deadLetterScope = _listener.AssertAndRemoveScope(DiagnosticProperty.DeadLetterActivityName);
                AssertCommonTags(deadLetterScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                var abandoned = receivedMsgs[++msgIndex];
                await receiver.AbandonMessageAsync(abandoned);
                var abandonScope = _listener.AssertAndRemoveScope(DiagnosticProperty.AbandonActivityName);
                AssertCommonTags(abandonScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                var receiveDeferMsg = await receiver.ReceiveDeferredMessageAsync(deferred.SequenceNumber);
                var receiveDeferScope = _listener.AssertAndRemoveScope(DiagnosticProperty.ReceiveDeferredActivityName);
                AssertCommonTags(receiveDeferScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                // renew lock
                if (useSessions)
                {
                    var sessionReceiver = (ServiceBusSessionReceiver)receiver;
                    await sessionReceiver.RenewSessionLockAsync();
                    var renewSessionScope = _listener.AssertAndRemoveScope(DiagnosticProperty.RenewSessionLockActivityName);
                    AssertCommonTags(renewSessionScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                    // set state
                    var state = new BinaryData("state");
                    await sessionReceiver.SetSessionStateAsync(state);
                    var setStateScope = _listener.AssertAndRemoveScope(DiagnosticProperty.SetSessionStateActivityName);
                    AssertCommonTags(setStateScope.Activity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace);

                    // get state
                    var getState = await sessionReceiver.GetSessionStateAsync();
                    Assert.AreEqual(state.ToArray(), getState.ToArray());
                    var getStateScope = _listener.AssertAndRemoveScope(DiagnosticProperty.GetSessionStateActivityName);
                    AssertCommonTags(getStateScope.Activity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace);
                }
                else
                {
                    await receiver.RenewMessageLockAsync(receivedMsgs[4]);
                    var renewMessageScope = _listener.AssertAndRemoveScope(DiagnosticProperty.RenewMessageLockActivityName);
                    AssertCommonTags(renewMessageScope.Activity, receiver.EntityPath, receiver.FullyQualifiedNamespace);
                }

                // schedule
                msgs = GetMessages(numMessages, sessionId);

                foreach (var msg in msgs)
                {
                    var seq = await sender.ScheduleMessageAsync(msg, DateTimeOffset.UtcNow.AddMinutes(1));
                    Assert.IsNotNull(msg.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute]);

                    var messageScope = _listener.AssertAndRemoveScope(DiagnosticProperty.MessageActivityName);
                    AssertCommonTags(messageScope.Activity, sender.EntityPath, sender.FullyQualifiedNamespace);

                    var scheduleScope = _listener.AssertAndRemoveScope(DiagnosticProperty.ScheduleActivityName);
                    AssertCommonTags(scheduleScope.Activity, sender.EntityPath, sender.FullyQualifiedNamespace);

                    var linkedActivities = scheduleScope.LinkedActivities;
                    Assert.AreEqual(1, linkedActivities.Count);
                    Assert.AreEqual(messageScope.Activity.Id, linkedActivities[0].ParentId);

                    await sender.CancelScheduledMessageAsync(seq);
                    var cancelScope = _listener.AssertAndRemoveScope(DiagnosticProperty.CancelActivityName);
                    AssertCommonTags(cancelScope.Activity, sender.EntityPath, sender.FullyQualifiedNamespace);
                }

                // send a batch
                var batch = await sender.CreateMessageBatchAsync();
                for (int i = 0; i < numMessages; i++)
                {
                    batch.TryAddMessage(GetMessage(sessionId));
                }
                await sender.SendMessagesAsync(batch);
                AssertSendActivities(useSessions, sender, batch.AsEnumerable<ServiceBusMessage>());
            };
        }

        [Test]
        public async Task ProcessorActivities()
        {
            string[] messageActivities = null;
            int messageProcessedCt = 0;
            bool callbackExecuted = false;
            _listener = new ClientDiagnosticListener(
                EntityScopeFactory.DiagnosticNamespace,
                scopeStartCallback: scope =>
                {
                    if (scope.Name == DiagnosticProperty.ProcessMessageActivityName)
                    {
                        Assert.IsNotNull(messageActivities);
                        Assert.AreEqual(
                            messageActivities[messageProcessedCt],
                            scope.Links.Single());
                        callbackExecuted = true;
                    }
                });
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCt = 2;
                var msgs = GetMessages(messageCt);
                await sender.SendMessagesAsync(msgs);
                Activity[] sendActivities = AssertSendActivities(false, sender, msgs);
                messageActivities = sendActivities.Select(a => a.ParentId).ToArray();

                ServiceBusProcessor processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = false,
                    MaxReceiveWaitTime = TimeSpan.FromSeconds(10),
                    MaxConcurrentCalls = 1
                });
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                processor.ProcessMessageAsync += args =>
                {
                    if (++messageProcessedCt == messageCt)
                    {
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                };
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                for (int i = 0; i < messageCt; i++)
                {
                    _listener.AssertAndRemoveScope(DiagnosticProperty.ReceiveActivityName);
                    var processScope = _listener.AssertAndRemoveScope(DiagnosticProperty.ProcessMessageActivityName);
                    AssertCommonTags(processScope.Activity, processor.EntityPath, processor.FullyQualifiedNamespace);
                }
                Assert.IsTrue(callbackExecuted);
            };
        }

        [Test]
        public async Task SessionProcessorActivities()
        {
            string[] messageActivities = null;
            int messageProcessedCt = 0;
            bool callbackExecuted = false;
            _listener = new ClientDiagnosticListener(
                EntityScopeFactory.DiagnosticNamespace,
                scopeStartCallback: scope =>
                {
                    if (scope.Name == DiagnosticProperty.ProcessSessionMessageActivityName)
                    {
                        Assert.IsNotNull(messageActivities);
                        Assert.AreEqual(
                            messageActivities[messageProcessedCt],
                            scope.Links.Single());
                        callbackExecuted = true;
                    }
                });
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCt = 2;
                var msgs = GetMessages(messageCt, "sessionId");
                await sender.SendMessagesAsync(msgs);
                Activity[] sendActivities = AssertSendActivities(false, sender, msgs);
                messageActivities = sendActivities.Select(a => a.ParentId).ToArray();

                ServiceBusSessionProcessor processor = client.CreateSessionProcessor(scope.QueueName,
                    new ServiceBusSessionProcessorOptions
                    {
                        AutoCompleteMessages = false,
                        SessionIdleTimeout = TimeSpan.FromSeconds(10),
                        MaxConcurrentSessions = 1
                    });
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                processor.ProcessMessageAsync += args =>
                {
                    if (++messageProcessedCt == messageCt)
                    {
                        tcs.SetResult(true);
                    }
                    return Task.CompletedTask;
                };
                processor.ProcessErrorAsync += ExceptionHandler;
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                for (int i = 0; i < messageCt; i++)
                {
                    _listener.AssertAndRemoveScope(DiagnosticProperty.ReceiveActivityName);
                    var processScope = _listener.AssertAndRemoveScope(DiagnosticProperty.ProcessSessionMessageActivityName);
                    AssertCommonTags(processScope.Activity, processor.EntityPath, processor.FullyQualifiedNamespace);
                }
                Assert.IsTrue(callbackExecuted);
            }
        }

        private Activity[] AssertSendActivities(bool useSessions, ServiceBusSender sender, IEnumerable<ServiceBusMessage> msgs)
        {
            IList<Activity> messageActivities = new List<Activity>();
            foreach (var msg in msgs)
            {
                Assert.IsNotNull(msg.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute]);
                var messageScope = _listener.AssertAndRemoveScope(DiagnosticProperty.MessageActivityName);
                messageActivities.Add(messageScope.Activity);
                AssertCommonTags(messageScope.Activity, sender.EntityPath, sender.FullyQualifiedNamespace);
            }

            var sendScope = _listener.AssertAndRemoveScope(DiagnosticProperty.SendActivityName);
            AssertCommonTags(sendScope.Activity, sender.EntityPath, sender.FullyQualifiedNamespace);

            var sendLinkedActivities = sendScope.LinkedActivities;
            for (int i = 0; i < sendLinkedActivities.Count; i++)
            {
                Assert.AreEqual(messageActivities[i].Id, sendLinkedActivities[i].ParentId);
            }
            return sendLinkedActivities.ToArray();
        }
        private void AssertCommonTags(Activity activity, string entityName, string fullyQualifiedNamespace)
        {
            var tags = activity.Tags;
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(DiagnosticProperty.EntityAttribute, entityName));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(DiagnosticProperty.EndpointAttribute, fullyQualifiedNamespace));
            CollectionAssert.Contains(tags, new KeyValuePair<string, string>(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.ServiceBusServiceContext));
        }
    }
}
