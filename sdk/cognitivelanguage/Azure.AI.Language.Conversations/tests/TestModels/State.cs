// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The status of the task at the mentioned last update time. </summary>
    public readonly partial struct State : IEquatable<State>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="State"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public State(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotStartedValue = "notStarted";
        private const string RunningValue = "running";
        private const string SucceededValue = "succeeded";
        private const string FailedValue = "failed";
        private const string CancelledValue = "cancelled";
        private const string CancellingValue = "cancelling";
        private const string PartiallyCompletedValue = "partiallyCompleted";

        /// <summary> notStarted. </summary>
        public static State NotStarted { get; } = new State(NotStartedValue);
        /// <summary> running. </summary>
        public static State Running { get; } = new State(RunningValue);
        /// <summary> succeeded. </summary>
        public static State Succeeded { get; } = new State(SucceededValue);
        /// <summary> failed. </summary>
        public static State Failed { get; } = new State(FailedValue);
        /// <summary> cancelled. </summary>
        public static State Cancelled { get; } = new State(CancelledValue);
        /// <summary> cancelling. </summary>
        public static State Cancelling { get; } = new State(CancellingValue);
        /// <summary> partiallyCompleted. </summary>
        public static State PartiallyCompleted { get; } = new State(PartiallyCompletedValue);
        /// <summary> Determines if two <see cref="State"/> values are the same. </summary>
        public static bool operator ==(State left, State right) => left.Equals(right);
        /// <summary> Determines if two <see cref="State"/> values are not the same. </summary>
        public static bool operator !=(State left, State right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="State"/>. </summary>
        public static implicit operator State(string value) => new State(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is State other && Equals(other);
        /// <inheritdoc />
        public bool Equals(State other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
