// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Providers;
using Azure.Generator.Provisioning.Utilities;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
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
        /// <summary>
        /// Builds the resource provider name from the provisioning namespace.
        /// For instance, "Azure.Provisioning.KeyVault" returns "KeyVault".
        /// </summary>
        protected override string BuildResourceProviderName()
        {
            const string provisioningNamespacePrefix = "Azure.Provisioning.";
            if (PrimaryNamespace.StartsWith(provisioningNamespacePrefix))
            {
                return PrimaryNamespace[provisioningNamespacePrefix.Length..].ToIdentifierName();
            }
            return base.BuildResourceProviderName();
        }

        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            // For model types, check if there's a provisioning-specific type mapping first
            if (inputType is InputModelType inputModel
                && KnownProvisioningTypes.TryGetProvisioningType(inputModel.CrossLanguageDefinitionId, out var provisioningType))
            {
                return provisioningType;
            }

            // For enum types, check provisioning mapping too (e.g., ManagedServiceIdentityType)
            if (inputType is InputEnumType inputEnum
                && KnownProvisioningTypes.TryGetProvisioningType(inputEnum.CrossLanguageDefinitionId, out var provisioningEnumType))
            {
                return new CSharpType(typeof(BicepValue<>), provisioningEnumType);
            }

            // Let the mgmt base resolve known system types (ResourceIdentifier, AzureLocation, etc.)
            var mgmtType = base.CreateCSharpTypeCore(inputType);

            if (mgmtType != null && BicepTypeHelpers.IsProvisioningType(mgmtType))
            {
                return mgmtType;
            }

            if (mgmtType != null && mgmtType.IsList)
            {
                return new CSharpType(typeof(BicepList<>), UnwrapBicepValue(mgmtType.Arguments[0]));
            }

            if (mgmtType != null && mgmtType.IsDictionary)
            {
                return new CSharpType(typeof(BicepDictionary<>), UnwrapBicepValue(mgmtType.Arguments[1]));
            }

            if (mgmtType != null)
            {
                return new CSharpType(typeof(BicepValue<>), mgmtType);
            }

            return mgmtType;
        }

        private static CSharpType UnwrapBicepValue(CSharpType type)
            => BicepTypeHelpers.IsBicepValueType(type) ? type.Arguments[0] : type;

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            // Known provisioning types (ManagedServiceIdentity, SystemData, etc.) → null (use framework type)
            if (KnownProvisioningTypes.IsKnownType(model.CrossLanguageDefinitionId))
                return null;

            // Inheritable system types (TrackedResource, ProxyResource, etc.) → null
            // Provisioning types use ProvisionableConstruct/ProvisionableResource as base, not ARM base types
            if (KnownProvisioningTypes.IsInheritableSystemType(model.CrossLanguageDefinitionId))
                return null;

            // "Unknown" discriminator variants are for deserialization fallback in client SDKs.
            // Provisioning types are write-only (compiled to Bicep), so we skip them.
            if (model.IsUnknownDiscriminatorModel)
                return null;

            // Resource models → look up from output library's pre-created resource providers
            var outputLib = ProvisioningGenerator.Instance.OutputLibrary;
            if (outputLib.TryGetResourcesByModel(model, out var resources))
            {
                // When the same input model backs multiple resources (e.g. a parent
                // resource and a virtual child "revisions" view that reuses the parent's
                // payload), CreateModel must return a single representative provider.
                // From the model side any of them works — they all serialize the same
                // input model — but the mgmt FlattenPropertyVisitor builds
                // OutputFlattenPropertyMap by calling CreateModel on the input model and
                // mutates the returned provider's properties to add the flattened
                // forwarding accessors. Prefer the canonical provider whose ResourceName
                // matches the input model's own name so that flattening lands on the
                // parent resource (the writable surface customers consume) and not on a
                // child view. If none matches, fall back to the candidate with the
                // alphabetically-smallest ResourceName for deterministic selection.
                ProvisioningResourceProvider? canonical = null;
                foreach (var candidate in resources)
                {
                    if (string.Equals(candidate.ResourceProjection?.ResourceName, model.Name, StringComparison.Ordinal))
                    {
                        return candidate;
                    }
                    if (canonical == null
                        || string.CompareOrdinal(candidate.ResourceProjection?.ResourceName, canonical.ResourceProjection?.ResourceName) < 0)
                    {
                        canonical = candidate;
                    }
                }
                return canonical!;
            }

            // Derived discriminated resource types → ProvisioningResourceProvider (derived path)
            if (model.DiscriminatorValue != null && IsBaseChainResource(model))
            {
                return new ProvisioningResourceProvider(model);
            }

            // Regular models (including discriminated models) → ProvisioningModelProvider
            return new ProvisioningModelProvider(model);
        }

        /// <summary>
        /// Checks whether any model in the base chain is a resource model.
        /// </summary>
        private bool IsBaseChainResource(InputModelType model)
        {
            var outputLib = ProvisioningGenerator.Instance.OutputLibrary;
            var baseModel = model.BaseModel;
            while (baseModel != null)
            {
                if (outputLib.TryGetResourcesByModel(baseModel, out _))
                    return true;
                baseModel = baseModel.BaseModel;
            }
            return false;
        }

        /// <inheritdoc/>
        protected override EnumProvider? CreateEnumCore(InputEnumType enumType, TypeProvider? declaringType)
        {
            // Known provisioning enums → null (use framework type)
            if (KnownProvisioningTypes.IsKnownType(enumType.CrossLanguageDefinitionId))
                return null;

            // Regular enums → ProvisioningEnumProvider
            return new ProvisioningEnumProvider(enumType);
        }

        /// <inheritdoc/>
        protected override PropertyProvider? CreatePropertyCore(InputProperty inputProperty, TypeProvider enclosingType)
        {
            // Run base chain which creates property and applies visitor renames (e.g., etag → ETag).
            var baseProperty = base.CreatePropertyCore(inputProperty, enclosingType);

            if (inputProperty is not InputModelProperty inputModelProperty)
                return baseProperty;

            if (enclosingType is IProvisioningPropertyInfo infoProvider)
            {
                var info = infoProvider.GetProvisioningPropertyInfo(inputModelProperty);
                if (info == null) return null;
                var resolvedName = baseProperty?.Name ?? info.PropertyName;
                var bicepType = info.TypeOverride ?? CreateCSharpType(inputModelProperty.Type);
                if (bicepType == null) return null;

                return ProvisioningPropertyProvider.Create(
                    resolvedName, bicepType,
                    info.IsOutput, info.IsSettable, info.IsRequired, info.BicepPath, info.DefaultValue,
                    enclosingType);
            }

            return baseProperty;
        }
    }
}
