// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the AMQP message ID.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-message-id-ulong"/>.
    /// </summary>
    public readonly struct AmqpMessageId : IEquatable<AmqpMessageId>
    {
        private readonly string _messageIdString;

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageId"/> using the provided
        /// <see cref="string"/>.
        /// </summary>
        ///
        /// <param name="messageId">The message Id.</param>
        public AmqpMessageId(string messageId)
        {
            Argument.AssertNotNull(messageId, nameof(messageId));
            _messageIdString = messageId;
        }

        /// <summary>
        /// Converts the value of this <see cref="AmqpMessageId"/> instance to a <see cref="string"/>.
        /// </summary>
        ///
        /// <returns>A <see cref="string"/> from the value of this instance.</returns>
        public override string ToString() => _messageIdString;

        /// <summary>
        /// Determines whether the provided object is equal to the current object.
        /// </summary>
        ///
        /// <param name="obj">The object to compare with the current object.</param>
        ///
        /// <returns>
        /// <see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is AmqpMessageId messageId)
            {
                return Equals(messageId);
            }
            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Determines whether the provided <see cref="AmqpMessageId"/> is equal to the current <see cref="AmqpMessageId"/>.
        /// </summary>
        ///
        /// <param name="other">The <see cref="AmqpMessageId"/> to compare with the current <see cref="AmqpMessageId"/>.</param>
        ///
        /// <returns>
        /// <see langword="true" /> if the specified <see cref="AmqpMessageId"/> is equal to the current
        /// <see cref="AmqpMessageId"/>; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(AmqpMessageId other) =>
            other.Equals(_messageIdString);

        /// <summary>
        /// Determines whether the provided <see cref="string"/> is equal to the current instance.
        /// </summary>
        ///
        /// <param name="other">The <see cref="string"/> to compare with the
        /// current <see cref="AmqpMessageId"/>.
        /// </param>
        ///
        /// <returns>
        /// <see langword="true" /> if the specified <see cref="string"/> is equal to the current
        /// <see cref="AmqpMessageId"/>; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(string other) =>
            _messageIdString == other;

        /// <summary>Compares two <see cref="AmqpMessageId"/> values for equality.</summary>
        public static bool operator ==(AmqpMessageId left, AmqpMessageId right)
        {
            return left.Equals(right);
        }

        /// <summary>Compares two <see cref="AmqpMessageId"/> values for inequality.</summary>
        public static bool operator !=(AmqpMessageId left, AmqpMessageId right)
        {
            return !(left == right);
        }
    }
}
