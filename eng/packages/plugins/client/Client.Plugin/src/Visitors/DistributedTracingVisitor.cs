// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Client.Plugin.Visitors
{
    /// <summary>
    /// Visitor that adds distributed tracing support to generated client code using System.Diagnostics.ActivitySource.
    /// </summary>
    internal class DistributedTracingVisitor : ScmLibraryVisitor
    {
        private const string ActivitySourcePropertyName = "ActivitySource";
        private const string OptionsPropertyName = "_options";

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            bool hasExistingProperty = clientProvider.CanonicalView.Properties
                .Any(p => p.Name == ActivitySourcePropertyName);
            if (hasExistingProperty)
            {
                return base.Visit(client, clientProvider);
            }

            AddDistributedTracingProperties(clientProvider);

            return clientProvider;
        }

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            if (ShouldSkipType(constructor.EnclosingType))
            {
                return base.VisitConstructor(constructor);
            }

            PropertyProvider optionsProperty = constructor.EnclosingType.CanonicalView.Properties
                .First(p => p.Name == OptionsPropertyName);
            ParameterProvider? endpoint = constructor.Signature.Parameters.FirstOrDefault(p => p.Name == "endpoint");
            ParameterProvider? options = constructor.Signature.Parameters.FirstOrDefault(p => p.Name == "options");
            bool hasNoInitializer = constructor.Signature.Initializer == null;
            bool isSubClientConstructor = hasNoInitializer &&
                   constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                   endpoint != null;
            bool isPrimaryConstructor = hasNoInitializer && options != null;

            if (isPrimaryConstructor)
            {
                var assignOptions = optionsProperty.Assign(options!).Terminate();
                List<MethodBodyStatement> constructorBody = constructor.BodyStatements != null
                    ? [constructor.BodyStatements, assignOptions]
                    : [assignOptions];

                constructor.Update(bodyStatements: constructorBody);
            }
            else if (isSubClientConstructor)
            {
                XmlDocProvider? updatedXmlDocs = constructor.XmlDocs;
                if (updatedXmlDocs != null)
                {
                    List<XmlDocParamStatement> updatedParametersXmlDoc = [new XmlDocParamStatement(optionsProperty.AsParameter), .. updatedXmlDocs.Parameters];
                    updatedXmlDocs.Update(parameters: updatedParametersXmlDoc);
                }

                var updatedSignature = new ConstructorSignature(
                   constructor.Signature.Type,
                   constructor.Signature.Description,
                   constructor.Signature.Modifiers,
                   [optionsProperty.AsParameter, .. constructor.Signature.Parameters],
                   constructor.Signature.Attributes,
                   constructor.Signature.Initializer);
                var assignOptions = optionsProperty.Assign(optionsProperty.AsParameter).Terminate();
                List<MethodBodyStatement> updatedBody = constructor.BodyStatements != null
                    ? [assignOptions, constructor.BodyStatements]
                    : [assignOptions];

                constructor.Update(signature: updatedSignature, bodyStatements: updatedBody, xmlDocs: updatedXmlDocs);
            }

            return constructor;
        }

        protected override ScmMethodProvider? VisitMethod(ScmMethodProvider method)
        {
            if (ShouldSkipType(method.EnclosingType) || ShouldSkipMethod(method))
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

        private static void AddDistributedTracingProperties(ClientProvider client)
        {
            List<PropertyProvider> updatedProperties = new(client.Properties.Count + 2);
            updatedProperties.AddRange(client.Properties);

            // Add static ActivitySource property with inline initializer
            var activitySourceName = $"{client.Type.Namespace}.{client.Type.Name}";
            PropertyProvider activitySourceProperty = new(
                $"The ActivitySource used for distributed tracing for the {client.Type.Name} client.",
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                new CSharpType(typeof(ActivitySource)),
                ActivitySourcePropertyName,
                new AutoPropertyBody(false, MethodSignatureModifiers.None, New.Instance(typeof(ActivitySource), [Literal(activitySourceName)])),
                client);

            // Add _options instance property for per-call options access
            PropertyProvider optionsProperty = new(
                $"The options for configuring the {client.Type.Name} client.",
                MethodSignatureModifiers.Internal,
                new CSharpType(typeof(ClientPipelineOptions)),
                OptionsPropertyName,
                new AutoPropertyBody(false),
                client);

            updatedProperties.Add(activitySourceProperty);
            updatedProperties.Add(optionsProperty);

            client.Update(properties: updatedProperties);
        }

        private static void UpdateProtocolMethodsWithDistributedTracing(ScmMethodProvider method)
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

            ClientProvider clientProvider = (ClientProvider)method.EnclosingType;
            PropertyProvider activitySourceProperty = clientProvider.CanonicalView.Properties
                .First(p => p.Name == ActivitySourcePropertyName);
            PropertyProvider optionsProperty = clientProvider.CanonicalView.Properties
                .First(p => p.Name == OptionsPropertyName);

            // using Activity? activity = ActivitySource.StartClientActivity(_options, "ScopeName");
            var activityDeclaration = UsingDeclare(
                "activity",
                new CSharpType(typeof(Activity), true),
                activitySourceProperty.Invoke(nameof(ActivityExtensions.StartClientActivity), [optionsProperty, Literal(scopeName)], false, false),
                out var activity);

            // wrap existing statements in try / catch
            var tryStatement = new TryExpression(
                method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!)
            );

            var catchBlock = new CatchExpression(
                Declare("e", typeof(Exception), out var exception),
                activity.NullConditional().Invoke(nameof(ActivityExtensions.MarkClientActivityFailed), [exception]).Terminate(),
                Throw());
            var tryCatchBlock = new TryCatchFinallyStatement(tryStatement, catchBlock);
            List<MethodBodyStatement> updatedBodyStatements = [activityDeclaration, tryCatchBlock];

            method.Update(bodyStatements: updatedBodyStatements);
        }

        private static void UpdateDistributedTracingRefInSubClientFactoryMethod(ScmMethodProvider method)
        {
            if (method.BodyStatements == null && method.BodyExpression == null)
            {
                return;
            }

            PropertyProvider optionsProperty = ((ClientProvider)method.EnclosingType).CanonicalView.Properties
                .First(p => p.Name == OptionsPropertyName);
            List<MethodBodyStatement> updatedFactoryMethodStatements = [];

            var statementsToVisit = method.BodyStatements ?? new ExpressionStatement(method.BodyExpression!);
            foreach (var statement in statementsToVisit)
            {
                if (TryUpdateSubClientFactoryMethodReturnStatement(
                    statement,
                    optionsProperty,
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

        private static bool TryUpdateSubClientFactoryMethodReturnStatement(
            MethodBodyStatement originalStatement,
            PropertyProvider options,
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
            // & update the arguments to pass the options property
            List<ValueExpression> updatedArguments = new(invokeMethodExpression.Arguments.Count + 1);
            foreach (var arg in invokeMethodExpression.Arguments)
            {
                if (arg is NewInstanceExpression ctorInstantiationExpression)
                {
                    updatedArguments.Add(new NewInstanceExpression(
                        ctorInstantiationExpression.Type,
                        [options, .. ctorInstantiationExpression.Parameters],
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

            // return Volatile.Read(ref _cachedT) ?? Interlocked.CompareExchange(ref _cachedT, new T(_options, _pipeline, _endpoint), null) ?? _cachedT;
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
                    .Any(p => p.Name == ActivitySourcePropertyName);
        }

        private static bool ShouldSkipMethod(ScmMethodProvider method)
        {
            // Skip instrumentation for paging methods as they have built-in instrumentation
            return method.ServiceMethod is InputPagingServiceMethod;
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
