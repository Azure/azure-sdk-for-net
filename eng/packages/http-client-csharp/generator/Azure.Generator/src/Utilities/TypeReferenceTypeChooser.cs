// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Generator.Utilities
{
    internal static class TypeReferenceTypeChooser
    {
        private static ConcurrentDictionary<ModelProvider, CSharpType?> _valueCache = new ConcurrentDictionary<ModelProvider, CSharpType?>();

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static CSharpType? GetExactMatch(ModelProvider typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace, out var result))
                return result;

            var replacedType = BuildExactMatchType(typeToReplace);

            _valueCache.TryAdd(typeToReplace, replacedType);
            return replacedType;
        }

        private static CSharpType? BuildExactMatchType(ModelProvider typeToReplace)
        {
            foreach (Type replacementType in AzureClientPlugin.Instance.ReferenceClassFinder.TypeReferenceTypes.Value)
            {
                if (PropertyMatchDetection.IsEqual(replacementType, typeToReplace))
                {
                    var csharpType = CSharpType.FromSystemType(MgmtContext.Context, replacementType, typeToReplace.MyProperties);
                    _valueCache.TryAdd(typeToReplace, csharpType);
                    return csharpType;
                }
            }

            // nothing matches, return null
            return null;
        }

        /// <summary>
        /// Check whether there is a match for the given schema.
        /// </summary>
        /// <param name="schema"><c>ObjectSchema</c> of the target type</param>
        /// <returns></returns>
        public static bool HasMatch(InputModelType schema)
        {
            return _valueCache.TryGetValue(schema, out var match) && match != null;
        }
    }
}
