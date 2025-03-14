// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal class CollectionWrapper
{
    private readonly Func<object> _createBuilder;
    private readonly Func<object, object> _toCollection;
    private readonly Action<object, string, object> _addKeyValuePair;
    private readonly Action<object, object> _addItem;
    private readonly Func<object> _createElement;

    private object? _builder;

    public CollectionWrapper(
        Func<object> createBuilder,
        Func<object, object> toCollection,
        Action<object, string, object> addKeyValuePair,
        Action<object, object> addItem,
        Func<object> createElement)
    {
        _createBuilder = createBuilder;
        _toCollection = toCollection;
        _addKeyValuePair = addKeyValuePair;
        _addItem = addItem;
        _createElement = createElement;
    }

    public object Builder => _builder ??= _createBuilder();

    public object ToCollection() => _toCollection(Builder);

    public void AddItem(object item, string? key)
    {
        if (key is not null)
        {
            _addKeyValuePair(Builder, key, item);
        }
        else
        {
            _addItem(Builder, item);
        }
    }

    public object CreateElement() => _createElement();
}
