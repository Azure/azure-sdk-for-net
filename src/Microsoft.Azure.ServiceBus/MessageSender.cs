// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class MessageSender : ClientEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
             "StyleCop.CSharp.ReadabilityRules",
             "SA1126:PrefixCallsCorrectly",
             Justification = "This is not a method call, but a type.")]
        protected MessageSender(TimeSpan operationTimeout)
            : base(nameof(MessageSender) + StringUtility.GetRandomString())
        {
            this.OperationTimeout = operationTimeout;
        }

        internal TimeSpan OperationTimeout { get; }

        protected MessagingEntityType EntityType { get; set; }

        public Task SendAsync(BrokeredMessage brokeredMessage)
        {
            return this.SendAsync(new[] { brokeredMessage });
        }

        public async Task SendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            int count = MessageSender.ValidateMessages(brokeredMessages);
            MessagingEventSource.Log.MessageSendStart(this.ClientId, count);

            try
            {
                await this.OnSendAsync(brokeredMessages).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageSendException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.MessageSendStop(this.ClientId);
        }

        public async Task<long> ScheduleMessageAsync(BrokeredMessage message, DateTimeOffset scheduleEnqueueTimeUtc)
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
            long result;

            try
            {
                result = await this.OnScheduleMessageAsync(message).ConfigureAwait(false);
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
                await this.OnCancelScheduledMessageAsync(sequenceNumber).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.CancelScheduledMessageException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.CancelScheduledMessageStop(this.ClientId);
        }

        protected abstract Task OnSendAsync(IEnumerable<BrokeredMessage> brokeredMessages);

        protected abstract Task<long> OnScheduleMessageAsync(BrokeredMessage brokeredMessage);

        protected abstract Task OnCancelScheduledMessageAsync(long sequenceNumber);

        static int ValidateMessages(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            int count = 0;
            if (brokeredMessages == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(brokeredMessages));
            }

            foreach (var message in brokeredMessages)
            {
                count++;
                ValidateMessage(message);
            }

            return count;
        }

        static void ValidateMessage(BrokeredMessage brokeredMessage)
        {
            if (brokeredMessage.IsLockTokenSet)
            {
                throw Fx.Exception.Argument(nameof(brokeredMessage), "Cannot send a message that was already received.");
            }
        }
    }
}