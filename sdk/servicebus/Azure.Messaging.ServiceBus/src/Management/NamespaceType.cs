// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// Specifies the type of entities the namespace can contain.
    /// </summary>
    internal readonly struct NamespaceType : IEquatable<NamespaceType>
    {
        internal const string MessagingValue = "Messaging";
        internal const string MixedValue = "Mixed";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceType"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public NamespaceType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Namespace contains service bus entities (queues, topics).
        /// </summary>
        public static NamespaceType Messaging { get; } = new NamespaceType(MessagingValue);

        /// <summary>
        /// Supported only for backward compatibility.
        /// Namespace can contain mixture of messaging entities and notification hubs.
        /// </summary>
        public static NamespaceType Mixed { get; } = new NamespaceType(MixedValue);

        /// <summary>
        /// Determines if two <see cref="NamespaceType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="NamespaceType"/> to compare.</param>
        /// <param name="right">The second <see cref="NamespaceType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(NamespaceType left, NamespaceType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="NamespaceType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="NamespaceType"/> to compare.</param>
        /// <param name="right">The second <see cref="NamespaceType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(NamespaceType left, NamespaceType right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="NamespaceType"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator NamespaceType(string value) => new NamespaceType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NamespaceType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(NamespaceType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
