// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MongoCluster.Models
{
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct MongoClusterPrivateEndpointServiceConnectionStatus : IEquatable<MongoClusterPrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MongoClusterPrivateEndpointServiceConnectionStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MongoClusterPrivateEndpointServiceConnectionStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "Pending";
        private const string ApprovedValue = "Approved";
        private const string RejectedValue = "Rejected";

        /// <summary> Connection waiting for approval or rejection. </summary>
        public static MongoClusterPrivateEndpointServiceConnectionStatus Pending { get; } = new MongoClusterPrivateEndpointServiceConnectionStatus(PendingValue);
        /// <summary> Connection approved. </summary>
        public static MongoClusterPrivateEndpointServiceConnectionStatus Approved { get; } = new MongoClusterPrivateEndpointServiceConnectionStatus(ApprovedValue);
        /// <summary> Connection Rejected. </summary>
        public static MongoClusterPrivateEndpointServiceConnectionStatus Rejected { get; } = new MongoClusterPrivateEndpointServiceConnectionStatus(RejectedValue);
        /// <summary> Determines if two <see cref="MongoClusterPrivateEndpointServiceConnectionStatus"/> values are the same. </summary>
        public static bool operator ==(MongoClusterPrivateEndpointServiceConnectionStatus left, MongoClusterPrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MongoClusterPrivateEndpointServiceConnectionStatus"/> values are not the same. </summary>
        public static bool operator !=(MongoClusterPrivateEndpointServiceConnectionStatus left, MongoClusterPrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MongoClusterPrivateEndpointServiceConnectionStatus"/>. </summary>
        public static implicit operator MongoClusterPrivateEndpointServiceConnectionStatus(string value) => new MongoClusterPrivateEndpointServiceConnectionStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MongoClusterPrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MongoClusterPrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
