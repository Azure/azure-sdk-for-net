// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides the client options for reading and writing models.
/// </summary>
public class ModelReaderWriterOptions
{
    private Dictionary<Type, List<object>>? _proxies;

    private static ModelReaderWriterOptions? s_jsonOptions;
    /// <summary>
    /// Default options for writing models into JSON format.
    /// </summary>
    public static ModelReaderWriterOptions Json => s_jsonOptions ??= new ModelReaderWriterOptions("J");

    private static ModelReaderWriterOptions? s_xmlOptions;
    /// <summary>
    /// Default options for writing models into XML format.
    /// </summary>
    public static ModelReaderWriterOptions Xml => s_xmlOptions ??= new ModelReaderWriterOptions("X");

    /// <summary>
    /// Initializes a new instance of <see cref="ModelReaderWriterOptions"/>.
    /// </summary>
    /// <param name="format">The format to read and write models.  Pass in 'W' to use the service defined wire format.</param>
    public ModelReaderWriterOptions(string format)
    {
        Format = format;
    }

    internal ModelReaderWriterOptions(ModelReaderWriterOptions options)
    {
        Format = options.Format;
        _proxies = options._proxies;
        IsCoreOwned = true;
    }

    internal bool HasProxies => _proxies?.Count > 0;

    internal bool IsCoreOwned { get; }

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// Registers a <see cref="ModelProxy{T}"/> proxy to be used when reading or writing a model.
    /// Multiple proxies can be registered for the same type to form a chain of responsibility.
    /// Proxies are consulted in FIFO order (first registered is consulted first).
    /// </summary>
    /// <param name="proxy"> The <see cref="ModelProxy{T}"/> proxy that will be used to read or write the model. </param>
    public void AddProxy<T>(ModelProxy<T> proxy)
    {
        _proxies ??= [];

        if (!_proxies.TryGetValue(typeof(T), out List<object>? chain))
        {
            chain = [];
            _proxies[typeof(T)] = chain;
        }

        chain.Add(proxy);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Checks whether any proxies are registered for the specified model type <typeparamref name="T"/>.
    /// Use this to decide whether to route deserialization of nested model properties through
    /// <see cref="ModelReaderWriter.Read{T}(BinaryData, ModelReaderWriterOptions)"/> (which performs
    /// full proxy chain resolution) or through the model's own deserialization method.
    /// </summary>
    /// <typeparam name="T">The model type to check for registered proxies.</typeparam>
    /// <returns> True if one or more proxies are registered for <typeparamref name="T"/>; otherwise, false. </returns>
    public bool HasProxy<T>()
    {
        return _proxies is not null
            && _proxies.TryGetValue(typeof(T), out List<object>? chain)
            && chain.Count > 0;
    }

    /// <summary>
    /// Checks whether any proxies are registered for the specified model type.
    /// </summary>
    /// <param name="modelType">The model type to check for registered proxies.</param>
    /// <returns> True if one or more proxies are registered for the specified type; otherwise, false. </returns>
    public bool HasProxy(Type modelType)
    {
        return _proxies is not null
            && _proxies.TryGetValue(modelType, out List<object>? chain)
            && chain.Count > 0;
    }

    /// <summary>
    /// Resolves the proxy chain for the specified model type on the write path, walking the chain
    /// in FIFO order (first registered is consulted first), calling <see cref="ModelProxy{T}.CanHandle(T, ModelReaderWriterOptions)"/> on each.
    /// The first proxy that can handle the model is returned.
    /// If no proxy is registered or none can handle the model, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model;
        }

