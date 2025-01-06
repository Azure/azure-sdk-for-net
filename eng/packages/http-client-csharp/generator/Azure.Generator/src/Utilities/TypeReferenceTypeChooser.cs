// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.Generator.Utilities
{
    internal static class TypeReferenceTypeChooser
    {
        private static ConcurrentDictionary<InputModelType, SystemObjectProvider?> _valueCache = new ConcurrentDictionary<InputModelType, SystemObjectProvider?>();
        private static readonly IReadOnlyDictionary<string, Type> _typeToReplace = new Dictionary<string, Type>
        {
            ["Azure.ResourceManager.CommonTypes.OperationStatusResult"] = typeof(OperationStatusResult),
            ["Azure.ResourceManager.CommonTypes.Resource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.TrackedResource"] = typeof(TrackedResourceData),
        };

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static SystemObjectProvider? GetExactMatch(InputModelType typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace, out var result))
                return result;

            var replacedType = BuildExactMatchType(typeToReplace);

            _valueCache.TryAdd(typeToReplace, replacedType);
            return replacedType;
        }

        private static SystemObjectProvider? BuildExactMatchType(InputModelType typeToReplace)
        {
            if (_typeToReplace.TryGetValue(typeToReplace.CrossLanguageDefinitionId, out var replaced))
            {
                return new SystemObjectProvider(replaced);
            }

            return null;
        }
    }
}
