// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    /// <summary> Sort the query results by input field. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SmartGroupsSortByField : IEquatable<SmartGroupsSortByField>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public SmartGroupsSortByField(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        /// <summary> AlertsCount. </summary>
        public static SmartGroupsSortByField AlertsCount => throw new NotSupportedException();
        /// <summary> State. </summary>
        public static SmartGroupsSortByField State => throw new NotSupportedException();
        /// <summary> Severity. </summary>
        public static SmartGroupsSortByField Severity => throw new NotSupportedException();
        /// <summary> StartDateTime. </summary>
        public static SmartGroupsSortByField StartDateTime => throw new NotSupportedException();
        /// <summary> LastModifiedDateTime. </summary>
        public static SmartGroupsSortByField LastModifiedDateTime => throw new NotSupportedException();

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
