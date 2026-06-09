// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    [CodeGenSuppress("ComponentId")]
    public partial class BatchPipelineComponentDeploymentConfiguration
    {
        /// <summary> The ARM id of the component to be run. </summary>
        [WirePath("componentId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningIdAssetReference ComponentId { get; set; }
    }
}
