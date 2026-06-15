// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Location")]
    [CodeGenSuppress("Tags")]
    public partial class ConnectionMonitorContent
    {
    }
}
