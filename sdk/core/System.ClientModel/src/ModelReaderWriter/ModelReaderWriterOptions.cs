// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides the client options for reading and writing models.
/// </summary>
public class ModelReaderWriterOptions
{
    private Dictionary<Type, List<ProxyEntry>>? _proxies;
    private readonly ModelReaderWriterOptions? _userOptions;
    private ModelReaderWriterContext? _context;
    private bool _isFrozen;

    private static ModelReaderWriterOptions? s_jsonOptions;
    /// <summary>
    /// Default options for writing models into JSON format.
    /// </summary>
    public static ModelReaderWriterOptions Json => s_jsonOptions ??= new ModelReaderWriterOptions("J") { _isFrozen = true };

    private static ModelReaderWriterOptions? s_xmlOptions;
    /// <summary>
    /// Default options for writing models into XML format.
    /// </summary>
    public static ModelReaderWriterOptions Xml => s_xmlOptions ??= new ModelReaderWriterOptions("X") { _isFrozen = true };

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
        _userOptions = options;
    }

    internal bool HasProxies => _proxies?.Count > 0;

    // The caller-provided options passed to conditional proxies' CanHandle. For a core-owned working
    // copy this is the original user options (preserving any derived type/config); otherwise this.
    private ModelReaderWriterOptions ProxyContextOptions => _userOptions ?? this;

    internal bool IsCoreOwned { get; }

    // Stashes the ModelReaderWriterContext in effect for the current operation on the core-owned
    // working copy, so it can be passed to conditional proxies' CanHandle during resolution.
    internal void SetProxyResolutionContext(ModelReaderWriterContext? context)
    {
        if (IsCoreOwned)
        {
            _context = context;
        }
    }

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    private void AssertNotFrozen()
    {
        if (_isFrozen)
        {
            throw new InvalidOperationException(
                "Proxies cannot be added to the default ModelReaderWriterOptions.Json or ModelReaderWriterOptions.Xml instances. " +
                "Create a new ModelReaderWriterOptions instance to register proxies.");
        }
    }

    /// <summary>
    /// Registers an <see cref="IPersistableModel{T}"/> as a proxy for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// Direct (non-conditional) proxies always match, the first registered one wins.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        Argument.AssertNotNull(proxy, nameof(proxy));
        AssertNotFrozen();
        GetOrAddProxyList(typeof(T)).Add(new DirectProxyEntry<T>(proxy));
    }

    /// <summary>
    /// Registers an <see cref="IJsonModel{T}"/> as a proxy for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// Direct (non-conditional) proxies always match, the first registered one wins.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
    public void AddProxy<T>(IJsonModel<T> proxy)
    {
        Argument.AssertNotNull(proxy, nameof(proxy));
        AssertNotFrozen();
        GetOrAddProxyList(typeof(T)).Add(new DirectProxyEntry<T>(proxy));
    }

    /// <summary>
    /// Registers a <see cref="ConditionalModelProxy{T}"/> for the specified type.
    /// Proxies are consulted in the order they were registered.
    /// When the proxy list is consulted by ModelReaderWriter, it checks <c>CanHandle</c> before delegating
    /// to the held model.
    /// </summary>
    /// <param name="proxy">The conditional proxy.</param>
    public void AddProxy<T>(ConditionalModelProxy<T> proxy)
        where T : IPersistableModel<T>
    {
        Argument.AssertNotNull(proxy, nameof(proxy));
        AssertNotFrozen();
        GetOrAddProxyList(typeof(T)).Add(new ConditionalProxyEntry<T>(proxy));
    }

    private List<ProxyEntry> GetOrAddProxyList(Type key)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(key, out List<ProxyEntry>? list))
        {
            list = [];
            _proxies[key] = list;
        }
        return list;
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
        Argument.AssertNotNull(model, nameof(model));
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleModel(model, ProxyContextOptions, _context!) && entry.GetPersistableModel<T>() is IPersistableModel<T> proxyModel)
                {
                    ProxiedModel = model;
                    return proxyModel;
                }
            }
            else if (entry.GetPersistableModel<T>() is IPersistableModel<T> directModel)
            {
                // Direct proxy (IJsonModel<T> or IPersistableModel<T>) — first wins
                ProxiedModel = model;
                return directModel;
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
        Argument.AssertNotNull(model, nameof(model));
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleModel(model, ProxyContextOptions, _context!) && entry.GetJsonModel<T>() is IJsonModel<T> jsonModel)
                {
                    ProxiedModel = model;
                    return jsonModel;
                }
            }
            else if (entry.GetJsonModel<T>() is IJsonModel<T> directJsonProxy)
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
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<ProxyEntry>? list) || list.Count == 0)
        {
            return false;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleData(data, ProxyContextOptions, _context!) && entry.GetPersistableModel<T>() is IPersistableModel<T> proxyModel)
                {
                    proxy = proxyModel;
                    return true;
                }
            }
            else if (entry.GetPersistableModel<T>() is IPersistableModel<T> directModel)
            {
                // Direct proxy — always handles
                proxy = directModel;
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
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<ProxyEntry>? list) || list.Count == 0)
        {
            return false;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                Utf8JsonReader snapshot = reader;
                if (entry.CanHandleReader(ref snapshot, ProxyContextOptions, _context!) && entry.GetJsonModel<T>() is IJsonModel<T> jsonModel)
                {
                    proxy = jsonModel;
                    return true;
                }
            }
            else if (entry.GetJsonModel<T>() is IJsonModel<T> directProxy)
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
    internal object? ReadWithChain(IPersistableModel<object> model, BinaryData data, Type? requestedType = null)
    {
        Type modelType = requestedType ?? model.GetType();
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model.Create(data, this);
        }

        ReadOnlyMemory<byte> memory = data.ToMemory();
        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleData(memory, ProxyContextOptions, _context!))
                {
                    ProxiedModel = model;
                    return entry.CreateFromData(data, this);
                }
            }
            else
            {
                // Direct proxy — always handles (result is boxed, so struct models work)
                ProxiedModel = model;
                return entry.CreateFromData(data, this);
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
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model.Create(ref reader, this);
        }

        Utf8JsonReader snapshot = reader;

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                Utf8JsonReader checkReader = snapshot;
                // Skip conditional proxies whose held model can't handle the reader path so we
                // fall through to the next proxy (or the model) instead of throwing mid-read.
                if (entry.CanHandleReader(ref checkReader, ProxyContextOptions, _context!) && entry.HasJsonModel)
                {
                    ProxiedModel = model;
                    object? result = entry.CreateFromReader(ref reader, this);
                    return result;
                }
            }
            else if (entry.HasJsonModel)
            {
                // Direct proxy with JSON support (result is boxed, so struct models work)
                ProxiedModel = model;
                object? result = entry.CreateFromReader(ref reader, this);
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
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                // Skip conditional proxies whose held model can't satisfy the JSON write
                // path so we fall through instead of throwing mid-serialization.
                if (entry.CanHandleModel(model, ProxyContextOptions, _context!) && entry.AsJsonModelOfObject() is IJsonModel<object> jsonModel)
                {
                    ProxiedModel = model;
                    return jsonModel;
                }
            }
            else if (entry.AsJsonModelOfObject() is IJsonModel<object> directJsonModel)
            {
                // Direct proxy — adapt to IJsonModel<object> (boxes, so struct models work)
                ProxiedModel = model;
                return directJsonModel;
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
