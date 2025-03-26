// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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

        public static bool TryGetManagementType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToTypeMap.TryGetValue(id, out type);
    }
}
