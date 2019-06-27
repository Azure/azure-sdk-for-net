﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey operations
    /// </summary>
    [Flags]
    public enum KeyOperations : uint
    {
        Encrypt = 0x0001,
        Decrypt = 0x0002,
        Sign = 0x0004,
        Verify = 0x0008,
        Wrap = 0x0010,
        Unwrap = 0x0020,
        Other = 0x0040,

        All = uint.MaxValue
    }

    public static class KeyOperationsExtensions
    {
        public static KeyOperations ParseFromString(string value)
        {
            switch (value)
            {
                case "encrypt": return KeyOperations.Encrypt;
                case "decrypt": return KeyOperations.Decrypt;
                case "sign": return KeyOperations.Sign;
                case "verify": return KeyOperations.Verify;
                case "wrapKey": return KeyOperations.Wrap;
                case "unwrapKey": return KeyOperations.Unwrap;
                default: return KeyOperations.Other;
            }
        }

        public static string AsString(KeyOperations keyType)
        {
            switch (keyType)
            {
                case KeyOperations.Encrypt:
                    return "encrypt";
                case KeyOperations.Decrypt:
                    return "decrypt";
                case KeyOperations.Sign:
                    return "sign";
                case KeyOperations.Verify:
                    return "verify";
                case KeyOperations.Wrap:
                    return "wrapKey";
                case KeyOperations.Unwrap:
                    return "unwrapKey";
                default:
                    return string.Empty;
            }
        }
    }
}
