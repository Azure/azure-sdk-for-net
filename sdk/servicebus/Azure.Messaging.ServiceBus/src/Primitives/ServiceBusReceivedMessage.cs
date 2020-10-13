// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceBusReceivedMessage
    {
        /// <summary>
        /// Indicates whether the user has settled the message as part of their callback.
        /// If they have done so, we will not autocomplete.
        /// </summary>
        internal bool IsSettled { get; set; }

        internal ServiceBusMessage SentMessage { get; set; } = new ServiceBusMessage();

        /// <summary>
        /// Gets the body of the message.
        /// </summary>
        public BinaryData Body => SentMessage.Body;

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
        public string MessageId => SentMessage.MessageId;

        /// <summary>Gets a partition key for sending a message to a partitioned entity.</summary>
        /// <value>The partition key. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-partitioning">partitioned entities</a>,
        ///    setting this value enables assigning related messages to the same internal partition, so that submission sequence
        ///    order is correctly recorded. The partition is chosen by a hash function over this value and cannot be chosen
        ///    directly. For session-aware entities, the <see cref="SessionId"/> property overrides this value.
        /// </remarks>
        public string PartitionKey => SentMessage.PartitionKey;

        /// <summary>Gets a partition key for sending a message into an entity via a partitioned transfer queue.</summary>
        /// <value>The partition key. Maximum length is 128 characters. </value>
        /// <remarks>
        ///    If a message is sent via a transfer queue in the scope of a transaction, this value selects the
        ///    transfer queue partition: This is functionally equivalent to <see cref="PartitionKey"/> and ensures that
        ///    messages are kept together and in order as they are transferred.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-transactions#transfers-and-send-via">Transfers and Send Via</a>.
        /// </remarks>
        public string ViaPartitionKey => SentMessage.ViaPartitionKey;

        /// <summary>Gets the session identifier for a session-aware entity.</summary>
        /// <value>The session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    For session-aware entities, this application-defined value specifies the session
        ///    affiliation of the message. Messages with the same session identifier are subject
        ///    to summary locking and enable exact in-order processing and demultiplexing.
        ///    For session-unaware entities, this value is ignored.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-sessions">Message Sessions</a>.
        /// </remarks>
        public string SessionId => SentMessage.SessionId;

        /// <summary>Gets a session identifier augmenting the <see cref="ReplyTo"/> address.</summary>
        /// <value>Session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        ///    This value augments the ReplyTo information and specifies which SessionId should be set
        ///    for the reply when sent to the reply entity. See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>
        /// </remarks>
        public string ReplyToSessionId => SentMessage.ReplyToSessionId;

        /// <summary>
        /// Gets the message’s "time to live" value.
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
        public TimeSpan TimeToLive => SentMessage.TimeToLive;

        /// <summary>Gets the a correlation identifier.</summary>
        /// <value>Correlation identifier.</value>
        /// <remarks>
        ///    Allows an application to specify a context for the message for the purposes of correlation,
        ///    for example reflecting the MessageId of a message that is being replied to.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string CorrelationId => SentMessage.CorrelationId;

        /// <summary>Gets an application specific label.</summary>
        /// <value>The application specific label</value>
        /// <remarks>
        ///   This property enables the application to indicate the purpose of the message to the receiver in a standardized
        ///   fashion, similar to an email subject line. The mapped AMQP property is "subject".
        /// </remarks>
        public string Label => SentMessage.Label;

        /// <summary>Gets the "to" address.</summary>
        /// <value>The "to" address.</value>
        /// <remarks>
        ///    This property is reserved for future use in routing scenarios and presently ignored by the broker itself.
        ///     Applications can use this value in rule-driven
        ///     <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-auto-forwarding">auto-forward chaining</a> scenarios to indicate the
        ///     intended logical destination of the message.
        /// </remarks>
        public string To => SentMessage.To;

        /// <summary>Gets the content type descriptor.</summary>
        /// <value>RFC2045 Content-Type descriptor.</value>
        /// <remarks>
        ///   Optionally describes the payload of the message, with a descriptor following the format of
        ///   RFC2045, Section 5, for example "application/json".
        /// </remarks>
        public string ContentType => SentMessage.ContentType;

        /// <summary>Gets the address of an entity to send replies to.</summary>
        /// <value>The reply entity address.</value>
        /// <remarks>
        ///    This optional and application-defined value is a standard way to express a reply path
        ///    to the receiver of the message. When a sender expects a reply, it sets the value to the
        ///    absolute or relative path of the queue or topic it expects the reply to be sent to.
        ///    See <a href="https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</a>.
        /// </remarks>
        public string ReplyTo => SentMessage.ReplyTo;

        /// <summary>Gets the date and time in UTC at which the message will be enqueued. This
        /// property returns the time in UTC; when setting the property, the supplied DateTime value must also be in UTC.</summary>
        /// <value>The scheduled enqueue time in UTC. This value is for delayed message sending.
        /// It is utilized to delay messages sending to a specific time in the future.</value>
        /// <remarks> Message enqueuing time does not mean that the message will be sent at the same time. It will get enqueued, but the actual sending time
        /// depends on the queue's workload and its state.</remarks>
        public DateTimeOffset ScheduledEnqueueTime => SentMessage.ScheduledEnqueueTime;

        /// <summary>
        /// Gets the "user properties" bag, which can be used for custom message metadata.
        /// </summary>
        /// <remarks>
        /// Only following value types are supported:
        /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
        /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
        /// </remarks>
        public IReadOnlyDictionary<string, object> Properties => new ReadOnlyDictionary<string, object> (SentMessage.Properties);

        /// <summary>
        /// User property key representing deadletter reason, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        internal const string DeadLetterReasonHeader = "DeadLetterReason";

        /// <summary>
        /// User property key representing detailed error description, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        internal const string DeadLetterErrorDescriptionHeader = "DeadLetterErrorDescription";

        /// <summary>
        /// Gets the lock token for the current message.
        /// </summary>
        /// <remarks>
        ///   The lock token is a reference to the lock that is being held by the broker in ReceiveMode.PeekLock mode.
        ///   Locks are used to explicitly settle messages as explained in the <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-transfers-locks-settlement">product documentation in more detail</a>.
        ///   The token can also be used to pin the lock permanently through the <a href="https://docs.microsoft.com/azure/service-bus-messaging/message-deferral">Deferral API</a> and, with that, take the message out of the
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
        public int DeliveryCount { get; internal set; }

        /// <summary>Gets the date and time in UTC until which the message will be locked in the queue/subscription.</summary>
        /// <value>The date and time until which the message will be locked in the queue/subscription.</value>
        /// <remarks>
        /// 	For messages retrieved under a lock (peek-lock receive mode, not pre-settled) this property reflects the UTC
        ///     instant until which the message is held locked in the queue/subscription. When the lock expires, the <see cref="DeliveryCount"/>
        ///     is incremented and the message is again available for retrieval. This property is read-only.
        /// </remarks>
        public DateTimeOffset LockedUntil { get; internal set; }

        /// <summary>Gets the unique number assigned to a message by Service Bus.</summary>
        /// <remarks>
        ///     The sequence number is a unique 64-bit integer assigned to a message as it is accepted
        ///     and stored by the broker and functions as its true identifier. For partitioned entities,
        ///     the topmost 16 bits reflect the partition identifier. Sequence numbers monotonically increase.
        ///     They roll over to 0 when the 48-64 bit range is exhausted. This property is read-only.
        /// </remarks>
        public long SequenceNumber { get; internal set; } = -1;

        /// <summary>
        /// Gets the name of the queue or subscription that this message was enqueued on, before it was deadlettered.
        /// </summary>
        /// <remarks>
        /// 	Only set in messages that have been dead-lettered and subsequently auto-forwarded from the dead-letter queue
        ///     to another entity. Indicates the entity in which the message was dead-lettered. This property is read-only.
        /// </remarks>
        public string DeadLetterSource { get; internal set; }

        internal short PartitionId { get; set; }

        /// <summary>Gets or sets the original sequence number of the message.</summary>
        /// <value>The enqueued sequence number of the message.</value>
        /// <remarks>
        /// For messages that have been auto-forwarded, this property reflects the sequence number
        /// that had first been assigned to the message at its original point of submission. This property is read-only.
        /// </remarks>
        public long EnqueuedSequenceNumber { get; internal set; }

        /// <summary>Gets or sets the date and time of the sent time in UTC.</summary>
        /// <value>The enqueue time in UTC. </value>
        /// <remarks>
        ///    The UTC instant at which the message has been accepted and stored in the entity.
        ///    This value can be used as an authoritative and neutral arrival time indicator when
        ///    the receiver does not want to trust the sender's clock. This property is read-only.
        /// </remarks>
        public DateTimeOffset EnqueuedTime { get; internal set; }

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
                if (TimeToLive >= DateTimeOffset.MaxValue.Subtract(EnqueuedTime))
                {
                    return DateTimeOffset.MaxValue;
                }

                return EnqueuedTime.Add(TimeToLive);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string DeadLetterReason
        {
            get
            {
                if (Properties.TryGetValue(DeadLetterReasonHeader, out object reason))
                {
                    return reason as string;
                }
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public string DeadLetterErrorDescription
        {
            get
            {
                if (Properties.TryGetValue(DeadLetterErrorDescriptionHeader, out object description))
                {
                    return description as string;
                }
                return null;
            }
        }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes</param>
        internal ServiceBusReceivedMessage(ReadOnlyMemory<byte> body)
        {
            SentMessage = new ServiceBusMessage(body);
        }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        internal ServiceBusReceivedMessage()
        {
        }

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
    }
}
