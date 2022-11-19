// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported conversational task results. </summary>
    public readonly partial struct AnalyzeConversationTaskResultsKind : IEquatable<AnalyzeConversationTaskResultsKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnalyzeConversationTaskResultsKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnalyzeConversationTaskResultsKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConversationResultValue = "ConversationResult";

        /// <summary> ConversationResult. </summary>
        public static AnalyzeConversationTaskResultsKind ConversationResult { get; } = new AnalyzeConversationTaskResultsKind(ConversationResultValue);
        /// <summary> Determines if two <see cref="AnalyzeConversationTaskResultsKind"/> values are the same. </summary>
        public static bool operator ==(AnalyzeConversationTaskResultsKind left, AnalyzeConversationTaskResultsKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnalyzeConversationTaskResultsKind"/> values are not the same. </summary>
        public static bool operator !=(AnalyzeConversationTaskResultsKind left, AnalyzeConversationTaskResultsKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnalyzeConversationTaskResultsKind"/>. </summary>
        public static implicit operator AnalyzeConversationTaskResultsKind(string value) => new AnalyzeConversationTaskResultsKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnalyzeConversationTaskResultsKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnalyzeConversationTaskResultsKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
