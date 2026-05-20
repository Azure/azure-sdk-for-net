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
    /// Registers a proxy for the specified type. Proxies are appended to a list per type.
    /// Both reads and writes use FIFO order (first registered is consulted first).
    /// For reads, the first proxy whose Create returns non-null wins.
    /// For writes, the first proxy in the list is used.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> implementation that will be used as the proxy. </param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(typeof(T), out List<object>? list))
        {
            list = [];
            _proxies[typeof(T)] = list;
        }
        list.Add(proxy);
    }

    /// <summary>
    /// Registers a proxy for the specified type. Proxies are appended to a list per type.
    /// Both reads and writes use FIFO order (first registered is consulted first).
    /// For reads, the first proxy whose Create returns non-null wins.
    /// For writes, the first proxy in the list is used.
    /// </summary>
    /// <param name="proxy"> The <see cref="IJsonModel{T}"/> implementation that will be used as the proxy. </param>
    public void AddProxy<T>(IJsonModel<T> proxy)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(typeof(T), out List<object>? list))
        {
            list = [];
            _proxies[typeof(T)] = list;
        }
        list.Add(proxy);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Resolves the write proxy for the specified model type.
    /// Uses FIFO order (first registered proxy wins). If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? list) || list.Count == 0)
        {
            return model;
        }

        // FIFO: first in list wins for write
        foreach (var entry in list)
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
    /// Resolves the write proxy for the specified model type, returning
    /// the first registered proxy that implements <see cref="IJsonModel{T}"/>.
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? list) || list.Count == 0)
        {
            return model;
        }

        // FIFO: first in list wins for write
        foreach (var entry in list)
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
    /// Resolves reading from <see cref="BinaryData"/> by consulting the proxy list first-to-last.
    /// The first proxy whose Create returns non-null wins. Falls back to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IPersistableModel<T> model, BinaryData data)
    {
        if (_proxies is not null && _proxies.TryGetValue(model.GetType(), out List<object>? list))
        {
            foreach (var entry in list)
            {
                if (entry is IPersistableModel<T> typedProxy)
                {
                    ProxiedModel = model;
                    T? result = typedProxy.Create(data, this);
                    if (result is not null)
                    {
                        return result;
                    }
                }
            }
        }

        // Fallback: model itself
        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> by consulting the proxy list first-to-last (FIFO).
    /// Each proxy receives a snapshot of the reader that it may freely advance.
    /// The first proxy whose Create returns non-null wins. Falls back to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        if (_proxies is not null && _proxies.TryGetValue(model.GetType(), out List<object>? list))
        {
            Utf8JsonReader snapshot = reader;

            foreach (var entry in list)
            {
                if (entry is IJsonModel<T> jsonProxy)
                {
                    ProxiedModel = model;
                    Utf8JsonReader createReader = snapshot;
                    T? result = jsonProxy.Create(ref createReader, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader); // advance original past element
                        return result;
                    }
                }
                else if (entry is IPersistableModel<T> typedProxy)
                {
                    ProxiedModel = model;
                    Utf8JsonReader materializeReader = snapshot;
                    using var doc = JsonDocument.ParseValue(ref materializeReader);
                    BinaryData binaryData = BinaryData.FromString(doc.RootElement.GetRawText());
                    T? result = typedProxy.Create(binaryData, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader);
                        return result;
                    }
                }
            }
        }

        // Fallback: model itself
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference.
    /// Used by <see cref="JsonModelConverter"/> and <see cref="JsonCollectionReader"/>.
    /// </summary>
    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        if (_proxies is not null && _proxies.TryGetValue(modelType, out List<object>? list))
        {
            Utf8JsonReader snapshot = reader;

            foreach (var entry in list)
            {
                if (entry is IJsonModel<object> jsonProxy)
                {
                    ProxiedModel = model;
                    Utf8JsonReader createReader = snapshot;
                    object? result = jsonProxy.Create(ref createReader, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader);
                        return result;
                    }
                }
                else if (entry is IPersistableModel<object> typedProxy)
                {
                    ProxiedModel = model;
                    Utf8JsonReader materializeReader = snapshot;
                    using var doc = JsonDocument.ParseValue(ref materializeReader);
                    BinaryData binaryData = BinaryData.FromString(doc.RootElement.GetRawText());
                    object? result = typedProxy.Create(binaryData, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader);
                        return result;
                    }
                }
            }
        }

        // Fallback: model itself
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }
}
