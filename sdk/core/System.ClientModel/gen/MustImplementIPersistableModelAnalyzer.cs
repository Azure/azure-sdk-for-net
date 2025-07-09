// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Analyzer that ensures types used in ModelReaderWriterBuildable implement IPersistableModel&lt;T&gt;.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class MustImplementIPersistableModelAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel);

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
        var iPersistableModelType = context.Compilation.GetTypeByMetadataName("System.ClientModel.Primitives.IPersistableModel`1");
        if (buildableAttrType == null || iPersistableModelType == null)
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
                    attr.ConstructorArguments[0].Kind == TypedConstantKind.Type)
                {
                    var outterModel = attr.ConstructorArguments[0].Value as ITypeSymbol;
                    if (outterModel is null)
                        continue;

                    var modelType = GetModelType(outterModel);
                    if (modelType is null)
                    {
                        ReportDiagnostic(symbolContext, namedType, attr, outterModel);
                        continue;
                    }

                    // Check if modelType implements IPersistableModel<T>
                    bool implements = modelType.AllInterfaces.Any(i =>
                        i.OriginalDefinition.Equals(iPersistableModelType, SymbolEqualityComparer.Default));

                    if (!implements)
                    {
                        symbolContext = ReportDiagnostic(symbolContext, namedType, attr, modelType);
                    }
                }
            }
        }, SymbolKind.NamedType);
    }

    private static SymbolAnalysisContext ReportDiagnostic(SymbolAnalysisContext symbolContext, INamedTypeSymbol namedType, AttributeData attr, ITypeSymbol modelType)
    {
        var attributeLocation = attr.ApplicationSyntaxReference?.GetSyntax()?.GetLocation()
            ?? namedType.Locations.FirstOrDefault()
            ?? Location.None;

        var diagnostic = Diagnostic.Create(
            ModelReaderWriterContextGenerator.DiagnosticDescriptors.MustImplementIPersistableModel,
            attributeLocation,
            modelType.Name);
        symbolContext.ReportDiagnostic(diagnostic);
        return symbolContext;
    }

    private static INamedTypeSymbol? GetModelType(object? value)
    {
        if (value is ITypeSymbol typeSymbol)
        {
            // Get the innermost element type for arrays and collections
            return GetInnermostElementType(typeSymbol);
        }

        return null;
    }

    private static INamedTypeSymbol? GetInnermostElementType(ITypeSymbol type)
    {
        if (type is IArrayTypeSymbol arrayType)
        {
            return GetInnermostElementType(arrayType.ElementType);
        }

        if (type is INamedTypeSymbol namedType)
        {
            if (!namedType.IsGenericType)
                return namedType;

            var index = IsDictionary(namedType) ? 1 : IsList(namedType) || IsReadOnlyMemory(namedType) ? 0 : -1;
            if (index >= 0)
            {
                return GetInnermostElementType(namedType.TypeArguments[index]);
            }
        }

        return null;
    }

    private static bool IsDictionary(INamedTypeSymbol namedType)
    {
        return namedType.ConstructedFrom is
        {
            Arity: 2,
            Name: "Dictionary",
            ContainingType: null,
            ContainingNamespace:
            {
                Name: "Generic",
                ContainingNamespace:
                {
                    Name: "Collections",
                    ContainingNamespace:
                    {
                        Name: "System",
                        ContainingNamespace.IsGlobalNamespace: true
                    }
                }
            }
        };
    }

    private static bool IsList(INamedTypeSymbol namedType)
    {
        return namedType.ConstructedFrom is
        {
            Arity: 1,
            Name: "List",
            ContainingType: null,
            ContainingNamespace:
            {
                Name: "Generic",
                ContainingNamespace:
                {
                    Name: "Collections",
                    ContainingNamespace:
                    {
                        Name: "System",
                        ContainingNamespace.IsGlobalNamespace: true
                    }
                }
            }
        };
    }

    private static bool IsReadOnlyMemory(INamedTypeSymbol namedType)
    {
        return namedType.ConstructedFrom is
        {
            Arity: 1,
            Name: "ReadOnlyMemory",
            ContainingType: null,
            ContainingNamespace:
            {
                Name: "System",
                ContainingNamespace.IsGlobalNamespace: true
            }
        };
    }
}
