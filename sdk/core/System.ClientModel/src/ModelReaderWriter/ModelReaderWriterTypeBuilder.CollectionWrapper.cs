// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

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
        }

        public object Builder => _instance ??= _builder.CreateInstance();

        public object ToCollection() => _builder.ConvertCollectionBuilder(AssertType(Builder, _builder.BuilderType));

        public void AddItem(object? item, string? key)
        {
            if (item is not null)
            {
                AssertType(item, _builder.ItemType!);
            }

            if (key is not null)
            {
                _builder.AddItemWithKey(AssertType(Builder, _builder.BuilderType), key, item);
            }
            else
            {
                _builder.AddItem(AssertType(Builder, _builder.BuilderType), item);
            }
        }

        public object CreateElement()
        {
            ModelReaderWriterTypeBuilder builder = _builder;

            while (builder.IsCollection)
            {
                builder = _context.GetTypeBuilder(builder.ItemType!);
            }

            return builder.CreateInstance();
        }

        private static object AssertType(object item, Type type)
        {
            var itemType = item.GetType();
            if (!itemType.Equals(type) && !type.IsAssignableFrom(itemType))
            {
                throw new InvalidOperationException($"Item is of type {item.GetType().ToFriendlyName()}, expected {type}");
            }

            return item;
        }
    }
}
