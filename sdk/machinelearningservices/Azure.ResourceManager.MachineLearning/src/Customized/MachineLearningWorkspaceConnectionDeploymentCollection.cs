// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: keep the deployment collection name aligned with the customized
    // MachineLearningWorkspaceConnectionDeploymentResource type.
    [CodeGenType("ConnectionCollection")]
    public partial class MachineLearningWorkspaceConnectionDeploymentCollection
    {
    }
}
