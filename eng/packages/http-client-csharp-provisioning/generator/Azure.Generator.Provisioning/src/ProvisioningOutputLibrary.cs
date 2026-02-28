// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator;
using Azure.Generator.Management;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Output library for provisioning generator that only emits model types.
    /// Client types (resources, collections, extensions, rest clients, etc.) are excluded
    /// because provisioning libraries generate ProvisionableResource subclasses separately.
    /// </summary>
    internal class ProvisioningOutputLibrary : ManagementOutputLibrary
    {
        // Assemblies whose custom type providers (resources, clients, extensions, etc.)
        // should be excluded — only framework infrastructure types are kept.
        private static readonly Assembly MgmtAssembly = typeof(ManagementOutputLibrary).Assembly;
        private static readonly Assembly AzureGeneratorAssembly = typeof(AzureOutputLibrary).Assembly;

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var allProviders = base.BuildTypeProviders();

            var filtered = allProviders.Where(t =>
            {
                // Always keep models and enums
                if (t is ModelProvider or EnumProvider)
                    return true;

                // Exclude client types (REST clients, API clients)
                if (t is ClientProvider)
                    return false;

                // Exclude mgmt-specific types (resources, collections, extensions,
                // mockables, LROs, operation sources, etc.)
                // and Azure generator client helper types (request context extensions, etc.)
                var assembly = t.GetType().Assembly;
                if (assembly == MgmtAssembly || assembly == AzureGeneratorAssembly)
                    return false;

                // Exclude client-related framework infrastructure types
                if (t.Name.EndsWith("ClientOptions") ||
                    t.Name == "ClientPipelineExtensions" ||
                    t.Name == "ClientUriBuilder" ||
                    t.Name == "PipelineRequestHeadersExtensions" ||
                    t.Name == "CancellationTokenExtensions")
                    return false;

                // Keep framework infrastructure types (Argument, Optional,
                // ModelSerializationExtensions, ModelReaderWriterContext, etc.)
                return true;
            }).ToArray();

            // Mark all kept types as "to keep" so they aren't removed by
            // the unreferenced-types-handling logic (models appear unused
            // because we removed all client types that reference them).
            foreach (var provider in filtered)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(provider.Name);
            }

            return filtered;
        }
    }
}
