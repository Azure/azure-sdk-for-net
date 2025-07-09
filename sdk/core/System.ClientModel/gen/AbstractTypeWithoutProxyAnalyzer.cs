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
        var proxyAttrType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.PersistableModelProxyAttribute");
        if (buildableAttrType == null)
            return;

        context.RegisterSymbolAction(symbolContext =>
        {
            var namedType = (INamedTypeSymbol)symbolContext.Symbol;
            if (namedType.TypeKind != TypeKind.Class)
                return;

            // Only look at context classes (those inheriting from ModelReaderWriterContext)
            var contextBaseType = symbolContext.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");
            if (contextBaseType == null)
                return;

            bool isContext = false;
            for (var baseType = namedType.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (SymbolEqualityComparer.Default.Equals(baseType, contextBaseType))
                {
                    isContext = true;
                    break;
                }
            }
            if (!isContext)
                return;

            // For each [ModelReaderWriterBuildable(typeof(T))] attribute, check T
            foreach (var attr in namedType.GetAttributes().Where(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, buildableAttrType)))
            {
                if (attr.ConstructorArguments.Length == 1 &&
                    attr.ConstructorArguments[0].Kind == TypedConstantKind.Type &&
                    attr.ConstructorArguments[0].Value is INamedTypeSymbol modelType)
                {
                    if (modelType.TypeKind == TypeKind.Class && modelType.IsAbstract)
                    {
                        // Check for [PersistableModelProxy] on the model type
                        bool hasProxy = modelType.GetAttributes().Any(a =>
                            proxyAttrType != null && SymbolEqualityComparer.Default.Equals(a.AttributeClass, proxyAttrType));
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
            }
        }, SymbolKind.NamedType);
    }
}
