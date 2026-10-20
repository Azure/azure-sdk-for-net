// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Evaluation state. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This legacy query evaluation state is not supported by the current connection monitor API.")]
    public readonly partial struct EvaluationState : IEquatable<EvaluationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EvaluationState"/>. </summary>
        /// <param name="value"> The value. </param>
        public EvaluationState(string value) => _value = value;

        /// <summary> Completed. </summary>
        public static EvaluationState Completed { get; } = new EvaluationState("Completed");
        /// <summary> InProgress. </summary>
        public static EvaluationState InProgress { get; } = new EvaluationState("InProgress");
        /// <summary> NotStarted. </summary>
        public static EvaluationState NotStarted { get; } = new EvaluationState("NotStarted");

        /// <inheritdoc/>
        public bool Equals(EvaluationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is EvaluationState other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="EvaluationState"/> values for equality. </summary>
        public static bool operator ==(EvaluationState left, EvaluationState right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="EvaluationState"/>. </summary>
        public static implicit operator EvaluationState(string value) => new EvaluationState(value);
        /// <summary> Compares two <see cref="EvaluationState"/> values for inequality. </summary>
        public static bool operator !=(EvaluationState left, EvaluationState right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
