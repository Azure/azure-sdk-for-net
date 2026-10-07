// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var types = base.BuildTypeProviders();
            var publicClients = types.OfType<ClientProvider>().Where(
                client => client.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)).ToList();

            // Only emit ClientBuilderExtensions for libraries that already ship it (backcompat).
            // Newly generated libraries do not get this Microsoft.Extensions.Azure integration type.
            ClientBuilderExtensionsDefinition? clientBuilderExtensions = null;
            if (publicClients.Count > 0)
            {
                var candidate = new ClientBuilderExtensionsDefinition(publicClients);
                if (candidate.LastContractView is not null)
                {
                    clientBuilderExtensions = candidate;
                }
            }

            return
            [
                .. types,
                new RequestContextExtensionsDefinition(),
                AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition,
                AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition,
                .. clientBuilderExtensions is not null ? [clientBuilderExtensions] : Array.Empty<TypeProvider>(),
                .. publicClients.Where(c => c.ClientSettings != null).Select(c => new ClientHostExtensionsDefinition(c))
            ];
        }
    }
}
