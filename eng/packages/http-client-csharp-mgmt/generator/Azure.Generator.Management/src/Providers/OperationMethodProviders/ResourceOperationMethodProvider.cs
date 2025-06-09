// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Primitives;
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
            var scopeDeclaration = BuildDiagnosticScopeDeclaration(out var scopeVariable);
            return
            [
                scopeDeclaration,
                scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                new TryCatchFinallyStatement(
                    BuildTryExpression(),
                    BuildCatchExpression(scopeVariable)
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

        private MethodBodyStatement BuildDiagnosticScopeDeclaration(out VariableExpression scopeVariable)
        {
            return UsingDeclare(
                "scope",
                typeof(DiagnosticScope),
                _clientDiagnosticsField.Invoke(
                    nameof(ClientDiagnostics.CreateScope),
                    [Literal($"{_resourceClientProvider.Name}.{_signature.Name}")]),
                out scopeVariable);
        }

        private TryExpression BuildTryExpression()
        {
            var contextParameter = _convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)) || p.Type.Equals(typeof(RequestContext)));

            var tryStatements = new List<MethodBodyStatement>
            {
                BuildRequestContextInitialization(contextParameter, out var contextVariable),
                BuildHttpMessageInitialization(contextVariable, out var messageVariable)
            };

            tryStatements.AddRange(BuildClientPipelineProcessing(messageVariable, contextVariable, out var responseVariable));

            if (_serviceMethod.IsLongRunningOperation())
            {
                tryStatements.AddRange(
                BuildLroHandling(
                    messageVariable,
                    responseVariable,
                    contextParameter));
            }
            else
            {
                tryStatements.AddRange(BuildReturnStatements(responseVariable, _signature));
            }
            return new TryExpression(tryStatements);
        }

        private CatchExpression BuildCatchExpression(VariableExpression scopeVariable)
        {
            return Catch(
                Declare<Exception>("e", out var exceptionVariable),
                [
                    scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVariable).Terminate(),
                    Throw()
                ]);
        }

        private MethodBodyStatement BuildRequestContextInitialization(ParameterProvider cancellationTokenParameter, out VariableExpression contextVariable)
        {
            var requestContextParams = new Dictionary<ValueExpression, ValueExpression>
                {
                    { This.Property(nameof(RequestContext.CancellationToken)), cancellationTokenParameter }
                };
            return Declare(
                "context",
                typeof(RequestContext),
                New.Instance(typeof(RequestContext), requestContextParams),
                out contextVariable);
        }

        private MethodBodyStatement BuildHttpMessageInitialization(VariableExpression contextVariable, out VariableExpression messageVariable)
        {
            var requestMethod = _serviceMethod.GetCorrespondingRequestMethod(_resourceClientProvider);

            var arguments = PopulateArguments(
                requestMethod.Signature.Parameters,
                contextVariable);

            var invokeExpression = _resourceClientProvider
                .GetRestClientField()
                .Invoke(requestMethod.Signature.Name, arguments);

            return Declare(
                "message",
                typeof(HttpMessage),
                invokeExpression,
                out messageVariable);
        }

        private IReadOnlyList<MethodBodyStatement> BuildClientPipelineProcessing(
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>();
            var responseType = _convenienceMethod.Signature.ReturnType!.UnWrapAsync();
            VariableExpression declaredResponseVariable;
            var pipelineInvoke = _isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            if (!responseType.Equals(typeof(Response)))
            {
                var resultDeclaration = Declare(
                    "result",
                    typeof(Response),
                    Identifier("this")
                        .Property("Pipeline")
                        .Invoke(pipelineInvoke, [messageVariable, contextVariable], null, _isAsync),
                    out var resultVariable);
                statements.Add(resultDeclaration);

                var responseDeclaration = Declare(
                    "response",
                    responseType,
                    Static(typeof(Response)).Invoke(
                        nameof(Response.FromValue),
                        [resultVariable.CastTo(responseType.Arguments[0]), resultVariable]),
                    out declaredResponseVariable);
                statements.Add(responseDeclaration);
            }
            else
            {
                var responseDeclaration = Declare(
                    "response",
                    typeof(Response),
                    Identifier("this")
                        .Property("Pipeline")
                        .Invoke(pipelineInvoke, [messageVariable, contextVariable], null, _isAsync),
                    out declaredResponseVariable);
                statements.Add(responseDeclaration);
            }
            responseVariable = declaredResponseVariable;
            return statements;
        }

        private IReadOnlyList<MethodBodyStatement> BuildLroHandling(
            VariableExpression messageVariable,
            VariableExpression responseVariable,
            ParameterProvider contextParameter)
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
                ? operationVariable.Invoke(waitMethod, [contextParameter], null, _isAsync).Terminate()
                : operationVariable.Invoke(waitMethod, contextParameter).Terminate();

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

        private ValueExpression[] PopulateArguments(
            IReadOnlyList<ParameterProvider> parameters,
            VariableExpression contextVariable)
        {
            var arguments = new List<ValueExpression>();
            foreach (var parameter in parameters)
            {
                if (parameter.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        Static(typeof(Guid)).Invoke(
                            nameof(Guid.Parse),
                            This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.SubscriptionId))));
                }
                else if (parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.ResourceGroupName)));
                }
                // TODO: handle parents
                // Handle resource name - the last contextual parameter
                else if (parameter.Name.Equals(_resourceClientProvider.ContextualParameters.Last(), StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.Name)));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    var resource = _convenienceMethod.Signature.Parameters
                        .Single(p => p.Type.Equals(_resourceClientProvider.ResourceData.Type) || p.Type.Equals(typeof(RequestContent)));
                    arguments.Add(resource);
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    var cancellationToken = _convenienceMethod.Signature.Parameters
                        .Single(p => p.Type.Equals(typeof(CancellationToken)) || p.Type.Equals(typeof(RequestContext)));
                    arguments.Add(contextVariable);
                }
                else
                {
                    arguments.Add(parameter);
                }
            }
            return [.. arguments];
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
