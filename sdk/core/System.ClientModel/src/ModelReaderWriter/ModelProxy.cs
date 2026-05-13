// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal non-generic interface for proxy resolution without knowing T at compile time.
/// </summary>
internal interface IModelProxy
{
    bool CanHandleData(BinaryData data, ModelReaderWriterOptions options);
    bool CanHandleObject(object model);
    object CreateFromData(BinaryData data, ModelReaderWriterOptions options);
}

/// <summary>
/// Abstract base class for model proxies that participate in the chain-of-responsibility
/// pattern for reading and writing models. Proxies must implement <see cref="CanHandle(T)"/>
/// to indicate whether they can handle a given model instance on the write path.
/// </summary>
/// <typeparam name="T">The model type this proxy handles.</typeparam>
public abstract class ModelProxy<T> : IModelProxy, IPersistableModel<T>
{
    /// <summary>
    /// Determines whether this proxy can handle the specified model instance.
    /// Used on the write path for per-element proxy selection.
    /// </summary>
    /// <param name="model">The model instance to check.</param>
    /// <returns>True if this proxy can handle the model; otherwise, false.</returns>
    public abstract bool CanHandle(T model);

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified data.
    /// Override to inspect the data and decline by returning false.
    /// Default returns true.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="options">The options for reading.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(BinaryData data, ModelReaderWriterOptions options) => true;

    /// <summary>
    /// Creates a model instance from the specified binary data.
    /// </summary>
    /// <param name="data">The data to deserialize.</param>
    /// <param name="options">The options for reading.</param>
    /// <returns>The deserialized model instance.</returns>
    protected abstract T PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options);

    /// <summary>
    /// Writes the model to binary data.
    /// </summary>
    /// <param name="options">The options for writing.</param>
    /// <returns>The serialized binary data.</returns>
    protected abstract BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options);

    /// <summary>
    /// Gets the format for this model from the specified options.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <returns>The format string.</returns>
    protected abstract string PersistableModelGetFormatFromOptionsCore(ModelReaderWriterOptions options);

    T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
        => PersistableModelCreateCore(data, options);

    BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
        => PersistableModelWriteCore(options);

    string IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => PersistableModelGetFormatFromOptionsCore(options);

    // Explicit IModelProxy implementation for non-generic resolution paths.
    bool IModelProxy.CanHandleData(BinaryData data, ModelReaderWriterOptions options)
        => CanHandle(data, options);

    bool IModelProxy.CanHandleObject(object model)
        => model is T typed && CanHandle(typed);

    object IModelProxy.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => PersistableModelCreateCore(data, options)!;
}
