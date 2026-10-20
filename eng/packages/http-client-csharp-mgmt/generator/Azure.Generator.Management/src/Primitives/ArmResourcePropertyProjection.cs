// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Management.Primitives
{
    /// <summary>
    /// Shares exceptional ARM property names and the allowlisted CLR shapes used to compare
    /// recognized historical framework-base contracts. Ordinary property creation is not converted.
    /// </summary>
    internal static class ArmResourcePropertyProjection
    {
        private static readonly IReadOnlyDictionary<string, string> _propertyNames =
            new Dictionary<string, string>
            {
                ["type"] = nameof(ResourceData.ResourceType),
            };

        public static bool TryGetName(
            InputModelProperty property,
            CSharpType currentType,
            [NotNullWhen(true)] out string? name)
        {
            name = null;
            return currentType.WithNullable(false).Equals(new CSharpType(typeof(ResourceType))) &&
                TryGetAliasedName(property, out name);
        }

        /// <summary>
        /// Projects only ARM envelope scalars when restoring a recognized historical framework base.
        /// MTG materializes the historical CLR shape with the current input's wire metadata after matching.
        /// </summary>
        public static bool TryGetHistoricalShape(
            InputModelProperty property,
            CSharpType currentType,
            [NotNullWhen(true)] out string? name,
            [NotNullWhen(true)] out CSharpType? type)
        {
            var wireName = property.SerializedName ?? property.Name;
            (name, type) = wireName switch
            {
                "id" => (nameof(ResourceData.Id), new CSharpType(typeof(ResourceIdentifier))),
                "type" => (nameof(ResourceData.ResourceType), new CSharpType(typeof(ResourceType))),
                "location" => (nameof(TrackedResourceData.Location), new CSharpType(typeof(AzureLocation))),
                _ => (null, null)
            };
            if (name is null || type is null)
            {
                return false;
            }

            var isSemanticType = currentType.WithNullable(false).Equals(type);
            if (!isSemanticType && !currentType.WithNullable(false).Equals(new CSharpType(typeof(string))))
            {
                name = null;
                type = null;
                return false;
            }

            // Only optional nullable semantic Location has an intentional default-value normalization.
            // Required nulls cannot be read into AzureLocation, and nullable ResourceType/string
            // contracts must not gain an implicit value-type or nullability conversion.
            if (currentType.IsNullable &&
                !(isSemanticType && (!type.IsValueType || wireName == "location" && !property.IsRequired)))
            {
                name = null;
                type = null;
                return false;
            }

            return true;
        }

        public static bool TryGetAliasedName(
            InputModelProperty property,
            [NotNullWhen(true)] out string? name)
            => _propertyNames.TryGetValue(property.SerializedName ?? property.Name, out name);
    }
}
