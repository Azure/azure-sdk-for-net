// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// List of To2 Address Entries
    /// </summary>
    public class TO2AddressEntries : LinkedList<TO2AddressEntry>
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
            if (obj is TO2AddressEntries to2AddressEntries)
            {
                return this.SequenceEqual(to2AddressEntries);
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
            foreach (var to2AddressEntry in this)
            {
                hashCode = System.HashCode.Combine(hashCode, to2AddressEntry?.GetHashCode() ?? 0);
            }
            return hashCode;
        }
    }
}
