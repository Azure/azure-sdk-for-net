// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// TO1 Prove to RV Object
    /// </summary>
    public class TO1ProveToRV : EATPayloadBase
    {
        /// <summary>
        /// Create new instance of TO1ProveToRV
        /// </summary>
        public TO1ProveToRV() : base()
        {
        }

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
            if (obj is TO1ProveToRV to2ProveDevice)
            {
                // We don't check fdo claim here as it is not populated for TO1ProveToRV
                return object.Equals(Nonce, to2ProveDevice.Nonce) &&
                       Guid.Equals(to2ProveDevice.Guid);
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
                Nonce?.GetHashCode() ?? 0,
                Guid.GetHashCode()
            );
        }
    }
}
