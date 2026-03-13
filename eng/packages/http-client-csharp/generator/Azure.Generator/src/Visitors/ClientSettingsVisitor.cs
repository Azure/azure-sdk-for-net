// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
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
    /// <item>ClientProvider: Removes the internal AuthenticationPolicy constructor, modifies the
    /// Settings constructor to chain to the TokenCredential constructor using
    /// settings.TokenProvider as TokenCredential, and inlines the pipeline building body
    /// into the credential-based constructors that previously chained to the internal one.</item>
    /// </list>
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private const string ConfigureLoggingMethodName = "ConfigureLogging";
        private static readonly CSharpType IConfigurationSectionType = typeof(IConfigurationSection);
        private static readonly CSharpType AuthenticationPolicyType = typeof(AuthenticationPolicy);
        private static readonly CSharpType TokenCredentialType = typeof(TokenCredential);
        private static readonly CSharpType AzureKeyCredentialType = typeof(AzureKeyCredential);

        // Tracks the internal AuthenticationPolicy constructor body per client,
        // so we can inline it into the "with options" constructors.
        private MethodBodyStatement? _internalCtorBody;
        private int _internalCtorParamCount;

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

            // Pre-scan: find the internal AuthenticationPolicy constructor and save its body
            // before VisitConstructor is called on each constructor individually.
            _internalCtorBody = null;
            _internalCtorParamCount = 0;
            if (clientProvider.ClientSettings != null)
            {
                var authPolicyCtor = clientProvider.Constructors.FirstOrDefault(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                    c.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)));

                if (authPolicyCtor != null)
                {
                    _internalCtorBody = authPolicyCtor.BodyStatements;
                    _internalCtorParamCount = authPolicyCtor.Signature.Parameters.Count;
                }
            }

            return clientProvider;
        }

        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            if (constructor.EnclosingType is not ClientProvider clientProvider ||
                clientProvider.ClientSettings == null ||
                _internalCtorBody == null)
            {
                return constructor;
            }

            // Remove the internal AuthenticationPolicy constructor
            if (constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal) &&
                constructor.Signature.Parameters.Any(p => p.Type.Name == nameof(AuthenticationPolicy)))
            {
                return null;
            }

            // Modify the Settings constructor to chain to a credential constructor
            if (constructor.Signature.Parameters.Count == 1 &&
                constructor.Signature.Parameters[0].Type.Name.EndsWith("Settings"))
            {
                // Check if there's a TokenCredential constructor to chain to
                bool hasTokenCredCtor = clientProvider.Constructors.Any(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    c.Signature.Parameters.Any(p => p.Type.Name == nameof(TokenCredential)) &&
                    c.Signature.Parameters.Count >= 3);

                // Check if there's an AzureKeyCredential constructor to chain to
                bool hasKeyCredCtor = clientProvider.Constructors.Any(c =>
                    c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                    c.Signature.Parameters.Any(p => p.Type.Name == nameof(AzureKeyCredential)) &&
                    c.Signature.Parameters.Count >= 3);

                if (!hasTokenCredCtor && !hasKeyCredCtor)
                {
                    // No credential constructor — remove the Settings constructor entirely
                    return null;
                }

                UpdateSettingsConstructor(constructor, hasTokenCredCtor, hasKeyCredCtor);
                return constructor;
            }

            // Inline body into "with options" constructors that chained to the removed internal constructor
            if (constructor.Signature.Initializer is { IsBase: false } init &&
                init.Arguments.Count == _internalCtorParamCount)
            {
                InlineConstructorBody(constructor, init.Arguments[0], _internalCtorBody);
            }

            return constructor;
        }

        private static void UpdateSettingsConstructor(ConstructorProvider settingsCtor, bool hasTokenCredCtor, bool hasKeyCredCtor)
        {
            // The base generator produces a Settings constructor like:
            //   this(AuthenticationPolicy.Create(settings), settings?.Endpoint, ...otherParams, settings?.Options)
            //
            // For TokenCredential, we change it to chain to the TokenCredential constructor:
            //   this(settings?.Endpoint, settings?.TokenProvider as TokenCredential, ...otherParams, settings?.Options)
            //
            // For AzureKeyCredential only, we need to add a body that checks credentialSource
            // and constructs the appropriate credential, then calls the key credential constructor.
            var existingArgs = settingsCtor.Signature.Initializer!.Arguments;
            var settingsParam = settingsCtor.Signature.Parameters[0];

            if (hasTokenCredCtor)
            {
                // Build: settings?.TokenProvider as TokenCredential
                var tokenProviderAccess = new MemberExpression(new NullConditionalExpression(settingsParam), "TokenProvider");
                var tokenCredentialArg = tokenProviderAccess.As(TokenCredentialType);

                // New args: endpoint, tokenCredential, ...otherParams, options
                var newArgs = new List<ValueExpression>();
                newArgs.Add(existingArgs[1]); // endpoint
                newArgs.Add(tokenCredentialArg); // credential
                for (int i = 2; i < existingArgs.Count; i++) // other params + options
                {
                    newArgs.Add(existingArgs[i]);
                }

                settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, newArgs));
            }
            else if (hasKeyCredCtor)
            {
                // Key-credential only library.
                // Build: new AzureKeyCredential(settings?.CredentialSource) — and chain to the AzureKeyCredential constructor.
                // The settings?.TokenProvider property returns a TokenProvider which for key creds
                // should be checked via credentialSource.
                //
                // settings?.TokenProvider as AzureKeyCredential
                // Note: If the credentialSource from config is "apikeycredential" (case-insensitive),
                // we construct an AzureKeyCredential.
                var tokenProviderAccess = new MemberExpression(new NullConditionalExpression(settingsParam), "TokenProvider");
                var keyCredentialArg = tokenProviderAccess.As(AzureKeyCredentialType);

                // New args: endpoint, keyCredential, ...otherParams, options
                var newArgs = new List<ValueExpression>();
                newArgs.Add(existingArgs[1]); // endpoint
                newArgs.Add(keyCredentialArg); // credential
                for (int i = 2; i < existingArgs.Count; i++) // other params + options
                {
                    newArgs.Add(existingArgs[i]);
                }

                settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, newArgs));
            }
        }

        private static void InlineConstructorBody(
            ConstructorProvider ctor,
            ValueExpression authPolicyExpr,
            MethodBodyStatement internalBody)
        {
            // Declare a local variable named "authenticationPolicy" with the auth policy expression
            // from the old this() initializer (e.g., new AzureKeyCredentialPolicy(credential, AuthorizationHeader)).
            // The internal constructor's body references "authenticationPolicy" by name, so the local
            // variable satisfies those references in the generated C# output.
            var authPolicyDecl = Declare("authenticationPolicy", AuthenticationPolicyType, authPolicyExpr, out _);

            // Remove the this() initializer and set the inlined body
            ctor.Signature.Update(initializer: null);
            ctor.Update(bodyStatements: new MethodBodyStatement[] { authPolicyDecl, internalBody });
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
