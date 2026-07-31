using System;

namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceUpdateClient
    {
        /// <summary> Initializes a new instance of <see cref="DeviceUpdateClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        public DeviceUpdateClient(Uri endpoint, string instanceId, global::Azure.Core.TokenCredential credential)
            : this(endpoint?.Authority, instanceId, credential)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeviceUpdateClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public DeviceUpdateClient(Uri endpoint, string instanceId, global::Azure.Core.TokenCredential credential, DeviceUpdateClientOptions options)
            : this(endpoint?.Authority, instanceId, credential, options)
        {
        }
    }
}