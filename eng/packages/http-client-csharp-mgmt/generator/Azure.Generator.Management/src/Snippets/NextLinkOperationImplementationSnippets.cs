// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Snippets
{
    internal static class NextLinkOperationImplementationSnippets
    {
        public static MethodBodyStatement CreateRehydrationToken(
            ScopedApi<RequestUriBuilder> uriVariable,
            string httpMethod,
            out VariableExpression rehydrationTokenVariable)
        {
            // RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(
            //     RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());

            var requestMethodName = httpMethod switch
            {
                "DELETE" => nameof(RequestMethod.Delete),
                "GET" => nameof(RequestMethod.Get),
                "POST" => nameof(RequestMethod.Post),
                "PUT" => nameof(RequestMethod.Put),
                "PATCH" => nameof(RequestMethod.Patch),
                "HEAD" => nameof(RequestMethod.Head),
                "OPTIONS" => nameof(RequestMethod.Options),
                "TRACE" => nameof(RequestMethod.Trace),
                _ => throw new ArgumentException($"Unsupported HTTP method: {httpMethod}")
            };

            return Declare(
                "rehydrationToken",
                typeof(RehydrationToken),
                Static(typeof(NextLinkOperationImplementation)).Invoke(
                    nameof(NextLinkOperationImplementation.GetRehydrationToken),
                    [
                        Static(typeof(RequestMethod)).Property(requestMethodName),
                        uriVariable.Invoke("ToUri"),
                        uriVariable.InvokeToString(),
                        Literal("None"),
                        Null,
                        Static(typeof(OperationFinalStateVia)).Property(nameof(OperationFinalStateVia.OriginalUri)).InvokeToString()
                    ]),
                out rehydrationTokenVariable);
        }
    }
}
