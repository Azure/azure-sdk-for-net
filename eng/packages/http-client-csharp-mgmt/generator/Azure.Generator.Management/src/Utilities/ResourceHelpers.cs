// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static ScopedApi<bool> BuildTryGetApiVersionInvocation(string resourceName, ValueExpression resourceType, out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{resourceName}ApiVersion".ToVariableName());
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = This.Invoke("TryGetApiVersion", resourceType, new DeclarationExpression(apiVersionDeclaration, true));
            return invocation.As<bool>();
        }
    }
}
