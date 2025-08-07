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

    public static ITypeSymbol? GetItemSymbol(this ITypeSymbol typeSymbol, TypeSymbolKindCache cache)
    {
        switch (typeSymbol)
        {
            case INamedTypeSymbol namedTypeSymbol:
                switch (cache.Get(namedTypeSymbol))
                {
                    case TypeBuilderKind.IList:
                    case TypeBuilderKind.ReadOnlyMemory:
                        return namedTypeSymbol.TypeArguments[0];
                    case TypeBuilderKind.IDictionary:
                        return namedTypeSymbol.TypeArguments[1];
                    default:
                        return null;
                }
            case IArrayTypeSymbol arrayTypeSymbol:
                return arrayTypeSymbol.ElementType;
            default:
                return null;
        }
    }
}
