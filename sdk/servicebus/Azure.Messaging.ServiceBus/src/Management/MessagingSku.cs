// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Specifies the SKU/tier of the messaging namespace.
    /// </summary>
    public readonly struct MessagingSku : IEquatable<MessagingSku>
    {
        internal const string BasicValue = "Basic";
        internal const string StandardValue = "Standard";
        internal const string PremiumValue = "Premium";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingSku"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public MessagingSku(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///  Basic namespace. Shared Resource. Only queues are available.
        /// </summary>
        public static MessagingSku Basic { get; } = new MessagingSku(BasicValue);

        /// <summary>
        /// Standard namespace. Shared Resource. Queues and topics.
        /// </summary>
        public static MessagingSku Standard { get; } = new MessagingSku(StandardValue);

        /// <summary>
        /// Premium namespace. Dedicated Resource. Queues and topics.
        /// </summary>
        public static MessagingSku Premium { get; } = new MessagingSku(PremiumValue);

        /// <summary>
        /// Determines if two <see cref="MessagingSku"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="MessagingSku"/> to compare.</param>
        /// <param name="right">The second <see cref="MessagingSku"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(MessagingSku left, MessagingSku right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="MessagingSku"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="MessagingSku"/> to compare.</param>
        /// <param name="right">The second <see cref="MessagingSku"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(MessagingSku left, MessagingSku right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="MessagingSku"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator MessagingSku(string value) => new MessagingSku(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MessagingSku other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(MessagingSku other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
