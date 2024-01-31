// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The customized DDoS protection trigger rate sensitivity degrees. High: Trigger rate set with most sensitivity w.r.t. normal traffic. Default: Trigger rate set with moderate sensitivity w.r.t. normal traffic. Low: Trigger rate set with less sensitivity w.r.t. normal traffic. Relaxed: Trigger rate set with least sensitivity w.r.t. normal traffic. </summary>
    [Obsolete("This struct is obsolete and will be removed in a future release", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct DdosCustomPolicyTriggerSensitivityOverride : IEquatable<DdosCustomPolicyTriggerSensitivityOverride>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DdosCustomPolicyTriggerSensitivityOverride(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string RelaxedValue = "Relaxed";
        private const string LowValue = "Low";
        private const string DefaultValue = "Default";
        private const string HighValue = "High";

        /// <summary> Relaxed. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Relaxed { get; } = new DdosCustomPolicyTriggerSensitivityOverride(RelaxedValue);
        /// <summary> Low. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Low { get; } = new DdosCustomPolicyTriggerSensitivityOverride(LowValue);
        /// <summary> Default. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Default { get; } = new DdosCustomPolicyTriggerSensitivityOverride(DefaultValue);
        /// <summary> High. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride High { get; } = new DdosCustomPolicyTriggerSensitivityOverride(HighValue);
        /// <summary> Determines if two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values are the same. </summary>
        public static bool operator ==(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values are not the same. </summary>
        public static bool operator !=(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        public static implicit operator DdosCustomPolicyTriggerSensitivityOverride(string value) => new DdosCustomPolicyTriggerSensitivityOverride(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DdosCustomPolicyTriggerSensitivityOverride other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DdosCustomPolicyTriggerSensitivityOverride other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
