// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The type of a target service. </summary>
    public readonly partial struct TargetProjectKind : IEquatable<TargetProjectKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="TargetProjectKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public TargetProjectKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string LuisValue = "Luis";
        private const string ConversationValue = "Conversation";
        private const string QuestionAnsweringValue = "QuestionAnswering";
        private const string NonLinkedValue = "NonLinked";

        /// <summary> Luis. </summary>
        public static TargetProjectKind Luis { get; } = new TargetProjectKind(LuisValue);
        /// <summary> Conversation. </summary>
        public static TargetProjectKind Conversation { get; } = new TargetProjectKind(ConversationValue);
        /// <summary> QuestionAnswering. </summary>
        public static TargetProjectKind QuestionAnswering { get; } = new TargetProjectKind(QuestionAnsweringValue);
        /// <summary> NonLinked. </summary>
        public static TargetProjectKind NonLinked { get; } = new TargetProjectKind(NonLinkedValue);
        /// <summary> Determines if two <see cref="TargetProjectKind"/> values are the same. </summary>
        public static bool operator ==(TargetProjectKind left, TargetProjectKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TargetProjectKind"/> values are not the same. </summary>
        public static bool operator !=(TargetProjectKind left, TargetProjectKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TargetProjectKind"/>. </summary>
        public static implicit operator TargetProjectKind(string value) => new TargetProjectKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TargetProjectKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TargetProjectKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
