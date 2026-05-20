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
    internal class CheckExistenceOperationMethodProvider(
        ResourceClientProvider resource,
        OperationContext operationContext,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        bool isAsync,
        string? methodName)
        : ResourceOperationMethodProvider(
            resource,
            operationContext,
            restClientInfo,
            method,
            isAsync,
            methodName: methodName)
    {
        protected override bool ShouldApplyLroHandling => false;

        protected override CSharpType BuildReturnType()
        {
            return new CSharpType(typeof(Response<>), typeof(bool))
                .WrapAsync(_isAsync);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildClientPipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out ScopedApi<Response> responseVariable)
        {
            var statements = new List<MethodBodyStatement>();

            var sendMethod = _isAsync ? "SendAsync" : "Send";
            var sendArguments = new ValueExpression[] { messageVariable, contextVariable.Property("CancellationToken") };

            var sendStatement = _isAsync
                ? This.Property("Pipeline").Invoke(sendMethod, sendArguments, null, _isAsync).Terminate()
                : This.Property("Pipeline").Invoke(sendMethod, sendArguments).Terminate();
            statements.Add(sendStatement);

            statements.Add(Declare(
                "response",
                typeof(Response),
                messageVariable.Property("Response"),
                out var responseVar));
            responseVariable = responseVar.As<Response>();

            var status = responseVar.Property("Status");
            var successCondition = new BinaryOperatorExpression(
                "&&",
                new BinaryOperatorExpression(">=", status, Literal(200)),
                new BinaryOperatorExpression("<", status, Literal(300)));
            var clientErrorCondition = new BinaryOperatorExpression(
                "&&",
                new BinaryOperatorExpression(">=", status, Literal(400)),
                new BinaryOperatorExpression("<", status, Literal(500)));

            statements.Add(new IfElseStatement(
                successCondition,
                new MethodBodyStatements([
                    Return(ResponseSnippets.FromValue(Literal(true), responseVar))
                ]),
                new MethodBodyStatements([
                    new IfElseStatement(
                        clientErrorCondition,
                        new MethodBodyStatements([
                            Return(ResponseSnippets.FromValue(Literal(false), responseVar))
                        ]),
                        new MethodBodyStatements([
                            Throw(New.Instance(typeof(RequestFailedException), responseVar))
                        ]))
                ])));

            return statements;
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ScopedApi<Response> responseVariable, MethodSignature signature)
        {
            return [];
        }
    }
}
