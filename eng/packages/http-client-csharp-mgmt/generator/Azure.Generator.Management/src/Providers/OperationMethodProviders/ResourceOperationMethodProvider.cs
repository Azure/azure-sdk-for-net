// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.Generator.Management.Visitors;
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
using System.Linq;
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

        private readonly CSharpType? _responseGenericType;
        private readonly bool _isGeneric;
        private readonly bool _isLongRunningOperation;
        private readonly bool _isFakeLongRunningOperation;

        /// <summary>
        /// Creates a new instance of <see cref="ResourceOperationMethodProvider"/> which represents a method on a client
        /// </summary>
        /// <param name="enclosingType">The enclosing type of this operation. </param>
        /// <param name="contextualPath">The contextual path of the enclosing type. </param>
        /// <param name="restClient">The client provider for this operation to send the request. </param>
        /// <param name="method">The input service method that we are building from. </param>
        /// <param name="convenienceMethod">The corresponding convenience method provided by the generator framework. </param>
        /// <param name="clientDiagnosticsField">The field that holds the client diagnostics instance. </param>
        /// <param name="restClientField">The field that holds the rest client instance. </param>
        /// <param name="isAsync">Whether this method is an async method. </param>
        public ResourceOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            ClientProvider restClient,
            InputServiceMethod method,
            MethodProvider convenienceMethod,
            FieldProvider clientDiagnosticsField, // we must pass this field in because in mockable resources (holding the extension methods) have multiple such fields
            FieldProvider restClientField,
            bool isAsync)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _resource = InitializeResource(enclosingType);
            _restClient = restClient;
            _serviceMethod = method;
            _convenienceMethod = convenienceMethod;
            _isAsync = isAsync;
            _responseGenericType = _serviceMethod.GetResponseBodyType();
            _isGeneric = _responseGenericType != null;
            _isLongRunningOperation = _serviceMethod.IsLongRunningOperation();
            _isFakeLongRunningOperation = _serviceMethod.IsFakeLongRunningOperation();
            _clientDiagnosticsField = clientDiagnosticsField;
            _restClientField = restClientField;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
        }

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

        protected virtual MethodSignature CreateSignature()
        {
            return new MethodSignature(
                _convenienceMethod.Signature.Name,
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
            var arguments = PopulateArguments(requestMethod.Signature.Parameters, contextVariable, _signature.Parameters);

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

        private IReadOnlyList<ValueExpression> PopulateArguments(
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression requestContext,
            IReadOnlyList<ParameterProvider> methodParameters)
        {
            var idProperty = This.Property("Id").As<ResourceIdentifier>();
            var arguments = new List<ValueExpression>();
            // here we always assume that the parameter name matches the parameter name in the request path.
            foreach (var parameter in requestParameters)
            {
                // find the corresponding contextual parameter in the contextual parameter list
                if (_contextualPath.TryGetContextualParameter(parameter, out var contextualParameter))
                {
                    arguments.Add(Convert(contextualParameter.BuildValueExpression(idProperty), typeof(string), parameter.Type));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    // find the body parameter
                    var bodyParameter = methodParameters.SingleOrDefault(p => p.Location == ParameterLocation.Body);
                    if (bodyParameter is not null)
                    {
                        arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
                    }
                    else
                    {
                        arguments.Add(Null);
                    }
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    arguments.Add(requestContext);
                }
                else
                {
                    arguments.Add(methodParameters.Single(p => p.Name == parameter.Name));
                }
            }
            return arguments;

            static ValueExpression Convert(ValueExpression expression, CSharpType fromType, CSharpType toType)
            {
                if (fromType.Equals(toType))
                {
                    return expression; // No conversion needed
                }

                if (toType.IsFrameworkType && toType.FrameworkType == typeof(Guid))
                {
                    return Static<Guid>().Invoke(nameof(Guid.Parse), expression);
                }

                // other unhandled cases, we will add when we need them in the future.
                return expression;
            }
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

            var resourceType = typeof(ArmResource);
            var returnValueExpression = New.Instance(
                _resource.Type,
                This.Property("Client"),
                responseVariable.Property("Value"));

            var returnStatement = Return(
                Static(typeof(Response)).Invoke(
                    nameof(Response.FromValue),
                    returnValueExpression,
                    responseVariable.Invoke("GetRawResponse")));
            statements.Add(returnStatement);

            return statements;
        }

        protected IReadOnlyList<ParameterProvider> GetOperationMethodParameters()
        {
            var parameters = new List<ParameterProvider>();
            if (_serviceMethod.IsLongRunningOperation() || _serviceMethod.IsFakeLongRunningOperation())
            {
                parameters.Add(KnownAzureParameters.WaitUntil);
            }

            foreach (var parameter in _convenienceMethod.Signature.Parameters)
            {
                if (!_contextualPath.TryGetContextualParameter(parameter, out _))
                {
                    if (ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(parameter.Type))
                    {
                        parameter.Update(name: "data");
                    }

                    parameters.Add(parameter);
                }
            }

            return parameters;
        }
    }
}
