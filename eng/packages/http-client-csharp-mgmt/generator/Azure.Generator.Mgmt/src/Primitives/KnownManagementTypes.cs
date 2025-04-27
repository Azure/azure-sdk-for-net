// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Mgmt.Primitives
{
    internal class KnownManagementTypes
    {
        private static readonly IReadOnlyDictionary<string, CSharpType> _idToTypeMap = new Dictionary<string, CSharpType>()
        {
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = typeof(ExtendedLocation),
            ["Azure.ResourceManager.CommonTypes.ExtendedLocationType"] = typeof(ExtendedLocationType),
            ["Azure.ResourceManager.CommonTypes.ProxyResource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.Resource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.TrackedResource"] = typeof(TrackedResourceData),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType"] = typeof(ManagedServiceIdentityType),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentity),
            ["Azure.ResourceManager.CommonTypes.OperationStatusResult"] = typeof(OperationStatusResult),
        };

        private static readonly HashSet<string> _azureTypeNamespaceWithName = new()
        {
            "Azure.ResourceManager.Models.ManagedServiceIdentity",
            "Azure.ResourceManager.Models.ManagedServiceIdentityType",
            "Azure.ResourceManager.Models.OperationStatusResult",
            "Azure.ResourceManager.Models.ProxyResource",
            "Azure.ResourceManager.Models.ResourceData",
            "Azure.ResourceManager.Models.SystemData",
            "Azure.ResourceManager.Models.TrackedResourceData",
            "Azure.ResourceManager.Models.UserAssignedIdentity",
            "Azure.ResourceManager.Resources.Models.ExtendedLocation",
            "Azure.ResourceManager.Resources.Models.ExtendedLocationType",
        };

        private static readonly HashSet<Type> _knownTypes = _idToTypeMap.Values.Select(x => x.FrameworkType).ToHashSet();

        public static bool IsKnownManagementType(Type type) => _knownTypes.Contains(type);
        public static bool IsKnownManagementType(string typeNameSpaceWithName) => _azureTypeNamespaceWithName.Contains(typeNameSpaceWithName);

        public static bool TryGetManagementType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToTypeMap.TryGetValue(id, out type);
    }
}
