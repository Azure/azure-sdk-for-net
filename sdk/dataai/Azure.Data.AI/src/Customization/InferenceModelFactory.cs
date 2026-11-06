// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
    // The generator derives the model factory name from the package name
    // (Azure.Data.AI -> AIModelFactory), which is too generic. Rename it to align
    // with the InferenceClient surface.
    [CodeGenType("AIModelFactory")]
    public static partial class InferenceModelFactory
    {
    }
}
