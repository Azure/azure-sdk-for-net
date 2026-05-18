// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal non-generic interface for discriminator router resolution on the read path.
/// </summary>
internal interface IDiscriminatorRouter
{
    bool CanHandleData(BinaryData data);
    bool CanHandleReader(ref Utf8JsonReader reader);
    object CreateFromData(BinaryData data, ModelReaderWriterOptions options);
    object CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
    bool IsJsonModel { get; }
}

/// <summary>
/// Abstract base class for discriminator routing on the read path.
/// A discriminator router holds an <see cref="IPersistableModel{T}"/> (or <see cref="IJsonModel{T}"/>)
/// and provides selection logic via <see cref="CanHandle(BinaryData)"/> and
/// <see cref="CanHandle(ref Utf8JsonReader)"/>. The framework calls
/// <see cref="CanHandle(ref Utf8JsonReader)"/> when the held model implements
/// <see cref="IJsonModel{T}"/>; otherwise it calls <see cref="CanHandle(BinaryData)"/>.
/// </summary>
/// <typeparam name="T">The base model type this router deserializes into.</typeparam>
public abstract class DiscriminatorRouter<T> : IDiscriminatorRouter
{
    internal IPersistableModel<T> Model { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DiscriminatorRouter{T}"/> with an
    /// <see cref="IJsonModel{T}"/> model for fast reader-based deserialization.
    /// </summary>
    /// <param name="model">The JSON model that handles deserialization.</param>
    protected DiscriminatorRouter(IJsonModel<T> model)
    {
        Model = model;
        IsJsonModel = true;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="DiscriminatorRouter{T}"/> with an
    /// <see cref="IPersistableModel{T}"/> model for BinaryData-based deserialization.
    /// </summary>
    /// <param name="model">The persistable model that handles deserialization.</param>
    protected DiscriminatorRouter(IPersistableModel<T> model)
    {
        Model = model;
        IsJsonModel = false;
    }

    /// <summary>
    /// Gets whether the held model implements <see cref="IJsonModel{T}"/>.
    /// </summary>
    public bool IsJsonModel { get; }

    /// <summary>
    /// Determines whether this router can handle reading from the specified binary data.
    /// Override to inspect the data (e.g. check a discriminator field) and return true
    /// if this router should handle deserialization.
    /// Default returns false.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <returns>True if this router can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(BinaryData data) => false;

    /// <summary>
    /// Determines whether this router can handle reading from the specified JSON reader.
    /// Override to inspect the JSON (e.g. check a discriminator property) and return true
    /// if this router should handle deserialization.
    /// Default returns false.
    /// The reader is passed by ref but should not be advanced; implementations should
    /// only peek at the current state.
    /// </summary>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <returns>True if this router can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ref Utf8JsonReader reader) => false;

    bool IDiscriminatorRouter.CanHandleData(BinaryData data) => CanHandle(data);

    bool IDiscriminatorRouter.CanHandleReader(ref Utf8JsonReader reader) => CanHandle(ref reader);

    bool IDiscriminatorRouter.IsJsonModel => IsJsonModel;

    object IDiscriminatorRouter.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Model.Create(data, options)!;

    object IDiscriminatorRouter.CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        if (Model is IJsonModel<T> jsonModel)
        {
            return jsonModel.Create(ref reader, options)!;
        }

        // Fallback: read into BinaryData and use IPersistableModel path
        using var doc = JsonDocument.ParseValue(ref reader);
        BinaryData data = BinaryData.FromString(doc.RootElement.GetRawText());
        return Model.Create(data, options)!;
    }
}
