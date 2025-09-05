// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides an interface to create objects without needing reflection.
/// </summary>
/// <remarks>
/// In most cases the implementation will be created automatically by the source generator.  In some advanced scenarios
/// the implementation may be created manually by the user see https://aka.ms/no-modelreaderwritertypebuilder-found for more details.
///
/// This class has no state and therefore the same instance can be used in multiple calls to <see cref="ModelReaderWriter"/>.
/// <see cref="ModelReaderWriterContext"/> will cache the <see cref="ModelReaderWriterTypeBuilder"/> instances for each type.
/// The state for collection building is maintained internally by <see cref="ModelReaderWriter"/> and is not needed to be maintained by the implementation.
/// The instance of the collection builder will be passed into each method that needs to modify that state such as <see cref="AddItem"/> and <see cref="AddItemWithKey"/>.
/// </remarks>
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
    /// <remarks>
    /// For collections like an array which you cannot dynamically add to
    /// this should be the type of collection that will be used to build the array such as <see cref="List{T}"/>.
    /// </remarks>
    protected abstract Type BuilderType { get; }

    /// <summary>
    /// If this builder is a collection, gets the type of the items in the collection.
    /// </summary>
    protected virtual Type? ItemType => null;

    /// <summary>
    /// Gets an <see cref="IEnumerable"/> representation of the passed in collection.
    /// </summary>
    /// <remarks>
    /// This is only needed when the collection passed into <see cref="ModelReaderWriter.Write(object, ModelReaderWriterOptions, ModelReaderWriterContext)"/>
    /// does not implement <see cref="IEnumerable"/>. In this case you must implement this method to return an <see cref="IEnumerable"/>.
    /// </remarks>
    /// <returns>An <see cref="IEnumerable"/> representation if its a collection otherwise null.</returns>
    protected virtual IEnumerable? GetItems(object collection) => null;

    /// <summary>
    /// Creates and returns a new instance of the object type that this builder represents.
    /// </summary>
    protected abstract object CreateInstance();

    /// <summary>
    /// Converts the passed in builder collection into the requested collection type.
    /// </summary>
    /// <remarks>
    /// In the case like an array which you cannot dynamically add to <see cref="CreateInstance"/> would have returned an instance of
    /// <see cref="List{T}"/> which matches the <see cref="BuilderType"/>.  This method would then convert the <see cref="List{T}"/>
    /// into an array by calling <see cref="List{T}.ToArray"/>.
    /// </remarks>
    /// <param name="collectionBuilder">The builder collection that is being transformed.</param>
    /// <returns>The requested collection format.</returns>
    protected virtual object ConvertCollectionBuilder(object collectionBuilder) => collectionBuilder;

    /// <summary>
    /// Adds an item to the passed in collection builder.
    /// </summary>
    /// <remarks>
    /// The collection builder instance that is being passed in is the instance returned from <see cref="CreateInstance"/>.
    /// The state of the collection builder is maintained internally by <see cref="ModelReaderWriter"/> and is not needed to be maintained by the implementation.
    /// </remarks>
    /// <param name="collectionBuilder">Represents the collection builder to which the item will be added.</param>
    /// <param name="item">Represents the item that will be added to the collection builder.</param>
    protected virtual void AddItem(object collectionBuilder, object? item)
        => Debug.Fail("AddItem should not be called for non-collections types.");

    /// <summary>
    /// Adds an item to the passed in collection builder under the specified key.
    /// </summary>
    /// <remarks>
    /// The collection builder instance that is being passed in is the instance returned from <see cref="CreateInstance"/>.
    /// The state of the collection builder is maintained internally by <see cref="ModelReaderWriter"/> and is not needed to be maintained by the implementation.
    /// </remarks>
    /// <param name="collectionBuilder">Represents the collection builder to which the item will be added.</param>
    /// <param name="key">Represents the key under which the item will be added.</param>
    /// <param name="item">Represents the item that will be added to the collection builder.</param>
    protected virtual void AddItemWithKey(object collectionBuilder, string key, object? item)
        => Debug.Fail("AddItemWithKey should not be called for non-dictionary collections.");
}
