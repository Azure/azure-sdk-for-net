// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Non-generic storage/dispatch wrapper for a registered proxy. Created at <c>AddProxy&lt;T&gt;</c>
/// time (where <c>T</c> is known) so the read/write paths that only have a <see cref="Type"/> can
/// dispatch without upcasting the model to <c>IPersistableModel&lt;object&gt;</c>. That keeps
/// value-type (struct) models working: results are boxed, the model interface is never
/// variance-cast to <c>object</c>.
/// </summary>
internal abstract class ProxyEntry
{
    /// <summary>True when this entry only handles the request if its <c>CanHandle</c> returns true.</summary>
    internal abstract bool IsConditional { get; }

    /// <summary>True when the held model supports the JSON (<see cref="IJsonModel{T}"/>) path.</summary>
    internal abstract bool HasJsonModel { get; }

    internal abstract bool CanHandleModel(object model, ModelReaderWriterOptions options, ModelReaderWriterContext context);

    internal abstract bool CanHandleData(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context);

    internal abstract bool CanHandleReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context);

    /// <summary>
    /// Returns the held model as <see cref="IPersistableModel{TRequested}"/> when compatible with the
    /// requested type (exact match, or <c>object</c> for reference-type models via covariance),
    /// otherwise null.
    /// </summary>
    internal abstract IPersistableModel<TRequested>? GetPersistableModel<TRequested>();

    /// <summary>
    /// Returns the held model as <see cref="IJsonModel{TRequested}"/> when compatible with the
    /// requested type (exact match, or <c>object</c> for reference-type models via covariance),
    /// otherwise null.
    /// </summary>
    internal abstract IJsonModel<TRequested>? GetJsonModel<TRequested>();

    internal abstract object? CreateFromData(BinaryData data, ModelReaderWriterOptions options);

    internal abstract object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);

    /// <summary>
    /// Returns the held model adapted to <see cref="IJsonModel{Object}"/> for the non-generic write
    /// path, or null when the held model is not an <see cref="IJsonModel{T}"/>. The adapter boxes so
    /// value-type models are supported.
    /// </summary>
    internal abstract IJsonModel<object>? AsJsonModelOfObject();
}

/// <summary>
/// A direct (unconditional) proxy entry. It always handles the registered type; the first
/// registered proxy wins.
/// </summary>
internal sealed class DirectProxyEntry<T> : ProxyEntry
{
    internal IPersistableModel<T> Model { get; }

    internal DirectProxyEntry(IPersistableModel<T> model) => Model = model;

    internal override bool IsConditional => false;

    internal override bool HasJsonModel => Model is IJsonModel<T>;

    internal override bool CanHandleModel(object model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;

    internal override bool CanHandleData(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;

    internal override bool CanHandleReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;

    internal override IPersistableModel<TRequested>? GetPersistableModel<TRequested>()
        => Model is IPersistableModel<TRequested> model ? model : null;

    internal override IJsonModel<TRequested>? GetJsonModel<TRequested>()
        => Model is IJsonModel<TRequested> model ? model : null;

    internal override object? CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Model.Create(data, options);

    internal override object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => Model is IJsonModel<T> jsonModel
            ? jsonModel.Create(ref reader, options)
            : throw new InvalidOperationException($"Proxy model for {typeof(T).Name} does not support the JSON reader path.");

    internal override IJsonModel<object>? AsJsonModelOfObject()
    {
        // Reference-type T: covariance lets us return the model directly (preserves identity).
        if (Model is IJsonModel<object> jsonObject)
        {
            return jsonObject;
        }
        // Value-type T: no variance, so adapt (box) the JSON model.
        return Model is IJsonModel<T> ? new ModelReaderWriterOptions.JsonModelObjectAdapter<T>(Model) : null;
    }
}

/// <summary>
/// A conditional proxy entry backed by a <see cref="ConditionalModelProxy{T}"/>. It handles the
/// request only when the proxy's <c>CanHandle</c> returns true; otherwise the chain falls through.
/// </summary>
internal sealed class ConditionalProxyEntry<T> : ProxyEntry
    where T : IPersistableModel<T>
{
    private readonly ConditionalModelProxy<T> _proxy;

    internal ConditionalProxyEntry(ConditionalModelProxy<T> proxy) => _proxy = proxy;

    internal override bool IsConditional => true;

    internal override bool HasJsonModel => _proxy.Model is IJsonModel<T>;

    internal override bool CanHandleModel(object model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => model is T typed && _proxy.CanHandle(typed, options, context);

    internal override bool CanHandleData(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _proxy.CanHandle(data, options, context);

    internal override bool CanHandleReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _proxy.CanHandle(ref reader, options, context);

    internal override IPersistableModel<TRequested>? GetPersistableModel<TRequested>()
        => _proxy.Model is IPersistableModel<TRequested> model ? model : null;

    internal override IJsonModel<TRequested>? GetJsonModel<TRequested>()
        => _proxy.Model is IJsonModel<TRequested> model ? model : null;

    internal override object? CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => _proxy.Model.Create(data, options);

    internal override object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => _proxy.Model is IJsonModel<T> jsonModel
            ? jsonModel.Create(ref reader, options)
            : throw new InvalidOperationException($"Conditional proxy model for {typeof(T).Name} does not support the JSON reader path.");

    internal override IJsonModel<object>? AsJsonModelOfObject()
    {
        // Reference-type T: covariance lets us return the model directly (preserves identity).
        if (_proxy.Model is IJsonModel<object> jsonObject)
        {
            return jsonObject;
        }
        // Value-type T: no variance, so adapt (box) the JSON model.
        return _proxy.Model is IJsonModel<T> ? new ModelReaderWriterOptions.JsonModelObjectAdapter<T>(_proxy.Model) : null;
    }
}
