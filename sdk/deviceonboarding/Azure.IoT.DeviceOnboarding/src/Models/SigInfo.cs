// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Signature Info; used to encode parameters for device attestation signature
    /// </summary>
    public class SigInfo
    {
        /// <summary>
        /// Device signature type.
        /// </summary>
		public DeviceSgType SigInfoType { get; set; }

        /// <summary>
        /// Information
        /// </summary>
        public byte[] Info { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is SigInfo sigInfo)
            {
                return SigInfoType == sigInfo.SigInfoType &&
                   StructuralComparisons.StructuralEqualityComparer.Equals(Info, sigInfo.Info);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.SigInfoType,
                StructuralComparisons.StructuralEqualityComparer.GetHashCode(Info));
        }

        /// <summary>
        /// Get device signature type from publickeytype
        /// </summary>
        /// <param name="publicKeyType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static DeviceSgType GetSigInfoType(PublicKeyType publicKeyType)
        {
            switch (publicKeyType)
            {
                case PublicKeyType.SECP256R1:
                    return DeviceSgType.SECP256R1;
                case PublicKeyType.SECP384R1:
                    return DeviceSgType.SECP384R1;
                default:
                    var msg = $"SigInfoType {publicKeyType} not supported on device.";
                    throw new ArgumentException(msg);
            }
        }
    }

    /// <summary>
    /// Device signature types
    /// </summary>
    public enum DeviceSgType
    {
        /// <summary>
        /// ECDSA secp256r1 = NIST-P-256 = prime256v
        /// </summary>
        SECP256R1 = -7,

        /// <summary>
        /// ECDSA secp384r1 = NIST-P-384
        /// </summary>
        SECP384R1 = -35,

        /// <summary>
        /// RSA 2048 bit
        /// </summary>
        RSA2048 = -257,

        /// <summary>
        /// RSA 3072 bit
        /// </summary>
        RSA3072 = -258,

        /// <summary>
        /// Intel® EPID 1.0 signature
        /// </summary>
        EPID10 = 90,

        /// <summary>
        /// Intel® EPID 1.1 signature
        /// </summary>
        EPID11 = 91
    }
}
