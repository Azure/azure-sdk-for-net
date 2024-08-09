// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

/// <summary>
/// Provides the client options for reading and writing models.
/// </summary>
public class ModelReaderWriterOptions
{
    private Dictionary<Type, object>? _proxies;
    /// <summary>
    /// .
    /// </summary>
    private Dictionary<Type, object> Proxies => _proxies ??= new Dictionary<Type, object>();

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
    /// .
    /// </summary>
    public void AddProxy<T>(Type type, IPersistableModel<T> proxy)
    {
        //multiple of same type?
        Proxies.Add(type, proxy);
    }

    /// <summary>
    /// .
    /// </summary>
    public object? WriteContext { get; private set; }

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public IPersistableModel<T> GetPersistableInterface<T>(IPersistableModel<T> model)
    {
        WriteContext = model;
        return Proxies.TryGetValue(typeof(T), out var proxy) && proxy is IPersistableModel<T> proxyAsT ? proxyAsT : model;
    }

    /// <summary>
    /// .
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public IJsonModel<T> GetJsonInterface<T>(IJsonModel<T> model)
    {
        WriteContext = model;
        return Proxies.TryGetValue(typeof(T), out var proxy) && proxy is IJsonModel<T> proxyAsT ? proxyAsT : model;
    }
}
