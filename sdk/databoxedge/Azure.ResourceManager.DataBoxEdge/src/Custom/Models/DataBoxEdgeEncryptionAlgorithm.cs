// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly:CodeGenSuppressType("DataBoxEdgeEncryptionAlgorithm")]
namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> The algorithm used to encrypt &quot;Value&quot;. </summary>
    public readonly partial struct DataBoxEdgeEncryptionAlgorithm : IEquatable<DataBoxEdgeEncryptionAlgorithm>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeEncryptionAlgorithm"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataBoxEdgeEncryptionAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string Aes256Value = "AES256";
#pragma warning disable CA1707
        private const string RsaesPkcs1V1_5Value = "RSAES_PKCS1_v_1_5";

        /// <summary> None. </summary>
        public static DataBoxEdgeEncryptionAlgorithm None { get; } = new DataBoxEdgeEncryptionAlgorithm(NoneValue);
        /// <summary> AES256. </summary>
        public static DataBoxEdgeEncryptionAlgorithm Aes256 { get; } = new DataBoxEdgeEncryptionAlgorithm(Aes256Value);
        /// <summary> RSAES_PKCS1_v_1_5. </summary>
        public static DataBoxEdgeEncryptionAlgorithm RsaesPkcs1V1_5 { get; } = new DataBoxEdgeEncryptionAlgorithm(RsaesPkcs1V1_5Value);
#pragma warning restore CA1707
        /// <summary> Determines if two <see cref="DataBoxEdgeEncryptionAlgorithm"/> values are the same. </summary>
        public static bool operator ==(DataBoxEdgeEncryptionAlgorithm left, DataBoxEdgeEncryptionAlgorithm right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataBoxEdgeEncryptionAlgorithm"/> values are not the same. </summary>
        public static bool operator !=(DataBoxEdgeEncryptionAlgorithm left, DataBoxEdgeEncryptionAlgorithm right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataBoxEdgeEncryptionAlgorithm"/>. </summary>
        public static implicit operator DataBoxEdgeEncryptionAlgorithm(string value) => new DataBoxEdgeEncryptionAlgorithm(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataBoxEdgeEncryptionAlgorithm other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataBoxEdgeEncryptionAlgorithm other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
