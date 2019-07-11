// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// <summary>
        /// Key Operation encrypt
        /// </summary>
        Encrypt = 0x0001,
        /// <summary>
        /// Key Operation decrypt
        /// </summary>
        Decrypt = 0x0002,
        /// <summary>
        /// Key Operation sign
        /// </summary>
        Sign = 0x0004,
        /// <summary>
        /// Key Operation verify
        /// </summary>
        Verify = 0x0008,
        /// <summary>
        /// Key Operation wrap
        /// </summary>
        Wrap = 0x0010,
        /// <summary>
        /// Key Operation unwrap
        /// </summary>
        Unwrap = 0x0020,
        /// <summary>
        /// Other type of Key Operation
        /// </summary>
        Other = 0x0040,
        /// <summary>
        /// Include all Key Operations
        /// </summary>
        All = uint.MaxValue
    }

    internal static class KeyOperationsExtensions
    {
        internal static KeyOperations ParseFromString(string value)
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

        internal static string AsString(KeyOperations keyType)
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
