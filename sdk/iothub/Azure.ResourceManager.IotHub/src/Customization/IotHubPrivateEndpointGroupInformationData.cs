// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // GroupIdInformation remains a plain TypeSpec model to preserve the generated swagger shape. The
    // previous GA .NET SDK exposed private link group information data as ResourceData, so this SDK-side
    // customization keeps the C# inheritance without changing the service TypeSpec model.
    [CodeGenType("IotHubPrivateEndpointGroupInformation")]
    public partial class IotHubPrivateEndpointGroupInformationData : ResourceData
    {
    }
}
