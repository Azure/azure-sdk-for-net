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
using static Microsoft.TypeSpec.Generator.Snippets.StringSnippets;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that applies Azure-specific modifications to ClientOptions and ClientProvider constructors.
    /// <list type="bullet">
    /// <item>ClientOptions: Changes IConfigurationSection constructor to use base(section, null)
    /// and adds a partial void ConfigureLogging() method called from all constructors.</item>
    /// <item>ClientProvider: Removes the internal AuthenticationPolicy constructor (Azure clients use
    /// credential types directly), inlines its body into the "with options" credential constructors,
    /// and modifies the Settings constructor to chain to the appropriate credential constructor.</item>
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

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            // Remove the internal AuthenticationPolicy constructor from ClientProviders.
            // Azure clients use credential types (TokenCredential, AzureKeyCredential) directly
            // instead of the base library's AuthenticationPolicy abstraction.
            // The "with options" credential constructors have their body inlined by Visit().
            if (constructor.EnclosingType is ClientProvider &&
                constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                constructor.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)))
            {
                return null;
            }

            // Remove Settings constructor if no credential constructors exist in the client.
            // Libraries without credential support don't get a Settings/configuration constructor.
            if (constructor.EnclosingType is ClientProvider &&
                constructor.Signature.Parameters.Count == 1 &&
                constructor.Signature.Parameters[0].Type.Name.EndsWith("Settings"))
            {
                var allConstructors = constructor.EnclosingType.Constructors;
                bool hasAnyCred = allConstructors.Any(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    c.Signature.Parameters.Count >= 3 &&
                    c.Signature.Parameters.Any(p =>
                        p.Type.Name == nameof(TokenCredential) ||
                        p.Type.Name == nameof(AzureKeyCredential)));
                if (!hasAnyCred)
                {
                    return null;
                }
            }

            return base.VisitConstructor(constructor);
        }

        private static void UpdateClientConstructors(ClientProvider clientProvider)
        {
            var constructors = clientProvider.Constructors;

            // Find the internal AuthenticationPolicy constructor to inline its body
            var internalCtor = constructors.FirstOrDefault(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                c.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)));

            if (internalCtor != null)
            {
                var internalBody = internalCtor.BodyStatements;
                var authPolicyParam = internalCtor.Signature.Parameters.First(
                    p => p.Type.Name == nameof(AuthenticationPolicy));

                // Inline the internal constructor's body into "with options" credential constructors
                // that previously chained to it via : this(policyExpr, endpoint, options)
                foreach (var ctor in constructors)
                {
                    if (ctor == internalCtor) continue;

                    var initializer = ctor.Signature.Initializer;
                    if (initializer != null && !initializer.IsBase &&
                        initializer.Arguments.Count == internalCtor.Signature.Parameters.Count &&
                        ctor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        ctor.Signature.Parameters.Count >= 3 &&
                        ctor.Signature.Parameters.Any(p =>
                            p.Type.Name == nameof(TokenCredential) ||
                            p.Type.Name == nameof(AzureKeyCredential)))
                    {
                        InlineInternalBody(ctor, initializer, authPolicyParam, internalBody);
                    }
                }
            }

            // Modify Settings constructor to chain to the appropriate credential constructor
            foreach (var ctor in constructors)
            {
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
        }

        private static void InlineInternalBody(
            ConstructorProvider ctor,
            ConstructorInitializer initializer,
            ParameterProvider authPolicyParam,
            MethodBodyStatement? internalBody)
        {
            // The first argument of the initializer is the policy expression
            // (e.g., new AzureKeyCredentialPolicy(credential, AuthorizationHeader))
            var policyExpr = initializer.Arguments[0];

            // Declare a local variable with the same name as the internal constructor's parameter
            // so the copied body statements can reference it by name
            var declarePolicy = Declare(authPolicyParam.Name, HttpPipelinePolicyType, policyExpr, out _);

            if (internalBody != null)
            {
                ctor.Update(bodyStatements: new List<MethodBodyStatement> { declarePolicy, internalBody });
            }

            // Remove the chaining initializer since the body is now inline
            ctor.Signature.Update(initializer: null);
        }

        private static void UpdateSettingsConstructor(ConstructorProvider settingsCtor, bool hasTokenCredCtor, bool hasKeyCredCtor)
        {
            var existingArgs = settingsCtor.Signature.Initializer!.Arguments;
            var settingsParam = settingsCtor.Signature.Parameters[0];

            if (hasTokenCredCtor)
            {
                // Build: settings?.CredentialProvider as TokenCredential
                var credentialProviderAccess = settingsParam.NullConditional().Property(nameof(ClientSettings.CredentialProvider));
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
                var credentialAccess = settingsParam.NullConditional().Property(nameof(ClientSettings.Credential));
                var credentialSourceProp = credentialAccess.NullConditional().Property(nameof(CredentialSettings.CredentialSource));

                var stringEqualsCall = Equals(
                    credentialSourceProp.As<string>(),
                    Literal("apikeycredential").As<string>(),
                    StringComparison.OrdinalIgnoreCase);

                var keyAccess = settingsParam.Property(nameof(ClientSettings.Credential)).Property(nameof(CredentialSettings.Key));
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
