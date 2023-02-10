// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported conversational modalities. </summary>
    public readonly partial struct InputModality : IEquatable<InputModality>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="InputModality"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public InputModality(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TranscriptValue = "transcript";
        private const string TextValue = "text";

        /// <summary> transcript. </summary>
        public static InputModality Transcript { get; } = new InputModality(TranscriptValue);
        /// <summary> text. </summary>
        public static InputModality Text { get; } = new InputModality(TextValue);
        /// <summary> Determines if two <see cref="InputModality"/> values are the same. </summary>
        public static bool operator ==(InputModality left, InputModality right) => left.Equals(right);
        /// <summary> Determines if two <see cref="InputModality"/> values are not the same. </summary>
        public static bool operator !=(InputModality left, InputModality right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="InputModality"/>. </summary>
        public static implicit operator InputModality(string value) => new InputModality(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InputModality other && Equals(other);
        /// <inheritdoc />
        public bool Equals(InputModality other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
