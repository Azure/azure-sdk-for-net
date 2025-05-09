// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// TO1 Hello RV
    /// </summary>
    public class TO1HelloRV
    {
        /// <summary>
        /// Device Guid
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Signature related information; from Device to Rendezvous/Owner
        /// </summary>
        public SigInfo EASigInfo { get; set; }

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
            if (obj is TO1HelloRV to1HelloRV)
            {
                return this.Guid.Equals(to1HelloRV.Guid) &&
                       object.Equals(this.EASigInfo, to1HelloRV.EASigInfo);
            }
            return false;
        }
        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Guid,
                this.EASigInfo?.GetHashCode() ?? 0);
        }
    }
}
