// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Security.Cryptography.Cose;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 OV Next Entry Response
    /// </summary>
    public class TO2OVNextEntry
    {
        /// <summary>
        /// nth entry number of OV Entries
        /// </summary>
        public byte EntryNumber { get; set; }

        /// <summary>
        /// nth entry value of OV Entries
        /// </summary>
        public CoseSign1Message Entry { get; set; }

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
            if (obj is TO2OVNextEntry to2OVNextEntry)
            {
                byte[] encodedMessageA = this.Entry.Encode();
                byte[] encodedMessageB = to2OVNextEntry.Entry.Encode();

                return EntryNumber == to2OVNextEntry.EntryNumber &&
                    StructuralComparisons.StructuralEqualityComparer.Equals(encodedMessageA, encodedMessageB);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            byte[] encodedMessage = this.Entry.Encode();
            return HashCode.Combine(EntryNumber,
                StructuralComparisons.StructuralEqualityComparer.GetHashCode(encodedMessage));
        }
    }
}
