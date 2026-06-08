// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve the legacy MachineLearning-prefixed collection name.
    [CodeGenType("ModelVersionCollection")]
    public partial class MachineLearningModelVersionCollection
    {
    }
}
