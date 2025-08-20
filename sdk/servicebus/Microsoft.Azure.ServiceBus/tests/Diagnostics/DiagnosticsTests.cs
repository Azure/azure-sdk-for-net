// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;

    [CollectionDefinition(nameof(DiagnosticsTests), DisableParallelization = true)]
    public abstract class DiagnosticsTests
    {
        protected const int MaxWaitSec = 10;
        protected readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(MaxWaitSec);

        protected ConcurrentQueue<(string eventName, object payload, Activity activity)> CreateEventQueue() =>
            new ConcurrentQueue<(string eventName, object payload, Activity activity)>();

        protected FakeDiagnosticListener CreateEventListener(string entityName, ConcurrentQueue<(string eventName, object payload, Activity activity)> eventQueue) =>
            new FakeDiagnosticListener(kvp =>
            {
                if (kvp.Key == null || kvp.Value == null)
                {
                    TestUtility.Log("Diagnostics Problem: Missing diagnostics information.  Ignoring.");
                    return;
                }

                // If an entity name was provided, log those payloads where the target is explicitly not associated with the entity.
                if (!String.IsNullOrEmpty(entityName))
                {
                    var targetEntity = this.GetPropertyValueFromAnonymousTypeInstance<string>(kvp.Value, "Entity", true);

                    if (String.IsNullOrEmpty(targetEntity) || !String.Equals(targetEntity, entityName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        TestUtility.Log($"Diagnostics Mismatch: Interested in Entity [{ entityName }], received [{ kvp.Key }] for Target [{ targetEntity }].");
                    }
                }

                eventQueue?.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });

        protected IDisposable SubscribeToEvents(IObserver<DiagnosticListener> listener) =>
            DiagnosticListener.AllListeners.Subscribe(listener);

        #region Send

        protected void AssertSendStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity, int messageCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Send.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            Assert.Equal(messageCount, messages.Count);

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);

            AssertTags(messages, activity);
        }

        protected void AssertSendStop(string entityName, string eventName, object payload, Activity activity, Activity sendActivity, int messageCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Send.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (sendActivity != null)
            {
                Assert.Equal(sendActivity, activity);
            }

            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            Assert.Equal(messageCount, messages.Count);
        }

        #endregion

        #region Complete

        protected void AssertCompleteStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Complete.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<IList<string>>(payload, "LockTokens");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertCompleteStop(string entityName, string eventName, object payload, Activity activity, Activity completeActivity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Complete.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (completeActivity != null)
            {
                Assert.Equal(completeActivity, activity);
            }

            var tokens = GetPropertyValueFromAnonymousTypeInstance<IList<string>>(payload, "LockTokens");
            Assert.Equal(1, tokens.Count);
        }

        #endregion


        #region Abandon

        protected void AssertAbandonStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Abandon.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertAbandonStop(string entityName, string eventName, object payload, Activity activity, Activity abandonActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Abandon.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (abandonActivity != null)
            {
                Assert.Equal(abandonActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion


        #region Defer

        protected void AssertDeferStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Defer.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertDeferStop(string entityName, string eventName, object payload, Activity activity, Activity deferActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Defer.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (deferActivity != null)
            {
                Assert.Equal(deferActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion

        #region DeadLetter

        protected void AssertDeadLetterStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.DeadLetter.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertDeadLetterStop(string entityName, string eventName, object payload, Activity activity, Activity deadLetterActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.DeadLetter.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (deadLetterActivity != null)
            {
                Assert.Equal(deadLetterActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion

        #region Schedule

        protected void AssertScheduleStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Schedule.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");
            GetPropertyValueFromAnonymousTypeInstance<DateTimeOffset>(payload, "ScheduleEnqueueTimeUtc");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
            AssertTags(message, activity);
        }

        protected void AssertScheduleStop(string entityName, string eventName, object payload, Activity activity, Activity scheduleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Schedule.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            Assert.Equal(scheduleActivity, activity);
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");
            GetPropertyValueFromAnonymousTypeInstance<DateTimeOffset>(payload, "ScheduleEnqueueTimeUtc");
            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "SequenceNumber");
            Assert.NotNull(message);
            Assert.Contains("Diagnostic-Id", message.UserProperties.Keys);
            if (scheduleActivity.Baggage.Any())
            {
                Assert.Contains("Correlation-Context", message.UserProperties.Keys);
            }
        }

        #endregion

        #region Cancel

        protected void AssertCancelStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Cancel.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "SequenceNumber");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertCancelStop(string entityName, string eventName, object payload, Activity activity, Activity scheduleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Cancel.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            Assert.Equal(scheduleActivity, activity);
            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "SequenceNumber");
        }

        #endregion

        #region Receive

        protected int AssertReceiveStart(string entityName, string eventName, object payload, Activity activity, int messagesCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Receive.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            var count = GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount");
            if (messagesCount != -1)
            {
                Assert.Equal(messagesCount, count);
            }
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);

            return count;
        }

        protected int AssertReceiveStop(string entityName, string eventName, object payload, Activity activity, Activity receiveActivity, Activity sendActivity, int sentMessagesCount = 1, int receivedMessagesCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Receive.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (receiveActivity != null)
            {
                Assert.Equal(receiveActivity, activity);
            }

            Assert.Equal(sentMessagesCount, GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount"));
            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages", true);

            if (receivedMessagesCount != -1)
            {
                Assert.Equal(receivedMessagesCount, messages.Count);
            }

            if (sendActivity != null)
            {
                Assert.Contains(sendActivity.Id, activity.Tags.Single(t => t.Key == "RelatedTo").Value);
            }

            AssertTags(messages, activity);
            return messages?.Count ?? 0;
        }

        #endregion

        #region ReceiveDeferred

        protected void AssertReceiveDeferredStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ReceiveDeferred.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            Assert.Single(GetPropertyValueFromAnonymousTypeInstance<IEnumerable<long>>(payload, "SequenceNumbers"));

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertReceiveDeferredStop(string entityName, string eventName, object payload, Activity activity, Activity receiveActivity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ReceiveDeferred.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (receiveActivity != null)
            {
                Assert.Equal(receiveActivity, activity);
            }

            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            Assert.Equal(1, messages.Count);
            Assert.Single(GetPropertyValueFromAnonymousTypeInstance<IEnumerable<long>>(payload, "SequenceNumbers"));

            Assert.Equal(sendActivity.Id, activity.Tags.Single(t => t.Key == "RelatedTo").Value);

            AssertTags(messages, activity);
        }

        #endregion


        #region Process

        protected void AssertProcessStart(string entityName, string eventName, object payload, Activity activity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Process.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sendActivity.Id, activity.ParentId);
            Assert.Equal(sendActivity.Baggage.OrderBy(p => p.Key), activity.Baggage.OrderBy(p => p.Key));

            AssertTags(message, activity);
        }

        protected void AssertProcessStop(string entityName, string eventName, object payload, Activity activity, Activity processActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Process.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (processActivity != null)
            {
                Assert.Equal(processActivity, activity);
            }
        }

        #endregion


        #region Peek

        protected void AssertPeekStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Peek.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "FromSequenceNumber");
            Assert.Equal(1, GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount"));

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertPeekStop(string entityName, string eventName, object payload, Activity activity, Activity peekActivity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Peek.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (peekActivity != null)
            {
                Assert.Equal(peekActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "FromSequenceNumber");
            Assert.Equal(1, GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount"));
            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            AssertTags(messages, activity);

            Assert.Equal(sendActivity.Id, activity.Tags.Single(t => t.Key == "RelatedTo").Value);
        }

        #endregion


        #region RenewLock

        protected void AssertRenewLockStart(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewLock.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertRenewLockStop(string entityName, string eventName, object payload, Activity activity, Activity renewLockActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewLock.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);

            if (renewLockActivity != null)
            {
                Assert.Equal(renewLockActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
            GetPropertyValueFromAnonymousTypeInstance<DateTime>(payload, "LockedUntilUtc");
        }

        #endregion

        protected void AssertTags(IList<Message> messageList, Activity activity)
        {
            if (messageList == null)
            {
                return;
            }

            var messagesWithId = messageList.Where(m => m.MessageId != null).ToArray();
            if (messagesWithId.Any())
            {
                Assert.Contains("MessageId", activity.Tags.Select(t => t.Key));

                string messageIdTag = activity.Tags.Single(t => t.Key == "MessageId").Value;
                foreach (var m in messagesWithId)
                {
                    Assert.Contains(m.MessageId, messageIdTag);
                }
            }

            var messagesWithSessionId = messageList.Where(m => m.SessionId != null).ToArray();
            if (messagesWithSessionId.Any())
            {
                Assert.Contains("SessionId", activity.Tags.Select(t => t.Key));

                string sessionIdTag = activity.Tags.Single(t => t.Key == "SessionId").Value;
                foreach (var m in messagesWithSessionId)
                {
                    Assert.Contains(m.SessionId, sessionIdTag);
                }
            }
        }

        protected void AssertTags(Message message, Activity activity)
        {
            if (message?.MessageId != null)
            {
                Assert.Contains("MessageId", activity.Tags.Select(t => t.Key));
                Assert.Equal(message.MessageId, activity.Tags.Single(t => t.Key == "MessageId").Value);
            }

            if (message?.SessionId != null)
            {
                Assert.Contains("SessionId", activity.Tags.Select(t => t.Key));
                Assert.Equal(message.SessionId, activity.Tags.Single(t => t.Key == "SessionId").Value);
            }
        }

        protected void AssertException(string entityName, string eventName, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Exception", eventName);
            AssertCommonPayloadProperties(entityName, payload);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            Assert.NotNull(activity);
            if (parentActivity != null)
            {
                Assert.Equal(parentActivity, activity.Parent);
            }
        }

        protected void AssertCommonPayloadProperties(string entityName, object eventPayload)
        {
            var entity = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");

            Assert.Equal(entityName, entity);
        }

        protected void AssertCommonStopPayloadProperties(string entityName, object eventPayload)
        {
            AssertCommonPayloadProperties(entityName, eventPayload);
            var status = GetPropertyValueFromAnonymousTypeInstance<TaskStatus>(eventPayload, "Status");
            Assert.Equal(TaskStatus.RanToCompletion, status);
        }

        protected T GetPropertyValueFromAnonymousTypeInstance<T>(object obj, string propertyName, bool canValueBeNull = false)
        {
            Type t = obj.GetType();

            PropertyInfo p = t.GetRuntimeProperty(propertyName);

            object propertyValue = p.GetValue(obj);
            if (!canValueBeNull)
            {
                Assert.NotNull(propertyValue);
            }

            if (propertyValue != null)
            {
                Assert.IsAssignableFrom<T>(propertyValue);
            }

            return (T)propertyValue;
        }
    }
}
