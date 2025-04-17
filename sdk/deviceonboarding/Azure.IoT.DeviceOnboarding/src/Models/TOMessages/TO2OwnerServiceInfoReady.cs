// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Owner Service Info ready
    /// </summary>
    public class TO2OwnerServiceInfoReady
    {
        /// <summary>
        /// Max size of the message that can owner can receive
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
            if (obj is TO2OwnerServiceInfoReady to2OwnerServiceInfoReady)
            {
                return this.MaxMessageSize == to2OwnerServiceInfoReady.MaxMessageSize;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.MaxMessageSize);
        }
    }
}
