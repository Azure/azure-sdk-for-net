// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AlertProcessingRuleOperator : IEquatable<AlertProcessingRuleOperator>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public AlertProcessingRuleOperator(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        private const string EqualsValueValue = "Equals";
        private const string NotEqualsValue = "NotEquals";
        private const string ContainsValue = "Contains";
        private const string DoesNotContainValue = "DoesNotContain";

        /// <summary> Equals. </summary>
        public static AlertProcessingRuleOperator EqualsValue { get; } = new AlertProcessingRuleOperator(EqualsValueValue);
        /// <summary> NotEquals. </summary>
        public static AlertProcessingRuleOperator NotEquals { get; } = new AlertProcessingRuleOperator(NotEqualsValue);
        /// <summary> Contains. </summary>
        public static AlertProcessingRuleOperator Contains { get; } = new AlertProcessingRuleOperator(ContainsValue);
        /// <summary> DoesNotContain. </summary>
        public static AlertProcessingRuleOperator DoesNotContain { get; } = new AlertProcessingRuleOperator(DoesNotContainValue);

        /// <summary> Converts a string. </summary>
        public static implicit operator AlertProcessingRuleOperator(string value) => new AlertProcessingRuleOperator(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AlertProcessingRuleOperator other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AlertProcessingRuleOperator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(AlertProcessingRuleOperator left, AlertProcessingRuleOperator right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(AlertProcessingRuleOperator left, AlertProcessingRuleOperator right) => !left.Equals(right);
    }
}
