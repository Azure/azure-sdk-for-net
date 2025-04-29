// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ElasticSan.Models
{
    /// <summary> The XmsForceDelete. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct XmsForceDelete : IEquatable<XmsForceDelete>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="XmsForceDelete"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public XmsForceDelete(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TrueValue = "true";
        private const string FalseValue = "false";

        /// <summary> true. </summary>
        public static XmsForceDelete True { get; } = new XmsForceDelete(TrueValue);
        /// <summary> false. </summary>
        public static XmsForceDelete False { get; } = new XmsForceDelete(FalseValue);
        /// <summary> Determines if two <see cref="XmsForceDelete"/> values are the same. </summary>
        public static bool operator ==(XmsForceDelete left, XmsForceDelete right) => left.Equals(right);
        /// <summary> Determines if two <see cref="XmsForceDelete"/> values are not the same. </summary>
        public static bool operator !=(XmsForceDelete left, XmsForceDelete right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="XmsForceDelete"/>. </summary>
        public static implicit operator XmsForceDelete(string value) => new XmsForceDelete(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is XmsForceDelete other && Equals(other);
        /// <inheritdoc />
        public bool Equals(XmsForceDelete other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
