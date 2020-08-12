// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// The status of the messaging entity.
    /// </summary>
    public readonly struct EntityStatus : IEquatable<EntityStatus>
    {
        internal const string ActiveValue = "Active";
        internal const string DisabledValue = "Disabled";
        internal const string SendDisabledValue = "SendDisabled";
        internal const string ReceiveDisabledValue = "ReceiveDisabled";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStatus"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public EntityStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The status of the messaging entity is active.
        /// </summary>
        public static EntityStatus Active { get; } = new EntityStatus(ActiveValue);

        /// <summary>
        /// The status of the messaging entity is active.
        /// </summary>
        public static EntityStatus Disabled { get; } = new EntityStatus(DisabledValue);

        /// <summary>
        /// The sending status of the messaging entity is disabled.
        /// </summary>
        public static EntityStatus SendDisabled { get; } = new EntityStatus(SendDisabledValue);

        /// <summary>
        /// The receiving status of the messaging entity is disabled.
        /// </summary>
        public static EntityStatus ReceiveDisabled { get; } = new EntityStatus(ReceiveDisabledValue);

        /// <summary>
        /// Determines if two <see cref="EntityStatus"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="EntityStatus"/> to compare.</param>
        /// <param name="right">The second <see cref="EntityStatus"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(EntityStatus left, EntityStatus right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="EntityStatus"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="EntityStatus"/> to compare.</param>
        /// <param name="right">The second <see cref="EntityStatus"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(EntityStatus left, EntityStatus right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="EntityStatus"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator EntityStatus(string value) => new EntityStatus(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EntityStatus other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(EntityStatus other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
