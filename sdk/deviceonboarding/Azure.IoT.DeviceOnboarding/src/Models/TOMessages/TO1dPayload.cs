// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To1d Payload
    /// </summary>
    public class TO1dPayload
    {
        /// <summary>
        /// Address Entries, choices to access TO2 protocol
        /// </summary>
        public TO2AddressEntries AddressEntries { get; set; }

        /// <summary>
        /// Hash of to0d from same to0 message
        /// </summary>
        public Hash To1dTo0dHash { get; set; }

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
            if (obj is TO1dPayload to1dPayload)
            {
                return object.Equals(this.AddressEntries, to1dPayload.AddressEntries) &&
                       object.Equals(this.To1dTo0dHash, to1dPayload.To1dTo0dHash);
            }
            return false;
        }
        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.AddressEntries?.GetHashCode() ?? 0,
                this.To1dTo0dHash?.GetHashCode() ?? 0);
        }
    }
}
