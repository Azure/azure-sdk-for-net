// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Expressions;
using Azure.Generator.Management.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.TagMethodProviders
{
    internal abstract class BaseTagMethodProvider
    {
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;
        protected readonly TypeProvider _enclosingType;
        protected readonly ResourceClientProvider _resourceClientProvider;
        protected readonly bool _isAsync;

        protected BaseTagMethodProvider(
            ResourceClientProvider resourceClientProvider,
            bool isAsync)
        {
            _resourceClientProvider = resourceClientProvider;
            _enclosingType = resourceClientProvider;
            _isAsync = isAsync;
            _signature = CreateMethodSignature();
            _bodyStatements = BuildBodyStatements();
        }

        protected abstract MethodSignature CreateMethodSignature();
        protected abstract ParameterProvider[] BuildParameters();
        protected abstract MethodBodyStatement[] BuildBodyStatements();

        protected MethodSignature CreateMethodSignatureCore(string methodName, string description)
        {
            var returnType = new CSharpType(typeof(Azure.Response<>), _resourceClientProvider.ResourceClientCSharpType).WrapAsync(_isAsync);
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual;
            if (_isAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }

            return new MethodSignature(
                methodName,
                $"{description}",
                modifiers,
                returnType,
                null,
                BuildParameters(),
                null,
                null,
                null,
                null,
                null);
        }

        /// <summary>
        /// Creates diagnostic scope declaration and start statements that can be shared among derived classes.
        /// </summary>
        /// <param name="resourceClientProvider">The resource client provider.</param>
        /// <param name="operationName">The operation name for the scope.</param>
        /// <param name="scopeVariable">Output parameter for the scope variable.</param>
        /// <returns>List of statements containing scope declaration and start.</returns>
        protected static List<MethodBodyStatement> CreateDiagnosticScopeStatements(
            ResourceClientProvider resourceClientProvider,
            string operationName,
            out VariableExpression scopeVariable)
        {
            var statements = new List<MethodBodyStatement>();

            // using var scope = _clientDiagnostics.CreateScope("ResourceName.OperationName");
            var clientDiagnosticsField = resourceClientProvider.GetClientDiagnosticsField();
            var scopeDeclaration = UsingDeclare(
                "scope",
                typeof(Azure.Core.Pipeline.DiagnosticScope),
                clientDiagnosticsField.Invoke("CreateScope", [Literal($"{resourceClientProvider.Name}.{operationName}")]),
                out scopeVariable);
            statements.Add(scopeDeclaration);

            // scope.Start();
            statements.Add(scopeVariable.Invoke("Start").Terminate());

            return statements;
        }

        /// <summary>
        /// Creates the condition expression for checking if CanUseTagResource method should be called.
        /// Generates: this.CanUseTagResource(cancellationToken) or await this.CanUseTagResourceAsync(cancellationToken)
        /// </summary>
        /// <param name="isAsync">Whether to use the async version of the method.</param>
        /// <param name="cancellationTokenParam">The cancellation token parameter.</param>
        /// <returns>The method invocation expression for the condition.</returns>
        protected static ValueExpression CreateCanUseTagResourceCondition(
            bool isAsync,
            ParameterProvider cancellationTokenParam)
        {
            // Determine method name based on async/sync pattern
            // For sync: "CanUseTagResource"
            // For async: "CanUseTagResourceAsync"
            var canUseTagResourceMethod = isAsync ? "CanUseTagResourceAsync" : "CanUseTagResource";

            // Generate method invocation expression:
            // Sync: this.CanUseTagResource(cancellationToken)
            // Async: await this.CanUseTagResourceAsync(cancellationToken)
            return This.Invoke(canUseTagResourceMethod, [cancellationTokenParam], null, isAsync);
        }

        /// <summary>
        /// Creates a catch block for handling exceptions in tag operations.
        /// Generates: catch (Exception e) { scope.Failed(e); throw; }
        /// </summary>
        /// <param name="scopeVariable">The diagnostic scope variable to call Failed on.</param>
        /// <returns>The catch block statement.</returns>
        protected static CatchExpression CreateDiagnosticCatchBlock(VariableExpression scopeVariable)
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

        /// <summary>
        /// Creates statements for RequestContext creation, HttpMessage creation, and Pipeline processing.
        /// This pattern is common across all tag method providers for retrieving current resource state.
        /// </summary>
        /// <param name="resourceClientProvider">The resource client provider containing REST client access.</param>
        /// <param name="isAsync">Whether to use async pipeline processing.</param>
        /// <param name="cancellationTokenParam">The cancellation token parameter.</param>
        /// <param name="contextVariable">Output variable for the RequestContext.</param>
        /// <param name="messageVariable">Output variable for the HttpMessage.</param>
        /// <param name="resultVariable">Output variable for the pipeline processing result.</param>
        /// <returns>List of method body statements for the RequestContext/HttpMessage/Pipeline pattern.</returns>
        protected static List<MethodBodyStatement> CreateRequestContextAndProcessMessage(
            ResourceClientProvider resourceClientProvider,
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out VariableExpression contextVariable,
            out VariableExpression messageVariable,
            out VariableExpression resultVariable)
        {
            var pipelineMethod = isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            var statements = new List<MethodBodyStatement>();

            var requestContextParams = new Dictionary<ValueExpression, ValueExpression>
            {
                { Identifier(nameof(RequestContext.CancellationToken)), cancellationTokenParam }
            };

            //        RequestContext context = new RequestContext
            //        {
            //            CancellationToken = cancellationToken
            //        }
            //        ;
            statements.Add(Declare("context", typeof(RequestContext), New.Instance(typeof(RequestContext), requestContextParams), out contextVariable));

            // HttpMessage message = _restClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
            statements.Add(Declare(
                "message",
                typeof(Azure.Core.HttpMessage),
                resourceClientProvider.GetRestClientField().Invoke("CreateGetRequest", [
                    Static(typeof(Guid)).Invoke("Parse", [This.Property("Id").Property("SubscriptionId")]),
                    This.Property("Id").Property("ResourceGroupName"),
                    This.Property("Id").Property("Name"),
                    contextVariable
                ]),
                out messageVariable));

            // Response result = Pipeline.ProcessMessage(message, context);
            statements.Add(Declare(
                "result",
                typeof(Azure.Response),
                This.Property("Pipeline").Invoke(pipelineMethod, [messageVariable, contextVariable], null, isAsync),
                out resultVariable));

            return statements;
        }

        /// <summary>
        /// Creates response statements for the primary path (if statement) in tag operations.
        /// Generates the response wrapping pattern: Response.FromValue((ResourceData)originalResult, originalResult)
        /// followed by return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse()).
        /// </summary>
        /// <param name="resourceClientProvider">The resource client provider containing type information.</param>
        /// <param name="originalResultVar">The variable containing the pipeline processing result.</param>
        /// <returns>List of method body statements for primary path response creation.</returns>
        protected static List<MethodBodyStatement> CreatePrimaryPathResponseStatements(
            ResourceClientProvider resourceClientProvider,
            VariableExpression originalResultVar)
        {
            return new List<MethodBodyStatement>
            {
                // Response<ResourceData> response = Response.FromValue((ResourceData)originalResult, originalResult);
                Declare("response", new CSharpType(typeof(Azure.Response<>), resourceClientProvider.ResourceData.Type),
                    Static(typeof(Azure.Response)).Invoke("FromValue", [
                        originalResultVar.CastTo(resourceClientProvider.ResourceData.Type),
                        originalResultVar
                    ]), out var originalResponseVar),

                // return Response.FromValue(new ResourceType(Client, response.Value), response.GetRawResponse());
                Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                    New.Instance(resourceClientProvider.ResourceClientCSharpType, [
                        This.Property("Client"),
                        originalResponseVar.Property("Value")
                    ]),
                    originalResponseVar.Invoke("GetRawResponse")
                ]))
            };
        }

        /// <summary>
        /// Creates a return statement for the secondary path (else statement) in tag operations.
        /// Generates: return Response.FromValue(result.Value, result.GetRawResponse()).
        /// </summary>
        /// <param name="resultVariable">The variable containing the update operation result.</param>
        /// <returns>The return statement for secondary path response creation.</returns>
        protected static MethodBodyStatement CreateSecondaryPathResponseStatement(VariableExpression resultVariable)
        {
            // return Response.FromValue(result.Value, result.GetRawResponse());
            return Return(Static(typeof(Azure.Response)).Invoke("FromValue", [
                resultVariable.Property("Value"),
                resultVariable.Invoke("GetRawResponse")
            ]));
        }

        /// <summary>
        /// Creates statements that retrieve current resource data.
        /// Generates: var currentResource = Get(cancellationToken: cancellationToken);
        ///           var current = currentResource.Value.Data;
        /// </summary>
        /// <param name="variableName">The name of the variable to declare for the resource data.</param>
        /// <param name="resourceClientProvider">The resource client provider containing type information.</param>
        /// <param name="isAsync">Whether to use async Get method.</param>
        /// <param name="cancellationTokenParam">The cancellation token parameter.</param>
        /// <param name="currentVar">Output variable for the declared resource data variable.</param>
        /// <returns>List of statements for getting resource data.</returns>
        protected static MethodBodyStatement GetResourceDataStatements(
            string variableName,
            ResourceClientProvider resourceClientProvider,
            bool isAsync,
            ParameterProvider cancellationTokenParam,
            out VariableExpression currentVar)
        {
            var getMethod = isAsync ? "GetAsync" : "Get";

            // var current = Get(cancellationToken: cancellationToken).Value.Data; // has compilation error
            return Declare(
                variableName,
                resourceClientProvider.ResourceData.Type,
                new TupleExpression(This.Invoke(getMethod, [cancellationTokenParam], null, isAsync))
                    .Property("Value").Property("Data"),
                out currentVar);
        }

        public static implicit operator MethodProvider(BaseTagMethodProvider tagMethodProvider)
        {
            return new MethodProvider(
                tagMethodProvider._signature,
                tagMethodProvider._bodyStatements,
                tagMethodProvider._enclosingType);
        }
    }
}