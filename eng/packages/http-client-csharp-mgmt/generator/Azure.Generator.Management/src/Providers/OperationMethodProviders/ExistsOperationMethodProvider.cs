// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class ExistsOperationMethodProvider(
        ResourceCollectionClientProvider collection,
        RequestPathPattern contextualPath,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        bool isAsync)
        : ResourceOperationMethodProvider(
            collection,
            contextualPath,
            restClientInfo,
            method,
            isAsync,
            methodName: isAsync ? "ExistsAsync" : "Exists",
            description: $"Checks to see if the resource exists in azure.")
    {
        protected override CSharpType BuildReturnType()
        {
            return new CSharpType(typeof(Response<>), typeof(bool))
                .WrapAsync(_isAsync);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ScopedApi<Response> responseVariable, MethodSignature signature)
        {
            // For Exists methods, we check if Value is not null and return a boolean
            var returnValueExpression = responseVariable.Value().NotEqual(Null);

            return [
                Return(
                    ResponseSnippets.FromValue(
                        returnValueExpression,
                        responseVariable.GetRawResponse()
                    )
                )
            ];
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildClientPipelineHandling(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out ScopedApi<Response> responseVariable)
        {
            return BuildExistsOperationPipelineHandling(messageVariable, contextVariable, out responseVariable);
        }
    }
}
