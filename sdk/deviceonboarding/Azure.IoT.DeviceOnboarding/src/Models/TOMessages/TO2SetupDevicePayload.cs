// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Setup Device Payload
    /// </summary>
    public class TO2SetupDevicePayload
    {
        /// <summary>
        /// RendezvousInfo replacement
        /// </summary>
        public RendezvousInfo RendezvousInfo { get; set; }

        /// <summary>
        /// GUID replacement
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// FDONonce to prove freshness of signature
        /// </summary>
        public FDONonce NonceTO2SetupDv { get; set; }

        /// <summary>
        /// Replacement for Owner key
        /// </summary>
        public PublicKey Owner2Key { get; set; }

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
            if (obj is TO2SetupDevicePayload to2SetupDevicePayload)
            {
                return object.Equals(this.RendezvousInfo, to2SetupDevicePayload.RendezvousInfo) &&
                       Guid.Equals(to2SetupDevicePayload.Guid) &&
                       object.Equals(this.NonceTO2SetupDv, to2SetupDevicePayload.NonceTO2SetupDv) &&
                       object.Equals(this.Owner2Key, to2SetupDevicePayload.Owner2Key);
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
                RendezvousInfo?.GetHashCode() ?? 0,
                Guid.GetHashCode(),
                NonceTO2SetupDv?.GetHashCode() ?? 0,
                Owner2Key?.GetHashCode() ?? 0
            );
        }
    }
}
