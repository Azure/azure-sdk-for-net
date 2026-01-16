// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    /// <summary> Body parameter's content type. </summary>
    public readonly partial struct ImportContentType : IEquatable<ImportContentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ImportContentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ImportContentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ApplicationJsonValue = "application/json";

        /// <summary> application/json. </summary>
        public static ImportContentType ApplicationJson { get; } = new ImportContentType(ApplicationJsonValue);

        /// <summary> Determines if two <see cref="ImportContentType"/> values are the same. </summary>
        public static bool operator ==(ImportContentType left, ImportContentType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ImportContentType"/> values are not the same. </summary>
        public static bool operator !=(ImportContentType left, ImportContentType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="ImportContentType"/>. </summary>
        public static implicit operator ImportContentType(string value) => new ImportContentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImportContentType other && Equals(other);

        /// <inheritdoc />
        public bool Equals(ImportContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
