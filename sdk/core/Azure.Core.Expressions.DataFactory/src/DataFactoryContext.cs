// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Context class used by <see cref="ModelReaderWriter"/> to read and write models in an AOT compatible way.
    /// </summary>
    public class DataFactoryContext : ModelReaderWriterContext
    {
        private readonly Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> _typeBuilderFactories = new();
        private readonly ConcurrentDictionary<Type, ModelReaderWriterTypeBuilder> _typeBuilders = new();

        private static readonly Dictionary<Type, ModelReaderWriterContext> s_referenceContexts = new()
        {
            { typeof(AzureCoreContext), AzureCoreContext.Default },
        };

        private static DataFactoryContext? _dataFactoryContext;
        /// <summary> Gets the default instance </summary>
        public static DataFactoryContext Default => _dataFactoryContext ??= new();

        private DataFactoryContext()
        {
        }

        /// <inheritdoc/>
        protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DataFactoryElement<>))
            {
                builder = GetBuilder(type.GetGenericArguments()[0]);
                return true;
            }

            if (_typeBuilders.TryGetValue(type, out builder))
            {
                return true;
            }

            if (_typeBuilderFactories.TryGetValue(type, out var factory))
            {
                builder = factory();
                _typeBuilders.TryAdd(type, builder);
                return true;
            }

            foreach (var kvp in s_referenceContexts)
            {
                if (kvp.Value.TryGetTypeBuilder(type, out builder))
                {
                    _typeBuilders.TryAdd(type, builder);
                    return true;
                }
            }

            return false;
        }

        private ModelReaderWriterTypeBuilder? GetBuilder(Type type)
        {
            var genericType = typeof(DataFactoryElementTypeBuilder<>);
            var constructedType = genericType.MakeGenericType(type);
            return Activator.CreateInstance(constructedType) as ModelReaderWriterTypeBuilder;
        }

        private class DataFactoryElementTypeBuilder<T> : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(DataFactoryElement<T>);

            protected override object CreateInstance()
            {
                return new DataFactoryElement<T>(default);
            }
        }
    }
}
