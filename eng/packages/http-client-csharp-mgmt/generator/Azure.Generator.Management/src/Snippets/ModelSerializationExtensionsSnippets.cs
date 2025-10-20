// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System.ClientModel.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Snippets
{
    internal static class ModelSerializationExtensionsSnippets
    {
        private const string WireOptionsName = "WireOptions";

        public static readonly ScopedApi<ModelReaderWriterOptions> Wire = Static<ModelSerializationExtensionsDefinition>().Property(WireOptionsName).As<ModelReaderWriterOptions>();
    }
}
