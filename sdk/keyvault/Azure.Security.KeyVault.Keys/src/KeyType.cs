// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public readonly struct KeyType : IEquatable<KeyType>
    {
        private const string ECString = "EC";
        private const string ECHsmString = "EC-HSM";
        private const string RsaString = "RSA";
        private const string RsaHsmString = "RSA-HSM";
        private const string OctetString = "Octet";
        private static readonly string[] s_mapping = new string[] { ECString, ECHsmString, RsaString, RsaHsmString, OctetString };

        private readonly KeyTypeValue _value;
        private readonly string _valueText;

        /// <summary>
        /// Supported JsonWebKey key types (kty) as enum
        /// </summary>
        public enum KeyTypeValue : uint
        {
            Other = 0,
            EllipticCurve,
            EllipticCurveHsm,
            Rsa,
            RsaHsm,
            Octet,
            // When a new entry is added, make sure to expose it as below.
        }

        public static KeyType Rsa { get; } = new KeyType(KeyTypeValue.Rsa);
        public static KeyType RsaHsm { get; } = new KeyType(KeyTypeValue.RsaHsm);
        public static KeyType EllipticCurve { get; } = new KeyType(KeyTypeValue.EllipticCurve);
        public static KeyType EllipticCurveHsm { get; } = new KeyType(KeyTypeValue.EllipticCurveHsm);
        public static KeyType Octet { get; } = new KeyType(KeyTypeValue.Octet);

        public KeyTypeValue Value => _value;

        public KeyType(KeyTypeValue value)
        {
            if (value == KeyTypeValue.Other) throw new ArgumentOutOfRangeException(nameof(value));
            _value = value;
            _valueText = default;
        }

        internal KeyType(string customValue)
        {
            if (string.IsNullOrEmpty(customValue)) throw new ArgumentNullException(nameof(customValue));

            var index = s_mapping.AsSpan().IndexOf(customValue);
            if (index != -1)
            {
                _value = (KeyTypeValue)index + 1; // 0 = Other
                _valueText = default;
            }
            else
            {
                _value = KeyTypeValue.Other;
                _valueText = customValue;
            }
        }

        public static implicit operator KeyTypeValue(KeyType keyType) => keyType.Value;
        public static explicit operator KeyType(KeyTypeValue keyTypeValue) => new KeyType(keyTypeValue);

        public static bool operator ==(KeyType left, KeyType right) => left.Equals(right);
        public static bool operator !=(KeyType left, KeyType right) => !left.Equals(right);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(KeyType other)
        {
            if (Value != other.Value) return false;
            if (Value == KeyTypeValue.Other) return _valueText.Equals(other._valueText, StringComparison.OrdinalIgnoreCase);
            return true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is KeyType keyType) return this.Equals(keyType);
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            if (Value == KeyTypeValue.Other) return _valueText.GetHashCode();
            return Value.GetHashCode();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            if (Value == KeyTypeValue.Other) return _valueText;
            return s_mapping[(uint)Value - 1]; // 0 is Other
        }
    }
}
