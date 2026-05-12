// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Registers an <see cref="IPersistableModel{T}"/> proxy to be used when reading or writing a model.
    /// Multiple proxies can be registered for the same type to form a chain of responsibility.
    /// The most recently registered proxy is consulted first.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy that will be used to read or write the model. </param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
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
    /// Gets the <see cref="IPersistableModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// Returns the last registered proxy (highest priority).
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy for <typeparamref name="T"/> was found; otherwise, false. </returns>
    public bool TryGetProxy<T>([NotNullWhen(true)] out IPersistableModel<T>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<object>? chain) || chain.Count == 0)
        {
            proxy = default;
            return false;
        }

        // Last registered = highest priority
        proxy = (IPersistableModel<T>)chain[chain.Count - 1];
        return true;
    }

    /// <summary>
    /// Gets the <see cref="IJsonModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// Returns the last registered proxy (highest priority) that implements <see cref="IJsonModel{T}"/>.
    /// </summary>
    /// <param name="proxy"> The <see cref="IJsonModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy for <typeparamref name="T"/> was found; otherwise, false. </returns>
    public bool TryGetProxy<T>([NotNullWhen(true)] out IJsonModel<T>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out List<object>? chain))
        {
            proxy = default;
            return false;
        }

        // Walk chain last-to-first, return the first IJsonModel<T> match
        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IJsonModel<T> jsonResult)
            {
                proxy = jsonResult;
                return true;
            }
        }

        proxy = default;
        return false;
    }

    internal bool TryGetProxy(Type modelType, [NotNullWhen(true)] out IJsonModel<object>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(modelType, out List<object>? chain))
        {
            proxy = default;
            return false;
        }

        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IJsonModel<object> jsonResult)
            {
                proxy = jsonResult;
                return true;
            }
        }

        proxy = default;
        return false;
    }

    /// <summary>
    /// Resolves the proxy chain for the specified model type on the write path, returning the highest-priority
    /// <see cref="IPersistableModel{T}"/> proxy (last registered wins).
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model;
        }

        // Write path: last registered = highest priority
        ProxiedModel = model;
        return (IPersistableModel<T>)chain[chain.Count - 1];
    }

    /// <summary>
    /// Resolves the proxy chain for the specified model type on the write path, returning the highest-priority
    /// <see cref="IJsonModel{T}"/> proxy (last registered wins).
    /// If no proxy is registered, returns the model itself.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain))
        {
            return model;
        }

        // Write path: walk chain last-to-first, return the first IJsonModel<T> match
        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IJsonModel<T> jsonResult)
            {
                ProxiedModel = model;
                return jsonResult;
            }
        }

        return model;
    }

    /// <summary>
    /// Resolves a proxy for reading by walking the chain of responsibility. Each proxy's
    /// <see cref="IPersistableModel{T}.Create(BinaryData, ModelReaderWriterOptions)"/> is called
    /// from most recently registered to first. If a proxy returns <c>null</c>, it declines and
    /// the next proxy is tried. If all proxies decline, the model itself handles the read.
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

        // Walk chain last-to-first, call Create on each proxy. null = decline.
        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IPersistableModel<T> proxy)
            {
                ProxiedModel = model;
                T? result = proxy.Create(data, this);
                if (result is not null)
                {
                    return result;
                }
            }
        }

        // All proxies declined — model handles it
        ProxiedModel = null;
        return model.Create(data, this);
    }

    /// <summary>
    /// Resolves a proxy for reading from a <see cref="Utf8JsonReader"/> by walking the chain of responsibility.
    /// Uses the reader-snapshot technique: before each proxy attempt, the reader position is saved.
    /// If a proxy returns <c>null</c>, the reader is restored to the snapshot and the next proxy is tried.
    /// If all proxies decline, the model itself handles the read.
    /// </summary>
    /// <remarks>
    /// This technique is based on the pattern used by System.Text.Json for polymorphic deserialization,
    /// where a Utf8JsonReader (a value type) is copied to snapshot its position before a speculative read.
    /// See: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/Object/ObjectDefaultConverter.cs
    /// </remarks>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model instance (used as terminal fallback). </param>
    /// <param name="reader"> The <see cref="Utf8JsonReader"/> positioned at the start of the JSON element. </param>
    /// <returns> The deserialized instance of <typeparamref name="T"/>. </returns>
    internal T? ReadWithChain<T>(IJsonModel<T> model, ref Utf8JsonReader reader)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out List<object>? chain) || chain.Count == 0)
        {
            return model.Create(ref reader, this);
        }

        // Walk chain last-to-first. Snapshot the reader before each attempt;
        // if proxy returns null (declines), restore the reader and try the next.
        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IJsonModel<T> proxy)
            {
                ProxiedModel = model;
                Utf8JsonReader snapshot = reader;
                T? result = proxy.Create(ref reader, this);
                if (result is not null)
                {
                    return result;
                }
                // Proxy declined — restore reader position for next attempt
                reader = snapshot;
            }
        }

        // All proxies declined — model handles it
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }

    /// <summary>
    /// Resolves a proxy for reading from a <see cref="Utf8JsonReader"/> using a non-generic model reference,
    /// walking the chain of responsibility with reader-snapshot semantics.
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

        // Walk chain last-to-first with reader-snapshot for each attempt.
        for (int i = chain.Count - 1; i >= 0; i--)
        {
            if (chain[i] is IJsonModel<object> proxy)
            {
                ProxiedModel = model;
                Utf8JsonReader snapshot = reader;
                object? result = proxy.Create(ref reader, this);
                if (result is not null)
                {
                    return result;
                }
                // Proxy declined — restore reader position
                reader = snapshot;
            }
        }

        // All proxies declined — model handles it
        ProxiedModel = null;
        return model.Create(ref reader, this);
    }
}
