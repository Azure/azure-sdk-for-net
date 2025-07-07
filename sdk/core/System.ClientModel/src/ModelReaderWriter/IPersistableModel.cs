// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Allows an object to control its own writing and reading.
/// The format is determined by the implementer.
/// </summary>
/// <typeparam name="T">The type the model can be converted into.</typeparam>
public interface IPersistableModel<out T>
{
    /// <summary>
    /// Writes the model into a <see cref="BinaryData"/>.
    /// </summary>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A binary representation of the written model.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    BinaryData Write(ModelReaderWriterOptions options);

    /// <summary>
    /// Converts the provided <see cref="BinaryData"/> into a model.
    /// </summary>
    /// <param name="data">The <see cref="BinaryData"/> to parse.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <returns>A <typeparamref name="T"/> representation of the data.</returns>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    T? Create(BinaryData data, ModelReaderWriterOptions options);

    /// <summary>
    /// Gets the data interchange format (JSON, Xml, etc) that the model uses when communicating with the service.
    /// </summary>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to consider when serializing and deserializing the model.</param>
    /// <returns>The format that the model uses when communicating with the service.</returns>
    string GetFormatFromOptions(ModelReaderWriterOptions options);
}
