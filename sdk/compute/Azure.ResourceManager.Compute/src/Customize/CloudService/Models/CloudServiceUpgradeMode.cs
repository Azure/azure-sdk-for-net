// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The CloudServiceUpgradeMode. This type is obsolete. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public readonly partial struct CloudServiceUpgradeMode : IEquatable<CloudServiceUpgradeMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CloudServiceUpgradeMode"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CloudServiceUpgradeMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AutoValue = "Auto";
        private const string ManualValue = "Manual";
        private const string SimultaneousValue = "Simultaneous";

        /// <summary> Auto. </summary>
        public static CloudServiceUpgradeMode Auto { get; } = new CloudServiceUpgradeMode(AutoValue);

        /// <summary> Manual. </summary>
        public static CloudServiceUpgradeMode Manual { get; } = new CloudServiceUpgradeMode(ManualValue);

        /// <summary> Simultaneous. </summary>
        public static CloudServiceUpgradeMode Simultaneous { get; } = new CloudServiceUpgradeMode(SimultaneousValue);

        /// <summary> Determines if two <see cref="CloudServiceUpgradeMode"/> values are the same. </summary>
        public static bool operator ==(CloudServiceUpgradeMode left, CloudServiceUpgradeMode right) => left.Equals(right);

        /// <summary> Determines if two <see cref="CloudServiceUpgradeMode"/> values are not the same. </summary>
        public static bool operator !=(CloudServiceUpgradeMode left, CloudServiceUpgradeMode right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="CloudServiceUpgradeMode"/>. </summary>
        public static implicit operator CloudServiceUpgradeMode(string value) => new CloudServiceUpgradeMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CloudServiceUpgradeMode other && Equals(other);

        /// <inheritdoc />
        public bool Equals(CloudServiceUpgradeMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
