// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Connection status of the service consumer with the service provider. </summary>
    public readonly partial struct MachineLearningPrivateEndpointServiceConnectionStatus : IEquatable<MachineLearningPrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpointServiceConnectionStatus"/>. </summary>
        /// <param name="value"> The value. </param>
        public MachineLearningPrivateEndpointServiceConnectionStatus(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Gets the Approved. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Approved { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Approved");
        /// <summary> Gets the Pending. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Pending { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Pending");
        /// <summary> Gets the Rejected. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Rejected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Rejected");
        /// <summary> Gets the Disconnected. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Disconnected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Disconnected");
        /// <summary> Gets the Timeout. </summary>
        public static MachineLearningPrivateEndpointServiceConnectionStatus Timeout { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Timeout");

        /// <summary> Determines if two values are the same. </summary>
        public static bool operator ==(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        /// <summary> Determines if two values are not the same. </summary>
        public static bool operator !=(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a status. </summary>
        public static implicit operator MachineLearningPrivateEndpointServiceConnectionStatus(string value) => new MachineLearningPrivateEndpointServiceConnectionStatus(value);
        /// <summary> Converts a string to a status. </summary>
        public static implicit operator MachineLearningPrivateEndpointServiceConnectionStatus?(string value) => value == null ? null : new MachineLearningPrivateEndpointServiceConnectionStatus(value);
        /// <summary> Converts the legacy status to the generated status. </summary>
        public static implicit operator EndpointServiceConnectionStatus(MachineLearningPrivateEndpointServiceConnectionStatus value) => new EndpointServiceConnectionStatus(value.ToString());
        /// <summary> Converts the generated status to the legacy status. </summary>
        public static implicit operator MachineLearningPrivateEndpointServiceConnectionStatus(EndpointServiceConnectionStatus value) => new MachineLearningPrivateEndpointServiceConnectionStatus(value.ToString());

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MachineLearningPrivateEndpointServiceConnectionStatus other && Equals(other);
        /// <inheritdoc/>
        public bool Equals(MachineLearningPrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
