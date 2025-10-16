﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionReadOnlyMemoryBuilder<T> : ModelReaderWriterTypeBuilder
{
    private Type _memoryType;

    public ReflectionReadOnlyMemoryBuilder(Type memoryType)
    {
        _memoryType = memoryType;
    }

    protected override Type BuilderType => typeof(List<>).MakeGenericType(typeof(T));

    protected override object CreateInstance() => Activator.CreateInstance(BuilderType)!;

    protected override Type ItemType => typeof(T);

    protected override void AddItem(object collection, object? item)
        => BuilderType.GetMethod("Add", [ItemType!])!.Invoke(collection, [ item ]);

    protected override object ConvertCollectionBuilder(object builder)
    {
        return Activator.CreateInstance(_memoryType, BuilderType.GetMethod("ToArray")!.Invoke(builder, null)!)!;
    }

    protected override IEnumerable? GetItems(object obj)
    {
        if (obj is ReadOnlyMemory<T> rom)
        {
            for (int i = 0; i < rom.Length; i++)
            {
                yield return rom.Span[i];
            }
        }
    }
}
