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
    public enum KeyCurveName : uint
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

    internal static class KeyCurveNameExtensions
    {
        internal static KeyCurveName ParseFromString(string value)
        {
            switch (value)
            {
                case "P-256":
                    return KeyCurveName.P256;
                case "P-256K":
                    return KeyCurveName.P256K;
                case "P-384":
                    return KeyCurveName.P384;
                case "P-521":
                    return KeyCurveName.P521;
                default:
                    return KeyCurveName.Other;
            }
        }

        internal static string AsString(KeyCurveName curve)
        {
            switch (curve)
            {
                case KeyCurveName.P256:
                    return "P-256";
                case KeyCurveName.P256K:
                    return "P-256K";
                case KeyCurveName.P384:
                    return "P-384";
                case KeyCurveName.P521:
                    return "P-521";
                default:
                    return string.Empty;
            }
        }
    }
}
