// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
    /// <param name="format">The format to read and write models.</param>
    public ModelReaderWriterOptions(string format)
    {
        Format = format;
    }

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
        if (_proxies is null)
            _proxies = new Dictionary<Type, object>();

        _proxies.Add(typeof(T), proxy);
    }

    /// <summary>
    /// Gets the model that is currently being proxied.
    /// </summary>
    /// <remarks>
    /// Whenever a proxy is used for a given type, the model being proxied is set here.
    /// The value does not need to be cleared after setting it will be overwritten on the next use.
    /// </remarks>
    public object? ProxiedModel { get; private set; }

    /// <summary>
    /// Gets the <see cref="IPersistableModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy was found; otherwise, false. </returns>
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
    /// <returns> True if a proxy was found; otherwise, false. </returns>
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

    /// <summary>
    /// Gets the <see cref="IPersistableModel{T}"/> proxy for the specified <paramref name="modelType"/>.
    /// </summary>
    /// <param name="modelType"> The model type that is proxied. </param>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy was found; otherwise, false. </returns>
    public bool TryGetProxy(Type modelType, [NotNullWhen(true)] out IPersistableModel<object>? proxy)
    {
        if (_proxies is null || !_proxies.TryGetValue(modelType, out object? result))
        {
            proxy = default;
            return false;
        }

        proxy = (IPersistableModel<object>)result;
        return true;
    }

    /// <summary>
    /// Gets the <see cref="IJsonModel{T}"/> proxy for the specified <paramref name="modelType"/>.
    /// </summary>
    /// <param name="modelType"> The model type that is proxied. </param>
    /// <param name="proxy"> The <see cref="IJsonModel{T}"/> proxy if one exists. </param>
    /// <returns> True if a proxy was found; otherwise, false. </returns>
    public bool TryGetProxy(Type modelType, [NotNullWhen(true)] out IJsonModel<object>? proxy)
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
    /// <param name="proxiedModel"> The <see cref="IPersistableModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IPersistableModel{T}"/> proxy to use. </returns>
    public IPersistableModel<T> GetProxy<T>(IPersistableModel<T> proxiedModel)
    {
        if (_proxies is null || !_proxies.TryGetValue(proxiedModel.GetType(), out object? result))
        {
            return proxiedModel;
        }

        ProxiedModel = proxiedModel;
        return (IPersistableModel<T>)result;
    }

    /// <summary>
    /// Gets the <see cref="IJsonModel{T}"/> proxy for the specified <typeparamref name="T"/> model type.
    /// </summary>
    /// <param name="proxiedModel"> The <see cref="IJsonModel{T}"/> model to proxy. </param>
    /// <returns> The <see cref="IJsonModel{T}"/> proxy to use. </returns>
    public IJsonModel<T> GetProxy<T>(IJsonModel<T> proxiedModel)
    {
        if (_proxies is null || !_proxies.TryGetValue(proxiedModel.GetType(), out object? result) || result is not IJsonModel<T> jsonResult)
        {
            return proxiedModel;
        }

        ProxiedModel = proxiedModel;
        return jsonResult;
    }
}
