﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Fields to retrieve from a label. </summary>
    public readonly partial struct LabelFields : IEquatable<LabelFields>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="LabelFields"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public LabelFields(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NameValue = "name";

        /// <summary> Name field. </summary>
        public static LabelFields Name { get; } = new LabelFields(NameValue);

        /// <summary> Determines if two <see cref="LabelFields"/> values are the same. </summary>
        public static bool operator ==(LabelFields left, LabelFields right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LabelFields"/> values are not the same. </summary>
        public static bool operator !=(LabelFields left, LabelFields right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LabelFields"/>. </summary>
        public static implicit operator LabelFields(string value) => new LabelFields(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LabelFields other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LabelFields other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
