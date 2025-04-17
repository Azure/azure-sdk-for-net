// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using Azure.IoT.DeviceOnboarding.Models;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Helper class for Hashing
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Gets Hash Type based on KeySize
        /// </summary>
        /// <param name="keySize"></param>
        /// <param name="isHMAC"></param>
        /// <returns>Hash Type</returns>
        /// <exception cref="ArgumentException"></exception>
        public static HashType GetHashType(KeySize keySize, bool isHMAC = false)
        {
            switch (keySize)
            {
                case KeySize.KeySize384:
                case KeySize.KeySize3072:
                    if (isHMAC)
                    {
                        return HashType.HMAC_SHA384;
                    }
                    return HashType.SHA384;
                case KeySize.KeySize256:
                case KeySize.KeySize2048:
                    if (isHMAC)
                    {
                        return HashType.HMAC_SHA256;
                    }
                    return HashType.SHA256;
                default:
                    throw new ArgumentException($"Public Key Size not supported {keySize}");
            }
        }

        /// <summary>
        /// Get hash of the data
        /// </summary>
        /// <param name="hashType">Type of hash</param>
        /// <param name="data">Data to be hashed</param>
        /// <returns></returns>
        public static byte[] GetHashValue(HashType hashType, byte[] data)
        {
            switch (hashType)
            {
                case HashType.SHA256:
                case HashType.HMAC_SHA256:
#if NETSTANDARD2_0
                    return (SHA256.Create()).ComputeHash(data);
#else
                    return SHA256.HashData(data);
#endif
                case HashType.SHA384:
                case HashType.HMAC_SHA384:
#if NETSTANDARD2_0
                    return (SHA384.Create()).ComputeHash(data);
#else
                    return SHA384.HashData(data);
#endif
                default:
                    throw new NotImplementedException($"Hash Calculation not supported for {hashType}");
            }
        }

        /// <summary>
        /// Get hash for ownership voucher header
        /// </summary>
        /// <param name="ovHeader"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        public static Hash GetOVHeaderHash(OwnershipVoucherHeader ovHeader, HashType hashType)
        {
            byte[] data;

            using (var memoryStream = new MemoryStream())
            {
                var ovHeaderBytes = ovHeader.Guid.ToByteArray();
                var ovHeaderDeviceInfoBytes = System.Text.Encoding.UTF8.GetBytes(ovHeader.DeviceInfo);
                memoryStream.Write(ovHeaderBytes, 0, ovHeaderBytes.Length);
                memoryStream.Write(ovHeaderDeviceInfoBytes, 0, ovHeaderDeviceInfoBytes.Length);
                data = memoryStream.ToArray();
            }
            var hashBytes = GetHashValue(hashType, data);

            var headerHash = new Hash
            {
                HashType = hashType,
                HashValue = hashBytes
            };
            return headerHash;
        }

        /// <summary>
        /// Get Hashing Algorithm for COSE Message
        /// </summary>
        /// <param name="keyType">FDO Public Key Type.</param>
        /// <param name="keySize"></param>
        /// <returns>
        /// Hashing Algorithm
        /// </returns>
        public static HashAlgorithmName GetSupportedHashAlgorithm(PublicKeyType keyType, int keySize)
        {
            switch (keyType)
            {
                case PublicKeyType.SECP256R1:
                    return HashAlgorithmName.SHA256;
                case PublicKeyType.SECP384R1:
                    return HashAlgorithmName.SHA384;
                case PublicKeyType.RSAPKCS:
                case PublicKeyType.RSA2048RESTR:
                    {
                        switch (keySize)
                        {
                            case 2048:
                                return HashAlgorithmName.SHA256;
                            case 3072:
                                return HashAlgorithmName.SHA384;
                            default:
                                throw new ArgumentException("KeySize " + keySize);
                        }
                    }
                default:
                    throw new ArgumentException("PublicKeyType " + keyType);
            }
        }
    }
}
