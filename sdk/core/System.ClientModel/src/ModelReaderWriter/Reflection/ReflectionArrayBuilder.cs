// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionArrayBuilder : ModelReaderWriterTypeBuilder
{
    private Type _arrayType;
    private Type _builderType;

    public ReflectionArrayBuilder(Type arrayType)
    {
        _arrayType = arrayType;
        _builderType = GetMultiDimensionalList(_arrayType.GetElementType()!, _arrayType.GetArrayRank());
    }

    protected override Type BuilderType => _builderType;

    private static Type GetMultiDimensionalList(Type type, int rank)
    {
        if (rank == 0)
            return type;

        return GetMultiDimensionalList(typeof(List<>).MakeGenericType(type), rank - 1);
    }

    protected override object CreateInstance() => Activator.CreateInstance(BuilderType)!;

    protected override Type ItemType => BuilderType.GenericTypeArguments[0];

    protected override void AddItem(object collection, object? item)
    {
        BuilderType.GetMethod("Add")!.Invoke(collection, [ item ]);
    }

    protected override object ConvertCollectionBuilder(object builder)
    {
        if (_arrayType.GetArrayRank() == 1)
        {
            return BuilderType.GetMethod("ToArray")!.Invoke(builder, null)!;
        }
        else
        {
            var dimensions = new List<int>();
            var current = builder;
            while (current is IList list)
            {
                dimensions.Add(list.Count);
                current = list.Count > 0 ? list[0] : null;
            }
            Array result = Array.CreateInstance(_arrayType.GetElementType()!, dimensions.ToArray());
            FillArray(builder, result, []);
            return result;
        }
    }

    private static void FillArray(object obj, Array array, int[] indices)
    {
        if (obj is IList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var nextIndices = indices.Append(i).ToArray();
                FillArray(list[i]!, array, nextIndices);
            }
        }
        else
        {
            array.SetValue(obj, indices);
        }
    }
}
