// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Evaluation state. </summary>
    public readonly partial struct EvaluationState : IEquatable<EvaluationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EvaluationState"/>. </summary>
        /// <param name="value"> The value. </param>
        public EvaluationState(string value) => _value = value;

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
