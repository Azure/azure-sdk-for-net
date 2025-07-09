// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that ensures ModelReaderWriterBuildableAttribute is only applied to classes inheriting from ModelReaderWriterContext.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class BuildableAttributeUsageAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext);

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

        // Look for ModelReaderWriterBuildableAttribute
        var hasBuildableAttribute = namedType.GetAttributes().Any(attr =>
            attr.AttributeClass?.ToDisplayString() == "System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute");

        if (!hasBuildableAttribute)
            return;

        // Check if the class inherits from ModelReaderWriterContext
        var contextType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
        if (contextType == null)
            return;

        bool inheritsFromContext = false;
        for (var baseType = namedType.BaseType; baseType != null; baseType = baseType.BaseType)
        {
            if (SymbolEqualityComparer.Default.Equals(baseType, contextType))
            {
                inheritsFromContext = true;
                break;
            }
        }

        if (!inheritsFromContext)
        {
            var diagnostic = Diagnostic.Create(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext,
                namedType.Locations.FirstOrDefault() ?? Location.None);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
