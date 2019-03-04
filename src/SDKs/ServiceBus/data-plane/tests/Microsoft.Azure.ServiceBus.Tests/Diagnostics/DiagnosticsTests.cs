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

    public abstract class DiagnosticsTests : IDisposable
    {
        protected ConcurrentQueue<(string eventName, object payload, Activity activity)> events;
        protected FakeDiagnosticListener listener;
        protected IDisposable subscription;
        protected const int maxWaitSec = 10;

        protected abstract string EntityName { get; }
        private bool disposed = false;

        internal DiagnosticsTests()
        {
            this.events = new ConcurrentQueue<(string eventName, object payload, Activity activity)>();
            this.listener = new FakeDiagnosticListener(kvp =>
            {
                TestUtility.Log($"Diagnostics event: {kvp.Key}, Activity Id: {Activity.Current?.Id}");
                if (kvp.Key.Contains("Exception"))
                {
                    TestUtility.Log($"Exception {kvp.Value}");
                }

                this.events.Enqueue((kvp.Key, kvp.Value, Activity.Current));
            });
            this.subscription = DiagnosticListener.AllListeners.Subscribe(this.listener);
        }

        #region Send

        protected void AssertSendStart(string name, object payload, Activity activity, Activity parentActivity, int messageCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Send.Start", name);
            AssertCommonPayloadProperties(payload);
            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            Assert.Equal(messageCount, messages.Count);

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);

            AssertTags(messages, activity);
        }

        protected void AssertSendStop(string name, object payload, Activity activity, Activity sendActivity, int messageCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Send.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (sendActivity != null)
            {
                Assert.Equal(sendActivity, activity);
            }

            var messages = GetPropertyValueFromAnonymousTypeInstance<IList<Message>>(payload, "Messages");
            Assert.Equal(messageCount, messages.Count);
        }

        #endregion

        #region Complete

        protected void AssertCompleteStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Complete.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<IList<string>>(payload, "LockTokens");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertCompleteStop(string name, object payload, Activity activity, Activity completeActivity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Complete.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (completeActivity != null)
            {
                Assert.Equal(completeActivity, activity);
            }

            var tokens = GetPropertyValueFromAnonymousTypeInstance<IList<string>>(payload, "LockTokens");
            Assert.Equal(1, tokens.Count);
        }

        #endregion


        #region Abandon

        protected void AssertAbandonStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Abandon.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertAbandonStop(string name, object payload, Activity activity, Activity abandonActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Abandon.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (abandonActivity != null)
            {
                Assert.Equal(abandonActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion


        #region Defer

        protected void AssertDeferStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Defer.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertDeferStop(string name, object payload, Activity activity, Activity deferActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Defer.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (deferActivity != null)
            {
                Assert.Equal(deferActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion

        #region DeadLetter

        protected void AssertDeadLetterStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.DeadLetter.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertDeadLetterStop(string name, object payload, Activity activity, Activity deadLetterActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.DeadLetter.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (deadLetterActivity != null)
            {
                Assert.Equal(deadLetterActivity, activity);
            }

            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");
        }

        #endregion

        #region Schedule

        protected void AssertScheduleStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Schedule.Start", name);
            AssertCommonPayloadProperties(payload);
            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");
            GetPropertyValueFromAnonymousTypeInstance<DateTimeOffset>(payload, "ScheduleEnqueueTimeUtc");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
            AssertTags(message, activity);
        }

        protected void AssertScheduleStop(string name, object payload, Activity activity, Activity scheduleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Schedule.Stop", name);
            AssertCommonStopPayloadProperties(payload);

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

        protected void AssertCancelStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Cancel.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "SequenceNumber");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertCancelStop(string name, object payload, Activity activity, Activity scheduleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Cancel.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            Assert.Equal(scheduleActivity, activity);
            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "SequenceNumber");
        }

        #endregion

        #region Receive

        protected int AssertReceiveStart(string name, object payload, Activity activity, int messagesCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Receive.Start", name);
            AssertCommonPayloadProperties(payload);

            var count = GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount");
            if (messagesCount != -1)
            {
                Assert.Equal(messagesCount, count);
            }
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);

            return count;
        }

        protected int AssertReceiveStop(string name, object payload, Activity activity, Activity receiveActivity, Activity sendActivity, int sentMessagesCount = 1, int receivedMessagesCount = 1)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Receive.Stop", name);
            AssertCommonStopPayloadProperties(payload);

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

        protected void AssertReceiveDeferredStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ReceiveDeferred.Start", name);
            AssertCommonPayloadProperties(payload);

            Assert.Single(GetPropertyValueFromAnonymousTypeInstance<IEnumerable<long>>(payload, "SequenceNumbers"));

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertReceiveDeferredStop(string name, object payload, Activity activity, Activity receiveActivity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.ReceiveDeferred.Stop", name);
            AssertCommonStopPayloadProperties(payload);

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

        protected void AssertProcessStart(string name, object payload, Activity activity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Process.Start", name);
            AssertCommonPayloadProperties(payload);

            var message = GetPropertyValueFromAnonymousTypeInstance<Message>(payload, "Message");

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
            Assert.Equal(sendActivity.Id, activity.ParentId);
            Assert.Equal(sendActivity.Baggage.OrderBy(p => p.Key), activity.Baggage.OrderBy(p => p.Key));

            AssertTags(message, activity);
        }

        protected void AssertProcessStop(string name, object payload, Activity activity, Activity processActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Process.Stop", name);
            AssertCommonStopPayloadProperties(payload);

            if (processActivity != null)
            {
                Assert.Equal(processActivity, activity);
            }
        }

        #endregion


        #region Peek

        protected void AssertPeekStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Peek.Start", name);
            AssertCommonPayloadProperties(payload);

            GetPropertyValueFromAnonymousTypeInstance<long>(payload, "FromSequenceNumber");
            Assert.Equal(1, GetPropertyValueFromAnonymousTypeInstance<int>(payload, "RequestedMessageCount"));

            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertPeekStop(string name, object payload, Activity activity, Activity peekActivity, Activity sendActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Peek.Stop", name);
            AssertCommonStopPayloadProperties(payload);

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

        protected void AssertRenewLockStart(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewLock.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "LockToken");

            Assert.NotNull(activity);
            Assert.Equal(parentActivity, activity.Parent);
        }

        protected void AssertRenewLockStop(string name, object payload, Activity activity, Activity renewLockActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RenewLock.Stop", name);
            AssertCommonStopPayloadProperties(payload);

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

        protected void AssertException(string name, object payload, Activity activity, Activity parentActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.Exception", name);
            AssertCommonPayloadProperties(payload);

            GetPropertyValueFromAnonymousTypeInstance<Exception>(payload, "Exception");

            Assert.NotNull(activity);
            if (parentActivity != null)
            {
                Assert.Equal(parentActivity, activity.Parent);
            }
        }

        protected void AssertCommonPayloadProperties(object eventPayload)
        {
            var entity = GetPropertyValueFromAnonymousTypeInstance<string>(eventPayload, "Entity");
            GetPropertyValueFromAnonymousTypeInstance<Uri>(eventPayload, "Endpoint");

            Assert.Equal(this.EntityName, entity);
        }

        protected void AssertCommonStopPayloadProperties(object eventPayload)
        {
            AssertCommonPayloadProperties(eventPayload);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                //Thread.Sleep(90000);
                this.listener?.Disable();

                while (this.events.TryDequeue(out var evnt))
                {
                }

                while (Activity.Current != null)
                {
                    Activity.Current.Stop();
                }

                this.listener?.Dispose();
                this.subscription?.Dispose();

                this.events = null;
                this.listener = null;
                this.subscription = null;
            }

            this.disposed = true;
        }
    }
}
