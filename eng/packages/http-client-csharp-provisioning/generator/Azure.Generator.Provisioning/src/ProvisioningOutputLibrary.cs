// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Generator.Management;
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
        private IReadOnlyList<ProvisioningResourceProvider>? _resources;
        private Dictionary<string, ProvisioningResourceProvider>? _resourcesByIdPattern;
        private Dictionary<InputModelType, List<ProvisioningResourceProvider>>? _resourcesByModel;
        private BuiltInRoleProvider? _builtInRole;

        /// <summary>
        /// Gets the BuiltInRole type provider if any resources define RBAC roles.
        /// </summary>
        internal BuiltInRoleProvider? BuiltInRole => GetNullableValue(ref _builtInRole);

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResources(ref _resources, ref _resourcesByIdPattern, ref _resourcesByModel, ref _builtInRole);
            return field!;
        }

        private T? GetNullableValue<T>(ref T? field) where T : class
        {
            InitializeResources(ref _resources, ref _resourcesByIdPattern, ref _resourcesByModel, ref _builtInRole);
            return field;
        }

        /// <summary>
        /// Gets all provisioning resource providers.
        /// </summary>
        internal IReadOnlyList<ProvisioningResourceProvider> Resources => GetValue(ref _resources);

        private void InitializeResources(
            ref IReadOnlyList<ProvisioningResourceProvider>? resources,
            ref Dictionary<string, ProvisioningResourceProvider>? resourcesByIdPattern,
            ref Dictionary<InputModelType, List<ProvisioningResourceProvider>>? resourcesByModel,
            ref BuiltInRoleProvider? builtInRole)
        {
            if (resources != null)
                return;

            var list = new List<ProvisioningResourceProvider>();
            var byIdPattern = new Dictionary<string, ProvisioningResourceProvider>();
            var byModel = new Dictionary<InputModelType, List<ProvisioningResourceProvider>>();

            var allMetadata = ProvisioningGenerator.Instance.InputLibrary.ArmProviderSchema.Resources;
            foreach (var metadata in allMetadata)
            {
                if (metadata.ResourceModel == null)
                    continue;

                var resource = new ProvisioningResourceProvider(metadata.ResourceModel, metadata);
                list.Add(resource);
                byIdPattern[metadata.ResourceIdPattern] = resource;

                if (!byModel.TryGetValue(metadata.ResourceModel, out var modelList))
                {
                    modelList = new List<ProvisioningResourceProvider>();
                    byModel[metadata.ResourceModel] = modelList;
                }
                modelList.Add(resource);
            }

            // Initialize BuiltInRole from input metadata — this is safe to do here since
            // it's constructed purely from input values, and must be available before any
            // resource provider's methods are materialized.
            var serviceName = ProvisioningGenerator.Instance.TypeFactory.ResourceProviderName;
            builtInRole = BuiltInRoleProvider.TryCreate(serviceName, allMetadata);

            resources = list;
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
            // TODO: Ideally we should call base.BuildTypeProviders() and filter the results
            // to keep only models, enums, and CodeGen attributes. However, ManagementOutputLibrary
            // eagerly initializes mgmt-specific client types (ResourceClientProvider,
            // ResourceCollectionClientProvider, etc.) whose BuildMethods() crashes because
            // our provisioning models don't have paging properties like 'nextLink'.
            // Until ManagementOutputLibrary is refactored to support lazy initialization or
            // allows skipping client type construction, we build the provider list manually.

            var providers = new List<TypeProvider>();

            // Add resource providers and mark them to survive post-processing.
            foreach (var resource in Resources)
            {
                providers.Add(resource);
                ProvisioningGenerator.Instance.AddTypeToKeep(resource.Name);
            }

            // Add BuiltInRole struct if any resources have RBAC roles defined.
            if (BuiltInRole != null)
            {
                providers.Add(BuiltInRole);
            }

            // Build models and enums via TypeFactory — our overridden CreateModel/CreateEnum
            // return ProvisioningModelProvider/ProvisioningResourceProvider/EnumProvider.
            var inputLib = ProvisioningGenerator.Instance.InputLibrary;
            foreach (var inputModel in inputLib.InputNamespace.Models)
            {
                var model = ProvisioningGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null && model is not ProvisioningResourceProvider)
                {
                    providers.Add(model);
                }
            }

            foreach (var inputEnum in inputLib.InputNamespace.Enums)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    providers.Add(enumProvider);
                }
            }

            // TODO: CodeGen* attribute definitions (CodeGenType, CodeGenMember, etc.) are
            // included in base OutputLibrary.BuildTypeProviders() via the internal property
            // CodeModelGenerator.CustomCodeAttributeProviders. Since we can't call base and
            // the property is inaccessible, we discover them by convention using reflection.
            // This should be replaced by a base.BuildTypeProviders() call once the above
            // ManagementOutputLibrary issue is resolved.
            foreach (var type in typeof(TypeProvider).Assembly.GetTypes())
            {
                if (typeof(TypeProvider).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && type.Name.EndsWith("AttributeDefinition"))
                {
                    if (Activator.CreateInstance(type) is TypeProvider attrProvider)
                    {
                        providers.Add(attrProvider);
                    }
                }
            }

            return [.. providers];
        }
    }
}
