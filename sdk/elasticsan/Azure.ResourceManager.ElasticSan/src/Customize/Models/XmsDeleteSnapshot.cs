// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ElasticSan.Models
{
    /// <summary> The XmsDeleteSnapshot. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct XmsDeleteSnapshot : IEquatable<XmsDeleteSnapshot>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="XmsDeleteSnapshot"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public XmsDeleteSnapshot(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TrueValue = "true";
        private const string FalseValue = "false";

        /// <summary> true. </summary>
        public static XmsDeleteSnapshot True { get; } = new XmsDeleteSnapshot(TrueValue);
        /// <summary> false. </summary>
        public static XmsDeleteSnapshot False { get; } = new XmsDeleteSnapshot(FalseValue);
        /// <summary> Determines if two <see cref="XmsDeleteSnapshot"/> values are the same. </summary>
        public static bool operator ==(XmsDeleteSnapshot left, XmsDeleteSnapshot right) => left.Equals(right);
        /// <summary> Determines if two <see cref="XmsDeleteSnapshot"/> values are not the same. </summary>
        public static bool operator !=(XmsDeleteSnapshot left, XmsDeleteSnapshot right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="XmsDeleteSnapshot"/>. </summary>
        public static implicit operator XmsDeleteSnapshot(string value) => new XmsDeleteSnapshot(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is XmsDeleteSnapshot other && Equals(other);
        /// <inheritdoc />
        public bool Equals(XmsDeleteSnapshot other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
