// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionReadOnlyDictionaryBuilder : ModelReaderWriterTypeBuilder
{
    private Type _dictionaryType;

    public ReflectionReadOnlyDictionaryBuilder(Type dictionaryType)
    {
        _dictionaryType = dictionaryType;
    }

    protected override Type BuilderType => typeof(Dictionary<,>).MakeGenericType(_dictionaryType.GenericTypeArguments);

    protected override object CreateInstance() => Activator.CreateInstance(BuilderType)!;

    protected override Type? ItemType => _dictionaryType.GetGenericArguments()[1];

    protected override void AddItemWithKey(object dictionary, string key, object? item)
    {
        var addMethod = BuilderType.GetMethod("Add", [typeof(string), ItemType!])!.Invoke(dictionary, [key, item]);
    }

    protected override object ConvertCollectionBuilder(object builder) => Activator.CreateInstance(_dictionaryType, [builder])!;
}
