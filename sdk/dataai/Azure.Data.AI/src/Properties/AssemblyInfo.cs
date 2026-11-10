// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

[assembly: Azure.Core.AzureResourceProviderNamespace("Microsoft.InferenceService")]

namespace Azure.Data.AI
{
    // Generic .NET name for the TypeSpec EmbeddingData base (AZC0032 forbids the 'Data' suffix).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("EmbeddingData")]
    public abstract partial class EmbeddingItem
    {
    }
}
