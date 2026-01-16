// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Shared;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Diagnostics
{
#if NET5_0_OR_GREATER
    [NonParallelizable]
    public class DiagnosticScopeActivitySourceLiveTests : ServiceBusLiveTestBase
    {
        [SetUp]
        [TearDown]
        public void ResetFeatureSwitch()
        {
            ActivityExtensions.ResetFeatureSwitch();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SenderReceiverActivitiesDisabled(bool useSessions)
        {
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                string sessionId = null;
                if (useSessions)
                {
                    sessionId = "sessionId";
                }

                int numMessages = 2;
                await sender.SendMessagesAsync(ServiceBusTestUtilities.GetMessages(numMessages, sessionId));

                ServiceBusReceiver receiver = null;
                if (useSessions)
                {
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                }
                else
                {
                    receiver = client.CreateReceiver(scope.QueueName);
                }

                var peeked = await receiver.PeekMessageAsync();
                var received = await receiver.ReceiveMessagesAsync(numMessages);

                if (useSessions)
                {
                    // renew lock
                    var sessionReceiver = (ServiceBusSessionReceiver)receiver;
                    await sessionReceiver.RenewSessionLockAsync();

                    // state
                    await sessionReceiver.SetSessionStateAsync(new BinaryData("state"));
                    var getState = await sessionReceiver.GetSessionStateAsync();
                }
                else
                {
                    await receiver.RenewMessageLockAsync(received[1]);
                }

                // schedule
                foreach (var msg in ServiceBusTestUtilities.GetMessages(numMessages, sessionId))
                {
                    var seq = await sender.ScheduleMessageAsync(msg, DateTimeOffset.UtcNow.AddMinutes(1));
                    Assert.That(msg.ApplicationProperties.ContainsKey(MessagingClientDiagnostics.DiagnosticIdAttribute), Is.False);
                    await sender.CancelScheduledMessageAsync(seq);
                }
            }
            Assert.That(listener.Activities, Is.Empty);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SenderReceiverActivities(bool useSessions)
        {
            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(s => s.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                string sessionId = null;
                if (useSessions)
                {
                    sessionId = "sessionId";
                }
                int numMessages = 5;
                var msgs = ServiceBusTestUtilities.GetMessages(numMessages, sessionId);
                await sender.SendMessagesAsync(msgs);
                ActivityLink[] sendActivities = AssertSendActivities(sender, msgs, listener);

                ServiceBusReceiver receiver = null;
                if (useSessions)
                {
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                }
                else
                {
                    receiver = client.CreateReceiver(scope.QueueName);
                }

                var peeked = await receiver.PeekMessageAsync();
                var peekActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.PeekActivityName);
                AssertCommonTags(peekActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Receive, 1);
                Assert.That(peekActivity.Links.First().Context.TraceId, Is.EqualTo(sendActivities[0].Context.TraceId));
                Assert.That(peekActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                var remaining = numMessages;
                List<ServiceBusReceivedMessage> receivedMsgs = new List<ServiceBusReceivedMessage>();
                while (remaining > 0)
                {
                    // loop in case we don't receive all messages in one attempt
                    var received = await receiver.ReceiveMessagesAsync(remaining);
                    receivedMsgs.AddRange(received);
                    var receiveActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.ReceiveActivityName);
                    AssertCommonTags(receiveActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Receive, received.Count);

                    var receiveLinkedActivities = receiveActivity.Links.ToList();
                    Assert.That(receiveLinkedActivities.Count, Is.GreaterThan(0));
                    for (int i = 0; i < receiveLinkedActivities.Count; i++)
                    {
                        Assert.That(receiveLinkedActivities[i].Context.TraceId, Is.EqualTo(sendActivities[i].Context.TraceId));
                    }
                    remaining -= received.Count;
                }

                var msgIndex = 0;

                var completed = receivedMsgs[msgIndex];
                await receiver.CompleteMessageAsync(completed);
                var completeActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.CompleteActivityName);
                AssertCommonTags(completeActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Settle, 1);
                Assert.That(completeActivity.Links.First().Context.TraceId, Is.EqualTo(sendActivities[msgIndex].Context.TraceId));
                Assert.That(completeActivity.Links.First().Context.SpanId, Is.EqualTo(sendActivities[msgIndex].Context.SpanId));
                Assert.That(completeActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                var deferred = receivedMsgs[++msgIndex];
                await receiver.DeferMessageAsync(deferred);
                var deferActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.DeferActivityName);
                AssertCommonTags(deferActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Settle, 1);
                Assert.That(deferActivity.Links.First().Context.TraceId, Is.EqualTo(sendActivities[msgIndex].Context.TraceId));
                Assert.That(deferActivity.Links.First().Context.SpanId, Is.EqualTo(sendActivities[msgIndex].Context.SpanId));
                Assert.That(deferActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                var deadLettered = receivedMsgs[++msgIndex];
                await receiver.DeadLetterMessageAsync(deadLettered);
                var deadLetterActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.DeadLetterActivityName);
                AssertCommonTags(deadLetterActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Settle, 1);
                Assert.That(deadLetterActivity.Links.First().Context.TraceId, Is.EqualTo(sendActivities[msgIndex].Context.TraceId));
                Assert.That(deadLetterActivity.Links.First().Context.SpanId, Is.EqualTo(sendActivities[msgIndex].Context.SpanId));
                Assert.That(deadLetterActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                var abandoned = receivedMsgs[++msgIndex];
                await receiver.AbandonMessageAsync(abandoned);
                var abandonActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.AbandonActivityName);
                AssertCommonTags(abandonActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Settle, 1);
                Assert.That(abandonActivity.Links.First().Context.TraceId, Is.EqualTo(sendActivities[msgIndex].Context.TraceId));
                Assert.That(abandonActivity.Links.First().Context.SpanId, Is.EqualTo(sendActivities[msgIndex].Context.SpanId));
                Assert.That(abandonActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                var receiveDeferMsg = await receiver.ReceiveDeferredMessageAsync(deferred.SequenceNumber);
                var receiveDeferredActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.ReceiveDeferredActivityName);
                AssertCommonTags(receiveDeferredActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, MessagingDiagnosticOperation.Receive, 1);
                Assert.That(receiveDeferredActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));

                // renew lock
                if (useSessions)
                {
                    var sessionReceiver = (ServiceBusSessionReceiver)receiver;
                    await sessionReceiver.RenewSessionLockAsync();
                    var renewSessionActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.RenewSessionLockActivityName);
                    AssertCommonTags(renewSessionActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, default, 1);
                    Assert.That(renewSessionActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusSessionReceiver"));

                    // set state
                    var state = new BinaryData("state");
                    await sessionReceiver.SetSessionStateAsync(state);
                    var setStateActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.SetSessionStateActivityName);
                    AssertCommonTags(setStateActivity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace, default, 1);
                    Assert.That(setStateActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusSessionReceiver"));

                    // get state
                    var getState = await sessionReceiver.GetSessionStateAsync();
                    Assert.That(getState.ToArray(), Is.EqualTo(state.ToArray()));
                    var getStateActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.GetSessionStateActivityName);
                    AssertCommonTags(getStateActivity, sessionReceiver.EntityPath, sessionReceiver.FullyQualifiedNamespace, default, 1);
                    Assert.That(getStateActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusSessionReceiver"));
                }
                else
                {
                    await receiver.RenewMessageLockAsync(receivedMsgs[4]);
                    var renewMessageActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.RenewMessageLockActivityName);
                    AssertCommonTags(renewMessageActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, default, 1);
                    Assert.That(renewMessageActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusReceiver"));
                }

                // schedule
                msgs = ServiceBusTestUtilities.GetMessages(numMessages, sessionId);

                foreach (var msg in msgs)
                {
                    var seq = await sender.ScheduleMessageAsync(msg, DateTimeOffset.UtcNow.AddMinutes(1));
                    Assert.That(msg.ApplicationProperties[MessagingClientDiagnostics.DiagnosticIdAttribute], Is.Not.Null);

                    var messageActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.MessageActivityName);
                    AssertCommonTags(messageActivity, sender.EntityPath, sender.FullyQualifiedNamespace, default, 1);

                    var scheduleScope = listener.AssertAndRemoveActivity(DiagnosticProperty.ScheduleActivityName);
                    AssertCommonTags(scheduleScope, sender.EntityPath, sender.FullyQualifiedNamespace, MessagingDiagnosticOperation.Publish, 1);

                    var linkedActivities = scheduleScope.Links.ToList();
                    Assert.That(linkedActivities.Count, Is.EqualTo(1));
                    Assert.That(linkedActivities[0].Context.TraceId, Is.EqualTo(messageActivity.TraceId));
                    Assert.That(linkedActivities[0].Context.SpanId, Is.EqualTo(messageActivity.SpanId));

                    await sender.CancelScheduledMessageAsync(seq);
                    var cancelScope = listener.AssertAndRemoveActivity(DiagnosticProperty.CancelActivityName);
                    AssertCommonTags(cancelScope, sender.EntityPath, sender.FullyQualifiedNamespace, default, 1);
                }

                // send a batch
                var batch = await sender.CreateMessageBatchAsync();
                var messages = new List<ServiceBusMessage>();
                for (int i = 0; i < numMessages; i++)
                {
                    var currentMessage = ServiceBusTestUtilities.GetMessage(sessionId);
                    messages.Add(currentMessage);
                    batch.TryAddMessage(currentMessage);
                }
                await sender.SendMessagesAsync(batch);
                AssertSendActivities(sender, messages, listener);

                // delete a message
                await receiver.DeleteMessagesAsync(1);
                var deleteActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.DeleteActivityName);
                AssertCommonTags(deleteActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, default, 1);

                // purge all messages
                await receiver.PurgeMessagesAsync();
                var purgeActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.PurgeActivityName);
                AssertCommonTags(purgeActivity, receiver.EntityPath, receiver.FullyQualifiedNamespace, default, 1);
            };
        }

        [Test]
        public async Task ProcessorActivities()
        {
            using var _ = SetAppConfigSwitch();

            int messageProcessedCt = 0;
            bool callbackExecuted = false;
            bool callbackAssertFailure = false;
            var messageCt = 2;
            var messages = ServiceBusTestUtilities.GetMessages(messageCt);

            using var listener = new TestActivitySourceListener(
                source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace),
                activityStartedCallback: activity =>
                {
                    if (activity.OperationName == DiagnosticProperty.ProcessMessageActivityName)
                    {
                        try
                        {
                            Assert.That(MessagingClientDiagnostics.TryExtractTraceContext(messages[messageProcessedCt].ApplicationProperties, out var traceparent, out var tracestate), Is.True);
                            Assert.That(activity.ParentId, Is.EqualTo(traceparent));
                            Assert.That(activity.Links.Count(), Is.EqualTo(1));
                            Assert.That(activity.Links.Single().Context.SpanId, Is.EqualTo(activity.ParentSpanId));
                            Assert.That(activity.TraceStateString, Is.EqualTo(tracestate));
                            Assert.That(activity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusProcessor"));
                            callbackExecuted = true;
                        }
                        catch
                        {
                            callbackAssertFailure = true;
                        }
                    }
                });
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessagesAsync(messages);
                AssertSendActivities(sender, messages, listener);

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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                for (int i = 0; i < messageCt; i++)
                {
                    listener.AssertAndRemoveActivity(DiagnosticProperty.ReceiveActivityName);
                    var processActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.ProcessMessageActivityName);
                    AssertCommonTags(processActivity, processor.EntityPath, processor.FullyQualifiedNamespace, MessagingDiagnosticOperation.Process, 1);
                }
                Assert.That(callbackExecuted, Is.True);
                Assert.That(callbackAssertFailure, Is.False);
            };
        }

        [Test]
        public async Task SessionProcessorActivities()
        {
            using var _ = SetAppConfigSwitch();
            int messageProcessedCt = 0;
            bool callbackExecuted = false;
            var messageCt = 2;
            var messages = ServiceBusTestUtilities.GetMessages(messageCt, "sessionId");

            using var listener = new TestActivitySourceListener(
                source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace),
                activityStartedCallback: activity =>
                {
                    if (activity.OperationName == DiagnosticProperty.ProcessSessionMessageActivityName)
                    {
                        Assert.That(MessagingClientDiagnostics.TryExtractTraceContext(messages[messageProcessedCt].ApplicationProperties, out var traceparent, out var tracestate), Is.True);
                        Assert.That(activity.ParentId, Is.EqualTo(traceparent));
                        Assert.That(activity.TraceStateString, Is.EqualTo(tracestate));
                        Assert.That(activity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusSessionProcessor"));
                        callbackExecuted = true;
                    }
                });
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessagesAsync(messages);
                AssertSendActivities(sender, messages, listener);

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
                processor.ProcessErrorAsync += ServiceBusTestUtilities.ExceptionHandler;
                await processor.StartProcessingAsync();
                await tcs.Task;
                await processor.StopProcessingAsync();
                for (int i = 0; i < messageCt; i++)
                {
                    listener.AssertAndRemoveActivity(DiagnosticProperty.ReceiveActivityName);
                    var processActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.ProcessSessionMessageActivityName);
                    AssertCommonTags(processActivity, processor.EntityPath, processor.FullyQualifiedNamespace, MessagingDiagnosticOperation.Process, 1);
                }
                Assert.That(callbackExecuted, Is.True);
            }
        }

        [Test]
        public async Task RuleManagerActivities()
        {
            using var _ = SetAppConfigSwitch();
            using var listener = new TestActivitySourceListener(source => source.Name.StartsWith(DiagnosticProperty.DiagnosticNamespace));

            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());
                for (int i = 0; i < 100; i++)
                {
                    var ruleName = $"CorrelationUserPropertyRule-{i}";
                    await ruleManager.CreateRuleAsync(new CreateRuleOptions
                    {
                        Filter = new CorrelationRuleFilter { ApplicationProperties = { { "color", "red" } } },
                        Name = ruleName
                    });
                    var createRuleActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.CreateRuleActivityName);
                    AssertCommonTags(createRuleActivity, ruleManager.SubscriptionPath, ruleManager.FullyQualifiedNamespace, default, 0);
                }

                int ruleCount = 0;
                await foreach (var rule in ruleManager.GetRulesAsync())
                {
                    ruleCount++;
                }

                // default rule + our added rules
                Assert.That(ruleCount, Is.EqualTo(101));

                // two get rule scopes (1st scope for the initial 100 rules, 2nd scope for the final rule)
                var getRuleActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.GetRulesActivityName);
                AssertCommonTags(getRuleActivity, ruleManager.SubscriptionPath, ruleManager.FullyQualifiedNamespace, default, 0);

                getRuleActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.GetRulesActivityName);
                AssertCommonTags(getRuleActivity, ruleManager.SubscriptionPath, ruleManager.FullyQualifiedNamespace, default, 0);
            }
        }

        private ActivityLink[] AssertSendActivities(ServiceBusSender sender, IList<ServiceBusMessage> messages, TestActivitySourceListener listener)
        {
            IList<Activity> messageActivities = new List<Activity>();
            foreach (var msg in messages)
            {
                Assert.That(msg.ApplicationProperties[MessagingClientDiagnostics.DiagnosticIdAttribute], Is.Not.Null);
                var messageActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.MessageActivityName);
                messageActivities.Add(messageActivity);
                Assert.That(messageActivity.Tags, Has.Member(new KeyValuePair<string, string>(MessagingClientDiagnostics.DestinationName, sender.EntityPath)));
                AssertCommonTags(messageActivity, sender.EntityPath, sender.FullyQualifiedNamespace, default, 1);
                Assert.That(messageActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".Message"));
            }

            var sendActivity = listener.AssertAndRemoveActivity(DiagnosticProperty.SendActivityName);
            AssertCommonTags(sendActivity, sender.EntityPath, sender.FullyQualifiedNamespace, MessagingDiagnosticOperation.Publish, messages.Count);
            Assert.That(sendActivity.Source.Name, Is.EqualTo(DiagnosticProperty.DiagnosticNamespace + ".ServiceBusSender"));

            var sendLinkedActivities = sendActivity.Links.ToArray();
            for (int i = 0; i < sendLinkedActivities.Length; i++)
            {
                Assert.That(sendLinkedActivities[i].Context.TraceId, Is.EqualTo(messageActivities[i].TraceId));
                Assert.That(sendLinkedActivities[i].Context.SpanId, Is.EqualTo(messageActivities[i].SpanId));
            }
            return sendLinkedActivities;
        }

        private void AssertCommonTags(Activity activity, string entityName, string fullyQualifiedNamespace, MessagingDiagnosticOperation operation, int messageCount)
        {
            var tags = activity.TagObjects.ToList();
            Assert.That(tags, Has.Member(new KeyValuePair<string, string>(DiagnosticScope.OpenTelemetrySchemaAttribute, DiagnosticScope.OpenTelemetrySchemaVersion)));
            Assert.That(tags, Has.Member(new KeyValuePair<string, string>(MessagingClientDiagnostics.ServerAddress, fullyQualifiedNamespace)));
            Assert.That(tags, Has.Member(new KeyValuePair<string, string>(MessagingClientDiagnostics.DestinationName, entityName)));
            Assert.That(tags, Has.Member(new KeyValuePair<string, string>(MessagingClientDiagnostics.MessagingSystem, DiagnosticProperty.ServiceBusServiceContext)));

            if (operation != default)
            {
                Assert.That(tags,
                    Has.Member(new KeyValuePair<string, string>(MessagingClientDiagnostics.MessagingOperation, operation.ToString())));
            }

            if (messageCount > 1)
                Assert.That(tags, Has.Member(new KeyValuePair<string, int>(MessagingClientDiagnostics.BatchCount, messageCount)));
            else
                Assert.That(tags, Has.No.Member(new KeyValuePair<string, int>(MessagingClientDiagnostics.BatchCount, messageCount)));
        }

        private static TestAppContextSwitch SetAppConfigSwitch()
        {
            var s = new TestAppContextSwitch("Azure.Experimental.EnableActivitySource", "true");
            ActivityExtensions.ResetFeatureSwitch();
            return s;
        }
    }
#endif
}
