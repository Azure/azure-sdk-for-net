// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal static class SymbolExtensions
{
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

    /// <summary>
    /// Checks if the given type inherits from the specified base type.
    /// </summary>
    public static bool InheritsFrom(this INamedTypeSymbol type, INamedTypeSymbol baseType)
    {
        for (var current = type.BaseType; current != null; current = current.BaseType)
        {
            if (SymbolEqualityComparer.Default.Equals(current, baseType))
            {
                return true;
            }
        }
        return false;
    }
}
