// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ContainerNetworkInterfaceConfiguration type. </summary>
    [CodeGenSuppress("ContainerNetworkInterfaces")]
    public partial class ContainerNetworkInterfaceConfiguration
    {
        /// <summary> Gets or sets the ContainerNetworkInterfaces compatibility property. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.containerNetworkInterfaces")]
        public IList<WritableSubResource> ContainerNetworkInterfaces => Azure.ResourceManager.Network.WritableSubResourceCollectionCompatibility.AsList(Properties?.ContainerNetworkInterfaces);
    }
}
