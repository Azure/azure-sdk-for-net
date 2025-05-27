// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class GetIfExistsOperationMethodProvider(
        ResourceClientProvider resourceClientProvider,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        MethodSignature signature,
        bool isAsync) : ResourceOperationMethodProvider(resourceClientProvider, method, convenienceMethod, signature, isAsync)
    {
        private readonly ResourceClientProvider _resourceClient = resourceClientProvider;

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            var resourceClientCSharpType = _resourceClient.ResourceClientCSharpType;

            List<MethodBodyStatement> statements =
            [
                new IfStatement(responseVariable.Property("Value").Equal(Null))
                {
                    Return(
                        New.Instance(
                            new CSharpType(typeof(NoValueResponse<>), resourceClientCSharpType),
                            responseVariable.Invoke("GetRawResponse")
                        )
                    )
                }
            ];

            var returnValueExpression = New.Instance(resourceClientCSharpType, This.Property("Client"), responseVariable.Property("Value"));
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
