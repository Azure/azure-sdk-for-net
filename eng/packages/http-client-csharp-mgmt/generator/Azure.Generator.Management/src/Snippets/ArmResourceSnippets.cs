// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using System;

namespace Azure.Generator.Management.Snippets
{
    internal static class ArmResourceSnippets
    {
        public static ScopedApi<ArmClient> Client(this ScopedApi<ArmResource> resource)
            => resource.Property("Client").As<ArmClient>();

        public static ScopedApi<ResourceIdentifier> Id(this ScopedApi<ArmResource> resource)
            => resource.Property(nameof(ArmResource.Id)).As<ResourceIdentifier>();

        public static ScopedApi<ClientDiagnostics> Diagnostics(this ScopedApi<ArmResource> resource)
            => resource.Property("Diagnostics").As<ClientDiagnostics>();

        public static ScopedApi<HttpPipeline> Pipeline(this ScopedApi<ArmResource> resource)
            => resource.Property("Pipeline").As<HttpPipeline>();

        public static ScopedApi<Uri> Endpoint(this ScopedApi<ArmResource> resource)
            => resource.Property("Endpoint").As<Uri>();

        /// <summary>
        /// Returns the "ResourceType" property on an ArmResource.
        /// Note: the abstract class ArmResource does not have a ResourceType property, but our generated ArmResource's derived classes will always have one.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public static ScopedApi<ResourceType> ResourceType(this ScopedApi<ArmResource> resource)
            => resource.Property("ResourceType").As<ResourceType>();

        public static ValueExpression GetCachedClient(this ScopedApi<ArmResource> resource, CodeWriterDeclaration client, Func<ScopedApi<ArmClient>, ValueExpression> factory)
        {
            var f = new FuncExpression([client], factory(new VariableExpression(typeof(ArmClient), client).As<ArmClient>()));
            return resource.Invoke(nameof(ArmResource.GetCachedClient), f);
        }
    }
}
