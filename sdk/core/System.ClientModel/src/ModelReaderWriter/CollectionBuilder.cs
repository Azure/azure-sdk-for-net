// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to define how to construct, add items, and produce the final collection type.
/// </summary>
public abstract class CollectionBuilder
{
    /// <summary>
    /// Gets the builder instance of the collection type.
    /// </summary>
    protected internal abstract object GetBuilder();

    /// <summary>
    /// Converts the builder collection type to the final type requested.
    /// </summary>
    protected internal virtual object ToObject() => GetBuilder();

    /// <summary>
    /// Adds an item into the collection builder type.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="key">Optional key for <see cref="IDictionary"/> collections.</param>
    /// <exception cref="ArgumentException">If <paramref name="item"/> is not the expected type.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="key"/> and the collection being added to is an <see cref="IDictionary"/>.</exception>
    protected internal abstract void AddItem(object item, string? key = default);

    /// <summary>
    /// Creates an instance of an element of the inner most collection.
    /// </summary>
    protected internal abstract object? CreateElement();

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
}
