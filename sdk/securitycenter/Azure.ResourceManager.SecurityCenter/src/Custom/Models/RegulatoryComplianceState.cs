// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Backward compatibility: preserve the previous extensible enum shape for regulatory compliance state.
    /// <summary> State of regulatory compliance. </summary>
    public readonly partial struct RegulatoryComplianceState : IEquatable<RegulatoryComplianceState>
    {
        private readonly string _value;
        private const string PassedValue = "Passed";
        private const string FailedValue = "Failed";
        private const string SkippedValue = "Skipped";
        private const string UnsupportedValue = "Unsupported";

        /// <summary> Initializes a new instance of <see cref="RegulatoryComplianceState"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RegulatoryComplianceState(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Passed. </summary>
        public static RegulatoryComplianceState Passed { get; } = new RegulatoryComplianceState(PassedValue);
        /// <summary> Failed. </summary>
        public static RegulatoryComplianceState Failed { get; } = new RegulatoryComplianceState(FailedValue);
        /// <summary> Skipped. </summary>
        public static RegulatoryComplianceState Skipped { get; } = new RegulatoryComplianceState(SkippedValue);
        /// <summary> Unsupported. </summary>
        public static RegulatoryComplianceState Unsupported { get; } = new RegulatoryComplianceState(UnsupportedValue);

        /// <summary> Determines if two <see cref="RegulatoryComplianceState"/> values are the same. </summary>
        public static bool operator ==(RegulatoryComplianceState left, RegulatoryComplianceState right) => left.Equals(right);

        /// <summary> Determines if two <see cref="RegulatoryComplianceState"/> values are not the same. </summary>
        public static bool operator !=(RegulatoryComplianceState left, RegulatoryComplianceState right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="RegulatoryComplianceState"/>. </summary>
        public static implicit operator RegulatoryComplianceState(string value) => new RegulatoryComplianceState(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RegulatoryComplianceState other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(RegulatoryComplianceState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
