// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: VolumeReplicationRelationshipStatus was previously a separate generated type.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Replication SnapMirror relationship status. </summary>
    public readonly partial struct VolumeReplicationRelationshipStatus : IEquatable<VolumeReplicationRelationshipStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VolumeReplicationRelationshipStatus"/>. </summary>
        public VolumeReplicationRelationshipStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        private const string IdleValue = "Idle";
        private const string TransferringValue = "Transferring";

        /// <summary> Idle. </summary>
        public static VolumeReplicationRelationshipStatus Idle { get; } = new VolumeReplicationRelationshipStatus(IdleValue);
        /// <summary> Transferring. </summary>
        public static VolumeReplicationRelationshipStatus Transferring { get; } = new VolumeReplicationRelationshipStatus(TransferringValue);

        /// <inheritdoc />
        public static bool operator ==(VolumeReplicationRelationshipStatus left, VolumeReplicationRelationshipStatus right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(VolumeReplicationRelationshipStatus left, VolumeReplicationRelationshipStatus right) => !left.Equals(right);
        /// <inheritdoc />
        public static implicit operator VolumeReplicationRelationshipStatus(string value) => new VolumeReplicationRelationshipStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VolumeReplicationRelationshipStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VolumeReplicationRelationshipStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
