// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to create objects without needing reflection.
/// </summary>
public abstract partial class ModelBuilder
{
    internal object CreateObject()
    {
        if (IsCollection)
        {
            return new CollectionWrapper(this);
        }
        else
        {
            return CreateInstance();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the object is a collection.
    /// </summary>
    protected virtual bool IsCollection => false;

    /// <summary>
    /// Gets an <see cref="IEnumerable"/> representation of the object.
    /// </summary>
    /// <returns>An <see cref="IEnumerable"/> representation if its a collection otherwise null.</returns>
    protected internal virtual IEnumerable? GetItems(object obj) => null;

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
    protected virtual void AddItem(object collection, object item) => Debug.Fail("AddItem should not be called for non-collections types.");

    /// <summary>
    /// Adds an item to a specified dictionary under the specified key.
    /// </summary>
    /// <param name="collection">Represents the collection to which the item will be added.</param>
    /// <param name="key">Represents the key under which the item will be added.</param>
    /// <param name="item">Represents the item that will be added to the collection.</param>
    protected virtual void AddKeyValuePair(object collection, string key, object item) => Debug.Fail("AddKeyValuePair should not be called for non-dictionary collections.");

    /// <summary>
    /// Creates an instance of the inner most element.
    /// </summary>
    /// <remarks>
    /// If the <see cref="ModelBuilder"/> is representing List&lt;list&lt;Foo&gt;&gt;
    /// then this factory should return an instance of Foo".
    /// </remarks>
    protected virtual object CreateElementInstance()
    {
        Debug.Fail("CreateElementInstance should not be called for non-collection types.");
        return null!;
    }

    /// <summary>
    /// Asserts the item is the desired type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to try to cast into.</typeparam>
    /// <param name="item">The item being inserted.</param>
    /// <returns>The <paramref name="item"/> cast into the desired <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentException">When the cast to <typeparamref name="T"/> fails.</exception>
    protected static T AssertItem<T>(object item)
    {
        if (item is not T t)
        {
            throw new ArgumentException($"item must be type {typeof(T).Name}", nameof(item));
        }
        return t;
    }

    /// <summary>
    /// Asserts the collection is the expected type.
    /// </summary>
    /// <typeparam name="T">The type to try to cast into.</typeparam>
    /// <param name="collection">The collection being validated.</param>
    /// <returns>The <paramref name="collection"/> cast into the desired <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentException">When the cast to <typeparamref name="T"/> fails.</exception>
    protected static T AssertCollection<T>(object collection)
    {
        if (collection is not T t)
        {
            throw new ArgumentException($"collection must be type {typeof(T).Name}", nameof(collection));
        }
        return t;
    }
}
