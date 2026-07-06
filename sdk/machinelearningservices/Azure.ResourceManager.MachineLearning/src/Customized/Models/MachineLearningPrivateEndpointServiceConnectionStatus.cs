// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA extensible enum used by compatibility shims for private link service connection state.
    // A TypeSpec rename cannot restore this member because the public surface is now supplied by SDK-side custom models.
    /// <summary> The private endpoint connection status. </summary>
    public readonly partial struct MachineLearningPrivateEndpointServiceConnectionStatus : IEquatable<MachineLearningPrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpointServiceConnectionStatus"/>. </summary>
        public MachineLearningPrivateEndpointServiceConnectionStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        /// <summary> The private endpoint connection has been approved. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Approved { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Approved");
        /// <summary> The private endpoint connection has been disconnected. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Disconnected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Disconnected");
        /// <summary> The private endpoint connection is pending approval. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Pending { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Pending");
        /// <summary> The private endpoint connection has been rejected. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Rejected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Rejected");
        /// <summary> The private endpoint connection request has timed out. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Timeout { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Timeout");
        /// <summary> Converts a <c>string</c> to a <c>MachineLearningPrivateEndpointServiceConnectionStatus</c>. </summary>
        public static implicit operator MachineLearningPrivateEndpointServiceConnectionStatus(string value) => new MachineLearningPrivateEndpointServiceConnectionStatus(value);
        /// <summary> Determines if two <c>MachineLearningPrivateEndpointServiceConnectionStatus</c> values are the same. </summary>
        public static bool operator ==(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two <c>MachineLearningPrivateEndpointServiceConnectionStatus</c> values are not the same. </summary>
        public static bool operator !=(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <inheritdoc/>
        public bool Equals(MachineLearningPrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is MachineLearningPrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
