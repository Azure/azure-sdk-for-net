// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that checks if classes inheriting from ModelReaderWriterContext are declared with the partial modifier.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class PartialModifierAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.ContextMustBePartial);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
    }

    private static void AnalyzeSymbol(SymbolAnalysisContext context)
    {
        var namedType = (INamedTypeSymbol)context.Symbol;
        if (namedType.TypeKind != TypeKind.Class)
            return;

        var contextType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
        if (contextType == null)
            return;

        // Check if this class inherits from ModelReaderWriterContext (directly or indirectly)
        if (!namedType.InheritsFrom(contextType))
            return;

        // Check for partial modifier
        if (!namedType.DeclaringSyntaxReferences.Any(syntaxRef =>
        {
            var syntax = syntaxRef.GetSyntax();
            return syntax is Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax classDecl &&
                   classDecl.Modifiers.Any(m => m.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.PartialKeyword));
        }))
        {
            var diagnostic = Diagnostic.Create(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.ContextMustBePartial,
                namedType.Locations.FirstOrDefault() ?? Location.None);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
