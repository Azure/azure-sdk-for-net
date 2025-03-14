// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public abstract partial class ModelReaderWriterTypeBuilder
{
    internal class CollectionWrapper
    {
        private object? _instance;
        private ModelReaderWriterTypeBuilder _builder;
        private ModelReaderWriterContext _context;

        public CollectionWrapper(ModelReaderWriterTypeBuilder builder, ModelReaderWriterContext context)
        {
            _builder = builder;
            _context = context;

            if (builder.ItemType is null)
            {
                throw new InvalidOperationException($"If {builder.GetType().Name} is a collection it must override ModelReaderWriterTypeBuilder.ItemType");
            }
        }

        public object Builder => _instance ??= _builder.CreateInstance();

        public object ToCollection() => _builder.ToCollection(AssertType(Builder, _builder.BuilderType));

        public void AddItem(object item, string? key)
        {
            if (key is not null)
            {
                _builder.AddKeyValuePair(AssertType(Builder, _builder.BuilderType), key, AssertType(item, _builder.ItemType!));
            }
            else
            {
                _builder.AddItem(AssertType(Builder, _builder.BuilderType), AssertType(item, _builder.ItemType!));
            }
        }

        public object CreateElement()
        {
            ModelReaderWriterTypeBuilder builder = _builder;

            while (builder.IsCollection)
            {
                builder = _context.GetModelBuilder(builder.ItemType!);
            }

            return builder.CreateInstance();
        }

        private static object AssertType(object item, Type type)
        {
            var itemType = item.GetType();
            if (!itemType.Equals(type) && !type.IsAssignableFrom(itemType))
            {
                throw new InvalidOperationException($"Item is of type {item.GetType().Name}, expected {type}");
            }

            return item;
        }
    }
}
