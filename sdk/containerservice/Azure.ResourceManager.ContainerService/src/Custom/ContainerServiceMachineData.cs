// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class ContainerServiceMachineData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerServiceMachineData"/>. </summary>
        public ContainerServiceMachineData()
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> The properties of the machine. </summary>
        [WirePath("properties")]
        public ContainerServiceMachineProperties Properties { get; set; }
    }
}
