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

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Find all class declarations that inherit from ModelReaderWriterContext
        var mrwContextCandidates = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: (node, _) => node is ClassDeclarationSyntax classDeclaration && IsModelReaderWriterContext(classDeclaration),
                transform: (ctx, _) => (Node: (ClassDeclarationSyntax)ctx.Node, ctx.SemanticModel))
            .Collect();

        // Used to skip processing if no ModelReaderWriterContext is found or too many are found
        var hasModelReaderWriterContext = mrwContextCandidates
            .Select((classes, _) => classes.Count() == 1);

        // Convert the candidates into INamedTypeSymbol
        var classDeclarations = mrwContextCandidates
            .SelectMany(static (classes, _) => classes.Select(tuple => tuple.SemanticModel.GetDeclaredSymbol(tuple.Node)))
            .Where(static result => result is not null)
            .Select(static (result, _) => result!)
            .Collect();

        // Find all class declarations that implement IPersistableModel<T>
        var persistableModelDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: (node, _) => node is ClassDeclarationSyntax,
                transform: (ctx, _) => (Node: (ClassDeclarationSyntax)ctx.Node, ctx.SemanticModel))
            .SelectWhen(hasModelReaderWriterContext, tuple =>
            {
                var (node, semanticModel) = tuple;
                return GetPersistableNamedSymbol(node, semanticModel);
            })
            .Collect();

        // Find all types that inherit from ModelReaderWriterContext from dependencies
        var references = context.CompilationProvider
            .Combine(hasModelReaderWriterContext)
            .SelectMany((tuple, _) =>
            {
                var (compilation, shouldRun) = tuple;
                return shouldRun
                    ? compilation.References.Select(r => compilation.GetAssemblyOrModuleSymbol(r)).OfType<IAssemblySymbol>()
                    : [];
            })
            .Collect();

        // Collect all types used in invocations to ModelReaderWriter.Read in the syntax tree
        var methodInvocations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: (node, _) => node is InvocationExpressionSyntax invocationSyntax && IsReadOrWriteCandidate(invocationSyntax),
                transform: (ctx, _) => (Node: (InvocationExpressionSyntax)ctx.Node, ctx.SemanticModel))
            .SelectWhen(hasModelReaderWriterContext, tuple =>
            {
                var (node, semanticModel) = tuple;
                return IsTargetMethod(node, semanticModel)
                    ? GetGenericType(node, semanticModel)
                    : null;
            })
            .Collect();

        var symbolToKindCacheProvider = context.CompilationProvider.Select((compilation, _) => new TypeSymbolKindCache());

        var symbolToTypeRefCacheProvider = context.CompilationProvider.Select((compilation, _) => new TypeSymbolTypeRefCache());

        var modelInfoTypes = persistableModelDeclarations
            .Combine(methodInvocations)
            .Select((tuple, _) => tuple.Left.AddRange(tuple.Right));

        var combined = classDeclarations
            .Combine(modelInfoTypes)
            .Combine(references)
            .Combine(symbolToKindCacheProvider)
            .Combine(symbolToTypeRefCacheProvider)
            .Select((data, _) => (
                data.Left.Left.Left.Left,
                data.Left.Left.Left.Right,
                data.Left.Left.Right,
                data.Left.Right,
                data.Right));

        context.RegisterSourceOutput(combined, ReportDiagnosticAndEmitSource);
    }

    private bool IsReadOrWriteCandidate(InvocationExpressionSyntax invocationSyntax)
    {
        var expression = invocationSyntax.Expression;

        var methodName = expression switch
        {
            IdentifierNameSyntax identifier => identifier.Identifier.Text,

            MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text,

            _ => null
        };

        return methodName is null ? false : methodName == "Read" || methodName == "Write";
    }

    private void ReportDiagnosticAndEmitSource(
        SourceProductionContext context,
        (ImmutableArray<INamedTypeSymbol> Contexts,
            ImmutableArray<ITypeSymbol> TypeBuilders,
            ImmutableArray<IAssemblySymbol> References,
            TypeSymbolKindCache SymbolToKindCache,
            TypeSymbolTypeRefCache SymbolToTypeRefCache) data)
    {
        if (data.Contexts.Length > 1)
        {
            context.ReportDiagnostic(Diagnostic.Create(
                DiagnosticDescriptors.MultipleContextsNotSupported,
                data.Contexts[0]?.Locations.First(),
                data.Contexts.Skip(1).Where(s => s is not null).Select(s => s!.Locations.First())));
            return;
        }

        if (data.Contexts.Length == 0)
        {
            // nothing to generate
            return;
        }

        var contextSymbol = data.Contexts[0];

        var mrwContextSymbol = GetMrwContextSymbol(contextSymbol);

        var contextType = data.SymbolToTypeRefCache.Get(contextSymbol, data.SymbolToKindCache);

        var builders = data.TypeBuilders
            .Concat(GetTypesFromAttributes(contextSymbol))
            .SelectMany(typeSymbol => GetRecursiveGenericTypes(typeSymbol, data.SymbolToKindCache))
            .Distinct(SymbolEqualityComparer.Default);

        ImmutableDictionary<string, TypeRef> referencedContexts = ImmutableDictionary<string, TypeRef>.Empty;
        if (mrwContextSymbol is not null)
        {
            referencedContexts = GetContextsFromDependencies(data.References, mrwContextSymbol).ToImmutableDictionary(
                refContext => refContext.ContainingAssembly.ToDisplayString(),
                refContext => data.SymbolToTypeRefCache.Get(refContext, data.SymbolToKindCache));
        }

        var typeGenerationSpecs = builders
            .Select(symbol =>
            {
                if (symbol is not ITypeSymbol typeSymbol || typeSymbol.DeclaredAccessibility == Accessibility.Private)
                    return null;

                if (data.SymbolToKindCache.Get(typeSymbol) == TypeBuilderKind.Unknown)
                    return null;

                var type = data.SymbolToTypeRefCache.Get(typeSymbol, data.SymbolToKindCache);
                if (type.ObsoleteLevel == ObsoleteLevel.Error)
                {
                    // if its marked as error obsolete we can't create a builder for it
                    // you cannot suppress the reference to an obsolete type marked as error
                    return null;
                }

                var itemType = type.GetInnerItemType();

                if (!HasAccessibleParameterlessConstructor(typeSymbol, data.SymbolToKindCache) && itemType.IsSameAssembly(contextType))
                {
                    context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.TypeMustHaveParameterlessConstructor, typeSymbol.Locations.FirstOrDefault(), type.Name));
                    return null;
                }

                if (!itemType.IsSameAssembly(contextType) && !referencedContexts.ContainsKey(itemType.Assembly))
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
                    Kind = data.SymbolToKindCache.Get(typeSymbol),
                    PersistableModelProxy = proxy is null ? null : data.SymbolToTypeRefCache.Get(proxy, data.SymbolToKindCache),
                    ContextType = referencedContexts.ContainsKey(type.Assembly) ? referencedContexts[type.Assembly] : contextType,
                };
            })
            .Where(spec => spec is not null)
            .Select(spec => spec!);

        if (!IsPartialClass(contextSymbol))
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.ContextMustBePartial, Location.None));
            return;
        }

        ModelReaderWriterContextGenerationSpec contextGenerationSpec = new()
        {
            Type = contextType,
            Modifier = contextSymbol.DeclaredAccessibility.ToString().ToLowerInvariant(),
            TypeBuilders = new ImmutableEquatableArray<TypeBuilderSpec>(typeGenerationSpecs),
            ReferencedContexts = new ImmutableEquatableArray<TypeRef>(referencedContexts.Values),
        };

        OnSourceEmitting?.Invoke(contextGenerationSpec);
        Emitter emitter = new(context);
        emitter.Emit(contextGenerationSpec);
    }

    private IEnumerable<ITypeSymbol> GetTypesFromAttributes(INamedTypeSymbol contextSymbol)
    {
        var attributes = contextSymbol.GetAttributes()
            .Where(attr => attr.AttributeClass?.ToDisplayString() == "System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute");

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

    private static IEnumerable<INamedTypeSymbol> GetContextsFromDependencies(ImmutableArray<IAssemblySymbol> assemblies, INamedTypeSymbol mrwContextSymbol)
    {
        List<INamedTypeSymbol> matchingTypes = [];

        foreach (var assembly in assemblies)
        {
            foreach (var type in GetAllTypes(assembly.GlobalNamespace))
            {
                if (type.TypeKind == TypeKind.Class && type.DeclaredAccessibility == Accessibility.Public && type.InheritsFrom(mrwContextSymbol))
                {
                    matchingTypes.Add(type);
                    break;
                }
            }
        }

        return matchingTypes;
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

    private static ITypeSymbol? GetGenericType(InvocationExpressionSyntax? invocation, SemanticModel semanticModel)
    {
        if (invocation is null)
            return null;

        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
            return null;

        ITypeSymbol? symbol;

        if (memberAccess.Name is GenericNameSyntax genericName)
        {
            if (genericName.TypeArgumentList.Arguments.Count != 1)
                return null;

            symbol = semanticModel.GetTypeInfo(genericName.TypeArgumentList.Arguments[0]).Type;
        }
        else
        {
            var argIndex = memberAccess.Name.Identifier.Text.Equals("Read", StringComparison.Ordinal) ? 1 : 0;
            if (invocation.ArgumentList.Arguments.Count < argIndex + 1)
                return null;

            symbol = GetUnderlyingType(semanticModel, invocation.ArgumentList.Arguments[argIndex].Expression);
        }

        return (symbol is INamedTypeSymbol || symbol is IArrayTypeSymbol) ? symbol : null;
    }

    private static ITypeSymbol? GetUnderlyingType(SemanticModel semanticModel, ExpressionSyntax argExpression)
    {
        while (true)
        {
            switch (argExpression)
            {
                case CastExpressionSyntax castExpr:
                    argExpression = castExpr.Expression;
                    continue;

                case ParenthesizedExpressionSyntax parenExpr:
                    argExpression = parenExpr.Expression;
                    continue;

                case ObjectCreationExpressionSyntax creationExpr:
                    return semanticModel.GetTypeInfo(creationExpr).Type;

                case TypeOfExpressionSyntax typeOfExpr:
                    return semanticModel.GetTypeInfo(typeOfExpr.Type).Type;

                case IdentifierNameSyntax identifierName:
                    var symbol = semanticModel.GetSymbolInfo(identifierName).Symbol;
                    if (symbol is ILocalSymbol localSymbol)
                    {
                        if (localSymbol.DeclaringSyntaxReferences.Length > 0)
                        {
                            var declSyntax = localSymbol.DeclaringSyntaxReferences[0].GetSyntax();
                            if (declSyntax is VariableDeclaratorSyntax variableDecl && variableDecl.Initializer != null)
                            {
                                argExpression = variableDecl.Initializer.Value;
                                continue;
                            }
                        }
                        return localSymbol.Type;
                    }
                    return null;

                default:
                    var typeInfo = semanticModel.GetTypeInfo(argExpression);
                    return typeInfo.Type ?? typeInfo.ConvertedType;
            }
        }
    }

    private static bool IsTargetMethod(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
    {
        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
            return false;

        var symbol = semanticModel.GetSymbolInfo(memberAccess.Expression).Symbol;

        if (symbol is not INamedTypeSymbol namedSymbol)
            return false;

        if (!memberAccess.Name.Identifier.Text.Equals("Read", StringComparison.Ordinal) && !memberAccess.Name.Identifier.Text.Equals("Write", StringComparison.Ordinal))
            return false;

        return namedSymbol.ToDisplayString(s_fullyQualifiedNoGlobal).Equals("System.ClientModel.Primitives.ModelReaderWriter", StringComparison.Ordinal) == true;
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

    private static bool IsModelReaderWriterContext(ClassDeclarationSyntax classDeclaration)
    {
        if (classDeclaration.BaseList == null)
            return false;

        foreach (var baseType in classDeclaration.BaseList.Types)
        {
            switch (baseType.Type)
            {
                case IdentifierNameSyntax identifier:
                    return identifier.Identifier.Text == "ModelReaderWriterContext";
                case QualifiedNameSyntax qualified:
                    return qualified.Right.Identifier.Text == "ModelReaderWriterContext";
            }
        }

        return false;
    }

    private ITypeSymbol? GetPersistableNamedSymbol(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel)
    {
        if (classDeclaration.BaseList is null)
        {
            return null;
        }

        var persistableSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
        if (persistableSymbol is null)
        {
            return null;
        }

        return persistableSymbol.AllInterfaces.Any(IsIPersistableInterface) ? persistableSymbol : null;
    }

    private static bool IsIPersistableInterface(INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.ContainingNamespace.ToDisplayString() == "System.ClientModel.Primitives" &&
               typeSymbol.Name == "IPersistableModel" &&
               typeSymbol.IsGenericType;
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
