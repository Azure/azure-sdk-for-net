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
    internal sealed partial class ModelReaderWriterContextGenerator : IIncrementalGenerator
    {
        private static readonly SymbolDisplayFormat s_FullyQualifiedNoGlobal = new SymbolDisplayFormat(
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        private readonly struct AttributeInfo
        {
            public AttributeInfo(ISymbol? symbol, List<Diagnostic>? diagnostics = null)
            {
                Symbol = symbol;
                Diagnostics = diagnostics ?? [];
            }

            public ISymbol? Symbol { get; }
            public List<Diagnostic> Diagnostics { get; }
        }

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

            // Collect all types used in ModelReaderWriterBuildableAttribute constructors
            var attributeInfos = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: (node, _) => node is AttributeSyntax,
                    transform: (ctx, _) => GetAttributeInfo(ctx.Node as AttributeSyntax, ctx.SemanticModel))
                .Where(info => info.Symbol != null || info.Diagnostics?.Count > 0)
                .Collect();

            context.RegisterSourceOutput(attributeInfos, (productionContext, infos) =>
            {
                foreach (var info in infos)
                {
                    foreach (var diagnostic in info.Diagnostics)
                    {
                        productionContext.ReportDiagnostic(diagnostic);
                    }
                }
            });

            var attributeInvocations = attributeInfos
                .SelectMany((infos, _) => infos.Where(info => info.Symbol != null).Select(info => info.Symbol!))
                .SelectMany((symbol, _) => GetRecursiveGenericTypes(symbol))
                .Where(typeSymbol => typeSymbol != null)
                .Collect();

            var assemblyNameProvider = context.CompilationProvider.Select((compilation, _) => compilation.Assembly.Identity.Name ?? "UnknownAssembly");

            var modelInfoTypes = persistableModelDeclarations
                .Combine(methodInvocations)
                .Select((tuple, _) => tuple.Left.AddRange(tuple.Right));

            modelInfoTypes = modelInfoTypes
                .Combine(attributeInvocations)
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
                .Select(x => new TypeBuilderSpec()
                {
                    Modifier = x!.DeclaredAccessibility.ToString().ToLowerInvariant(),
                    Type = TypeRef.FromINamedTypeSymbol(x),
                    Kind = x.GetModelInfoKind()
                })
                .Distinct();
            var referencedContexts = data.ReferencedContexts.Select(x => new TypeRef(x.Name, x.ContainingNamespace.ToDisplayString(), x.ContainingAssembly.ToDisplayString()));
            ModelReaderWriterContextGenerationSpec contextGenerationSpec;
            if (data.Contexts.Length == 0 || data.Contexts[0] is null)
            {
                contextGenerationSpec = new()
                {
                    Type = new TypeRef($"{data.AssemblyName.RemovePeriods()}Context", data.AssemblyName, data.AssemblyName),
                    Modifier = "internal",
                    TypeBuilders = new ImmutableEquatableArray<TypeBuilderSpec>(typeGenerationSpecs),
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
                    TypeBuilders = new ImmutableEquatableArray<TypeBuilderSpec>(typeGenerationSpecs),
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
        internal Action<ModelReaderWriterContextGenerationSpec>? OnSourceEmitting { get; init; }

        private AttributeInfo GetAttributeInfo(AttributeSyntax? attribute, SemanticModel semanticModel)
        {
            {
                if (attribute == null)
                    return default;

                // Check if this is ModelReaderWriterBuildableAttribute
                var attributeSymbol = semanticModel.GetSymbolInfo(attribute).Symbol?.ContainingType;
                if (attributeSymbol == null ||
                    attributeSymbol.ToDisplayString(s_FullyQualifiedNoGlobal) != "System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute")
                    return default;

                // Check if it's applied to a class
                var parent = attribute.Parent?.Parent as ClassDeclarationSyntax;
                if (parent == null)
                    return default;

                var classSymbol = semanticModel.GetDeclaredSymbol(parent);
                if (classSymbol == null)
                    return default;

                // Check if the class inherits from ModelReaderWriterContext
                var baseType = classSymbol.BaseType;
                bool inheritsFromContext = false;

                while (baseType != null)
                {
                    if (baseType.ToDisplayString(s_FullyQualifiedNoGlobal) == "System.ClientModel.Primitives.ModelReaderWriterContext")
                    {
                        inheritsFromContext = true;
                        break;
                    }

                    baseType = baseType.BaseType;
                }

                // Extract the type from attribute
                ISymbol? typeSymbol = null;
                if (attribute.ArgumentList?.Arguments.Count > 0)
                {
                    var firstArg = attribute.ArgumentList.Arguments[0];
                    if (firstArg.Expression is TypeOfExpressionSyntax typeOfExpr)
                    {
                        typeSymbol = semanticModel.GetTypeInfo(typeOfExpr.Type).Type;
                    }
                }

                // If it doesn't inherit from ModelReaderWriterContext, create a diagnostic
                if (!inheritsFromContext)
                {
                    var diagnostics = new List<Diagnostic>
                            {
                                Diagnostic.Create(
                                    DiagnosticDescriptors.BuildableAttributeRequiresContext,
                                    attribute.GetLocation())
                            };

                    return new AttributeInfo(null, diagnostics);
                }

                return new AttributeInfo(typeSymbol);
            }
        }

        private static ISymbol? GetGenericType(InvocationExpressionSyntax? invocation, SemanticModel semanticModel)
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

            if (symbol is INamedTypeSymbol || symbol is IArrayTypeSymbol)
                return symbol;

            return null;
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
                            if (localSymbol.Type.Name == "Type" && localSymbol.HasConstantValue)
                            {
                                var constantValue = localSymbol.ConstantValue as Type;
                                if (constantValue != null)
                                {
                                    return semanticModel.Compilation.GetTypeByMetadataName(constantValue.FullName);
                                }
                            }

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
                        if (symbol is IParameterSymbol parameterSymbol)
                            return parameterSymbol.Type;
                        if (symbol is IFieldSymbol fieldSymbol)
                            return fieldSymbol.Type;
                        if (symbol is IPropertySymbol propertySymbol)
                            return propertySymbol.Type;
                        return null;

                    case MemberAccessExpressionSyntax memberAccess:
                        var memberSymbol = semanticModel.GetSymbolInfo(memberAccess).Symbol;
                        if (memberSymbol is IFieldSymbol field)
                            return field.Type;
                        if (memberSymbol is IPropertySymbol property)
                            return property.Type;
                        return semanticModel.GetTypeInfo(memberAccess).Type;

                    default:
                        return semanticModel.GetTypeInfo(argExpression).Type ?? semanticModel.GetTypeInfo(argExpression).ConvertedType;
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
                return namedTypeSymbol.IsList() || namedTypeSymbol.IsDictionary() || namedTypeSymbol.IsReadOnlyMemory();
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
