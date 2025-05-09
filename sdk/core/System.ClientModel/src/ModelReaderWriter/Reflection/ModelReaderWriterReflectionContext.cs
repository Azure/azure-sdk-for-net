// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[RequiresDynamicCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
[RequiresUnreferencedCode("This method uses reflection use the overload that takes a ModelReaderWriterContext to be AOT compatible.")]
internal class ModelReaderWriterReflectionContext : ModelReaderWriterContext
{
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder>? _typeBuilders;
    private ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder> TypeBuilders => _typeBuilders ??= [];

    private static ModelReaderWriterReflectionContext? _instance;
    public static ModelReaderWriterReflectionContext Default => _instance ??= new ModelReaderWriterReflectionContext();

    private Dictionary<Type, Func<Type, ModelReaderWriterTypeBuilder>>? _typeBuilderFactories;
    private Dictionary<Type, Func<Type, ModelReaderWriterTypeBuilder>> TypeBuilderFactories => _typeBuilderFactories ??= [];

    private ModelReaderWriterReflectionContext()
    {
        TypeBuilderFactories.Add(typeof(Collection<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.Add(typeof(List<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.Add(typeof(HashSet<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.Add(typeof(ObservableCollection<>), (type) => new ReflectionCollectionBuilder(type));
        TypeBuilderFactories.Add(typeof(LinkedList<>), (type) => new ReflectionCollectionBuilder(type, "AddLast"));
        TypeBuilderFactories.Add(typeof(Queue<>), (type) => new ReflectionCollectionBuilder(type, "Enqueue"));
        TypeBuilderFactories.Add(typeof(Stack<>), (type) => new ReflectionCollectionBuilder(type, "Push"));
        TypeBuilderFactories.Add(typeof(Dictionary<,>), (type) => new ReflectionDictionaryBuilder(type));
        TypeBuilderFactories.Add(typeof(ReadOnlyCollection<>), (type) => new ReflectionReadOnlyCollectionBuilder(type));
        TypeBuilderFactories.Add(typeof(ReadOnlyDictionary<,>), (type) => new ReflectionReadOnlyDictionaryBuilder(type));
        TypeBuilderFactories.Add(typeof(ReadOnlyMemory<>), (type) => (ModelReaderWriterTypeBuilder)Activator.CreateInstance(typeof(ReflectionReadOnlyMemoryBuilder<>).MakeGenericType(type.GenericTypeArguments), type)!);
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
