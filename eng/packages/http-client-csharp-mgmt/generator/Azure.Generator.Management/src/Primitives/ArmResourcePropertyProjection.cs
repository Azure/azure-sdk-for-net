// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Primitives
{
    /// <summary>
    /// Defines ARM envelope property names, CLR shapes, and projection policies shared by
    /// naming, historical framework-base matching, and missing wire metadata restoration.
    /// Ordinary property creation is not converted.
    /// </summary>
    internal static class ArmResourcePropertyProjection
    {
        private static readonly IReadOnlyDictionary<string, PropertyDefinition> _propertiesByWireName =
            new PropertyDefinition[]
            {
                new("id", nameof(ResourceData.Id), typeof(ResourceIdentifier), IsReadOnly: true, HasHistoricalShape: true),
                new("name", nameof(ResourceData.Name), typeof(string), IsReadOnly: true),
                new("type", nameof(ResourceData.ResourceType), typeof(ResourceType), IsReadOnly: true, HasAlias: true, HasHistoricalShape: true),
                new("systemData", nameof(ResourceData.SystemData), typeof(SystemData), IsReadOnly: true),
                new("location", nameof(TrackedResourceData.Location), typeof(AzureLocation), IsReadOnly: false, HasHistoricalShape: true, NormalizeOptionalNullable: true),
                new("tags", nameof(TrackedResourceData.Tags), typeof(IDictionary<string, string>), IsReadOnly: false),
            }.ToDictionary(property => property.SerializedName);

        private static readonly IReadOnlyDictionary<string, PropertyDefinition> _propertiesByClrName =
            _propertiesByWireName.Values.ToDictionary(property => property.Name);

        public static bool TryGetName(
            InputModelProperty property,
            CSharpType currentType,
            [NotNullWhen(true)] out string? name)
        {
            name = null;
            if (_propertiesByWireName.TryGetValue(property.SerializedName ?? property.Name, out var definition) &&
                definition.HasAlias && currentType.WithNullable(false).Equals(definition.Type))
            {
                name = definition.Name;
                return true;
            }
            return false;
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
            name = null;
            type = null;
            if (!_propertiesByWireName.TryGetValue(property.SerializedName ?? property.Name, out var definition) ||
                !definition.HasHistoricalShape)
            {
                return false;
            }

            name = definition.Name;
            type = definition.Type;
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
                !(isSemanticType && (!type.IsValueType || definition.NormalizeOptionalNullable && !property.IsRequired)))
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
        {
            name = null;
            if (_propertiesByWireName.TryGetValue(property.SerializedName ?? property.Name, out var definition) &&
                definition.HasAlias)
            {
                name = definition.Name;
                return true;
            }
            return false;
        }

        public static bool TryGetFrameworkWireMetadata(
            PropertyProvider property,
            [NotNullWhen(true)] out PropertyWireInformation? wireInfo)
        {
            wireInfo = null;
            if (!_propertiesByClrName.TryGetValue(property.Name, out var definition) ||
                !property.Type.WithNullable(false).Equals(definition.Type))
            {
                return false;
            }

            // An inherited ARM envelope retains the same wire fields as an explicitly customized
            // framework base, even when the current input does not repeat those fields.
            wireInfo = new PropertyWireInformation(
                property.SerializationFormat, isRequired: false, isReadOnly: definition.IsReadOnly, isNullable: false,
                isDiscriminator: false, serializedName: definition.SerializedName, isHttpMetadata: false, isApiVersion: false);
            return true;
        }

        private sealed record PropertyDefinition(
            string SerializedName,
            string Name,
            CSharpType Type,
            bool IsReadOnly,
            bool HasAlias = false,
            bool HasHistoricalShape = false,
            bool NormalizeOptionalNullable = false);
    }
}
