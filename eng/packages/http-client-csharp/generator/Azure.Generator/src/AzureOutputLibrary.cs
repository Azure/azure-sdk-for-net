// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Providers;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
            => [
                ..base.BuildTypeProviders(),
                new RequestContextExtensionsDefinition(),
            ];
    }
}
