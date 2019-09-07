// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Supported JsonWebKey cryptographic operations that may be performed on a key.
    /// </summary>
    [Flags]
    public enum JsonWebKeyOperations : uint
    {
        /// <summary>
        /// A key stored in Key Vault may be used to protect another key, 
        /// typically a symmetric content encryption key (CEK). 
        /// When the key in Key Vault is asymmetric, key encryption is used.
        /// A key stored in Key Vault may be used to encrypt
        /// a single block of data.
        /// The size of the block is determined by the key type and selected encryption algorithm.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        Encrypt = 0x0001,
        /// <summary>
        /// A key stored in Key Vault may be used to protect another key, 
        /// typically a symmetric content encryption key (CEK).
        /// A key stored in Key Vault may be used to decrypt
        /// a single block of data.
        /// The size of the block is determined by the key type and selected encryption algorithm.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        Decrypt = 0x0002,
        /// <summary>
        /// This operation is "sign hash" as Key Vault doesn't support hashing
        /// of content as part of signature creation.
        /// Applications should hash the data to be signed locally,
        /// then request that Key Vault sign the hash.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        Sign = 0x0004,
        /// <summary>
        /// This operation is "verify hash", as Key Vault doesn't support hashing of content
        /// as part of signature creation. 
        /// Verification of signed hashes is supported as a convenience operation
        /// for applications that may not have access to [public] key material.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        Verify = 0x0008,
        /// <summary>
        /// The WrapWrapKey operation is supported as a convenience for
        /// applications that may not have access to [public] key material. 
        /// For best application performance, wrap key operations should be performed locally.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        WrapKey = 0x0010,
        /// <summary>
        /// Unwraps a symmetric key using the specified key that was initially used
        /// for wrapping that key. The unwrap operation supports decryption of a 
        /// symmetric key using the target key encryption key.
        /// This operation is the reverse of the WRAP operation.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        UnwrapKey = 0x0020,
        /// <summary>
        /// Other type of Key Operation
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        Other = 0x0040,
        /// <summary>
        /// Include all Key Operations
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/key-vault/about-keys-secrets-and-certificates#key-operations"/>.
        /// </summary>
        All = uint.MaxValue
    }

    internal static class KeyOperationsExtensions
    {
        internal static JsonWebKeyOperations Parse(string value)
        {
            switch (value)
            {
                case "encrypt": return JsonWebKeyOperations.Encrypt;
                case "decrypt": return JsonWebKeyOperations.Decrypt;
                case "sign": return JsonWebKeyOperations.Sign;
                case "verify": return JsonWebKeyOperations.Verify;
                case "wrapKey": return JsonWebKeyOperations.WrapKey;
                case "unwrapKey": return JsonWebKeyOperations.UnwrapKey;
                default: return JsonWebKeyOperations.Other;
            }
        }

        internal static string AsString(JsonWebKeyOperations keyType)
        {
            switch (keyType)
            {
                case JsonWebKeyOperations.Encrypt:
                    return "encrypt";
                case JsonWebKeyOperations.Decrypt:
                    return "decrypt";
                case JsonWebKeyOperations.Sign:
                    return "sign";
                case JsonWebKeyOperations.Verify:
                    return "verify";
                case JsonWebKeyOperations.WrapKey:
                    return "wrapKey";
                case JsonWebKeyOperations.UnwrapKey:
                    return "unwrapKey";
                default:
                    return string.Empty;
            }
        }
    }
}
