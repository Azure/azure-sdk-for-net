// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class EdgeMachineProperties
    {
        /// <summary> The device pool resource identifier. </summary>
        [CodeGenMember("DevicePoolResourceId")]
        public ResourceIdentifier DevicePoolResourceId { get; }
    }
}
