// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Azure.Generator.Management.Snippets
{
    internal static class ResourceTypeSnippets
    {
        public static ScopedApi<string> Namespace(this ScopedApi<ResourceType> type)
            => type.Property(nameof(ResourceType.Namespace)).As<string>();

        public static ScopedApi<string> Type(this ScopedApi<ResourceType> type)
            => type.Property(nameof(ResourceType.Type)).As<string>();
    }
}
