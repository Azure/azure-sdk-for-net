// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public abstract partial class ModelBuilder
{
    internal class CollectionWrapper
    {
        private object? _instance;
        private ModelBuilder _builder;

        public CollectionWrapper(ModelBuilder builder)
        {
            _builder = builder;
        }

        public object Builder => _instance ??= _builder.CreateObject();

        public object ToCollection() => _builder.ToCollection(Builder);

        public void AddItem(object item, string? key)
        {
            if (key is not null)
            {
                _builder.AddKeyValuePair(Builder, key, item);
            }
            else
            {
                _builder.AddItem(Builder, item);
            }
        }

        public object CreateElement() => _builder.CreateElementInstance();
    }
}
