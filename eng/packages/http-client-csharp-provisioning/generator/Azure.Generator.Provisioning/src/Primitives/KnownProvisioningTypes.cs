// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Known ARM common types that the provisioning generator should skip generating
    /// (they have framework equivalents in Azure.Provisioning or Azure.ResourceManager).
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
        /// ARM common model/enum types that have framework equivalents and should not be generated.
        /// </summary>
        private static readonly HashSet<string> _systemTypes =
        [
            "Azure.ResourceManager.CommonTypes.ExtendedLocation",
            "Azure.ResourceManager.CommonTypes.ExtendedLocationType",
            "Azure.ResourceManager.CommonTypes.ManagedServiceIdentity",
            "Azure.ResourceManager.Legacy.ManagedServiceIdentityV4",
            "Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType",
            "Azure.ResourceManager.CommonTypes.OperationStatusResult",
            "Azure.ResourceManager.CommonTypes.Plan",
            "Azure.ResourceManager.CommonTypes.SystemData",
            "Azure.ResourceManager.CommonTypes.UserAssignedIdentity",
            "Azure.ResourceManager.Models.SubResource",
            "Azure.ResourceManager.Models.WritableSubResource",
            "Azure.ResourceManager.CommonTypes.ErrorDetail",
        ];

        /// <summary>
        /// Returns true if the given cross-language definition ID is a known ARM inheritable base type.
        /// </summary>
        public static bool IsInheritableSystemType(string crossLanguageDefinitionId)
            => _inheritableSystemTypes.Contains(crossLanguageDefinitionId);

        /// <summary>
        /// Returns true if the given cross-language definition ID is a known ARM system type.
        /// </summary>
        public static bool IsSystemType(string crossLanguageDefinitionId)
            => _systemTypes.Contains(crossLanguageDefinitionId);
    }
}
