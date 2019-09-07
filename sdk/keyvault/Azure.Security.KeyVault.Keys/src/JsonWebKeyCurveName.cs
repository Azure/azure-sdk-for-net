// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public enum JsonWebKeyCurveName : uint
    {
        /// <summary>
        /// The NIST P-256 elliptic curve, AKA SECG curve SECP256R1
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        P256 = 0x0001,
        /// <summary>
        /// The NIST P-384 elliptic curve, AKA SECG curve SECP384R1.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        P384 = 0x0002,
        /// <summary>
        /// The NIST P-521 elliptic curve, AKA SECG curve SECP521R1.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        P521 = 0x0004,
        /// <summary>
        /// The SECG SECP256K1 elliptic curve.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#curve-types"/>.
        /// </summary>
        P256K = 0x0008,
        /// <summary>
        /// Other Elliptic Curve Cryptography curve name.
        /// </summary>
        Other = 0x0010,
    }

    internal readonly struct JsonWebKeyCurveNameInfo
    {
        internal static readonly JsonWebKeyCurveNameInfo P256 = new JsonWebKeyCurveNameInfo(JsonWebKeyCurveName.P256, "P-256", new Oid("1.2.840.10045.3.1.7"), 256, 32);
        internal static readonly JsonWebKeyCurveNameInfo P256K = new JsonWebKeyCurveNameInfo(JsonWebKeyCurveName.P256K, "P-256K", new Oid("1.3.132.0.10"), 256, 32);
        internal static readonly JsonWebKeyCurveNameInfo P384 = new JsonWebKeyCurveNameInfo(JsonWebKeyCurveName.P384, "P-384", new Oid("1.3.132.0.34"), 384, 48);
        internal static readonly JsonWebKeyCurveNameInfo P521 = new JsonWebKeyCurveNameInfo(JsonWebKeyCurveName.P521, "P-521", new Oid("1.3.132.0.35"), 521, 66);
        internal static readonly JsonWebKeyCurveNameInfo Other = new JsonWebKeyCurveNameInfo(JsonWebKeyCurveName.Other, null, null, -1, -1);

        private static readonly JsonWebKeyCurveNameInfo[] Supported =
        {
            P521,
            P384,
            P256K,
            P256,
        };

        private JsonWebKeyCurveNameInfo(JsonWebKeyCurveName value, string name, Oid oid, int keySize, int keyParameterSize)
        {
            Value = value;
            Name = name;
            Oid = oid;
            KeySize = keySize;
            KeyParameterSize = keyParameterSize;
        }

        internal readonly JsonWebKeyCurveName Value;

        internal readonly string Name;

        internal readonly Oid Oid;

        internal readonly int KeySize;

        internal readonly int KeyParameterSize;

        internal static ref readonly JsonWebKeyCurveNameInfo FromValue(JsonWebKeyCurveName value)
        {
            switch (value)
            {
                case JsonWebKeyCurveName.P256:
                    return ref P256;

                case JsonWebKeyCurveName.P256K:
                    return ref P256K;

                case JsonWebKeyCurveName.P384:
                    return ref P384;

                case JsonWebKeyCurveName.P521:
                    return ref P521;

                default:
                    return ref Other;
            }
        }

        internal static ref readonly JsonWebKeyCurveNameInfo FromName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < Supported.Length; ++i)
                {
                    ref JsonWebKeyCurveNameInfo info = ref Supported[i];
                    if (string.Equals(name, info.Name, StringComparison.Ordinal))
                    {
                        return ref info;
                    }
                }
            }

            return ref Other;
        }

        internal static ref readonly JsonWebKeyCurveNameInfo FromOid(Oid oid, int keySize)
        {
            if (!string.IsNullOrEmpty(oid?.Value))
            {
                string oidValue = oid.Value;
                for (int i = 0; i < Supported.Length; ++i)
                {
                    ref JsonWebKeyCurveNameInfo info = ref Supported[i];
                    if (string.Equals(oidValue, info.Oid.Value, StringComparison.Ordinal))
                    {
                        return ref info;
                    }
                }
            }

            if (!string.IsNullOrEmpty(oid?.FriendlyName))
            {
                switch (keySize)
                {
                    case 256 when string.Equals(oid.FriendlyName, "nistP256", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp256r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P256", StringComparison.OrdinalIgnoreCase):
                        return ref P256;

                    case 256 when string.Equals(oid.FriendlyName, "secP256k1", StringComparison.OrdinalIgnoreCase):
                        return ref P256K;

                    case 384 when string.Equals(oid.FriendlyName, "nistP384", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp384r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P384", StringComparison.OrdinalIgnoreCase):
                        return ref P384;

                    case 521 when string.Equals(oid.FriendlyName, "nistP521", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "secp521r1", StringComparison.OrdinalIgnoreCase)
                               || string.Equals(oid.FriendlyName, "ECDSA_P521", StringComparison.OrdinalIgnoreCase):
                        return ref P521;
                }
            }

            return ref Other;
        }

        public override string ToString() => Value switch
        {
            JsonWebKeyCurveName.P256 => P256.Name,
            JsonWebKeyCurveName.P256K => P256K.Name,
            JsonWebKeyCurveName.P384 => P384.Name,
            JsonWebKeyCurveName.P521 => P521.Name,
            _ => string.Empty,
        };
    }
}
