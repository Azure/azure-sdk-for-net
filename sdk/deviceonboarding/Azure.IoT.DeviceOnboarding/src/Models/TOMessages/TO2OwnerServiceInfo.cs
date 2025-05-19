// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Owner Service Info
    /// </summary>
    public class TO2OwnerServiceInfo
    {
        /// <summary>
        /// Is there more information to be sent
        /// </summary>
        public bool IsMoreServiceInfo { get; set; }

        /// <summary>
        /// Is all the information sent
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Service Information on owner side
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
            if (obj is TO2OwnerServiceInfo to2OwnerServiceInfo)
            {
                return IsMoreServiceInfo == to2OwnerServiceInfo.IsMoreServiceInfo &&
                   IsDone == to2OwnerServiceInfo.IsDone &&
                   object.Equals(ServiceInfo, to2OwnerServiceInfo.ServiceInfo);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.IsMoreServiceInfo, this.IsDone,
                this.ServiceInfo?.GetHashCode() ?? 0);
        }
    }
}
