// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.IoT.Hub.Service.Models
{
    public partial class DeviceCapabilities
    {
        /// <summary>
        ///  The property that determines if the device is an edge device or not.
        /// </summary>
        [CodeGenMember("IotEdge")]
        public bool? IsIotEdgeDevice { get; set; }
    }
}
