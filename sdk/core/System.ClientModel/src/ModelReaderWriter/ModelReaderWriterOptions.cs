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
    /// <param name="type"> The <see cref="Type"/> that will be proxied when asked to be read or written. </param>
    /// <param name="proxy"> The <see cref="IPersistableModel{T}"/> proxy that will be used to read or write the model. </param>
    public void AddProxy<T>(Type type, IPersistableModel<T> proxy)
    {
        if (_proxies is null)
            _proxies = new Dictionary<Type, object>();

        _proxies.Add(type, proxy);
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
    /// Gets the applicable <see cref="IPersistableModel{T}"/> interface that should be used for the given model.
    /// </summary>
    /// <param name="model"> The <see cref="IPersistableModel{T}"/> model to get the applicable interface for. </param>
    /// <returns> A proxy <see cref="IPersistableModel{T}"/> interface if registered otherwise returns the <paramref name="model"/>. </returns>
    public IPersistableModel<T> GetPersistableInterface<T>(IPersistableModel<T> model)
    {
        ProxiedModel = model;
        if (_proxies is null)
            return model;

        return _proxies.TryGetValue(model.GetType(), out var proxy) && proxy is IPersistableModel<T> proxyAsT ? proxyAsT : model;
    }

    /// <summary>
    /// Gets the applicable <see cref="IJsonModel{T}"/> interface that should be used for the given model.
    /// </summary>
    /// <param name="model"> The <see cref="IJsonModel{T}"/> model to get the applicable interface for. </param>
    /// <returns> A proxy <see cref="IJsonModel{T}"/> interface if registered otherwise returns the <paramref name="model"/>. </returns>
    public IJsonModel<T> GetJsonInterface<T>(IJsonModel<T> model)
    {
        ProxiedModel = model;
        if (_proxies is null)
            return model;

        return _proxies.TryGetValue(model.GetType(), out var proxy) && proxy is IJsonModel<T> proxyAsT ? proxyAsT : model;
    }
}
