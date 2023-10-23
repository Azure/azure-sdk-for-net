// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.Net.ClientModel.Core
{
    /// <summary>
    /// Allows an object to control its own JSON writing and reading.
    /// </summary>
    /// <typeparam name="T">The type the model can be converted into.</typeparam>
    public interface IJsonModel<out T> : IModel<T>
    {
        /// <summary>
        /// Writes the model to the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write into.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="InvalidOperationException">If <see cref="ModelReaderWriterFormat.Wire"/> format is passed in and the model does not use JSON for its wire format.</exception>
        void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options);

        /// <summary>
        /// Reads one JSON value (including objects or arrays) from the provided reader and converts it to a model.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the JSON value.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        /// <exception cref="InvalidOperationException">If <see cref="ModelReaderWriterFormat.Wire"/> format is passed in and the model does not use JSON for its wire format.</exception>
        T Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
    }
}
