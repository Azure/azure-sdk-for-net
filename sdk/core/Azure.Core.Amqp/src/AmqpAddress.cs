// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents the AMQP address.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-address-string"/>.
    /// </summary>
    public struct AmqpAddress : IEquatable<AmqpAddress>
    {
        private readonly string _address;

        /// <summary>
        /// Initializes a new <see cref="AmqpAddress"/> using the provided
        /// <see cref="string"/>.
        /// </summary>
        ///
        /// <param name="address">The address.</param>
        public AmqpAddress(string address)
        {
            Argument.AssertNotNull(address, nameof(address));
            _address = address;
        }

        /// <summary>
        /// Converts the value of this <see cref="AmqpAddress"/> instance to a <see cref="string"/>.
        /// </summary>
        ///
        /// <returns>A <see cref="string"/> from the value of this instance.</returns>
        public override string ToString() =>
            _address;

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
        public override bool Equals(object obj)
        {
            if (obj is AmqpAddress address)
            {
                return Equals(address);
            }
            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            _address.GetHashCode();

        /// <summary>
        /// Determines whether the provided <see cref="AmqpAddress"/> is equal to the current <see cref="AmqpAddress"/>.
        /// </summary>
        ///
        /// <param name="other">The <see cref="AmqpAddress"/> to compare with the current <see cref="AmqpAddress"/>.</param>
        ///
        /// <returns>
        /// <see langword="true" /> if the specified <see cref="AmqpAddress"/> is equal to the current
        /// <see cref="AmqpAddress"/>; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(AmqpAddress other) =>
            other.Equals(_address);

        /// <summary>
        /// Determines whether the provided <see cref="string"/> is equal to the current instance.
        /// </summary>
        ///
        /// <param name="other">The <see cref="string"/> to compare with the
        /// current <see cref="AmqpAddress"/>.
        /// </param>
        ///
        /// <returns>
        /// <see langword="true" /> if the specified <see cref="string"/> is equal to the current
        /// <see cref="AmqpAddress"/>; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(string other) =>
            _address == other;

        /// <summary>Compares two <see cref="AmqpAddress"/> values for equality.</summary>
        public static bool operator ==(AmqpAddress left, AmqpAddress right)
        {
            return left.Equals(right);
        }

        /// <summary>Compares two <see cref="AmqpAddress"/> values for inequality.</summary>
        public static bool operator !=(AmqpAddress left, AmqpAddress right)
        {
            return !(left == right);
        }
    }
}
