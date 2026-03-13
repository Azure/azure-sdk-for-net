// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that applies Azure-specific modifications to the ClientOptions provider.
    /// Modifies the IConfigurationSection constructor to use base(section, null)
    /// (Azure.Core.ClientOptions takes IConfigurationSection, DiagnosticsOptions?) instead of base(section).
    /// Adds a partial void ConfigureLogging() method and calls it from all constructors.
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private const string ConfigureLoggingMethodName = "ConfigureLogging";
        private static readonly CSharpType IConfigurationSectionType = typeof(IConfigurationSection);

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

            return clientProvider;
        }

        private static void UpdateClientOptions(ClientOptionsProvider options)
        {
            UpdateClientOptionsConstructors(options);
            AddConfigureLoggingMethod(options);
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

                // Add ConfigureLogging() call to all constructors
                var configureLoggingCall = This.Invoke(ConfigureLoggingMethodName).Terminate();
                List<MethodBodyStatement> updatedBody = ctor.BodyStatements != null
                    ? [ctor.BodyStatements, configureLoggingCall]
                    : [configureLoggingCall];
                ctor.Update(bodyStatements: updatedBody);
            }
        }

        private static void AddConfigureLoggingMethod(ClientOptionsProvider options)
        {
            // Add: partial void ConfigureLogging();
            // This is a partial method that services can implement to configure logging.
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
