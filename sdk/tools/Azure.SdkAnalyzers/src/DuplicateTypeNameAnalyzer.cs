// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DuplicateTypeNameAnalyzer : SymbolAnalyzerBase
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Descriptors.AZC0034);
        public override SymbolKind[] SymbolKinds { get; } = [SymbolKind.NamedType];

        // Sorted array of reserved type names loaded from embedded resource
        private static readonly string[] ReservedTypeNames = LoadReservedTypeNames();

        // Parallel array of qualified type names corresponding to the reserved type names
        private static readonly string[] QualifiedTypeNames = LoadQualifiedTypeNames();

        private static string[] LoadReservedTypeNames()
        {
            var assembly = typeof(DuplicateTypeNameAnalyzer).GetTypeInfo().Assembly;
            var resourceName = "Azure.SdkAnalyzers.reserved-type-names.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return new string[0];
                }

                using (var reader = new StreamReader(stream))
                {
                    var names = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            names.Add(line);
                        }
                    }
                    var nameArray = names.ToArray();

                    VerifyNamesSorted(nameArray);

                    return nameArray;
                }
            }
        }

        private static string[] LoadQualifiedTypeNames()
        {
            var assembly = typeof(DuplicateTypeNameAnalyzer).GetTypeInfo().Assembly;
            var resourceName = "Azure.SdkAnalyzers.reserved-type-qualified-names.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return new string[0];
                }

                using (var reader = new StreamReader(stream))
                {
                    var names = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            names.Add(line);
                        }
                    }
                    return names.ToArray();
                }
            }
        }

        private static void VerifyNamesSorted(string[] names)
        {
            for (int i = 1; i < names.Length; i++)
            {
                if (StringComparer.Ordinal.Compare(names[i - 1], names[i]) > 0)
                {
                    throw new InvalidOperationException($"Reserved type names file is not sorted. '{names[i - 1]}' comes before '{names[i]}'");
                }
            }
        }

        public override void Analyze(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

            // Only analyze public types in Azure namespaces
            if (namedTypeSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return;
            }

            // Skip nested types
            if (namedTypeSymbol.ContainingType != null)
            {
                return;
            }

            // Check if this is in an Azure namespace
            var namespaceName = namedTypeSymbol.ContainingNamespace?.ToDisplayString();
            if (string.IsNullOrEmpty(namespaceName) || !namespaceName.StartsWith("Azure"))
            {
                return;
            }

            var typeName = namedTypeSymbol.MetadataName;

            // Check for conflicts with reserved types
            int index = Array.BinarySearch(ReservedTypeNames, typeName, StringComparer.Ordinal);
            if (index >= 0)
            {
                var qualifiedEntry = index < QualifiedTypeNames.Length ? QualifiedTypeNames[index] : "unknown type";

                // Parse the qualified entry to extract the type name and package name
                string qualifiedTypeName;
                string packageName = "";

                var semicolonIndex = qualifiedEntry.IndexOf(';');
                if (semicolonIndex >= 0)
                {
                    qualifiedTypeName = qualifiedEntry.Substring(0, semicolonIndex);
                    packageName = qualifiedEntry.Substring(semicolonIndex + 1);
                }
                else
                {
                    qualifiedTypeName = qualifiedEntry;
                }

                // Verify that the qualified name corresponds to the same type name with proper casing
                var lastDotIndex = qualifiedTypeName.LastIndexOf('.');
                var extractedTypeName = lastDotIndex >= 0 ? qualifiedTypeName.Substring(lastDotIndex + 1) : qualifiedTypeName;
                if (!string.Equals(typeName, extractedTypeName, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException($"Type name mismatch: expected '{typeName}' but qualified name contains '{extractedTypeName}' at index {index}");
                }

                // Check if this is exactly the same type (same namespace, name, and package)
                var currentAssemblyName = namedTypeSymbol.ContainingAssembly?.Name ?? "";

                // Get the metadata name for proper generic type comparison
                // For generic types, this includes the backtick notation (e.g., "Operation`1" for Operation<T>)
                var currentMetadataName = namedTypeSymbol.MetadataName;
                var currentNamespaceName = namedTypeSymbol.ContainingNamespace?.ToDisplayString() ?? "";
                var currentFullMetadataName = string.IsNullOrEmpty(currentNamespaceName)
                    ? currentMetadataName
                    : currentNamespaceName + "." + currentMetadataName;

                // Check if it's the same assembly first (most important check for false positives)
                if (string.Equals(currentAssemblyName, packageName, StringComparison.Ordinal))
                {
                    // If same assembly, check if the type names match (using metadata names for proper generic comparison)
                    if (string.Equals(currentFullMetadataName, qualifiedTypeName, StringComparison.Ordinal) ||
                        (qualifiedTypeName.IndexOf('.') < 0 && currentMetadataName.Equals(qualifiedTypeName, StringComparison.Ordinal)))
                    {
                        return;
                    }
                }

                // Create the error message including package name if available
                var conflictDescription = string.IsNullOrEmpty(packageName)
                    ? qualifiedTypeName
                    : $"{qualifiedTypeName} (from {packageName})";

                // Generate contextual suggestions based on namespace
                var suggestedName = GetSuggestedName(typeName, namedTypeSymbol);
                var additionalMessage = $"Consider renaming to {suggestedName} to avoid confusion.";

                foreach (var location in namedTypeSymbol.Locations)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0034, location,
                        new Dictionary<string, string> { { "SuggestedName", suggestedName } }.ToImmutableDictionary(),
                        typeName, conflictDescription, additionalMessage));
                }
            }
        }

        private string GetSuggestedName(string conflictingTypeName, INamedTypeSymbol typeSymbol)
        {
            return NamingSuggestionHelper.GetCommonTypeSuggestion(conflictingTypeName, typeSymbol);
        }
    }
}
