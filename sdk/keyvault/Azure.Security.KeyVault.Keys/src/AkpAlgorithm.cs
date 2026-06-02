// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Algorithm identifier for Algorithm Key Pair (AKP) keys.
    /// </summary>
    public readonly struct AkpAlgorithm : IEquatable<AkpAlgorithm>
    {
        internal const string MlDsa44Value = "ML-DSA-44";
        internal const string MlDsa65Value = "ML-DSA-65";
        internal const string MlDsa87Value = "ML-DSA-87";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AkpAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public AkpAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets ML-DSA-44, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MlDsa44 { get; } = new AkpAlgorithm(MlDsa44Value);

        /// <summary>
        /// Gets ML-DSA-65, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MlDsa65 { get; } = new AkpAlgorithm(MlDsa65Value);

        /// <summary>
        /// Gets ML-DSA-87, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MlDsa87 { get; } = new AkpAlgorithm(MlDsa87Value);

        /// <summary>
        /// Determines if two <see cref="AkpAlgorithm"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="AkpAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="AkpAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(AkpAlgorithm left, AkpAlgorithm right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="AkpAlgorithm"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="AkpAlgorithm"/> to compare.</param>
        /// <param name="right">The second <see cref="AkpAlgorithm"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(AkpAlgorithm left, AkpAlgorithm right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="AkpAlgorithm"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator AkpAlgorithm(string value) => new AkpAlgorithm(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AkpAlgorithm other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(AkpAlgorithm other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
