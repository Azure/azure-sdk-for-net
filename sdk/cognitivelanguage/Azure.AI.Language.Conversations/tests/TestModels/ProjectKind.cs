// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The type of the project. </summary>
    public readonly partial struct ProjectKind : IEquatable<ProjectKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProjectKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProjectKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ConversationValue = "Conversation";
        private const string OrchestrationValue = "Orchestration";

        /// <summary> Conversation. </summary>
        public static ProjectKind Conversation { get; } = new ProjectKind(ConversationValue);
        /// <summary> Orchestration. </summary>
        public static ProjectKind Orchestration { get; } = new ProjectKind(OrchestrationValue);
        /// <summary> Determines if two <see cref="ProjectKind"/> values are the same. </summary>
        public static bool operator ==(ProjectKind left, ProjectKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProjectKind"/> values are not the same. </summary>
        public static bool operator !=(ProjectKind left, ProjectKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProjectKind"/>. </summary>
        public static implicit operator ProjectKind(string value) => new ProjectKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProjectKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProjectKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
