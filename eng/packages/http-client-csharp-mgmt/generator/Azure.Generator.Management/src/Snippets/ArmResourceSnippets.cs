// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        public static ScopedApi<bool> TryGetApiVersion(this ScopedApi<ArmResource> resource, ValueExpression resourceType, string variableName, out ScopedApi<string> apiVersion)
        {
            var apiVersionVariable = new VariableExpression(typeof(string), variableName);
            var invocation = resource.Invoke("TryGetApiVersion", resourceType, new DeclarationExpression(apiVersionVariable, IsOut: true));
            apiVersion = apiVersionVariable.As<string>();
            return invocation.As<bool>();
        }

        public static ValueExpression GetCachedClient(this ScopedApi<ArmResource> resource, CodeWriterDeclaration client, Func<ScopedApi<ArmClient>, ValueExpression> factory)
        {
            var f = new FuncExpression([client], factory(new VariableExpression(typeof(ArmClient), client).As<ArmClient>()));
            return resource.Invoke(nameof(ArmResource.GetCachedClient), f);
        }

        /// <summary>
        /// Constructs a method expression that calls the ValidateResourceId method on the ArmResource type.
        /// Note: this method is a static method, the <paramref name="type"/> must be a static type reference of the type.
        /// Also the abstract class ArmResource does not have a ValidateResourceId method, but our generated ArmResource's derived classes will always have one.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static InvokeMethodExpression ValidateResourceId(this ScopedApi<ArmResource> type, ValueExpression id)
            => type.Invoke("ValidateResourceId", id);
    }
}
