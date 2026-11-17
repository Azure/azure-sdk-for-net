// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

internal abstract class ProxyEntry
{
    internal abstract Type ModelType { get; }
    internal abstract bool HasJsonModel { get; }
    internal abstract bool CanHandleModel(object model, ModelReaderWriterOptions options);
    internal abstract bool CanHandleData(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options);
    internal abstract bool CanHandleReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
    internal abstract IPersistableModel<TRequested> GetPersistableModel<TRequested>();
    internal abstract IJsonModel<TRequested>? GetJsonModel<TRequested>();
}

// The closed generic registration fixes the serializer specialization, even when callers
// subsequently use a different base/derived interface. No runtime generic activation is needed.
internal sealed class ModelProxyEntry<T> : ProxyEntry
{
    private readonly ModelProxy<T> _proxy;
    private readonly IPersistableModel<T> _model;
    private readonly IPersistableModel<object>? _objectAdapter;

    internal ModelProxyEntry(ModelProxy<T> proxy)
    {
        _proxy = proxy;
        _model = proxy;
        if (typeof(T) != typeof(object))
        {
            _objectAdapter = proxy is IJsonModel<T>
                ? new JsonProxyAdapter<object>(this)
                : new PersistableProxyAdapter<object>(this);
        }
    }

    internal override Type ModelType => typeof(T);
    internal override bool HasJsonModel => _model is IJsonModel<T>;

    internal override bool CanHandleModel(object model, ModelReaderWriterOptions options)
        => model is T typed && _proxy.CanHandle(typed, options);

    internal override bool CanHandleData(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options)
        => _proxy.CanHandle(data, options);

    internal override bool CanHandleReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => _proxy.CanHandle(ref reader, options);

    internal override IPersistableModel<TRequested> GetPersistableModel<TRequested>()
        => typeof(T) == typeof(TRequested)
            ? (IPersistableModel<TRequested>)_model
            : typeof(TRequested) == typeof(object) ? (IPersistableModel<TRequested>)_objectAdapter!
            : HasJsonModel ? new JsonProxyAdapter<TRequested>(this) : new PersistableProxyAdapter<TRequested>(this);

    internal override IJsonModel<TRequested>? GetJsonModel<TRequested>()
        => !HasJsonModel ? null
            : typeof(T) == typeof(TRequested) ? (IJsonModel<TRequested>)_model
            : typeof(TRequested) == typeof(object) ? (IJsonModel<TRequested>)_objectAdapter!
            : new JsonProxyAdapter<TRequested>(this);

    private class PersistableProxyAdapter<TRequested> : IPersistableModel<TRequested>
    {
        protected ModelProxyEntry<T> Entry { get; }

        internal PersistableProxyAdapter(ModelProxyEntry<T> entry) => Entry = entry;

        public BinaryData Write(ModelReaderWriterOptions options) => Entry._model.Write(options);
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => Entry._model.GetFormatFromOptions(options);
        public TRequested Create(BinaryData data, ModelReaderWriterOptions options)
            => CastResult(Entry._model.Create(data, options));

        protected static TRequested CastResult(object? result)
        {
            if (result is TRequested typed)
            {
                return typed;
            }
            if (result is null && default(TRequested) is null)
            {
                return default!;
            }
            throw new InvalidOperationException($"The proxy returned a model that is not assignable to {typeof(TRequested).Name}.");
        }
    }

    private sealed class JsonProxyAdapter<TRequested> : PersistableProxyAdapter<TRequested>, IJsonModel<TRequested>
    {
        internal JsonProxyAdapter(ModelProxyEntry<T> entry) : base(entry) { }

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<T>)Entry._model).Write(writer, options);

        public TRequested Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => CastResult(((IJsonModel<T>)Entry._model).Create(ref reader, options));
    }
}
