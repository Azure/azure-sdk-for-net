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
    /// <summary> Days of week. </summary>
    [Obsolete("The AlertProcessingRule types have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the same-named type (e.g., Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AlertsManagementDayOfWeek : IEquatable<AlertsManagementDayOfWeek>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public AlertsManagementDayOfWeek(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        private const string SundayValue = "Sunday";
        private const string MondayValue = "Monday";
        private const string TuesdayValue = "Tuesday";
        private const string WednesdayValue = "Wednesday";
        private const string ThursdayValue = "Thursday";
        private const string FridayValue = "Friday";
        private const string SaturdayValue = "Saturday";

        /// <summary> Sunday. </summary>
        public static AlertsManagementDayOfWeek Sunday { get; } = new AlertsManagementDayOfWeek(SundayValue);
        /// <summary> Monday. </summary>
        public static AlertsManagementDayOfWeek Monday { get; } = new AlertsManagementDayOfWeek(MondayValue);
        /// <summary> Tuesday. </summary>
        public static AlertsManagementDayOfWeek Tuesday { get; } = new AlertsManagementDayOfWeek(TuesdayValue);
        /// <summary> Wednesday. </summary>
        public static AlertsManagementDayOfWeek Wednesday { get; } = new AlertsManagementDayOfWeek(WednesdayValue);
        /// <summary> Thursday. </summary>
        public static AlertsManagementDayOfWeek Thursday { get; } = new AlertsManagementDayOfWeek(ThursdayValue);
        /// <summary> Friday. </summary>
        public static AlertsManagementDayOfWeek Friday { get; } = new AlertsManagementDayOfWeek(FridayValue);
        /// <summary> Saturday. </summary>
        public static AlertsManagementDayOfWeek Saturday { get; } = new AlertsManagementDayOfWeek(SaturdayValue);

        /// <summary> Converts a string. </summary>
        public static implicit operator AlertsManagementDayOfWeek(string value) => new AlertsManagementDayOfWeek(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AlertsManagementDayOfWeek other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AlertsManagementDayOfWeek other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(AlertsManagementDayOfWeek left, AlertsManagementDayOfWeek right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(AlertsManagementDayOfWeek left, AlertsManagementDayOfWeek right) => !left.Equals(right);
    }
}
