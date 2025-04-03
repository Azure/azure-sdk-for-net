// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal static class SymbolExtensions
{
    public static bool InheritsFrom(this INamedTypeSymbol namedTypeSymbol, INamedTypeSymbol baseType)
    {
        while (namedTypeSymbol.BaseType is not null)
        {
            if (SymbolEqualityComparer.Default.Equals(namedTypeSymbol.BaseType, baseType))
                return true;

            namedTypeSymbol = namedTypeSymbol.BaseType;
        }
        return false;
    }

    public static TypeBuilderKind GetModelInfoKind(this ISymbol symbol)
    {
        if (symbol is INamedTypeSymbol namedTypeSymbol)
        {
            if (namedTypeSymbol.IsList())
            {
                return TypeBuilderKind.IList;
            }

            if (namedTypeSymbol.IsDictionary())
            {
                return TypeBuilderKind.IDictionary;
            }

            if (namedTypeSymbol.IsReadOnlyMemory())
            {
                return TypeBuilderKind.ReadOnlyMemory;
            }
        }
        else if (symbol is IArrayTypeSymbol arraySymbol)
        {
            return arraySymbol.Rank == 1 ? TypeBuilderKind.Array : TypeBuilderKind.MultiDimensionalArray;
        }

        return TypeBuilderKind.IPersistableModel;
    }

    internal static bool IsReadOnlyMemory(this INamedTypeSymbol namedSymbol)
    {
        return namedSymbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat).StartsWith("System.ReadOnlyMemory<", StringComparison.Ordinal);
    }

    internal static bool IsList(this INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.AllInterfaces
            .Any(i => i.OriginalDefinition.SpecialType == SpecialType.None &&
                      i.ContainingNamespace?.ToDisplayString() == "System.Collections" &&
                      i.Name == "IList");
    }

    internal static bool IsDictionary(this INamedTypeSymbol typeSymbol)
    {
        return typeSymbol.AllInterfaces
            .Any(i => i.OriginalDefinition.SpecialType == SpecialType.None &&
                      i.ContainingNamespace?.ToDisplayString() == "System.Collections.Generic" &&
                      i.Name == "IDictionary");
    }
}
