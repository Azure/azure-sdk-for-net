// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Azure.Generator.Management.Snippets
{
    internal static class ResourceIdentifierSnippets
    {
        public static ScopedApi<ResourceIdentifier> Root(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property("Root").As<ResourceIdentifier>();
    }
}
