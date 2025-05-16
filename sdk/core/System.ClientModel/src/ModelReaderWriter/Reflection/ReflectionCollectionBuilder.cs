// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionCollectionBuilder : ModelReaderWriterTypeBuilder
{
    private Type _collectionType;
    private string _addMethod;

    public ReflectionCollectionBuilder(Type collectionType, string addMethod = "Add")
    {
        _collectionType = collectionType;
        _addMethod = addMethod;
    }

    protected override Type BuilderType => _collectionType;

    protected override object CreateInstance() => Activator.CreateInstance(_collectionType)!;

    protected override Type? ItemType => _collectionType.GetGenericArguments()[0];

    protected override void AddItem(object collection, object? item)
        => _collectionType.GetMethod(_addMethod, [ ItemType! ])!.Invoke(collection, [ item ]);
}
