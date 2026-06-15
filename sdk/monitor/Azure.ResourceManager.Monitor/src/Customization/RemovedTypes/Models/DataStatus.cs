// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy VM Insights data status. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public readonly partial struct DataStatus : IEquatable<DataStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataStatus"/>. </summary>
        public DataStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Present. </summary>
        public static DataStatus Present { get; } = new DataStatus("Present");

        /// <summary> NotPresent. </summary>
        public static DataStatus NotPresent { get; } = new DataStatus("NotPresent");

        /// <inheritdoc/>
        public bool Equals(DataStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DataStatus other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <summary> Converts a string to <see cref="DataStatus"/>. </summary>
        public static implicit operator DataStatus(string value) => new DataStatus(value);

        /// <summary> Determines if two values are equal. </summary>
        public static bool operator ==(DataStatus left, DataStatus right) => left.Equals(right);

        /// <summary> Determines if two values are not equal. </summary>
        public static bool operator !=(DataStatus left, DataStatus right) => !left.Equals(right);
    }
}
