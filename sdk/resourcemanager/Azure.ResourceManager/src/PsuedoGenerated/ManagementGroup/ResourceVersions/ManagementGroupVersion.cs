// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// A class representing Azure resource API versions base.
    /// </summary>
    public readonly partial struct ManagementGroupVersion : IEquatable<ManagementGroupVersion>
    {
        private readonly string _value;

#pragma warning disable CA1707 // Identifiers should not contain underscores
        /// <summary> Version 2021-04-01. </summary>
        public static ManagementGroupVersion V2021_04_01 { get; } = new ManagementGroupVersion("2021-04-01");
        /// <summary> Default version. </summary>
        public static ManagementGroupVersion Default { get; }  = V2021_04_01;
#pragma warning restore CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementGroupVersion"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        private ManagementGroupVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Converts a string to a <see cref="ManagementGroupVersion"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator ManagementGroupVersion(string value) => new ManagementGroupVersion(value);

        /// <inheritdoc/>
        public bool Equals(ManagementGroupVersion other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <summary>
        /// Determines if two <see cref="ManagementGroupVersion"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="ManagementGroupVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="ManagementGroupVersion"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(ManagementGroupVersion left, ManagementGroupVersion right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="ManagementGroupVersion"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="ManagementGroupVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="ManagementGroupVersion"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(ManagementGroupVersion left, ManagementGroupVersion right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManagementGroupVersion other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    }
}
