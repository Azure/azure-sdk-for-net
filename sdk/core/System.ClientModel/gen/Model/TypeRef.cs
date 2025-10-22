// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.SourceGeneration;

internal sealed class TypeRef : IEquatable<TypeRef>
{
    public TypeRef(
        string name,
        string nameSpace,
        string assembly,
        string fullyQualifiedName,
        TypeRef? containingContext,
        TypeRef? itemType = default,
        int arrayRank = 0,
        ObsoleteLevel obsoleteLevel = ObsoleteLevel.None,
        string? experimentalDiagnosticId = null)
    {
        Name = name;
        Namespace = nameSpace;
        ItemType = itemType;
        Assembly = assembly;
        ArrayRank = arrayRank;
        FullyQualifiedName = fullyQualifiedName;
        ObsoleteLevel = obsoleteLevel;
        ExperimentalDiagnosticId = experimentalDiagnosticId;
        ContainingContext = containingContext;
    }

    public string Name { get; }
    public string Namespace { get; }
    public TypeRef? ItemType { get; }
    public string Assembly { get; }
    public int ArrayRank { get; }
    public string FullyQualifiedName { get; }
    public ObsoleteLevel ObsoleteLevel { get; init; }
    public string? ExperimentalDiagnosticId { get; }
    public TypeRef? ContainingContext { get; }

    private string? _typeCaseName;
    public string TypeCaseName => _typeCaseName ??= Name.ToIdentifier(false);

    private string? _camelCaseName;
    public string CamelCaseName => _camelCaseName ??= TypeCaseName.ToCamelCase();

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
