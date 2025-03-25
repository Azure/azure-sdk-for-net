// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace System.ClientModel.SourceGeneration
{
    /// <summary>
    /// SourceGenerator to create ModelReaderWriterContext.
    /// </summary>
    [Generator]
    public sealed partial class ContextGenerator : IIncrementalGenerator
    {
        private static readonly SymbolDisplayFormat s_FullyQualifiedNoGlobal = new SymbolDisplayFormat(
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Find all class declarations that inherit from ModelReaderWriterContext
            var classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => node is ClassDeclarationSyntax classDeclaration && IsModelReaderWriterContext(classDeclaration),
                    transform: (ctx, _) => GetIfMatching(ctx))
                .Where(symbol => symbol != null)
                .Collect();

            // Find all class declarations that implement IPersistableModel<T>
            var persistableModelDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => node is ClassDeclarationSyntax,
                    transform: (ctx, _) => GetPersistableNamedSymbol(ctx))
                .Where(symbol => symbol != null)
                .Collect();

            // Find all types that inherit from ModelReaderWriterContext from dependencies
            var referencedTypes = context.CompilationProvider
                .Select((compilation, _) =>
                {
                    var targetBaseType = compilation.GetTypeByMetadataName("System.ClientModel.Primitives.ModelReaderWriterContext");

                    if (targetBaseType is null)
                    {
                        return [];
                    }

                    List<INamedTypeSymbol> matchingTypes = [];

                    foreach (var reference in compilation.References)
                    {
                        var symbol = compilation.GetAssemblyOrModuleSymbol(reference) as IAssemblySymbol;
                        if (symbol is null)
                            continue;

                        foreach (var type in GetAllTypes(symbol.GlobalNamespace))
                        {
                            if (type.TypeKind == TypeKind.Class && type.DeclaredAccessibility == Accessibility.Public && type.InheritsFrom(targetBaseType))
                            {
                                matchingTypes.Add(type);
                            }
                        }
                    }

                    return matchingTypes.ToImmutableArray();
                });

            // Collect all types used in invocations to ModelReaderWriter.Read in the syntax tree
            var methodInvocations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => node is InvocationExpressionSyntax,
                    transform: (ctx, _) => (ctx.Node as InvocationExpressionSyntax, ctx.SemanticModel))
                .Where(tuple => tuple.Item1 is not null && IsTargetMethod(tuple.Item1, tuple.SemanticModel))
                .SelectMany((tuple, _) => GetRecursiveGenericTypes(GetGenericType(tuple.Item1, tuple.SemanticModel)))
                .Where(typeSymbol => typeSymbol is not null)
                .Collect();

            var assemblyNameProvider = context.CompilationProvider.Select((compilation, _) => compilation.Assembly.Identity.Name ?? "UnknownAssembly");

            var modelInfoTypes = persistableModelDeclarations
                .Combine(methodInvocations)
                .Select((tuple, _) => tuple.Left.AddRange(tuple.Right));

            var combined = classDeclarations
                .Combine(modelInfoTypes)
                .Combine(assemblyNameProvider)
                .Combine(referencedTypes)
                .Select((data, _) => (data.Left.Left.Left, data.Left.Left.Right, data.Left.Right, data.Right));

            context.RegisterSourceOutput(combined, ReportDiagnosticAndEmitSource);
        }

        private void ReportDiagnosticAndEmitSource(
            SourceProductionContext context,
            (ImmutableArray<INamedTypeSymbol?> Contexts,
                ImmutableArray<ISymbol?> ModelInfos,
                string AssemblyName,
                ImmutableArray<INamedTypeSymbol> ReferencedContexts) data)
        {
            if (data.Contexts.Length > 1)
            {
                context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.MultipleContextsNotSupported, Location.None));
                return;
            }

            var typeGenerationSpecs = data.ModelInfos
                .Select(x => new TypeGenerationSpec()
                {
                    Modifier = x!.DeclaredAccessibility.ToString().ToLowerInvariant(),
                    Type = TypeRef.FromINamedTypeSymbol(x),
                    Kind = x.GetModelInfoKind()
                })
                .Distinct();
            var referencedContexts = data.ReferencedContexts.Select(x => new TypeRef(x.Name, x.ContainingNamespace.ToDisplayString(), x.ContainingAssembly.ToDisplayString()));
            ContextGenerationSpec contextGenerationSpec;
            if (data.Contexts.Length == 0 || data.Contexts[0] is null)
            {
                contextGenerationSpec = new()
                {
                    Type = new TypeRef($"{data.AssemblyName.RemovePeriods()}Context", data.AssemblyName, data.AssemblyName),
                    Modifier = "internal",
                    Types = new ImmutableEquatableArray<TypeGenerationSpec>(typeGenerationSpecs),
                    ReferencedContexts = new ImmutableEquatableArray<TypeRef>(referencedContexts),
                };
            }
            else
            {
                var contentSymbol = data.Contexts[0]!;

                if (!IsPartialClass(contentSymbol))
                {
                    context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.ContextMustBePartial, Location.None));
                    return;
                }

                contextGenerationSpec = new()
                {
                    Type = new TypeRef(contentSymbol.Name, contentSymbol.ContainingNamespace.ToDisplayString(), contentSymbol.ContainingAssembly.ToDisplayString()),
                    Modifier = contentSymbol.DeclaredAccessibility.ToString().ToLowerInvariant(),
                    Types = new ImmutableEquatableArray<TypeGenerationSpec>(typeGenerationSpecs),
                    ReferencedContexts = new ImmutableEquatableArray<TypeRef>(referencedContexts),
                };
            }

            OnSourceEmitting?.Invoke(contextGenerationSpec);
            Emitter emitter = new(context);
            emitter.Emit(contextGenerationSpec);
        }

        /// <summary>
        /// Instrumentation helper for unit tests.
        /// </summary>
        internal Action<ContextGenerationSpec>? OnSourceEmitting { get; init; }

        private static ISymbol? GetGenericType(InvocationExpressionSyntax? invocation, SemanticModel semanticModel)
        {
            if (invocation is null)
                return null;

            if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess ||
                memberAccess.Name is not GenericNameSyntax genericName)
                return null;

            if (genericName.TypeArgumentList.Arguments.Count != 1)
                return null;

            var typeSyntax = genericName.TypeArgumentList.Arguments[0];
            var symbol = semanticModel.GetTypeInfo(typeSyntax).Type;

            if (symbol is INamedTypeSymbol || symbol is IArrayTypeSymbol)
                return symbol;

            return null;
        }

        private static bool IsTargetMethod(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
                return false;

            if (memberAccess.Name is not GenericNameSyntax genericName)
                return false;

            if (!genericName.Identifier.Text.Equals("Read", StringComparison.Ordinal))
                return false;

            var symbol = semanticModel.GetSymbolInfo(memberAccess.Expression).Symbol;

            if (symbol is not INamedTypeSymbol namedSymbol)
                return false;

            return namedSymbol.ToDisplayString(s_FullyQualifiedNoGlobal).Equals("System.ClientModel.Primitives.ModelReaderWriter", StringComparison.Ordinal) == true;
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
            return classDeclaration.BaseList?.Types.FirstOrDefault()?.Type.ToString().Equals("ModelReaderWriterContext", StringComparison.Ordinal) == true;
        }

        private static INamedTypeSymbol? GetIfMatching(GeneratorSyntaxContext context)
        {
            var classDecl = (ClassDeclarationSyntax)context.Node;
            var model = context.SemanticModel;
            var symbol = model.GetDeclaredSymbol(classDecl);
            if (symbol is null)
                return symbol;

            if (symbol is not INamedTypeSymbol namedSymbol)
                return null;

            return namedSymbol;
        }

        private ISymbol? GetPersistableNamedSymbol(GeneratorSyntaxContext context)
        {
            if (context.Node is not ClassDeclarationSyntax classDeclaration)
            {
                return null;
            }

            var semanticModel = context.SemanticModel;

            if (classDeclaration.BaseList is null)
            {
                return null;
            }

            var persistableSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
            if (persistableSymbol is null)
            {
                return null;
            }

            foreach (var baseItem in classDeclaration.BaseList.Types)
            {
                var baseTypeSymbol = semanticModel.GetSymbolInfo(baseItem.Type).Symbol as INamedTypeSymbol;
                if (baseTypeSymbol is null)
                {
                    continue;
                }

                if (IsIPersistableInterface(baseTypeSymbol))
                {
                    return persistableSymbol;
                }

                foreach (var interfaceSymbol in baseTypeSymbol.AllInterfaces)
                {
                    if (IsIPersistableInterface(interfaceSymbol))
                    {
                        return persistableSymbol;
                    }
                }
            }

            return null;
        }

        private static bool IsIPersistableInterface(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol.ContainingNamespace.ToDisplayString() == "System.ClientModel.Primitives" &&
                   typeSymbol.Name == "IPersistableModel" &&
                   typeSymbol.IsGenericType;
        }

        private static HashSet<ISymbol?> GetRecursiveGenericTypes(ISymbol? typeSymbol)
        {
            if (typeSymbol is null)
                return [];

            var types = new HashSet<ISymbol?>(SymbolEqualityComparer.Default);

            void CollectTypes(ISymbol? symbol)
            {
                if (symbol is null || types.Contains(symbol))
                    return;

                if (symbol is INamedTypeSymbol namedTypeSymbol)
                {
                    if (!ImplementsTargetInterfaces(namedTypeSymbol))
                        return;

                    types.Add(symbol);

                    foreach (var typeArg in namedTypeSymbol.TypeArguments.OfType<ISymbol>())
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
            if (typeSymbol.AllInterfaces.Any(i => i.ToDisplayString().StartsWith("System.ClientModel.Primitives.IPersistableModel<", StringComparison.Ordinal)))
                return true;

            if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
            {
                return namedTypeSymbol.IsList() || namedTypeSymbol.IsDictionary();
            }

            return typeSymbol is IArrayTypeSymbol;
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
}
