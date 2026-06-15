// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkAdminRule { [Azure.ResourceManager.Network.WirePath("properties.resourceGuid")] public Guid? ResourceGuid => Azure.ResourceManager.Network.ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
}

#pragma warning restore CS1591
