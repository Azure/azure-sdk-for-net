// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Analyzer to check model names ending with "Data". Avoid using "Data" as a model suffix
    /// unless the model derives from ResourceData/TrackedResourceData.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DataSuffixAnalyzer : SymbolAnalyzerBase
    {
        private const string DataSuffix = "Data";
        private const string ResourceDataTypeName = "ResourceData";
        private const string TrackedResourceDataTypeName = "TrackedResourceData";
        private const string SuggestedNamePropertyKey = "SuggestedName";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Descriptors.AZC0032);

        public override SymbolKind[] SymbolKinds { get; } = [SymbolKind.NamedType];

        public override void Analyze(SymbolAnalysisContext context)
        {
            var typeSymbol = (INamedTypeSymbol)context.Symbol;

            if (typeSymbol.DeclaredAccessibility != Accessibility.Public ||
                !typeSymbol.Name.EndsWith(DataSuffix, StringComparison.Ordinal) ||
                !AnalyzerUtils.IsSdkCode(typeSymbol) ||
                !ModelTypeHelper.IsModelType(typeSymbol) ||
                DerivesFromResourceData(typeSymbol))
            {
                return;
            }

            string suggestedName = NamingSuggestionHelper.GetNamespacedSuggestion(typeSymbol.Name, typeSymbol, "Info", "Details");
            ImmutableDictionary<string, string> properties = new Dictionary<string, string>
            {
                { SuggestedNamePropertyKey, suggestedName }
            }.ToImmutableDictionary();

            context.ReportDiagnostic(Diagnostic.Create(
                Descriptors.AZC0032,
                typeSymbol.Locations[0],
                properties,
                typeSymbol.Name,
                DataSuffix));
        }

        private static bool DerivesFromResourceData(INamedTypeSymbol typeSymbol)
        {
            for (INamedTypeSymbol type = typeSymbol; type is not null; type = type.BaseType)
            {
                if ((type.Name == ResourceDataTypeName || type.Name == TrackedResourceDataTypeName) &&
                    AnalyzerUtils.IsNamespace(type.ContainingNamespace, "Azure", "ResourceManager", "Models"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
