// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA extensible enum used by compatibility shims for online endpoint public network access.
    // A TypeSpec rename cannot restore this member because the public surface is now supplied by SDK-side custom models.
    public readonly partial struct MachineLearningPublicNetworkAccessType : IEquatable<MachineLearningPublicNetworkAccessType>
    {
        private readonly string _value;
        public MachineLearningPublicNetworkAccessType(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static MachineLearningPublicNetworkAccessType Enabled { get; } = new MachineLearningPublicNetworkAccessType("Enabled");
        public static MachineLearningPublicNetworkAccessType Disabled { get; } = new MachineLearningPublicNetworkAccessType("Disabled");
        public static implicit operator MachineLearningPublicNetworkAccessType(string value) => new MachineLearningPublicNetworkAccessType(value);
        public static bool operator ==(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => left.Equals(right);
        public static bool operator !=(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => !left.Equals(right);
        public bool Equals(MachineLearningPublicNetworkAccessType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is MachineLearningPublicNetworkAccessType other && Equals(other);
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        public override string ToString() => _value;
    }
}
