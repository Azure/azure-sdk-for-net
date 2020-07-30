// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Iot.Hub.Service.Models
{
    public partial class DeviceCapabilities
    {
        [CodeGenMember("IotEdge")]
        public bool? IsIotEdgeDevice { get; set; }
    }
}
