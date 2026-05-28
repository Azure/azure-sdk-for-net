// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// SourceGenerator to create ModelReaderWriterContext.
/// </summary>
[Generator]
internal sealed partial class ModelReaderWriterContextGenerator : IIncrementalGenerator
{
    private const string BuildableAttributeName = "System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute";

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var typesFromAttribute = context.SyntaxProvider.ForAttributeWithMetadataName(BuildableAttributeName,
                predicate: (node, _) => true,
                transform: (ctx, _) => (ctx.TargetSymbol as INamedTypeSymbol, ctx.Attributes))
            .Collect();

        var symbolToKindCacheProvider = context.CompilationProvider.Select((compilation, _) => new TypeSymbolKindCache());

        var symbolToTypeRefCacheProvider = context.CompilationProvider.Select((compilation, _) => new TypeSymbolTypeRefCache());

        var combined = typesFromAttribute
            .Combine(symbolToKindCacheProvider)
            .Combine(symbolToTypeRefCacheProvider)
            .Select((data, _) => (
                data.Left.Left,
                data.Left.Right,
                data.Right));

        context.RegisterSourceOutput(combined, ReportDiagnosticAndEmitSource);
    }

    private void ReportDiagnosticAndEmitSource(
        SourceProductionContext context,
        (ImmutableArray<(INamedTypeSymbol? Context,
            ImmutableArray<AttributeData> Attributes)> TypesWithAttribute,
            TypeSymbolKindCache SymbolToKindCache,
            TypeSymbolTypeRefCache SymbolToTypeRefCache) data)
    {
        if (data.TypesWithAttribute.Length == 0 || data.TypesWithAttribute[0].Context is null || data.TypesWithAttribute[0].Context!.ContainingType is not null)
        {
            return;
        }

        if (data.TypesWithAttribute.Length == 1)
        {
            ProcessContext(context, data, data.TypesWithAttribute[0].Attributes);
            return;
        }

        var first = data.TypesWithAttribute[0].Context;

        for (int i = 1; i < data.TypesWithAttribute.Length; i++)
        {
            if (!SymbolEqualityComparer.Default.Equals(first, data.TypesWithAttribute[i].Context))
            {
                // Verify all contexts are partials of each other SCM0001.
                context.ReportDiagnostic(Diagnostic.Create(
                    DiagnosticDescriptors.MultipleContextsNotSupported,
                    data.TypesWithAttribute[0].Context?.Locations.First(),
                    data.TypesWithAttribute.Skip(1).Where(s => s.Context is not null).Select(s => s.Context!.Locations.First())));
                return;
            }
        }

        ProcessContext(context, data, data.TypesWithAttribute.SelectMany(c => c.Attributes));
    }

    private void ProcessContext(
        SourceProductionContext context,
        (ImmutableArray<(INamedTypeSymbol? Context,
            ImmutableArray<AttributeData> Attributes)> TypesWithAttribute,
            TypeSymbolKindCache SymbolToKindCache,
            TypeSymbolTypeRefCache SymbolToTypeRefCache) data,
        IEnumerable<AttributeData> allAttributes)
    {
        var contextSymbol = data.TypesWithAttribute[0].Context!;

        var mrwContextSymbol = GetMrwContextSymbol(contextSymbol);

        var contextType = data.SymbolToTypeRefCache.Get(contextSymbol, data.SymbolToKindCache);

        var builders = GetTypesFromAttributes(allAttributes)
            .SelectMany(typeSymbol => GetRecursiveGenericTypes(typeSymbol, data.SymbolToKindCache))
            .Distinct(SymbolEqualityComparer.Default);

        var typeGenerationSpecs = builders
            .Select(symbol => ConvertToTypeBuilderSpec(symbol, context, contextType, data.SymbolToKindCache, data.SymbolToTypeRefCache))
            .Where(spec => spec is not null)
            .Select(spec => spec!);

        if (!IsPartialClass(contextSymbol))
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.ContextMustBePartial, Location.None));
            return;
        }

        var builderArray = new ImmutableEquatableArray<TypeBuilderSpec>(typeGenerationSpecs);

        ModelReaderWriterContextGenerationSpec contextGenerationSpec = new()
        {
            Type = contextType,
            Modifier = contextSymbol.DeclaredAccessibility.ToString().ToLowerInvariant(),
            TypeBuilders = builderArray,
            ReferencedContexts = new ImmutableEquatableArray<TypeRef>(builderArray.Select(tb => tb.ContextType).Distinct().Where(tb => !tb.Equals(contextType))),
        };

        OnSourceEmitting?.Invoke(contextGenerationSpec);
        Emitter emitter = new(context);
        emitter.Emit(contextGenerationSpec);
    }

    private TypeBuilderSpec? ConvertToTypeBuilderSpec(
        ISymbol? symbol,
        SourceProductionContext context,
        TypeRef contextType,
        TypeSymbolKindCache symbolKindCache,
        TypeSymbolTypeRefCache symbolTypeRefCache)
    {
        if (symbol is not ITypeSymbol typeSymbol || typeSymbol.DeclaredAccessibility == Accessibility.Private)
            return null;

        if (symbolKindCache.Get(typeSymbol) == TypeBuilderKind.Unknown)
            return null;

        var type = symbolTypeRefCache.Get(typeSymbol, symbolKindCache);
        if (type.ObsoleteLevel == ObsoleteLevel.Error)
        {
            // if its marked as error obsolete we can't create a builder for it
            // you cannot suppress the reference to an obsolete type marked as error
            return null;
        }

        var itemType = type.GetInnerItemType();

        if (!HasAccessibleParameterlessConstructor(typeSymbol, symbolKindCache) && itemType.IsSameAssembly(contextType))
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.TypeMustHaveParameterlessConstructor, typeSymbol.Locations.FirstOrDefault(), type.Name));
            return null;
        }

        if (!itemType.IsSameAssembly(contextType) && itemType.ContainingContext is null)
        {
            return null;
        }

        var proxy = GetProxyType(typeSymbol);

        if (typeSymbol.IsAbstract && proxy is null)
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.AbstractTypeWithoutProxy, typeSymbol.Locations.FirstOrDefault(), type.Name));
            return null;
        }

        return new TypeBuilderSpec()
        {
            Modifier = "internal",
            Type = type,
            Kind = symbolKindCache.Get(typeSymbol),
            PersistableModelProxy = proxy is null ? null : symbolTypeRefCache.Get(proxy, symbolKindCache),
            ContextType = (typeSymbol is IArrayTypeSymbol ? itemType.ContainingContext : type.ContainingContext) ?? contextType,
        };
    }

    private IEnumerable<ITypeSymbol> GetTypesFromAttributes(IEnumerable<AttributeData> attributes)
    {
        foreach (var attr in attributes)
        {
            if (attr.ConstructorArguments.Length > 0)
            {
                var arg = attr.ConstructorArguments[0];
                if (arg.Kind == TypedConstantKind.Type && arg.Value is ITypeSymbol typeSymbol)
                {
                    yield return typeSymbol;
                }
            }
        }
    }

    private INamedTypeSymbol? GetMrwContextSymbol(INamedTypeSymbol typeSymbol)
    {
        var current = typeSymbol.BaseType;
        while (current != null && current.BaseType != null && current.BaseType.SpecialType != SpecialType.System_Object)
        {
            current = current.BaseType;
        }

        return current;
    }

    /// <summary>
    /// Instrumentation helper for unit tests.
    /// </summary>
    internal Action<ModelReaderWriterContextGenerationSpec>? OnSourceEmitting { get; init; }

    public static bool HasAccessibleParameterlessConstructor(ITypeSymbol typeSymbol, TypeSymbolKindCache cache)
    {
        ITypeSymbol GetInnerItemType(ITypeSymbol symbol)
        {
            var itemType = symbol.GetItemSymbol(cache);
            return itemType is null ? symbol : GetInnerItemType(itemType);
        }

        var itemType = GetInnerItemType(typeSymbol);

        if (itemType.IsAbstract || GetProxyType(itemType) is not null)
            return true; // DiagnosticDescriptors.AbstractTypeWithoutProxy will catch this

        if (itemType is not INamedTypeSymbol namedType)
            return false;

        return namedType.Constructors.Any(ctor =>
            !ctor.IsStatic &&
            ctor.Parameters.Length == 0 &&
            (ctor.DeclaredAccessibility == Accessibility.Public ||
            ctor.DeclaredAccessibility == Accessibility.Internal ||
            ctor.DeclaredAccessibility == Accessibility.ProtectedOrInternal));
    }

    public static INamedTypeSymbol? GetProxyType(ITypeSymbol typeSymbol)
    {
        var persistableModelProxyAttribute = typeSymbol.GetAttributes()
            .FirstOrDefault(attr => attr.AttributeClass?.Name == "PersistableModelProxyAttribute");

        if (persistableModelProxyAttribute == null || persistableModelProxyAttribute.ConstructorArguments.Length == 0)
            return null;

        var proxyTypeArg = persistableModelProxyAttribute.ConstructorArguments[0];

        return proxyTypeArg.Value as INamedTypeSymbol;
    }

    private static IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol ns)
    {
        foreach (var type in ns.GetTypeMembers())
            yield return type;

        foreach (var nestedNs in ns.GetNamespaceMembers())
        {
            foreach (var type in GetAllTypes(nestedNs))
                yield return type;
        }
    }

    private static bool IsPartialClass(ISymbol symbol)
    {
        if (symbol is INamedTypeSymbol namedTypeSymbol)
        {
            foreach (var syntaxRef in namedTypeSymbol.DeclaringSyntaxReferences)
            {
                var syntaxNode = syntaxRef.GetSyntax();
                if (syntaxNode is ClassDeclarationSyntax classDecl)
                {
                    if (classDecl.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private static HashSet<ITypeSymbol> GetRecursiveGenericTypes(ITypeSymbol typeSymbol, TypeSymbolKindCache symbolToKindCache)
    {
        var types = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);

        void CollectTypes(ITypeSymbol symbol)
        {
            if (symbol is null || types.Contains(symbol))
                return;

            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                if (!ImplementsTargetInterfaces(namedTypeSymbol, symbolToKindCache))
                    return;

                types.Add(symbol);

                foreach (var typeArg in namedTypeSymbol.TypeArguments.OfType<ITypeSymbol>())
                {
                    CollectTypes(typeArg);
                }
            }
            else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                if (!ImplementsTargetInterfaces(arrayTypeSymbol.ElementType, symbolToKindCache))
                    return;

                types.Add(symbol);

                CollectTypes(arrayTypeSymbol.ElementType);
            }
        }

        CollectTypes(typeSymbol);
        return types;
    }

    private static bool ImplementsTargetInterfaces(ITypeSymbol typeSymbol, TypeSymbolKindCache symbolToKindCache)
    {
        if (typeSymbol.AllInterfaces.Any(i => i.ToDisplayString().StartsWith("System.ClientModel.Primitives.IPersistableModel<", StringComparison.Ordinal)))
        {
            return true;
        }

        var kind = symbolToKindCache.Get(typeSymbol);
        switch (kind)
        {
            case TypeBuilderKind.IList:
            case TypeBuilderKind.IDictionary:
            case TypeBuilderKind.ReadOnlyMemory:
            case TypeBuilderKind.Array:
                return true;
            default:
                return false;
        }
    }

    private partial class Emitter
    {
        private readonly SourceProductionContext _context;

        public Emitter(SourceProductionContext context)
            => _context = context;

        private partial void AddSource(string hintName, SourceText sourceText)
            => _context.AddSource(hintName, sourceText);
    }
}
