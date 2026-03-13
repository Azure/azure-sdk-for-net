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

            // Detect and resolve CollectionResult naming collisions before any Name property
            // is accessed on these types (names are computed lazily).
            DisambiguateCollectionResultNames(types);

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

        // Groups all AzureCollectionResultDefinition instances by their computed base name.
        // When multiple definitions share the same base name (a naming collision), each is
        // assigned a unique numeric suffix (1, 2, 3, ...) so the generated types remain distinct.
        private static void DisambiguateCollectionResultNames(TypeProvider[] types)
        {
            var collectionResults = types.OfType<AzureCollectionResultDefinition>().ToList();
            if (collectionResults.Count == 0)
                return;

            var nameGroups = collectionResults
                .GroupBy(cr => cr.GetBaseName())
                .Where(g => g.Count() > 1);

            foreach (var group in nameGroups)
            {
                int suffix = 1;
                foreach (var cr in group)
                {
                    cr.SetDisambiguationSuffix(suffix++);
                }
            }
        }
    }
}
