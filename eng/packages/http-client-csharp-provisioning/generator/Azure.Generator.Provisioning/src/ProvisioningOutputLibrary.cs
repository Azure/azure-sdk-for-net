// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Provisioning.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Output library for provisioning generator. Bypasses the mgmt output library's
    /// resource client initialization (which would crash) and instead builds providers
    /// directly from InputModelType/InputEnumType via our ProvisioningTypeFactory.
    /// </summary>
    internal class ProvisioningOutputLibrary : ManagementOutputLibrary
    {
        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // DO NOT call base.BuildTypeProviders() — it triggers ResourceClientProvider
            // initialization which calls TypeFactory.CreateModel() expecting ModelProvider,
            // but our factory returns ProvisioningModelProvider.

            // Instead, iterate input types directly and let TypeFactory create our providers.
            var providers = new List<TypeProvider>();
            var inputLib = ProvisioningGenerator.Instance.InputLibrary;

            // Create models via TypeFactory (returns ProvisioningModelProvider or ProvisioningResourceProvider)
            foreach (var inputModel in inputLib.InputNamespace.Models)
            {
                var model = ProvisioningGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null)
                {
                    providers.Add(model);
                }
                // Only add resources to the keep list — models/enums referenced by
                // resources are kept automatically by the post-processor; unreferenced
                // types get pruned.
                if (model is ProvisioningResourceProvider)
                {
                    ProvisioningGenerator.Instance.AddTypeToKeep(model.Name);
                }
                else if (model is not null && inputModel.DiscriminatorValue != null)
                {
                    // Derived discriminated types must be kept — users instantiate them directly
                    ProvisioningGenerator.Instance.AddTypeToKeep(model.Name);
                }
            }

            // Create enums via TypeFactory (returns ProvisioningEnumProvider when implemented)
            foreach (var inputEnum in inputLib.InputNamespace.Enums)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    providers.Add(enumProvider);
                }
            }

            return providers.ToArray();
        }
    }
}
