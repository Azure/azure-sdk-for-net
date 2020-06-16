// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The message object used to communicate and transfer data with Service Bus.
    /// </summary>
    /// <remarks>
    /// The message structure is discussed in detail in the <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads">product documentation.</a>
    /// </remarks>
    public class ServiceBusMessage
    {
        private string _messageId;
        private string _sessionId;
        private string _replyToSessionId;
        private string _partitionKey;
        private string _viaPartitionKey;
        private TimeSpan _timeToLive;

        /// <summary>
        /// Creates a new message.
        /// </summary>
        public ServiceBusMessage()
            : this(default(ReadOnlyMemory<byte>))
        {
        }

        /// <summary>
        /// Creates a new message from the specified string, using UTF-8 encoding.
        /// </summary>
        /// <param name="body">The payload of the message as a string.</param>
        public ServiceBusMessage(string body) :
            this(body, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Creates a new message from the specified string, using the specified encoding.
        /// </summary>
        /// <param name="body">The payload of the message as a string.</param>
        /// <param name="encoding">The encoding to use for the body.</param>
        public ServiceBusMessage(string body, Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));
            Body = new BinaryData(body, encoding);
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes.</param>
        public ServiceBusMessage(ReadOnlyMemory<byte> body)
        {
            Body = new BinaryData(body);
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new message from the specified <see cref="BinaryData"/> instance.
        /// </summary>
        /// <param name="body">The payload of the message.</param>
        public ServiceBusMessage(BinaryData body)
        {
            Body = body;
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new message from the specified received message by copying the properties.
        /// </summary>
        /// <param name="receivedMessage">The received message to copy the data from.</param>
        public ServiceBusMessage(ServiceBusReceivedMessage receivedMessage)
        {
            Argument.AssertNotNull(receivedMessage, nameof(receivedMessage));

            Body = receivedMessage.Body;
            ContentType = receivedMessage.ContentType;
            CorrelationId = receivedMessage.CorrelationId;
            Label = receivedMessage.Label;
            MessageId = receivedMessage.MessageId;
            PartitionKey = receivedMessage.PartitionKey;
            Properties = new Dictionary<string, object>(receivedMessage.SentMessage.Properties);
            ReplyTo = receivedMessage.ReplyTo;
            ReplyToSessionId = receivedMessage.ReplyToSessionId;
            SessionId = receivedMessage.SessionId;
            ScheduledEnqueueTime = receivedMessage.ScheduledEnqueueTime;
            TimeToLive = receivedMessage.TimeToLive;
            To = receivedMessage.To;
            ViaPartitionKey = receivedMessage.ViaPartitionKey;
        }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        /// <remarks>
        /// The easiest way to create a new message from a string is the following:
        /// <code>
        /// message.Body = System.Text.Encoding.UTF8.GetBytes("Message1");
        /// </code>
        /// </remarks>
        public BinaryData Body { get; set; }

        /// <summary>
        /// Gets or sets the MessageId to identify the message.
        /// </summary>
        /// <remarks>
        ///    The message identifier is an application-defined value that uniquely identifies the
        ///    message and its payload. The identifier is a free-form string and can reflect a GUID
        ///    or an identifier derived from the application context. If enabled, the
        ///    <a href="https://docs.microsoft.com/azure/service-bus-messaging/duplicate-detection">duplicate detection</a>
        ///    feature identifies and removes second and further submissions of messages with the
        ///    same MessageId.
        /// </remarks>
        public string MessageId
        {
            get => _messageId;

            set
            {
                ValidateMessageId(value);
                _messageId = value;
            }
        }

        /// <summary>Gets or sets a partition key for sending a message to a partitioned entity.</summary>
        /// <value>The partition key. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-partitioning">partitioned entities</a>,
        ///    setting this value enables assigning related messages to the same internal partition, so that submission sequence
        ///    order is correctly recorded. The partition is chosen by a hash function over this value and cannot be chosen
        ///    directly. For session-aware entities, the <see cref="SessionId"/> property overrides this value.
        /// </remarks>
        public string PartitionKey
        {
            get => _partitionKey;

            set
            {
                ValidatePartitionKey(value);
                _partitionKey = value;
            }
        }

        /// <summary>Gets or sets a partition key for sending a message into an entity via a partitioned transfer queue.</summary>
        /// <value>The partition key. Maximum length is 128 characters. </value>
        /// <remarks>
        ///    If a message is sent via a transfer queue in the scope of a transaction, this value selects the
        ///    transfer queue partition: This is functionally equivalent to <see cref="PartitionKey"/> and ensures that
        ///    messages are kept together and in order as they are transferred.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-transactions#transfers-and-send-via">Transfers and Send Via</a>.
        /// </remarks>
        public string ViaPartitionKey
        {
            get => _viaPartitionKey;

            set
            {
                ValidatePartitionKey(value);
                _viaPartitionKey = value;
            }
        }

        /// <summary>Gets or sets the session identifier for a session-aware entity.</summary>
        /// <value>The session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For session-aware entities, this application-defined value specifies the session
        ///    affiliation of the message. Messages with the same session identifier are subject
        ///    to summary locking and enable exact in-order processing and demultiplexing.
        ///    For session-unaware entities, this value is ignored.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-sessions">Message Sessions</a>.
        /// </remarks>
        public string SessionId
        {
            get => _sessionId;

            set
            {
                ValidateSessionId(value);
                _sessionId = value;
            }
        }

        /// <summary>Gets or sets a session identifier augmenting the <see cref="ReplyTo"/> address.</summary>
        /// <value>Session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    This value augments the ReplyTo information and specifies which SessionId should be set
        ///    for the reply when sent to the reply entity. See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>
        /// </remarks>
        public string ReplyToSessionId
        {
            get => _replyToSessionId;

            set
            {
                ValidateSessionId(value);
                _replyToSessionId = value;
            }
        }

        /// <summary>
        /// Gets or sets the message’s "time to live" value.
        /// </summary>
        /// <value>The message’s time to live value.</value>
        /// <remarks>
        ///     This value is the relative duration after which the message expires, starting from the instant
        ///      the message has been accepted and stored by the broker, as captured in "SystemPropertiesCollection.EnqueuedTimeUtc"/>.
        ///      When not set explicitly, the assumed value is the DefaultTimeToLive for the respective queue or topic.
        ///      A message-level <see cref="TimeToLive"/> value cannot be longer than the entity's DefaultTimeToLive
        ///      setting and it is silently adjusted if it does.
        ///      See <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-expiration">Expiration</a>
        /// </remarks>
        public TimeSpan TimeToLive
        {
            get
            {
                if (_timeToLive == TimeSpan.Zero)
                {
                    return TimeSpan.MaxValue;
                }
                return _timeToLive;
            }

            set
            {
                Argument.AssertPositive(value, nameof(TimeToLive));
                _timeToLive = value;
            }
        }

        /// <summary>Gets or sets the a correlation identifier.</summary>
        /// <value>Correlation identifier.</value>
        /// <remarks>
        ///    Allows an application to specify a context for the message for the purposes of correlation,
        ///    for example reflecting the MessageId of a message that is being replied to.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string CorrelationId { get; set; }

        /// <summary>Gets or sets an application specific label.</summary>
        /// <value>The application specific label</value>
        /// <remarks>
        ///   This property enables the application to indicate the purpose of the message to the receiver in a standardized
        ///   fashion, similar to an email subject line. The mapped AMQP property is "subject".
        /// </remarks>
        public string Label { get; set; }

        /// <summary>Gets or sets the "to" address.</summary>
        /// <value>The "to" address.</value>
        /// <remarks>
        ///    This property is reserved for future use in routing scenarios and presently ignored by the broker itself.
        ///     Applications can use this value in rule-driven
        ///     <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-auto-forwarding">auto-forward chaining</a> scenarios to indicate the
        ///     intended logical destination of the message.
        /// </remarks>
        public string To { get; set; }

        /// <summary>Gets or sets the content type descriptor.</summary>
        /// <value>RFC2045 Content-Type descriptor.</value>
        /// <remarks>
        ///   Optionally describes the payload of the message, with a descriptor following the format of
        ///   RFC2045, Section 5, for example "application/json".
        /// </remarks>
        public string ContentType { get; set; }

        /// <summary>Gets or sets the address of an entity to send replies to.</summary>
        /// <value>The reply entity address.</value>
        /// <remarks>
        ///    This optional and application-defined value is a standard way to express a reply path
        ///    to the receiver of the message. When a sender expects a reply, it sets the value to the
        ///    absolute or relative path of the queue or topic it expects the reply to be sent to.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string ReplyTo { get; set; }

        /// <summary>Gets or sets the date and time in UTC at which the message will be enqueued. This
        /// property returns the time in UTC; when setting the property, the supplied DateTime value must also be in UTC.</summary>
        /// <value>The scheduled enqueue time in UTC. This value is for delayed message sending.
        /// It is utilized to delay messages sending to a specific time in the future.</value>
        /// <remarks> Message enqueuing time does not mean that the message will be sent at the same time. It will get enqueued, but the actual sending time
        /// depends on the queue's workload and its state.</remarks>
        public DateTimeOffset ScheduledEnqueueTime { get; set; }

        /// <summary>
        /// Gets the "user properties" bag, which can be used for custom message metadata.
        /// </summary>
        /// <remarks>
        /// Only following value types are supported:
        /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
        /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
        /// </remarks>
        public IDictionary<string, object> Properties { get; internal set; }

        /////// <summary>
        ///// Gets the <see cref="SystemPropertiesCollection"/>, which is used to store properties that are set by the system.
        ///// </summary>
        //public SystemPropertiesCollection SystemProperties { get; internal set; }

        /// <summary>Returns a string that represents the current message.</summary>
        /// <returns>The string representation of the current message.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{MessageId:{0}}}", MessageId);
        }

        private static void ValidateMessageId(string messageId)
        {
            if (string.IsNullOrEmpty(messageId) ||
                messageId.Length > Constants.MaxMessageIdLength)
            {
                throw new ArgumentException("MessageIdIsNullOrEmptyOrOverMaxValue");
            }
        }

        private static void ValidateSessionId(string sessionId)
        {
            if (sessionId != null && sessionId.Length > Constants.MaxSessionIdLength)
            {
                throw new ArgumentException("SessionIdIsOverMaxValue");
            }
        }

        private static void ValidatePartitionKey(string partitionKey)
        {
            if (partitionKey != null && partitionKey.Length > Constants.MaxPartitionKeyLength)
            {
                throw new ArgumentException("PropertyValueOverMaxValue");
            }
        }
    }
}
