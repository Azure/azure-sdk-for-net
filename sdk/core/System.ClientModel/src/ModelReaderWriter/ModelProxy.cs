// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal non-generic interface for proxy resolution without knowing T at compile time.
/// </summary>
internal interface IModelProxy
{
    bool CanHandleData(BinaryData data, ModelReaderWriterOptions options);
    bool CanHandleObject(object model, ModelReaderWriterOptions options);
    object CreateFromData(BinaryData data, ModelReaderWriterOptions options);
}

/// <summary>
/// Abstract base class for model proxies that participate in the chain-of-responsibility
/// pattern for reading and writing models. Override <see cref="CanHandle(T, ModelReaderWriterOptions)"/> or
/// <see cref="CanHandle(BinaryData, ModelReaderWriterOptions)"/> to selectively decline
/// handling specific instances or data.
/// </summary>
/// <typeparam name="T">The model type this proxy handles.</typeparam>
public abstract class ModelProxy<T> : IModelProxy, IPersistableModel<T>
{
    /// <summary>
    /// Determines whether this proxy can handle the specified model instance.
    /// Used on the write path for per-element proxy selection.
    /// Override to inspect the model and decline by returning false.
    /// Default returns true.
    /// </summary>
    /// <param name="model">The model instance to check.</param>
    /// <param name="options">The options for writing.</param>
    /// <returns>True if this proxy can handle the model; otherwise, false.</returns>
    public virtual bool CanHandle(T model, ModelReaderWriterOptions options) => true;

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified data.
    /// Override to inspect the data and decline by returning false.
    /// Default returns true.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="options">The options for reading.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(BinaryData data, ModelReaderWriterOptions options) => true;

    /// <inheritdoc/>
    public abstract T Create(BinaryData data, ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract BinaryData Write(ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract string GetFormatFromOptions(ModelReaderWriterOptions options);

    bool IModelProxy.CanHandleData(BinaryData data, ModelReaderWriterOptions options)
        => CanHandle(data, options);

    bool IModelProxy.CanHandleObject(object model, ModelReaderWriterOptions options)
        => model is T typed && CanHandle(typed, options);

    object IModelProxy.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Create(data, options)!;
}
