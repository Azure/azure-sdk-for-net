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
        protected readonly ResourceClientProvider _resource;
        protected readonly ClientProvider _restClient;
        protected readonly InputServiceMethod _serviceMethod;
        protected readonly MethodProvider _convenienceMethod;
        protected readonly bool _isAsync;
        protected readonly ValueExpression _clientDiagnosticsField;
        protected readonly ValueExpression _restClientField;
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;

        private readonly string _methodName;
        private readonly CSharpType? _responseGenericType;
        private readonly bool _isGeneric;
        private readonly bool _isLongRunningOperation;
        private readonly bool _isFakeLongRunningOperation;

        /// <summary>
        /// Creates a new instance of <see cref="ResourceOperationMethodProvider"/> which represents a method on a client
        /// </summary>
        /// <param name="enclosingType">The enclosing type of this operation. </param>
        /// <param name="contextualPath">The contextual path of the enclosing type. </param>
        /// <param name="restClientInfo">The rest client information containing the client provider and related fields. </param>
        /// <param name="method">The input service method that we are building from. </param>
        /// <param name="convenienceMethod">The corresponding convenience method provided by the generator framework. </param>
        /// <param name="isAsync">Whether this method is an async method. </param>
        /// <param name="methodName">Optional override for the method name. If not provided, uses the convenience method name. </param>
        public ResourceOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            MethodProvider convenienceMethod,
            bool isAsync,
            string? methodName = null)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _resource = InitializeResource(enclosingType);
            _restClient = restClientInfo.RestClientProvider;
            _serviceMethod = method;
            _convenienceMethod = convenienceMethod;
            _isAsync = isAsync;
            _methodName = methodName ?? convenienceMethod.Signature.Name;
            _responseGenericType = _serviceMethod.GetResponseBodyType();
            _isGeneric = _responseGenericType != null;
            _isLongRunningOperation = _serviceMethod.IsLongRunningOperation();
            _isFakeLongRunningOperation = _serviceMethod.IsFakeLongRunningOperation();
            _clientDiagnosticsField = restClientInfo.DiagnosticsField;
            _restClientField = restClientInfo.RestClientField;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
        }

        // TODO -- we should not need to do this. We need the resource only because sometimes we need to wrap the return type into its corresponding resource.
        // We should have a cache in the outputlibrary for it.
        private static ResourceClientProvider InitializeResource(TypeProvider enclosingType)
            => enclosingType switch
            {
                ResourceClientProvider resourceProvider => resourceProvider,
                ResourceCollectionClientProvider collectionProvider => collectionProvider.Resource,
                _ => throw new NotImplementedException()
            };

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
            return OperationMethodParameterHelper.GetOperationMethodParameters(_serviceMethod, _contextualPath);
        }

        protected virtual MethodSignature CreateSignature()
        {
            return new MethodSignature(
                _methodName,
                _convenienceMethod.Signature.Description,
                _convenienceMethod.Signature.Modifiers,
                _serviceMethod.GetOperationMethodReturnType(_isAsync, _resource.Type, _resource.ResourceData.Type),
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
            out VariableExpression responseVariable)
        {
            if (_isGeneric && !_isLongRunningOperation)
            {
                return ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                    messageVariable,
                    contextVariable,
                    _responseGenericType!,
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
            VariableExpression responseVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var armOperationType = _isGeneric
                ? ManagementClientGenerator.Instance.OutputLibrary.GenericArmOperation.Type
                    .MakeGenericType([_resource.Type])
                : ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type;

            var uriDeclaration = ResourceMethodSnippets.CreateUriFromMessage(messageVariable, out var uriVariable);
            statements.Add(uriDeclaration);
            var rehydrationTokenDeclaration = NextLinkOperationImplementationSnippets.CreateRehydrationToken(uriVariable.As<RequestUriBuilder>(), _serviceMethod.Operation.HttpMethod, out var rehydrationTokenVariable);
            statements.Add(rehydrationTokenDeclaration);

            var responseFromValueExpression = Static(typeof(Response)).Invoke(
                nameof(Response.FromValue),
                New.Instance(
                    _resource.Type,
                    This.Property("Client"),
                    responseVariable.Property("Value")),
                responseVariable.Invoke("GetRawResponse"));

            ValueExpression[] armOperationArguments = _isGeneric ? [responseFromValueExpression, rehydrationTokenVariable] : [responseVariable, rehydrationTokenVariable];
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
            VariableExpression responseVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var finalStateVia = _serviceMethod.GetOperationFinalStateVia();

            var armOperationType = _isGeneric
                ? ManagementClientGenerator.Instance.OutputLibrary.GenericArmOperation.Type
                    .MakeGenericType([_resource.Type])
                : ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type;

            ValueExpression[] armOperationArguments = [
                _clientDiagnosticsField,
                This.Property("Pipeline"),
                messageVariable.Property("Request"),
                responseVariable,
                Static(typeof(OperationFinalStateVia)).Property(finalStateVia.ToString())
            ];

            var operationInstanceArguments = _isGeneric
                ? [
                    New.Instance(_resource.Source.Type, This.Property("Client")), // TODO -- this is incorrect: https://github.com/Azure/azure-sdk-for-net/issues/51177
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
            var waitMethod = _isGeneric
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
        protected virtual IReadOnlyList<MethodBodyStatement> BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            var nullCheckStatement = new IfStatement(
                responseVariable.Property("Value").Equal(Null))
            {
                ((KeywordExpression)ThrowExpression(
                    New.Instance(
                        typeof(RequestFailedException),
                        responseVariable.Invoke("GetRawResponse")))).Terminate()
            };

            List<MethodBodyStatement> statements = [nullCheckStatement];

            var returnType = signature.ReturnType!.UnWrap();
            var returnValueExpression = New.Instance(
                returnType,
                This.Property("Client"),
                responseVariable.Property("Value"));
            // If the return type is the same as the resource type, we need to the convert work (from resource data to resource)
            if (returnType.Equals(_resource.Type))
            {
                var returnStatement = Return(
                    Static(typeof(Response)).Invoke(
                        nameof(Response.FromValue),
                        returnValueExpression,
                        responseVariable.Invoke("GetRawResponse")));
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
