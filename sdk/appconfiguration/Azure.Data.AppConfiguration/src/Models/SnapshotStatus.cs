// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The current status of the snapshot. </summary>
    public readonly partial struct SnapshotStatus : IEquatable<SnapshotStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SnapshotStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SnapshotStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ProvisioningValue = "provisioning";
        private const string ReadyValue = "ready";
        private const string ArchivedValue = "archived";
        private const string FailedValue = "failed";

        /// <summary> provisioning. </summary>
        public static SnapshotStatus Provisioning { get; } = new SnapshotStatus(ProvisioningValue);
        /// <summary> ready. </summary>
        public static SnapshotStatus Ready { get; } = new SnapshotStatus(ReadyValue);
        /// <summary> archived. </summary>
        public static SnapshotStatus Archived { get; } = new SnapshotStatus(ArchivedValue);
        /// <summary> failed. </summary>
        public static SnapshotStatus Failed { get; } = new SnapshotStatus(FailedValue);
        /// <summary> Determines if two <see cref="SnapshotStatus"/> values are the same. </summary>
        public static bool operator ==(SnapshotStatus left, SnapshotStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SnapshotStatus"/> values are not the same. </summary>
        public static bool operator !=(SnapshotStatus left, SnapshotStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SnapshotStatus"/>. </summary>
        public static implicit operator SnapshotStatus(string value) => new SnapshotStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SnapshotStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SnapshotStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
