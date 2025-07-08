// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> Compute model enum. </summary>
    public readonly partial struct AutonomousDatabaseComputeModel : IEquatable<AutonomousDatabaseComputeModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AutonomousDatabaseComputeModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AutonomousDatabaseComputeModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EcpuValue = "ECPU";
        private const string OcpuValue = "OCPU";

        /// <summary> ECPU model type. </summary>
        public static AutonomousDatabaseComputeModel Ecpu { get; } = new AutonomousDatabaseComputeModel(EcpuValue);
        /// <summary> OCPU model type. </summary>
        public static AutonomousDatabaseComputeModel Ocpu { get; } = new AutonomousDatabaseComputeModel(OcpuValue);
        /// <summary> Determines if two <see cref="AutonomousDatabaseComputeModel"/> values are the same. </summary>
        public static bool operator ==(AutonomousDatabaseComputeModel left, AutonomousDatabaseComputeModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AutonomousDatabaseComputeModel"/> values are not the same. </summary>
        public static bool operator !=(AutonomousDatabaseComputeModel left, AutonomousDatabaseComputeModel right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AutonomousDatabaseComputeModel"/>. </summary>
        public static implicit operator AutonomousDatabaseComputeModel(string value) => new AutonomousDatabaseComputeModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AutonomousDatabaseComputeModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AutonomousDatabaseComputeModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
