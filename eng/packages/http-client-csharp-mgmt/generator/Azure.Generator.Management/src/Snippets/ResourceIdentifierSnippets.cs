// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
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

        public static ScopedApi<string> SubscriptionId(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.SubscriptionId)).As<string>();

        public static ScopedApi<string> ResourceGroupName(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.ResourceGroupName)).As<string>();

        public static ScopedApi<string> Name(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.Name)).As<string>();

        public static ScopedApi<ResourceIdentifier> Parent(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.Parent)).As<ResourceIdentifier>();

        public static ScopedApi<string> Provider(this ScopedApi<ResourceIdentifier> resourceIdentifier)
            => resourceIdentifier.Property(nameof(ResourceIdentifier.Provider)).As<string>();

        public static ScopedApi<ResourceIdentifier> AppendProviderResource(
            this ScopedApi<ResourceIdentifier> resourceIdentifier,
            ValueExpression providerNamespace,
            ValueExpression resourceType,
            ValueExpression resourceName)
        {
            return resourceIdentifier.Invoke(
                nameof(ResourceIdentifier.AppendProviderResource),
                [providerNamespace, resourceType, resourceName])
                .As<ResourceIdentifier>();
        }

        public static ScopedApi<ResourceIdentifier> AppendChildResource(
            this ScopedApi<ResourceIdentifier> resourceIdentifier,
            ValueExpression childResourceType,
            ValueExpression childResourceName)
        {
            return resourceIdentifier.Invoke(
                nameof(ResourceIdentifier.AppendChildResource),
                [childResourceType, childResourceName])
                .As<ResourceIdentifier>();
        }
    }
}
