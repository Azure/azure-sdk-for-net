// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> The current status of the snapshot. </summary>
    public readonly partial struct ConfigurationSnapshotStatus : IEquatable<ConfigurationSnapshotStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConfigurationSnapshotStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ConfigurationSnapshotStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ProvisioningValue = "provisioning";
        private const string ReadyValue = "ready";
        private const string ArchivedValue = "archived";
        private const string FailedValue = "failed";

        /// <summary> provisioning. </summary>
        public static ConfigurationSnapshotStatus Provisioning { get; } = new ConfigurationSnapshotStatus(ProvisioningValue);
        /// <summary> ready. </summary>
        public static ConfigurationSnapshotStatus Ready { get; } = new ConfigurationSnapshotStatus(ReadyValue);
        /// <summary> archived. </summary>
        public static ConfigurationSnapshotStatus Archived { get; } = new ConfigurationSnapshotStatus(ArchivedValue);
        /// <summary> failed. </summary>
        public static ConfigurationSnapshotStatus Failed { get; } = new ConfigurationSnapshotStatus(FailedValue);
        /// <summary> Determines if two <see cref="ConfigurationSnapshotStatus"/> values are the same. </summary>
        public static bool operator ==(ConfigurationSnapshotStatus left, ConfigurationSnapshotStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConfigurationSnapshotStatus"/> values are not the same. </summary>
        public static bool operator !=(ConfigurationSnapshotStatus left, ConfigurationSnapshotStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConfigurationSnapshotStatus"/>. </summary>
        public static implicit operator ConfigurationSnapshotStatus(string value) => new ConfigurationSnapshotStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConfigurationSnapshotStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConfigurationSnapshotStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
