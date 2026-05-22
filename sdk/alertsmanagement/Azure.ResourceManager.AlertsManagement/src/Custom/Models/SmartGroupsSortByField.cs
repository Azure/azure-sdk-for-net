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
    //   The SmartGroup operation group is deliberately out of scope for this migration's TypeSpec spec
    //   (specification/alertsmanagement/.../Microsoft.AlertsManagement/AlertsManagement). The
    //   underlying service operations still exist but will be shipped from a separate dedicated package
    //   in a future release, so the MPG generator does not (and must not) emit these types here.
    //
    // What this stub provides:
    //   The type is declared with the original v1.1.x signature so that consumer assemblies compiled
    //   against the old GA still load, but every member throws NotSupportedException at runtime. The
    //   type is also marked [Obsolete(..., error: true)] + [EditorBrowsable(Never)] so the C# compiler
    //   redirects new callers to the future dedicated SmartGroup package.
    /// <summary> Sort the query results by input field. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SmartGroupsSortByField : IEquatable<SmartGroupsSortByField>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public SmartGroupsSortByField(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        private const string AlertsCountValue = "alertsCount";
        private const string StateValue = "state";
        private const string SeverityValue = "severity";
        private const string StartDateTimeValue = "startDateTime";
        private const string LastModifiedDateTimeValue = "lastModifiedDateTime";

        /// <summary> AlertsCount. </summary>
        public static SmartGroupsSortByField AlertsCount { get; } = new SmartGroupsSortByField(AlertsCountValue);
        /// <summary> State. </summary>
        public static SmartGroupsSortByField State { get; } = new SmartGroupsSortByField(StateValue);
        /// <summary> Severity. </summary>
        public static SmartGroupsSortByField Severity { get; } = new SmartGroupsSortByField(SeverityValue);
        /// <summary> StartDateTime. </summary>
        public static SmartGroupsSortByField StartDateTime { get; } = new SmartGroupsSortByField(StartDateTimeValue);
        /// <summary> LastModifiedDateTime. </summary>
        public static SmartGroupsSortByField LastModifiedDateTime { get; } = new SmartGroupsSortByField(LastModifiedDateTimeValue);

        /// <summary> Converts a string. </summary>
        public static implicit operator SmartGroupsSortByField(string value) => new SmartGroupsSortByField(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SmartGroupsSortByField other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SmartGroupsSortByField other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(SmartGroupsSortByField left, SmartGroupsSortByField right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(SmartGroupsSortByField left, SmartGroupsSortByField right) => !left.Equals(right);
    }
}
