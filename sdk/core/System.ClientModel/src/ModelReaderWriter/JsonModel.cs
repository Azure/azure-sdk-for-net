// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Base class for JSON models implementing <see cref="IJsonModel{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the model represented by this JSON model.</typeparam>
public abstract class JsonModel<T> : IJsonModel<T>, IPersistableModel<T>
{
    /// <summary>
    /// Writes the model to the provided <see cref="Utf8JsonWriter"/>.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write into.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    protected abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);

    /// <summary>
    /// Reads one JSON value (including objects or arrays) from the provided reader and converts it to a model.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>The model created from the JSON value.</returns>
    protected abstract T CreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options);

    #region MRW
    T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CreateCore(ref reader, options);

    T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        Utf8JsonReader reader = new Utf8JsonReader(data.ToMemory().Span);
        return CreateCore(ref reader, options);
    }

    string IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => WriteCore(writer, options);

    BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
    {
        MemoryStream stream = new MemoryStream();
        Utf8JsonWriter writer = new Utf8JsonWriter(stream);
        WriteCore(writer, options);
        writer.Flush();
        byte[] buffer = stream.GetBuffer();
        ReadOnlyMemory<byte> memory = buffer.AsMemory(0, (int)stream.Position);
        return new BinaryData(memory);
    }
    #endregion
}
