// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: VolumeRestoreRelationshipStatus was previously a separate generated type.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Restore SnapMirror relationship status. </summary>
    public readonly partial struct VolumeRestoreRelationshipStatus : IEquatable<VolumeRestoreRelationshipStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="VolumeRestoreRelationshipStatus"/>. </summary>
        public VolumeRestoreRelationshipStatus(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        private const string IdleValue = "Idle";
        private const string TransferringValue = "Transferring";
        private const string FailedValue = "Failed";
        private const string UnknownValue = "Unknown";

        /// <summary> Idle. </summary>
        public static VolumeRestoreRelationshipStatus Idle { get; } = new VolumeRestoreRelationshipStatus(IdleValue);
        /// <summary> Transferring. </summary>
        public static VolumeRestoreRelationshipStatus Transferring { get; } = new VolumeRestoreRelationshipStatus(TransferringValue);
        /// <summary> Failed. </summary>
        public static VolumeRestoreRelationshipStatus Failed { get; } = new VolumeRestoreRelationshipStatus(FailedValue);
        /// <summary> Unknown. </summary>
        public static VolumeRestoreRelationshipStatus Unknown { get; } = new VolumeRestoreRelationshipStatus(UnknownValue);

        /// <summary> Determines if two <see cref="VolumeRestoreRelationshipStatus"/> values are the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator ==(VolumeRestoreRelationshipStatus left, VolumeRestoreRelationshipStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="VolumeRestoreRelationshipStatus"/> values are not the same. </summary>
        /// <param name="left"> The left value to compare. </param>
        /// <param name="right"> The right value to compare. </param>
        public static bool operator !=(VolumeRestoreRelationshipStatus left, VolumeRestoreRelationshipStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="VolumeRestoreRelationshipStatus"/>. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator VolumeRestoreRelationshipStatus(string value) => new VolumeRestoreRelationshipStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VolumeRestoreRelationshipStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(VolumeRestoreRelationshipStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
