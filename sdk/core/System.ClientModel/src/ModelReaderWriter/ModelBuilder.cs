// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to create objects without needing reflection.
/// </summary>
public abstract class ModelBuilder
{
    private bool? _isCollection;
    private bool IsCollection => _isCollection ??= AddItem is not null || CreateElementInstance is not null;

    private readonly Func<object, object> _defaultToCollection = (original) => original;

    internal object CreateObject()
    {
        if (IsCollection)
        {
            AssertFuncDefined(AddItem, nameof(AddItem));
            AssertFuncDefined(CreateElementInstance, nameof(CreateElementInstance));

            return new CollectionWrapper(CreateInstance, ToCollection, AddItem!, CreateElementInstance!);
        }
        else
        {
            return CreateInstance();
        }
    }

    private void AssertFuncDefined(object? func, string name)
    {
        if (func is null)
        {
            throw new InvalidOperationException($"{name} must be set for collections.");
        }
    }

    /// <summary>
    /// Gets an <see cref="IEnumerable"/> representation of the object.
    /// </summary>
    /// <returns>An <see cref="IEnumerable"/> representation if its a collection otherwise null.</returns>
    protected internal virtual IEnumerable? GetEnumerable(object obj) => null;

    /// <summary>
    /// Provides a factory to create an instance of the object.
    /// </summary>
    protected abstract Func<object> CreateInstance { get; }

    /// <summary>
    /// Provides a factory convert the collection builder instance to the final type.
    /// </summary>
    protected virtual Func<object, object> ToCollection => _defaultToCollection;

    /// <summary>
    /// Provides a factory to add an item to a collection.
    /// </summary>
    /// <remarks>
    /// The key parameter is used for dictionaries and is ignored for other collections.
    /// </remarks>
    protected virtual Action<object, object, string?>? AddItem => null;

    /// <summary>
    /// Provides a factory to create an instance of the innermost element type.
    /// </summary>
    /// <remarks>
    /// If the <see cref="ModelBuilder"/> is representing List&lt;list&lt;Foo&gt;&gt;
    /// then this factory should return an instance of Foo".
    /// </remarks>
    protected virtual Func<object>? CreateElementInstance => null;

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
    /// Asserts the key is not null.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <exception cref="ArgumentNullException">When key is null.</exception>
    protected static string AssertKey(string? key)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        return key;
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
