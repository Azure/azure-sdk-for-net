// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA extensible enum used by compatibility shims for private link service connection state.
    // A TypeSpec rename cannot restore this member because the public surface is now supplied by SDK-side custom models.
    public readonly partial struct MachineLearningPrivateEndpointServiceConnectionStatus : IEquatable<MachineLearningPrivateEndpointServiceConnectionStatus>
    {
        private readonly string _value;
        public MachineLearningPrivateEndpointServiceConnectionStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static MachineLearningPrivateEndpointServiceConnectionStatus Approved { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Approved");
        public static MachineLearningPrivateEndpointServiceConnectionStatus Disconnected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Disconnected");
        public static MachineLearningPrivateEndpointServiceConnectionStatus Pending { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Pending");
        public static MachineLearningPrivateEndpointServiceConnectionStatus Rejected { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Rejected");
        public static MachineLearningPrivateEndpointServiceConnectionStatus Timeout { get; } = new MachineLearningPrivateEndpointServiceConnectionStatus("Timeout");
        public static implicit operator MachineLearningPrivateEndpointServiceConnectionStatus(string value) => new MachineLearningPrivateEndpointServiceConnectionStatus(value);
        public static bool operator ==(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => left.Equals(right);
        public static bool operator !=(MachineLearningPrivateEndpointServiceConnectionStatus left, MachineLearningPrivateEndpointServiceConnectionStatus right) => !left.Equals(right);
        public bool Equals(MachineLearningPrivateEndpointServiceConnectionStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is MachineLearningPrivateEndpointServiceConnectionStatus other && Equals(other);
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        public override string ToString() => _value;
    }
}
