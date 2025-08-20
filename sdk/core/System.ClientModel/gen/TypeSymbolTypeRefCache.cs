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
                var itemType = itemSymbol is null ? null : Get(itemSymbol, symbolToKindCache);

                return new TypeRef(
                    symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                    symbol.ContainingNamespace.ToDisplayString(),
                    symbol.ContainingAssembly.ToDisplayString(),
                    symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    itemType,
                    obsoleteLevel: itemType is not null ? itemType.ObsoleteLevel : GetObsoleteLevel(symbol));
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
                    arrayTypeSymbol.Rank,
                    obsoleteLevel: elementType.ObsoleteLevel);
            }
            else
            {
                throw new NotSupportedException($"Unexpected type {symbol.GetType()}");
            }
        }

        public static ObsoleteLevel GetObsoleteLevel(ITypeSymbol typeSymbol)
        {
            foreach (var attribute in typeSymbol.GetAttributes())
            {
                if (attribute.AttributeClass?.ToDisplayString() == "System.ObsoleteAttribute")
                {
                    if (attribute.ConstructorArguments.Length == 2 &&
                                    attribute.ConstructorArguments[1].Kind == TypedConstantKind.Primitive &&
                                    attribute.ConstructorArguments[1].Value is bool isError)
                    {
                        return isError ? ObsoleteLevel.Error : ObsoleteLevel.Warning;
                    }
                    else
                    {
                        return ObsoleteLevel.Warning;
                    }
                }
            }

            return ObsoleteLevel.None;
        }
    }
}
