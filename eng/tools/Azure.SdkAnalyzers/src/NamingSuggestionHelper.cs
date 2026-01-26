// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Shared helper for generating consistent naming suggestions across all analyzers.
    /// </summary>
    public static class NamingSuggestionHelper
    {
        /// <summary>
        /// Gets namespace-aware naming suggestions for a given type.
        /// </summary>
        /// <param name="typeName">The current type name</param>
        /// <param name="typeSymbol">The type symbol for namespace context</param>
        /// <param name="primarySuffix">Primary suggested suffix</param>
        /// <param name="secondarySuffix">Secondary suggested suffix</param>
        /// <returns>Formatted suggestion string</returns>
        public static string GetNamespacedSuggestion(string typeName, INamedTypeSymbol typeSymbol, string primarySuffix, string secondarySuffix = null)
        {
            var namespacePrefix = GetNamespacePrefix(typeSymbol);
            var cleanTypeName = CleanTypeName(typeName);

            if (string.IsNullOrEmpty(secondarySuffix))
            {
                return $"'{namespacePrefix}{cleanTypeName}{primarySuffix}'";
            }

            return $"'{namespacePrefix}{cleanTypeName}{primarySuffix}' or '{namespacePrefix}{cleanTypeName}{secondarySuffix}'";
        }

        /// <summary>
        /// Gets naming suggestions based on common type patterns.
        /// </summary>
        /// <param name="typeName">The current type name</param>
        /// <param name="typeSymbol">The type symbol for namespace context</param>
        /// <returns>Formatted suggestion string</returns>
        public static string GetCommonTypeSuggestion(string typeName, INamedTypeSymbol typeSymbol)
        {
            var cleanTypeName = CleanTypeName(typeName);
            var namespacePrefix = GetNamespacePrefix(typeSymbol);

            // Handle composite names (e.g., "BlobClient" -> "TestBlobClient" or "TestServiceClient")
            if (IsCompositeClientName(cleanTypeName))
            {
                var primaryName = $"{namespacePrefix}{cleanTypeName}";
                var secondaryName = $"{namespacePrefix}ServiceClient";
                return $"'{primaryName}' or '{secondaryName}'";
            }

            // Handle exact matches with simple replacement patterns
            return cleanTypeName switch
            {
                "Client" => GetSimpleNamespacedSuggestion(namespacePrefix, "Client", "ServiceClient"),
                "Service" => GetSimpleNamespacedSuggestion(namespacePrefix, "Service", "Manager"),
                "Response" => GetSimpleNamespacedSuggestion(namespacePrefix, "Response", "Result"),
                "Operation" => GetSimpleNamespacedSuggestion(namespacePrefix, "Operation", "Process"),
                "Data" => GetSimpleNamespacedSuggestion(namespacePrefix, "Data", "Info"),
                "Options" => GetSimpleNamespacedSuggestion(namespacePrefix, "Options", "Settings"),
                "Settings" => GetSimpleNamespacedSuggestion(namespacePrefix, "Settings", "Config"),
                "Config" => GetSimpleNamespacedSuggestion(namespacePrefix, "Config", "Settings"),
                "Builder" => GetSimpleNamespacedSuggestion(namespacePrefix, "Builder", "Factory"),
                "Manager" => GetSimpleNamespacedSuggestion(namespacePrefix, "Manager", "Service"),
                "Provider" => GetSimpleNamespacedSuggestion(namespacePrefix, "Provider", "Factory"),
                "Handler" => GetSimpleNamespacedSuggestion(namespacePrefix, "Handler", "Processor"),
                "Helper" => GetSimpleNamespacedSuggestion(namespacePrefix, "Helper", "Util"),
                "Util" or "Utils" => GetSimpleNamespacedSuggestion(namespacePrefix, "Util", "Helper"),
                "Factory" => GetSimpleNamespacedSuggestion(namespacePrefix, "Factory", "Builder"),
                "Info" => GetSimpleNamespacedSuggestion(namespacePrefix, "Info", "Data"),
                "Result" => GetSimpleNamespacedSuggestion(namespacePrefix, "Result", "Response"),
                "Type" => GetSimpleNamespacedSuggestion(namespacePrefix, "Type", "Kind"),
                "Kind" => GetSimpleNamespacedSuggestion(namespacePrefix, "Kind", "Type"),
                "State" => GetSimpleNamespacedSuggestion(namespacePrefix, "State", "Status"),
                "Status" => GetSimpleNamespacedSuggestion(namespacePrefix, "Status", "State"),
                _ => GetNamespacedSuggestion(typeName, typeSymbol, "Client", "Service")
            };
        }

        /// <summary>
        /// Gets simple namespace-based suggestions without adding redundant suffixes.
        /// </summary>
        /// <param name="namespacePrefix">The namespace prefix</param>
        /// <param name="primaryName">Primary suggested name</param>
        /// <param name="secondaryName">Secondary suggested name</param>
        /// <returns>Formatted suggestion string</returns>
        public static string GetSimpleNamespacedSuggestion(string namespacePrefix, string primaryName, string secondaryName)
        {
            return $"'{namespacePrefix}{primaryName}' or '{namespacePrefix}{secondaryName}'";
        }

        /// <summary>
        /// Determines if a type name is a composite client name (e.g., "BlobClient", "TableClient").
        /// </summary>
        /// <param name="typeName">The clean type name</param>
        /// <returns>True if the name appears to be a composite client name</returns>
        public static bool IsCompositeClientName(string typeName)
        {
            return typeName.EndsWith("Client") &&
                   typeName.Length > "Client".Length &&
                   char.IsUpper(typeName[0]) &&
                   typeName != "Client";
        }

        /// <summary>
        /// Cleans type name by removing generic notation and interface prefixes.
        /// </summary>
        /// <param name="typeName">The type name to clean</param>
        /// <returns>Clean type name</returns>
        public static string CleanTypeName(string typeName)
        {
            var cleaned = typeName;

            // Remove generic type notation (e.g., "Operation`1" becomes "Operation")
            var backtickIndex = cleaned.IndexOf('`');
            if (backtickIndex >= 0)
            {
                cleaned = cleaned.Substring(0, backtickIndex);
            }

            // Remove interface prefix if present (e.g., "IClient" becomes "Client")
            if (cleaned.StartsWith("I") && cleaned.Length > 1 && char.IsUpper(cleaned[1]))
            {
                cleaned = cleaned.Substring(1);
            }

            return cleaned;
        }

        /// <summary>
        /// Extracts meaningful namespace prefix for naming suggestions.
        /// </summary>
        /// <param name="typeSymbol">The type symbol</param>
        /// <returns>Namespace prefix</returns>
        public static string GetNamespacePrefix(INamedTypeSymbol typeSymbol)
        {
            if (typeSymbol.ContainingNamespace == null || typeSymbol.ContainingNamespace.IsGlobalNamespace)
            {
                return "Custom"; // Fallback for types without meaningful namespace
            }

            var fullNamespace = typeSymbol.ContainingNamespace.GetFullNamespaceName().ToString();

            // Split the namespace and get meaningful segments
            var namespaceParts = fullNamespace.Split('.');

            // Skip common Azure prefixes and find the most specific meaningful part
            for (int i = namespaceParts.Length - 1; i >= 0; i--)
            {
                var part = namespaceParts[i];

                // Skip generic parts that don't provide context
                if (part.Equals("Models", System.StringComparison.OrdinalIgnoreCase) ||
                    part.Equals("Internal", System.StringComparison.OrdinalIgnoreCase) ||
                    part.Equals("Common", System.StringComparison.OrdinalIgnoreCase) ||
                    part.Equals("Azure", System.StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Convert to PascalCase and return the most specific part
                return ConvertToPascalCase(part);
            }

            // If we can't find a good namespace part, try to extract from the full namespace
            // For example: Azure.Messaging.EventHubs -> EventHubs
            if (namespaceParts.Length >= 3 && namespaceParts[0] == "Azure")
            {
                // Take the last meaningful part
                var lastPart = namespaceParts[namespaceParts.Length - 1];
                if (lastPart != "Models" && lastPart != "Internal" && lastPart != "Azure")
                {
                    return ConvertToPascalCase(lastPart);
                }

                // If last part is generic, try second to last
                if (namespaceParts.Length >= 4)
                {
                    return ConvertToPascalCase(namespaceParts[namespaceParts.Length - 2]);
                }
            }

            return "Custom"; // Final fallback
        }

        /// <summary>
        /// Converts string to PascalCase.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>PascalCase string</returns>
        public static string ConvertToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "Custom";

            // Handle cases like "EventHubs" (already PascalCase)
            if (char.IsUpper(input[0]))
                return input;

            // Handle cases like "eventHubs" or "eventhubs"
            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
