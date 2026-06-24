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
    /// Registers an <see cref="IPersistableModel{T}"/> as a proxy for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// Direct (non-conditional) proxies always match, the first registered one wins.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
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
    /// Registers an <see cref="IJsonModel{T}"/> as a proxy for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// Direct (non-conditional) proxies always match, the first registered one wins.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
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
    /// Registers a <see cref="ConditionalModelProxy{T}"/> for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// When the proxy list is consulted by ModelReaderWriter, it checks <c>CanHandle</c> before delegating
    /// to the held model.
    /// </summary>
    /// <param name="proxy">The conditional proxy.</param>
    public void AddProxy<T>(ConditionalModelProxy<T> proxy)
        where T : class
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
    /// Gets the original model instance that is currently being proxied.
    /// Set by <see cref="ResolveProxy{T}(IJsonModel{T})"/> and <see cref="ReadWithChain{T}(IPersistableModel{T}, BinaryData)"/>
    /// so that the proxy implementation can access the original model's data during serialization.
    /// Returns null when no proxy is active.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Resolves the write proxy for the specified model, walking the proxy list in the order they were registered.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(model)</c>; skips if false.
    /// For plain <see cref="IPersistableModel{T}"/> proxies, returns immediately (first wins).
    /// If no proxy matches, returns the model itself.
    /// </summary>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                if (conditional.CanHandleModel(model))
                {
                    ProxiedModel = model;
                    return (IPersistableModel<T>)conditional.GetModel();
                }
            }
            else
            {
                // Direct proxy (IJsonModel<T> or IPersistableModel<T>) — first wins
                ProxiedModel = model;
                return (IPersistableModel<T>)entry;
            }
        }

        ProxiedModel = null;
        return model;
    }

    /// <summary>
    /// Resolves the write proxy for the specified model on the JSON path, walking the proxy list in the order they were registered.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(model)</c>; skips if false.
    /// For plain <see cref="IJsonModel{T}"/> proxies, returns immediately (first wins).
    /// If no proxy matches, returns the model itself.
    /// </summary>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                if (conditional.CanHandleModel(model) && conditional.GetModel() is IJsonModel<T> jsonModel)
                {
                    ProxiedModel = model;
                    return jsonModel;
                }
            }
            else if (entry is IJsonModel<T> directJsonProxy)
            {
                ProxiedModel = model;
                return directJsonProxy;
            }
        }

        ProxiedModel = null;
        return model;
    }

    /// <summary>
    /// Attempts to find a proxy for reading from binary data, walking the proxy list in the order they were registered.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(data)</c>; skips if false.
    /// For plain <see cref="IPersistableModel{T}"/> proxies, returns immediately (first wins).
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="proxy">When this method returns true, the proxy to use for deserialization.</param>
    /// <returns>True if a proxy was found; otherwise, false.</returns>
    internal bool TryGetProxy<T>(ReadOnlyMemory<byte> data, out IPersistableModel<T>? proxy)
    {
        proxy = null;
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<object>? list) || list.Count == 0)
        {
            return false;
        }

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                if (conditional.CanHandleData(data))
                {
                    proxy = (IPersistableModel<T>)conditional.GetModel();
                    return true;
                }
            }
            else
            {
                // Direct proxy — always handles
                proxy = (IPersistableModel<T>)entry;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Attempts to find a proxy for reading from a <see cref="Utf8JsonReader"/>, walking the proxy list in the order they were registered.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(ref reader)</c> with a snapshot; skips if false.
    /// For plain <see cref="IJsonModel{T}"/> proxies, returns immediately (first wins).
    /// </summary>
    /// <remarks>
    /// Each conditional proxy receives a snapshot of the reader that it may freely advance.
    /// The original reader position is not modified by this method.
    /// </remarks>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <param name="proxy">When this method returns true, the proxy to use for deserialization.</param>
    /// <returns>True if a proxy was found; otherwise, false.</returns>
    internal bool TryGetProxy<T>(ref Utf8JsonReader reader, out IJsonModel<T>? proxy)
    {
        proxy = null;
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<object>? list) || list.Count == 0)
        {
            return false;
        }

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                Utf8JsonReader snapshot = reader;
                if (conditional.CanHandleReader(ref snapshot) && conditional.GetModel() is IJsonModel<T> jsonModel)
                {
                    proxy = jsonModel;
                    return true;
                }
            }
            else if (entry is IJsonModel<T> directProxy)
            {
                proxy = directProxy;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Resolves reading from <see cref="BinaryData"/> by consulting the proxy list in FIFO order.
    /// Falls back to the model itself if no proxy handles the request.
    /// </summary>
    internal T? ReadWithChain<T>(IPersistableModel<T> model, BinaryData data)
    {
        if (TryGetProxy<T>(data.ToMemory(), out IPersistableModel<T>? proxy))
        {
            ProxiedModel = model;
            return proxy!.Create(data, this);
        }

        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> by consulting the proxy list in the order they were registered.
    /// Each conditional proxy receives a snapshot of the reader. Falls back to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        Utf8JsonReader snapshot = reader;
        if (TryGetProxy<T>(ref snapshot, out IJsonModel<T>? proxy))
        {
            ProxiedModel = model;
            T? result = proxy!.Create(ref reader, this);
            return result;
        }

        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    /// <summary>
    /// Resolves reading from <see cref="BinaryData"/> using a non-generic model reference.
    /// Uses the runtime type of the model to look up the proxy list.
    /// </summary>
    internal object? ReadWithChain(IPersistableModel<object> model, BinaryData data)
    {
        Type modelType = model.GetType();
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<object>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model.Create(data, this);
        }

        ReadOnlyMemory<byte> memory = data.ToMemory();
        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                if (conditional.CanHandleData(memory))
                {
                    ProxiedModel = model;
                    return conditional.CreateFromData(data, this);
                }
            }
            else
            {
                // Direct proxy — use covariance to call Create
                ProxiedModel = model;
                return ((IPersistableModel<object>)entry).Create(data, this);
            }
        }

        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference.
    /// Used by <see cref="JsonModelConverter"/> and <see cref="JsonCollectionReader"/>.
    /// </summary>
    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<object>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model.Create(ref reader, this);
        }

        Utf8JsonReader snapshot = reader;

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                Utf8JsonReader checkReader = snapshot;
                // Skip conditional proxies whose held model can't handle the reader path so we
                // fall through to the next proxy (or the model) instead of throwing mid-read.
                if (conditional.CanHandleReader(ref checkReader) && conditional.HasJsonModel)
                {
                    ProxiedModel = model;
                    object? result = conditional.CreateFromReader(ref reader, this);
                    return result;
                }
            }
            else if (entry is IJsonModel<object> directProxy)
            {
                // Direct proxy — covariance lets us cast directly
                ProxiedModel = model;
                object? result = directProxy.Create(ref reader, this);
                return result;
            }
        }

        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    /// <summary>
    /// Resolves the write proxy for the specified model using a non-generic path.
    /// Used by <see cref="JsonModelConverter"/> for write operations.
    /// </summary>
    internal IJsonModel<object> ResolveProxy(IJsonModel<object> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry is IConditionalProxy conditional)
            {
                if (conditional.CanHandleModel(model))
                {
                    ProxiedModel = model;
                    if (conditional.GetModel() is IJsonModel<object> jsonModel)
                        return jsonModel;
                    return conditional.AsJsonModelOfObject();
                }
            }
            else if (entry is IJsonModel<object> directProxy)
            {
                // Direct proxy — covariance lets us use it directly
                ProxiedModel = model;
                return directProxy;
            }
        }

        ProxiedModel = null;
        return model;
    }

    /// <summary>
    /// Adapts an IJsonModel{T} to IJsonModel{object} for use in non-generic write paths.
    /// </summary>
    internal sealed class JsonModelObjectAdapter<T> : IJsonModel<object>
    {
        private readonly object _proxy;

        public JsonModelObjectAdapter(object proxy)
        {
            _proxy = proxy;
        }

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<T>)_proxy).Create(ref reader, options)!;

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<T>)_proxy).Create(data, options)!;

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<T>)_proxy).GetFormatFromOptions(options);

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<T>)_proxy).Write(writer, options);

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<T>)_proxy).Write(options);
    }
}
