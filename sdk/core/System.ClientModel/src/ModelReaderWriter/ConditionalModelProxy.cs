// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// A proxy that conditionally handles reading and writing for a model type based on
/// <see cref="CanHandle(T)"/>, <see cref="CanHandle(ReadOnlyMemory{byte})"/>, and
/// <see cref="CanHandle(ref Utf8JsonReader)"/> checks.
/// </summary>
/// <typeparam name="T">The model type this proxy handles. Must be a reference type.</typeparam>
public abstract class ConditionalModelProxy<T> : IConditionalProxy
    where T : class
{
    /// <summary>
    /// Gets the model implementation used for reading and writing when this proxy handles the request.
    /// </summary>
    public IPersistableModel<T> Model { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ConditionalModelProxy{T}"/> with the specified model.
    /// </summary>
    /// <param name="model">The model implementation to delegate to when this proxy handles a request.</param>
    protected ConditionalModelProxy(IPersistableModel<T> model)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
    }

    /// <summary>
    /// Determines whether this proxy can handle the specified model instance on the write path.
    /// Default returns false.
    /// </summary>
    /// <param name="model">The model instance to check.</param>
    /// <returns>True if this proxy can handle the model; otherwise, false.</returns>
    public virtual bool CanHandle(T model) => false;

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified binary data.
    /// Override to inspect the data (e.g. check a discriminator field) and return true
    /// if this proxy should handle deserialization.
    /// Default returns false.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ReadOnlyMemory<byte> data) => false;

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified JSON reader.
    /// Override to inspect the JSON (e.g. check a discriminator property) and return true
    /// if this proxy should handle deserialization.
    /// Default returns false.
    /// </summary>
    /// <remarks>
    /// When called by <see cref="ModelReaderWriter"/>, the reader passed to this method is a
    /// snapshot. Implementations may freely advance the reader to inspect the JSON structure.
    /// The reader position will be reset before the model's Create is called.
    /// <para>
    /// If you call this method directly outside of <see cref="ModelReaderWriter"/>, you are
    /// responsible for snapshotting the reader beforehand if you need to preserve its position.
    /// </para>
    /// </remarks>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ref Utf8JsonReader reader) => false;

    // IConditionalProxy bridges non-generic dispatch
    bool IConditionalProxy.CanHandleData(ReadOnlyMemory<byte> data) => CanHandle(data);
    bool IConditionalProxy.CanHandleReader(ref Utf8JsonReader reader) => CanHandle(ref reader);
    bool IConditionalProxy.CanHandleModel(object model) => model is T typed && CanHandle(typed);
    bool IConditionalProxy.HasJsonModel => Model is IJsonModel<T>;
    IPersistableModel<object> IConditionalProxy.GetModel() => (IPersistableModel<object>)Model;

    object? IConditionalProxy.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Model.Create(data, options);

    object? IConditionalProxy.CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        if (Model is IJsonModel<T> jsonModel)
            return jsonModel.Create(ref reader, options);
        throw new InvalidOperationException($"Conditional proxy model for {typeof(T).Name} does not support JSON reader path.");
    }

    IJsonModel<object> IConditionalProxy.AsJsonModelOfObject()
    {
        if (Model is IJsonModel<T>)
            return new ModelReaderWriterOptions.JsonModelObjectAdapter<T>(Model);
        throw new InvalidOperationException($"Conditional proxy model for {typeof(T).Name} does not implement IJsonModel.");
    }
}
