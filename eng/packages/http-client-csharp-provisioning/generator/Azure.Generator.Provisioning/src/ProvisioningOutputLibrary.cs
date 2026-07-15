// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
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
        private IReadOnlyList<ProvisioningResourceProvider>? _resources;
        private Dictionary<string, ProvisioningResourceProvider>? _resourcesByIdPattern;
        private Dictionary<InputModelType, List<ProvisioningResourceProvider>>? _resourcesByModel;
        private BuiltInRoleProvider? _builtInRole;
        private CodeGenEnumValueAttributeDefinition? _codeGenEnumValueAttributeDefinition;

        /// <summary>
        /// Gets the BuiltInRole type provider if any resources define RBAC roles.
        /// </summary>
        internal BuiltInRoleProvider? BuiltInRole
        {
            get
            {
                InitializeResources();
                return _builtInRole;
            }
        }

        internal CodeGenEnumValueAttributeDefinition CodeGenEnumValueAttributeDefinition => _codeGenEnumValueAttributeDefinition ??= new();

        /// <summary>
        /// Gets all provisioning resource providers.
        /// </summary>
        internal IReadOnlyList<ProvisioningResourceProvider> Resources
        {
            get
            {
                InitializeResources();
                return _resources!;
            }
        }

        private void InitializeResources()
        {
            if (_resources != null)
                return;

            var inputLibrary = ProvisioningGenerator.Instance.InputLibrary;
            var resources = new List<ProvisioningResourceProvider>();
            var resourcesByIdPattern = new Dictionary<string, ProvisioningResourceProvider>();
            var resourcesByModel = new Dictionary<InputModelType, List<ProvisioningResourceProvider>>();
            foreach (var projection in inputLibrary.ResourceProjections)
            {
                var resource = new ProvisioningResourceProvider(projection);
                resources.Add(resource);
                foreach (var resourceIdPattern in projection.ResourceIdPatterns)
                {
                    resourcesByIdPattern[resourceIdPattern.SerializedPath] = resource;
                }

                if (!resourcesByModel.TryGetValue(projection.ResourceModel, out var modelList))
                {
                    modelList = new List<ProvisioningResourceProvider>();
                    resourcesByModel[projection.ResourceModel] = modelList;
                }
                modelList.Add(resource);
            }

            // Initialize BuiltInRole from input metadata — this is safe to do here since
            // it's constructed purely from input values, and must be available before any
            // resource provider's methods are materialized.
            var serviceName = ProvisioningGenerator.Instance.TypeFactory.ResourceProviderName;
            _builtInRole = BuiltInRoleProvider.TryCreate(serviceName, inputLibrary.ArmProviderSchema.Resources);

            _resources = resources;
            _resourcesByIdPattern = resourcesByIdPattern;
            _resourcesByModel = resourcesByModel;
        }

        /// <summary>
        /// Tries to get the resource provider(s) for a given InputModelType.
        /// Returns false if the model is not a resource model.
        /// </summary>
        internal bool TryGetResourcesByModel(InputModelType model, out IReadOnlyList<ProvisioningResourceProvider> resources)
        {
            InitializeResources();
            if (_resourcesByModel!.TryGetValue(model, out var list))
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
        internal ProvisioningResourceProvider? GetResourceByIdPattern(RequestPathPattern resourceIdPattern)
        {
            InitializeResources();
            _resourcesByIdPattern!.TryGetValue(resourceIdPattern.SerializedPath, out var resource);
            return resource;
        }

        /// <inheritdoc/>
        protected override IReadOnlyList<ModelProvider> ResolveFlattenTargetModels(InputModelType inputModel)
        {
            if (TryGetResourcesByModel(inputModel, out var resources))
            {
                return resources;
            }

            return ProvisioningGenerator.Instance.InputLibrary.IsModelReachable(inputModel)
                ? base.ResolveFlattenTargetModels(inputModel)
                : [];
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
                ProvisioningGenerator.Instance.AddTypeToKeep(resource);
            }

            // Add BuiltInRole struct if any resources have RBAC roles defined.
            if (BuiltInRole != null)
            {
                providers.Add(BuiltInRole);
            }
            providers.Add(CodeGenEnumValueAttributeDefinition);

            // Build models and enums via TypeFactory — our overridden CreateModel/CreateEnum
            // return ProvisioningModelProvider/ProvisioningResourceProvider/EnumProvider.
            // Only emit models/enums reachable from resource models' property graphs. This
            // avoids emitting dead types like list-result envelopes, patch/request wrappers,
            // and error models that have no place in a Provisioning library.
            foreach (var inputModel in ProvisioningGenerator.Instance.InputLibrary.ReachableModels)
            {
                var model = ProvisioningGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null)
                {
                    providers.Add(model);
                    // CollectReachableTypes excludes models already backed by ArmProviderSchema.Resources,
                    // so this does not duplicate the pre-created resource providers added above.
                    // CreateModel can still return a resource provider here for discriminator-derived
                    // models whose base chain is a resource, and those providers must also be kept.
                    if (model is ProvisioningResourceProvider resource)
                    {
                        ProvisioningGenerator.Instance.AddTypeToKeep(resource);
                    }
                }
            }

            foreach (var inputEnum in ProvisioningGenerator.Instance.InputLibrary.ReachableEnums)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    // Provisioning manually builds the provider list instead of calling the base
                    // OutputLibrary.BuildTypeProviders(), so we must preserve the base pipeline's
                    // custom enum replacement behavior here. When a custom enum is decorated with
                    // [CodeGenType("GeneratedEnumName")], the generated enum provider still exists
                    // (often internalized), but C# cannot merge two enum declarations with the
                    // same name. Skipping the generated provider lets the custom enum fully replace
                    // it, matching the base/mgmt generator behavior.
                    if (enumProvider.CustomCodeView != null)
                    {
                        continue;
                    }
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
