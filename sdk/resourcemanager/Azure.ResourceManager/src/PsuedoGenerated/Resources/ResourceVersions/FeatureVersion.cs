// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing Azure resource API versions base.
    /// </summary>
    public readonly partial struct FeatureVersion : IEquatable<FeatureVersion>
    {
        private readonly string _value;

#pragma warning disable CA1707 // Identifiers should not contain underscores
        /// <summary> Version 2015-12-01. </summary>
        public static FeatureVersion V2015_12_01 { get; } = new FeatureVersion("2015-12-01");
        /// <summary> Default version. </summary>
        public static FeatureVersion Default { get; }  = V2015_12_01;
#pragma warning restore CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureVersion"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        private FeatureVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Converts a string to a <see cref="FeatureVersion"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator FeatureVersion(string value) => new FeatureVersion(value);

        /// <inheritdoc/>
        public bool Equals(FeatureVersion other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <summary>
        /// Determines if two <see cref="FeatureVersion"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="FeatureVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="FeatureVersion"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(FeatureVersion left, FeatureVersion right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="FeatureVersion"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="FeatureVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="FeatureVersion"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(FeatureVersion left, FeatureVersion right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FeatureVersion other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
