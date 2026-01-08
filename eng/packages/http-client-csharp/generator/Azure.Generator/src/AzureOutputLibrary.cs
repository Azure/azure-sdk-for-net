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
            return
            [
                .. types,
                new RequestContextExtensionsDefinition(),
                AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition,
                AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition,
                .. publicClients.Count > 0 ? [new ClientBuilderExtensionsDefinition(publicClients)] : Array.Empty<TypeProvider>()
            ];
        }
    }
}
