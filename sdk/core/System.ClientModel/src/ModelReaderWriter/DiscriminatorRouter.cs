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
    object? CreateFromData(BinaryData data, ModelReaderWriterOptions options);
    object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
}

/// <summary>
/// Abstract base class for discriminator routing on the read path.
/// A discriminator router provides selection logic via <see cref="CanHandle(BinaryData)"/> and
/// <see cref="CanHandle(ref Utf8JsonReader)"/>, and deserialization via
/// <see cref="Create(ref Utf8JsonReader, ModelReaderWriterOptions)"/> and
/// <see cref="Create(BinaryData, ModelReaderWriterOptions)"/>.
/// Override the <c>CanHandle</c> method(s) to indicate which data this router can handle,
/// and override the corresponding <c>Create</c> method to produce the deserialized instance.
/// Only one <c>Create</c> method needs to be implemented depending on whether the underlying
/// model is JSON-based or BinaryData-based.
/// </summary>
public abstract class DiscriminatorRouter : IDiscriminatorRouter
{
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

    /// <summary>
    /// Creates a deserialized instance from a <see cref="Utf8JsonReader"/>.
    /// Override this when the router handles JSON-based deserialization.
    /// Return null to indicate this router cannot handle the data (default behavior).
    /// </summary>
    /// <param name="reader">The JSON reader positioned at the start of the element.</param>
    /// <param name="options">The options to use during deserialization.</param>
    /// <returns>The deserialized instance, or null if this router cannot handle the data.</returns>
    public virtual object? Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => null;

    /// <summary>
    /// Creates a deserialized instance from <see cref="BinaryData"/>.
    /// Override this when the router handles BinaryData-based deserialization.
    /// Return null to indicate this router cannot handle the data (default behavior).
    /// </summary>
    /// <param name="data">The binary data to deserialize.</param>
    /// <param name="options">The options to use during deserialization.</param>
    /// <returns>The deserialized instance, or null if this router cannot handle the data.</returns>
    public virtual object? Create(BinaryData data, ModelReaderWriterOptions options) => null;

    bool IDiscriminatorRouter.CanHandleData(BinaryData data) => CanHandle(data);

    bool IDiscriminatorRouter.CanHandleReader(ref Utf8JsonReader reader) => CanHandle(ref reader);

    object? IDiscriminatorRouter.CreateFromData(BinaryData data, ModelReaderWriterOptions options)
        => Create(data, options);

    object? IDiscriminatorRouter.CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => Create(ref reader, options);
}
