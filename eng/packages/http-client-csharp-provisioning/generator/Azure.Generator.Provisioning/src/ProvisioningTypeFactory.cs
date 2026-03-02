// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Provisioning.Providers;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// TypeFactory for provisioning generator that intercepts model/enum creation
    /// to return provisioning-style type providers (ProvisionableConstruct/ProvisionableResource)
    /// instead of management-style types.
    /// </summary>
    public class ProvisioningTypeFactory : ManagementTypeFactory
    {
        private Dictionary<InputModelType, ResourceMetadata>? _resourceModelMap;

        private Dictionary<InputModelType, ResourceMetadata> ResourceModelMap
            => _resourceModelMap ??= BuildResourceModelMap();

        private Dictionary<InputModelType, ResourceMetadata> BuildResourceModelMap()
        {
            var map = new Dictionary<InputModelType, ResourceMetadata>();
            foreach (var metadata in ManagementClientGenerator.Instance.InputLibrary.ArmProviderSchema.Resources)
            {
                if (metadata.ResourceModel != null)
                {
                    map[metadata.ResourceModel] = metadata;
                }
            }
            return map;
        }

        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            // Let the mgmt base resolve known system types first (ResourceIdentifier, AzureLocation, etc.)
            var mgmtType = base.CreateCSharpTypeCore(inputType);

            // For model types, don't wrap — models are referenced directly (not BicepValue<Model>)
            if (inputType is InputModelType)
                return mgmtType;

            // For enum types that resolved to a system type, wrap in BicepValue
            // For non-system enums without a provider yet, fallback to BicepValue<string>
            if (inputType is InputEnumType)
            {
                if (mgmtType != null)
                    return new CSharpType(typeof(BicepValue<>), mgmtType);
                // No provider for this enum yet → use string as fallback
                return new CSharpType(typeof(BicepValue<>), typeof(string));
            }

            // For array types, produce BicepList<T>
            if (inputType is InputArrayType arrayType)
            {
                var elementType = CreateCSharpType(arrayType.ValueType);
                if (elementType != null)
                    return new CSharpType(typeof(BicepList<>), elementType);
            }

            // For dictionary types, produce BicepDictionary<TValue>
            if (inputType is InputDictionaryType dictType)
            {
                var valueType = CreateCSharpType(dictType.ValueType);
                if (valueType != null)
                    return new CSharpType(typeof(BicepDictionary<>), valueType);
            }

            // For primitive types resolved by base, wrap in BicepValue<T>
            if (mgmtType != null && inputType is InputPrimitiveType)
            {
                return new CSharpType(typeof(BicepValue<>), mgmtType);
            }

            return mgmtType;
        }

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            // Known system types (ManagedServiceIdentity, SystemData, etc.) → null (use framework type)
            if (KnownManagementTypes.TryGetSystemType(model.CrossLanguageDefinitionId, out _))
                return null;

            // Inheritable system types (TrackedResource, ProxyResource, etc.) → null
            // Provisioning types use ProvisionableConstruct/ProvisionableResource as base, not ARM base types
            if (KnownManagementTypes.TryGetInheritableSystemType(model.CrossLanguageDefinitionId, out _))
                return null;

            // Resource models → ProvisioningResourceProvider (TODO: implement later)
            if (ResourceModelMap.TryGetValue(model, out var metadata))
            {
                // For now, return a ProvisioningModelProvider until ProvisioningResourceProvider is ready
                return new ProvisioningModelProvider(model);
            }

            // Regular models → ProvisioningModelProvider
            return new ProvisioningModelProvider(model);
        }

        /// <inheritdoc/>
        protected override EnumProvider? CreateEnumCore(InputEnumType enumType, TypeProvider? declaringType)
        {
            // Known system enums → null (use framework type)
            if (KnownManagementTypes.TryGetSystemType(enumType.CrossLanguageDefinitionId, out _))
                return null;

            // TODO: return new ProvisioningEnumProvider(enumType) when implemented
            // For now, return null — enum property types will resolve to BicepValue<string> via CreateCSharpTypeCore
            return null;
        }
    }
}
