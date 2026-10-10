// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Field for a given condition. </summary>
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AlertProcessingRuleField : IEquatable<AlertProcessingRuleField>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public AlertProcessingRuleField(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        /// <summary> Severity. </summary>
        public static AlertProcessingRuleField Severity => throw new NotSupportedException();
        /// <summary> MonitorService. </summary>
        public static AlertProcessingRuleField MonitorService => throw new NotSupportedException();
        /// <summary> MonitorCondition. </summary>
        public static AlertProcessingRuleField MonitorCondition => throw new NotSupportedException();
        /// <summary> SignalType. </summary>
        public static AlertProcessingRuleField SignalType => throw new NotSupportedException();
        /// <summary> TargetResourceType. </summary>
        public static AlertProcessingRuleField TargetResourceType => throw new NotSupportedException();
        /// <summary> TargetResource. </summary>
        public static AlertProcessingRuleField TargetResource => throw new NotSupportedException();
        /// <summary> TargetResourceGroup. </summary>
        public static AlertProcessingRuleField TargetResourceGroup => throw new NotSupportedException();
        /// <summary> AlertRuleId. </summary>
        public static AlertProcessingRuleField AlertRuleId => throw new NotSupportedException();
        /// <summary> AlertRuleName. </summary>
        public static AlertProcessingRuleField AlertRuleName => throw new NotSupportedException();
        /// <summary> Description. </summary>
        public static AlertProcessingRuleField Description => throw new NotSupportedException();
        /// <summary> AlertContext. </summary>
        public static AlertProcessingRuleField AlertContext => throw new NotSupportedException();

        /// <summary> Converts a string to AlertProcessingRuleField. </summary>
        public static implicit operator AlertProcessingRuleField(string value) => new AlertProcessingRuleField(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AlertProcessingRuleField other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AlertProcessingRuleField other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(AlertProcessingRuleField left, AlertProcessingRuleField right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(AlertProcessingRuleField left, AlertProcessingRuleField right) => !left.Equals(right);
    }
}
