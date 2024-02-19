// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// Allows an object to control its own writing and reading.
    /// The format is determined by the implementer.
    /// </summary>
    /// <typeparam name="T">The type the model can be converted into.</typeparam>
    public interface IPersistableStreamModel<out T>
    {
        /// <summary>
        /// Writes the model into a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write into.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        void Write(Stream stream, ModelReaderWriterOptions options);
        /// <summary>
        /// Writes the model into a <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write into.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <param name="cancellation">To cancellation token to use.</param>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
       Task WriteAsync(Stream stream, ModelReaderWriterOptions options, CancellationToken cancellation);

        /// <summary>
        /// Converts the provided <see cref="BinaryData"/> into a model.
        /// </summary>
        /// <param name="stream">The <see cref="BinaryData"/> to parse.</param>
        /// <param name="options">The <see cref="ModelReaderWriterOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the data.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelReaderWriterOptions.Format"/>.</exception>
        T Create(Stream stream, ModelReaderWriterOptions options);

        /// <summary>
        /// Gets the data content type of the model when communicating with the service.
        /// </summary>
        /// <returns>The content type of the model when communicating with the serivce.</returns>
        string GetMediaType(ModelReaderWriterOptions options);
    }
}
