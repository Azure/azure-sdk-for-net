// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Internal;

/// <summary>
/// Provides an efficient way to write <see cref="IJsonModel{T}"/> into a <see cref="BinaryData"/> using multiple pooled buffers.
/// </summary>
internal partial class ModelWriter<T>
{
    private readonly IJsonModel<T> _model;
    private readonly ModelReaderWriterOptions _options;

    /// <summary>
    /// Initializes a new instance of <see cref="ModelWriter{T}"/>.
    /// </summary>
    /// <param name="model">The model to write.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <exception cref="NotSupportedException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    public ModelWriter(IJsonModel<T> model, ModelReaderWriterOptions options)
    {
        _model = model;
        _options = options;
    }

    public UnsafeBufferSequence.Reader ExtractReader()
    {
        using UnsafeBufferSequence sequenceWriter = new UnsafeBufferSequence();
        using var jsonWriter = new Utf8JsonWriter(sequenceWriter);
        _model.Write(jsonWriter, _options);
        jsonWriter.Flush();
        return sequenceWriter.ExtractReader();
    }
}
