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
    private static readonly SymbolDisplayFormat s_fullyQualifiedNoGlobal = new SymbolDisplayFormat(
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
    private const string BuildableAttributeName = "System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute";

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var typesFromAttribute = context.SyntaxProvider.ForAttributeWithMetadataName(BuildableAttributeName,
                predicate: (node, _) => true,
                transform: (ctx, _) => (ctx.TargetSymbol as INamedTypeSymbol, ctx.Attributes))
            .Collect();

        context.RegisterSourceOutput(typesFromAttribute, ReportDiagnosticAndEmitSource);
    }

    private void ReportDiagnosticAndEmitSource(
        SourceProductionContext context,
        ImmutableArray<(INamedTypeSymbol? Context,
            ImmutableArray<AttributeData> Attributes)> data)
    {
        var tuples = data
            .Where(tuple =>
            {
                if (tuple.Context is null)
                    return false;

                return GetBaseClass(tuple.Context) is
                {
                    Name: "ModelReaderWriterContext",
                    ContainingType: null,
                    ContainingNamespace:
                    {
                        Name: "Primitives",
                        ContainingNamespace:
                        {
                            Name: "ClientModel",
                            ContainingNamespace:
                            {
                                Name: "System",
                                ContainingNamespace.IsGlobalNamespace: true
                            }
                        }
                    }
                };
            });

        if (tuples.Count() != 1)
        {
            // nothing to generate
            return;
        }

        var tuple = tuples.First();

        var contextSymbol = tuple.Context!;

        var mrwContextSymbol = GetBaseClass(contextSymbol);

        var contextType = TypeSymbolTypeRefCache.Get(contextSymbol);

        var builders = GetTypesFromAttributes(tuple.Attributes)
            .SelectMany(typeSymbol => GetRecursiveGenericTypes(typeSymbol))
            .Distinct(SymbolEqualityComparer.Default);

        var typeGenerationSpecs = builders
            .Select(symbol => ConvertToTypeBuilderSpec(symbol, context, contextType))
            .Where(spec => spec is not null)
            .Select(spec => spec!);

        if (!IsPartialClass(contextSymbol))
        {
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
        TypeRef contextType)
    {
        if (symbol is not ITypeSymbol typeSymbol || typeSymbol.DeclaredAccessibility == Accessibility.Private)
            return null;

        if (TypeSymbolKindCache.GetStatic(typeSymbol) == TypeBuilderKind.Unknown)
            return null;

        var type = TypeSymbolTypeRefCache.Get(typeSymbol);
        if (type.ObsoleteLevel == ObsoleteLevel.Error)
        {
            // if its marked as error obsolete we can't create a builder for it
            // you cannot suppress the reference to an obsolete type marked as error
            return null;
        }

        var itemType = type.GetInnerItemType();

        if (!HasAccessibleParameterlessConstructor(typeSymbol) && itemType.IsSameAssembly(contextType))
        {
            return null;
        }

        if (!itemType.IsSameAssembly(contextType) && itemType.ContainingContext is null)
        {
            return null;
        }

        var proxy = GetProxyType(typeSymbol);

        if (typeSymbol.IsAbstract && proxy is null)
        {
            return null;
        }

        return new TypeBuilderSpec()
        {
            Modifier = "internal",
            Type = type,
            Kind = TypeSymbolKindCache.GetStatic(typeSymbol),
            PersistableModelProxy = proxy is null ? null : TypeSymbolTypeRefCache.Get(proxy),
            ContextType = (typeSymbol is IArrayTypeSymbol ? itemType.ContainingContext : type.ContainingContext) ?? contextType,
        };
    }

    private IEnumerable<ITypeSymbol> GetTypesFromAttributes(ImmutableArray<AttributeData> attributes)
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

    private INamedTypeSymbol? GetBaseClass(INamedTypeSymbol typeSymbol)
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

    public static bool HasAccessibleParameterlessConstructor(ITypeSymbol typeSymbol)
    {
        ITypeSymbol GetInnerItemType(ITypeSymbol symbol)
        {
            var itemType = symbol.GetItemSymbol();
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

    private static HashSet<ITypeSymbol> GetRecursiveGenericTypes(ITypeSymbol typeSymbol)
    {
        var types = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);

        void CollectTypes(ITypeSymbol symbol)
        {
            if (symbol is null || types.Contains(symbol))
                return;

            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                if (!ImplementsTargetInterfaces(namedTypeSymbol))
                    return;

                types.Add(symbol);

                foreach (var typeArg in namedTypeSymbol.TypeArguments.OfType<ITypeSymbol>())
                {
                    CollectTypes(typeArg);
                }
            }
            else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                if (!ImplementsTargetInterfaces(arrayTypeSymbol.ElementType))
                    return;

                types.Add(symbol);

                CollectTypes(arrayTypeSymbol.ElementType);
            }
        }

        CollectTypes(typeSymbol);
        return types;
    }

    private static bool ImplementsTargetInterfaces(ITypeSymbol typeSymbol)
    {
        if (typeSymbol is INamedTypeSymbol namedSymbol && TypeSymbolKindCache.IsPersistable(namedSymbol))
        {
            return true;
        }

        var kind = TypeSymbolKindCache.GetStatic(typeSymbol);
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
