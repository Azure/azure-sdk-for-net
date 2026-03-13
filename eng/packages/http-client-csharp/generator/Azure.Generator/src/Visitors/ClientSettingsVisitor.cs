// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System.Linq;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that applies Azure-specific modifications to the ClientSettings and ClientOptions providers.
    /// For ClientSettings: adds Partial modifier so users can extend the generated class.
    /// For ClientOptions: modifies the IConfigurationSection constructor to use base(section, null)
    /// (Azure.Core.ClientOptions takes IConfigurationSection, DiagnosticsOptions?) instead of base(section).
    /// </summary>
    internal class ClientSettingsVisitor : ScmLibraryVisitor
    {
        private static readonly CSharpType IConfigurationSectionType = typeof(IConfigurationSection);

        protected override ClientProvider? Visit(InputClient client, ClientProvider? clientProvider)
        {
            if (clientProvider == null)
            {
                return base.Visit(client, clientProvider);
            }

            if (clientProvider.ClientSettings != null)
            {
                UpdateClientSettings(clientProvider.ClientSettings);
            }

            if (clientProvider.ClientOptions != null)
            {
                UpdateClientOptionsConstructors(clientProvider.ClientOptions);
            }

            return clientProvider;
        }

        private static void UpdateClientSettings(ClientSettingsProvider settings)
        {
            // Add Partial modifier to ClientSettings for Azure to allow user extension
            settings.Update(modifiers: TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class);
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
            }
        }
    }
}
