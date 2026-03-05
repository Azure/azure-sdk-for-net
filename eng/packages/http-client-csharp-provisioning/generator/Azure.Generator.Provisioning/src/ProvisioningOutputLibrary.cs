// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Output library for provisioning generator. Pre-creates all resource providers
    /// from ArmProviderSchema.Resources and builds model/enum providers from input types.
    /// </summary>
    public class ProvisioningOutputLibrary : ManagementOutputLibrary
    {
        private Dictionary<string, ProvisioningResourceProvider>? _resourcesByIdPattern;
        private Dictionary<InputModelType, List<ProvisioningResourceProvider>>? _resourcesByModel;

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResources(ref _resourcesByIdPattern, ref _resourcesByModel);
            return field!;
        }

        private static void InitializeResources(
            ref Dictionary<string, ProvisioningResourceProvider>? resourcesByIdPattern,
            ref Dictionary<InputModelType, List<ProvisioningResourceProvider>>? resourcesByModel)
        {
            if (resourcesByIdPattern != null)
                return;

            var byIdPattern = new Dictionary<string, ProvisioningResourceProvider>();
            var byModel = new Dictionary<InputModelType, List<ProvisioningResourceProvider>>();

            foreach (var metadata in ProvisioningGenerator.Instance.InputLibrary.ArmProviderSchema.Resources)
            {
                if (metadata.ResourceModel == null)
                    continue;

                var resource = new ProvisioningResourceProvider(metadata.ResourceModel, metadata);
                byIdPattern[metadata.ResourceIdPattern] = resource;

                if (!byModel.TryGetValue(metadata.ResourceModel, out var list))
                {
                    list = new List<ProvisioningResourceProvider>();
                    byModel[metadata.ResourceModel] = list;
                }
                list.Add(resource);
            }

            resourcesByIdPattern = byIdPattern;
            resourcesByModel = byModel;
        }

        /// <summary>
        /// Tries to get the resource provider(s) for a given InputModelType.
        /// Returns false if the model is not a resource model.
        /// </summary>
        internal bool TryGetResourcesByModel(InputModelType model, out IReadOnlyList<ProvisioningResourceProvider> resources)
        {
            if (GetValue(ref _resourcesByModel).TryGetValue(model, out var list))
            {
                resources = list;
                return true;
            }
            resources = [];
            return false;
        }

        /// <summary>
        /// Gets a resource provider by its ARM resource ID pattern.
        /// Returns null if not found.
        /// </summary>
        internal ProvisioningResourceProvider? GetResourceByIdPattern(string resourceIdPattern)
        {
            GetValue(ref _resourcesByIdPattern).TryGetValue(resourceIdPattern, out var resource);
            return resource;
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // DO NOT call base.BuildTypeProviders() — it triggers ResourceClientProvider
            // initialization which calls TypeFactory.CreateModel() expecting ModelProvider,
            // but our factory returns ProvisioningModelProvider.

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
                // TODO: The FlattenPropertyVisitor in the mgmt generator flattens discriminator base
                // types that have few properties, marking them as internal. This needs to be fixed
                // so discriminator base types remain public regardless of property count.
                // Tracked by https://github.com/Azure/azure-sdk-for-net/issues/56708
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

            return [.. providers];
        }
    }
}
