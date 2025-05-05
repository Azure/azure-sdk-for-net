// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal class ReflectionContext : ModelReaderWriterContext
{
    private Dictionary<Type, ModelReaderWriterTypeBuilder>? _typeBuilders;
    private Dictionary<Type, ModelReaderWriterTypeBuilder> TypeBuilders => _typeBuilders ??= [];

    protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
    {
        if (TypeBuilders.TryGetValue(type, out builder))
        {
            return true;
        }

        builder = new ReflectionModelBuilder(type);
        TypeBuilders[type] = builder;

        return true;
    }
}
