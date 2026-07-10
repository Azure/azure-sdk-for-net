// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.FrontDoor.Models
{
    // The shipped SDK inherited FrontDoorResourceData. This partial restores that base type after
    // removing the spec-side C# replacement model declaration for HealthProbeSettingsModel.
    // Suppress the generated Type property because FrontDoorResourceData.ResourceType already owns
    // the "type" wire path; keeping both writes duplicate "type" values. See https://github.com/Azure/azure-sdk-for-net/issues/60378.
    [CodeGenSuppress("Type", typeof(string))]
    public partial class FrontDoorHealthProbeSettingsData : FrontDoorResourceData
    {
    }
}
