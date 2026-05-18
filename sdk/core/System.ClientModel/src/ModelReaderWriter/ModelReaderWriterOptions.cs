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
    private Dictionary<Type, object>? _proxies;
    private Dictionary<Type, List<IDiscriminatorRouter>>? _routers;

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
        _routers = options._routers;
        IsCoreOwned = true;
    }

    internal bool HasProxies => (_proxies?.Count > 0) || (_routers?.Count > 0);

    internal bool IsCoreOwned { get; }

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// Registers a proxy for the specified type. The proxy is used for both write and read
    /// (as a fallback after discriminator routers). Only one proxy per type is stored;
    /// calling this again for the same type replaces the previous proxy.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> implementation that will be used as the proxy. </param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        _proxies ??= [];
        _proxies[typeof(T)] = proxy;
    }

    /// <summary>
    /// Registers a proxy for the specified type. The proxy is used for both write and read
    /// (as a fallback after discriminator routers). Only one proxy per type is stored;
    /// calling this again for the same type replaces the previous proxy.
    /// </summary>
    /// <param name="proxy"> The <see cref="IJsonModel{T}"/> implementation that will be used as the proxy. </param>
    public void AddProxy<T>(IJsonModel<T> proxy)
    {
        _proxies ??= [];
        _proxies[typeof(T)] = proxy;
    }

    /// <summary>
    /// Registers a <see cref="DiscriminatorRouter"/> for the discriminator read path.
    /// Multiple routers can be registered for the same base type.
    /// Routers are consulted in FIFO order (first registered is consulted first).
    /// </summary>
    /// <param name="router"> The <see cref="DiscriminatorRouter"/> for discriminator-based deserialization. </param>
    public void AddDiscriminatorRouter<T>(DiscriminatorRouter router)
    {
        _routers ??= [];

        if (!_routers.TryGetValue(typeof(T), out List<IDiscriminatorRouter>? chain))
        {
            chain = [];
            _routers[typeof(T)] = chain;
        }

        chain.Add(router);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Resolves the write proxy for the specified model type.
    /// Returns the registered proxy if one exists; otherwise returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out object? proxy))
        {
            return model;
        }

        if (proxy is IPersistableModel<T> typedProxy)
        {
            ProxiedModel = model;
            return typedProxy;
        }

        return model;
    }

    /// <summary>
    /// Resolves the write proxy for the specified model type, returning
    /// the registered proxy if it also implements <see cref="IJsonModel{T}"/>.
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out object? proxy))
        {
            return model;
        }

        if (proxy is IJsonModel<T> jsonProxy)
        {
            ProxiedModel = model;
            return jsonProxy;
        }

        return model;
    }

    /// <summary>
    /// Resolves reading from <see cref="BinaryData"/> using discriminator routers,
    /// then falls back to the registered proxy, then to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IPersistableModel<T> model, BinaryData data)
    {
        // Step 1: Discriminator routers
        if (_routers is not null && _routers.TryGetValue(model.GetType(), out List<IDiscriminatorRouter>? chain) && chain.Count > 0)
        {
            foreach (var entry in chain)
            {
                if (entry.CanHandleData(data))
                {
                    ProxiedModel = model;
                    return (T?)entry.CreateFromData(data, this);
                }
            }
        }

        // Step 2: Fall back to registered proxy
        if (_proxies is not null && _proxies.TryGetValue(model.GetType(), out object? proxy))
        {
            if (proxy is IPersistableModel<T> typedProxy)
            {
                ProxiedModel = model;
                return typedProxy.Create(data, this);
            }
        }

        // Step 3: Model itself
        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> using discriminator routers,
    /// then falls back to the registered proxy, then to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        // Step 1: Discriminator routers
        if (_routers is not null && _routers.TryGetValue(model.GetType(), out List<IDiscriminatorRouter>? chain) && chain.Count > 0)
        {
            Utf8JsonReader snapshot = reader;

            foreach (var entry in chain)
            {
                // Try reader-based CanHandle first
                Utf8JsonReader checkReader = snapshot;
                if (entry.CanHandleReader(ref checkReader))
                {
                    ProxiedModel = model;
                    Utf8JsonReader createReader = snapshot;
                    object? result = entry.CreateFromReader(ref createReader, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader); // advance original past element
                        return (T?)result;
                    }
                }
                else
                {
                    // Try BinaryData path: materialize and check CanHandleData
                    Utf8JsonReader materializeReader = snapshot;
                    using var doc = JsonDocument.ParseValue(ref materializeReader);
                    BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                    if (entry.CanHandleData(data))
                    {
                        ProxiedModel = model;
                        object? result = entry.CreateFromData(data, this);
                        if (result is not null)
                        {
                            JsonDocument.ParseValue(ref reader);
                            return (T?)result;
                        }
                    }
                }
            }
        }

        // Step 2: Fall back to registered proxy
        if (_proxies is not null && _proxies.TryGetValue(model.GetType(), out object? proxy))
        {
            if (proxy is IJsonModel<T> jsonProxy)
            {
                ProxiedModel = model;
                return jsonProxy.Create(ref reader, this);
            }
            else if (proxy is IPersistableModel<T> typedProxy)
            {
                ProxiedModel = model;
                using var doc = JsonDocument.ParseValue(ref reader);
                BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                return typedProxy.Create(data, this);
            }
        }

        // Step 3: Model itself
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference.
    /// Used by <see cref="JsonModelConverter"/> and <see cref="JsonCollectionReader"/>.
    /// </summary>
    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        // Step 1: Discriminator routers
        if (_routers is not null && _routers.TryGetValue(modelType, out List<IDiscriminatorRouter>? chain) && chain.Count > 0)
        {
            Utf8JsonReader snapshot = reader;

            foreach (var entry in chain)
            {
                Utf8JsonReader checkReader = snapshot;
                if (entry.CanHandleReader(ref checkReader))
                {
                    ProxiedModel = model;
                    Utf8JsonReader createReader = snapshot;
                    object? result = entry.CreateFromReader(ref createReader, this);
                    if (result is not null)
                    {
                        JsonDocument.ParseValue(ref reader);
                        return result;
                    }
                }
                else
                {
                    Utf8JsonReader materializeReader = snapshot;
                    using var doc = JsonDocument.ParseValue(ref materializeReader);
                    BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                    if (entry.CanHandleData(data))
                    {
                        ProxiedModel = model;
                        object? result = entry.CreateFromData(data, this);
                        if (result is not null)
                        {
                            JsonDocument.ParseValue(ref reader);
                            return result;
                        }
                    }
                }
            }
        }

        // Step 2: Fall back to registered proxy
        if (_proxies is not null && _proxies.TryGetValue(modelType, out object? proxy))
        {
            if (proxy is IJsonModel<object> jsonProxy)
            {
                ProxiedModel = model;
                return jsonProxy.Create(ref reader, this);
            }
            else if (proxy is IPersistableModel<object> typedProxy)
            {
                ProxiedModel = model;
                using var doc = JsonDocument.ParseValue(ref reader);
                BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
                return typedProxy.Create(data, this);
            }
        }

        // Step 3: Model itself
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }
}
