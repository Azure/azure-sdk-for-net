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
    private Dictionary<Type, List<ProxyEntry>>? _proxies;

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
    /// Proxies are consulted in FIFO order (first registered is consulted first).
    /// For writes, the first proxy is used. For reads, the first whose Create produces a result is used.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(typeof(T), out List<ProxyEntry>? list))
        {
            list = [];
            _proxies[typeof(T)] = list;
        }
        list.Add(new DirectPersistableProxyEntry<T>(proxy));
    }

    /// <summary>
    /// Registers an <see cref="IJsonModel{T}"/> as a proxy for the specified type.
    /// Proxies are consulted in FIFO order (first registered is consulted first).
    /// For writes, the first proxy is used. For reads, the first whose Create produces a result is used.
    /// </summary>
    /// <param name="proxy">The proxy implementation.</param>
    public void AddProxy<T>(IJsonModel<T> proxy)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(typeof(T), out List<ProxyEntry>? list))
        {
            list = [];
            _proxies[typeof(T)] = list;
        }
        list.Add(new DirectJsonProxyEntry<T>(proxy));
    }

    /// <summary>
    /// Registers a <see cref="ConditionalModelProxy{T}"/> for the specified type.
    /// When the proxy list is consulted, conditional proxies check <c>CanHandle</c> before delegating
    /// to their held model. Non-conditional proxies are always used (first one wins).
    /// </summary>
    /// <param name="proxy">The conditional proxy.</param>
    public void AddProxy<T>(ConditionalModelProxy<T> proxy)
    {
        _proxies ??= [];
        if (!_proxies.TryGetValue(typeof(T), out List<ProxyEntry>? list))
        {
            list = [];
            _proxies[typeof(T)] = list;
        }
        list.Add(new ConditionalProxyEntry<T>(proxy));
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Resolves the write proxy for the specified model, walking the proxy list in FIFO order.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(model)</c>; skips if false.
    /// For plain <see cref="IPersistableModel{T}"/> proxies, returns immediately (first wins).
    /// If no proxy matches, returns the model itself.
    /// </summary>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<ProxyEntry>? list) || list.Count == 0)
        {
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleModel(model))
                {
                    ProxiedModel = model;
                    return (IPersistableModel<T>)entry.GetModel();
                }
            }
            else
            {
                ProxiedModel = model;
                return (IPersistableModel<T>)entry.GetModel();
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves the write proxy for the specified model on the JSON path, walking the proxy list in FIFO order.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(model)</c>; skips if false.
    /// For plain <see cref="IJsonModel{T}"/> proxies, returns immediately (first wins).
    /// If no proxy matches, returns the model itself.
    /// </summary>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<ProxyEntry>? list) || list.Count == 0)
        {
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleModel(model) && entry.GetModel() is IJsonModel<T> jsonModel)
                {
                    ProxiedModel = model;
                    return jsonModel;
                }
            }
            else if (entry.GetModel() is IJsonModel<T> directJsonProxy)
            {
                ProxiedModel = model;
                return directJsonProxy;
            }
        }

        return model;
    }

    /// <summary>
    /// Attempts to find a proxy for reading from <see cref="BinaryData"/>, walking the proxy list in FIFO order.
    /// For <see cref="ConditionalModelProxy{T}"/>, calls <c>CanHandle(data)</c>; skips if false.
    /// For plain <see cref="IPersistableModel{T}"/> proxies, returns immediately (first wins).
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="proxy">When this method returns true, the proxy to use for deserialization.</param>
    /// <returns>True if a proxy was found; otherwise, false.</returns>
    public bool TryGetProxy<T>(BinaryData data, out IPersistableModel<T>? proxy)
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
                if (entry.CanHandleData(data))
                {
                    proxy = (IPersistableModel<T>)entry.GetModel();
                    return true;
                }
            }
            else
            {
                proxy = (IPersistableModel<T>)entry.GetModel();
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Attempts to find a proxy for reading from a <see cref="Utf8JsonReader"/>, walking the proxy list in FIFO order.
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
    public bool TryGetProxy<T>(ref Utf8JsonReader reader, out IJsonModel<T>? proxy)
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
                if (entry.CanHandleReader(ref snapshot) && entry.GetModel() is IJsonModel<T> jsonModel)
                {
                    proxy = jsonModel;
                    return true;
                }
            }
            else if (entry.GetModel() is IJsonModel<T> directProxy)
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
        if (TryGetProxy<T>(data, out IPersistableModel<T>? proxy))
        {
            ProxiedModel = model;
            return proxy!.Create(data, this);
        }

        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves reading from a <see cref="Utf8JsonReader"/> by consulting the proxy list in FIFO order.
    /// Each conditional proxy receives a snapshot of the reader. Falls back to the model itself.
    /// </summary>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        Utf8JsonReader snapshot = reader;
        if (TryGetProxy<T>(ref snapshot, out IJsonModel<T>? proxy))
        {
            ProxiedModel = model;
            Utf8JsonReader createReader = reader;
            T? result = proxy!.Create(ref createReader, this);
            JsonDocument.ParseValue(ref reader); // advance original past the element
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
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<ProxyEntry>? list) || list.Count == 0)
        {
            ProxiedModel = null;
            return model.Create(data, this);
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleData(data))
                {
                    ProxiedModel = model;
                    return entry.CreateFromData(data, this);
                }
            }
            else
            {
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
                if (entry.CanHandleReader(ref checkReader))
                {
                    ProxiedModel = model;
                    Utf8JsonReader createReader = snapshot;
                    object? result = entry.CreateFromReader(ref createReader, this);
                    JsonDocument.ParseValue(ref reader);
                    return result;
                }
            }
            else
            {
                ProxiedModel = model;
                Utf8JsonReader createReader = snapshot;
                object? result = entry.CreateFromReader(ref createReader, this);
                JsonDocument.ParseValue(ref reader);
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
            return model;
        }

        foreach (var entry in list)
        {
            if (entry.IsConditional)
            {
                if (entry.CanHandleModel(model) && entry.GetModel() is IJsonModel<object> jsonModel)
                {
                    ProxiedModel = model;
                    return jsonModel;
                }
            }
            else if (entry.HasJsonModel)
            {
                ProxiedModel = model;
                return entry.AsJsonModelOfObject(model);
            }
        }

        return model;
    }

    #region ProxyEntry internal types

    internal abstract class ProxyEntry
    {
        public abstract bool IsConditional { get; }
        public abstract bool HasJsonModel { get; }
        public abstract object GetModel();
        public abstract bool CanHandleData(BinaryData data);
        public abstract bool CanHandleReader(ref Utf8JsonReader reader);
        public abstract bool CanHandleModel(object model);
        public abstract object? CreateFromData(BinaryData data, ModelReaderWriterOptions options);
        public abstract object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
        public abstract IJsonModel<object> AsJsonModelOfObject(object originalModel);
    }

    internal sealed class DirectPersistableProxyEntry<T> : ProxyEntry
    {
        private readonly IPersistableModel<T> _proxy;

        public DirectPersistableProxyEntry(IPersistableModel<T> proxy) => _proxy = proxy;

        public override bool IsConditional => false;
        public override bool HasJsonModel => _proxy is IJsonModel<T>;
        public override object GetModel() => _proxy;
        public override bool CanHandleData(BinaryData data) => true;
        public override bool CanHandleReader(ref Utf8JsonReader reader) => true;
        public override bool CanHandleModel(object model) => true;
        public override object? CreateFromData(BinaryData data, ModelReaderWriterOptions options) => _proxy.Create(data, options);
        public override object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            if (_proxy is IJsonModel<T> jsonModel)
                return jsonModel.Create(ref reader, options);
            throw new InvalidOperationException($"Proxy for {typeof(T).Name} does not support JSON reader path.");
        }

        public override IJsonModel<object> AsJsonModelOfObject(object originalModel)
        {
            if (_proxy is IJsonModel<T>)
                return new JsonModelObjectAdapter<T>(_proxy, originalModel);
            throw new InvalidOperationException($"Proxy for {typeof(T).Name} does not implement IJsonModel.");
        }
    }

    internal sealed class DirectJsonProxyEntry<T> : ProxyEntry
    {
        private readonly IJsonModel<T> _proxy;

        public DirectJsonProxyEntry(IJsonModel<T> proxy) => _proxy = proxy;

        public override bool IsConditional => false;
        public override bool HasJsonModel => true;
        public override object GetModel() => _proxy;
        public override bool CanHandleData(BinaryData data) => true;
        public override bool CanHandleReader(ref Utf8JsonReader reader) => true;
        public override bool CanHandleModel(object model) => true;
        public override object? CreateFromData(BinaryData data, ModelReaderWriterOptions options) => ((IPersistableModel<T>)_proxy).Create(data, options);
        public override object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => _proxy.Create(ref reader, options);
        public override IJsonModel<object> AsJsonModelOfObject(object originalModel) => new JsonModelObjectAdapter<T>(_proxy, originalModel);
    }

    internal sealed class ConditionalProxyEntry<T> : ProxyEntry
    {
        private readonly ConditionalModelProxy<T> _proxy;

        public ConditionalProxyEntry(ConditionalModelProxy<T> proxy) => _proxy = proxy;

        public override bool IsConditional => true;
        public override bool HasJsonModel => _proxy.Model is IJsonModel<T>;
        public override object GetModel() => _proxy.Model;
        public override bool CanHandleData(BinaryData data) => _proxy.CanHandle(data);
        public override bool CanHandleReader(ref Utf8JsonReader reader) => _proxy.CanHandle(ref reader);
        public override bool CanHandleModel(object model) => model is T typed && _proxy.CanHandle(typed);
        public override object? CreateFromData(BinaryData data, ModelReaderWriterOptions options) => _proxy.Model.Create(data, options);
        public override object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            if (_proxy.Model is IJsonModel<T> jsonModel)
                return jsonModel.Create(ref reader, options);
            throw new InvalidOperationException($"Conditional proxy model for {typeof(T).Name} does not support JSON reader path.");
        }

        public override IJsonModel<object> AsJsonModelOfObject(object originalModel)
        {
            if (_proxy.Model is IJsonModel<T>)
                return new JsonModelObjectAdapter<T>(_proxy.Model, originalModel);
            throw new InvalidOperationException($"Conditional proxy model for {typeof(T).Name} does not implement IJsonModel.");
        }
    }

    /// <summary>
    /// Adapts an IJsonModel&lt;T&gt; to IJsonModel&lt;object&gt; for use in non-generic write paths.
    /// </summary>
    internal sealed class JsonModelObjectAdapter<T> : IJsonModel<object>
    {
        private readonly object _proxy;
        private readonly object _originalModel;

        public JsonModelObjectAdapter(object proxy, object originalModel)
        {
            _proxy = proxy;
            _originalModel = originalModel;
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

    #endregion
}
