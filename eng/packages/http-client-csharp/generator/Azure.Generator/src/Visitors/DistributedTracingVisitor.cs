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

        /// <summary>
        /// Creates a new instance of <see cref="DistributedTracingVisitor"/> with the specified types.
        /// </summary>
        /// <param name="clientDiagnosticsType">The CSharpType for ClientDiagnostics (e.g., Azure.Core.Pipeline.ClientDiagnostics or System.ClientModel.Primitives.ClientDiagnostics).</param>
        /// <param name="diagnosticScopeType">The CSharpType for DiagnosticScope (e.g., Azure.Core.Pipeline.DiagnosticScope or System.ClientModel.Primitives.DiagnosticScope).</param>
        public DistributedTracingVisitor(
            CSharpType clientDiagnosticsType,
            CSharpType diagnosticScopeType)
        {
            _clientDiagnosticsType = clientDiagnosticsType;
            _diagnosticScopeType = diagnosticScopeType;
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
        /// Determines whether the specified method is a paging method whose scope name should be
        /// passed to the pageable collection result constructor (e.g., AzureCollectionResultDefinition).
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <returns>True if the scope name should be passed to the pageable constructor; otherwise, false.</returns>
        protected virtual bool ShouldPassScopeToPageableConstructor(ScmMethodProvider method)
        {
            return false;
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

        protected override MethodProvider? VisitMethod(MethodProvider method)
        {
            if (method.EnclosingType is CollectionResultDefinition collectionResult
                && collectionResult.GetType() == typeof(CollectionResultDefinition)
                && method.Signature.Name is "GetNextResponse" or "GetNextResponseAsync")
            {
                WrapCollectionResultMethodWithTracing(method, collectionResult);
                return method;
            }

            return base.VisitMethod(method);
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (ShouldSkipType(method.EnclosingType))
            {
                return base.VisitMethod(method);
            }

            if (ShouldPassScopeToPageableConstructor(method))
            {
                // For Azure paging methods, tracing is handled inside AzureCollectionResultDefinition.GetNextResponse,
                // so we skip standard try/catch wrapping and instead pass the scope name to the pageable constructor.
                UpdatePagingMethodWithScope(method);
            }
            else if (method.Kind == ScmMethodKind.Protocol)
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

        private void WrapCollectionResultMethodWithTracing(MethodProvider method, CollectionResultDefinition collectionResult)
        {
            if (method.BodyStatements == null && method.BodyExpression == null)
            {
                return;
            }

            var clientField = collectionResult.Fields.First(f => f.Name == "_client");
            var scopeName = collectionResult.ScopeName;

            // declare scope
            var scopeDeclaration = UsingDeclare(
                "scope",
                DiagnosticScopeType,
                ((MemberExpression)clientField).Property(ClientDiagnosticsPropertyName).Invoke("CreateScope", [Literal(scopeName)]),
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
            if (originalStatement is not ExpressionStatement { Expression: KeywordExpression keywordExpression })
            {
                return false;
            }

            // Handle simple return: return new T(Pipeline, _endpoint, ...);
            if (keywordExpression.Expression is NewInstanceExpression simpleCtorExpression)
            {
                updatedStatement = Return(new NewInstanceExpression(
                    simpleCtorExpression.Type,
                    [clientDiagnostics, .. simpleCtorExpression.Parameters],
                    simpleCtorExpression.InitExpression));
                return true;
            }

            // Handle cached return: return Volatile.Read(ref _cachedT) ?? Interlocked.CompareExchange(ref _cachedT, new T(...), null) ?? _cachedT;
            if (keywordExpression.Expression is not BinaryOperatorExpression binaryOperatorExpression)
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

        private static void UpdatePagingMethodWithScope(ScmMethodProvider method)
        {
            string scopeName = $"{method.EnclosingType.Name}.{method.Signature.Name}";
            const string asyncSuffix = "Async";
            if (scopeName.EndsWith(asyncSuffix))
            {
                scopeName = scopeName[..^asyncSuffix.Length];
            }

            if (method.BodyExpression is NewInstanceExpression newInstance)
            {
                List<MethodBodyStatement> updatedStatements =
                [
                    Return(new NewInstanceExpression(
                        newInstance.Type,
                        [.. newInstance.Parameters, Literal(scopeName)],
                        newInstance.InitExpression))
                ];
                method.Update(bodyStatements: updatedStatements);
            }
            else if (method.BodyStatements != null)
            {
                var updatedStatements = new List<MethodBodyStatement>();
                foreach (var statement in method.BodyStatements)
                {
                    if (statement is ExpressionStatement
                        {
                            Expression: KeywordExpression
                            {
                                Keyword: "return",
                                Expression: NewInstanceExpression returnNewInstance
                            } keyword
                        })
                    {
                        keyword.Update(keyword.Keyword, new NewInstanceExpression(
                            returnNewInstance.Type,
                            [.. returnNewInstance.Parameters, Literal(scopeName)],
                            returnNewInstance.InitExpression));
                    }
                    updatedStatements.Add(statement);
                }
                method.Update(bodyStatements: updatedStatements);
            }
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
