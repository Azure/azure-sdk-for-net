// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("ResourceGuid")]
    public partial class NetworkManagerSecurityUserConfigurationData { [WirePath("properties.resourceGuid")] public Guid? ResourceGuid => ResourceGuidCompatibility.Parse(Properties?.ResourceGuid); }
}

#pragma warning restore CS1591
