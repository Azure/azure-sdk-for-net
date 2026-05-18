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
    private Dictionary<Type, List<object>>? _writeProxies;
    private Dictionary<Type, List<IDiscriminatorProxy>>? _discriminatorProxies;

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
        _writeProxies = options._writeProxies;
        _discriminatorProxies = options._discriminatorProxies;
        IsCoreOwned = true;
    }

    internal bool HasProxies => (_writeProxies?.Count > 0) || (_discriminatorProxies?.Count > 0);

    internal bool IsCoreOwned { get; }

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// Registers a write proxy for the specified type.
    /// The proxy must implement <see cref="IPersistableModel{T}"/> and will be used
    /// in place of the original model when writing. One proxy per type is matched at runtime.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> implementation that will be used to write the model. </param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        _writeProxies ??= [];

        if (!_writeProxies.TryGetValue(typeof(T), out List<object>? chain))
        {
            chain = [];
            _writeProxies[typeof(T)] = chain;
        }

        chain.Add(proxy);
    }

    /// <summary>
    /// Registers a <see cref="DiscriminatorProxy{T}"/> for the discriminator read path.
    /// Multiple discriminator proxies can be registered for the same base type.
    /// Proxies are consulted in FIFO order (first registered is consulted first).
    /// </summary>
    /// <param name="proxy"> The <see cref="DiscriminatorProxy{T}"/> proxy for discriminator-based deserialization. </param>
    public void AddDiscriminatorProxy<T>(DiscriminatorProxy<T> proxy)
    {
        _discriminatorProxies ??= [];

        if (!_discriminatorProxies.TryGetValue(typeof(T), out List<IDiscriminatorProxy>? chain))
        {
            chain = [];
            _discriminatorProxies[typeof(T)] = chain;
        }

        chain.Add(proxy);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Checks whether any write proxies or discriminator proxies are registered for the specified model type <typeparamref name="T"/>.
    /// Use this to decide whether to route deserialization of nested model properties through
    /// <see cref="ModelReaderWriter.Read{T}(BinaryData, ModelReaderWriterOptions)"/> (which performs
    /// full proxy chain resolution) or through the model's own deserialization method.
    /// </summary>
    /// <typeparam name="T">The model type to check for registered proxies.</typeparam>
    /// <returns> True if one or more proxies are registered for <typeparamref name="T"/>; otherwise, false. </returns>
    public bool HasProxy<T>()
    {
        return HasProxy(typeof(T));
    }

    /// <summary>
    /// Checks whether any write proxies or discriminator proxies are registered for the specified model type.
    /// </summary>
    /// <param name="modelType">The model type to check for registered proxies.</param>
    /// <returns> True if one or more proxies are registered for the specified type; otherwise, false. </returns>
    public bool HasProxy(Type modelType)
    {
        if (_writeProxies is not null && _writeProxies.TryGetValue(modelType, out List<object>? wChain) && wChain.Count > 0)
            return true;

        if (_discriminatorProxies is not null && _discriminatorProxies.TryGetValue(modelType, out List<IDiscriminatorProxy>? dChain) && dChain.Count > 0)
            return true;

        return false;
    }

    /// <summary>
    /// Resolves the write proxy for the specified model type.
    /// Returns the first registered proxy for the model's type.
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_writeProxies is null || !_writeProxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model;
        }

        // Write path: return the first registered proxy that is IPersistableModel<T>.
        foreach (var entry in chain)
        {
            if (entry is IPersistableModel<T> typedProxy)
            {
                ProxiedModel = model;
                return typedProxy;
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves the write proxy for the specified model type, returning the first
    /// registered proxy that also implements <see cref="IJsonModel{T}"/>.
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_writeProxies is null || !_writeProxies.TryGetValue(model.GetType(), out List<object>? chain))
        {
            return model;
        }

        // Write path: return the first registered proxy that is IJsonModel<T>.
        foreach (var entry in chain)
        {
            if (entry is IJsonModel<T> jsonProxy)
            {
                ProxiedModel = model;
                return jsonProxy;
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves a discriminator proxy for reading from <see cref="BinaryData"/>.
    /// Walks the discriminator proxy chain in FIFO order, calling
    /// <see cref="DiscriminatorProxy{T}.CanHandle(BinaryData)"/> on each.
    /// If a proxy returns true, its <see cref="IPersistableModel{T}.Create(BinaryData, ModelReaderWriterOptions)"/> is called.
    /// If all proxies decline, the model itself handles the read.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="data"> The data to read. </param>
    /// <returns> The deserialized instance of <typeparamref name="T"/>. </returns>
    internal T? ReadWithChain<T>(IPersistableModel<T> model, BinaryData data)
    {
        if (_discriminatorProxies is null || !_discriminatorProxies.TryGetValue(model.GetType(), out List<IDiscriminatorProxy>? chain) || chain.Count == 0)
        {
            return model.Create(data, this);
        }

        // Walk chain first-to-last (FIFO), check CanHandle on each discriminator proxy.
        foreach (var entry in chain)
        {
            if (entry.CanHandleData(data))
            {
                ProxiedModel = model;
                return (T?)entry.CreateFromData(data, this);
            }
        }

        // All proxies declined — model handles it
        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves a discriminator proxy for reading from a <see cref="Utf8JsonReader"/>.
    /// If a discriminator proxy is an <see cref="IJsonModel{T}"/>, its
    /// <see cref="DiscriminatorProxy{T}.CanHandle(ref Utf8JsonReader)"/> is called;
    /// otherwise <see cref="DiscriminatorProxy{T}.CanHandle(BinaryData)"/> is used.
    /// If all proxies decline, the model itself handles the read using the original reader.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="reader"> The <see cref="Utf8JsonReader"/> positioned at the start of the JSON element. </param>
    /// <returns> The deserialized instance of <typeparamref name="T"/>. </returns>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        if (_discriminatorProxies is null || !_discriminatorProxies.TryGetValue(model.GetType(), out List<IDiscriminatorProxy>? chain) || chain.Count == 0)
        {
            return model.Create(ref reader, this);
        }

        // Snapshot the reader for fallback.
        Utf8JsonReader snapshot = reader;

        // Check if any proxy in the chain is a JSON model (can use reader-based CanHandle).
        bool anyJsonProxy = false;
        foreach (var entry in chain)
        {
            if (entry.IsJsonModel)
            {
                anyJsonProxy = true;
                break;
            }
        }

        if (anyJsonProxy)
        {
            // For JSON-model proxies, try reader-based CanHandle first.
            Utf8JsonReader probeReader = snapshot;
            foreach (var entry in chain)
            {
                if (entry.IsJsonModel)
                {
                    Utf8JsonReader checkReader = probeReader;
                    if (entry.CanHandleReader(ref checkReader))
                    {
                        ProxiedModel = model;
                        Utf8JsonReader createReader = probeReader;
                        // Advance the original reader past the element
                        JsonDocument.ParseValue(ref reader);
                        return (T?)entry.CreateFromReader(ref createReader, this);
                    }
                }
                else
                {
                    // Non-JSON discriminator proxies need BinaryData
                    using var doc = JsonDocument.ParseValue(ref reader);
                    BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                    if (entry.CanHandleData(data))
                    {
                        ProxiedModel = model;
                        return (T?)entry.CreateFromData(data, this);
                    }
                    // Reset reader for next iteration — but we've consumed it, so use snapshot
                    reader = snapshot;
                }
            }
        }
        else
        {
            // All proxies are non-JSON; read into BinaryData once for CanHandle checks.
            using var doc = JsonDocument.ParseValue(ref reader);
            BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());

            foreach (var entry in chain)
            {
                if (entry.CanHandleData(data))
                {
                    ProxiedModel = model;
                    return (T?)entry.CreateFromData(data, this);
                }
            }
        }

        // All proxies declined — model handles it using the snapshot reader
        ProxiedModel = null;
        return model.Create(ref snapshot, this);
    }

    /// <summary>
    /// Resolves a discriminator proxy for reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference.
    /// Used by <see cref="JsonModelConverter"/> and <see cref="JsonCollectionReader"/>.
    /// </summary>
    /// <param name="modelType"> The runtime type of the model to look up proxies for. </param>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="reader"> The <see cref="Utf8JsonReader"/> positioned at the start of the JSON element. </param>
    /// <returns> The deserialized instance, or null if deserialization failed. </returns>
    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        if (_discriminatorProxies is null || !_discriminatorProxies.TryGetValue(modelType, out List<IDiscriminatorProxy>? chain) || chain.Count == 0)
        {
            return model.Create(ref reader, this);
        }

        // Snapshot the reader for fallback.
        Utf8JsonReader snapshot = reader;

        // Check if any proxy is a JSON model.
        bool anyJsonProxy = false;
        foreach (var entry in chain)
        {
            if (entry.IsJsonModel)
            {
                anyJsonProxy = true;
                break;
            }
        }

        if (anyJsonProxy)
        {
            Utf8JsonReader probeReader = snapshot;
            foreach (var entry in chain)
            {
                if (entry.IsJsonModel)
                {
                    Utf8JsonReader checkReader = probeReader;
                    if (entry.CanHandleReader(ref checkReader))
                    {
                        ProxiedModel = model;
                        Utf8JsonReader createReader = probeReader;
                        JsonDocument.ParseValue(ref reader);
                        return entry.CreateFromReader(ref createReader, this);
                    }
                }
                else
                {
                    using var doc = JsonDocument.ParseValue(ref reader);
                    BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                    if (entry.CanHandleData(data))
                    {
                        ProxiedModel = model;
                        return entry.CreateFromData(data, this);
                    }
                    reader = snapshot;
                }
            }
        }
        else
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());

            foreach (var entry in chain)
            {
                if (entry.CanHandleData(data))
                {
                    ProxiedModel = model;
                    return entry.CreateFromData(data, this);
                }
            }
        }

        // All proxies declined — model handles it using the snapshot reader
        ProxiedModel = null;
        return model.Create(ref snapshot, this);
    }
}
