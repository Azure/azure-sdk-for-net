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
    public abstract class ServiceBusPlugin
    {
        /// <summary>
        /// Gets the name of the <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <remarks>This name is used to identify the plugin, and prevent a plugin from being registered multiple times.</remarks>
        public abstract string Name { get; }

        /// <summary>
        /// Determines whether or an exception in the plugin should prevent a send or receive operation.
        /// </summary>
        public virtual bool ShouldContinueOnException => false;

        /// <summary>
        /// This operation is called before a message is sent.
        /// </summary>
        /// <param name="message">The <see cref="ServiceBusMessage"/> to be modified by the plugin</param>
        /// <returns>The modified <see cref="ServiceBusMessage"/>.</returns>
        public virtual Task BeforeMessageSend(ServiceBusMessage message)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// This operation is called after a message is received, but before it is returned to the <see cref="ServiceBusReceiver"/>.
        /// </summary>
        /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to be modified by the plugin</param>
        /// <returns>The modified <see cref="ServiceBusReceivedMessage"/>.</returns>
        public virtual Task AfterMessageReceive(ServiceBusReceivedMessage message)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="body"></param>
        protected static void SetBody(ServiceBusReceivedMessage message, BinaryData body)
        {
            message.SentMessage.Body = body;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected static void SetUserProperty(ServiceBusReceivedMessage message, string key, object value)
        {
            message.SentMessage.Properties[key] = value;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="contentType"></param>

        protected static void SetContentType(ServiceBusReceivedMessage message, string contentType)
        {
            message.SentMessage.ContentType = contentType;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="correlationId"></param>

        protected static void SetCorrelationId(ServiceBusReceivedMessage message, string correlationId)
        {
            message.SentMessage.CorrelationId = correlationId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="label"></param>

        protected static void SetLabel(ServiceBusReceivedMessage message, string label)
        {
            message.SentMessage.Label = label;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageId"></param>

        protected static void SetMessageId(ServiceBusReceivedMessage message, string messageId)
        {
            message.SentMessage.MessageId = messageId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="partitionKey"></param>

        protected static void SetPartitionKey(ServiceBusReceivedMessage message, string partitionKey)
        {
            message.SentMessage.PartitionKey = partitionKey;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="replyTo"></param>

        protected static void SetReplyTo(ServiceBusReceivedMessage message, string replyTo)
        {
            message.SentMessage.ReplyTo = replyTo;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="replyToSessionId"></param>

        protected static void SetReplyToSessionId(ServiceBusReceivedMessage message, string replyToSessionId)
        {
            message.SentMessage.ReplyToSessionId = replyToSessionId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sessionId"></param>

        protected static void SetSessionId(ServiceBusReceivedMessage message, string sessionId)
        {
            message.SentMessage.SessionId = sessionId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="scheduledEnqueueTime"></param>

        protected static void SetScheduledEnqueueTime(ServiceBusReceivedMessage message, DateTimeOffset scheduledEnqueueTime)
        {
            message.SentMessage.ScheduledEnqueueTime = scheduledEnqueueTime;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeToLive"></param>

        protected static void SetTimeToLive(ServiceBusReceivedMessage message, TimeSpan timeToLive)
        {
            message.SentMessage.TimeToLive = timeToLive;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="to"></param>

        protected static void SetTo(ServiceBusReceivedMessage message, string to)
        {
            message.SentMessage.To = to;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="viaPartitionKey"></param>

        protected static void SetViaPartitionKey(ServiceBusReceivedMessage message, string viaPartitionKey)
        {
            message.SentMessage.ViaPartitionKey = viaPartitionKey;
        }
    }
}
