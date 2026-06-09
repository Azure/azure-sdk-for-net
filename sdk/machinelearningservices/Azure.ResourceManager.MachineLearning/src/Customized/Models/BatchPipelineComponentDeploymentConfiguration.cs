// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    [CodeGenSuppress("ComponentId")]
    public partial class BatchPipelineComponentDeploymentConfiguration
    {
        // Customized: TypeSpec property renaming is not applied to this generated property declaration.
        [WirePath("componentId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningIdAssetReference ComponentId { get; set; }
    }
}
