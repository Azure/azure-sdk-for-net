// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AIInfraOptimization.Models
{
    // Avoid the reserved Option suffix without changing the service's TypeSpec model.
    [CodeGenType("RecommendVmSkuOption")]
    public partial class AIInfraOptimizationRecommendVmSkuOptionConfig
    {
        // Use the .NET boolean naming convention while preserving the wire property.
        /// <summary> Whether the Azure Machine Learning model catalog recommends this virtual machine size for the model. </summary>
        [CodeGenMember("AzureMlRecommended")]
        public bool? IsAzureMlRecommended { get; }
    }
}
