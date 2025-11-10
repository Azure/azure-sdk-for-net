// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    /// <summary>
    /// Defines the client builder extension methods for integration with Microsoft.Extensions.Azure.
    /// </summary>
    internal class ClientBuilderExtensionsDefinition : TypeProvider
    {
        private readonly IEnumerable<ClientProvider> _publicClients;
        private readonly string _resourceProviderName;

        public ClientBuilderExtensionsDefinition(IEnumerable<ClientProvider> publicClients)
        {
            _publicClients = publicClients;
            _resourceProviderName = TypeNameUtilities.GetResourceProviderName();
            AzureClientGenerator.Instance.AddTypeToKeep(this, isRoot: false);
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName() => $"{_resourceProviderName}ClientBuilderExtensions";

        protected override string BuildNamespace() => "Microsoft.Extensions.Azure";

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Public | TypeSignatureModifiers.Static | TypeSignatureModifiers.Partial;

        protected override FormattableString BuildDescription() => $"Extension methods to add clients to <see cref=\"{typeof(IAzureClientBuilder<,>)}\"/>.";

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>();
            foreach (var client in _publicClients)
            {
                if (client.ClientOptionsParameter == null)
                {
                    continue;
                }

                var tBuilder = typeof(BuilderType<,>).GetGenericArguments()[0];
                var tConfiguration = typeof(BuilderType<,>).GetGenericArguments()[1];
                var builderParameter = new ParameterProvider("builder", $"The builder to register with.", tBuilder);
                var configurationParameter = new ParameterProvider(
                    "configuration",
                    $"The configuration to use for the client.",
                    tConfiguration);
                var methodName = $"Add{client.Name}";
                FormattableString methodDescription =
                    $"Registers a <see cref=\"{client.Name}\"/> client with the specified <see cref=\"{typeof(IAzureClientBuilder<,>)}\"/>.";
                var methodModifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static |
                                      MethodSignatureModifiers.Extension;
                var methodReturnType = new CSharpType(typeof(IAzureClientBuilder<,>), client.Type,
                    client.ClientOptionsParameter.Type);

                foreach (var constructor in client.CanonicalView.Constructors)
                {
                    if (!constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        continue;
                    }

                    // only add overloads for the full constructors that include the client options parameter
                    if (constructor.Signature.Parameters.LastOrDefault()?.Type.Equals(client.ClientOptionsParameter.Type) != true)
                    {
                        continue;
                    }

                    // get the second to last parameter, which is the location of the auth credential parameter if there is one
                    var authParameter = constructor.Signature.Parameters[^2];
                    var isTokenCredential = authParameter?.Type.Equals(typeof(TokenCredential)) == true;
                    var parameters = new List<ParameterProvider>(constructor.Signature.Parameters.Count + 1);
                    parameters.Add(builderParameter);
                    parameters.AddRange(isTokenCredential ? constructor.Signature.Parameters.SkipLast(2) : constructor.Signature.Parameters.SkipLast(1));
                    var method = new MethodProvider(
                        new MethodSignature(
                            methodName,
                            methodDescription,
                            methodModifiers,
                            methodReturnType,
                            null,
                            parameters,
                            GenericArguments: [tBuilder],
                            GenericParameterConstraints: [Where.Implements(tBuilder, isTokenCredential ?
                                typeof(IAzureClientFactoryBuilderWithCredential) :
                                typeof(IAzureClientFactoryBuilder))]),
                        bodyStatements:
                            Return(builderParameter.Invoke(
                                "RegisterClientFactory",
                                args: [BuildFuncExpression(client, constructor.Signature, isTokenCredential)],
                                typeArgs: [client.Type, client.ClientOptionsParameter.Type])),
                        enclosingType: this);
                    methods.Add(method);
                }

                // Add the configuration overload
                var requiresUnreferencedCodeMessage = Literal("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.");
                methods.Add(new MethodProvider(
                    new MethodSignature(
                        methodName,
                        methodDescription,
                        methodModifiers,
                        methodReturnType,
                        null,
                        [builderParameter, configurationParameter],
                        Attributes:
                        [
                            new AttributeStatement(
                                typeof(RequiresUnreferencedCodeAttribute),
                                requiresUnreferencedCodeMessage),
                            new AttributeStatement(
                                typeof(RequiresDynamicCodeAttribute),
                                requiresUnreferencedCodeMessage)
                        ],
                        GenericArguments: [tBuilder, tConfiguration],
                        GenericParameterConstraints:
                        [
                            Where.Implements(
                                tBuilder,
                                new CSharpType(typeof(IAzureClientFactoryBuilderWithConfiguration<>), tConfiguration))
                        ]),
                    bodyStatements:
                        Return(builderParameter.Invoke(
                            "RegisterClientFactory",
                            args: [configurationParameter],
                            typeArgs: [client.Type, client.ClientOptionsParameter.Type])),
                    enclosingType: this));
            }

            return [.. methods];
        }

        private static FuncExpression BuildFuncExpression(ClientProvider client, ConstructorSignature constructorSignature, bool isTokenCredential)
        {
            var options = constructorSignature.Parameters.Last();
            var token = new VariableExpression(typeof(TokenCredential), "credential");

            ValueExpression[] ctorArgs = isTokenCredential ?
                [.. constructorSignature.Parameters.SkipLast(2), token, options] :
                [.. constructorSignature.Parameters];

            return new FuncExpression(
                isTokenCredential ? [options.AsVariable().Declaration, token.Declaration] : [options.AsVariable().Declaration],
                New.Instance(client.Type, ctorArgs));
        }

        private class BuilderType<TBuilder, TConfiguration>
        {
        }
    }
}