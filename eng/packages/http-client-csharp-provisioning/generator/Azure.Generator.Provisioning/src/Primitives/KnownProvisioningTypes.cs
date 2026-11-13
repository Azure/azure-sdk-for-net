// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Known ARM common types that the provisioning generator should skip generating
    /// (they have framework equivalents in Azure.Provisioning).
    /// </summary>
    internal static class KnownProvisioningTypes
    {
        /// <summary>
        /// ARM inheritable base types (TrackedResource, ProxyResource, etc.).
        /// Provisioning types use ProvisionableConstruct/ProvisionableResource as base instead.
        /// </summary>
        private static readonly HashSet<string> _inheritableSystemTypes =
        [
            "Azure.ResourceManager.CommonTypes.ProxyResource",
            "Azure.ResourceManager.CommonTypes.ExtensionResource",
            "Azure.ResourceManager.CommonTypes.Resource",
            "Azure.ResourceManager.CommonTypes.TrackedResource",
        ];

        /// <summary>
        /// Maps known ARM common type cross-language definition IDs to their Azure.Provisioning equivalents.
        /// Types in this map should not be generated — the provisioning framework types are used instead.
        /// </summary>
        private static readonly IReadOnlyDictionary<string, CSharpType> _provisioningTypeMap = new Dictionary<string, CSharpType>()
        {
            // Models
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.Legacy.ManagedServiceIdentityV4"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentityDetails),
            ["Azure.ResourceManager.CommonTypes.Plan"] = typeof(ArmPlan),
            ["Azure.ResourceManager.Models.SubResource"] = typeof(SubResource),
            ["Azure.ResourceManager.Models.WritableSubResource"] = typeof(WritableSubResource),
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = typeof(ExtendedAzureLocation),
            // Enums
            ["Azure.ResourceManager.CommonTypes.ExtendedLocationType"] = typeof(ExtendedLocationType),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType"] = typeof(ManagedServiceIdentityType),
            ["Azure.ResourceManager.CommonTypes.createdByType"] = typeof(CreatedByType),
        };

        /// <summary>
        /// Returns true if the given cross-language definition ID is a known ARM inheritable base type.
        /// </summary>
        public static bool IsInheritableSystemType(string crossLanguageDefinitionId)
            => _inheritableSystemTypes.Contains(crossLanguageDefinitionId);

        /// <summary>
        /// Returns true if the given cross-language definition ID is a known ARM type
        /// that has a provisioning framework equivalent and should not be generated.
        /// </summary>
        public static bool IsKnownType(string crossLanguageDefinitionId)
            => _provisioningTypeMap.ContainsKey(crossLanguageDefinitionId);

        /// <summary>
        /// Tries to get the Azure.Provisioning equivalent type for a known ARM common type.
        /// </summary>
        public static bool TryGetProvisioningType(string crossLanguageDefinitionId, [MaybeNullWhen(false)] out CSharpType type)
            => _provisioningTypeMap.TryGetValue(crossLanguageDefinitionId, out type);
    }
}
