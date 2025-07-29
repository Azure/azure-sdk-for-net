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
    internal static class ArmCollectionSnippets
    {
        public static ScopedApi<ResourceIdentifier> Id(this ScopedApi<ArmCollection> collection)
            => collection.Property(nameof(ArmCollection.Id)).As<ResourceIdentifier>();

        public static ScopedApi<ArmClient> Client(this ScopedApi<ArmCollection> collection)
            => collection.Property("Client").As<ArmClient>();

        public static ScopedApi<ClientDiagnostics> Diagnostics(this ScopedApi<ArmCollection> collection)
            => collection.Property("Diagnostics").As<ClientDiagnostics>();

        public static ScopedApi<HttpPipeline> Pipeline(this ScopedApi<ArmCollection> collection)
            => collection.Property("Pipeline").As<HttpPipeline>();

        public static ScopedApi<Uri> Endpoint(this ScopedApi<ArmCollection> collection)
            => collection.Property("Endpoint").As<Uri>();

        public static ScopedApi<bool> TryGetApiVersion(this ScopedApi<ArmCollection> collection, ValueExpression resourceType, string variableName, out ScopedApi<string> apiVersion)
        {
            var apiVersionVariable = new VariableExpression(typeof(string), variableName);
            var invocation = collection.Invoke("TryGetApiVersion", resourceType, new DeclarationExpression(apiVersionVariable, IsOut: true));
            apiVersion = apiVersionVariable.As<string>();
            return invocation.As<bool>();
        }

        public static ValueExpression GetCachedClient(this ScopedApi<ArmCollection> collection, CodeWriterDeclaration client, Func<ScopedApi<ArmClient>, ValueExpression> factory)
        {
            var f = new FuncExpression([client], factory(new VariableExpression(typeof(ArmClient), client).As<ArmClient>()));
            return collection.Invoke(nameof(ArmCollection.GetCachedClient), f);
        }

        /// <summary>
        /// Constructs a method expression that calls the ValidateResourceId method on the ArmCollection type.
        /// Note: this method is a static method, the <paramref name="type"/> must be a static type reference of the type.
        /// Also the abstract class ArmCollection does not have a ValidateResourceId method, but our generated ArmCollection's derived classes will always have one.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static InvokeMethodExpression ValidateResourceId(this ScopedApi<ArmCollection> type, ValueExpression id)
            => type.Invoke("ValidateResourceId", id);
    }
}
