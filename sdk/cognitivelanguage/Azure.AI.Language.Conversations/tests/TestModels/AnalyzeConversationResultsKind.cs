// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported Conversation Analysis task results. </summary>
    public readonly partial struct AnalyzeConversationResultsKind : IEquatable<AnalyzeConversationResultsKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnalyzeConversationResultsKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnalyzeConversationResultsKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConversationalPIIResultsValue = "conversationalPIIResults";
        private const string ConversationalSummarizationResultsValue = "conversationalSummarizationResults";
        private const string ConversationalSentimentResultsValue = "conversationalSentimentResults";

        /// <summary> conversationalPIIResults. </summary>
        public static AnalyzeConversationResultsKind ConversationalPIIResults { get; } = new AnalyzeConversationResultsKind(ConversationalPIIResultsValue);
        /// <summary> conversationalSummarizationResults. </summary>
        public static AnalyzeConversationResultsKind ConversationalSummarizationResults { get; } = new AnalyzeConversationResultsKind(ConversationalSummarizationResultsValue);
        /// <summary> conversationalSentimentResults. </summary>
        public static AnalyzeConversationResultsKind ConversationalSentimentResults { get; } = new AnalyzeConversationResultsKind(ConversationalSentimentResultsValue);
        /// <summary> Determines if two <see cref="AnalyzeConversationResultsKind"/> values are the same. </summary>
        public static bool operator ==(AnalyzeConversationResultsKind left, AnalyzeConversationResultsKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnalyzeConversationResultsKind"/> values are not the same. </summary>
        public static bool operator !=(AnalyzeConversationResultsKind left, AnalyzeConversationResultsKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnalyzeConversationResultsKind"/>. </summary>
        public static implicit operator AnalyzeConversationResultsKind(string value) => new AnalyzeConversationResultsKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnalyzeConversationResultsKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnalyzeConversationResultsKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
