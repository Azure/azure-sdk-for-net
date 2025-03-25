// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
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

        public static ModelInfoKind GetModelInfoKind(this ISymbol symbol)
        {
            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                if (namedTypeSymbol.IsList())
                {
                    return ModelInfoKind.IEnumerable;
                }

                if (namedTypeSymbol.IsDictionary())
                {
                    return ModelInfoKind.IDictionary;
                }
            }
            else if (symbol is IArrayTypeSymbol arraySymbol)
            {
                return arraySymbol.Rank == 1 ? ModelInfoKind.Array : ModelInfoKind.MultiDimensionalArray;
            }

            return ModelInfoKind.IPersistableModel;
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
}
