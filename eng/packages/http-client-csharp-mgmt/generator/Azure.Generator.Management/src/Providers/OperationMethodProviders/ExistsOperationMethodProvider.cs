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
        ParameterContextRegistry parameterMappings,
        RestClientInfo restClientInfo,
        InputServiceMethod method,
        bool isAsync
        )
        : ResourceOperationMethodProvider(
            collection,
            parameterMappings,
            restClientInfo,
            method,
            ResourceOperationKind.CheckExistence,
            isAsync,
            methodName: isAsync ? "ExistsAsync" : "Exists",
            description: $"Checks to see if the resource exists in azure.")
    {
        protected override bool ShouldApplyLroHandling => false;

        protected override CSharpType BuildReturnType()
        {
            return new CSharpType(typeof(Response<>), typeof(bool))
                .WrapAsync(_isAsync);
        }

        protected override IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ScopedApi<Response> responseVariable, MethodSignature signature)
        {
            if (_serviceMethod.Operation.HttpMethod == "HEAD")
            {
                return [Return(ResponseSnippets.FromValue(responseVariable.Property(nameof(Response.Status)).NotEqual(Literal(404)), responseVariable))];
            }

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

        protected override IReadOnlyList<MethodBodyStatement> BuildClientPipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out ScopedApi<Response> responseVariable)
        {
            if (_serviceMethod.Operation.HttpMethod != "HEAD")
            {
                return BuildExistsOperationPipelineProcessing(messageVariable, contextVariable, out responseVariable);
            }

            var sendArguments = new ValueExpression[] { messageVariable, contextVariable.Property(nameof(RequestContext.CancellationToken)) };
            var send = _isAsync
                ? This.Property("Pipeline").Invoke("SendAsync", sendArguments, null, true).Terminate()
                : This.Property("Pipeline").Invoke("Send", sendArguments).Terminate();
            var declaration = Declare("response", typeof(Response), messageVariable.Property("Response"), out var response);
            responseVariable = response.As<Response>();
            var status = response.Property(nameof(Response.Status));
            var isNotSuccess = new BinaryOperatorExpression("<", status, Literal(200)).As<bool>()
                .Or(new BinaryOperatorExpression(">=", status, Literal(300)));
            return [
                send,
                declaration,
                new IfStatement(isNotSuccess.And(status.NotEqual(Literal(404))))
                {
                    Throw(New.Instance(typeof(RequestFailedException), response))
                }
            ];
        }
    }
}
