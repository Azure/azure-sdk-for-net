// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Utilities
{
    internal static class ResourceHelpers
    {
        public static string GetClientDiagnosticFieldName(string resourceName)
        {
            var fieldName = $"{resourceName}ClientDiagnostics".ToVariableName();

            return $"_{fieldName}";
        }

        public static string GetRestClientFieldName(string restClientName)
        {
            var fieldName = $"{restClientName}RestClient".ToVariableName();
            return $"_{fieldName}";
        }

        public static ScopedApi<bool> BuildTryGetApiVersionInvocation(string resourceName, ValueExpression resourceType, out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{resourceName}ApiVersion".ToVariableName());
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = This.Invoke("TryGetApiVersion", resourceType, new DeclarationExpression(apiVersionDeclaration, true));
            return invocation.As<bool>();
        }
    }
}
