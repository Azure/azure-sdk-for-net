// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Done2 Response
    /// </summary>
    public class TO2Done2
    {
        /// <summary>
        /// FDONonce Object shared during To2 Setup Device
        /// </summary>
        public FDONonce NonceTO2SetupDevice { get; set; }

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
            if (obj is TO2Done2 to2Done2)
            {
                return object.Equals(this.NonceTO2SetupDevice, to2Done2.NonceTO2SetupDevice);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.NonceTO2SetupDevice?.GetHashCode() ?? 0;
        }
    }
}
