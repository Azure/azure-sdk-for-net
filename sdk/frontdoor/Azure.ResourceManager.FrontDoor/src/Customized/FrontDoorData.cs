// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.FrontDoor
{
    // Compatibility experiment: removing the spec-side alternateType for Microsoft.Network.Resource
    // makes generated FrontDoorData inherit the generated FrontDoor.Models.Resource type. The shipped
    // SDK inherited TrackedResourceData, so this partial tests whether custom code can restore that
    // base type without putting the alternateType back.
    public partial class FrontDoorData : TrackedResourceData
    {
    }
}
