// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers
{
    // Preserve the released managed-environment collection name after the stable API added
    // a second private endpoint connection resource under container apps.
    [CodeGenType("ManagedEnvironmentPrivateEndpointConnectionCollection")]
    public partial class ContainerAppPrivateEndpointConnectionCollection
    {
    }
}
