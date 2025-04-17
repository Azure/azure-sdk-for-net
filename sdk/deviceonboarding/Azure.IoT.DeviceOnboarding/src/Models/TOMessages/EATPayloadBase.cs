// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// EAT Payload Base
    /// </summary>
    public class EATPayloadBase
    {
        /// <summary>
        /// Contain the specified FIDO Device Onboard FDONonce for the specific FIDO Device Onboard message
        /// </summary>
        public FDONonce Nonce { get; set; }

        /// <summary>
        /// Device Protocol GUID
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Claims specified for the specific FIDO Device Onboard message
        /// </summary>
        public object FdoClaim { get; set; }

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
            if (obj is EATPayloadBase eatPayloadBase)
            {
                return object.Equals(Nonce, eatPayloadBase.Nonce) &&
                       Guid.Equals(eatPayloadBase.Guid) &&
                       object.Equals(FdoClaim, eatPayloadBase.FdoClaim);
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
                Guid.GetHashCode(),
                FdoClaim?.GetHashCode() ?? 0
            );
        }
    }
}
