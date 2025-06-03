// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Snippets
{
    internal static class ResourceIdentifierSnippets
    {
        public static ScopedApi<ResourceIdentifier> Root()
            => Static<ResourceIdentifier>().Property(nameof(ResourceIdentifier.Root)).As<ResourceIdentifier>();

        public static ScopedApi<ResourceType> ResourceType(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.ResourceType)).As<ResourceType>();
    }
}
