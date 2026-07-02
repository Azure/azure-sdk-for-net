// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // The old SDK exposed a string-backed union for breakthrough mode.
    // Keep the removed type so older callers can keep compiling.
    /// <summary> Breakthrough mode. </summary>
    public readonly partial struct BreakthroughMode : IEquatable<BreakthroughMode>
    {
        private readonly string _value;
        private const string DisabledValue = "Disabled";
        private const string EnabledValue = "Enabled";

        /// <summary> Initializes a new instance of <see cref="BreakthroughMode"/>. </summary>
        public BreakthroughMode(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Disabled. </summary>
        public static BreakthroughMode Disabled { get; } = new BreakthroughMode(DisabledValue);

        /// <summary> Enabled. </summary>
        public static BreakthroughMode Enabled { get; } = new BreakthroughMode(EnabledValue);

        /// <summary> Determines if two <see cref="BreakthroughMode"/> values are the same. </summary>
        public static bool operator ==(BreakthroughMode left, BreakthroughMode right) => left.Equals(right);

        /// <summary> Determines if two <see cref="BreakthroughMode"/> values are not the same. </summary>
        public static bool operator !=(BreakthroughMode left, BreakthroughMode right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="BreakthroughMode"/>. </summary>
        public static implicit operator BreakthroughMode(string value) => new BreakthroughMode(value);

        /// <summary> Converts a string to a nullable <see cref="BreakthroughMode"/>. </summary>
        public static implicit operator BreakthroughMode?(string value) => value == null ? null : new BreakthroughMode(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BreakthroughMode other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(BreakthroughMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
