// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents a proxy that reads and writes models in place of the models' own serialization.
/// </summary>
/// <remarks>
/// Derive from <see cref="ModelProxy{T}"/> to implement a proxy, then register it in
/// <see cref="ModelReaderWriterOptions.Proxies"/> or <see cref="ClientPipelineOptions.ModelProxies"/>.
/// </remarks>
public abstract class ModelProxy
{
    private protected ModelProxy() { }

    internal abstract ProxyEntry CreateEntry();
}

/// <summary>
/// A proxy that reads and writes <typeparamref name="T"/> and the types derived from it in place of the
/// models' own serialization.
/// </summary>
/// <remarks>
/// A proxy is considered for <typeparamref name="T"/> and every type derived from it. By default it handles
/// every such model and payload; override the <c>CanHandle</c> methods to select the models and payloads it
/// handles. Proxy implementations must not retain per-operation state. Writers obtain the original model from
/// <see cref="ModelReaderWriterOptions.ProxiedModel"/>.
/// <para>
/// The options passed to <c>CanHandle</c> are the options supplied by the caller, so derived options types and
/// custom flags are preserved.
/// </para>
/// </remarks>
/// <typeparam name="T">The model type this proxy handles.</typeparam>
public abstract class ModelProxy<T> : ModelProxy, IPersistableModel<T>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ModelProxy{T}"/>.
    /// </summary>
    protected ModelProxy() { }

    /// <summary>
    /// Writes the original model supplied through <see cref="ModelReaderWriterOptions.ProxiedModel"/>.
    /// </summary>
    /// <param name="options">The options for the operation.</param>
    /// <returns>The serialized model.</returns>
    public abstract BinaryData Write(ModelReaderWriterOptions options);

    /// <summary>
    /// Creates a model from the supplied data.
    /// </summary>
    /// <param name="data">The serialized model.</param>
    /// <param name="options">The options for the operation.</param>
    /// <returns>The deserialized model.</returns>
    public abstract T Create(BinaryData data, ModelReaderWriterOptions options);

    /// <summary>
    /// Gets the format used by the proxy for the supplied options.
    /// </summary>
    /// <param name="options">The options for the operation.</param>
    /// <returns>The serialization format.</returns>
    public abstract string GetFormatFromOptions(ModelReaderWriterOptions options);

    /// <summary>
    /// Determines whether this proxy handles the specified model instance on the write path.
    /// Default returns true.
    /// </summary>
    /// <param name="model">The model instance to check.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <returns>True if this proxy handles the model; otherwise, false.</returns>
    public virtual bool CanHandle(T model, ModelReaderWriterOptions options) => true;

    /// <summary>
    /// Determines whether this proxy handles reading from the specified binary data.
    /// Override to inspect the data (e.g. check a discriminator field) and return false
    /// if this proxy should not handle deserialization.
    /// Default returns true.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <returns>True if this proxy handles the data; otherwise, false.</returns>
    public virtual bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options) => true;

    /// <summary>
    /// Determines whether this proxy handles reading from the specified JSON reader.
    /// Override to inspect the JSON (e.g. check a discriminator property) and return false
    /// if this proxy should not handle deserialization.
    /// Default returns true.
    /// </summary>
    /// <remarks>
    /// When called by <see cref="ModelReaderWriter"/>, the reader passed to this method is a
    /// snapshot. Implementations may freely advance the reader to inspect the JSON structure.
    /// The reader position will be reset before the model's Create is called.
    /// <para>
    /// If you call this method directly outside of <see cref="ModelReaderWriter"/>, you are
    /// responsible for snapshotting the reader beforehand if you need to preserve its position.
    /// </para>
    /// </remarks>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <returns>True if this proxy handles the data; otherwise, false.</returns>
    public virtual bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => true;

    internal override ProxyEntry CreateEntry() => new ModelProxyEntry<T>(this);
}
