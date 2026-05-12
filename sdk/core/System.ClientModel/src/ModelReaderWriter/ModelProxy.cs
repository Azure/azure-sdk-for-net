// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Non-generic base class for model proxies. Allows non-generic chain traversal
/// in the proxy resolution pipeline.
/// </summary>
public abstract class ModelProxy
{
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
    /// Determines whether this proxy can handle the specified model instance (non-generic).
    /// </summary>
    internal abstract bool CanHandleObject(object model);

    /// <summary>
    /// Creates a model instance from the specified data (non-generic).
    /// </summary>
    internal abstract object CreateFromData(BinaryData data, ModelReaderWriterOptions options);
}

/// <summary>
/// Abstract base class for model proxies that participate in the chain-of-responsibility
/// pattern for reading and writing models. Proxies must implement <see cref="CanHandle(T)"/>
/// to indicate whether they can handle a given model instance on the write path.
/// </summary>
/// <typeparam name="T">The model type this proxy handles.</typeparam>
public abstract class ModelProxy<T> : ModelProxy, IPersistableModel<T>
{
    /// <summary>
    /// Determines whether this proxy can handle the specified model instance.
    /// Used on the write path for per-element proxy selection.
    /// </summary>
    /// <param name="model">The model instance to check.</param>
    /// <returns>True if this proxy can handle the model; otherwise, false.</returns>
    public abstract bool CanHandle(T model);

    internal sealed override bool CanHandleObject(object model)
        => model is T typed && CanHandle(typed);

    internal sealed override object CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Create(data, options)!;

    /// <inheritdoc/>
    public abstract T Create(BinaryData data, ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract BinaryData Write(ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract string GetFormatFromOptions(ModelReaderWriterOptions options);
}
