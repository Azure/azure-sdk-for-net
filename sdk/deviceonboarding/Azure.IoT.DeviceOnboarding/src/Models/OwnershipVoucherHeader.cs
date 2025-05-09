// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Ownership Voucher Header
    /// </summary>
    public class OwnershipVoucherHeader
    {
        /// <summary>
        /// Protocol version of Ownership Voucher
        /// </summary>
        public ProtocolVersion Version { get; set; }

        /// <summary>
        /// Unique Guid for Devcie FDO Protocol
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Rendezvous Info
        /// </summary>
        public RendezvousInfo RendezvousInfo { get; set; }

        /// <summary>
        /// information about device like Endorsement Key, Serial Number, Manufacturer Name etc
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// Owner Public Key
        /// </summary>
        public PublicKey PublicKey { get; set; }

        /// <summary>
        /// Hash of Device Certificate Chain
        /// </summary>
        public Hash DeviceCertChainHash { get; set; }

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
            if (obj is OwnershipVoucherHeader ownershipVoucherHeader)
            {
                return Version == ownershipVoucherHeader.Version &&
                   Guid.Equals(ownershipVoucherHeader.Guid) &&
                   object.Equals(RendezvousInfo, ownershipVoucherHeader.RendezvousInfo) &&
                   string.Equals(DeviceInfo, ownershipVoucherHeader.DeviceInfo) &&
                   object.Equals(PublicKey, ownershipVoucherHeader.PublicKey) &&
                   object.Equals(DeviceCertChainHash, ownershipVoucherHeader.DeviceCertChainHash);
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
                Version,
                Guid,
                RendezvousInfo?.GetHashCode() ?? 0,
                DeviceInfo?.ToLowerInvariant().GetHashCode() ?? 0,
                PublicKey?.GetHashCode() ?? 0,
                DeviceCertChainHash?.GetHashCode() ?? 0
            );
        }
    }
}
