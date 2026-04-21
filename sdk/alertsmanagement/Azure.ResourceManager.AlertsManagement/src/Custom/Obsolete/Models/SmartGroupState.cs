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
    public readonly partial struct SmartGroupState : IEquatable<SmartGroupState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance. </summary>
        /// <param name="value"> The value. </param>
        public SmartGroupState(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        private const string NewValue = "New";
        private const string AcknowledgedValue = "Acknowledged";
        private const string ClosedValue = "Closed";

        /// <summary> New. </summary>
        public static SmartGroupState New { get; } = new SmartGroupState(NewValue);
        /// <summary> Acknowledged. </summary>
        public static SmartGroupState Acknowledged { get; } = new SmartGroupState(AcknowledgedValue);
        /// <summary> Closed. </summary>
        public static SmartGroupState Closed { get; } = new SmartGroupState(ClosedValue);

        /// <summary> Converts a string. </summary>
        public static implicit operator SmartGroupState(string value) => new SmartGroupState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SmartGroupState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SmartGroupState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Equality operator. </summary>
        public static bool operator ==(SmartGroupState left, SmartGroupState right) => left.Equals(right);
        /// <summary> Inequality operator. </summary>
        public static bool operator !=(SmartGroupState left, SmartGroupState right) => !left.Equals(right);
    }
}
