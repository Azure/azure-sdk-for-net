// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The algorithm identifier for an Algorithm Key Pair (AKP) key, such as ML-DSA.
    /// This value is required when the <see cref="KeyType"/> is <see cref="KeyType.Akp"/> or <see cref="KeyType.AkpHsm"/>.
    /// </summary>
    public readonly struct AkpAlgorithm : IEquatable<AkpAlgorithm>
    {
        internal const string MLDsa44Value = "ML-DSA-44";
        internal const string MLDsa65Value = "ML-DSA-65";
        internal const string MLDsa87Value = "ML-DSA-87";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AkpAlgorithm"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public AkpAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the ML-DSA-44 algorithm, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MLDsa44 { get; } = new AkpAlgorithm(MLDsa44Value);

        /// <summary>
        /// Gets the ML-DSA-65 algorithm, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MLDsa65 { get; } = new AkpAlgorithm(MLDsa65Value);

        /// <summary>
        /// Gets the ML-DSA-87 algorithm, as defined by FIPS 204.
        /// </summary>
        public static AkpAlgorithm MLDsa87 { get; } = new AkpAlgorithm(MLDsa87Value);

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
