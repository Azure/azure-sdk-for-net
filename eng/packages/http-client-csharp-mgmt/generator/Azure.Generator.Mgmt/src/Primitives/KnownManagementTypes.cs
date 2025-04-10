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
            ["Azure.ResourceManager.CommonTypes.TrackedResource"] = typeof(TrackedResourceData),
            ["Azure.ResourceManager.CommonTypes.Resource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = typeof(ExtendedLocation),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentity),
            ["Azure.ResourceManager.CommonTypes.OperationStatusResult"] = typeof(OperationStatusResult),
        };
        private static readonly HashSet<Type> _knownTypes = _idToTypeMap.Values.Select(x => x.FrameworkType).ToHashSet();

        public static bool IsKnownManagementType(Type type) => _knownTypes.Contains(type);

        public static bool TryGetManagementType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToTypeMap.TryGetValue(id, out type);
    }
}
