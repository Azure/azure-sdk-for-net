// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Backward compatibility stub. The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release. </summary>
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
