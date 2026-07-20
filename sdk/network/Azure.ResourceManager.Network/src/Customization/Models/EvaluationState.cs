// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Connectivity analysis evaluation state. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct EvaluationState : IEquatable<EvaluationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EvaluationState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public EvaluationState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotStartedValue = "NotStarted";
        private const string InProgressValue = "InProgress";
        private const string CompletedValue = "Completed";

        /// <summary> NotStarted. </summary>
        public static EvaluationState NotStarted { get; } = new EvaluationState(NotStartedValue);
        /// <summary> InProgress. </summary>
        public static EvaluationState InProgress { get; } = new EvaluationState(InProgressValue);
        /// <summary> Completed. </summary>
        public static EvaluationState Completed { get; } = new EvaluationState(CompletedValue);
        /// <summary> Determines if two <see cref="EvaluationState"/> values are the same. </summary>
        public static bool operator ==(EvaluationState left, EvaluationState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="EvaluationState"/> values are not the same. </summary>
        public static bool operator !=(EvaluationState left, EvaluationState right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="EvaluationState"/>. </summary>
        public static implicit operator EvaluationState(string value) => new EvaluationState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EvaluationState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(EvaluationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
