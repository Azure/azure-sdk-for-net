// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
    internal class TypeSymbolKindCache
    {
        private readonly Dictionary<ITypeSymbol, TypeBuilderKind> _cache
            = new(SymbolEqualityComparer.Default);

        public TypeBuilderKind Get(ITypeSymbol typeSymbol)
        {
            if (_cache.TryGetValue(typeSymbol, out var kind))
                return kind;

            kind = AnalyzeType(typeSymbol);
            _cache[typeSymbol] = kind;
            return kind;
        }

        private static TypeBuilderKind AnalyzeType(ITypeSymbol typeSymbol)
        {
            if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
            {
                if (IsPersistable(namedTypeSymbol))
                {
                    return TypeBuilderKind.IPersistableModel;
                }

                if (IsList(namedTypeSymbol))
                {
                    return TypeBuilderKind.IList;
                }

                if (IsDictionary(namedTypeSymbol))
                {
                    return TypeBuilderKind.IDictionary;
                }

                if (IsReadOnlyMemory(namedTypeSymbol))
                {
                    return TypeBuilderKind.ReadOnlyMemory;
                }
            }
            else if (typeSymbol is IArrayTypeSymbol arraySymbol)
            {
                return arraySymbol.Rank == 1 ? TypeBuilderKind.Array : TypeBuilderKind.MultiDimensionalArray;
            }

            return TypeBuilderKind.Unknown;
        }

        private static bool IsReadOnlyMemory(INamedTypeSymbol namedSymbol)
        {
            return namedSymbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat).StartsWith("System.ReadOnlyMemory<", StringComparison.Ordinal);
        }

        private static bool IsList(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol.AllInterfaces
                .Any(i => i.OriginalDefinition.SpecialType == SpecialType.None &&
                          i.ContainingNamespace?.ToDisplayString() == "System.Collections" &&
                          i.Name == "IList") && typeSymbol.IsGenericType && typeSymbol.TypeArguments.Length == 1;
        }

        private static bool IsPersistable(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol.AllInterfaces
                .Any(i => i.OriginalDefinition.SpecialType == SpecialType.None &&
                          i.ContainingNamespace?.ToDisplayString() == "System.ClientModel.Primitives" &&
                          i.Name == "IPersistableModel" &&
                          i.IsGenericType);
        }

        private static bool IsDictionary(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol.AllInterfaces
                .Any(i => i.OriginalDefinition.SpecialType == SpecialType.None &&
                          i.ContainingNamespace?.ToDisplayString() == "System.Collections.Generic" &&
                          i.Name == "IDictionary") && typeSymbol.IsGenericType && typeSymbol.TypeArguments.Length == 2;
        }
    }
}
