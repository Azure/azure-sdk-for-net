// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Whether requests from Public Network are allowed. </summary>
    public readonly partial struct MachineLearningPublicNetworkAccess : IEquatable<MachineLearningPublicNetworkAccess>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MachineLearningPublicNetworkAccess"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MachineLearningPublicNetworkAccess(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnabledValue = "Enabled";
        private const string DisabledValue = "Disabled";

        /// <summary> Enabled. </summary>
        public static MachineLearningPublicNetworkAccess Enabled { get; } = new MachineLearningPublicNetworkAccess(EnabledValue);
        /// <summary> Disabled. </summary>
        public static MachineLearningPublicNetworkAccess Disabled { get; } = new MachineLearningPublicNetworkAccess(DisabledValue);
        /// <summary> Determines if two <see cref="MachineLearningPublicNetworkAccess"/> values are the same. </summary>
        public static bool operator ==(MachineLearningPublicNetworkAccess left, MachineLearningPublicNetworkAccess right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MachineLearningPublicNetworkAccess"/> values are not the same. </summary>
        public static bool operator !=(MachineLearningPublicNetworkAccess left, MachineLearningPublicNetworkAccess right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MachineLearningPublicNetworkAccess"/>. </summary>
        public static implicit operator MachineLearningPublicNetworkAccess(string value) => new MachineLearningPublicNetworkAccess(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MachineLearningPublicNetworkAccess other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MachineLearningPublicNetworkAccess other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
