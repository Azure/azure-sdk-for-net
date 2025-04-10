// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace System.ClientModel.SourceGeneration;

internal sealed class TypeRef : IEquatable<TypeRef>
{
    public TypeRef(string name, string nameSpace, string assembly, TypeRef? itemType = default, int arrayRank = 0, string? alias = null)
    {
        Name = name;
        Namespace = nameSpace;
        ItemType = itemType;
        Assembly = assembly;
        ArrayRank = arrayRank;
        Alias = alias;
    }

    public string Name { get; }
    public string Namespace { get; }
    public TypeRef? ItemType { get; }
    public string Assembly { get; }
    public int ArrayRank { get; }
    public string? Alias { get; }

    private string? _typeCaseName;
    public string TypeCaseName => _typeCaseName ??= Name.ToIdentifier(false);

    private string? _camelCaseName;
    public string CamelCaseName => _camelCaseName ??= TypeCaseName.ToCamelCase();

    private string? _typeCaseAlias;
    public string? TypeCaseAlias => _typeCaseAlias ??= Alias?.ToIdentifier(false);

    private string? _camelCaseAlias;
    public string? CamelCaseAlias => _camelCaseAlias ??= TypeCaseAlias?.ToCamelCase();

    internal static TypeRef FromTypeSymbol(ITypeSymbol symbol, TypeSymbolKindCache symbolToKindCache, Dictionary<ITypeSymbol, string> dupes)
    {
        dupes.TryGetValue(symbol, out string alias);
        if (symbol is INamedTypeSymbol namedTypeSymbol)
        {
            var name = symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat);
            var itemSymbol = namedTypeSymbol.GetItemSymbol(symbolToKindCache);
            TypeRef? itemTypeRef = null;
            if (itemSymbol is not null)
            {
                itemTypeRef = FromTypeSymbol(itemSymbol, symbolToKindCache, dupes);
                if (itemTypeRef.Alias is not null)
                {
                    alias = name.Replace(itemSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat), itemTypeRef.Alias);
                }
            }

            return new TypeRef(
                symbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat),
                symbol.ContainingNamespace.ToDisplayString(),
                symbol.ContainingAssembly.ToDisplayString(),
                itemSymbol is null ? null : FromTypeSymbol(itemSymbol, symbolToKindCache, dupes),
                alias: alias);
        }
        else if (symbol is IArrayTypeSymbol arrayTypeSymbol)
        {
            var name = arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat).RemoveAsterisks();
            var elementType = FromTypeSymbol(arrayTypeSymbol.ElementType, symbolToKindCache, dupes);
            if (elementType.Alias is not null)
            {
                alias = name.Replace(arrayTypeSymbol.ElementType.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat), elementType.Alias);
            }

            return new TypeRef(
                arrayTypeSymbol.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat).RemoveAsterisks(),
                elementType.Namespace,
                elementType.Assembly,
                elementType,
                arrayTypeSymbol.Rank,
                alias: alias);
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
