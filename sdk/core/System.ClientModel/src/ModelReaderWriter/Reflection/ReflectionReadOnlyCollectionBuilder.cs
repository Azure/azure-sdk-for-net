// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionReadOnlyCollectionBuilder : ModelReaderWriterTypeBuilder
{
    private Type _collectionType;

    public ReflectionReadOnlyCollectionBuilder(Type collectionType)
    {
        _collectionType = collectionType;
    }

    protected override Type BuilderType => typeof(List<>).MakeGenericType(_collectionType.GenericTypeArguments);

    protected override object CreateInstance() => Activator.CreateInstance(BuilderType)!;

    protected override Type ItemType => _collectionType.GenericTypeArguments[0];

    protected override void AddItem(object collection, object? item)
        => BuilderType.GetMethod("Add", [ ItemType! ])!.Invoke(collection, [ item ]);

    protected override object ConvertCollectionBuilder(object builder) => BuilderType.GetMethod("AsReadOnly")!.Invoke(builder, null)!;
}
