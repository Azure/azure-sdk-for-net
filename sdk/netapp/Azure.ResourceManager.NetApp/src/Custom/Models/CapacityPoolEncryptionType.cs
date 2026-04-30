// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct CapacityPoolEncryptionType : IEquatable<CapacityPoolEncryptionType>
    {
        private readonly string _value;

        public CapacityPoolEncryptionType(string value)
        {
            _value = value;
        }

        public static CapacityPoolEncryptionType Single { get; } = new CapacityPoolEncryptionType("Single");
        public static CapacityPoolEncryptionType Double { get; } = new CapacityPoolEncryptionType("Double");

        public static implicit operator CapacityPoolEncryptionType(string value) => new CapacityPoolEncryptionType(value);
        public static bool operator ==(CapacityPoolEncryptionType left, CapacityPoolEncryptionType right) => left.Equals(right);
        public static bool operator !=(CapacityPoolEncryptionType left, CapacityPoolEncryptionType right) => !left.Equals(right);

        public bool Equals(CapacityPoolEncryptionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is CapacityPoolEncryptionType other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}
