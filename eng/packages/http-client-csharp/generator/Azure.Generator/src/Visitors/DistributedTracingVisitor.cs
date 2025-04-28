// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
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
    /// </summary>
    internal class DistributedTracingVisitor : ScmLibraryVisitor
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";
        private const string ClientDiagnosticsPropertyDescription = "The ClientDiagnostics is used to provide tracing support for the client library.";
        private const string RequestContentParamterName = "content";

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            AddDistributedTracingProperty(clientProvider);

            return clientProvider;
        }

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            if (ShouldSkip(constructor.EnclosingType))
            {
                return base.VisitConstructor(constructor);
            }

            PropertyProvider clientDiagnosticsProperty = constructor.EnclosingType
               .Properties.First(p => p.Name == ClientDiagnosticsPropertyName);
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

                constructor.Update(signature: updatedSignature, bodyStatements: updatedBody);
            }

            return constructor;
        }

        protected override MethodProvider? VisitMethod(MethodProvider method)
        {
            if (ShouldSkip(method.EnclosingType) || !IsSubClientFactoryMethod(method))
            {
                return base.VisitMethod(method);
            }

            UpdateDistributedTracingRefInSubClientFactoryMethod(method);

            return method;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (ShouldSkip(method.EnclosingType) || !method.IsProtocolMethod)
            {
                return base.VisitMethod(method);
            }

            // Wrap protocol methods with distributed tracing
            UpdateProtocolMethodsWithDistributedTracing(method);

            return method;
        }

        private static void UpdateDistributedTracingRefInSubClientFactoryMethod(
            MethodProvider method)
        {
            if (method.BodyStatements != null)
            {
                PropertyProvider clientDiagnosticsProperty = method.EnclosingType.Properties
                    .First(p => p.Name == ClientDiagnosticsPropertyName);
                List<MethodBodyStatement> updatedFactoryMethodStatements = [];
                foreach (var statement in method.BodyStatements.Flatten())
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
        }

        private static void UpdateProtocolMethodsWithDistributedTracing(MethodProvider method)
        {
            string scopeName = $"{method.EnclosingType.Name}.{method.Signature.Name}";
            PropertyProvider clientDiagnosticsProperty = method.EnclosingType.Properties.First(p => p.Name == ClientDiagnosticsPropertyName);

            // declare scope
            var scopeDeclaration = UsingDeclare(
                "scope",
                typeof(DiagnosticScope),
                clientDiagnosticsProperty.Invoke(nameof(ClientDiagnostics.CreateScope), [Literal(scopeName)], false, false),
                out var scope);
            // start scope
            var scopeStart = scope.Invoke(nameof(DiagnosticScope.Start)).Terminate();
            // wrap existing statements in try / catch
            var tryStatement = new TryStatement
                {
                    method.BodyStatements ?? MethodBodyStatement.EmptyLine
                };
            var catchBlock = new CatchStatement(Declare("e", typeof(Exception), out var exception))
                {
                    scope.Invoke(nameof(DiagnosticScope.Failed), [exception]).Terminate(),
                    Throw()
                };
            var tryCatchRequestBlock = new TryCatchFinallyStatement(tryStatement, catchBlock);
            List<MethodBodyStatement> updatedBodyStatements = [scopeDeclaration, scopeStart, MethodBodyStatement.EmptyLine, tryCatchRequestBlock];

            method.Update(bodyStatements: updatedBodyStatements);
        }

        private static void AddDistributedTracingProperty(ClientProvider client)
        {
            // Enable distributed tracing if the ClientDiagnostics property is not already present
            if (client.CanonicalView.Properties.Any(p => p.Name == ClientDiagnosticsPropertyName))
            {
                return;
            }

            var existingCount = client.Properties.Count;
            List<PropertyProvider> updatedProperties = new(existingCount + 1);
            updatedProperties.AddRange(client.Properties);

            PropertyProvider clientDiagnosticsProperty = new(
                $"{ClientDiagnosticsPropertyDescription}",
                MethodSignatureModifiers.Internal,
                new CSharpType(typeof(ClientDiagnostics)),
                ClientDiagnosticsPropertyName,
                new AutoPropertyBody(false),
                client
                );

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

        private static bool ShouldSkip(TypeProvider typeProvider)
        {
            return typeProvider is not ClientProvider || !typeProvider.Properties.Any(p => p.Name == ClientDiagnosticsPropertyName);
        }

        private static bool IsSubClientFactoryMethod(MethodProvider method)
        {
            return method.Signature.ReturnType?.IsFrameworkType == false &&
                method.Signature.Name.StartsWith("Get") && method.Signature.Name.EndsWith("Client");
        }
    }
}
