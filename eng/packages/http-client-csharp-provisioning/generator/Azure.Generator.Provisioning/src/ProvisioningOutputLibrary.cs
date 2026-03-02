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
            var inputLib = ManagementClientGenerator.Instance.InputLibrary;

            // Create models via TypeFactory (returns ProvisioningModelProvider for each)
            foreach (var inputModel in inputLib.InputNamespace.Models)
            {
                var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is ProvisioningModelProvider)
                {
                    ManagementClientGenerator.Instance.AddTypeToKeep(model.Name);
                    providers.Add(model);
                }
            }

            // Create enums via TypeFactory (returns ProvisioningEnumProvider when implemented)
            foreach (var inputEnum in inputLib.InputNamespace.Enums)
            {
                var enumProvider = ManagementClientGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    ManagementClientGenerator.Instance.AddTypeToKeep(enumProvider.Name);
                    providers.Add(enumProvider);
                }
            }

            return providers.ToArray();
        }
    }
}
