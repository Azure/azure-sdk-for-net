// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal abstract class MessageSender : ClientEntity, IMessageSender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
             "StyleCop.CSharp.ReadabilityRules",
             "SA1126:PrefixCallsCorrectly",
             Justification = "This is not a method call, but a type.")]
        protected MessageSender(TimeSpan operationTimeout, RetryPolicy retryPolicy)
            : base(nameof(MessageSender) + StringUtility.GetRandomString(), retryPolicy ?? RetryPolicy.Default)
        {
            this.OperationTimeout = operationTimeout;
        }

        internal TimeSpan OperationTimeout { get; }

        protected MessagingEntityType? EntityType { get; set; }

        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        public async Task SendAsync(IList<Message> messageList)
        {
            int count = MessageSender.ValidateMessages(messageList);
            MessagingEventSource.Log.MessageSendStart(this.ClientId, count);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnSendAsync(messageList).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageSendException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageSendStop(this.ClientId);
        }

        public async Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            if (message == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(message));
            }

            if (scheduleEnqueueTimeUtc.CompareTo(DateTimeOffset.UtcNow) < 0)
            {
                throw Fx.Exception.ArgumentOutOfRange(
                    nameof(scheduleEnqueueTimeUtc),
                    scheduleEnqueueTimeUtc.ToString(),
                    "Cannot schedule messages in the past");
            }

            message.ScheduledEnqueueTimeUtc = scheduleEnqueueTimeUtc.UtcDateTime;
            MessageSender.ValidateMessage(message);
            MessagingEventSource.Log.ScheduleMessageStart(this.ClientId, scheduleEnqueueTimeUtc);
            long result = 0;

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        result = await this.OnScheduleMessageAsync(message).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.ScheduleMessageException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.ScheduleMessageStop(this.ClientId);
            return result;
        }

        public async Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            MessagingEventSource.Log.CancelScheduledMessageStart(this.ClientId, sequenceNumber);

            try
            {
                await this.RetryPolicy.RunOperation(
                    async () =>
                    {
                        await this.OnCancelScheduledMessageAsync(sequenceNumber).ConfigureAwait(false);
                    }, this.OperationTimeout)
                    .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.CancelScheduledMessageException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.CancelScheduledMessageStop(this.ClientId);
        }

        protected abstract Task OnSendAsync(IList<Message> messageList);

        protected abstract Task<long> OnScheduleMessageAsync(Message message);

        protected abstract Task OnCancelScheduledMessageAsync(long sequenceNumber);

        static int ValidateMessages(IList<Message> messageList)
        {
            int count = 0;
            if (messageList == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(messageList));
            }

            foreach (var message in messageList)
            {
                count++;
                ValidateMessage(message);
            }

            return count;
        }

        static void ValidateMessage(Message message)
        {
            if (message.SystemProperties.IsLockTokenSet)
            {
                throw Fx.Exception.Argument(nameof(message), "Cannot send a message that was already received.");
            }
        }
    }
}