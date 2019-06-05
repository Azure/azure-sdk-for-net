// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public enum KeyCurveName : uint
    {
        P256 = 0x0001,
        P384 = 0x0002,
        P521 = 0x0004,
        P256K = 0x0008,
        Other = 0x0010,
    }

    public static class KeyCurveNameExtensions
    {
        public static KeyCurveName ParseFromString(string value)
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

        public static string AsString(KeyCurveName curve)
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
