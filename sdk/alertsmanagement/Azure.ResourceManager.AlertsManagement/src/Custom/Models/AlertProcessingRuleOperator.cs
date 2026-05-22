// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    // Back-compat ApiCompat shim — kept solely to preserve the binary contract of the previously
    // published GA package (Azure.ResourceManager.AlertsManagement v1.1.x).
    //
    // Why it lives here instead of being regenerated:
    //   The TypeSpec spec for this package (specification/alertsmanagement/.../Microsoft.AlertsManagement/
    //   AlertsManagement) intentionally covers only the Alerts + AlertsSummary operation groups. The
    //   AlertProcessingRule (formerly "actionRules") RP surface was extracted into its own RP namespace
    //   and now ships from the sibling package 'Azure.ResourceManager.AlertProcessingRules', so the
    //   MPG generator does not (and must not) emit these types here.
    //
    // What this stub provides:
    //   The type is declared with the original v1.1.x signature so that consumer assemblies compiled
    //   against the old GA still load, but every member throws NotSupportedException at runtime. The
    //   type is also marked [Obsolete(..., error: true)] + [EditorBrowsable(Never)] so the C# compiler
    //   redirects new callers to the AlertProcessingRules package.
    /// <summary> Operator for a given condition. </summary>
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
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
