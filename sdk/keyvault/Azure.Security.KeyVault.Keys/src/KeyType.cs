// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public struct KeyType
    {
        /// <summary>
        /// Supported JsonWebKey key types (kty) as enum
        /// </summary>
        public enum KeyTypeValues : uint
        {
            EllipticCurve = 0x0001,
            EllipticCurveHsm = 0x0002,
            Rsa = 0x0004,
            RsaHsm = 0x0008,
            Octet = 0x0010
            // When a new entry is added, make sure to expose it as a field below.
        }

        public static readonly KeyType Rsa = new KeyType("RSA");
        public static readonly KeyType RsaHsm = new KeyType("RSA-HSM");
        public static readonly KeyType EllipticCurve = new KeyType("EC");
        public static readonly KeyType EllipticCurveHsm = new KeyType("EC-HSM");
        public static readonly KeyType Octet = new KeyType("Octet");

        public string StringValue { get; private set; }

        public KeyType(string keyType)
        {
            StringValue = keyType;
        }

        public static bool operator ==(KeyType first, KeyType second)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(first.StringValue, second.StringValue);
        }

        public static bool operator !=(KeyType first, KeyType second)
        {
            return !StringComparer.OrdinalIgnoreCase.Equals(first.StringValue, second.StringValue);
        }

        public override bool Equals(object obj)
        {
            return obj is KeyType objAsKeyType &&
                StringComparer.OrdinalIgnoreCase.Equals(StringValue, objAsKeyType.StringValue);
        }

        public override int GetHashCode()
        {
            return StringValue.GetHashCode();
        }
    }
}
