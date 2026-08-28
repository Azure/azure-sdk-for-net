// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: replace latest-emitter generated constructor with a base call that matches the discriminated base model.
    [CodeGenSuppress("LabelGeneration", typeof(DataGenerationTaskType))]
    public partial class LabelGeneration
    {
        /// <summary> Initializes a new instance of <see cref="LabelGeneration"/>. </summary>
        /// <param name="dataGenerationTaskType"> [Required] DataGeneration Task type. </param>
        public LabelGeneration(DataGenerationTaskType dataGenerationTaskType)
            : base(dataGenerationTaskType, DataGenerationType.LabelGeneration, teacherModelEndpoint: default)
        {
        }
    }
}
