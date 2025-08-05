// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    internal class GetIfExistsOperationMethodProvider(
        ResourceCollectionClientProvider collection,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        bool isAsync)
        : ResourceOperationMethodProvider(
            collection,
            collection.ContextualPath,
            restClientInfo,
            method,
            convenienceMethod,
            isAsync,
            methodName: isAsync ? "GetIfExistsAsync" : "GetIfExists",
            description: $"Tries to get details for this resource from the service.")
    {
        protected override CSharpType BuildReturnType()
        {
            return new CSharpType(typeof(NullableResponse<>), _returnBodyType!).WrapAsync(_isAsync);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            // we need to add some null checks before we return the response.
            List<MethodBodyStatement> statements =
            [
                new IfStatement(responseVariable.Property("Value").Equal(Null))
                {
                    Return(
                        New.Instance(
                            new CSharpType(typeof(NoValueResponse<>), _resourceClient!.Type),
                            responseVariable.Invoke("GetRawResponse")
                        )
                    )
                }
            ];

            var returnValueExpression = New.Instance(_resourceClient.Type, This.As<ArmResource>().Client(), responseVariable.Property("Value"));
            statements.Add(
                Return(
                    Static(typeof(Response)).Invoke(
                        nameof(Response.FromValue),
                        returnValueExpression,
                        responseVariable.Invoke("GetRawResponse")
                    )
                )
            );

            return statements;
        }
    }
}
