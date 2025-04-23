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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    internal class ClientVisitor : ScmLibraryVisitor
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";
        private const string ClientDiagnosticsPropertyDescription = "The ClientDiagnostics is used to provide tracing support for the client library.";

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            var visitedClient = base.Visit(client, clientProvider);
            if (visitedClient == null)
            {
                return null;
            }

            UpdateClient(client, visitedClient);

            return visitedClient;
        }

        private static void UpdateClient(InputClient inputClient, ClientProvider client)
        {
            // Enable distributed tracing
            AddDistributedTracing(inputClient, client);
        }

        private static void AddDistributedTracing(InputClient inputClient, ClientProvider client)
        {
            // Enable distributed tracing if the ClientDiagnostics property is not already present
            if (client.CanonicalView.Properties.Any(p => p.Name == ClientDiagnosticsPropertyName))
            {
                return;
            }

            List<PropertyProvider> updatedProperties = [.. client.CanonicalView.Properties];
            PropertyProvider clientDiagnosticsProperty = new(
                $"{ClientDiagnosticsPropertyDescription}",
                MethodSignatureModifiers.Internal,
                new CSharpType(typeof(ClientDiagnostics)),
                ClientDiagnosticsPropertyName,
                new AutoPropertyBody(false),
                client
                );

            updatedProperties.Add(clientDiagnosticsProperty);

            UpdatePrimaryConstructorWithDistributedTracing(client, clientDiagnosticsProperty);
            if (inputClient.Parent != null)
            {
                UpdateSubClientConstructorWithDistributedTracing(client, clientDiagnosticsProperty);
            }
            else
            {
                UpdateSubClientFactoryMethodsWithDistributedTracing(client, clientDiagnosticsProperty);
            }

            client.Update(properties: updatedProperties);
        }

        // This method instantiates the ClientDiagnostics property in the primary constructor of the client
        private static void UpdatePrimaryConstructorWithDistributedTracing(
            ClientProvider client,
            PropertyProvider clientDiagnosticsProperty)
        {
            ConstructorProvider? primaryConstructor = client.CanonicalView.Constructors.FirstOrDefault(
                   c => c.Signature.Initializer == null && c.Signature.Parameters.FirstOrDefault(p => p.Name == "options") != null);

            if (primaryConstructor == null)
            {
                return;
            }

            ParameterProvider clientOptionsParameter = primaryConstructor.Signature.Parameters.First(p => p.Name == "options");

            var assignClientDiagnostics = clientDiagnosticsProperty.Assign(
                    New.Instance(clientDiagnosticsProperty.Type, [clientOptionsParameter, True])).Terminate();
            List<MethodBodyStatement> constructorBody = primaryConstructor.BodyStatements != null
                ? [primaryConstructor.BodyStatements, assignClientDiagnostics]
                : [assignClientDiagnostics];

            primaryConstructor.Update(bodyStatements: constructorBody);
        }

        // This method adds the ClientDiagnostics parameter to the sub-client constructor &
        // assigns the ClientDiagnostics property within the constructor body.
        private static void UpdateSubClientConstructorWithDistributedTracing(
            ClientProvider client,
            PropertyProvider clientDiagnosticsProperty)
        {
            ConstructorProvider? subClientConstructor = client.CanonicalView.Constructors.FirstOrDefault(
                   c => c.Signature.Initializer == null &&
                   c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)
                   && c.Signature.Parameters.FirstOrDefault(p => p.Name == "endpoint") != null);

            if (subClientConstructor == null)
            {
                return;
            }

            var updatedSignature = new ConstructorSignature(
                    subClientConstructor.Signature.Type,
                    subClientConstructor.Signature.Description,
                    subClientConstructor.Signature.Modifiers,
                    [clientDiagnosticsProperty.AsParameter, .. subClientConstructor.Signature.Parameters],
                    subClientConstructor.Signature.Attributes,
                    subClientConstructor.Signature.Initializer);
            var assignClientDiagnostics = clientDiagnosticsProperty.Assign(clientDiagnosticsProperty.AsParameter).Terminate();
            List<MethodBodyStatement> updatedBody = subClientConstructor.BodyStatements != null
                ? [assignClientDiagnostics, subClientConstructor.BodyStatements]
                : [assignClientDiagnostics];

            subClientConstructor.Update(signature: updatedSignature, bodyStatements: updatedBody);
        }

        // This method adds the ClientDiagnostics property as an argument to the sub-client constructor invocation.
        private static void UpdateSubClientFactoryMethodsWithDistributedTracing(
            ClientProvider client,
            PropertyProvider clientDiagnosticsProperty)
        {
            // Update any subclient factory methods to include the ClientDiagnostics property as an argument
            foreach (var method in client.CanonicalView.Methods)
            {
                string clientName = method.Signature.Name;
                if (clientName.StartsWith("Get") && clientName.EndsWith("Client"))
                {
                    if (method.BodyStatements != null)
                    {
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
            }
        }

        // This method is used to update the return statement within a sub-client factory method
        // with the ClientDiagnostics property passed as an argument to the sub-client constructor.
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
    }
}
