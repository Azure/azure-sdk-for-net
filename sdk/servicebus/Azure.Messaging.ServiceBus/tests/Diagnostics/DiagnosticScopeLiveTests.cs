// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
    [NonParallelizable]
    public class DiagnosticScopeLiveTests : ServiceBusLiveTestBase
    {
        private TestDiagnosticListener _listener;

        [SetUp]
        public void Setup()
        {
            _listener = new TestDiagnosticListener(EntityScopeFactory.DiagnosticNamespace);
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
                    (string Key, object Value, DiagnosticListener) receiveStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.ReceiveActivityName + ".Start", receiveStart.Key);

                    Activity receiveActivity = (Activity)receiveStart.Value;
                    AssertCommonTags(receiveActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                    var receiveLinkedActivities = ((IEnumerable<Activity>)receiveActivity.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(receiveActivity)).ToArray();
                    for (int i = 0; i < receiveLinkedActivities.Length; i++)
                    {
                        Assert.AreEqual(sendActivities[i].ParentId, receiveLinkedActivities[i].ParentId);
                    }
                    (string Key, object Value, DiagnosticListener) receiveStop = _listener.Events.Dequeue();

                    Assert.AreEqual(DiagnosticProperty.ReceiveActivityName + ".Stop", receiveStop.Key);
                    remaining -= received.Count;
                }

                var msgIndex = 0;

                var completed = receivedMsgs[msgIndex];
                await receiver.CompleteMessageAsync(completed);
                (string Key, object Value, DiagnosticListener) completeStart = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.CompleteActivityName + ".Start", completeStart.Key);
                Activity completeActivity = (Activity)completeStart.Value;
                AssertCommonTags(completeActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);
                (string Key, object Value, DiagnosticListener) completeStop = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.CompleteActivityName + ".Stop", completeStop.Key);

                var deferred = receivedMsgs[++msgIndex];
                await receiver.DeferMessageAsync(deferred);
                (string Key, object Value, DiagnosticListener) deferStart = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.DeferActivityName + ".Start", deferStart.Key);
                Activity deferActivity = (Activity)deferStart.Value;
                AssertCommonTags(deferActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);
                (string Key, object Value, DiagnosticListener) deferStop = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.DeferActivityName + ".Stop", deferStop.Key);

                var deadLettered = receivedMsgs[++msgIndex];
                await receiver.DeadLetterMessageAsync(deadLettered);
                (string Key, object Value, DiagnosticListener) deadLetterStart = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.DeadLetterActivityName + ".Start", deadLetterStart.Key);
                Activity deadLetterActivity = (Activity)deadLetterStart.Value;
                AssertCommonTags(deadLetterActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);
                (string Key, object Value, DiagnosticListener) deadletterStop = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.DeadLetterActivityName + ".Stop", deadletterStop.Key);

                var abandoned = receivedMsgs[++msgIndex];
                await receiver.AbandonMessageAsync(abandoned);
                (string Key, object Value, DiagnosticListener) abandonStart = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.AbandonActivityName + ".Start", abandonStart.Key);
                Activity abandonActivity = (Activity)abandonStart.Value;
                AssertCommonTags(abandonActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);
                (string Key, object Value, DiagnosticListener) abandonStop = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.AbandonActivityName + ".Stop", abandonStop.Key);

                var receiveDeferMsg = await receiver.ReceiveDeferredMessageAsync(deferred.SequenceNumber);
                (string Key, object Value, DiagnosticListener) receiveDeferStart = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.ReceiveDeferredActivityName + ".Start", receiveDeferStart.Key);
                Activity receiveDeferActivity = (Activity)receiveDeferStart.Value;
                AssertCommonTags(receiveDeferActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                (string Key, object Value, DiagnosticListener) receiveDeferStop = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.ReceiveDeferredActivityName + ".Stop", receiveDeferStop.Key);

                // renew lock
                if (useSessions)
                {
                    var sessionReceiver = (ServiceBusSessionReceiver)receiver;
                    await sessionReceiver.RenewSessionLockAsync();
                    (string Key, object Value, DiagnosticListener) renewStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.RenewSessionLockActivityName + ".Start", renewStart.Key);
                    Activity renewActivity = (Activity)renewStart.Value;
                    AssertCommonTags(renewActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) renewStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.RenewSessionLockActivityName + ".Stop", renewStop.Key);

                    // set state
                    var state = new BinaryData("state");
                    await sessionReceiver.SetSessionStateAsync(state);
                    (string Key, object Value, DiagnosticListener) setStateStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.SetSessionStateActivityName + ".Start", setStateStart.Key);
                    Activity setStateActivity = (Activity)setStateStart.Value;
                    AssertCommonTags(setStateActivity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) setStateStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.SetSessionStateActivityName + ".Stop", setStateStop.Key);

                    // get state
                    var getState = await sessionReceiver.GetSessionStateAsync();
                    Assert.AreEqual(state.ToArray(), getState.ToArray());
                    (string Key, object Value, DiagnosticListener) getStateStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.GetSessionStateActivityName + ".Start", getStateStart.Key);
                    Activity getStateActivity = (Activity)getStateStart.Value;
                    AssertCommonTags(getStateActivity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) getStateStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.GetSessionStateActivityName + ".Stop", getStateStop.Key);
                }
                else
                {
                    await receiver.RenewMessageLockAsync(receivedMsgs[4]);
                    (string Key, object Value, DiagnosticListener) renewStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.RenewMessageLockActivityName + ".Start", renewStart.Key);
                    Activity renewActivity = (Activity)renewStart.Value;
                    AssertCommonTags(renewActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) renewStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.RenewMessageLockActivityName + ".Stop", renewStop.Key);
                }

                // schedule
                msgs = GetMessages(numMessages, sessionId);

                foreach (var msg in msgs)
                {
                    var seq = await sender.ScheduleMessageAsync(msg, DateTimeOffset.UtcNow.AddMinutes(1));
                    Assert.IsNotNull(msg.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute]);

                    (string Key, object Value, DiagnosticListener) startMessage = _listener.Events.Dequeue();
                    Activity messageActivity = (Activity)startMessage.Value;
                    AssertCommonTags(messageActivity, sender.EntityPath, sender.FullyQualifiedNamespace);
                    Assert.AreEqual(DiagnosticProperty.MessageActivityName + ".Start", startMessage.Key);

                    (string Key, object Value, DiagnosticListener) stopMessage = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.MessageActivityName + ".Stop", stopMessage.Key);

                    (string Key, object Value, DiagnosticListener) startSchedule = _listener.Events.Dequeue();
                    AssertCommonTags((Activity)startSchedule.Value, sender.EntityPath, sender.FullyQualifiedNamespace);

                    Assert.AreEqual(DiagnosticProperty.ScheduleActivityName + ".Start", startSchedule.Key);
                    (string Key, object Value, DiagnosticListener) stopSchedule = _listener.Events.Dequeue();

                    Assert.AreEqual(DiagnosticProperty.ScheduleActivityName + ".Stop", stopSchedule.Key);
                    var linkedActivities = ((IEnumerable<Activity>)startSchedule.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startSchedule.Value)).ToArray();
                    Assert.AreEqual(1, linkedActivities.Length);
                    Assert.AreEqual(messageActivity.Id, linkedActivities[0].ParentId);

                    await sender.CancelScheduledMessageAsync(seq);
                    (string Key, object Value, DiagnosticListener) startCancel = _listener.Events.Dequeue();
                    AssertCommonTags((Activity)startCancel.Value, sender.EntityPath, sender.FullyQualifiedNamespace);
                    Assert.AreEqual(DiagnosticProperty.CancelActivityName + ".Start", startCancel.Key);

                    (string Key, object Value, DiagnosticListener) stopCancel = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.CancelActivityName + ".Stop", stopCancel.Key);
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
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCt = 2;
                var msgs = GetMessages(messageCt);
                await sender.SendMessagesAsync(msgs);
                Activity[] sendActivities = AssertSendActivities(false, sender, msgs);

                ServiceBusProcessor processor = client.CreateProcessor(scope.QueueName, new ServiceBusProcessorOptions
                {
                    AutoCompleteMessages = false,
                    MaxReceiveWaitTime = TimeSpan.FromSeconds(10),
                    MaxConcurrentCalls = 1
                });
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                int messageProcessedCt = 0;
                processor.ProcessMessageAsync += args =>
                {
                    messageProcessedCt++;
                    if (messageProcessedCt == messageCt)
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
                    (string Key, object Value, DiagnosticListener) receiveStart = _listener.Events.Dequeue();
                    (string Key, object Value, DiagnosticListener) receiveStop = _listener.Events.Dequeue();
                    (string Key, object Value, DiagnosticListener) processStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.ProcessMessageActivityName + ".Start", processStart.Key);
                    Activity processActivity = (Activity)processStart.Value;
                    AssertCommonTags(processActivity, processor.EntityPath, processor.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) processStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.ProcessMessageActivityName + ".Stop", processStop.Key);
                }
            };
        }

        [Test]
        public async Task SessionProcessorActivities()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCt = 2;
                var msgs = GetMessages(messageCt, "sessionId");
                await sender.SendMessagesAsync(msgs);
                Activity[] sendActivities = AssertSendActivities(false, sender, msgs);

                ServiceBusSessionProcessor processor = client.CreateSessionProcessor(scope.QueueName,
                    new ServiceBusSessionProcessorOptions
                    {
                        AutoCompleteMessages = false,
                        MaxReceiveWaitTime = TimeSpan.FromSeconds(10),
                        MaxConcurrentSessions = 1
                    });
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                int processedMsgCt = 0;
                processor.ProcessMessageAsync += args =>
                {
                    processedMsgCt++;
                    if (processedMsgCt == messageCt)
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
                    (string Key, object Value, DiagnosticListener) receiveStart = _listener.Events.Dequeue();
                    (string Key, object Value, DiagnosticListener) receiveStop = _listener.Events.Dequeue();
                    (string Key, object Value, DiagnosticListener) processStart = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.ProcessSessionMessageActivityName + ".Start", processStart.Key);
                    Activity processActivity = (Activity)processStart.Value;
                    AssertCommonTags(processActivity, processor.EntityPath, processor.FullyQualifiedNamespace);

                    (string Key, object Value, DiagnosticListener) processStop = _listener.Events.Dequeue();
                    Assert.AreEqual(DiagnosticProperty.ProcessSessionMessageActivityName + ".Stop", processStop.Key);
                }
            };
        }

        private Activity[] AssertSendActivities(bool useSessions, ServiceBusSender sender, IEnumerable<ServiceBusMessage> msgs)
        {
            IList<Activity> messageActivities = new List<Activity>();
            foreach (var msg in msgs)
            {
                Assert.IsNotNull(msg.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute]);
                (string Key, object Value, DiagnosticListener) startMessage = _listener.Events.Dequeue();
                messageActivities.Add((Activity)startMessage.Value);
                AssertCommonTags((Activity)startMessage.Value, sender.EntityPath, sender.FullyQualifiedNamespace);
                Assert.AreEqual(DiagnosticProperty.MessageActivityName + ".Start", startMessage.Key);

                (string Key, object Value, DiagnosticListener) stopMessage = _listener.Events.Dequeue();
                Assert.AreEqual(DiagnosticProperty.MessageActivityName + ".Stop", stopMessage.Key);
            }

            (string Key, object Value, DiagnosticListener) startSend = _listener.Events.Dequeue();
            Assert.AreEqual(DiagnosticProperty.SendActivityName + ".Start", startSend.Key);
            Activity sendActivity = (Activity)startSend.Value;
            AssertCommonTags(sendActivity, sender.EntityPath, sender.FullyQualifiedNamespace);

            (string Key, object Value, DiagnosticListener) stopSend = _listener.Events.Dequeue();
            Assert.AreEqual(DiagnosticProperty.SendActivityName + ".Stop", stopSend.Key);

            var sendLinkedActivities = ((IEnumerable<Activity>)startSend.Value.GetType().GetTypeInfo().GetDeclaredProperty("Links").GetValue(startSend.Value)).ToArray();
            for (int i = 0; i < sendLinkedActivities.Length; i++)
            {
                Assert.AreEqual(messageActivities[i].Id, sendLinkedActivities[i].ParentId);
            }
            return sendLinkedActivities;
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
