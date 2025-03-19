// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
    /// <summary> The AssociationType. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `TrafficControllerAssociationType` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AssociationType : IEquatable<AssociationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AssociationType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AssociationType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SubnetsValue = "subnets";

        /// <summary> subnets. </summary>
        public static AssociationType Subnets { get; } = new AssociationType(SubnetsValue);
        /// <summary> Determines if two <see cref="AssociationType"/> values are the same. </summary>
        public static bool operator ==(AssociationType left, AssociationType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AssociationType"/> values are not the same. </summary>
        public static bool operator !=(AssociationType left, AssociationType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AssociationType"/>. </summary>
        public static implicit operator AssociationType(string value) => new AssociationType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AssociationType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AssociationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
