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

        public static TypeBuilderKind GetStatic(ITypeSymbol typeSymbol)
        {
            return AnalyzeType(typeSymbol);
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

        internal static bool IsReadOnlyMemory(INamedTypeSymbol namedSymbol)
        {
            return namedSymbol is
            {
                Arity: 1,
                Name: "ReadOnlyMemory",
                ContainingType: null,
                ContainingNamespace:
                {
                    Name: "System",
                    ContainingNamespace.IsGlobalNamespace: true
                }
            };
        }

        internal static bool IsList(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol is
            {
                Arity: 1,
                Name: "List",
                ContainingType: null,
                ContainingNamespace:
                {
                    Name: "Generic",
                    ContainingNamespace:
                    {
                        Name: "Collections",
                        ContainingNamespace:
                        {
                            Name: "System",
                            ContainingNamespace.IsGlobalNamespace: true
                        }
                    }
                }
            };
        }

        internal static bool IsPersistable(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol.AllInterfaces
                .Any(i => i is {
                    Arity: 1,
                    Name: "IPersistableModel",
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
                });
        }

        internal static bool IsDictionary(INamedTypeSymbol typeSymbol)
        {
            return typeSymbol is
            {
                Arity: 2,
                Name: "Dictionary",
                ContainingType: null,
                ContainingNamespace:
                {
                    Name: "Generic",
                    ContainingNamespace:
                    {
                        Name: "Collections",
                        ContainingNamespace:
                        {
                            Name: "System",
                            ContainingNamespace.IsGlobalNamespace: true
                        }
                    }
                }
            };
        }
    }
}
