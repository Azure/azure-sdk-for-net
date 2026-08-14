// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Provides helper methods for generating type name suggestions.
    /// Used by both the analyzer (for diagnostic messages) and the code fix provider.
    /// </summary>
    internal static class TypeNameSuggestionHelper
    {
        /// <summary>
        /// Generates up to 3 name suggestions based on namespace parts.
        /// </summary>
        public static ImmutableArray<string> GenerateNameSuggestions(INamedTypeSymbol typeSymbol)
        {
            ImmutableArray<string>.Builder suggestions = ImmutableArray.CreateBuilder<string>();
            string currentName = typeSymbol.Name;

            // For interfaces, work with the name without 'I' prefix
            string baseName = currentName;
            bool isInterface = typeSymbol.TypeKind == TypeKind.Interface;
            if (isInterface && currentName.Length > 1 && currentName[0] == 'I' && char.IsUpper(currentName[1]))
            {
                baseName = currentName.Substring(1);
            }

            // Get namespace parts (exclude 'Azure' and common prefixes)
            List<string> namespaceParts = typeSymbol.ContainingNamespace.ToDisplayString()
                .Split('.')
                .Where(p => !string.Equals(p, "Azure", StringComparison.OrdinalIgnoreCase) &&
                           !string.IsNullOrWhiteSpace(p))
                .Reverse()
                .ToList();

            // Generate up to 3 suggestions using namespace parts
            int suggestionCount = 0;
            foreach (string part in namespaceParts)
            {
                if (suggestionCount >= 3)
                    break;

                string newName = part + baseName;

                // Add 'I' prefix back for interfaces
                if (isInterface && newName[0] != 'I')
                {
                    newName = "I" + newName;
                }

                // Avoid suggesting the same name
                if (!string.Equals(newName, currentName, StringComparison.Ordinal))
                {
                    suggestions.Add(newName);
                    suggestionCount++;
                }
            }

            // If we don't have enough suggestions, add some generic ones
            while (suggestions.Count < 3)
            {
                string fallback;
                if (suggestions.Count == 0)
                {
                    fallback = baseName + "Service";
                }
                else if (suggestions.Count == 1)
                {
                    fallback = baseName + "Client";
                }
                else
                {
                    fallback = baseName + "Options";
                }

                if (isInterface && fallback[0] != 'I')
                {
                    fallback = "I" + fallback;
                }

                if (!suggestions.Contains(fallback) && !string.Equals(fallback, currentName, StringComparison.Ordinal))
                {
                    suggestions.Add(fallback);
                }
                else
                {
                    // If the fallback is already used, add a number
                    suggestions.Add($"{baseName}Type{suggestions.Count}");
                }
            }

            return suggestions.ToImmutable();
        }

        /// <summary>
        /// Formats suggestions as a comma-separated string for display in diagnostic messages.
        /// </summary>
        public static string FormatSuggestions(ImmutableArray<string> suggestions)
        {
            return string.Join(", ", suggestions.Select(s => $"'{s}'"));
        }
    }
}
