// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TypeNameAnalyzer : SymbolAnalyzerBase
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Descriptors.AZC0012);
        public override SymbolKind[] SymbolKinds { get; } = [SymbolKind.NamedType];

        public override void Analyze(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

            // Only analyze SDK code
            if (!AnalyzerUtils.IsSdkCode(context.Symbol))
            {
                return;
            }

            if (namedTypeSymbol.DeclaredAccessibility == Accessibility.Public &&
                namedTypeSymbol.ContainingType == null &&
                (namedTypeSymbol.TypeKind == TypeKind.Class || namedTypeSymbol.TypeKind == TypeKind.Interface || namedTypeSymbol.TypeKind == TypeKind.Struct) &&
                CountWords(namedTypeSymbol.Name) <= 1)
            {
                var typeName = namedTypeSymbol.Name;

                foreach (var location in namedTypeSymbol.Locations)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0012, location, typeName));
                }
            }
        }

        private int CountWords(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return 0;
            }

            // For interfaces, ignore the 'I' prefix when counting words
            ReadOnlySpan<char> nameToCount = name.AsSpan();
            if (name.Length > 1 && name[0] == 'I' && char.IsUpper(name[1]))
            {
                nameToCount = nameToCount.Slice(1);
            }

            if (nameToCount.IsEmpty)
            {
                return 0;
            }

            int wordCount = 0;
            bool inAcronym = false;

            for (int i = 0; i < nameToCount.Length; i++)
            {
                char current = nameToCount[i];
                bool isCurrentUpper = char.IsUpper(current);
                bool hasNext = i < nameToCount.Length - 1;
                bool isNextLower = hasNext && char.IsLower(nameToCount[i + 1]);

                if (isCurrentUpper)
                {
                    if (!inAcronym)
                    {
                        // Start of a new word
                        wordCount++;
                        inAcronym = !isNextLower; // If next is lower, this is a regular word, not acronym
                    }
                    else if (isNextLower)
                    {
                        // End of acronym, start of new word (e.g., "HTTPClient" -> HTTP + Client)
                        wordCount++;
                        inAcronym = false;
                    }
                    // else: continue in acronym (e.g., "HTTP")
                }
                else
                {
                    inAcronym = false;
                }
            }

            return wordCount;
        }
    }
}
