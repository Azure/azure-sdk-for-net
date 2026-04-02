// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist)
// Old name: ContainerGroupProvisioningState, New name: NGroupProvisioningState

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="NGroupProvisioningState"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerGroupProvisioningState : IEquatable<ContainerGroupProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProvisioningState"/>. </summary>
        public ContainerGroupProvisioningState(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Accepted. </summary>
        public static ContainerGroupProvisioningState Accepted { get; } = new ContainerGroupProvisioningState("Accepted");
        /// <summary> Canceled. </summary>
        public static ContainerGroupProvisioningState Canceled { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Canceled.ToString());
        /// <summary> Creating. </summary>
        public static ContainerGroupProvisioningState Creating { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Creating.ToString());
        /// <summary> Deleting. </summary>
        public static ContainerGroupProvisioningState Deleting { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Deleting.ToString());
        /// <summary> Failed. </summary>
        public static ContainerGroupProvisioningState Failed { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Failed.ToString());
        /// <summary> NotAccessible. </summary>
        public static ContainerGroupProvisioningState NotAccessible { get; } = new ContainerGroupProvisioningState("NotAccessible");
        /// <summary> NotSpecified. </summary>
        public static ContainerGroupProvisioningState NotSpecified { get; } = new ContainerGroupProvisioningState("NotSpecified");
        /// <summary> Pending. </summary>
        public static ContainerGroupProvisioningState Pending { get; } = new ContainerGroupProvisioningState("Pending");
        /// <summary> PreProvisioned. </summary>
        public static ContainerGroupProvisioningState PreProvisioned { get; } = new ContainerGroupProvisioningState("PreProvisioned");
        /// <summary> Repairing. </summary>
        public static ContainerGroupProvisioningState Repairing { get; } = new ContainerGroupProvisioningState("Repairing");
        /// <summary> Succeeded. </summary>
        public static ContainerGroupProvisioningState Succeeded { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Succeeded.ToString());
        /// <summary> Unhealthy. </summary>
        public static ContainerGroupProvisioningState Unhealthy { get; } = new ContainerGroupProvisioningState("Unhealthy");
        /// <summary> Updating. </summary>
        public static ContainerGroupProvisioningState Updating { get; } = new ContainerGroupProvisioningState(NGroupProvisioningState.Updating.ToString());

        /// <summary> Converts to the new type. </summary>
        public static implicit operator NGroupProvisioningState(ContainerGroupProvisioningState value) => new NGroupProvisioningState(value._value);
        /// <summary> Converts from the new type. </summary>
        public static implicit operator ContainerGroupProvisioningState(NGroupProvisioningState value) => new ContainerGroupProvisioningState(value.ToString());

        /// <inheritdoc />
        public static bool operator ==(ContainerGroupProvisioningState left, ContainerGroupProvisioningState right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(ContainerGroupProvisioningState left, ContainerGroupProvisioningState right) => !left.Equals(right);
        /// <inheritdoc />
        public static implicit operator ContainerGroupProvisioningState(string value) => new ContainerGroupProvisioningState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContainerGroupProvisioningState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerGroupProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
