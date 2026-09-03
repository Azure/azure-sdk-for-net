// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    // The C# TypeSpec customization renamed this type to StickySessionAffinity. Preserve the shipped management type for compatibility.
    /// <summary> Sticky Session Affinity. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future version. Use StickySessionAffinity instead.", false)]
    public readonly partial struct Affinity : IEquatable<Affinity>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Affinity"/>. </summary>
        /// <param name="value"> The value. </param>
        public Affinity(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> sticky. </summary>
        public static Affinity Sticky { get; } = new Affinity("sticky");

        /// <summary> none. </summary>
        public static Affinity None { get; } = new Affinity("none");

        /// <summary> Determines if two <see cref="Affinity"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(Affinity left, Affinity right) => left.Equals(right);

        /// <summary> Determines if two <see cref="Affinity"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(Affinity left, Affinity right) => !left.Equals(right);

        /// <summary> Converts a string to an <see cref="Affinity"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator Affinity(string value) => new Affinity(value);

        /// <summary> Converts a string to a nullable <see cref="Affinity"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator Affinity?(string value) => value == null ? null : new Affinity(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Affinity other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Affinity other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
