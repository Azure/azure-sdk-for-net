// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore the previous public feature data constructor and settable properties
    // that are not emitted by the TypeSpec-generated resource data model.
    [CodeGenSuppress("MachineLearningFeatureData", typeof(MachineLearningFeatureProperties))]
    public partial class MachineLearningFeatureData
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningFeatureData"/>. </summary>
        /// <param name="properties"> [Required] Additional attributes of the entity. </param>
        public MachineLearningFeatureData(MachineLearningFeatureProperties properties)
        {
            Properties = properties;
        }

        /// <summary> [Required] Additional attributes of the entity. </summary>
        [CodeGenMember("Properties")]
        [WirePath("properties")]
        public MachineLearningFeatureProperties Properties { get; set; }
    }
}
