// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("TargetResourceGuid")]
    public partial class FlowLogData { [WirePath("properties.targetResourceGuid")] public Guid? TargetResourceGuid => ResourceGuidCompatibility.Parse(Properties?.TargetResourceGuid); }
}

#pragma warning restore CS1591
