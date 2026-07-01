// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserves the GA extensible enum used by compatibility shims for online endpoint public network access.
    // A TypeSpec rename cannot restore this member because the public surface is now supplied by SDK-side custom models.
    /// <summary> Whether requests from the public network are allowed. </summary>
    public readonly partial struct MachineLearningPublicNetworkAccessType : IEquatable<MachineLearningPublicNetworkAccessType>
    {
        private readonly string _value;
        /// <summary> Initializes a new instance of <see cref="MachineLearningPublicNetworkAccessType"/>. </summary>
        public MachineLearningPublicNetworkAccessType(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        /// <summary> Gets the Enabled. </summary>
        public static MachineLearningPublicNetworkAccessType Enabled { get; } = new MachineLearningPublicNetworkAccessType("Enabled");
        /// <summary> Gets the Disabled. </summary>
        public static MachineLearningPublicNetworkAccessType Disabled { get; } = new MachineLearningPublicNetworkAccessType("Disabled");
        /// <summary> Converts a <c>string</c> to a <c>MachineLearningPublicNetworkAccessType</c>. </summary>
        public static implicit operator MachineLearningPublicNetworkAccessType(string value) => new MachineLearningPublicNetworkAccessType(value);
        /// <summary> Determines if two <c>MachineLearningPublicNetworkAccessType</c> values are the same. </summary>
        public static bool operator ==(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => left.Equals(right);
        /// <summary> Determines if two <c>MachineLearningPublicNetworkAccessType</c> values are not the same. </summary>
        public static bool operator !=(MachineLearningPublicNetworkAccessType left, MachineLearningPublicNetworkAccessType right) => !left.Equals(right);
        /// <inheritdoc/>
        public bool Equals(MachineLearningPublicNetworkAccessType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is MachineLearningPublicNetworkAccessType other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value is null ? 0 : StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
