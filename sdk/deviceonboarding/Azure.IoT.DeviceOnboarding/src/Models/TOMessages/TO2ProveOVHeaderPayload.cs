// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// TO2 Prove OV Header Payload
    /// </summary>
    public class TO2ProveOVHeaderPayload
    {
        /// <summary>
        /// Ownership Voucher header
        /// </summary>
        public byte[] Header { get; set; }

        /// <summary>
        /// Number of ownership voucher entries
        /// </summary>
        public byte NumEntries { get; set; }

        /// <summary>
        /// Ownership Voucher "hmac" of Header
        /// </summary>
        public Hash Hmac { get; set; }

        /// <summary>
        /// FDONonce from TO2.HelloDevice
        /// </summary>
        public FDONonce NonceTO2ProveOV { get; set; }

        /// <summary>
        /// Device attestation signature info
        /// </summary>
        public SigInfo SigInfoB { get; set; }

        /// <summary>
        /// Key exchange first step
        /// </summary>
        public byte[] KexA { get; set; }

        /// <summary>
        /// hash of HelloDevice message
        /// </summary>
        public Hash HelloHash { get; set; }

        /// <summary>
        /// Max Owner Message Size
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public ushort MaxMessageSize { get; set; }
#pragma warning restore CS3003 // Type is not CLS-compliant

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
            if (obj is TO2ProveOVHeaderPayload to2ProveOVHeaderPayload)
            {
                return StructuralComparisons.StructuralEqualityComparer.Equals(Header, to2ProveOVHeaderPayload.Header) &&
                    NumEntries == to2ProveOVHeaderPayload.NumEntries &&
                    object.Equals(Hmac, to2ProveOVHeaderPayload.Hmac) &&
                    object.Equals(NonceTO2ProveOV, to2ProveOVHeaderPayload.NonceTO2ProveOV) &&
                    object.Equals(SigInfoB, to2ProveOVHeaderPayload.SigInfoB) &&
                    StructuralComparisons.StructuralEqualityComparer.Equals(KexA, to2ProveOVHeaderPayload.KexA) &&
                    object.Equals(HelloHash, to2ProveOVHeaderPayload.HelloHash) &&
                    MaxMessageSize == to2ProveOVHeaderPayload.MaxMessageSize;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(
                Header != null ? StructuralComparisons.StructuralEqualityComparer.GetHashCode(Header) : 0,
                NumEntries,
                Hmac?.GetHashCode() ?? 0,
                NonceTO2ProveOV?.GetHashCode() ?? 0,
                SigInfoB?.GetHashCode() ?? 0,
                KexA != null ? StructuralComparisons.StructuralEqualityComparer.GetHashCode(KexA) : 0,
                HelloHash?.GetHashCode() ?? 0,
                MaxMessageSize
            );
        }
    }
}
