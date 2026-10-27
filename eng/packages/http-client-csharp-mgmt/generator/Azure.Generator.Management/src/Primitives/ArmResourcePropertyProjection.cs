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
    /// Shares exceptional ARM property names between property creation and historical-base checks.
    /// Semantic CLR types are supplied by the type factory, not converted here.
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
                _propertyNames.TryGetValue(property.SerializedName ?? property.Name, out name);
        }
    }
}
