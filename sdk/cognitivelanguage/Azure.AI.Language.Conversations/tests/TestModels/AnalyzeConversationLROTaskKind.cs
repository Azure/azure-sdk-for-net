// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Enumeration of supported analysis tasks on a collection of conversation. </summary>
    public readonly partial struct AnalyzeConversationLROTaskKind : IEquatable<AnalyzeConversationLROTaskKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnalyzeConversationLROTaskKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnalyzeConversationLROTaskKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConversationalPIITaskValue = "ConversationalPIITask";
        private const string ConversationalSummarizationTaskValue = "ConversationalSummarizationTask";
        private const string ConversationalSentimentTaskValue = "ConversationalSentimentTask";

        /// <summary> ConversationalPIITask. </summary>
        public static AnalyzeConversationLROTaskKind ConversationalPIITask { get; } = new AnalyzeConversationLROTaskKind(ConversationalPIITaskValue);
        /// <summary> ConversationalSummarizationTask. </summary>
        public static AnalyzeConversationLROTaskKind ConversationalSummarizationTask { get; } = new AnalyzeConversationLROTaskKind(ConversationalSummarizationTaskValue);
        /// <summary> ConversationalSentimentTask. </summary>
        public static AnalyzeConversationLROTaskKind ConversationalSentimentTask { get; } = new AnalyzeConversationLROTaskKind(ConversationalSentimentTaskValue);
        /// <summary> Determines if two <see cref="AnalyzeConversationLROTaskKind"/> values are the same. </summary>
        public static bool operator ==(AnalyzeConversationLROTaskKind left, AnalyzeConversationLROTaskKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnalyzeConversationLROTaskKind"/> values are not the same. </summary>
        public static bool operator !=(AnalyzeConversationLROTaskKind left, AnalyzeConversationLROTaskKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnalyzeConversationLROTaskKind"/>. </summary>
        public static implicit operator AnalyzeConversationLROTaskKind(string value) => new AnalyzeConversationLROTaskKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnalyzeConversationLROTaskKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnalyzeConversationLROTaskKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
