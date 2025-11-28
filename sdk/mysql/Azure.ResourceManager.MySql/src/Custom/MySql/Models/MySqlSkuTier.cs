// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The tier of the particular SKU, e.g. Basic. </summary>
    public readonly partial struct MySqlSkuTier : IEquatable<MySqlSkuTier>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlSkuTier"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlSkuTier(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BasicValue = "Basic";
        private const string GeneralPurposeValue = "GeneralPurpose";
        private const string MemoryOptimizedValue = "MemoryOptimized";

        /// <summary> Basic. </summary>
        public static MySqlSkuTier Basic { get; } = new MySqlSkuTier(BasicValue);
        /// <summary> GeneralPurpose. </summary>
        public static MySqlSkuTier GeneralPurpose { get; } = new MySqlSkuTier(GeneralPurposeValue);
        /// <summary> MemoryOptimized. </summary>
        public static MySqlSkuTier MemoryOptimized { get; } = new MySqlSkuTier(MemoryOptimizedValue);
        /// <summary> Determines if two <see cref="MySqlSkuTier"/> values are the same. </summary>
        public static bool operator ==(MySqlSkuTier left, MySqlSkuTier right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlSkuTier"/> values are not the same. </summary>
        public static bool operator !=(MySqlSkuTier left, MySqlSkuTier right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlSkuTier"/>. </summary>
        public static implicit operator MySqlSkuTier(string value) => new MySqlSkuTier(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlSkuTier other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlSkuTier other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}