// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AlertProcessingRuleField : IEquatable<AlertProcessingRuleField>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public AlertProcessingRuleField(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        private const string SeverityValue = "Severity";
        private const string MonitorServiceValue = "MonitorService";
        private const string MonitorConditionValue = "MonitorCondition";
        private const string SignalTypeValue = "SignalType";
        private const string TargetResourceTypeValue = "TargetResourceType";
        private const string TargetResourceValue = "TargetResource";
        private const string TargetResourceGroupValue = "TargetResourceGroup";
        private const string AlertRuleIdValue = "AlertRuleId";
        private const string AlertRuleNameValue = "AlertRuleName";
        private const string DescriptionValue = "Description";
        private const string AlertContextValue = "AlertContext";

        /// <summary> Severity. </summary>
        public static AlertProcessingRuleField Severity { get; } = new AlertProcessingRuleField(SeverityValue);
        /// <summary> MonitorService. </summary>
        public static AlertProcessingRuleField MonitorService { get; } = new AlertProcessingRuleField(MonitorServiceValue);
        /// <summary> MonitorCondition. </summary>
        public static AlertProcessingRuleField MonitorCondition { get; } = new AlertProcessingRuleField(MonitorConditionValue);
        /// <summary> SignalType. </summary>
        public static AlertProcessingRuleField SignalType { get; } = new AlertProcessingRuleField(SignalTypeValue);
        /// <summary> TargetResourceType. </summary>
        public static AlertProcessingRuleField TargetResourceType { get; } = new AlertProcessingRuleField(TargetResourceTypeValue);
        /// <summary> TargetResource. </summary>
        public static AlertProcessingRuleField TargetResource { get; } = new AlertProcessingRuleField(TargetResourceValue);
        /// <summary> TargetResourceGroup. </summary>
        public static AlertProcessingRuleField TargetResourceGroup { get; } = new AlertProcessingRuleField(TargetResourceGroupValue);
        /// <summary> AlertRuleId. </summary>
        public static AlertProcessingRuleField AlertRuleId { get; } = new AlertProcessingRuleField(AlertRuleIdValue);
        /// <summary> AlertRuleName. </summary>
        public static AlertProcessingRuleField AlertRuleName { get; } = new AlertProcessingRuleField(AlertRuleNameValue);
        /// <summary> Description. </summary>
        public static AlertProcessingRuleField Description { get; } = new AlertProcessingRuleField(DescriptionValue);
        /// <summary> AlertContext. </summary>
        public static AlertProcessingRuleField AlertContext { get; } = new AlertProcessingRuleField(AlertContextValue);

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
