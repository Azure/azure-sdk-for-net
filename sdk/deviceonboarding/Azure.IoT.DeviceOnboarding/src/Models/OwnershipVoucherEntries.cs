// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.Cose;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// List of Ownership Voucher Entries
    /// </summary>
    public class OwnershipVoucherEntries : List<CoseSign1Message>
    {
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
            if (obj is OwnershipVoucherEntries ownershipVoucherEntries)
            {
                if (this.Count != ownershipVoucherEntries.Count)
                {
                    return false;
                }
                for (int i = 0; i < ownershipVoucherEntries.Count; i++)
                {
                    byte[] encodedMessageA = this[i].Encode();
                    byte[] encodedMessageB = ownershipVoucherEntries[i].Encode();

                    if (!StructuralComparisons.StructuralEqualityComparer.Equals(encodedMessageA, encodedMessageB))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var ovEntry in this)
            {
                byte[] encodedMessage = ovEntry.Encode();
                hashCode = System.HashCode.Combine(hashCode,
                    StructuralComparisons.StructuralEqualityComparer.GetHashCode(encodedMessage));
            }
            return hashCode;
        }
    }
}
