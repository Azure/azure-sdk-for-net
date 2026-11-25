// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // The inherited ResourceType already represents the ARM "type" field.
    [CodeGenSuppress("Type")]
    public partial class FirstPartyServiceTagData
    {
    }
}
