// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that checks for multiple definitions of ModelReaderWriterContext.
/// </summary>
/// <remarks>
/// This analyzer uses CompilationStart/CompilationEnd and will only run on build, not during live editing.
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class MultipleContextAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterCompilationStartAction(StartAction);
    }

    private void StartAction(CompilationStartAnalysisContext context)
    {
        var contextType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
        if (contextType == null)
            return;

        var found = new ConcurrentBag<INamedTypeSymbol>();

        context.RegisterSymbolAction(symbolContext =>
        {
            var namedType = (INamedTypeSymbol)symbolContext.Symbol;
            if (namedType.TypeKind == TypeKind.Class &&
                namedType.InheritsFrom(contextType))
            {
                found.Add(namedType);
            }
        }, SymbolKind.NamedType);

        context.RegisterCompilationEndAction(compilationEndContext =>
        {
            if (found.Count > 1)
            {
                foreach (var symbol in found)
                {
                    var diagnostic = Diagnostic.Create(
                        ModelReaderWriterContextGenerator.DiagnosticDescriptors.MultipleContextsNotSupported,
                        symbol.Locations.FirstOrDefault() ?? Location.None);
                    compilationEndContext.ReportDiagnostic(diagnostic);
                }
            }
        });
    }
}
