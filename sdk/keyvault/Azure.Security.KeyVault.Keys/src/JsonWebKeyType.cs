// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public enum JsonWebKeyType : uint
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

    internal static class JsonWebKeyTypeExtensions
    {
        internal static JsonWebKeyType Parse(string value)
        {
            switch (value)
            {
                case "EC":
                    return JsonWebKeyType.EllipticCurve;
                case "EC-HSM":
                    return JsonWebKeyType.EllipticCurveHsm;
                case "RSA":
                    return JsonWebKeyType.Rsa;
                case "RSA-HSM":
                    return JsonWebKeyType.RsaHsm;
                case "oct":
                    return JsonWebKeyType.Octet;
                default:
                    return JsonWebKeyType.Other;
            }
        }

        internal static string AsString(JsonWebKeyType keyType)
        {
            switch (keyType)
            {
                case JsonWebKeyType.EllipticCurve:
                    return "EC";
                case JsonWebKeyType.EllipticCurveHsm:
                    return "EC-HSM";
                case JsonWebKeyType.Rsa:
                    return "RSA";
                case JsonWebKeyType.RsaHsm:
                    return "RSA-HSM";
                case JsonWebKeyType.Octet:
                    return "oct";
                default:
                    return string.Empty;
            }
        }
    }
}
