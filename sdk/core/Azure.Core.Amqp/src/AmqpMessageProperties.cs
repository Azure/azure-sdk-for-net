// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the AMQP message properties.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-properties" />
    /// </summary>
    public class AmqpMessageProperties
    {
        /// <summary>
        /// Initializes a new <see cref="AmqpMessageProperties"/> instance.
        /// </summary>
        internal AmqpMessageProperties() { }

        /// <summary>
        /// The message-id value from the AMQP properties.
        /// </summary>
        public AmqpMessageId? MessageId { get; set; }

        /// <summary>
        /// The user-id value from the AMQP properties.
        /// </summary>
        public ReadOnlyMemory<byte>? UserId { get; set; }

        /// <summary>
        /// The to value from the AMQP properties.
        /// </summary>
        public AmqpAddress? To { get; set; }

        /// <summary>
        /// The subject value from the AMQP properties.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// The reply-to value from the AMQP properties.
        /// </summary>
        public AmqpAddress? ReplyTo { get; set; }

        /// <summary>
        /// The correlation-id value from the AMQP properties.
        /// </summary>
        public AmqpMessageId? CorrelationId { get; set; }

        /// <summary>
        /// The content-type value from the AMQP properties.
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// The content-encoding value from the AMQP properties.
        /// </summary>
        public string? ContentEncoding { get; set; }

        /// <summary>
        /// The absolute-expiry-time value from the AMQP properties.
        /// </summary>
        public DateTimeOffset? AbsoluteExpiryTime { get; set; }

        /// <summary>
        /// The creation-time value from the AMQP properties.
        /// </summary>
        public DateTimeOffset? CreationTime { get; set; }

        /// <summary>
        /// The group-id value from the AMQP properties.
        /// </summary>
        public string? GroupId { get; set; }

        /// <summary>
        /// The group-sequence value from the AMQP properties.
        /// </summary>
        public uint? GroupSequence { get; set; }

        /// <summary>
        /// The reply-to-group-id value from the AMQP properties.
        /// </summary>
        public string? ReplyToGroupId { get; set; }
    }
}
