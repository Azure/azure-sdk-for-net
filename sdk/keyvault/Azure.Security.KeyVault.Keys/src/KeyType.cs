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
        EllipticCurve = 0x0001,
        EllipticCurveHsm = 0x0002,
        Rsa = 0x0004,
        RsaHsm = 0x0008,
        Octet = 0x0010,
        Other = 0x0020,
    }

    public static class KeyTypeExtensions
    {
        public static KeyType ParseFromString(string value)
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

        public static string AsString(KeyType keyType)
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
