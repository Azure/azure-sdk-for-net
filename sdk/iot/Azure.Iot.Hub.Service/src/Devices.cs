using System;
using System.Collections.Generic;
using System.Text;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class Devices
    {
        internal RegistryManagerClient _registryManagerClient;
        /// <summary>
        /// 
        /// </summary>
        public Devices()
        {
            _registryManagerClient = new RegistryManagerRestClient();
        }

        /// <summary>
        /// Get a single device.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device.</returns>
        public virtual async Task<Response<DeviceIdentity>> GetIdentityAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.GetDeviceAsync(deviceId);
        }


    }
}
