// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: the generated name ConnectionResource is too generic for deployments under
    // workspace connections, and TypeSpec cannot give the operation group the same client name
    // as the deployment data model. Map the generated resource to a contextual public name.
    [CodeGenType("ConnectionResource")]
    public partial class MachineLearningWorkspaceConnectionDeploymentResource
    {
    }
}
