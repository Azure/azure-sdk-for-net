// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Polling interval in seconds. </summary>
    public readonly partial struct PollingIntervalInSecond : IEquatable<PollingIntervalInSecond>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="PollingIntervalInSecond"/>. </summary>
        /// <param name="value"> The value. </param>
        public PollingIntervalInSecond(int value)
        {
            _value = value;
        }

        /// <summary> 30. </summary>
        public static PollingIntervalInSecond Thirty { get; } = new PollingIntervalInSecond(30);

        /// <summary> 60. </summary>
        public static PollingIntervalInSecond Sixty { get; } = new PollingIntervalInSecond(60);

        /// <summary> 90. </summary>
        public static PollingIntervalInSecond Ninety { get; } = new PollingIntervalInSecond(90);

        /// <summary> 120. </summary>
        public static PollingIntervalInSecond OneHundredTwenty { get; } = new PollingIntervalInSecond(120);

        /// <summary> Determines if two <see cref="PollingIntervalInSecond"/> values are the same. </summary>
        public static bool operator ==(PollingIntervalInSecond left, PollingIntervalInSecond right) => left.Equals(right);

        /// <summary> Determines if two <see cref="PollingIntervalInSecond"/> values are not the same. </summary>
        public static bool operator !=(PollingIntervalInSecond left, PollingIntervalInSecond right) => !left.Equals(right);

        /// <summary> Converts an integer to a <see cref="PollingIntervalInSecond"/>. </summary>
        public static implicit operator PollingIntervalInSecond(int value) => new PollingIntervalInSecond(value);

        /// <inheritdoc/>
        public bool Equals(PollingIntervalInSecond other) => _value == other._value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PollingIntervalInSecond other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
