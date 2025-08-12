// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Provider for building operation methods in resource clients.
    /// </summary>
    internal class ResourceOperationMethodProvider
    {
        protected readonly TypeProvider _enclosingType;
        protected readonly RequestPathPattern _contextualPath;
        protected readonly ClientProvider _restClient;
        protected readonly InputServiceMethod _serviceMethod;
        protected readonly MethodProvider _convenienceMethod;
        protected readonly bool _isAsync;
        protected readonly ValueExpression _clientDiagnosticsField;
        protected readonly ValueExpression _restClientField;
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;

        private readonly string _methodName;
        private protected readonly CSharpType? _originalBodyType;
        private protected readonly CSharpType? _returnBodyType;
        private protected readonly ResourceClientProvider? _returnBodyResourceClient;
        private readonly bool _isLongRunningOperation;
        private readonly bool _isFakeLongRunningOperation;
        private readonly FormattableString? _description;

        /// <summary>
        /// Creates a new instance of <see cref="ResourceOperationMethodProvider"/> which represents a method on a client
        /// </summary>
        /// <param name="enclosingType">The enclosing type of this operation. </param>
        /// <param name="contextualPath">The contextual path of the enclosing type. </param>
        /// <param name="restClientInfo">The rest client information containing the client provider and related fields. </param>
        /// <param name="method">The input service method that we are building from. </param>
        /// <param name="isAsync">Whether this method is an async method. </param>
        /// <param name="methodName">Optional override for the method name. If not provided, uses the convenience method name. </param>
        /// <param name="description">Optional override for the method description. If not provided, uses the convenience method description.</param>
        /// <param name="forceLro">Generate this method in LRO signature even if it is not an actual LRO</param>
        public ResourceOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            bool isAsync,
            string? methodName = null,
            FormattableString? description = null,
            bool forceLro = false)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _restClient = restClientInfo.RestClientProvider;
            _serviceMethod = method;
            _isAsync = isAsync;
            _convenienceMethod = _restClient.GetConvenienceMethodByOperation(_serviceMethod.Operation, isAsync);
            InitializeLroFlags(
                _serviceMethod,
                forceLro: forceLro,
                ref _isLongRunningOperation,
                ref _isFakeLongRunningOperation);
            _methodName = methodName ?? _convenienceMethod.Signature.Name;
            _description = description ?? _convenienceMethod.Signature.Description;
            InitializeTypeInfo(
                _serviceMethod,
                ref _originalBodyType,
                ref _returnBodyType,
                ref _returnBodyResourceClient);
            _clientDiagnosticsField = restClientInfo.Diagnostics;
            _restClientField = restClientInfo.RestClient;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
        }

        private static void InitializeLroFlags(
            in InputServiceMethod serviceMethod,
            in bool forceLro,
            ref bool isLongRunningOperation,
            ref bool isFakeLongRunningOperation)
        {
            isLongRunningOperation = serviceMethod.IsLongRunningOperation();
            // when the method is not a real LRO, but we have to force it to be an LRO, the fake lro flag is true.
            isFakeLongRunningOperation = forceLro && !isLongRunningOperation;
        }

        private static void InitializeTypeInfo(
            in InputServiceMethod serviceMethod,
            ref CSharpType? originalBodyType,
            ref CSharpType? returnBodyType,
            ref ResourceClientProvider? wrappedResourceClient)
        {
            originalBodyType = serviceMethod.GetResponseBodyType();
            // see if the body type could be wrapped into a resource client
            returnBodyType = originalBodyType;
            if (originalBodyType != null && ManagementClientGenerator.Instance.OutputLibrary.TryGetResourceClientProvider(originalBodyType, out wrappedResourceClient))
            {
                returnBodyType = wrappedResourceClient.Type;
            }
        }

        private CSharpType? _returnType;
        public CSharpType ReturnType => _returnType ??= BuildReturnType();

        protected virtual CSharpType BuildReturnType()
        {
            return _returnBodyType.WrapResponse(_isLongRunningOperation || _isFakeLongRunningOperation).WrapAsync(_isAsync);
        }

        public static implicit operator MethodProvider(ResourceOperationMethodProvider resourceOperationMethodProvider)
        {
            return new MethodProvider(
                resourceOperationMethodProvider._signature,
                resourceOperationMethodProvider._bodyStatements,
                resourceOperationMethodProvider._enclosingType);
        }

        protected virtual MethodBodyStatement[] BuildBodyStatements()
        {
            var scopeStatements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_enclosingType, _clientDiagnosticsField, _signature.Name, out var scopeVariable);
            return [
                .. scopeStatements,
                new TryCatchFinallyStatement(
                    BuildTryExpression(),
                    ResourceMethodSnippets.CreateDiagnosticCatchBlock(scopeVariable)
                )
            ];
        }

        protected IReadOnlyList<ParameterProvider> GetOperationMethodParameters()
        {
            return OperationMethodParameterHelper.GetOperationMethodParameters(_serviceMethod, _contextualPath, _isFakeLongRunningOperation);
        }

        protected virtual MethodSignature CreateSignature()
        {
            return new MethodSignature(
                _methodName,
                _description,
                _convenienceMethod.Signature.Modifiers,
                ReturnType,
                _convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        private TryExpression BuildTryExpression()
        {
            var cancellationTokenParameter = KnownParameters.CancellationTokenParameter;

            var requestMethod = _restClient.GetRequestMethodByOperation(_serviceMethod.Operation);
            var tryStatements = new List<MethodBodyStatement>
            {
                ResourceMethodSnippets.CreateRequestContext(cancellationTokenParameter, out var contextVariable)
            };

            // Populate arguments for the REST client method call
            var arguments = _contextualPath.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters);

            tryStatements.Add(ResourceMethodSnippets.CreateHttpMessage(_restClientField, requestMethod.Signature.Name, arguments, out var messageVariable));

            tryStatements.AddRange(BuildClientPipelineProcessing(messageVariable, contextVariable, out var responseVariable));

            if (_isLongRunningOperation || _isFakeLongRunningOperation)
            {
                tryStatements.AddRange(
                    _isFakeLongRunningOperation ?
                    BuildFakeLroHandling(messageVariable, responseVariable, cancellationTokenParameter) :
                    BuildLroHandling(messageVariable, responseVariable, cancellationTokenParameter));
            }
            else
            {
                tryStatements.AddRange(BuildReturnStatements(responseVariable, _signature));
            }
            return new TryExpression(tryStatements);
        }

        private IReadOnlyList<MethodBodyStatement> BuildClientPipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out ScopedApi<Response> responseVariable)
        {
            if (_originalBodyType != null && !_isLongRunningOperation)
            {
                return ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                    messageVariable,
                    contextVariable,
                    _originalBodyType,
                    _isAsync,
                    out responseVariable);
            }
            else
            {
                return ResourceMethodSnippets.CreateNonGenericResponsePipelineProcessing(
                    messageVariable,
                    contextVariable,
                    _isAsync,
                    out responseVariable);
            }
        }

        private IReadOnlyList<MethodBodyStatement> BuildFakeLroHandling(
            VariableExpression messageVariable,
            ScopedApi<Response> responseVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var armOperationType = _returnBodyType != null
                ? ManagementClientGenerator.Instance.OutputLibrary.ArmOperationOfT.Type
                    .MakeGenericType([_returnBodyType])
                : ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type;

            var uriDeclaration = ResourceMethodSnippets.CreateUriFromMessage(messageVariable, out var uriVariable);
            statements.Add(uriDeclaration);
            var rehydrationTokenDeclaration = NextLinkOperationImplementationSnippets.CreateRehydrationToken(uriVariable.As<RequestUriBuilder>(), _serviceMethod.Operation.HttpMethod, out var rehydrationTokenVariable);
            statements.Add(rehydrationTokenDeclaration);

            ValueExpression responseValueExpression = responseVariable;
            // when the response is wrapped by a resource, we need to construct it from the response value.
            if (_returnBodyResourceClient != null)
            {
                responseValueExpression = ResponseSnippets.FromValue(
                    New.Instance(
                            _returnBodyResourceClient.Type,
                            This.As<ArmResource>().Client(),
                            responseVariable.Value()),
                    responseVariable.GetRawResponse());
            }

            ValueExpression[] armOperationArguments = [responseValueExpression, rehydrationTokenVariable];
            var operationDeclaration = Declare(
                "operation",
                armOperationType,
                New.Instance(armOperationType, armOperationArguments),
                out var operationVariable);
            statements.Add(operationDeclaration);

            AddWaitCompletionLogic(statements, operationVariable, cancellationTokenParameter);
            return statements;
        }

        private IReadOnlyList<MethodBodyStatement> BuildLroHandling(
            VariableExpression messageVariable,
            ScopedApi<Response> responseVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var finalStateVia = _serviceMethod.GetOperationFinalStateVia();

            var armOperationType = _returnBodyType != null
                ? ManagementClientGenerator.Instance.OutputLibrary.ArmOperationOfT.Type
                    .MakeGenericType([_returnBodyType])
                : ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type;

            ValueExpression[] armOperationArguments = [
                _clientDiagnosticsField,
                This.As<ArmResource>().Pipeline(),
                messageVariable.Property("Request"),
                responseVariable,
                Static(typeof(OperationFinalStateVia)).Property(finalStateVia.ToString())
            ];

            var operationInstanceArguments = _returnBodyResourceClient != null
                ? [
                    New.Instance(_returnBodyResourceClient.Source.Type, This.As<ArmResource>().Client()),
                    .. armOperationArguments
                  ]
                : armOperationArguments;

            var operationDeclaration = Declare(
                "operation",
                armOperationType,
                New.Instance(armOperationType, operationInstanceArguments),
                out var operationVariable);
            statements.Add(operationDeclaration);

            AddWaitCompletionLogic(statements, operationVariable, cancellationTokenParameter);

            return statements;
        }

        private void AddWaitCompletionLogic(
            List<MethodBodyStatement> statements,
            VariableExpression operationVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var waitMethod = _returnBodyType != null
                ? (_isAsync ? "WaitForCompletionAsync" : "WaitForCompletion")
                : (_isAsync ? "WaitForCompletionResponseAsync" : "WaitForCompletionResponse");

            var waitInvocation = _isAsync
                           ? operationVariable.Invoke(waitMethod, [cancellationTokenParameter], null, _isAsync).Terminate()
                           : operationVariable.Invoke(waitMethod, cancellationTokenParameter).Terminate();

            var waitIfCompletedStatement = new IfStatement(
                KnownAzureParameters.WaitUntil.Equal(
                    Static(typeof(WaitUntil)).Property(nameof(WaitUntil.Completed))))
            {
                waitInvocation
            };
            statements.Add(waitIfCompletedStatement);
            statements.Add(Return(operationVariable));
        }

        // TODO: re-examine if this method need to be virtual or not after tags related method providers are implmented.
        protected virtual IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ScopedApi<Response> responseVariable, MethodSignature signature)
        {
            var nullCheckStatement = new IfStatement(
                responseVariable.Value().Equal(Null))
            {
                ((KeywordExpression)ThrowExpression(
                    New.Instance(
                        typeof(RequestFailedException),
                        responseVariable.GetRawResponse()))).Terminate()
            };

            List<MethodBodyStatement> statements = [nullCheckStatement];

            // If the return type has been wrapped by a resource client, we need to return the resource client type.
            if (_returnBodyResourceClient != null)
            {
                var returnValueExpression = New.Instance(
                    _returnBodyResourceClient.Type,
                    This.As<ArmResource>().Client(),
                    responseVariable.Value());
                var returnStatement = Return(
                    ResponseSnippets.FromValue(
                        returnValueExpression,
                        responseVariable.GetRawResponse()));
                statements.Add(returnStatement);
            }
            else
            {
                statements.Add(Return(responseVariable));
            }

            return statements;
        }
    }
}
