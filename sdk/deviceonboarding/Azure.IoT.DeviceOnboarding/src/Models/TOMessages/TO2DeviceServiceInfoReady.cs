// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Device Service Info Ready
    /// </summary>
    public class TO2DeviceServiceInfoReady
    {
        /// <summary>
        /// Replacement for HMAC
        /// </summary>
        public Hash Hmac { get; set; }

        /// <summary>
        /// Maximum size service info that Device can receive
        /// </summary>
        public ushort? MaxMessageSize { get; set; }

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
            if (obj is TO2DeviceServiceInfoReady to2DeviceServiceInfoReady)
            {
                return object.Equals(this.Hmac, to2DeviceServiceInfoReady.Hmac) &&
                       this.MaxMessageSize == to2DeviceServiceInfoReady.MaxMessageSize;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Hmac?.GetHashCode() ?? 0,
                this.MaxMessageSize);
        }
    }
}
