// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceBusReceivedMessage : ServiceBusMessage
    {
        private Guid _lockTokenGuid;

        /// <summary>
        /// User property key representing deadletter reason, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        public static string DeadLetterReasonHeader = "DeadLetterReason";

        /// <summary>
        /// User property key representing detailed error description, when a message is received from a deadletter subqueue of an entity.
        /// </summary>
        public static string DeadLetterErrorDescriptionHeader = "DeadLetterErrorDescription";

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes</param>
        internal ServiceBusReceivedMessage(ReadOnlyMemory<byte> body) :
            base(body)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ServiceBusReceivedMessage Create(ReadOnlyMemory<byte> body) =>
            new ServiceBusReceivedMessage(body);

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        public ServiceBusReceivedMessage() :
            base()
        {
        }

        /// <summary>
        /// Specifies whether or not there is a lock token set on the current message.
        /// </summary>
        /// <remarks>A lock token will only be specified if the message was received using ReceiveMode.PeekLock</remarks>
        public bool IsLockTokenSet => _lockTokenGuid != default;

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
        public DateTime LockedUntilUtc { get; internal set; }

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
        public DateTime EnqueuedTimeUtc { get; internal set; }

        internal Guid LockTokenGuid
        {
            get
            {
                //this.ThrowIfNotReceived();
                return _lockTokenGuid;
            }

            set => _lockTokenGuid = value;
        }

        internal object BodyObject
        {
            get;
            set;
        }
        /// <summary>Gets the date and time in UTC at which the message is set to expire.</summary>
        /// <value>The message expiration time in UTC. This property is read-only.</value>
        /// <exception cref="System.InvalidOperationException">If the message has not been received. For example if a new message was created but not yet sent and received.</exception>
        /// <remarks>
        ///  The UTC instant at which the message is marked for removal and no longer available for retrieval
        ///  from the entity due to expiration. Expiry is controlled by the <see cref="ServiceBusMessage.TimeToLive"/> property
        ///  and this property is computed from <see cref="EnqueuedTimeUtc"/>+<see cref="ServiceBusMessage.TimeToLive"/></remarks>
        public DateTime ExpiresAtUtc
        {
            get
            {
                if (TimeToLive >= DateTime.MaxValue.Subtract(EnqueuedTimeUtc))
                {
                    return DateTime.MaxValue;
                }

                return EnqueuedTimeUtc.Add(TimeToLive);
            }
        }
    }
}
