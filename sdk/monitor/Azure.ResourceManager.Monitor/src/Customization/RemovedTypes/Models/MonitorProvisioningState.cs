// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy monitor provisioning state. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public readonly partial struct MonitorProvisioningState : IEquatable<MonitorProvisioningState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MonitorProvisioningState"/>. </summary>
        public MonitorProvisioningState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Creating. </summary>
        public static MonitorProvisioningState Creating { get; } = new MonitorProvisioningState("Creating");

        /// <summary> Succeeded. </summary>
        public static MonitorProvisioningState Succeeded { get; } = new MonitorProvisioningState("Succeeded");

        /// <summary> Failed. </summary>
        public static MonitorProvisioningState Failed { get; } = new MonitorProvisioningState("Failed");

        /// <summary> Deleting. </summary>
        public static MonitorProvisioningState Deleting { get; } = new MonitorProvisioningState("Deleting");

        /// <summary> Canceled. </summary>
        public static MonitorProvisioningState Canceled { get; } = new MonitorProvisioningState("Canceled");

        /// <inheritdoc/>
        public bool Equals(MonitorProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is MonitorProvisioningState other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to <see cref="MonitorProvisioningState"/>. </summary>
        public static implicit operator MonitorProvisioningState(string value) => new MonitorProvisioningState(value);

        /// <summary> Determines if two values are equal. </summary>
        public static bool operator ==(MonitorProvisioningState left, MonitorProvisioningState right) => left.Equals(right);

        /// <summary> Determines if two values are not equal. </summary>
        public static bool operator !=(MonitorProvisioningState left, MonitorProvisioningState right) => !left.Equals(right);
    }
}