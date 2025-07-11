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

        public static TypeRef Get(ITypeSymbol typeSymbol, bool isContext = false)
        {
            return FromTypeSymbol(typeSymbol, isContext);
        }

        public TypeRef Get(ITypeSymbol typeSymbol, TypeSymbolKindCache symbolToKindCache)
            => Get(typeSymbol, symbolToKindCache, isContext: false);

        private TypeRef Get(ITypeSymbol typeSymbol, TypeSymbolKindCache symbolToKindCache, bool isContext = false)
        {
            if (_cache.TryGetValue(typeSymbol, out var typeRef))
                return typeRef;

            typeRef = FromTypeSymbol(typeSymbol, isContext);
            _cache[typeSymbol] = typeRef;
            return typeRef;
        }

        private static TypeRef FromTypeSymbol(ITypeSymbol symbol, bool isContext)
        {
            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                var itemSymbol = namedTypeSymbol.GetItemSymbol();
                var itemType = itemSymbol is null ? null : Get(itemSymbol);

                return new TypeRef(
                    symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                    symbol.ContainingNamespace.ToDisplayString(),
                    symbol.ContainingAssembly.ToDisplayString(),
                    symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    isContext ? null : GetContextType(symbol.ContainingAssembly),
                    itemType,
                    obsoleteLevel: itemType is not null ? itemType.ObsoleteLevel : GetObsoleteLevel(symbol));
            }
            else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                var elementType = Get(arrayTypeSymbol.ElementType);

                var assembly = GetArrayAssembly(arrayTypeSymbol);

                return new TypeRef(
                    arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat).RemoveAsterisks(),
                    elementType.Namespace,
                    elementType.Assembly,
                    arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    isContext ? null : GetContextType(assembly),
                    elementType,
                    arrayTypeSymbol.Rank,
                    obsoleteLevel: elementType.ObsoleteLevel);
            }
            else
            {
                throw new NotSupportedException($"Unexpected type {symbol.GetType()}");
            }
        }

        private static IAssemblySymbol GetArrayAssembly(IArrayTypeSymbol arrayTypeSymbol)
        {
            while (arrayTypeSymbol.ElementType is IArrayTypeSymbol innerArray)
            {
                arrayTypeSymbol = innerArray;
            }

            return arrayTypeSymbol.ElementType.ContainingAssembly;
        }

        private static TypeRef? GetContextType(IAssemblySymbol assembly)
        {
            foreach (var attribute in assembly.GetAttributes())
            {
                if (attribute.AttributeClass is
                    {
                        Name: "ModelReaderWriterContextTypeAttribute",
                        ContainingType: null,
                        ContainingNamespace:
                        {
                            Name: "Primitives",
                            ContainingNamespace:
                            {
                                Name: "ClientModel",
                                ContainingNamespace:
                                {
                                    Name: "System",
                                    ContainingNamespace.IsGlobalNamespace: true
                                }
                            }
                        }
                    })
                {
                    if (attribute.ConstructorArguments.Length > 0 &&
                        attribute.ConstructorArguments[0].Value is ITypeSymbol typeSymbol)
                    {
                        return Get(typeSymbol, true);
                    }
                }
            }
            return null;
        }

        public static ObsoleteLevel GetObsoleteLevel(ITypeSymbol typeSymbol)
        {
            foreach (var attribute in typeSymbol.GetAttributes())
            {
                if (attribute.AttributeClass is
                    {
                        Name: "ObsoleteAttribute",
                        ContainingType: null,
                        ContainingNamespace:
                        {
                            Name: "System",
                            ContainingNamespace.IsGlobalNamespace: true
                        }
                    })
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
