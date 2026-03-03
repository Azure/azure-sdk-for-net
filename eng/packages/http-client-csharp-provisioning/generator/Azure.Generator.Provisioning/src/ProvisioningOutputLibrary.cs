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
                // TODO: Derived discriminated types need to be kept too (users instantiate them
                // directly), but the post-processor should detect discriminated sets and keep all
                // subtypes automatically. If not, we may need extension points in the MTG core
                // library to enable this.
                if (model is ProvisioningResourceProvider)
                {
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
