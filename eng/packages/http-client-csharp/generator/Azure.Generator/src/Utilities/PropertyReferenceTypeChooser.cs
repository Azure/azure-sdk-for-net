// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.Generator.Utilities
{
    internal class PropertyReferenceTypeChooser
    {
        private static readonly ConcurrentDictionary<InputModelType, SystemObjectProvider?> _cache = new ConcurrentDictionary<InputModelType, SystemObjectProvider?>();
        private static readonly IReadOnlyDictionary<string, Type> _propertyTypeToReplace = new Dictionary<string, Type>
        {
            ["Azure.ResourceManager.CommonTypes.Plan"] = typeof(ArmPlan),
            ["Azure.ResourceManager.CommonTypes.Sku"] = typeof(ArmSku),
            //["Azure.ResourceManager.CommonTypes.EncryptionProperties"] = typeof(EncryptionProperties), obsoleted
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = typeof(ExtendedLocation),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            //["Azure.ResourceManager.CommonTypes.KeyVaultProperties"] = typeof(ManagedServiceIdentity), obsoleted
            //["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ResourceProviderData), not found in tsp common types
            //["Azure.ResourceManager.CommonTypes.SystemAssignedServiceIdentity"] = typeof(SystemAssignedServiceIdentity), obsoleted
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentity),
            //["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(WritableSubResource), not found in tsp common types
        };

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static SystemObjectProvider? GetExactMatch(InputModelType typeToReplace)
        {
            if (_cache.TryGetValue(typeToReplace, out var result))
                return result;

            var replacedType = BuildExactMatchType(typeToReplace);

            _cache.TryAdd(typeToReplace, replacedType);
            return replacedType;
        }

        private static SystemObjectProvider? BuildExactMatchType(InputModelType typeToReplace)
        {
            if (typeToReplace.CrossLanguageDefinitionId == "Azure.ResourceManager.CommonTypes.ExtendedLocation")
            {
                Console.WriteLine("exnteded location matched");
            }
            if (_propertyTypeToReplace.TryGetValue(typeToReplace.CrossLanguageDefinitionId, out var replaced))
            {
                return new SystemObjectProvider(replaced);
            }

            return null;
        }
    }
}
