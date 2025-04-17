// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Ownership Voucher Entry Payload
    /// </summary>
    public class OwnershipVoucherEntryPayload
    {
        /// <summary>
        /// Previous entry hash
        /// </summary>
        public Hash PreviousHash { get; set; }

        /// <summary>
        /// Header hash
        /// </summary>
        public Hash HeaderHash { get; set; }

        /// <summary>
        /// Extra data
        /// </summary>
        public byte[] Extra { get; set; }

        /// <summary>
        /// Owner Public Key
        /// </summary>
        public PublicKey OwnerPublicKey { get; set; }

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
            if (obj is OwnershipVoucherEntryPayload ownershipVoucherEntryPayload)
            {
                return object.Equals(this.PreviousHash, ownershipVoucherEntryPayload.PreviousHash) &&
                    object.Equals(this.HeaderHash, ownershipVoucherEntryPayload.HeaderHash) &&
                    StructuralComparisons.StructuralEqualityComparer.Equals(this.Extra, ownershipVoucherEntryPayload.Extra) &&
                    object.Equals(this.OwnerPublicKey, ownershipVoucherEntryPayload.OwnerPublicKey);
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
                PreviousHash?.GetHashCode() ?? 0,
                HeaderHash?.GetHashCode() ?? 0,
                Extra != null ? StructuralComparisons.StructuralEqualityComparer.GetHashCode(Extra) : 0,
                OwnerPublicKey?.GetHashCode() ?? 0
            );
        }
    }
}
