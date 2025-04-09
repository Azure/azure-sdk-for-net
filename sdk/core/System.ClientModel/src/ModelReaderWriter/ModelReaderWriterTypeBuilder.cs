// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to create objects without needing reflection.
/// </summary>
public abstract partial class ModelReaderWriterTypeBuilder
{
    /// <summary>
    /// Creates an object based on the type information.
    /// </summary>
    internal object CreateObject()
    {
        if (IsCollection)
        {
            Debug.Assert(Context is not null);
            return new CollectionWrapper(this, Context!);
        }
        else
        {
            return CreateInstance();
        }
    }

    internal ModelReaderWriterContext? Context { get; set; }

    internal Type? GetItemType() => ItemType;

    internal IEnumerable? ToEnumerable(object obj) => GetItems(obj);

    private bool IsCollection => ItemType is not null;

    /// <summary>
    /// Gets the type this builder creates.
    /// </summary>
    protected abstract Type BuilderType { get; }

    /// <summary>
    /// If this builder is a collection, gets the type of the items in the collection.
    /// </summary>
    protected virtual Type? ItemType => null;

    /// <summary>
    /// Gets an <see cref="IEnumerable"/> representation of the object.
    /// </summary>
    /// <returns>An <see cref="IEnumerable"/> representation if its a collection otherwise null.</returns>
    protected virtual IEnumerable? GetItems(object obj) => null;

    /// <summary>
    /// Creates and returns a new instance of the object type that this builder represents.
    /// </summary>
    protected abstract object CreateInstance();

    /// <summary>
    /// Converts the input builder collection into the requested collection format.
    /// </summary>
    /// <param name="builder">The builder collection that is being transformed.</param>
    /// <returns>The requested collection format.</returns>
    protected virtual object ToCollection(object builder) => builder;

    /// <summary>
    /// Adds an item to a specified collection.
    /// </summary>
    /// <param name="collection">Represents the collection to which the item will be added.</param>
    /// <param name="item">Represents the item that will be added to the collection.</param>
    protected virtual void AddItem(object collection, object? item)
        => Debug.Fail("AddItem should not be called for non-collections types.");

    /// <summary>
    /// Adds an item to a specified dictionary under the specified key.
    /// </summary>
    /// <param name="collection">Represents the collection to which the item will be added.</param>
    /// <param name="key">Represents the key under which the item will be added.</param>
    /// <param name="item">Represents the item that will be added to the collection.</param>
    protected virtual void AddKeyValuePair(object collection, string key, object? item)
        => Debug.Fail("AddKeyValuePair should not be called for non-dictionary collections.");
}
