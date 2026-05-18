// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal non-generic interface for discriminator proxy resolution on the read path.
/// </summary>
internal interface IDiscriminatorProxy
{
    bool CanHandleData(BinaryData data);
    bool CanHandleReader(ref Utf8JsonReader reader);
    object CreateFromData(BinaryData data, ModelReaderWriterOptions options);
    object CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
    bool IsJsonModel { get; }
}

/// <summary>
/// Abstract base class for discriminator proxies on the read path.
/// A discriminator proxy is an <see cref="IPersistableModel{T}"/> that provides
/// deserialization for a specific discriminator variant. Override
/// <see cref="CanHandle(BinaryData)"/> or <see cref="CanHandle(ref Utf8JsonReader)"/>
/// to indicate which data this proxy can deserialize.
/// Under the hood, if this proxy also implements <see cref="IJsonModel{T}"/>,
/// the framework will prefer calling <see cref="CanHandle(ref Utf8JsonReader)"/>;
/// otherwise it will call <see cref="CanHandle(BinaryData)"/>.
/// </summary>
/// <typeparam name="T">The base model type this proxy deserializes into.</typeparam>
public abstract class DiscriminatorProxy<T> : IDiscriminatorProxy, IPersistableModel<T>
{
    /// <summary>
    /// Determines whether this proxy can handle reading from the specified binary data.
    /// Override to inspect the data (e.g. check a discriminator field) and return true
    /// if this proxy should handle deserialization.
    /// Default returns false.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(BinaryData data) => false;

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified JSON reader.
    /// Override to inspect the JSON (e.g. check a discriminator property) and return true
    /// if this proxy should handle deserialization.
    /// Default returns false.
    /// The reader is passed by ref but should not be advanced; implementations should
    /// only peek at the current state.
    /// </summary>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ref Utf8JsonReader reader) => false;

    /// <inheritdoc/>
    public abstract T Create(BinaryData data, ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract BinaryData Write(ModelReaderWriterOptions options);

    /// <inheritdoc/>
    public abstract string GetFormatFromOptions(ModelReaderWriterOptions options);

    bool IDiscriminatorProxy.CanHandleData(BinaryData data) => CanHandle(data);

    bool IDiscriminatorProxy.CanHandleReader(ref Utf8JsonReader reader) => CanHandle(ref reader);

    object IDiscriminatorProxy.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Create(data, options)!;

    object IDiscriminatorProxy.CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        if (this is IJsonModel<T> jsonModel)
        {
            return jsonModel.Create(ref reader, options)!;
        }

        // Fallback: read into BinaryData and use IPersistableModel path
        using var doc = JsonDocument.ParseValue(ref reader);
        BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
        return Create(data, options)!;
    }

    bool IDiscriminatorProxy.IsJsonModel => this is IJsonModel<T>;
}
