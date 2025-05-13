// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
	/// TO2 Prove Device Object
	/// </summary>
    public class TO2ProveDevice : EATPayloadBase
    {
        /// <summary>
        /// Create a new instance of TO2ProveDevice
        /// </summary>
        public TO2ProveDevice() : base()
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
            if (obj is TO2ProveDevice to2ProveDevice)
            {
                TO2ProveDevicePayload payloadA = ConvertToType<TO2ProveDevicePayload>(this.FdoClaim);
                TO2ProveDevicePayload payloadB = ConvertToType<TO2ProveDevicePayload>(to2ProveDevice.FdoClaim);
                return object.Equals(Nonce, to2ProveDevice.Nonce) &&
                       Guid.Equals(to2ProveDevice.Guid) &&
                       object.Equals(payloadA, payloadB);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            TO2ProveDevicePayload payload = ConvertToType<TO2ProveDevicePayload>(this.FdoClaim);
            return HashCode.Combine(
                Nonce?.GetHashCode() ?? 0,
                Guid.GetHashCode(),
                payload?.GetHashCode() ?? 0
            );
        }

        private static T ConvertToType<T>(object obj) where T : class
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
            {
                return null;
            }
        }
    }
}
