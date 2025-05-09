// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Done
    /// </summary>
    public class TO2Done
    {
        /// <summary>
        /// FDONonce shared during To2 Prove OV Header
        /// </summary>
        public FDONonce NonceTO2ProveDevice { get; set; }

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
            if (obj is TO2Done to2Done)
            {
                return object.Equals(this.NonceTO2ProveDevice, to2Done.NonceTO2ProveDevice);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.NonceTO2ProveDevice?.GetHashCode() ?? 0;
        }
    }
}
