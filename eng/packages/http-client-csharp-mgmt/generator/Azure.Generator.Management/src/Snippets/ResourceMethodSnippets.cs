// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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
            TypeProvider enclosingType,
            ValueExpression clientDiagnostics,
            string scopeName,
            out VariableExpression scopeVariable)
        {
            var statements = new List<MethodBodyStatement>();

            // using var scope = _clientDiagnostics.CreateScope("ResourceName.OperationName");
            var scopeDeclaration = UsingDeclare(
                "scope",
                typeof(DiagnosticScope),
                clientDiagnostics.Invoke("CreateScope", [Literal($"{enclosingType.Name}.{scopeName}")]),
                out scopeVariable);
            statements.Add(scopeDeclaration);

            // scope.Start();
            statements.Add(scopeVariable.Invoke("Start").Terminate());

            return statements;
        }

        public static MethodBodyStatement CreateRequestContext(
            ParameterProvider cancellationTokenParam,
            out VariableExpression contextVariable)
        {
            var requestContextParams = new Dictionary<ValueExpression, ValueExpression>
            {
                { Identifier(nameof(RequestContext.CancellationToken)), cancellationTokenParam }
            };

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

        public static MethodBodyStatement CreateHttpMessage(
            ValueExpression restClient,
            string methodName,
            IReadOnlyList<ValueExpression> arguments,
            out VariableExpression messageVariable)
        {
            // HttpMessage message = _restClient.{methodName}(...arguments);
            return Declare(
                "message",
                typeof(HttpMessage),
                restClient.Invoke(methodName, arguments),
                out messageVariable);
        }

        public static IReadOnlyList<MethodBodyStatement> CreateGenericResponsePipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            CSharpType responseGenericType,
            bool isAsync,
            out ScopedApi<Response> responseVariable)
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
                    [Static(responseGenericType).Invoke(SerializationVisitor.FromResponseMethodName, [resultVariable]), resultVariable]),
                out var responseVar);
            responseVariable = responseVar.As<Response>();
            statements.Add(responseDeclaration);

            return statements;
        }

        public static IReadOnlyList<MethodBodyStatement> CreateNonGenericResponsePipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            bool isAsync,
            out ScopedApi<Response> responseVariable)
        {
            var statements = new List<MethodBodyStatement>();
            var pipelineInvoke = isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            // Response response = this.Pipeline.ProcessMessage(message, context);
            var responseDeclaration = Declare(
                "response",
                typeof(Response),
                This.Property("Pipeline").Invoke(pipelineInvoke, [messageVariable, contextVariable], null, isAsync),
                out var responseVar);
            responseVariable = responseVar.As<Response>();
            statements.Add(responseDeclaration);

            return statements;
        }

        public static MethodProvider BuildValidateResourceIdMethod(TypeProvider enclosingType, ValueExpression resourceType)
        {
            var idParameter = new ParameterProvider("id", $"", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                "ValidateResourceId",
                null,
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                null,
                null,
                [idParameter],
                [new AttributeStatement(typeof(ConditionalAttribute), Literal("DEBUG"))]);
            var bodyStatements = new IfStatement(idParameter.As<ResourceIdentifier>().ResourceType().NotEqual(resourceType))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.As<ResourceIdentifier>().ResourceType(), resourceType), false))
            };
            return new MethodProvider(signature, bodyStatements, enclosingType);
        }
    }
}
