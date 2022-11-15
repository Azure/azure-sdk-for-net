// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The extra information object kind. </summary>
    public readonly partial struct ExtraInformationKind : IEquatable<ExtraInformationKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExtraInformationKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExtraInformationKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EntitySubtypeValue = "EntitySubtype";
        private const string ListKeyValue = "ListKey";
        private const string RegexKeyValue = "RegexKey";

        /// <summary> EntitySubtype. </summary>
        public static ExtraInformationKind EntitySubtype { get; } = new ExtraInformationKind(EntitySubtypeValue);
        /// <summary> ListKey. </summary>
        public static ExtraInformationKind ListKey { get; } = new ExtraInformationKind(ListKeyValue);
        /// <summary> RegexKey. </summary>
        public static ExtraInformationKind RegexKey { get; } = new ExtraInformationKind(RegexKeyValue);
        /// <summary> Determines if two <see cref="ExtraInformationKind"/> values are the same. </summary>
        public static bool operator ==(ExtraInformationKind left, ExtraInformationKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ExtraInformationKind"/> values are not the same. </summary>
        public static bool operator !=(ExtraInformationKind left, ExtraInformationKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ExtraInformationKind"/>. </summary>
        public static implicit operator ExtraInformationKind(string value) => new ExtraInformationKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExtraInformationKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExtraInformationKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
