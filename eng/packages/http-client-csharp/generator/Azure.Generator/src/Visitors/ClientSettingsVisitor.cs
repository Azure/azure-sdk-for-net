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
    /// Adds partial void ConfigureLoggedHeaderDefaults() and ConfigureLoggedQueryParameterDefaults() methods
    /// and calls them from all constructors.
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private const string ConfigureLoggedHeaderDefaultsMethodName = "ConfigureLoggedHeaderDefaults";
        private const string ConfigureLoggedQueryParameterDefaultsMethodName = "ConfigureLoggedQueryParameterDefaults";
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

                // Call both logging configuration methods from all constructors
                var headerDefaultsCall = This.Invoke(ConfigureLoggedHeaderDefaultsMethodName).Terminate();
                var queryParamDefaultsCall = This.Invoke(ConfigureLoggedQueryParameterDefaultsMethodName).Terminate();
                List<MethodBodyStatement> updatedBody = ctor.BodyStatements != null
                    ? [ctor.BodyStatements, headerDefaultsCall, queryParamDefaultsCall]
                    : [headerDefaultsCall, queryParamDefaultsCall];
                ctor.Update(bodyStatements: updatedBody);
            }
        }

        private static void AddLoggingConfigurationMethods(ClientOptionsProvider options)
        {
            // Add: partial void ConfigureLoggedHeaderDefaults();
            // Services can implement this to add service-specific logged headers.
            // If not implemented, the call is removed at compile time.
            var headerDefaultsSignature = new MethodSignature(
                ConfigureLoggedHeaderDefaultsMethodName,
                (FormattableString)$"Configures the default logged header names for the client options.",
                MethodSignatureModifiers.Partial,
                null,
                null,
                []);

            // Add: partial void ConfigureLoggedQueryParameterDefaults();
            // Services can implement this to add service-specific logged query parameters.
            // If not implemented, the call is removed at compile time.
            var queryParamDefaultsSignature = new MethodSignature(
                ConfigureLoggedQueryParameterDefaultsMethodName,
                (FormattableString)$"Configures the default logged query parameters for the client options.",
                MethodSignatureModifiers.Partial,
                null,
                null,
                []);

            var headerDefaultsMethod = new MethodProvider(headerDefaultsSignature, options);
            var queryParamDefaultsMethod = new MethodProvider(queryParamDefaultsSignature, options);

            options.Update(methods: [.. options.Methods, headerDefaultsMethod, queryParamDefaultsMethod]);
        }
    }
}
