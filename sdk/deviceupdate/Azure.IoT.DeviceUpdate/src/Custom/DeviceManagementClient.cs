// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceManagementClient
    {
        /// <summary> Initializes a new instance of <see cref="DeviceManagementClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        public DeviceManagementClient(Uri endpoint, string instanceId, global::Azure.Core.TokenCredential credential)
            : this(endpoint?.Authority, instanceId, credential)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeviceManagementClient"/>. </summary>
        /// <param name="endpoint"> The Device Update for IoT Hub account endpoint. </param>
        /// <param name="instanceId"> The Device Update for IoT Hub account instance identifier. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public DeviceManagementClient(Uri endpoint, string instanceId, global::Azure.Core.TokenCredential credential, DeviceUpdateClientOptions options)
            : this(endpoint?.Authority, instanceId, credential, options)
        {
        }
    }
}