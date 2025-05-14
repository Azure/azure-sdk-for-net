// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides the client options for reading and writing models.
/// </summary>
public class ModelReaderWriterOptions
{
    private Dictionary<Type, object>? _proxies;

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

    internal bool HasProxies => _proxies is not null;

    internal bool IsCoreOwned { get; }

    /// <summary>
    /// Gets the format to read and write the model.
    /// </summary>
    public string Format { get; }

    /// <summary>
    /// Registers an <see cref="IPersistableModel{T}"/> proxy to be used when reading or writing a model.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy that will be used to read or write the model. </param>
    public void AddProxy<T>(IPersistableModel<T> proxy)
    {
        _proxies ??= [];

        _proxies.Add(typeof(T), proxy);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Gets the <see cref="IPersistableModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy for <typeparamref name="T"/> was found; otherwise, false. </returns>
    public bool TryGetProxy<T>([NotNullWhen(true)] out IPersistableModel<T>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out object? result))
        {
            proxy = default;
            return false;
        }

        proxy = (IPersistableModel<T>)result;
        return true;
    }

    /// <summary>
    /// Gets the <see cref="IJsonModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="proxy"> The <see cref="IJsonModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy for <typeparamref name="T"/> was found; otherwise, false. </returns>
    public bool TryGetProxy<T>([NotNullWhen(true)] out IJsonModel<T>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(typeof(T), out object? result) || result is not IJsonModel<T> jsonResult)
        {
            proxy = default;
            return false;
        }

        proxy = jsonResult;
        return true;
    }

    internal bool TryGetProxy(Type modelType, [NotNullWhen(true)] out IJsonModel<object>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(modelType, out object? result) || result is not IJsonModel<object> jsonResult)
        {
            proxy = default;
            return false;
        }

        proxy = jsonResult;
        return true;
    }

    /// <summary>
    /// Gets the <see cref="IPersistableModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IPersistableModel<T> ResolveProxy<T>(IPersistableModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out object? result))
        {
            return model;
        }

        ProxiedModel = model;
        return (IPersistableModel<T>)result;
    }

    /// <summary>
    /// Gets the <see cref="IJsonModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy if one was found otherwise returns <paramref name="model"/>. </returns>
    public IJsonModel<T> ResolveProxy<T>(IJsonModel<T> model)
    {
        if (_proxies is null || !_proxies.TryGetValue(model.GetType(), out object? result) || result is not IJsonModel<T> jsonResult)
        {
            return model;
        }

        ProxiedModel = model;
        return jsonResult;
    }
}
