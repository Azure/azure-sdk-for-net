// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives;

/// <summary>
/// Allows an object to control its own writing to a <see cref="Stream"/>.
/// The format is determined by the implementer.
/// </summary>
/// <typeparam name="T">The type the model can be converted into.</typeparam>
public interface IStreamModel<out T> : IPersistableModel<T>
{
    /// <summary>
    /// Writes the model into the provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to write the model into.</param>
    /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
    /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
    void Write(Stream stream, ModelReaderWriterOptions options);
}
