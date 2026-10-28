// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // Native generation loses the released NetworkTrackedResourceData inheritance (ApiCompat CP0007).
    [CodeGenSuppress("NamePropertiesName")]
    [CodeGenSuppress("PropertiesETag")]
    public partial class VpnServerConfigurationData : NetworkTrackedResourceData { }
}
