// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Device Service Info
    /// </summary>
    public class TO2DeviceServiceInfo
    {
        /// <summary>
        /// Indicates if there is more Device Service Information to be sent
        /// </summary>
        public bool IsMoreServiceInfo { get; set; }

        /// <summary>
        /// Device Service Information
        /// </summary>
        public ServiceInfo ServiceInfo { get; set; }

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
            if (obj is TO2DeviceServiceInfo to2DeviceServiceInfo)
            {
                return this.IsMoreServiceInfo == to2DeviceServiceInfo.IsMoreServiceInfo &&
                    object.Equals(this.ServiceInfo, to2DeviceServiceInfo.ServiceInfo);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.IsMoreServiceInfo,
                this.ServiceInfo?.GetHashCode() ?? 0);
        }
    }
}
