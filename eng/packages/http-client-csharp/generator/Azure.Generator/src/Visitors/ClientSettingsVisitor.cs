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
    /// <item>ClientProvider: Changes the internal constructor's AuthenticationPolicy parameter to
    /// HttpPipelinePolicy for Azure.Core compatibility, and modifies the Settings constructor to
    /// chain to the appropriate credential constructor.</item>
    /// </list>
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private const string ConfigureLoggingMethodName = "ConfigureLogging";
        private static readonly CSharpType IConfigurationSectionType = typeof(IConfigurationSection);
        private static readonly CSharpType TokenCredentialType = typeof(TokenCredential);
        private static readonly CSharpType AzureKeyCredentialType = typeof(AzureKeyCredential);
        private static readonly CSharpType HttpPipelinePolicyType = typeof(HttpPipelinePolicy);

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            if (clientProvider.ClientOptions != null)
            {
                UpdateClientOptions(clientProvider.ClientOptions);
            }

            UpdateClientConstructors(clientProvider);

            return clientProvider;
        }

        private static void UpdateClientConstructors(ClientProvider clientProvider)
        {
            var constructors = clientProvider.Constructors;

            foreach (var ctor in constructors)
            {
                // Change the internal AuthenticationPolicy constructor's parameter type
                // from AuthenticationPolicy (System.ClientModel) to HttpPipelinePolicy (Azure.Core.Pipeline)
                // so that Azure policy types (AzureKeyCredentialPolicy, BearerTokenAuthenticationPolicy)
                // can be passed to it from the "with options" constructors.
                if (ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                    ctor.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)))
                {
                    var authPolicyParam = ctor.Signature.Parameters.First(
                        p => p.Type.Name == nameof(AuthenticationPolicy));
                    authPolicyParam.Type = HttpPipelinePolicyType;
                }

                // Modify the Settings constructor to chain to a credential constructor
                if (ctor.Signature.Parameters.Count == 1 &&
                    ctor.Signature.Parameters[0].Type.Name.EndsWith("Settings"))
                {
                    bool hasTokenCredCtor = constructors.Any(c =>
                        c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        c.Signature.Parameters.Any(p => p.Type.Name == nameof(TokenCredential)) &&
                        c.Signature.Parameters.Count >= 3);

                    bool hasKeyCredCtor = constructors.Any(c =>
                        c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        c.Signature.Parameters.Any(p => p.Type.Name == nameof(AzureKeyCredential)) &&
                        c.Signature.Parameters.Count >= 3);

                    if (hasTokenCredCtor || hasKeyCredCtor)
                    {
                        UpdateSettingsConstructor(ctor, hasTokenCredCtor, hasKeyCredCtor);
                    }
                }
            }

            // Remove the Settings constructor if no credential constructor exists
            var settingsCtor = constructors.FirstOrDefault(c =>
                c.Signature.Parameters.Count == 1 &&
                c.Signature.Parameters[0].Type.Name.EndsWith("Settings"));
            if (settingsCtor != null)
            {
                bool hasAnyCred = constructors.Any(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    c.Signature.Parameters.Count >= 3 &&
                    c.Signature.Parameters.Any(p =>
                        p.Type.Name == nameof(TokenCredential) ||
                        p.Type.Name == nameof(AzureKeyCredential)));
                if (!hasAnyCred)
                {
                    clientProvider.Update(constructors: constructors.Where(c => c != settingsCtor).ToList());
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
                var credentialProviderAccess = new MemberExpression(new NullConditionalExpression(settingsParam), "CredentialProvider");
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
                var credentialAccess = new MemberExpression(
                    new NullConditionalExpression(settingsParam), "Credential");
                var credentialSourceProp = new MemberExpression(
                    new NullConditionalExpression(credentialAccess), "CredentialSource");

                var stringEqualsCall = Static(typeof(string)).Invoke("Equals", [
                    credentialSourceProp,
                    Literal("apikeycredential"),
                    Static(typeof(StringComparison)).Property("OrdinalIgnoreCase")]);

                var keyAccess = new MemberExpression(
                    new MemberExpression(settingsParam, "Credential"), "Key");
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
                        [sectionParam, Snippet.Null]);

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