        // Write path: walk chain first-to-last (FIFO), return the first that CanHandle.
        foreach (var entry in chain)
        {
            if (entry is IModelProxy proxyBase && proxyBase.CanHandleObject(model, this) && entry is IPersistableModel<T> typedProxy)
            {
                ProxiedModel = model;
                return typedProxy;
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves the proxy chain for the specified model type on the write path, walking the chain
    /// in FIFO order (first registered is consulted first), calling <see cref="ModelProxy{T}.CanHandle(T, ModelReaderWriterOptions)"/> on each
    /// proxy that also implements <see cref="IJsonModel{T}"/>.
    /// If no proxy is registered or none can handle the model, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain))
        {
            return model;
        }

        // Write path: walk chain first-to-last (FIFO), return the first IJsonModel<T> that CanHandle.
        foreach (var entry in chain)
        {
            if (entry is IModelProxy proxyBase && proxyBase.CanHandleObject(model, this) && entry is IJsonModel<T> jsonProxy)
            {
                ProxiedModel = model;
                return jsonProxy;
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves a proxy for reading by walking the chain of responsibility in FIFO order.
    /// Each proxy's <see cref="ModelProxy{T}.CanHandle(BinaryData, ModelReaderWriterOptions)"/> is called
    /// from first registered to last. If a proxy returns <c>true</c>, its
    /// <see cref="IPersistableModel{T}.Create(BinaryData, ModelReaderWriterOptions)"/> is called.
    /// If all proxies decline, the model itself handles the read.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="data"> The data to read. </param>
    /// <returns> The deserialized instance of <typeparamref name="T"/>. </returns>
    internal T? ReadWithChain<T>(IPersistableModel<T> model, BinaryData data)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model.Create(data, this);
        }

        // Walk chain first-to-last (FIFO), check CanHandle on each proxy.
        foreach (var entry in chain)
        {
            if (entry is IModelProxy proxyBase && proxyBase.CanHandleData(data, this))
            {
                ProxiedModel = model;
                return (T?)proxyBase.CreateFromData(data, this);
            }
        }

        // All proxies declined — model handles it
        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves a proxy for reading from a <see cref="Utf8JsonReader"/> by walking the chain of responsibility
    /// in FIFO order (first registered is consulted first).
    /// When proxies exist, the JSON element is read into <see cref="BinaryData"/> once for
    /// <see cref="ModelProxy{T}.CanHandle(BinaryData, ModelReaderWriterOptions)"/> checks. If a proxy handles it,
    /// <see cref="IPersistableModel{T}.Create(BinaryData, ModelReaderWriterOptions)"/> is called.
    /// If all proxies decline, the model itself handles the read using the original reader.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="reader"> The <see cref="Utf8JsonReader"/> positioned at the start of the JSON element. </param>
    /// <returns> The deserialized instance of <typeparamref name="T"/>. </returns>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model.Create(ref reader, this);
        }

        // Snapshot the reader, then read the element into BinaryData for CanHandle checks.
        Utf8JsonReader snapshot = reader;
        using var doc = JsonDocument.ParseValue(ref reader);
        BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());

        // Walk chain first-to-last (FIFO), check CanHandle with the BinaryData.
        foreach (var entry in chain)
        {
            if (entry is IModelProxy proxyBase && proxyBase.CanHandleData(data, this))
            {
                ProxiedModel = model;
                return (T?)proxyBase.CreateFromData(data, this);
            }
        }

        // All proxies declined — model handles it using the snapshot reader
        ProxiedModel = null;
        return model.Create(ref snapshot, this);
    }

    /// <summary>
    /// Resolves a proxy for reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference,
    /// walking the chain of responsibility in FIFO order with
    /// <see cref="ModelProxy{T}.CanHandle(BinaryData, ModelReaderWriterOptions)"/> semantics.
    /// Used by <see cref="JsonModelConverter"/> and <see cref="JsonCollectionReader"/>.
    /// </summary>
    /// <param name="modelType"> The runtime type of the model to look up proxies for. </param>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="reader"> The <see cref="Utf8JsonReader"/> positioned at the start of the JSON element. </param>
    /// <returns> The deserialized instance, or null if deserialization failed. </returns>
    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<object>? chain) || chain.Count == 0)
        {
            return model.Create(ref reader, this);
        }

        // Snapshot the reader, then read the element into BinaryData for CanHandle checks.
        Utf8JsonReader snapshot = reader;
        using var doc = JsonDocument.ParseValue(ref reader);
        BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());

        // Walk chain first-to-last (FIFO) with CanHandle.
        foreach (var entry in chain)
        {
            if (entry is IModelProxy proxyBase && proxyBase.CanHandleData(data, this))
            {
                ProxiedModel = model;
                return proxyBase.CreateFromData(data, this);
            }
        }

        // All proxies declined — model handles it using the snapshot reader
        ProxiedModel = null;
        return model.Create(ref snapshot, this);
    }
}
