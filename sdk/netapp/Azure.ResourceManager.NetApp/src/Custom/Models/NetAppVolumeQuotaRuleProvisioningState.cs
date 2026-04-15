// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Gets the status of the VolumeQuotaRule at the time the operation was called. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct NetAppVolumeQuotaRuleProvisioningState : IEquatable<NetAppVolumeQuotaRuleProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetAppVolumeQuotaRuleProvisioningState"/>. </summary>
        public NetAppVolumeQuotaRuleProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <inheritdoc />
        public bool Equals(NetAppVolumeQuotaRuleProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is NetAppVolumeQuotaRuleProvisioningState other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;

        /// <summary> Determines if two <see cref="NetAppVolumeQuotaRuleProvisioningState"/> values are the same. </summary>
        public static bool operator ==(NetAppVolumeQuotaRuleProvisioningState left, NetAppVolumeQuotaRuleProvisioningState right) => left.Equals(right);

        /// <summary> Determines if two <see cref="NetAppVolumeQuotaRuleProvisioningState"/> values are not the same. </summary>
        public static bool operator !=(NetAppVolumeQuotaRuleProvisioningState left, NetAppVolumeQuotaRuleProvisioningState right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="NetAppVolumeQuotaRuleProvisioningState"/>. </summary>
        public static implicit operator NetAppVolumeQuotaRuleProvisioningState(string value) => new NetAppVolumeQuotaRuleProvisioningState(value);

        /// <summary> Accepted. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Accepted { get; } = new NetAppVolumeQuotaRuleProvisioningState("Accepted");
        /// <summary> Creating. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Creating { get; } = new NetAppVolumeQuotaRuleProvisioningState("Creating");
        /// <summary> Patching. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Patching { get; } = new NetAppVolumeQuotaRuleProvisioningState("Patching");
        /// <summary> Deleting. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Deleting { get; } = new NetAppVolumeQuotaRuleProvisioningState("Deleting");
        /// <summary> Moving. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Moving { get; } = new NetAppVolumeQuotaRuleProvisioningState("Moving");
        /// <summary> Failed. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Failed { get; } = new NetAppVolumeQuotaRuleProvisioningState("Failed");
        /// <summary> Succeeded. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Succeeded { get; } = new NetAppVolumeQuotaRuleProvisioningState("Succeeded");
        /// <summary> Updating. </summary>
        public static NetAppVolumeQuotaRuleProvisioningState Updating { get; } = new NetAppVolumeQuotaRuleProvisioningState("Updating");
    }
}
