// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;

namespace System.ClientModel.Primitives;

internal class ReflectionContext : ModelReaderWriterContext
{
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder>? _typeBuilders;
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder> TypeBuilders =>
        LazyInitializer.EnsureInitialized(ref _typeBuilders, static () => [])!;

    protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
    {
        builder = TypeBuilders.GetOrAdd(type, static type => new ReflectionModelBuilder(type));
        return true;
    }
}
