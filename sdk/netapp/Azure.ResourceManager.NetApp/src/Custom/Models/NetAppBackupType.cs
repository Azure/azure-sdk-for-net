﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Type of backup Manual or Scheduled. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct NetAppBackupType : IEquatable<NetAppBackupType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetAppBackupType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public NetAppBackupType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ManualValue = "Manual";
        private const string ScheduledValue = "Scheduled";

        /// <summary> Manual backup. </summary>
        public static NetAppBackupType Manual { get; } = new NetAppBackupType(ManualValue);
        /// <summary> Scheduled backup. </summary>
        public static NetAppBackupType Scheduled { get; } = new NetAppBackupType(ScheduledValue);
        /// <summary> Determines if two <see cref="NetAppBackupType"/> values are the same. </summary>
        public static bool operator ==(NetAppBackupType left, NetAppBackupType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="NetAppBackupType"/> values are not the same. </summary>
        public static bool operator !=(NetAppBackupType left, NetAppBackupType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="NetAppBackupType"/>. </summary>
        public static implicit operator NetAppBackupType(string value) => new NetAppBackupType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NetAppBackupType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(NetAppBackupType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
