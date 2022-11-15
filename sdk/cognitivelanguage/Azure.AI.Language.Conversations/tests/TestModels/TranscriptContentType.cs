// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported transcript content types. </summary>
    public readonly partial struct TranscriptContentType : IEquatable<TranscriptContentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TranscriptContentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TranscriptContentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LexicalValue = "lexical";
        private const string ItnValue = "itn";
        private const string MaskedItnValue = "maskedItn";
        private const string TextValue = "text";

        /// <summary> lexical. </summary>
        public static TranscriptContentType Lexical { get; } = new TranscriptContentType(LexicalValue);
        /// <summary> itn. </summary>
        public static TranscriptContentType Itn { get; } = new TranscriptContentType(ItnValue);
        /// <summary> maskedItn. </summary>
        public static TranscriptContentType MaskedItn { get; } = new TranscriptContentType(MaskedItnValue);
        /// <summary> text. </summary>
        public static TranscriptContentType Text { get; } = new TranscriptContentType(TextValue);
        /// <summary> Determines if two <see cref="TranscriptContentType"/> values are the same. </summary>
        public static bool operator ==(TranscriptContentType left, TranscriptContentType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TranscriptContentType"/> values are not the same. </summary>
        public static bool operator !=(TranscriptContentType left, TranscriptContentType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TranscriptContentType"/>. </summary>
        public static implicit operator TranscriptContentType(string value) => new TranscriptContentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TranscriptContentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TranscriptContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
