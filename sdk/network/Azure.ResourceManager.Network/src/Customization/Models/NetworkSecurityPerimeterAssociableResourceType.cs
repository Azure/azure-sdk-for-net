// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Without suppression, the generator emits a flattened string ResourceType that collides with ResourceData.ResourceType.
    // Keep the inherited ResourceData metadata instead of exposing the service field as ARM metadata.
    [CodeGenSuppress("ResourceType")]
    public partial class NetworkSecurityPerimeterAssociableResourceType
    {
    }
}
