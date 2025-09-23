// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ReflectionContext : ModelReaderWriterContext
{
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder>? _typeBuilders;
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder> TypeBuilders =>
        LazyInitializer.EnsureInitialized(ref _typeBuilders, static () => [])!;

    private ConcurrentDictionary<Type, Func<Type, ModelReaderWriterTypeBuilder>>? _typeBuilderFactories;
    private ConcurrentDictionary<Type, Func<Type, ModelReaderWriterTypeBuilder>> TypeBuilderFactories =>
        LazyInitializer.EnsureInitialized(ref _typeBuilderFactories, static () => [])!;

    private static ReflectionContext? _instance;
    public static ReflectionContext Default => _instance ??= new ReflectionContext();

    private ReflectionContext()
    {
        TypeBuilderFactories.TryAdd(typeof(Collection<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(List<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(HashSet<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(ObservableCollection<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(LinkedList<>), (type) => new ReflectionCollectionBuilder(type, "AddLast"));
        TypeBuilderFactories.TryAdd(typeof(Queue<>), (type) => new ReflectionCollectionBuilder(type, "Enqueue"));
        TypeBuilderFactories.TryAdd(typeof(Stack<>), (type) => new ReflectionCollectionBuilder(type, "Push"));
        TypeBuilderFactories.TryAdd(typeof(Dictionary<,>), (type) => new ReflectionDictionaryBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(ReadOnlyCollection<>), (type) => new ReflectionReadOnlyCollectionBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(ReadOnlyDictionary<,>), (type) => new ReflectionReadOnlyDictionaryBuilder(type));
        TypeBuilderFactories.TryAdd(typeof(ReadOnlyMemory<>), (type) =>
        (ModelReaderWriterTypeBuilder)Activator.CreateInstance(typeof(ReflectionReadOnlyMemoryBuilder<>).MakeGenericType(type.GenericTypeArguments), type)!);
    }

    protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
    {
        if (TypeBuilders.TryGetValue(type, out builder))
        {
            return true;
        }

        if (type.IsArray)
        {
            builder = new ReflectionArrayBuilder(type);
        }
        else if (type.IsGenericType)
        {
            var genericType = type.GetGenericTypeDefinition();
            if (TypeBuilderFactories.TryGetValue(genericType, out var factory))
            {
                builder = factory(type);
            }
            else
            {
                throw new NotSupportedException($"Unsupported type: {type.ToFriendlyName()}");
            }
        }
        else
        {
            builder = new ReflectionModelBuilder(type);
        }

        TypeBuilders.TryAdd(type, builder);
        return true;
    }
}
