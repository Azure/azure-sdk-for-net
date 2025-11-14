// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The private link service connection status. </summary>
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateStatus : IEquatable<MySqlPrivateLinkServiceConnectionStateStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlPrivateLinkServiceConnectionStateStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlPrivateLinkServiceConnectionStateStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ApprovedValue = "Approved";
        private const string PendingValue = "Pending";
        private const string RejectedValue = "Rejected";
        private const string DisconnectedValue = "Disconnected";

        /// <summary> Approved. </summary>
        public static MySqlPrivateLinkServiceConnectionStateStatus Approved { get; } = new MySqlPrivateLinkServiceConnectionStateStatus(ApprovedValue);
        /// <summary> Pending. </summary>
        public static MySqlPrivateLinkServiceConnectionStateStatus Pending { get; } = new MySqlPrivateLinkServiceConnectionStateStatus(PendingValue);
        /// <summary> Rejected. </summary>
        public static MySqlPrivateLinkServiceConnectionStateStatus Rejected { get; } = new MySqlPrivateLinkServiceConnectionStateStatus(RejectedValue);
        /// <summary> Disconnected. </summary>
        public static MySqlPrivateLinkServiceConnectionStateStatus Disconnected { get; } = new MySqlPrivateLinkServiceConnectionStateStatus(DisconnectedValue);
        /// <summary> Determines if two <see cref="MySqlPrivateLinkServiceConnectionStateStatus"/> values are the same. </summary>
        public static bool operator ==(MySqlPrivateLinkServiceConnectionStateStatus left, MySqlPrivateLinkServiceConnectionStateStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlPrivateLinkServiceConnectionStateStatus"/> values are not the same. </summary>
        public static bool operator !=(MySqlPrivateLinkServiceConnectionStateStatus left, MySqlPrivateLinkServiceConnectionStateStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlPrivateLinkServiceConnectionStateStatus"/>. </summary>
        public static implicit operator MySqlPrivateLinkServiceConnectionStateStatus(string value) => new MySqlPrivateLinkServiceConnectionStateStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlPrivateLinkServiceConnectionStateStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlPrivateLinkServiceConnectionStateStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}