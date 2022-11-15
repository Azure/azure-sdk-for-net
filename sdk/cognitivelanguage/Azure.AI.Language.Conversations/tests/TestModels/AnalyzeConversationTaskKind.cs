// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported Conversation tasks. </summary>
    public readonly partial struct AnalyzeConversationTaskKind : IEquatable<AnalyzeConversationTaskKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnalyzeConversationTaskKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnalyzeConversationTaskKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConversationValue = "Conversation";

        /// <summary> Conversation. </summary>
        public static AnalyzeConversationTaskKind Conversation { get; } = new AnalyzeConversationTaskKind(ConversationValue);
        /// <summary> Determines if two <see cref="AnalyzeConversationTaskKind"/> values are the same. </summary>
        public static bool operator ==(AnalyzeConversationTaskKind left, AnalyzeConversationTaskKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnalyzeConversationTaskKind"/> values are not the same. </summary>
        public static bool operator !=(AnalyzeConversationTaskKind left, AnalyzeConversationTaskKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnalyzeConversationTaskKind"/>. </summary>
        public static implicit operator AnalyzeConversationTaskKind(string value) => new AnalyzeConversationTaskKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnalyzeConversationTaskKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnalyzeConversationTaskKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
