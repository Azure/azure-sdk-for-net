// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Template.Mocdels
{
    /// <summary> The Enum0. </summary>
    internal readonly partial struct SomeEnum : IEquatable<SomeEnum>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="SomeEnum"/> values are the same. </summary>
        public SomeEnum(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string FullValue = "full";
        private const string SummaryValue = "summary";

        /// <summary> full. </summary>
        public static SomeEnum Full { get; } = new SomeEnum(FullValue);
        /// <summary> summary. </summary>
        public static SomeEnum Summary { get; } = new SomeEnum(SummaryValue);
        /// <summary> Determines if two <see cref="SomeEnum"/> values are the same. </summary>
        public static bool operator ==(SomeEnum left, SomeEnum right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SomeEnum"/> values are not the same. </summary>
        public static bool operator !=(SomeEnum left, SomeEnum right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SomeEnum"/>. </summary>
        public static implicit operator SomeEnum(string value) => new SomeEnum(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SomeEnum other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SomeEnum other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
