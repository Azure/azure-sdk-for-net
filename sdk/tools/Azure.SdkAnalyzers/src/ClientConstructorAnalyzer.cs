// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ClientConstructorAnalyzer : SymbolAnalyzerBase
    {
        private const string ClientSuffix = "Client";
        private const string ClientOptionsSuffix = "ClientOptions";
        private const string ClientsOptionsSuffix = "ClientsOptions";
        private const string AzureCoreClientOptions = "Azure.Core.ClientOptions";
        private const string SystemClientModelClientSettings = "System.ClientModel.Primitives.ClientSettings";

        public override SymbolKind[] SymbolKinds { get; } = new[] { SymbolKind.NamedType };

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            Descriptors.AZC0005,
            Descriptors.AZC0006,
            Descriptors.AZC0007,
            Descriptors.AZC0021);

        public override void Analyze(SymbolAnalysisContext context)
        {
            var type = (INamedTypeSymbol)context.Symbol;
            if (type.TypeKind != TypeKind.Class || !type.Name.EndsWith(ClientSuffix, StringComparison.Ordinal) || !IsPubliclyAccessible(type))
            {
                return;
            }

            if (!type.Constructors.Any(c => (c.DeclaredAccessibility == Accessibility.Protected || c.DeclaredAccessibility == Accessibility.Public) && c.Parameters.Length == 0))
            {
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0005, type.Locations.First()));
            }

            foreach (var constructor in type.Constructors)
            {
                if (constructor.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var lastParameter = constructor.Parameters.LastOrDefault();

                // Check if any parameter is ClientSettings - it should only be used alone
                if (constructor.Parameters.Any(IsClientSettingsParameter) && constructor.Parameters.Length > 1)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0021, constructor.Locations.First()));
                    continue;
                }

                // A client constructed from another client (a sub-client, e.g. a lease client) inherits its
                // configuration from that client, so it legitimately has no service-connection or options overload.
                if (constructor.Parameters.Any(IsClientParameter))
                {
                    continue;
                }

                if (IsClientOptionsParameter(lastParameter))
                {
                    // Allow optional options parameters
                    if (lastParameter.IsOptional)
                    {
                        continue;
                    }

                    // When there are static properties in client, there would be static constructor implicitly added
                    var nonOptionsMethod = FindMethod(
                        type.Constructors, constructor.TypeParameters, constructor.Parameters.RemoveAt(constructor.Parameters.Length - 1), true);

                    if (nonOptionsMethod == null || nonOptionsMethod.DeclaredAccessibility != Accessibility.Public)
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0006, constructor.Locations.First()));
                    }
                }
                else if (IsClientSettingsParameter(lastParameter))
                {
                    // Allow constructors ending with a ClientSettings parameter without requiring a ClientOptions overload.
                    continue;
                }
                else
                {
                    var optionsMethod = FindMethod(
                        type.Constructors, constructor.TypeParameters, constructor.Parameters, IsClientOptionsParameter);

                    if (optionsMethod == null || optionsMethod.DeclaredAccessibility != Accessibility.Public)
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0007, constructor.Locations.First()));
                    }
                }
            }
        }

        private static bool IsPubliclyAccessible(INamedTypeSymbol type)
        {
            for (INamedTypeSymbol current = type; current != null; current = current.ContainingType)
            {
                if (current.DeclaredAccessibility != Accessibility.Public)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsClientOptionsParameter(IParameterSymbol symbol)
            => symbol != null && IsClientOptionsType(symbol.Type);

        private static bool IsClientSettingsParameter(IParameterSymbol symbol)
            => symbol != null && IsClientSettingsType(symbol.Type);

        private static bool IsClientParameter(IParameterSymbol symbol)
        {
            return symbol.Type is INamedTypeSymbol named
                && named.TypeKind == TypeKind.Class
                && named.Name.EndsWith(ClientSuffix, StringComparison.Ordinal)
                && TopLevelNamespace(named) != "System";
        }

        private static string TopLevelNamespace(ITypeSymbol type)
        {
            string name = null;
            for (INamespaceSymbol ns = type.ContainingNamespace; ns != null && !ns.IsGlobalNamespace; ns = ns.ContainingNamespace)
            {
                name = ns.Name;
            }

            return name;
        }

        private static bool IsClientOptionsType(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Class || typeSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            for (ITypeSymbol baseType = typeSymbol.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.ToDisplayString() == AzureCoreClientOptions)
                {
                    return typeSymbol.Name.EndsWith(ClientOptionsSuffix, StringComparison.Ordinal) || typeSymbol.Name.EndsWith(ClientsOptionsSuffix, StringComparison.Ordinal);
                }
            }

            return false;
        }

        private static bool IsClientSettingsType(ITypeSymbol typeSymbol)
        {
            if (typeSymbol.TypeKind != TypeKind.Class || typeSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return false;
            }

            for (ITypeSymbol baseType = typeSymbol.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.ToDisplayString() == SystemClientModelClientSettings)
                {
                    return true;
                }
            }

            return false;
        }

        private static IMethodSymbol FindMethod(IEnumerable<IMethodSymbol> methodSymbols, ImmutableArray<ITypeParameterSymbol> genericParameters, ImmutableArray<IParameterSymbol> parameters, bool ignoreStatic = false)
        {
            return methodSymbols.SingleOrDefault(symbol =>
                (!ignoreStatic || !symbol.IsStatic) &&
                genericParameters.SequenceEqual(symbol.TypeParameters, ParameterEquivalenceComparer.Default) &&
                parameters.SequenceEqual(symbol.Parameters, ParameterEquivalenceComparer.Default));
        }

        private static IMethodSymbol FindMethod(IEnumerable<IMethodSymbol> methodSymbols, ImmutableArray<ITypeParameterSymbol> genericParameters, ImmutableArray<IParameterSymbol> parameters, Func<IParameterSymbol, bool> lastParameter)
        {
            return methodSymbols.SingleOrDefault(symbol =>
            {
                if (!symbol.Parameters.Any() || !genericParameters.SequenceEqual(symbol.TypeParameters, ParameterEquivalenceComparer.Default))
                {
                    return false;
                }

                var allButLast = symbol.Parameters.RemoveAt(symbol.Parameters.Length - 1);
                return allButLast.SequenceEqual(parameters, ParameterEquivalenceComparer.Default) && lastParameter(symbol.Parameters.Last());
            });
        }

        private class ParameterEquivalenceComparer : IEqualityComparer<IParameterSymbol>, IEqualityComparer<ITypeParameterSymbol>
        {
            public static ParameterEquivalenceComparer Default { get; } = new ParameterEquivalenceComparer();

            public bool Equals(IParameterSymbol x, IParameterSymbol y)
            {
                // Constructor overload equivalence is determined by parameter type, ref-kind (ref/out/in)
                // and params-ness, but NOT by parameter name (C# overload resolution ignores names).
                // Comparing names would produce false AZC0006/AZC0007 when a with-options and
                // without-options overload name the same positional parameter differently (e.g.
                // "containerName" vs "blobContainerName").
                return x.RefKind == y.RefKind && x.IsParams == y.IsParams && TypeSymbolEquals(x.Type, y.Type);
            }

            private bool TypeSymbolEquals(ITypeSymbol x, ITypeSymbol y)
            {
                switch (x)
                {
                    case INamedTypeSymbol namedX when namedX.IsGenericType:
                        var namedY = y as INamedTypeSymbol;
                        if (namedY == null || !namedY.IsGenericType)
                        {
                            return false;
                        }

                        // Compare the generic type definitions by full symbol identity (namespace,
                        // containing type, assembly) rather than metadata name + arity, which would
                        // conflate same-named generics from different namespaces/assemblies.
                        if (!SymbolEqualityComparer.Default.Equals(namedX.OriginalDefinition, namedY.OriginalDefinition) || namedX.TypeArguments.Length != namedY.TypeArguments.Length)
                        {
                            return false;
                        }

                        for (int i = 0; i < namedX.TypeArguments.Length; i++)
                        {
                            if (!TypeSymbolEquals(namedX.TypeArguments[i], namedY.TypeArguments[i]))
                            {
                                return false;
                            }
                        }

                        return true;

                    case ITypeSymbol typeSym when typeSym.TypeKind == TypeKind.TypeParameter:
                        return y.TypeKind == TypeKind.TypeParameter && x.Name.Equals(y.Name);

                    default:
                        return SymbolEqualityComparer.Default.Equals(x, y) && x.Name.Equals(y.Name);
                }
            }

            public int GetHashCode(IParameterSymbol obj)
            {
                return SymbolEqualityComparer.Default.GetHashCode(obj.Type);
            }

            public bool Equals(ITypeParameterSymbol x, ITypeParameterSymbol y)
            {
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(ITypeParameterSymbol obj)
            {
                return obj.Name.GetHashCode();
            }
        }
    }
}
