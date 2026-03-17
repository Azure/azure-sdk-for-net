// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that applies Azure-specific modifications to ClientOptions and ClientProvider constructors.
    /// <list type="bullet">
    /// <item>ClientOptions: Changes IConfigurationSection constructor to use base(section, null)
    /// and adds a partial void ConfigureLogging() method called from all constructors.</item>
    /// <item>ClientProvider: Changes the internal AuthenticationPolicy constructor parameter type to
    /// HttpPipelinePolicy (Azure clients use Azure.Core policy types instead of the base library's
    /// AuthenticationPolicy), and modifies the Settings constructor to chain to the appropriate
    /// credential constructor (or to the internal constructor with null auth policy when no
    /// credentials are configured).</item>
    /// </list>
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private const string ConfigureLoggingMethodName = "ConfigureLogging";
        private static readonly CSharpType IConfigurationSectionType = typeof(IConfigurationSection);
        private static readonly CSharpType TokenCredentialType = typeof(TokenCredential);
        private static readonly CSharpType AzureKeyCredentialType = typeof(AzureKeyCredential);
        private static readonly CSharpType HttpPipelinePolicyType = typeof(HttpPipelinePolicy);
        private readonly HashSet<ClientOptionsProvider> _visitedOptions = new();

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            if (clientProvider.ClientOptions != null && _visitedOptions.Add(clientProvider.ClientOptions))
            {
                UpdateClientOptions(clientProvider.ClientOptions);
            }

            UpdateClientConstructors(clientProvider);

            return clientProvider;
        }

        private static void UpdateClientConstructors(ClientProvider clientProvider)
        {
            var constructors = clientProvider.Constructors;

            // Azure clients use HttpPipelinePolicy (from Azure.Core) instead of the base library's
            // AuthenticationPolicy abstraction. Change the parameter type on the internal constructor
            // so that credential constructors can chain to it with Azure-specific policy types
            // (AzureKeyCredentialPolicy, BearerTokenAuthenticationPolicy).
            var internalCtor = constructors.FirstOrDefault(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                c.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)));
            if (internalCtor != null)
            {
                var authPolicyParam = internalCtor.Signature.Parameters.First(
                    p => p.Type.Name == nameof(AuthenticationPolicy));
                authPolicyParam.Update(type: HttpPipelinePolicyType);
            }

            // Modify Settings constructor to chain to the appropriate credential constructor
            foreach (var ctor in constructors)
            {
                if (ctor.Signature.Parameters.Count == 1 &&
                    ctor.Signature.Parameters[0].Type.Equals(clientProvider.ClientSettings?.Type))
                {
                    bool hasTokenCredCtor = constructors.Any(c =>
                        c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        c.Signature.Parameters.Any(p => p.Type.Equals(typeof(TokenCredential))) &&
                        c.Signature.Parameters.Count >= 3);

                    bool hasKeyCredCtor = constructors.Any(c =>
                        c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        c.Signature.Parameters.Any(p => p.Type.Equals(typeof(AzureKeyCredential))) &&
                        c.Signature.Parameters.Count >= 3);

                    if (hasTokenCredCtor || hasKeyCredCtor)
                    {
                        UpdateSettingsConstructor(ctor, hasTokenCredCtor, hasKeyCredCtor);
                    }
                    else
                    {
                        UpdateSettingsConstructorForNoAuth(ctor);
                    }
                }
            }
        }

        private static void UpdateSettingsConstructor(ConstructorProvider settingsCtor, bool hasTokenCredCtor, bool hasKeyCredCtor)
        {
            var existingArgs = settingsCtor.Signature.Initializer!.Arguments;
            var settingsParam = settingsCtor.Signature.Parameters[0];

            if (hasTokenCredCtor)
            {
                // Build: settings?.CredentialProvider as TokenCredential
#pragma warning disable SCME0002
                var credentialProviderAccess = settingsParam.NullConditional().Property(nameof(ClientSettings.CredentialProvider));
#pragma warning restore SCME0002
                var tokenCredentialArg = new AsExpression(credentialProviderAccess, TokenCredentialType);

                var newArgs = new List<ValueExpression>();
                newArgs.Add(existingArgs[1]); // endpoint
                newArgs.Add(tokenCredentialArg); // credential
                for (int i = 2; i < existingArgs.Count; i++)
                {
                    newArgs.Add(existingArgs[i]);
                }

                settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, newArgs));
            }
            else if (hasKeyCredCtor)
            {
                // Key-credential only library.
                // Build a ternary: check CredentialSource == "apikeycredential" (case-insensitive),
                // construct AzureKeyCredential if true, otherwise pass null.
#pragma warning disable SCME0002
                var credentialAccess = settingsParam.NullConditional().Property(nameof(ClientSettings.Credential));
                var credentialSourceProp = credentialAccess.NullConditional().Property(nameof(CredentialSettings.CredentialSource));
#pragma warning restore SCME0002

                var stringEqualsCall = StringSnippets.Equals(
                    credentialSourceProp.As<string>(),
                    Literal("apikeycredential").As<string>(),
                    StringComparison.OrdinalIgnoreCase);

#pragma warning disable SCME0002
                var keyAccess = settingsParam.Property(nameof(ClientSettings.Credential)).Property(nameof(CredentialSettings.Key));
#pragma warning restore SCME0002
                var newKeyCredential = New.Instance(AzureKeyCredentialType, [keyAccess]);

                var keyCredentialArg = new TernaryConditionalExpression(
                    stringEqualsCall,
                    newKeyCredential,
                    Null);

                var newArgs = new List<ValueExpression>();
                newArgs.Add(existingArgs[1]); // endpoint
                newArgs.Add(keyCredentialArg); // credential
                for (int i = 2; i < existingArgs.Count; i++)
                {
                    newArgs.Add(existingArgs[i]);
                }

                settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, newArgs));
            }
        }

        private static void UpdateSettingsConstructorForNoAuth(ConstructorProvider settingsCtor)
        {
            // No credential constructors — replace the AuthenticationPolicy.Create(settings)
            // argument with null so the internal constructor receives a null auth policy.
            // Cast to HttpPipelinePolicy to avoid overload ambiguity.
            var existingArgs = settingsCtor.Signature.Initializer!.Arguments;
            var newArgs = new List<ValueExpression>();
            newArgs.Add(Null.CastTo(HttpPipelinePolicyType));
            for (int i = 1; i < existingArgs.Count; i++)
            {
                newArgs.Add(existingArgs[i]);
            }
            settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, newArgs));
        }

        private static void UpdateClientOptions(ClientOptionsProvider options)
        {
            UpdateClientOptionsConstructors(options);
            AddLoggingConfigurationMethods(options);
        }

        private static void UpdateClientOptionsConstructors(ClientOptionsProvider options)
        {
            foreach (var ctor in options.Constructors)
            {
                var sectionParam = ctor.Signature.Parameters.FirstOrDefault(
                    p => p.Type.Equals(IConfigurationSectionType));

                if (sectionParam != null)
                {
                    // This is the IConfigurationSection constructor - change initializer
                    // from : base(section) to : base(section, null)
                    // Azure.Core.ClientOptions takes (IConfigurationSection, DiagnosticsOptions?)
                    var azureBaseInitializer = new ConstructorInitializer(
                        true,
                        [sectionParam, Null]);

                    ctor.Signature.Update(initializer: azureBaseInitializer);
                }

                // Call ConfigureLogging() from all constructors
                var configureLoggingCall = This.Invoke(ConfigureLoggingMethodName).Terminate();
                List<MethodBodyStatement> updatedBody = ctor.BodyStatements != null
                    ? [ctor.BodyStatements, configureLoggingCall]
                    : [configureLoggingCall];
                ctor.Update(bodyStatements: updatedBody);
            }
        }

        private static void AddLoggingConfigurationMethods(ClientOptionsProvider options)
        {
            // Add: partial void ConfigureLogging();
            // Services can implement this to configure service-specific logging (headers, query params).
            // If not implemented, the call is removed at compile time.
            var configureLoggingSignature = new MethodSignature(
                ConfigureLoggingMethodName,
                (FormattableString)$"Configures logging for the client options.",
                MethodSignatureModifiers.Partial,
                null,
                null,
                []);

            var configureLoggingMethod = new MethodProvider(configureLoggingSignature, options);

            options.Update(methods: [.. options.Methods, configureLoggingMethod]);
        }
    }
}
