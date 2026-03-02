// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Provisioning.Providers;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
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

            // For model types: if resolved to a system type that's a ProvisionableConstruct, return as-is.
            // Otherwise, for non-ProvisionableConstruct system types (ResponseError, SystemData from mgmt),
            // wrap in BicepValue<T> since they can't be used with DefineModelProperty.
            if (inputType is InputModelType)
            {
                if (mgmtType != null && mgmtType.IsFrameworkType
                    && !typeof(ProvisionableConstruct).IsAssignableFrom(mgmtType.FrameworkType))
                {
                    return new CSharpType(typeof(BicepValue<>), mgmtType);
                }
                return mgmtType;
            }

            // For enum types, wrap in BicepValue<T>
            // System enums: mgmtType is the system CSharpType
            // Non-system enums: mgmtType is our ProvisioningEnumProvider.Type
            if (inputType is InputEnumType)
            {
                if (mgmtType != null)
                    return new CSharpType(typeof(BicepValue<>), mgmtType);
                // Fallback: shouldn't happen now that ProvisioningEnumProvider is wired up
                return new CSharpType(typeof(BicepValue<>), typeof(string));
            }

            // For array types, produce BicepList<T> — element type should NOT be BicepValue-wrapped
            if (inputType is InputArrayType arrayType)
            {
                var elementType = GetUnwrappedCSharpType(arrayType.ValueType);
                if (elementType != null)
                    return new CSharpType(typeof(BicepList<>), elementType);
            }

            // For dictionary types, produce BicepDictionary<TValue> — value type should NOT be BicepValue-wrapped
            if (inputType is InputDictionaryType dictType)
            {
                var valueType = GetUnwrappedCSharpType(dictType.ValueType);
                if (valueType != null)
                    return new CSharpType(typeof(BicepDictionary<>), valueType);
            }

            // For all other non-model, non-enum types resolved by base (primitives, date/time, duration, etc.),
            // wrap in BicepValue<T>
            if (mgmtType != null)
            {
                return new CSharpType(typeof(BicepValue<>), mgmtType);
            }

            return mgmtType;
        }

        /// <summary>
        /// Resolves an InputType to its raw CSharpType without BicepValue wrapping.
        /// Used for BicepList/BicepDictionary element types which handle wrapping internally.
        /// </summary>
        private CSharpType? GetUnwrappedCSharpType(InputType inputType)
        {
            // For model types, return the provider type directly
            if (inputType is InputModelType)
                return base.CreateCSharpTypeCore(inputType) ?? CreateCSharpType(inputType);

            // For enum types, return the system type or string
            if (inputType is InputEnumType)
                return base.CreateCSharpTypeCore(inputType) ?? typeof(string);

            // For all other types, use the base resolution (returns raw .NET type)
            return base.CreateCSharpTypeCore(inputType);
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

            // Resource models → ProvisioningResourceProvider
            if (ResourceModelMap.TryGetValue(model, out var metadata))
            {
                return new ProvisioningResourceProvider(model, metadata);
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

            // Regular enums → ProvisioningEnumProvider
            return new ProvisioningEnumProvider(enumType);
        }
    }
}
