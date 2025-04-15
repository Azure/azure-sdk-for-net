// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
    internal class TypeSymbolTypeRefCache
    {
        private readonly Dictionary<ITypeSymbol, TypeRef> _cache
            = new(SymbolEqualityComparer.Default);

        public TypeRef Get(ITypeSymbol typeSymbol, TypeSymbolKindCache symbolToKindCache)
        {
            if (_cache.TryGetValue(typeSymbol, out var typeRef))
                return typeRef;

            typeRef = FromTypeSymbol(typeSymbol, symbolToKindCache);
            _cache[typeSymbol] = typeRef;
            return typeRef;
        }

        private TypeRef FromTypeSymbol(ITypeSymbol symbol, TypeSymbolKindCache symbolToKindCache)
        {
            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                var itemSymbol = namedTypeSymbol.GetItemSymbol(symbolToKindCache);

                return new TypeRef(
                    symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                    symbol.ContainingNamespace.ToDisplayString(),
                    symbol.ContainingAssembly.ToDisplayString(),
                    symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    itemSymbol is null ? null : Get(itemSymbol, symbolToKindCache));
            }
            else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                var elementType = Get(arrayTypeSymbol.ElementType, symbolToKindCache);

                return new TypeRef(
                    arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat).RemoveAsterisks(),
                    elementType.Namespace,
                    elementType.Assembly,
                    arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    elementType,
                    arrayTypeSymbol.Rank);
            }
            else
            {
                throw new NotSupportedException($"Unexpected type {symbol.GetType()}");
            }
        }
    }
}
