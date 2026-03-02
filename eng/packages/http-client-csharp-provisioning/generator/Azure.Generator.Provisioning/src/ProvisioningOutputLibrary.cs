// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Provisioning.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Output library for provisioning generator that produces ProvisionableConstruct
    /// and ProvisionableResource types from the management generator's final type snapshot.
    /// </summary>
    internal class ProvisioningOutputLibrary : ManagementOutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // Let the mgmt pipeline run fully (including all visitors)
            var allMgmtProviders = base.BuildTypeProviders();

            // First pass: create provisioning model providers and collect enum types for the type map
            var provisioningProviders = new List<TypeProvider>();
            var typeMap = new Dictionary<string, CSharpType>();
            var modelProviders = new List<ProvisioningModelProvider>();

            foreach (var provider in allMgmtProviders)
            {
                if (provider is ModelProvider model)
                {
                    var provModel = new ProvisioningModelProvider(model);
                    ManagementClientGenerator.Instance.AddTypeToKeep(provModel.Name);
                    modelProviders.Add(provModel);
                    provisioningProviders.Add(provModel);
                    typeMap[model.Name] = provModel.Type;
                }
                // Enum types are excluded for now — enum properties become BicepValue<string>
                // TODO: Transform enums into provisioning-compatible enum types
            }

            // Second pass: set the type map on each model provider for cross-reference resolution
            foreach (var provModel in modelProviders)
            {
                provModel.SetTypeMap(typeMap);
            }

            // TODO: Transform enums into simple enum types (currently keeping mgmt enums as-is)
            // TODO: Transform resources into ProvisionableResource subclasses

            return provisioningProviders.ToArray();
        }
    }
}
