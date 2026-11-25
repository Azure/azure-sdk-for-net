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
    private const string FrozenProxiesMessage =
        "Proxies cannot be changed on the shared ModelReaderWriterOptions.Json or ModelReaderWriterOptions.Xml instances. Create a new options instance to add proxies.";

    private ModelProxyCollection? _proxies;
    // Lookup built from _proxies on first use and discarded when the collection changes. Working copies share it.
    private Dictionary<Type, List<ProxyEntry>>? _index;
    private readonly ModelReaderWriterOptions? _userOptions;
    private List<object>? _activeWrites;
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

    internal ModelReaderWriterOptions(ModelReaderWriterOptions options) : this(options.Format)
    {
        _index = options.GetProxyIndex();
        _userOptions = options._userOptions ?? options;
    }

    internal bool HasProxies => GetProxyIndex()?.Count > 0;
    internal bool IsCoreOwned => _userOptions is not null;
    private ModelReaderWriterOptions PredicateOptions => _userOptions ?? this;

    internal void EnterWrite(object model)
    {
        _activeWrites ??= [];
        foreach (object active in _activeWrites)
        {
            if (ReferenceEquals(active, model))
            {
                throw new InvalidOperationException(
                    "A proxy cannot reenter ModelReaderWriter with an active model. Invoke the original model's writer directly for pass-through.");
            }
        }
        _activeWrites.Add(model);
    }

    internal void ExitWrite() => _activeWrites!.RemoveAt(_activeWrites.Count - 1);

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// Gets the proxies used to read and write models with these options.
    /// </summary>
    /// <remarks>
    /// A proxy derived from <see cref="ModelProxy{T}"/> is considered for any model whose type is <c>T</c> or derives
    /// from it, regardless of the static type used to read or write it. Proxies for the most derived type are
    /// consulted first, then each base class in turn; proxies for the same type are consulted in collection order.
    /// A proxy declines models and payloads it does not handle through its <c>CanHandle</c> methods. Interfaces
    /// implemented by a model are not consulted. Serializers must resolve nested model proxies and forward the
    /// received options. Add proxies before starting operations rather than changing the collection concurrently
    /// with serialization. The collection is read-only for the shared <see cref="Json"/> and <see cref="Xml"/> options.
    /// </remarks>
    public IList<ModelProxy> Proxies
    {
        get
        {
            if (_userOptions is not null)
            {
                return _userOptions.Proxies;
            }
            return _proxies ??= new ModelProxyCollection(FrozenProxiesMessage, () => _index = null, frozen: _isFrozen);
        }
    }

    private Dictionary<Type, List<ProxyEntry>>? GetProxyIndex()
    {
        if (_index is null && _proxies is { Count: > 0 } proxies)
        {
            var index = new Dictionary<Type, List<ProxyEntry>>();
            foreach (ModelProxy proxy in proxies)
            {
                ProxyEntry entry = proxy.CreateEntry();
                if (!index.TryGetValue(entry.ModelType, out List<ProxyEntry>? entries))
                {
                    entries = [];
                    index.Add(entry.ModelType, entries);
                }
                entries.Add(entry);
            }
            _index = index;
        }
        return _index;
    }

    /// <summary>
    /// Gets the original model instance currently being proxied, or null when no proxy is active.
    /// </summary>
    /// <remarks>
    /// Nested resolution can replace this value. Capture the original model before resolving children.
    /// MRW operations and independently deferred request bodies use their own working options.
    /// </remarks>
    public object? ProxiedModel { get; internal set; }

    /// <summary>
    /// Resolves a write proxy, or returns the original model if every candidate declines.
    /// </summary>
    /// <remarks>
    /// This updates <see cref="ProxiedModel"/>. Resolve each nested child and forward the received options
    /// to its writer.
    /// </remarks>
    /// <typeparam name="T">The model contract of the caller.</typeparam>
    /// <param name="model">The original model.</param>
    /// <returns>The selected proxy or original model.</returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        Argument.AssertNotNull(model, nameof(model));
        foreach (ProxyEntry entry in GetCandidates(model.GetType()))
        {
            if (entry.CanHandleModel(model, PredicateOptions))
            {
                ProxiedModel = model;
                return entry.GetPersistableModel<T>();
            }
        }
        ProxiedModel = null;
        return model;
    }

    /// <summary>
    /// Resolves a JSON write proxy, or returns the original model if every compatible candidate declines.
    /// </summary>
    /// <remarks>
    /// This updates <see cref="ProxiedModel"/>. Capture a parent's original model before resolving children.
    /// </remarks>
    /// <typeparam name="T">The model contract of the caller.</typeparam>
    /// <param name="model">The original model.</param>
    /// <returns>The selected JSON proxy or original model.</returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        Argument.AssertNotNull(model, nameof(model));
        foreach (ProxyEntry entry in GetCandidates(model.GetType()))
        {
            if (entry.HasJsonModel && entry.CanHandleModel(model, PredicateOptions))
            {
                ProxiedModel = model;
                return entry.GetJsonModel<T>()!;
            }
        }
        ProxiedModel = null;
        return model;
    }

    internal bool TryGetProxy<T>(ReadOnlyMemory<byte> data, out IPersistableModel<T>? proxy)
    {
        foreach (ProxyEntry entry in GetCandidates(typeof(T)))
        {
            if (entry.CanHandleData(data, PredicateOptions))
            {
                proxy = entry.GetPersistableModel<T>();
                return true;
            }
        }
        proxy = null;
        return false;
    }

    internal bool TryGetProxy<T>(ref Utf8JsonReader reader, out IJsonModel<T>? proxy)
    {
        foreach (ProxyEntry entry in GetCandidates(typeof(T)))
        {
            Utf8JsonReader snapshot = reader;
            if (entry.HasJsonModel && entry.CanHandleReader(ref snapshot, PredicateOptions))
            {
                proxy = entry.GetJsonModel<T>();
                return true;
            }
        }
        proxy = null;
        return false;
    }

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

    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        if (TryGetProxy<T>(ref reader, out IJsonModel<T>? proxy))
        {
            ProxiedModel = model;
            return proxy!.Create(ref reader, this);
        }
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    internal object? ReadWithChain(IPersistableModel<object> model, BinaryData data, Type requestedType)
    {
        foreach (ProxyEntry entry in GetCandidates(requestedType))
        {
            if (entry.CanHandleData(data.ToMemory(), PredicateOptions))
            {
                ProxiedModel = model;
                return ValidateResult(entry.GetPersistableModel<object>().Create(data, this), requestedType);
            }
        }
        ProxiedModel = null;
        return model.Create(data, this);
    }

    internal object? ReadWithChain(Type modelType, IJsonModel<object> model, ref Utf8JsonReader reader)
    {
        foreach (ProxyEntry entry in GetCandidates(modelType))
        {
            Utf8JsonReader snapshot = reader;
            if (entry.HasJsonModel && entry.CanHandleReader(ref snapshot, PredicateOptions))
            {
                ProxiedModel = model;
                return ValidateResult(entry.GetJsonModel<object>()!.Create(ref reader, this), modelType);
            }
        }
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    private static object? ValidateResult(object? result, Type requestedType)
    {
        if (result is not null ? !requestedType.IsInstanceOfType(result) : requestedType.IsValueType)
        {
            throw new InvalidOperationException($"The proxy returned a model that is not assignable to {requestedType.Name}.");
        }
        return result;
    }

    // Walks the model type and then each base class, so a registration for a base type applies to
    // derived models without reflection-based type discovery. Type.BaseType is preserved under trimming and NativeAOT.
    private ProxyCandidates GetCandidates(Type type) => new(GetProxyIndex(), type);

    private struct ProxyCandidates
    {
        private readonly Dictionary<Type, List<ProxyEntry>>? _proxies;
        private Type? _next;
        private List<ProxyEntry>? _entries;
        private int _index;

        internal ProxyCandidates(Dictionary<Type, List<ProxyEntry>>? proxies, Type type)
        {
            _proxies = proxies;
            _next = proxies is null ? null : type;
            _entries = null;
            _index = 0;
            Current = null!;
        }

        public readonly ProxyCandidates GetEnumerator() => this;

        public ProxyEntry Current { get; private set; }

        public bool MoveNext()
        {
            while (true)
            {
                if (_entries is not null && _index < _entries.Count)
                {
                    Current = _entries[_index++];
                    return true;
                }
                if (_next is null)
                {
                    return false;
                }
                _proxies!.TryGetValue(_next, out _entries);
                _index = 0;
                _next = _next.BaseType;
            }
        }
    }
}
