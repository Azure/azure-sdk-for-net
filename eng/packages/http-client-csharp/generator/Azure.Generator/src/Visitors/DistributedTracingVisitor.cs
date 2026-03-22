// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that adds distributed tracing support to generated client code.
    /// Uses constructor injection to support both Azure.Core and System.ClientModel types.
    /// </summary>
    internal class DistributedTracingVisitor : ScmLibraryVisitor
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";
        private const string ClientDiagnosticsPropertyDescription = "The ClientDiagnostics is used to provide tracing support for the client library.";

        private readonly CSharpType _clientDiagnosticsType;
        private readonly CSharpType _diagnosticScopeType;
        private readonly Func<ScmMethodProvider, bool>? _shouldSkipMethod;

        /// <summary>
        /// Creates a new instance of <see cref="DistributedTracingVisitor"/> with the specified types.
        /// </summary>
        /// <param name="clientDiagnosticsType">The CSharpType for ClientDiagnostics (e.g., Azure.Core.Pipeline.ClientDiagnostics or System.ClientModel.Primitives.ClientDiagnostics).</param>
        /// <param name="diagnosticScopeType">The CSharpType for DiagnosticScope (e.g., Azure.Core.Pipeline.DiagnosticScope or System.ClientModel.Primitives.DiagnosticScope).</param>
        /// <param name="shouldSkipMethod">Optional delegate to determine if a method should be skipped for tracing instrumentation.</param>
        public DistributedTracingVisitor(
            CSharpType clientDiagnosticsType,
            CSharpType diagnosticScopeType,
            Func<ScmMethodProvider, bool>? shouldSkipMethod = null)
        {
            _clientDiagnosticsType = clientDiagnosticsType;
            _diagnosticScopeType = diagnosticScopeType;
            _shouldSkipMethod = shouldSkipMethod;
        }

        /// <summary>
        /// Gets the <see cref="CSharpType"/> for the ClientDiagnostics class.
        /// </summary>
        protected CSharpType ClientDiagnosticsType => _clientDiagnosticsType;

        /// <summary>
        /// Gets the <see cref="CSharpType"/> for the DiagnosticScope struct.
        /// </summary>
        protected CSharpType DiagnosticScopeType => _diagnosticScopeType;

        /// <summary>
        /// Determines whether the specified method should be skipped for distributed tracing instrumentation.
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <returns>True if the method should be skipped; otherwise, false.</returns>
        protected bool ShouldSkipMethodForTracing(ScmMethodProvider method)
        {
            return _shouldSkipMethod?.Invoke(method) ?? false;
        }

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            bool hasExistingProperty = clientProvider.CanonicalView.Properties
                    .Any(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
            if (hasExistingProperty)
            {
                return base.Visit(client, clientProvider);
            }

            AddDistributedTracingProperty(clientProvider);

            return clientProvider;
        }

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            if (ShouldSkipType(constructor.EnclosingType))
            {
                return base.VisitConstructor(constructor);
            }

            PropertyProvider clientDiagnosticsProperty = constructor.EnclosingType.CanonicalView.Properties
                .First(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
            ParameterProvider? endpoint = constructor.Signature.Parameters.FirstOrDefault(p => p.Name == "endpoint");
            ParameterProvider? options = constructor.Signature.Parameters.FirstOrDefault(p => p.Name == "options");
            bool hasNoInitializer = constructor.Signature.Initializer == null;
            bool isSubClientConstructor = hasNoInitializer &&
                   constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                   endpoint != null;
            bool isPrimaryConstructor = hasNoInitializer && options != null;
            if (isPrimaryConstructor)
            {
                var assignClientDiagnostics = clientDiagnosticsProperty.Assign(
                        New.Instance(clientDiagnosticsProperty.Type, [options!, True])).Terminate();
                List<MethodBodyStatement> constructorBody = constructor.BodyStatements != null
                    ? [constructor.BodyStatements, assignClientDiagnostics]
                    : [assignClientDiagnostics];

                constructor.Update(bodyStatements: constructorBody);
            }
            else if (isSubClientConstructor)
            {
                XmlDocProvider? updatedXmlDocs = constructor.XmlDocs;
                if (updatedXmlDocs != null)
                {
                    List<XmlDocParamStatement> updatedParametersXmlDoc = [new XmlDocParamStatement(clientDiagnosticsProperty.AsParameter), .. updatedXmlDocs.Parameters];
                    updatedXmlDocs?.Update(parameters: updatedParametersXmlDoc);
                }

                var updatedSignature = new ConstructorSignature(
                   constructor.Signature.Type,
                   constructor.Signature.Description,
                   constructor.Signature.Modifiers,
                   [clientDiagnosticsProperty.AsParameter, .. constructor.Signature.Parameters],
                   constructor.Signature.Attributes,
                   constructor.Signature.Initializer);
                var assignClientDiagnostics = clientDiagnosticsProperty.Assign(clientDiagnosticsProperty.AsParameter).Terminate();
                List<MethodBodyStatement> updatedBody = constructor.BodyStatements != null
                    ? [assignClientDiagnostics, constructor.BodyStatements]
                    : [assignClientDiagnostics];

                constructor.Update(signature: updatedSignature, bodyStatements: updatedBody, xmlDocs: updatedXmlDocs);
            }

            return constructor;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (ShouldSkipType(method.EnclosingType) || ShouldSkipMethodForTracing(method))
            {
                return base.VisitMethod(method);
            }

            if (method.Kind == ScmMethodKind.Protocol)
            {
                UpdateProtocolMethodsWithDistributedTracing(method);
            }
            else if (IsSubClientFactoryMethod(method))
            {
                UpdateDistributedTracingRefInSubClientFactoryMethod(method);
            }

            return method;
        }

        private void UpdateDistributedTracingRefInSubClientFactoryMethod(
            ScmMethodProvider method)
        {
            if (method.BodyStatements == null && method.BodyExpression == null)
            {
                return;
            }

            PropertyProvider clientDiagnosticsProperty = method.EnclosingType.CanonicalView.Properties
                    .First(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
            List<MethodBodyStatement> updatedFactoryMethodStatements = [];

            var statementsToVisit = method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!);
            foreach (var statement in statementsToVisit)
            {
                if (TryUpdateSubClientFactoryMethodReturnStatement(
                    statement,
                    clientDiagnosticsProperty,
                    out MethodBodyStatement? updatedStatement))
                {
                    updatedFactoryMethodStatements.Add(updatedStatement);
                }
                else
                {
                    updatedFactoryMethodStatements.Add(statement);
                }
            }

            method.Update(bodyStatements: updatedFactoryMethodStatements);
        }

        private void UpdateProtocolMethodsWithDistributedTracing(ScmMethodProvider method)
        {
            if (method.BodyStatements == null && method.BodyExpression == null)
            {
                return;
            }

            // Get scope name: "{ClientName}.{MethodName}" without Async suffix
            string scopeName = $"{method.EnclosingType.Name}.{method.Signature.Name}";
            const string asyncSuffix = "Async";
            if (scopeName.EndsWith(asyncSuffix))
            {
                scopeName = scopeName[..^asyncSuffix.Length];
            }

            PropertyProvider clientDiagnosticsProperty = ((ClientProvider)method.EnclosingType).CanonicalView.Properties
                .First(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);

            // declare scope
            var scopeDeclaration = UsingDeclare(
                "scope",
                DiagnosticScopeType,
                clientDiagnosticsProperty.Invoke("CreateScope", [Literal(scopeName)], false, false),
                out var scope);
            // start scope
            var scopeStart = scope.Invoke("Start").Terminate();
            // wrap existing statements in try / catch
            var tryStatement = new TryExpression
            (
                method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!)
            );

            var catchBlock = new CatchExpression(
                Declare("e", typeof(Exception), out var exception),
                scope.Invoke("Failed", [exception]).Terminate(),
                Throw());
            var tryCatchRequestBlock = new TryCatchFinallyStatement(tryStatement, catchBlock);
            List<MethodBodyStatement> updatedBodyStatements = [scopeDeclaration, scopeStart, tryCatchRequestBlock];

            method.Update(bodyStatements: updatedBodyStatements);
        }

        private void AddDistributedTracingProperty(ClientProvider client)
        {
            var existingCount = client.Properties.Count;
            List<PropertyProvider> updatedProperties = new(existingCount + 1);
            updatedProperties.AddRange(client.Properties);

            PropertyProvider clientDiagnosticsProperty = new(
                $"{ClientDiagnosticsPropertyDescription}",
                MethodSignatureModifiers.Internal,
                ClientDiagnosticsType,
                ClientDiagnosticsPropertyName,
                new AutoPropertyBody(false),
                client);

            updatedProperties.Add(clientDiagnosticsProperty);

            client.Update(properties: updatedProperties);
        }

        private static bool TryUpdateSubClientFactoryMethodReturnStatement(
            MethodBodyStatement originalStatement,
            PropertyProvider clientDiagnostics,
            [NotNullWhen(true)] out MethodBodyStatement? updatedStatement)
        {
            updatedStatement = originalStatement;
            if (originalStatement is not ExpressionStatement { Expression: KeywordExpression keywordExpression }
                || keywordExpression.Expression is not BinaryOperatorExpression binaryOperatorExpression)
            {
                return false;
            }

            var innerBinaryOperatorExpression = binaryOperatorExpression.Right as BinaryOperatorExpression;
            if (innerBinaryOperatorExpression?.Left is not InvokeMethodExpression invokeMethodExpression)
            {
                return false;
            }

            bool constructorArgsUpdated = false;

            // find the new instance expression that instantiates the subclient
            // & update the arguments to pass the ClientDiagnostics property
            List<ValueExpression> updatedArguments = new(invokeMethodExpression.Arguments.Count + 1);
            foreach (var arg in invokeMethodExpression.Arguments)
            {
                if (arg is NewInstanceExpression ctorInstantiationExpression)
                {
                    updatedArguments.Add(new NewInstanceExpression(
                        ctorInstantiationExpression.Type,
                        [clientDiagnostics, .. ctorInstantiationExpression.Parameters],
                        ctorInstantiationExpression.InitExpression));
                    constructorArgsUpdated = true;
                }
                else
                {
                    updatedArguments.Add(arg);
                }
            }

            if (!constructorArgsUpdated)
            {
                return false;
            }

            InvokeMethodExpression updatedInvokeMethodExpression = new(
                invokeMethodExpression.InstanceReference,
                invokeMethodExpression.MethodName!,
                updatedArguments);

            // return Volatile.Read(ref _cachedT) ?? Interlocked.CompareExchange(ref _cachedT, new T(ClientDiagnostics, _pipeline, _endpoint), null) ?? _cachedT;
            updatedStatement = Return(
                binaryOperatorExpression.Left.NullCoalesce(
                    updatedInvokeMethodExpression.NullCoalesce(
                        innerBinaryOperatorExpression.Right)));
            return true;
        }

        private static bool ShouldSkipType(TypeProvider typeProvider)
        {
            return typeProvider is not ClientProvider ||
                !typeProvider.CanonicalView.Properties
                    .Any(p => p.Name == ClientDiagnosticsPropertyName || p.OriginalName?.Equals(ClientDiagnosticsPropertyName) == true);
        }

        private static bool IsSubClientFactoryMethod(ScmMethodProvider method)
        {
            ClientProvider clientProvider = (ClientProvider)method.EnclosingType;
            var methodReturnType = method.Signature.ReturnType;

            return methodReturnType != null &&
                clientProvider.SubClients.Any(subClient => methodReturnType.Equals(subClient.Type));
        }
    }
}
