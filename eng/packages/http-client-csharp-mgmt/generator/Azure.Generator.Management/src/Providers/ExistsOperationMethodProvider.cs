// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ExistsOperationMethodProvider(
        ResourceClientProvider resourceClientProvider,
        InputServiceMethod method,
        MethodProvider convenienceMethod,
        bool isAsync) : ResourceOperationMethodProvider(resourceClientProvider, method, convenienceMethod, isAsync)
    {
        protected override MethodSignature CreateSignature()
        {
            var returnType = _isAsync
                ? new CSharpType(typeof(Task<>), new CSharpType(typeof(Response<>), typeof(bool)))
                : new CSharpType(typeof(Response<>), typeof(bool));

            return new MethodSignature(
                _isAsync ? "ExistsAsync" : "Exists",
                $"Checks to see if the resource exists in azure.",
                _convenienceMethod.Signature.Modifiers,
                returnType,
                _convenienceMethod.Signature.ReturnDescription,
                _resourceClientProvider.GetOperationMethodParameters(_convenienceMethod, false),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            // For Exists methods, we check if Value is not null and return a boolean
            var returnValueExpression = responseVariable.Property("Value").NotEqual(Null);

            return [
                Return(
                    Static(typeof(Response)).Invoke(
                        nameof(Response.FromValue),
                        returnValueExpression,
                        responseVariable.Invoke("GetRawResponse")
                    )
                )
            ];
        }
    }
}
