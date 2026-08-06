// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// A proxy that conditionally handles reading and writing for a model type based on its
/// <c>CanHandle</c> checks. Each check receives the active <see cref="ModelReaderWriterOptions"/> and
/// <see cref="ModelReaderWriterContext"/>, so the decision can depend on them in addition to the
/// payload.
/// </summary>
/// <typeparam name="T">The model type this proxy handles.</typeparam>
public abstract class ConditionalModelProxy<T>
    where T : IPersistableModel<T>
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
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> in effect for the current operation.</param>
    /// <returns>True if this proxy can handle the model; otherwise, false.</returns>
    public virtual bool CanHandle(T model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => false;

    /// <summary>
    /// Determines whether this proxy can handle reading from the specified binary data.
    /// Override to inspect the data (e.g. check a discriminator field) and return true
    /// if this proxy should handle deserialization.
    /// Default returns false.
    /// </summary>
    /// <param name="data">The data to inspect.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> in effect for the current operation.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => false;

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
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> in effect for the current operation.</param>
    /// <param name="context">The <see cref="ModelReaderWriterContext"/> in effect for the current operation.</param>
    /// <returns>True if this proxy can handle the data; otherwise, false.</returns>
    public virtual bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => false;
}
