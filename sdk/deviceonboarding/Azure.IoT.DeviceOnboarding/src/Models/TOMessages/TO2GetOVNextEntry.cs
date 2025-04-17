// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Get Next Entry
    /// </summary>
    public class TO2GetOVNextEntry
    {
        /// <summary>
        /// nth entry number of OV Entries to retrieve
        /// </summary>
        public byte EntryNumber { get; set; }

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
            if (obj is TO2GetOVNextEntry to2GetNextEntry)
            {
                return this.EntryNumber == to2GetNextEntry.EntryNumber;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.EntryNumber);
        }
    }
}
