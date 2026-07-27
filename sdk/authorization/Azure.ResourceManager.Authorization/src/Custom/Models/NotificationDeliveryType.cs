// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Authorization.Models
{
    // TypeSpec now generates RoleManagementNotificationDeliveryType. Keep this shipped extensible
    // enum as a hidden wrapper so existing binaries and source continue to use the same wire value.
    /// <summary> The type of notification. </summary>
    [Obsolete("Use RoleManagementNotificationDeliveryType instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct NotificationDeliveryType : IEquatable<NotificationDeliveryType>
    {
        private readonly RoleManagementNotificationDeliveryType _value;

        /// <summary> Initializes a new instance of <see cref="NotificationDeliveryType"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NotificationDeliveryType(string value)
        {
            _value = new RoleManagementNotificationDeliveryType(value);
        }

        internal NotificationDeliveryType(RoleManagementNotificationDeliveryType value)
        {
            _value = value;
        }

        internal RoleManagementNotificationDeliveryType Value => _value;

        /// <summary> Email. </summary>
        public static NotificationDeliveryType Email { get; } = new NotificationDeliveryType(RoleManagementNotificationDeliveryType.Email);

        /// <summary> Determines if two <see cref="NotificationDeliveryType"/> values are the same. </summary>
        public static bool operator ==(NotificationDeliveryType left, NotificationDeliveryType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="NotificationDeliveryType"/> values are not the same. </summary>
        public static bool operator !=(NotificationDeliveryType left, NotificationDeliveryType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="NotificationDeliveryType"/>. </summary>
        public static implicit operator NotificationDeliveryType(string value) => new NotificationDeliveryType(value);

        /// <summary> Converts a string to a nullable <see cref="NotificationDeliveryType"/>. </summary>
        public static implicit operator NotificationDeliveryType?(string value) => value == null ? null : new NotificationDeliveryType(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NotificationDeliveryType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(NotificationDeliveryType other) => _value.Equals(other._value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
