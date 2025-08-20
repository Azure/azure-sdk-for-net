// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
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
            var clients = types.OfType<ClientProvider>().ToList();
            return
            [
                .. types,
                new RequestContextExtensionsDefinition(),
                .. clients.Count > 0 ? [new ClientBuilderExtensionsDefinition(clients)] : Array.Empty<TypeProvider>()
            ];
        }
    }
}
