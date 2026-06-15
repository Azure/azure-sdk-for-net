// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy Azure Monitor workspace public network access value. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
    public readonly partial struct MonitorWorkspacePublicNetworkAccess : IEquatable<MonitorWorkspacePublicNetworkAccess>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MonitorWorkspacePublicNetworkAccess"/>. </summary>
        public MonitorWorkspacePublicNetworkAccess(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Enabled. </summary>
        public static MonitorWorkspacePublicNetworkAccess Enabled { get; } = new MonitorWorkspacePublicNetworkAccess("Enabled");

        /// <summary> Disabled. </summary>
        public static MonitorWorkspacePublicNetworkAccess Disabled { get; } = new MonitorWorkspacePublicNetworkAccess("Disabled");

        /// <inheritdoc/>
        public bool Equals(MonitorWorkspacePublicNetworkAccess other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MonitorWorkspacePublicNetworkAccess other && Equals(other);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to <see cref="MonitorWorkspacePublicNetworkAccess"/>. </summary>
        public static implicit operator MonitorWorkspacePublicNetworkAccess(string value) => new MonitorWorkspacePublicNetworkAccess(value);

        /// <summary> Determines if two values are equal. </summary>
        public static bool operator ==(MonitorWorkspacePublicNetworkAccess left, MonitorWorkspacePublicNetworkAccess right) => left.Equals(right);

        /// <summary> Determines if two values are not equal. </summary>
        public static bool operator !=(MonitorWorkspacePublicNetworkAccess left, MonitorWorkspacePublicNetworkAccess right) => !left.Equals(right);
    }
}
