// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> DDoS custom policy trigger sensitivity override. </summary>
    [ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    public readonly partial struct DdosCustomPolicyTriggerSensitivityOverride : IEquatable<DdosCustomPolicyTriggerSensitivityOverride>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosCustomPolicyTriggerSensitivityOverride(string value)
        {
            _value = value;
        }

        /// <summary> Default. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Default { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Default");
        /// <summary> High. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride High { get; } = new DdosCustomPolicyTriggerSensitivityOverride("High");
        /// <summary> Low. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Low { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Low");
        /// <summary> Relaxed. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Relaxed { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Relaxed");

        /// <inheritdoc/>
        public bool Equals(DdosCustomPolicyTriggerSensitivityOverride other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosCustomPolicyTriggerSensitivityOverride other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values for equality. </summary>
        public static bool operator ==(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        public static implicit operator DdosCustomPolicyTriggerSensitivityOverride(string value) => new DdosCustomPolicyTriggerSensitivityOverride(value);
        /// <summary> Compares two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values for inequality. </summary>
        public static bool operator !=(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
