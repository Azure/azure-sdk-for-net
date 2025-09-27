// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class GetIfExistsOperationMethodProvider(
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
            methodName: isAsync ? "GetIfExistsAsync" : "GetIfExists",
            description: $"Tries to get details for this resource from the service.")
    {
        protected override CSharpType BuildReturnType()
        {
            return new CSharpType(typeof(NullableResponse<>), _returnBodyType!).WrapAsync(_isAsync);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ScopedApi<Response> responseVariable, MethodSignature signature)
        {
            // we need to add some null checks before we return the response.
            List<MethodBodyStatement> statements =
            [
                new IfStatement(responseVariable.Value().Equal(Null))
                {
                    Return(
                        New.Instance(
                            new CSharpType(typeof(NoValueResponse<>), _returnBodyResourceClient!.Type),
                            responseVariable.GetRawResponse()
                        )
                    )
                }
            ];

            var returnValueExpression = New.Instance(_returnBodyResourceClient.Type, This.As<ArmResource>().Client(), responseVariable.Value());
            statements.Add(
                Return(
                    ResponseSnippets.FromValue(
                        returnValueExpression,
                        responseVariable.GetRawResponse()
                    )
                )
            );

            return statements;
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
