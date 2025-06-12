// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Provider for building operation methods in resource clients.
    /// </summary>
    internal class ResourceOperationMethodProvider
    {
        protected readonly ResourceClientProvider _resourceClientProvider;
        protected readonly InputServiceMethod _serviceMethod;
        protected readonly MethodProvider _convenienceMethod;
        protected readonly bool _isAsync;
        protected readonly ValueExpression _clientDiagnosticsField;
        protected readonly MethodSignature _signature;
        protected readonly MethodBodyStatement[] _bodyStatements;

        public ResourceOperationMethodProvider(
            ResourceClientProvider resourceClientProvider,
            InputServiceMethod method,
            MethodProvider convenienceMethod,
            bool isAsync)
        {
            _resourceClientProvider = resourceClientProvider;
            _serviceMethod = method;
            _convenienceMethod = convenienceMethod;
            _isAsync = isAsync;
            _clientDiagnosticsField = resourceClientProvider.GetClientDiagnosticsField();
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
        }

        public static implicit operator MethodProvider(ResourceOperationMethodProvider resourceOperationMethodProvider)
        {
            return new MethodProvider(
                resourceOperationMethodProvider._signature,
                resourceOperationMethodProvider._bodyStatements,
                resourceOperationMethodProvider._resourceClientProvider.Source);
        }

        protected virtual MethodBodyStatement[] BuildBodyStatements()
        {
            var scopeStatements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_resourceClientProvider, _signature.Name, out var scopeVariable);
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
                _serviceMethod.GetOperationMethodReturnType(_isAsync, _resourceClientProvider.ResourceClientCSharpType, _resourceClientProvider.ResourceData.Type),
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
            var cancellationTokenParameter = _convenienceMethod.Signature.Parameters.FirstOrDefault(p => p.Type.Equals(typeof(CancellationToken)));

            var requestMethod = _resourceClientProvider.GetClientProvider().GetRequestMethodByOperation(_serviceMethod.Operation);
            var tryStatements = new List<MethodBodyStatement>();
            VariableExpression messageVariable;
            VariableExpression responseVariable;

            if (cancellationTokenParameter is null)
            {
                var contextParameter = _convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(RequestContext)));

                // Populate arguments for the REST client method call
                var arguments = _resourceClientProvider.PopulateArguments(requestMethod.Signature.Parameters, contextParameter, _convenienceMethod);

                tryStatements.Add(ResourceMethodSnippets.CreateHttpMessage(_resourceClientProvider, requestMethod.Signature.Name, arguments, out messageVariable));

                tryStatements.AddRange(BuildClientPipelineProcessing(messageVariable, contextParameter, out responseVariable));
            }
            else
            {
                tryStatements.Add(ResourceMethodSnippets.CreateRequestContext(cancellationTokenParameter, out var contextVariable));
                // Populate arguments for the REST client method call
                var arguments = _resourceClientProvider.PopulateArguments(requestMethod.Signature.Parameters, contextVariable, _convenienceMethod);

                tryStatements.Add(ResourceMethodSnippets.CreateHttpMessage(_resourceClientProvider, requestMethod.Signature.Name, arguments, out messageVariable));

                tryStatements.AddRange(BuildClientPipelineProcessing(messageVariable, contextVariable, out responseVariable));
            }

            if (_serviceMethod.IsLongRunningOperation())
            {
                tryStatements.AddRange(
                BuildLroHandling(
                    messageVariable,
                    responseVariable,
                    cancellationTokenParameter));
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
            var responseType = _convenienceMethod.Signature.ReturnType!.UnWrapAsync();

            // Check if the return type is a generic Response<T> or just Response
            if (!responseType.Equals(typeof(Response)))
            {
                // For methods returning Response<T> (e.g., Response<MyResource>), use generic response processing
                return ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                    messageVariable,
                    contextVariable,
                    responseType,
                    _isAsync,
                    out responseVariable);
            }
            else
            {
                // For methods returning just Response (no generic type), use non-generic response processing
                return ResourceMethodSnippets.CreateNonGenericResponsePipelineProcessing(
                    messageVariable,
                    contextVariable,
                    _isAsync,
                    out responseVariable);
            }
        }

        private IReadOnlyList<MethodBodyStatement> BuildLroHandling(
            VariableExpression messageVariable,
            VariableExpression responseVariable,
            ParameterProvider? cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var finalStateVia = _serviceMethod.GetOperationFinalStateVia();
            bool isGeneric = _serviceMethod.GetResponseBodyType() != null;

            var armOperationType = isGeneric
                ? ManagementClientGenerator.Instance.OutputLibrary.GenericArmOperation.Type
                    .MakeGenericType([_resourceClientProvider.ResourceClientCSharpType])
                : ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type;

            ValueExpression[] armOperationArguments = [
                _clientDiagnosticsField,
                This.Property("Pipeline"),
                messageVariable.Property("Request"),
                isGeneric ? responseVariable.Invoke("GetRawResponse") : responseVariable,
                Static(typeof(OperationFinalStateVia)).Property(finalStateVia.ToString())
            ];

            var operationInstanceArguments = isGeneric
                ? [
                    New.Instance(_resourceClientProvider.Source.Type, This.Property("Client")),
                    .. armOperationArguments
                  ]
                : armOperationArguments;

            var operationDeclaration = Declare(
                "operation",
                armOperationType,
                New.Instance(armOperationType, operationInstanceArguments),
                out var operationVariable);
            statements.Add(operationDeclaration);

            var waitMethod = isGeneric
                ? (_isAsync ? "WaitForCompletionAsync" : "WaitForCompletion")
                : (_isAsync ? "WaitForCompletionResponseAsync" : "WaitForCompletionResponse");

            var waitInvocation = _isAsync
                ? operationVariable.Invoke(waitMethod, cancellationTokenParameter != null ? [cancellationTokenParameter] : [], null, _isAsync).Terminate()
                : (cancellationTokenParameter is null ? operationVariable.Invoke(waitMethod) : operationVariable.Invoke(waitMethod, cancellationTokenParameter)).Terminate();

            var waitIfCompletedStatement = new IfStatement(
                KnownAzureParameters.WaitUntil.Equal(
                    Static(typeof(WaitUntil)).Property(nameof(WaitUntil.Completed))))
            {
                waitInvocation
            };
            statements.Add(waitIfCompletedStatement);
            statements.Add(Return(operationVariable));
            return statements;
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
                _resourceClientProvider.ResourceClientCSharpType,
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
            var result = new List<ParameterProvider>();
            if (_serviceMethod.IsLongRunningOperation())
            {
                result.Add(KnownAzureParameters.WaitUntil);
            }

            foreach (var parameter in _convenienceMethod.Signature.Parameters)
            {
                if (!_resourceClientProvider.ImplicitParameterNames.Contains(parameter.Name))
                {
                    result.Add(parameter);
                }
            }

            return result;
        }
    }
}
