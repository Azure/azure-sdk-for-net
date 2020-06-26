// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Plugins
{
    /// <summary>
    /// This class provides methods that can be overridden to manipulate messages for custom plugin functionality.
    /// </summary>
    internal abstract class ServiceBusPlugin
    {
        /// <summary>
        /// This operation is called before a message is sent and can be
        /// overridden to alter the body and the properties of an outgoing message.
        /// </summary>
        /// <param name="message">The <see cref="ServiceBusMessage"/> to be modified by the plugin.</param>
        public virtual ValueTask BeforeMessageSendAsync(ServiceBusMessage message) =>
            default;

        /// <summary>
        /// This operation is called after a message is received, but before it is returned to the <see cref="ServiceBusReceiver"/>.
        /// It can be overridden to alter the body and the properties of an
        /// incoming message.
        /// </summary>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to be modified by the plugin.</param>
        public virtual ValueTask AfterMessageReceiveAsync(ServiceBusReceivedMessage message) =>
            default;

        /// <summary>
        /// Set the <see cref="ServiceBusReceivedMessage.Body"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="body">The body to set on the message. This will overwrite any existing body.</param>
#pragma warning disable CA1822 // Mark members as static
        protected void SetBody(ServiceBusReceivedMessage message, BinaryData body)
        {
            message.SentMessage.Body = body;
        }

        /// <summary>
        /// Set a key/value pair on the <see cref="ServiceBusReceivedMessage.Properties"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="key">The key to add or update the value of.</param>
        /// <param name="value">The value to set for the associated key.</param>
        protected void SetUserProperty(ServiceBusReceivedMessage message, string key, object value)
        {
            message.SentMessage.Properties[key] = value;
        }

        /// <summary>
        /// Sets the
        /// <see cref="ServiceBusReceivedMessage.ContentType"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="contentType">The content type to set on
        /// the message.</param>

        protected void SetContentType(ServiceBusReceivedMessage message, string contentType)
        {
            message.SentMessage.ContentType = contentType;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.CorrelationId"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="correlationId">The correlationId to set
        /// on the message.</param>

        protected void SetCorrelationId(ServiceBusReceivedMessage message, string correlationId)
        {
            message.SentMessage.CorrelationId = correlationId;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.Label"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="label">The label to set on the message.</param>

        protected void SetLabel(ServiceBusReceivedMessage message, string label)
        {
            message.SentMessage.Label = label;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.MessageId"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="messageId">The message ID to set on the message.</param>

        protected void SetMessageId(ServiceBusReceivedMessage message, string messageId)
        {
            message.SentMessage.MessageId = messageId;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.PartitionKey"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="partitionKey">The partition key to set on the message.</param>

        protected void SetPartitionKey(ServiceBusReceivedMessage message, string partitionKey)
        {
            message.SentMessage.PartitionKey = partitionKey;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.ReplyTo"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="replyTo">The reply to value to set on the message.</param>

        protected void SetReplyTo(ServiceBusReceivedMessage message, string replyTo)
        {
            message.SentMessage.ReplyTo = replyTo;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.ReplyToSessionId"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="replyToSessionId">The reply to session ID value to set on the message.</param>

        protected void SetReplyToSessionId(ServiceBusReceivedMessage message, string replyToSessionId)
        {
            message.SentMessage.ReplyToSessionId = replyToSessionId;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.SessionId"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="sessionId">The session ID to set on the message.</param>
        protected void SetSessionId(ServiceBusReceivedMessage message, string sessionId)
        {
            message.SentMessage.SessionId = sessionId;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.ScheduledEnqueueTime"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="scheduledEnqueueTime">The scheduled enqueue time to set on the message.</param>
        protected void SetScheduledEnqueueTime(ServiceBusReceivedMessage message, DateTimeOffset scheduledEnqueueTime)
        {
            message.SentMessage.ScheduledEnqueueTime = scheduledEnqueueTime;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.TimeToLive"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="timeToLive">The time to live to set on the message.</param>

        protected void SetTimeToLive(ServiceBusReceivedMessage message, TimeSpan timeToLive)
        {
            message.SentMessage.TimeToLive = timeToLive;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.To"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="to">The to value to set on the message.</param>
        protected void SetTo(ServiceBusReceivedMessage message, string to)
        {
            message.SentMessage.To = to;
        }

        /// <summary>
        /// Sets the <see cref="ServiceBusReceivedMessage.ViaPartitionKey"/>.
        /// </summary>
        /// <param name="message">The message to modify.</param>
        /// <param name="viaPartitionKey">The via partition key to set on the message.</param>
        protected void SetViaPartitionKey(ServiceBusReceivedMessage message, string viaPartitionKey)
        {
            message.SentMessage.ViaPartitionKey = viaPartitionKey;
        }
#pragma warning restore CA1822 // Mark members as static
    }
}
