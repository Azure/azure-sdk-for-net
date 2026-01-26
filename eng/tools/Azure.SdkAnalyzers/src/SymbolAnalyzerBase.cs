// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    public abstract class SymbolAnalyzerBase : DiagnosticAnalyzer
    {
        private const string ClientOptionsSuffix = "ClientOptions";
        private const string ClientsOptionsSuffix = "ClientsOptions";
        private const string AzureCoreClientOptions = "Azure.Core.ClientOptions";
        private const string SystemClientModelClientSettings = "System.ClientModel.ClientSettings";

        public abstract SymbolKind[] SymbolKinds { get; }
        public abstract void Analyze(ISymbolAnalysisContext context);

        protected INamedTypeSymbol ClientOptionsType { get; private set; }

        public sealed override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterSymbolAction(c => Analyze(new RoslynSymbolAnalysisContext(c)), SymbolKinds);
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

        protected bool IsClientOptionsType(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Class || typeSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            ITypeSymbol baseType = typeSymbol.BaseType;
            while (baseType != null)
            {
                // validate if the base type is Azure.Core.ClientOptions
                var fullName = $"{baseType.ContainingNamespace.GetFullNamespaceName()}.{baseType.Name}";
                if ($"{fullName}".Equals(AzureCoreClientOptions))
                {
                    return typeSymbol.Name.EndsWith(ClientOptionsSuffix) || typeSymbol.Name.EndsWith(ClientsOptionsSuffix);
                }

                baseType = baseType.BaseType;
            }

            return false;
        }

        protected bool IsClientSettingsType(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Class || typeSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            ITypeSymbol baseType = typeSymbol.BaseType;
            while (baseType != null)
            {
                // validate if the base type is System.ClientModel.ClientSettings
                var fullName = $"{baseType.ContainingNamespace.GetFullNamespaceName()}.{baseType.Name}";
                if ($"{fullName}".Equals(SystemClientModelClientSettings))
                {
                    return true;
                }

                baseType = baseType.BaseType;
            }

            return false;
        }

        private class RoslynSymbolAnalysisContext : ISymbolAnalysisContext
        {
            private readonly SymbolAnalysisContext _context;

            public RoslynSymbolAnalysisContext(SymbolAnalysisContext context)
            {
                _context = context;
            }

            public ISymbol Symbol => _context.Symbol;

            public void ReportDiagnostic(Diagnostic diagnostic, ISymbol symbol)
            {
                _context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
