// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct CapacityPoolEncryptionType : IEquatable<CapacityPoolEncryptionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CapacityPoolEncryptionType"/>. </summary>
        public CapacityPoolEncryptionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> EncryptionType Single, volumes will use single encryption at rest. </summary>
        public static CapacityPoolEncryptionType Single { get; } = new CapacityPoolEncryptionType(SingleValue);
        /// <summary> EncryptionType Double, volumes will use double encryption at rest. </summary>
        public static CapacityPoolEncryptionType Double { get; } = new CapacityPoolEncryptionType(DoubleValue);

        /// <inheritdoc />
        public bool Equals(CapacityPoolEncryptionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is CapacityPoolEncryptionType other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
