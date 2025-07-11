// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal static class SymbolExtensions
{
    public static ITypeSymbol? GetItemSymbol(this ITypeSymbol typeSymbol)
    {
        switch (typeSymbol)
        {
            case INamedTypeSymbol namedTypeSymbol:
                switch (TypeSymbolKindCache.GetStatic(namedTypeSymbol))
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
