// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Predicted sentiment. </summary>
    public readonly partial struct TextSentiment : IEquatable<TextSentiment>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TextSentiment"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TextSentiment(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PositiveValue = "positive";
        private const string NeutralValue = "neutral";
        private const string NegativeValue = "negative";
        private const string MixedValue = "mixed";

        /// <summary> Positive sentiment. </summary>
        public static TextSentiment Positive { get; } = new TextSentiment(PositiveValue);
        /// <summary> Neutral sentiment. </summary>
        public static TextSentiment Neutral { get; } = new TextSentiment(NeutralValue);
        /// <summary> Negative sentiment. </summary>
        public static TextSentiment Negative { get; } = new TextSentiment(NegativeValue);
        /// <summary> Mixed sentiment. </summary>
        public static TextSentiment Mixed { get; } = new TextSentiment(MixedValue);
        /// <summary> Determines if two <see cref="TextSentiment"/> values are the same. </summary>
        public static bool operator ==(TextSentiment left, TextSentiment right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TextSentiment"/> values are not the same. </summary>
        public static bool operator !=(TextSentiment left, TextSentiment right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TextSentiment"/>. </summary>
        public static implicit operator TextSentiment(string value) => new TextSentiment(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextSentiment other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TextSentiment other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
