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
        internal const string WireV3OptionsName = "WireV3Options";
        internal const string JsonV3OptionsName = "JsonV3Options";

        public static readonly ScopedApi<ModelReaderWriterOptions> Wire = Static<ModelSerializationExtensionsDefinition>().Property(WireOptionsName).As<ModelReaderWriterOptions>();
        public static readonly ScopedApi<ModelReaderWriterOptions> WireV3 = Static<ModelSerializationExtensionsDefinition>().Property(WireV3OptionsName).As<ModelReaderWriterOptions>();
        public static readonly ScopedApi<ModelReaderWriterOptions> JsonV3 = Static<ModelSerializationExtensionsDefinition>().Property(JsonV3OptionsName).As<ModelReaderWriterOptions>();
    }
}
