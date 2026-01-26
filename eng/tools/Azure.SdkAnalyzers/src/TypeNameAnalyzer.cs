// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public override void Analyze(ISymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

            // Only analyze SDK code
            if (AnalyzerUtils.IsNotSdkCode(context.Symbol))
            {
                return;
            }

            // Count words in the type name
            if (namedTypeSymbol.DeclaredAccessibility == Accessibility.Public &&
                namedTypeSymbol.ContainingType == null &&
                (namedTypeSymbol.TypeKind == TypeKind.Class || namedTypeSymbol.TypeKind == TypeKind.Interface || namedTypeSymbol.TypeKind == TypeKind.Struct) &&
                CountWords(namedTypeSymbol.Name) <= 1)
            {
                var typeName = namedTypeSymbol.Name;

                foreach (var location in namedTypeSymbol.Locations)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0012, location,
                        typeName), context.Symbol);
                }
            }
        }

        private int CountWords(string name)
        {
            // For interfaces, ignore the 'I' prefix when counting words
            string nameToCount = name;
            if (name.Length > 1 && name.StartsWith("I") && char.IsUpper(name[1]))
            {
                nameToCount = name.Substring(1);
            }

            int i = 0;
            foreach (var c in nameToCount)
            {
                if (char.IsUpper(c))
                {
                    i++;
                }
            }

            return i;
        }
    }
}
