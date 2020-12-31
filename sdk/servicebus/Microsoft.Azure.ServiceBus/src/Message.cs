// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Primitives;

    /// <summary>
    /// The message object used to communicate and transfer data with Service Bus.
    /// </summary>
    /// <remarks>
    /// The message structure is discussed in detail in the <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads">product documentation.</a>
    /// </remarks>
    public class Message
    {
        /// <summary>
        /// User property key representing deadletter reason, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        public static string DeadLetterReasonHeader = "DeadLetterReason";

        /// <summary>
        /// User property key representing detailed error description, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        public static string DeadLetterErrorDescriptionHeader = "DeadLetterErrorDescription";

        private string messageId;
        private string sessionId;
        private string replyToSessionId;
        private string partitionKey;
        private string viaPartitionKey;
        private TimeSpan timeToLive;

        /// <summary>
        /// Creates a new Message
        /// </summary>
        public Message()
            : this(null)
        {
        }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes</param>
        public Message(byte[] body)
        {
            this.Body = body;
            this.SystemProperties = new SystemPropertiesCollection();
            this.UserProperties = new Dictionary<string, object>();
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
        public byte[] Body { get; set; }

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
            get => this.messageId;

            set
            {
                Message.ValidateMessageId(value);
                this.messageId = value;
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
            get => this.partitionKey;

            set
            {
                if (this.sessionId != null && this.sessionId != value)
                {
                    // SessionId is set. Then partition key must be same as session id.
                    throw new InvalidOperationException($"PartitionKey:{value} is not same as SessionId:{this.sessionId}");
                }

                Message.ValidatePartitionKey(nameof(this.PartitionKey), value);
                this.partitionKey = value;
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
            get => this.viaPartitionKey;

            set
            {
                Message.ValidatePartitionKey(nameof(this.ViaPartitionKey), value);
                this.viaPartitionKey = value;
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
            get => this.sessionId;

            set
            {
                Message.ValidateSessionId(nameof(this.SessionId), value);
                this.sessionId = value;
                this.PartitionKey = value;
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
            get => this.replyToSessionId;

            set
            {
                Message.ValidateSessionId(nameof(this.ReplyToSessionId), value);
                this.replyToSessionId = value;
            }
        }

        /// <summary>Gets the date and time in UTC at which the message is set to expire.</summary>
        /// <value>The message expiration time in UTC. This property is read-only.</value>
        /// <exception cref="System.InvalidOperationException">If the message has not been received. For example if a new message was created but not yet sent and received.</exception>
        /// <remarks>
        ///  The UTC instant at which the message is marked for removal and no longer available for retrieval
        ///  from the entity due to expiration. Expiry is controlled by the <see cref="TimeToLive"/> property
        ///  and this property is computed from <see cref="SystemPropertiesCollection.EnqueuedTimeUtc"/>+<see cref="TimeToLive"/></remarks>
        public DateTime ExpiresAtUtc
        {
            get
            {
                if (this.TimeToLive >= DateTime.MaxValue.Subtract(this.SystemProperties.EnqueuedTimeUtc))
                {
                    return DateTime.MaxValue;
                }

                return this.SystemProperties.EnqueuedTimeUtc.Add(this.TimeToLive);
            }
        }

        /// <summary>
        /// Gets or sets the message’s "time to live" value.
        /// </summary>
        /// <value>The message’s time to live value.</value>
        /// <remarks>
        ///     This value is the relative duration after which the message expires, starting from the instant
        ///      the message has been accepted and stored by the broker, as captured in <see cref="SystemPropertiesCollection.EnqueuedTimeUtc"/>.
        ///      When not set explicitly, the assumed value is the DefaultTimeToLive for the respective queue or topic.
        ///      A message-level <see cref="TimeToLive"/> value cannot be longer than the entity's DefaultTimeToLive
        ///      setting and it is silently adjusted if it does.
        ///      See <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-expiration">Expiration</a>
        /// </remarks>
        public TimeSpan TimeToLive
        {
            get
            {
                if (this.timeToLive == TimeSpan.Zero)
                {
                    return TimeSpan.MaxValue;
                }

                return this.timeToLive;
            }

            set
            {
                TimeoutHelper.ThrowIfNonPositiveArgument(value);
                this.timeToLive = value;
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
        public DateTime ScheduledEnqueueTimeUtc { get; set; }

        // TODO: Calculate the size of the properties and body
        /// <summary>
        /// Gets the total size of the message body in bytes.
        /// </summary>
        public long Size => this.Body != null ? this.Body.Length : 0;

        /// <summary>
        /// Gets the "user properties" bag, which can be used for custom message metadata.
        /// </summary>
        /// <remarks>
        /// Only following value types are supported:
        /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
        /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
        /// </remarks>
        public IDictionary<string, object> UserProperties { get; internal set; }

        /// <summary>
        /// Gets the <see cref="SystemPropertiesCollection"/>, which is used to store properties that are set by the system.
        /// </summary>
        public SystemPropertiesCollection SystemProperties { get; internal set; }

        /// <summary>Returns a string that represents the current message.</summary>
        /// <returns>The string representation of the current message.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{MessageId:{0}}}", this.MessageId);
        }

        /// <summary>Clones a message, so that it is possible to send a clone of an already received
        /// message as a new message. The system properties of original message
        /// are not copied.</summary>
        /// <returns>A cloned <see cref="Message" />.</returns>
        public Message Clone()
        {
            var clone = (Message)this.MemberwiseClone();
            clone.SystemProperties = new SystemPropertiesCollection();

            if (this.Body != null)
            {
                var clonedBody = new byte[this.Body.Length];
                Array.Copy(this.Body, clonedBody, this.Body.Length);
                clone.Body = clonedBody;
            }
            return clone;
        }

        private static void ValidateMessageId(string messageId)
        {
            if (string.IsNullOrEmpty(messageId) ||
                messageId.Length > Constants.MaxMessageIdLength)
            {
                // TODO: throw FxTrace.Exception.Argument("messageId", SRClient.MessageIdIsNullOrEmptyOrOverMaxValue(Constants.MaxMessageIdLength));
                throw new ArgumentException("MessageIdIsNullOrEmptyOrOverMaxValue");
            }
        }

        private static void ValidateSessionId(string sessionIdPropertyName, string sessionId)
        {
            if (sessionId != null && sessionId.Length > Constants.MaxSessionIdLength)
            {
                // TODO: throw FxTrace.Exception.Argument("sessionId", SRClient.SessionIdIsOverMaxValue(Constants.MaxSessionIdLength));
                throw new ArgumentException("SessionIdIsOverMaxValue");
            }
        }

        private static void ValidatePartitionKey(string partitionKeyPropertyName, string partitionKey)
        {
            if (partitionKey != null && partitionKey.Length > Constants.MaxPartitionKeyLength)
            {
                // TODO: throw FxTrace.Exception.Argument(partitionKeyPropertyName, SRClient.PropertyOverMaxValue(partitionKeyPropertyName, Constants.MaxPartitionKeyLength));
                throw new ArgumentException("PropertyValueOverMaxValue");
            }
        }

        /// <summary>
        /// A collection used to store properties which are set by the Service Bus service.
        /// </summary>
        public sealed class SystemPropertiesCollection
        {
            int deliveryCount;
            DateTime lockedUntilUtc;
            long sequenceNumber = -1;
            short partitionId;
            long enqueuedSequenceNumber;
            DateTime enqueuedTimeUtc;
            Guid lockTokenGuid;
            string deadLetterSource;

            /// <summary>
            /// Specifies whether or not there is a lock token set on the current message.
            /// </summary>
            /// <remarks>A lock token will only be specified if the message was received using <see cref="ReceiveMode.PeekLock"/></remarks>
            public bool IsLockTokenSet => this.lockTokenGuid != default;

            /// <summary>
            /// Gets the lock token for the current message.
            /// </summary>
            /// <remarks>
            ///   The lock token is a reference to the lock that is being held by the broker in <see cref="ReceiveMode.PeekLock"/> mode.
            ///   Locks are used to explicitly settle messages as explained in the <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement">product documentation in more detail</a>.
            ///   The token can also be used to pin the lock permanently through the <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-deferral">Deferral API</a> and, with that, take the message out of the
            ///   regular delivery state flow. This property is read-only.
            /// </remarks>
            public string LockToken => this.LockTokenGuid.ToString();

            /// <summary>Specifies if the message has been obtained from the broker.</summary>
            public bool IsReceived => this.sequenceNumber > -1;

            /// <summary>
            /// Get the current delivery count.
            /// </summary>
            /// <value>This value starts at 1.</value>
            /// <remarks>
            ///    Number of deliveries that have been attempted for this message. The count is incremented when a message lock expires,
            ///    or the message is explicitly abandoned by the receiver. This property is read-only.
            /// </remarks>
            public int DeliveryCount
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.deliveryCount;
                }

                internal set => this.deliveryCount = value;
            }

            /// <summary>Gets the date and time in UTC until which the message will be locked in the queue/subscription.</summary>
            /// <value>The date and time until which the message will be locked in the queue/subscription.</value>
            /// <remarks>
            /// 	For messages retrieved under a lock (peek-lock receive mode, not pre-settled) this property reflects the UTC
            ///     instant until which the message is held locked in the queue/subscription. When the lock expires, the <see cref="DeliveryCount"/>
            ///     is incremented and the message is again available for retrieval. This property is read-only.
            /// </remarks>
            public DateTime LockedUntilUtc
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.lockedUntilUtc;
                }

                internal set => this.lockedUntilUtc = value;
            }

            /// <summary>Gets the unique number assigned to a message by Service Bus.</summary>
            /// <remarks>
            ///     The sequence number is a unique 64-bit integer assigned to a message as it is accepted
            ///     and stored by the broker and functions as its true identifier. For partitioned entities,
            ///     the topmost 16 bits reflect the partition identifier. Sequence numbers monotonically increase.
            ///     They roll over to 0 when the 48-64 bit range is exhausted. This property is read-only.
            /// </remarks>
            public long SequenceNumber
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.sequenceNumber;
                }

                internal set => this.sequenceNumber = value;
            }

            /// <summary>
            /// Gets the name of the queue or subscription that this message was enqueued on, before it was deadlettered.
            /// </summary>
            /// <remarks>
            /// 	Only set in messages that have been dead-lettered and subsequently auto-forwarded from the dead-letter queue
            ///     to another entity. Indicates the entity in which the message was dead-lettered. This property is read-only.
            /// </remarks>
            public string DeadLetterSource
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.deadLetterSource;
                }

                internal set => this.deadLetterSource = value;
            }

            internal short PartitionId
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.partitionId;
                }

                set => this.partitionId = value;
            }

            /// <summary>Gets or sets the original sequence number of the message.</summary>
            /// <value>The enqueued sequence number of the message.</value>
            /// <remarks>
            /// For messages that have been auto-forwarded, this property reflects the sequence number
            /// that had first been assigned to the message at its original point of submission. This property is read-only.
            /// </remarks>
            public long EnqueuedSequenceNumber
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.enqueuedSequenceNumber;
                }

                internal set => this.enqueuedSequenceNumber = value;
            }

            /// <summary>Gets or sets the date and time of the sent time in UTC.</summary>
            /// <value>The enqueue time in UTC. </value>
            /// <remarks>
            ///    The UTC instant at which the message has been accepted and stored in the entity.
            ///    This value can be used as an authoritative and neutral arrival time indicator when
            ///    the receiver does not want to trust the sender's clock. This property is read-only.
            /// </remarks>
            public DateTime EnqueuedTimeUtc
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.enqueuedTimeUtc;
                }

                internal set => this.enqueuedTimeUtc = value;
            }

            internal Guid LockTokenGuid
            {
                get
                {
                    this.ThrowIfNotReceived();
                    return this.lockTokenGuid;
                }

                set => this.lockTokenGuid = value;
            }

            internal object BodyObject
            {
                get;
                set;
            }

            void ThrowIfNotReceived()
            {
                if (!this.IsReceived)
                {
                    throw Fx.Exception.AsError(new InvalidOperationException());
                }
            }
        }
    }
}
