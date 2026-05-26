// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Utilities
{
    internal static class BodyParameterNameNormalizer
    {
        private static readonly string[] ContentTypeSuffixes = ["Content", "Parameters", "Request", "Options", "Info", "Input"];

        /// <summary>
        /// Gets the normalized parameter name for body parameters.
        /// </summary>
        /// <param name="parameter">The parameter to normalize.</param>
        /// <returns>The normalized parameter name, or null if no normalization is needed.</returns>
        public static string? GetNormalizedBodyParameterName(ParameterProvider parameter)
        {
            if (parameter.Location != ParameterLocation.Body || !parameter.Type.IsModelType())
            {
                return null;
            }

            var typeName = parameter.Type.Name;

            // Check type name suffixes first - these are ARM conventions and take priority
            // Check if type name ends with "Patch" - return "patch"
            if (typeName.EndsWith("Patch", System.StringComparison.Ordinal))
            {
                return "patch";
            }

            // Check if type name ends with "Details" - return "details"
            if (typeName.EndsWith("Details", System.StringComparison.Ordinal))
            {
                return "details";
            }

            // Check if type name ends with "Data" - return "data"
            if (typeName.EndsWith("Data", System.StringComparison.Ordinal))
            {
                return "data";
            }

            // Check if type name ends with any content suffixes - return "content"
            foreach (var suffix in ContentTypeSuffixes)
            {
                if (typeName.EndsWith(suffix, System.StringComparison.Ordinal))
                {
                    return "content";
                }
            }

            // Check if parameter name equals "parameters" - return type name with first char lowercase
            // This is checked after type suffixes to ensure ARM conventions take priority
            if (parameter.Name.Equals("parameters", System.StringComparison.Ordinal))
            {
                return typeName.FirstCharToLowerCase();
            }

            return parameter.Name;
        }
    }
}
