﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresUnreferencedCode("This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionDictionaryBuilder : ModelReaderWriterTypeBuilder
{
    private Type _dictionaryType;

    public ReflectionDictionaryBuilder(Type dictionaryType)
    {
        _dictionaryType = dictionaryType;
    }

    protected override Type BuilderType => _dictionaryType;

    protected override object CreateInstance() => Activator.CreateInstance(_dictionaryType)!;

    protected override Type? ItemType => _dictionaryType.GetGenericArguments()[1];

    protected override void AddItemWithKey(object dictionary, string key,  object? item)
    {
        _dictionaryType.GetMethod("Add")!.Invoke(dictionary, [ key, item ]);
    }
}
