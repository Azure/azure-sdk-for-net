// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class representing ownership voucher
    /// </summary>
    public class OwnershipVoucher
    {
        /// <summary>
        /// Protocol Version
        /// </summary>
        public ProtocolVersion Version { get; set; }

        /// <summary>
        /// Ownership Voucher Header in CBOR
        /// </summary>
        public byte[] Header { get; set; }

        /// <summary>
        /// Ownership Voucher header Hmac
        /// </summary>
        public Hash HeaderHmac { get; set; }

        /// <summary>
        /// Certificate Chain of Device
        /// </summary>
        public CertChain DeviceCertChain { get; set; }

        /// <summary>
        /// Sequential Owner Entries of Ownership Voucher
        /// </summary>

        public OwnershipVoucherEntries OwnerEntries { get; set; }

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
            if (obj is OwnershipVoucher ownershipVoucher)
            {
                return Version == ownershipVoucher.Version &&
                   StructuralComparisons.StructuralEqualityComparer.Equals(Header, ownershipVoucher.Header) &&
                   object.Equals(HeaderHmac, ownershipVoucher.HeaderHmac) &&
                   object.Equals(DeviceCertChain, ownershipVoucher.DeviceCertChain) &&
                   object.Equals(OwnerEntries, ownershipVoucher.OwnerEntries);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = HashCode.Combine(Version,
                                        HeaderHmac?.GetHashCode() ?? 0,
                                        DeviceCertChain?.GetHashCode() ?? 0,
                                        OwnerEntries?.GetHashCode() ?? 0);

            if (Header != null)
            {
                foreach (var b in Header)
                {
                    hashCode = HashCode.Combine(hashCode, b);
                }
            }

            return hashCode;
        }
    }
}
