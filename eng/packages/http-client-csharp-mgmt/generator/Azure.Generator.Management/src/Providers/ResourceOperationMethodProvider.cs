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

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Provider for building operation methods in resource clients.
    /// </summary>
    internal class ResourceOperationMethodProvider
    {
        private readonly ResourceClientProvider _resourceClientProvider;
        private readonly InputServiceMethod _method;
        private readonly MethodProvider _convenienceMethod;
        private readonly MethodSignature _signature;
        private readonly bool _isAsync;
        private readonly ValueExpression _clientDiagnosticsField;

        public ResourceOperationMethodProvider(
            ResourceClientProvider resourceClientProvider,
            InputServiceMethod method,
            MethodProvider convenienceMethod,
            MethodSignature signature,
            bool isAsync)
        {
            _resourceClientProvider = resourceClientProvider;
            _method = method;
            _convenienceMethod = convenienceMethod;
            _signature = signature;
            _isAsync = isAsync;
            _clientDiagnosticsField = resourceClientProvider.GetClientDiagnosticsField();
        }

        public MethodProvider Build()
        {
            var scopeDeclaration = BuildDiagnosticScopeDeclaration(out var scopeVariable);
            var bodyStatements = new MethodBodyStatement[]
            {
                scopeDeclaration,
                scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                new TryCatchFinallyStatement(
                    BuildTryExpression(),
                    BuildCatchExpression(scopeVariable)
                )
            };

            return new MethodProvider(_signature, bodyStatements, _resourceClientProvider);
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
            var cancellationTokenParameter = _convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)));

            var tryStatements = new List<MethodBodyStatement>
            {
                BuildRequestContextInitialization(cancellationTokenParameter, out var contextVariable),
                BuildHttpMessageInitialization(_method, _convenienceMethod, contextVariable, out var messageVariable),
                BuildClientPipelineProcessing(_convenienceMethod, _isAsync, messageVariable, contextVariable, out var responseVariable).ToList()
            };

            if (_method.IsLongRunningOperation())
            {
                tryStatements.AddRange(
                BuildLroHandling(
                    _method,
                    _isAsync,
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
                { Identifier(nameof(RequestContext.CancellationToken)), cancellationTokenParameter }
            };
            return Declare(
                "context",
                typeof(RequestContext),
                New.Instance(typeof(RequestContext), requestContextParams),
                out contextVariable);
        }

        private MethodBodyStatement BuildHttpMessageInitialization(InputServiceMethod serviceMethod, MethodProvider convenienceMethod, VariableExpression contextVariable, out VariableExpression messageVariable)
        {
            var requestMethod = GetCorrespondingRequestMethod(serviceMethod.Operation);

            var arguments = PopulateArguments(
                requestMethod.Signature.Parameters,
                convenienceMethod,
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
            MethodProvider convenienceMethod,
            bool isAsync,
            VariableExpression messageVariable,
            VariableExpression contextVariable,
            out VariableExpression responseVariable)
        {
            var statements = new List<MethodBodyStatement>();
            var responseType = isAsync ? convenienceMethod.Signature.ReturnType?.Arguments[0]! : convenienceMethod.Signature.ReturnType!;
            VariableExpression declaredResponseVariable;
            var pipelineProperty = typeof(ArmResource).GetProperty("Pipeline");
            var pipelineInvoke = isAsync ? "ProcessMessageAsync" : "ProcessMessage";

            if (!responseType.Equals(typeof(Response)))
            {
                var resultDeclaration = Declare(
                    "result",
                    typeof(Response),
                    Identifier("this")
                        .Property("Pipeline")
                        .Invoke(pipelineInvoke, [messageVariable, contextVariable], null, isAsync),
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
                        .Invoke(pipelineInvoke, [messageVariable, contextVariable], null, isAsync),
                    out declaredResponseVariable);
                statements.Add(responseDeclaration);
            }
            responseVariable = declaredResponseVariable;
            return statements;
        }

        private IReadOnlyList<MethodBodyStatement> BuildLroHandling(
            InputServiceMethod method,
            bool isAsync,
            VariableExpression messageVariable,
            VariableExpression responseVariable,
            ParameterProvider cancellationTokenParameter)
        {
            var statements = new List<MethodBodyStatement>();

            var finalStateVia = method.GetOperationFinalStateVia();
            bool isGeneric = method.GetResponseBodyType() != null;

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
                ? (isAsync ? "WaitForCompletionAsync" : "WaitForCompletion")
                : (isAsync ? "WaitForCompletionResponseAsync" : "WaitForCompletionResponse");

            var waitInvocation = isAsync
                ? operationVariable.Invoke(waitMethod, [cancellationTokenParameter], null, isAsync).Terminate()
                : operationVariable.Invoke(waitMethod, cancellationTokenParameter).Terminate();

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
            MethodProvider convenienceMethod,
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
                    var resource = convenienceMethod.Signature.Parameters
                        .Single(p => p.Type.Equals(_resourceClientProvider.ResourceData.Type));
                    arguments.Add(resource);
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    var cancellationToken = convenienceMethod.Signature.Parameters
                        .Single(p => p.Type.Equals(typeof(CancellationToken)));
                    arguments.Add(contextVariable);
                }
                else
                {
                    arguments.Add(parameter);
                }
            }
            return arguments.ToArray();
        }

        private MethodProvider GetCorrespondingRequestMethod(InputOperation operation)
        {
            var expectedMethodName = $"Create{operation.Name}Request";
            return _resourceClientProvider.GetClientProvider().RestClient.Methods
                .Single(m => m.Signature.Name.Equals(
                    expectedMethodName,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
