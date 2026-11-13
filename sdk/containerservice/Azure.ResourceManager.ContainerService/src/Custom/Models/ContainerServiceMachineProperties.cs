// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ContainerService;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ContainerServiceMachineProperties
    {
        /// <summary>
        /// IPv4, IPv6 addresses of the machine
        /// </summary>
        [WirePath("network.ipAddresses")]
        public IReadOnlyList<ContainerServiceMachineIPAddress> NetworkIPAddresses
        {
            get => Network?.IPAddresses;
        }
    }
}
