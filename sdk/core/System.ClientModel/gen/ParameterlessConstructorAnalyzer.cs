// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that ensures types used as buildable models have an accessible parameterless constructor.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ParameterlessConstructorAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor);

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

            if (!namedType.InheritsFrom(contextBaseType))
                return;

            // For each [ModelReaderWriterBuildable(typeof(T))] attribute, check T
            foreach (var attr in namedType.GetAttributes().Where(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass?.OriginalDefinition, buildableAttrType)))
            {
                if (attr.ConstructorArguments.Length == 1 &&
                    attr.ConstructorArguments[0].Kind == TypedConstantKind.Type &&
                    attr.ConstructorArguments[0].Value is INamedTypeSymbol modelType)
                {
                    // Skip unbound generic types like typeof(DataFactoryElement<>)
                    if (modelType.IsUnboundGenericType)
                        continue;

                    if (modelType.TypeKind == TypeKind.Class)
                    {
                        // Only report for types from the current compilation
                        if (!SymbolEqualityComparer.Default.Equals(modelType.ContainingAssembly, symbolContext.Compilation.Assembly))
                            return;

                        var proxyAttr = modelType.GetAttributes().FirstOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass?.OriginalDefinition, proxyAttrType));
                        if (proxyAttr is not null &&
                            proxyAttr.ConstructorArguments.Length == 1 &&
                            proxyAttr.ConstructorArguments[0].Kind == TypedConstantKind.Type &&
                            proxyAttr.ConstructorArguments[0].Value is INamedTypeSymbol proxyType)
                        {
                            symbolContext = CheckSymbolForCtor(symbolContext, proxyAttr, proxyType);
                        }
                        else if (!modelType.IsAbstract)
                        {
                            // Check for accessible parameterless constructor
                            symbolContext = CheckSymbolForCtor(symbolContext, attr, modelType);
                        }
                    }
                }
            }
        }, SymbolKind.NamedType);
    }

    private static SymbolAnalysisContext CheckSymbolForCtor(SymbolAnalysisContext symbolContext, AttributeData attr, INamedTypeSymbol modelType)
    {
        // Note: private protected (ProtectedAndInternal) is not allowed because the generated code
        // cannot access it from a different assembly
        bool hasCtor = modelType.Constructors.Any(ctor =>
            ctor is
            {
                IsStatic: false,
                Parameters.Length: 0,
                DeclaredAccessibility: Accessibility.Public or
                    Accessibility.Internal or
                    Accessibility.ProtectedOrInternal
            });
        if (!hasCtor)
        {
            // Use the attribute's location for the diagnostic
            var attributeLocation = attr.ApplicationSyntaxReference?.GetSyntax()?.GetLocation() ?? Location.None;

            var diagnostic = Diagnostic.Create(
                ModelReaderWriterContextGenerator.DiagnosticDescriptors.ParameterlessConstructor,
                attributeLocation,
                modelType.Name);
            symbolContext.ReportDiagnostic(diagnostic);
        }

        return symbolContext;
    }
}
