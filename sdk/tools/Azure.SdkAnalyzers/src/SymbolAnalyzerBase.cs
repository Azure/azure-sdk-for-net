// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    public abstract class SymbolAnalyzerBase : DiagnosticAnalyzer
    {
        public abstract SymbolKind[] SymbolKinds { get; }
        public abstract void Analyze(SymbolAnalysisContext context);

        public sealed override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterSymbolAction(Analyze, SymbolKinds);
        }

        protected bool IsPublicApi(ISymbol symbol)
        {
            if (symbol.ContainingSymbol != null && !IsPublicApi(symbol.ContainingSymbol))
            {
                return false;
            }

            return symbol.DeclaredAccessibility == Accessibility.NotApplicable ||
                   symbol.DeclaredAccessibility == Accessibility.Public ||
                   symbol.DeclaredAccessibility == Accessibility.Protected;
        }
    }
}
