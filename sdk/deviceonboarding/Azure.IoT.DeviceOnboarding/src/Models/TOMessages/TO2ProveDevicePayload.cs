// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Prove Device Payload
    /// </summary>
    public class TO2ProveDevicePayload
    {
        /// <summary>
        /// Key exchange parameter
        /// </summary>
        public byte[] KexB { get; set; }

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
            if (obj is TO2ProveDevicePayload to2ProveDevicePayload)
            {
                return StructuralComparisons.StructuralEqualityComparer.Equals(KexB, to2ProveDevicePayload.KexB);
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
            if (KexB != null)
            {
                foreach (var val in KexB)
                {
                    hashCode = HashCode.Combine(hashCode, val);
                }
            }
            return hashCode;
        }
    }
}
