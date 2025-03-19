// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Azure.Core.Amqp;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Amqp;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusReceivedMessage"/> is used to receive data from Service Bus Queues and Subscriptions.
    /// When sending messages, the <see cref="ServiceBusMessage"/> is used.
    /// </summary>
    /// <remarks>
    /// The message structure is discussed in detail in the
    /// <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads">product documentation</see>.
    /// </remarks>
    public class ServiceBusReceivedMessage
    {
        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message represented as bytes.</param>
        internal ServiceBusReceivedMessage(ReadOnlyMemory<byte> body)
            : this(new AmqpAnnotatedMessage(new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegments(new ReadOnlyMemory<byte>[] { body }))))
        {
        }

        /// <summary>
        /// Creates a new message from the specified Amqp message.
        /// </summary>
        internal ServiceBusReceivedMessage(AmqpAnnotatedMessage message)
        {
            AmqpMessage = message;
        }

        internal ServiceBusReceivedMessage(): this(body: default)
        { }

        /// <summary>
        /// Constructs a <see cref="ServiceBusReceivedMessage"/> from its serialized AMQP form.
        /// </summary>
        /// <param name="message">The AMQP message.</param>
        /// <param name="lockTokenBytes">The lock token bytes.</param>
        /// <returns>The constructed <see cref="ServiceBusReceivedMessage"/>.</returns>
        public static ServiceBusReceivedMessage FromAmqpMessage(AmqpAnnotatedMessage message, BinaryData lockTokenBytes)
        {
            var receivedMessage = new ServiceBusReceivedMessage(message);
            if (GuidUtilities.TryParseGuidBytes(lockTokenBytes, out Guid lockToken))
            {
                receivedMessage.LockTokenGuid = lockToken;
            }
            return receivedMessage;
        }

        /// <summary>
        /// Indicates whether the user has settled the message as part of their callback.
        /// If they have done so, we will not autocomplete.
        /// </summary>
        internal bool IsSettled { get; set; }

        /// <summary>
        /// Gets the raw Amqp message data that was transmitted over the wire.
        /// This can be used to enable scenarios that require reading AMQP header, footer, property, or annotation
        /// data that is not exposed as top level properties in the <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        internal AmqpAnnotatedMessage AmqpMessage { get; set; }

        /// <summary>
        /// Gets the raw Amqp message data that was transmitted over the wire.
        /// This can be used to enable scenarios that require reading AMQP header, footer, property, or annotation
        /// data that is not exposed as top level properties in the <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <returns>The raw Amqp message.</returns>
        public AmqpAnnotatedMessage GetRawAmqpMessage() => AmqpMessage;

        /// <summary>
        /// Gets the body of the message.
        /// </summary>
        public BinaryData Body => AmqpMessage.GetBody();

        /// <summary>
        /// Gets the MessageId to identify the message.
        /// </summary>
        /// <remarks>
        ///    The message identifier is an application-defined value that uniquely identifies the
        ///    message and its payload. The identifier is a free-form string and can reflect a GUID
        ///    or an identifier derived from the application context. If enabled, the
        ///    <a href="https://learn.microsoft.com/azure/service-bus-messaging/duplicate-detection">duplicate detection</a>
        ///    feature identifies and removes second and further submissions of messages with the
        ///    same MessageId.
        /// </remarks>
        public string MessageId => AmqpMessage.Properties.MessageId?.ToString();

        /// <summary>Gets a partition key for sending a message to a partitioned entity.</summary>
        /// <value>The partition key. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-partitioning">partitioned entities</a>,
        ///    setting this value enables assigning related messages to the same internal partition, so that submission sequence
        ///    order is correctly recorded. The partition is chosen by a hash function over this value and cannot be chosen
        ///    directly. For session-aware entities, the <see cref="SessionId"/> property overrides this value.
        /// </remarks>
        public string PartitionKey => AmqpMessage.GetPartitionKey();

        /// <summary>Gets a partition key for sending a message into an entity via a partitioned transfer queue.</summary>
        /// <value>The partition key. Maximum length is 128 characters. </value>
        /// <remarks>
        ///    If a message is sent via a transfer queue in the scope of a transaction, this value selects the
        ///    transfer queue partition: This is functionally equivalent to <see cref="PartitionKey"/> and ensures that
        ///    messages are kept together and in order as they are transferred.
        ///    See <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions#transfers-and-send-via">Transfers and Send Via</a>.
        /// </remarks>
        public string TransactionPartitionKey => AmqpMessage.GetViaPartitionKey();

        /// <summary>Gets the session identifier for a session-aware entity.</summary>
        /// <value>The session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For session-aware entities, this application-defined value specifies the session
        ///    affiliation of the message. Messages with the same session identifier are subject
        ///    to summary locking and enable exact in-order processing and demultiplexing.
        ///    For session-unaware entities, this value is ignored.
        ///    See <a href="https://learn.microsoft.com/azure/service-bus-messaging/message-sessions">Message Sessions</a>.
        /// </remarks>
        public string SessionId => AmqpMessage.Properties.GroupId;

        /// <summary>Gets a session identifier augmenting the <see cref="ReplyTo"/> address.</summary>
        /// <value>Session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    This value augments the ReplyTo information and specifies which SessionId should be set
        ///    for the reply when sent to the reply entity. See <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>
        /// </remarks>
        public string ReplyToSessionId => AmqpMessage.Properties.ReplyToGroupId;

        /// <summary>
        /// Gets the message’s "time to live" value.
        /// </summary>
        /// <value>The message’s time to live value.</value>
        /// <remarks>
        ///     This value is the relative duration after which the message expires, starting from the instant
        ///      the message has been accepted and stored by the broker, as captured in <see cref="EnqueuedTime"/>.
        ///      When not set explicitly, the assumed value is the DefaultTimeToLive for the respective queue or topic.
        ///      A message-level <see cref="TimeToLive"/> value cannot be longer than the entity's DefaultTimeToLive
        ///      setting and it is silently adjusted if it does.
        ///      See <a href="https://learn.microsoft.com/azure/service-bus-messaging/message-expiration">Expiration</a>
        /// </remarks>
        public TimeSpan TimeToLive => AmqpMessage.GetTimeToLive();

        /// <summary>Gets the correlation identifier.</summary>
        /// <value>Correlation identifier.</value>
        /// <remarks>
        ///    Allows an application to specify a context for the message for the purposes of correlation,
        ///    for example reflecting the MessageId of a message that is being replied to.
        ///    See <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string CorrelationId => AmqpMessage.Properties.CorrelationId?.ToString();

        /// <summary>Gets an application specific label.</summary>
        /// <value>The application specific label</value>
        /// <remarks>
        ///   This property enables the application to indicate the purpose of the message to the receiver in a standardized
        ///   fashion, similar to an email subject line. The mapped AMQP property is "subject".
        /// </remarks>
        public string Subject => AmqpMessage.Properties.Subject;

        /// <summary>Gets the "to" address.</summary>
        /// <value>The "to" address.</value>
        /// <remarks>
        ///    This property is reserved for future use in routing scenarios and presently ignored by the broker itself.
        ///     Applications can use this value in rule-driven
        ///     <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-auto-forwarding">auto-forward chaining</a> scenarios to indicate the
        ///     intended logical destination of the message.
        /// </remarks>
        public string To => AmqpMessage.Properties.To?.ToString();

        /// <summary>Gets the content type descriptor.</summary>
        /// <value>RFC2045 Content-Type descriptor.</value>
        /// <remarks>
        ///   Optionally describes the payload of the message, with a descriptor following the format of
        ///   RFC2045, Section 5, for example "application/json".
        /// </remarks>
        public string ContentType => AmqpMessage.Properties.ContentType;

        /// <summary>Gets the address of an entity to send replies to.</summary>
        /// <value>The reply entity address.</value>
        /// <remarks>
        ///    This optional and application-defined value is a standard way to express a reply path
        ///    to the receiver of the message. When a sender expects a reply, it sets the value to the
        ///    absolute or relative path of the queue or topic it expects the reply to be sent to.
        ///    See <a href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string ReplyTo => AmqpMessage.Properties.ReplyTo?.ToString();

        /// <summary>
        /// Gets the date and time, in UTC, at which the message should be made available to receivers. This property does not control when a message is sent by the
        /// client. Sending happens immediately when `SendAsync` is called.  Service Bus will hide the message from receivers until the the requested time.
        /// </summary>
        /// <value>
        /// The date and time, in UTC, at which the message should be available to receivers. This time may not be exact; the actual time depends on the entity's workload and state.
        /// </value>
        /// <seealso href="https://learn.microsoft.com/azure/service-bus-messaging/message-sequencing#scheduled-messages">Scheduled messages</seealso>
        public DateTimeOffset ScheduledEnqueueTime => AmqpMessage.GetScheduledEnqueueTime();

        /// <summary>
        /// Gets the application properties bag, which can be used for custom message metadata.
        /// </summary>
        /// <remarks>
        /// Only the following value types are supported:
        /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
        /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
        /// </remarks>
        public IReadOnlyDictionary<string, object> ApplicationProperties => new ReadOnlyDictionary<string, object>(AmqpMessage.ApplicationProperties);

        /// <summary>
        /// Gets the lock token for the current message.
        /// </summary>
        /// <remarks>
        ///   The lock token is a reference to the lock that is being held by the broker in ReceiveMode.PeekLock mode.
        ///   Locks are used to explicitly settle messages as explained in the <a href="https://learn.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement">product documentation in more detail</a>.
        ///   The token can also be used to pin the lock permanently through the <a href="https://learn.microsoft.com/azure/service-bus-messaging/message-deferral">Deferral API</a> and, with that, take the message out of the
        ///   regular delivery state flow. This property is read-only.
        /// </remarks>
        public string LockToken => LockTokenGuid.ToString();

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
                return (int)AmqpMessage.Header.DeliveryCount;
            }
            internal set
            {
                AmqpMessage.Header.DeliveryCount = (uint)value;
            }
        }

        /// <summary>Gets the date and time in UTC until which the message will be locked in the queue/subscription.</summary>
        /// <value>The date and time until which the message will be locked in the queue/subscription.</value>
        /// <remarks>
        /// 	For messages retrieved under a lock (peek-lock receive mode, not pre-settled) this property reflects the UTC
        ///     instant until which the message is held locked in the queue/subscription. When the lock expires, the <see cref="DeliveryCount"/>
        ///     is incremented and the message is again available for retrieval. This property is read-only.
        /// </remarks>
        public DateTimeOffset LockedUntil
        {
            get
            {
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.LockedUntilName,
                    out object val))
                {
                    return (DateTime)val;
                }
                return default;
            }
            internal set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.LockedUntilName] = value.UtcDateTime;
            }
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
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.SequenceNumberName,
                    out object val))
                {
                    return (long)val;
                }
                return default;
            }
            internal set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.SequenceNumberName] = value;
            }
        }

        /// <summary>
        /// Gets the name of the queue or subscription that this message was enqueued on, before it was dead-lettered.
        /// </summary>
        /// <remarks>
        /// 	Only set in messages that have been dead-lettered and subsequently auto-forwarded from the dead-letter queue
        ///     to another entity. Indicates the entity in which the message was dead-lettered. This property is read-only.
        /// </remarks>
        public string DeadLetterSource
        {
            get
            {
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.DeadLetterSourceName,
                    out object val))
                {
                    return (string)val;
                }
                return default;
            }
            internal set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.DeadLetterSourceName] = value;
            }
        }

        internal short PartitionId { get; set; }

        /// <summary>Gets the original sequence number of the message.</summary>
        /// <value>The enqueued sequence number of the message.</value>
        /// <remarks>
        /// For messages that have been auto-forwarded, this property reflects the sequence number
        /// that had first been assigned to the message at its original point of submission. This property is read-only.
        /// </remarks>
        public long EnqueuedSequenceNumber
        {
            get
            {
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.EnqueueSequenceNumberName,
                    out object val))
                {
                    return (long)val;
                }
                return default;
            }
            internal set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.EnqueueSequenceNumberName] = value;
            }
        }

        /// <summary>Gets the date and time of the sent time in UTC.</summary>
        /// <value>The enqueue time in UTC. </value>
        /// <remarks>
        ///    The UTC instant at which the message has been accepted and stored in the entity.
        ///    This value can be used as an authoritative and neutral arrival time indicator when
        ///    the receiver does not want to trust the sender's clock. This property is read-only.
        /// </remarks>
        public DateTimeOffset EnqueuedTime
        {
            get
            {
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.EnqueuedTimeUtcName,
                    out object val))
                {
                    return (DateTime)val;
                }
                return default;
            }
            internal set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.EnqueuedTimeUtcName] = value.UtcDateTime;
            }
        }

        internal Guid LockTokenGuid { get; set; }

        /// <summary>Gets the date and time in UTC at which the message is set to expire.</summary>
        /// <value>The message expiration time in UTC. This property is read-only.</value>
        /// <exception cref="System.InvalidOperationException">If the message has not been received. For example if a new message was created but not yet sent and received.</exception>
        /// <remarks>
        ///  The UTC instant at which the message is marked for removal and no longer available for retrieval
        ///  from the entity due to expiration. Expiry is controlled by the <see cref="ServiceBusMessage.TimeToLive"/> property
        ///  and this property is computed from <see cref="EnqueuedTime"/>+<see cref="ServiceBusMessage.TimeToLive"/></remarks>
        public DateTimeOffset ExpiresAt
        {
            get
            {
                if (AmqpMessage.Properties.AbsoluteExpiryTime != default)
                {
                    return (DateTimeOffset)AmqpMessage.Properties.AbsoluteExpiryTime;
                }
                if (TimeToLive >= DateTimeOffset.MaxValue.Subtract(EnqueuedTime))
                {
                    return DateTimeOffset.MaxValue;
                }
                return EnqueuedTime.Add(TimeToLive);
            }
        }

        /// <summary>
        /// Gets the dead letter reason for the message.
        /// </summary>
        public string DeadLetterReason
        {
            get
            {
                if (ApplicationProperties.TryGetValue(AmqpMessageConstants.DeadLetterReasonHeader, out object reason))
                {
                    return reason as string;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the dead letter error description for the message.
        /// </summary>
        public string DeadLetterErrorDescription
        {
            get
            {
                if (ApplicationProperties.TryGetValue(AmqpMessageConstants.DeadLetterErrorDescriptionHeader, out object description))
                {
                    return description as string;
                }
                return null;
            }
        }

        /// <summary>Gets the state of the message.</summary>
        /// <value>The state of the message. </value>
        /// <remarks>
        ///    The state of the message can be Active, Deferred, or Scheduled. Deferred messages have Deferred state,
        ///    scheduled messages have Scheduled state, all other messages have Active state.
        /// </remarks>
        public ServiceBusMessageState State
        {
            get
            {
                if (AmqpMessage.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.MessageStateName,
                    out object val))
                {
                    return (ServiceBusMessageState)val;
                }

                return ServiceBusMessageState.Active;
            }
        }

        /// <summary>Returns a string that represents the current message.</summary>
        /// <returns>The string representation of the current message.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{MessageId:{0}}}", MessageId);
        }
    }
}
