// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that ensures abstract types used as buildable models have a PersistableModelProxy defined.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AbstractTypeWithoutProxyAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterCompilationStartAction(StartAction);
    }

    private static void StartAction(CompilationStartAnalysisContext context)
    {
        var buildableAttrType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute");
        if (buildableAttrType == null)
            return;

        var proxyAttrType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.PersistableModelProxyAttribute");
        if (proxyAttrType == null)
            return;

        var contextBaseType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
        if (contextBaseType == null)
            return;

        context.RegisterSymbolAction(symbolContext =>
        {
            var namedType = (INamedTypeSymbol)symbolContext.Symbol;
            if (namedType.TypeKind != TypeKind.Class)
                return;

            // Only look at context classes (those inheriting from ModelReaderWriterContext)
            if (!namedType.InheritsFrom(contextBaseType))
                return;

            // For each [ModelReaderWriterBuildable(typeof(T))] attribute, check T
            foreach (var attr in namedType.GetAttributes().Where(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass?.OriginalDefinition, buildableAttrType)))
            {
                if (attr.ConstructorArguments.Length == 1 &&
                    attr.ConstructorArguments[0] is
                    {
                        Kind: TypedConstantKind.Type,
                        Value: INamedTypeSymbol
                        {
                            TypeKind: TypeKind.Class,
                            IsAbstract: true,
                            IsUnboundGenericType: false
                        }
                        modelType
                    })
                {
                    // Check for [PersistableModelProxy] on the model type
                    bool hasProxy = modelType.GetAttributes().Any(a =>
                        SymbolEqualityComparer.Default.Equals(a.AttributeClass?.OriginalDefinition, proxyAttrType));
                    if (!hasProxy)
                    {
                        var diagnostic = Diagnostic.Create(
                            ModelReaderWriterContextGenerator.DiagnosticDescriptors.AbstractTypeWithoutProxy,
                            modelType.Locations.FirstOrDefault() ?? namedType.Locations.FirstOrDefault() ?? Location.None,
                            modelType.Name);
                        symbolContext.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }, SymbolKind.NamedType);
    }
}
