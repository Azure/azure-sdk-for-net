// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public enum KeyType : uint
    {
        /// <summary>
        /// Cryptographic algorithm Elliptic Curve
        /// </summary>
        EllipticCurve = 0x0001,
        /// <summary>
        /// Cryptographic algorithm Elliptic Curve HSM
        /// </summary>
        EllipticCurveHsm = 0x0002,
        /// <summary>
        /// Cryptographic algorithm RSA
        /// </summary>
        Rsa = 0x0004,
        /// <summary>
        /// Cryptographic algorithm RSA HSM
        /// </summary>
        RsaHsm = 0x0008,
        /// <summary>
        /// Cryptographic algorithm Octet
        /// </summary>
        Octet = 0x0010,
        /// <summary>
        /// Other type of cyptographic algorithm 
        /// </summary>
        Other = 0x0020,
    }

    internal static class KeyTypeExtensions
    {
        internal static KeyType ParseFromString(string value)
        {
            switch (value)
            {
                case "EC":
                    return KeyType.EllipticCurve;
                case "EC-HSM":
                    return KeyType.EllipticCurveHsm;
                case "RSA":
                    return KeyType.Rsa;
                case "RSA-HSM":
                    return KeyType.RsaHsm;
                case "oct":
                    return KeyType.Octet;
                default:
                    return KeyType.Other;
            }
        }

        internal static string AsString(KeyType keyType)
        {
            switch (keyType)
            {
                case KeyType.EllipticCurve:
                    return "EC";
                case KeyType.EllipticCurveHsm:
                    return "EC-HSM";
                case KeyType.Rsa:
                    return "RSA";
                case KeyType.RsaHsm:
                    return "RSA-HSM";
                case KeyType.Octet:
                    return "oct";
                default:
                    return string.Empty;
            }
        }
    }
}
