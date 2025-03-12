// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal class CollectionWrapper
{
    private readonly Func<object> _createBuilder;
    private readonly Func<object, object> _toCollection;
    private readonly Action<object, object, string?> _addItem;
    private readonly Func<object> _createElement;

    private object? _builder;

    public CollectionWrapper(
        Func<object> createBuilder,
        Func<object, object> toCollection,
        Action<object, object, string?> addItem,
        Func<object> createElement)
    {
        _createBuilder = createBuilder;
        _toCollection = toCollection;
        _addItem = addItem;
        _createElement = createElement;
    }

    public object Builder => _builder ??= _createBuilder();

    public object ToCollection() => _toCollection(Builder);

    public void AddItem(object item, string? key = null) => _addItem(Builder, item, key);

    public object CreateElement() => _createElement();
}
