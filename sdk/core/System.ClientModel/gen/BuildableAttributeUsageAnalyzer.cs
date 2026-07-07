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
        context.RegisterCompilationStartAction(StartAction);
    }

    private static void StartAction(CompilationStartAnalysisContext context)
    {
        var contextType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
        if (contextType == null)
            return;

        var buildableAttrType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute");
        if (buildableAttrType == null)
            return;

        context.RegisterSymbolAction(symbolContext =>
        {
            if (symbolContext.Symbol is not INamedTypeSymbol { TypeKind: TypeKind.Class } namedType)
                return;

            // Look for ModelReaderWriterBuildableAttribute
            var hasBuildableAttribute = namedType.GetAttributes().Any(attr => SymbolEqualityComparer.Default.Equals(attr.AttributeClass?.OriginalDefinition, buildableAttrType));

            if (!hasBuildableAttribute)
                return;

            var current = namedType.BaseType;
            do
            {
                if (current!.SpecialType == SpecialType.System_Object)
                {
                    var diagnostic = Diagnostic.Create(
                        ModelReaderWriterContextGenerator.DiagnosticDescriptors.BuildableAttributeRequiresContext,
                        namedType.Locations.FirstOrDefault() ?? Location.None);
                    symbolContext.ReportDiagnostic(diagnostic);
                    return;
                }

                if (SymbolEqualityComparer.Default.Equals(current, contextType))
                {
                    return;
                }

                current = current.BaseType;
            }
            while (true);
        }, SymbolKind.NamedType);
    }
}
