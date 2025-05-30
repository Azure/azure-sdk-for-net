// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var typeProviders = base.BuildTypeProviders();
            return
            [
                .. typeProviders,
                new RequestContextExtensionsDefinition(),
                new ClientBuilderExtensionsDefinition(typeProviders.OfType<ClientProvider>())
            ];
        }
    }
}
