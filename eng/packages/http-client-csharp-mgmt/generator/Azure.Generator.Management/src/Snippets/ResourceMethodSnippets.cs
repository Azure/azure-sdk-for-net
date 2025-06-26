// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using ProviderParameterProvider = Microsoft.TypeSpec.Generator.Providers.ParameterProvider;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using Microsoft.TypeSpec.Generator.Snippets;

namespace Azure.Generator.Management.Snippets
{
    internal static class ResourceMethodSnippets
    {
        public static CatchExpression CreateDiagnosticCatchBlock(VariableExpression scopeVariable)
        {
            // Generate catch block:
            // catch (Exception e)
            // {
            //     scope.Failed(e);
            //     throw;
            // }
            return Catch(
                Declare("e", typeof(Exception), out var exceptionVar),
                [
                    scopeVariable.Invoke("Failed", [exceptionVar]).Terminate(),
                    Throw()
                ]);
        }

        public static List<MethodBodyStatement> CreateDiagnosticScopeStatements(
            ResourceClientProvider resourceClientProvider,
            string operationName,
            out VariableExpression scopeVariable)
        {
            var statements = new List<MethodBodyStatement>();

            // using var scope = _clientDiagnostics.CreateScope("ResourceName.OperationName");
            var clientDiagnosticsField = resourceClientProvider.GetClientDiagnosticsField();
            var scopeDeclaration = UsingDeclare(
                "scope",
                typeof(DiagnosticScope),
                clientDiagnosticsField.Invoke("CreateScope", [Literal($"{resourceClientProvider.Name}.{operationName}")]),
                out scopeVariable);
            statements.Add(scopeDeclaration);

            // scope.Start();
            statements.Add(scopeVariable.Invoke("Start").Terminate());

            return statements;
        }

        // TODO: The generated code has format issue https://github.com/microsoft/typespec/issues/7283
        public static MethodBodyStatement CreateRequestContext(
            ProviderParameterProvider cancellationTokenParam,
            out VariableExpression contextVariable)
        {
            var requestContextParams = new Dictionary<ValueExpression, ValueExpression>
            {
                { Identifier(nameof(RequestContext.CancellationToken)), cancellationTokenParam }
            };

            //        RequestContext context = new RequestContext
            //        {
            //            CancellationToken = cancellationToken
            //        }
            //        ;
            return Declare("context", typeof(RequestContext), New.Instance(typeof(RequestContext), requestContextParams), out contextVariable);
        }

        public static MethodBodyStatement CreateUriFromMessage(VariableExpression messageVariable, out VariableExpression uriVariable)
        {
            // Uri uri = message.Request.Uri;
            return Declare(
                "uri",
                typeof(RequestUriBuilder),
                messageVariable.Property("Request").Property("Uri"),
                out uriVariable);
        }

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

        public static MethodBodyStatement CreateHttpMessage(
            ResourceClientProvider resourceClientProvider,
            string methodName,
            ValueExpression[] arguments,
            out VariableExpression messageVariable)
        {
            // HttpMessage message = _restClient.{methodName}(...arguments);
            return Declare(
                "message",
                typeof(HttpMessage),
                resourceClientProvider.GetRestClientField().Invoke(methodName, arguments),
                out messageVariable);
        }

        public static IReadOnlyList<MethodBodyStatement> CreateGenericResponsePipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            CSharpType responseGenericType,
            bool isAsync,
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>();
            var pipelineInvoke = isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            // Response result = this.Pipeline.ProcessMessage(message, context);
            var resultDeclaration = Declare(
                "result",
                typeof(Response),
                This.Property("Pipeline").Invoke(pipelineInvoke, [messageVariable, contextVariable], null, isAsync),
                out var resultVariable);
            statements.Add(resultDeclaration);

            // Response<T> response = Response.FromValue((T)result, result);
            var responseDeclaration = Declare(
                "response",
                new CSharpType(typeof(Response<>), responseGenericType),
                Static(typeof(Response)).Invoke(
                    nameof(Response.FromValue),
                    [resultVariable.CastTo(responseGenericType), resultVariable]),
                out responseVariable);
            statements.Add(responseDeclaration);

            return statements;
        }

        public static IReadOnlyList<MethodBodyStatement> CreateNonGenericResponsePipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            bool isAsync,
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>();
            var pipelineInvoke = isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            // Response response = this.Pipeline.ProcessMessage(message, context);
            var responseDeclaration = Declare(
                "response",
                typeof(Response),
                This.Property("Pipeline").Invoke(pipelineInvoke, [messageVariable, contextVariable], null, isAsync),
                out responseVariable);
            statements.Add(responseDeclaration);

            return statements;
        }
    }
}
