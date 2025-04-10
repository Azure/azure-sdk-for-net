// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal sealed class TypeRef : IEquatable<TypeRef>
{
    public TypeRef(string name, string nameSpace, string assembly, string fullyQualifiedName, TypeRef? itemType = default, int arrayRank = 0)
    {
        Name = name;
        Namespace = nameSpace;
        ItemType = itemType;
        Assembly = assembly;
        ArrayRank = arrayRank;
        FullyQualifiedName = fullyQualifiedName;
    }

    public string Name { get; }
    public string Namespace { get; }
    public TypeRef? ItemType { get; }
    public string Assembly { get; }
    public int ArrayRank { get; }
    public string FullyQualifiedName { get; }

    private string? _typeCaseName;
    public string TypeCaseName => _typeCaseName ??= Name.ToIdentifier(false);

    private string? _camelCaseName;
    public string CamelCaseName => _camelCaseName ??= TypeCaseName.ToCamelCase();

    internal static TypeRef FromTypeSymbol(ITypeSymbol symbol, TypeSymbolKindCache symbolToKindCache)
    {
        if (symbol is INamedTypeSymbol namedTypeSymbol)
        {
            var itemSymbol = namedTypeSymbol.GetItemSymbol(symbolToKindCache);

            return new TypeRef(
                symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                symbol.ContainingNamespace.ToDisplayString(),
                symbol.ContainingAssembly.ToDisplayString(),
                symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                itemSymbol is null ? null : FromTypeSymbol(itemSymbol, symbolToKindCache));
        }
        else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
        {
            var elementType = FromTypeSymbol(arrayTypeSymbol.ElementType, symbolToKindCache);

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

    internal bool IsSameAssembly(TypeRef other) => Assembly.Equals(other.Assembly, StringComparison.Ordinal);

    public bool Equals(TypeRef? other)
        => other != null && Name == other.Name && Namespace == other.Namespace;

    public override bool Equals(object? obj)
        => obj is TypeRef other && Equals(other);

    public override int GetHashCode()
        => HashHelpers.Combine(Name.GetHashCode(), Namespace.GetHashCode());

    public override string ToString()
        => $"{Namespace}.{Name}";

    internal TypeRef GetInnerItemType()
    {
        return ItemType is null ? this : ItemType.GetInnerItemType();
    }
}
