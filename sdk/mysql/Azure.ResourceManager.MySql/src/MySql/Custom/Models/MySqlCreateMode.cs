// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> The mode to create a new server. </summary>
    internal readonly partial struct MySqlCreateMode : IEquatable<MySqlCreateMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MySqlCreateMode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MySqlCreateMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DefaultValue = "Default";
        private const string PointInTimeRestoreValue = "PointInTimeRestore";
        private const string GeoRestoreValue = "GeoRestore";
        private const string ReplicaValue = "Replica";

        /// <summary> Default. </summary>
        public static MySqlCreateMode Default { get; } = new MySqlCreateMode(DefaultValue);
        /// <summary> PointInTimeRestore. </summary>
        public static MySqlCreateMode PointInTimeRestore { get; } = new MySqlCreateMode(PointInTimeRestoreValue);
        /// <summary> GeoRestore. </summary>
        public static MySqlCreateMode GeoRestore { get; } = new MySqlCreateMode(GeoRestoreValue);
        /// <summary> Replica. </summary>
        public static MySqlCreateMode Replica { get; } = new MySqlCreateMode(ReplicaValue);
        /// <summary> Determines if two <see cref="MySqlCreateMode"/> values are the same. </summary>
        public static bool operator ==(MySqlCreateMode left, MySqlCreateMode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MySqlCreateMode"/> values are not the same. </summary>
        public static bool operator !=(MySqlCreateMode left, MySqlCreateMode right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="MySqlCreateMode"/>. </summary>
        public static implicit operator MySqlCreateMode(string value) => new MySqlCreateMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MySqlCreateMode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MySqlCreateMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}