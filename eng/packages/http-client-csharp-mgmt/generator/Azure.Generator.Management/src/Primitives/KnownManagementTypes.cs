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
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType"] = typeof(ManagedServiceIdentityType),
            ["Azure.ResourceManager.CommonTypes.OperationStatusResult"] = typeof(OperationStatusResult),
            ["Azure.ResourceManager.CommonTypes.ProxyResource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.Resource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.TrackedResource"] = typeof(TrackedResourceData),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentity),
        };

        private static readonly HashSet<CSharpType> _knownTypes = _idToTypeMap.Values.ToHashSet(new CSharpFullNameComparer());

        public static bool IsKnownManagementType(CSharpType type) => _knownTypes.Contains(type);

        public static bool TryGetManagementType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToTypeMap.TryGetValue(id, out type);

        // The comparison could be CSharpType from Azure.ResourceManager, which is a framework type
        // and CSharpType from InheritableSystemObjectModelProvider, which is not a framework type, they should still be equal if namespace and name match
        // Then, the default Equals of CSharpType doesn't apply here
        private class CSharpFullNameComparer : IEqualityComparer<CSharpType>
        {
            public bool Equals(CSharpType? x, CSharpType? y)
            {
                if (x is null)
                {
                    if (y is null)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return x.AreNamesEqual(y);
                }
            }

            public int GetHashCode([DisallowNull] CSharpType obj)
            {
                return HashCode.Combine(obj.Namespace, obj.Name);
            }
        }
    }
}
