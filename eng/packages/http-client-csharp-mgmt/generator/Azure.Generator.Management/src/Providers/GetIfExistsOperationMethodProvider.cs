// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
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
        bool isAsync) : ResourceOperationMethodProvider(resourceClientProvider, method, convenienceMethod, isAsync)
    {
        protected override MethodSignature CreateSignature()
        {
            var returnType = new CSharpType(typeof(NullableResponse<>), _resourceClientProvider.ResourceClientCSharpType)
                .WrapAsync(_isAsync);

            return new MethodSignature(
                _isAsync ? "GetIfExistsAsync" : "GetIfExists",
                $"Tries to get details for this resource from the service.",
                _convenienceMethod.Signature.Modifiers,
                returnType,
                _convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            var resourceClientCSharpType = _resourceClientProvider.ResourceClientCSharpType;

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
