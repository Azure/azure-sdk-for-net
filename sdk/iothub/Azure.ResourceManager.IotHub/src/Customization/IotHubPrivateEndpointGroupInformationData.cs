// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    // Customization justification:
    // GroupIdInformation is defined in TypeSpec, but its operations are scoped out of C# generation to
    // avoid duplicate data-returning methods on IotHubDescriptionResource. The previous GA .NET SDK
    // exposed private link group information data as ResourceData, so this keeps the C# inheritance shape.
    [CodeGenType("IotHubPrivateEndpointGroupInformation")]
    public partial class IotHubPrivateEndpointGroupInformationData : ResourceData
    {
    }
}
