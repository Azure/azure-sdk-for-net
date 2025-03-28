// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration
{
    internal sealed class TypeRef : IEquatable<TypeRef>
    {
        public TypeRef(string name, string nameSpace, string assembly, IEnumerable<TypeRef>? genericArguments = default, int arrayRank = 0)
        {
            Name = name;
            Namespace = nameSpace;
            GenericArguments = genericArguments is null ? [] : genericArguments.ToList();
            Assembly = assembly;
            ArrayRank = arrayRank;
        }

        public string Name { get; }
        public string Namespace { get; }
        public IReadOnlyList<TypeRef> GenericArguments { get; }
        public string Assembly { get; }
        public int ArrayRank { get; }

        internal static TypeRef FromINamedTypeSymbol(ISymbol symbol)
        {
            if (symbol is INamedTypeSymbol namedTypeSymbol)
            {
                var typeArguments = namedTypeSymbol.TypeArguments.OfType<INamedTypeSymbol>().Select(FromINamedTypeSymbol);

                return new TypeRef(
                    symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                    symbol.ContainingNamespace.ToDisplayString(),
                    symbol.ContainingAssembly.ToDisplayString(),
                    typeArguments);
            }
            else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                var elementType = FromINamedTypeSymbol(arrayTypeSymbol.ElementType);
                return new TypeRef(
                    arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat).RemoveAsterisks(),
                    elementType.Namespace,
                    elementType.Assembly,
                    [elementType],
                    arrayTypeSymbol.Rank);
            }
            else
            {
                throw new NotSupportedException($"Unexpected type {symbol.GetType()}");
            }
        }

        public bool Equals(TypeRef? other)
            => other != null && Name == other.Name && Namespace == other.Namespace;

        public override bool Equals(object? obj)
            => obj is TypeRef other && Equals(other);

        public override int GetHashCode()
            => HashHelpers.Combine(Name.GetHashCode(), Namespace.GetHashCode());

        public override string ToString()
            => $"{Namespace}.{Name}";
    }
}
