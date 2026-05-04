// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

#pragma warning disable SCME0002

namespace Azure.Generator.Providers
{
    /// <summary>
    /// Defines a per-client static class with strongly-typed extension methods on
    /// <see cref="IHostApplicationBuilder"/> that delegate to the generic
    /// <c>AddAzureClient</c> / <c>AddKeyedAzureClient</c> methods from
    /// <see cref="ConfigurationExtensions"/>, filling in the client and settings type parameters.
    /// </summary>
    internal class ClientHostExtensionsDefinition : TypeProvider
    {
        private static readonly CSharpType IHostApplicationBuilderType = typeof(IHostApplicationBuilder);
        private static readonly CSharpType ConfigurationExtensionsType = typeof(ConfigurationExtensions);
        private static readonly CSharpType IClientBuilderType = typeof(System.ClientModel.Primitives.IClientBuilder);

        private readonly ClientProvider _client;
        private readonly CSharpType _settingsType;

        public ClientHostExtensionsDefinition(ClientProvider client)
        {
            _client = client;
            _settingsType = client.ClientSettings!.Type;
            AzureClientGenerator.Instance.AddTypeToKeep(this, isRoot: false);
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override string BuildName() => $"{_client.Name}HostExtensions";

        protected override string BuildNamespace() => _client.Type.Namespace;

        protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
            TypeSignatureModifiers.Public | TypeSignatureModifiers.Static;

        protected override FormattableString BuildDescription() =>
            $"Extension methods to add {_client.Type:C} to an {IHostApplicationBuilderType:C}.";

        protected override IReadOnlyList<MethodBodyStatement> BuildAttributes() =>
        [
            new AttributeStatement(typeof(ExperimentalAttribute), Literal("SCME0002"))
        ];

        protected override MethodProvider[] BuildMethods()
        {
            var hostParam = new ParameterProvider(
                "host",
                $"The {IHostApplicationBuilderType:C} to add to.",
                IHostApplicationBuilderType);
            var sectionNameParam = new ParameterProvider(
                "sectionName",
                $"The section of {typeof(Microsoft.Extensions.Configuration.IConfiguration):C} to use.",
                typeof(string));
            var keyParam = new ParameterProvider(
                "key",
                $"The unique key to register as.",
                typeof(string));
            var configureSettingsParam = new ParameterProvider(
                "configureSettings",
                $"Factory method to modify the {_settingsType:C} after they are created.",
                new CSharpType(typeof(Action<>), _settingsType));

            FormattableString returnDescription =
                $"An {IClientBuilderType:C} that can be used to further configure the client.";
            FormattableString singletonDescription =
                $"Adds a singleton {_client.Type:C} to the {IHostApplicationBuilderType:C}'s service collection.";
            FormattableString keyedDescription =
                $"Adds a keyed singleton {_client.Type:C} to the {IHostApplicationBuilderType:C}'s service collection.";

            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static |
                            MethodSignatureModifiers.Extension;
            var typeArgs = new[] { _client.Type, _settingsType };

            return
            [
                BuildOverload(
                    $"Add{_client.Name}",
                    singletonDescription,
                    [hostParam, sectionNameParam],
                    nameof(ConfigurationExtensions.AddAzureClient),
                    [sectionNameParam],
                    typeArgs,
                    hostParam,
                    returnDescription,
                    modifiers),
                BuildOverload(
                    $"Add{_client.Name}",
                    singletonDescription,
                    [hostParam, sectionNameParam, configureSettingsParam],
                    nameof(ConfigurationExtensions.AddAzureClient),
                    [sectionNameParam, configureSettingsParam],
                    typeArgs,
                    hostParam,
                    returnDescription,
                    modifiers),
                BuildOverload(
                    $"AddKeyed{_client.Name}",
                    keyedDescription,
                    [hostParam, keyParam, sectionNameParam],
                    nameof(ConfigurationExtensions.AddKeyedAzureClient),
                    [keyParam, sectionNameParam],
                    typeArgs,
                    hostParam,
                    returnDescription,
                    modifiers),
                BuildOverload(
                    $"AddKeyed{_client.Name}",
                    keyedDescription,
                    [hostParam, keyParam, sectionNameParam, configureSettingsParam],
                    nameof(ConfigurationExtensions.AddKeyedAzureClient),
                    [keyParam, sectionNameParam, configureSettingsParam],
                    typeArgs,
                    hostParam,
                    returnDescription,
                    modifiers)
            ];
        }

        private MethodProvider BuildOverload(
            string methodName,
            FormattableString description,
            IReadOnlyList<ParameterProvider> parameters,
            string targetMethodName,
            IReadOnlyList<ParameterProvider> targetArgs,
            IReadOnlyList<CSharpType> typeArgs,
            ParameterProvider hostParam,
            FormattableString returnDescription,
            MethodSignatureModifiers modifiers)
        {
            var args = new ValueExpression[targetArgs.Count];
            for (int i = 0; i < targetArgs.Count; i++)
            {
                args[i] = targetArgs[i];
            }

            var invoke = hostParam.Invoke(targetMethodName, args, typeArgs, ConfigurationExtensionsType);

            return new MethodProvider(
                new MethodSignature(
                    methodName,
                    description,
                    modifiers,
                    IClientBuilderType,
                    returnDescription,
                    parameters),
                Return(invoke),
                enclosingType: this);
        }
    }
}
