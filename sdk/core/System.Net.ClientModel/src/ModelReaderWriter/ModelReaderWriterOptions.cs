// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Net.ClientModel
{
    /// <summary>
    /// Provides the client options for reading and writing models.
    /// </summary>
    public class ModelReaderWriterOptions
    {
        private bool _isFrozen;

        private static ModelReaderWriterOptions? _wireOptions;
        /// <summary>
        /// Default options for writing models into the format the serivce is expecting.
        /// </summary>
        public static ModelReaderWriterOptions Wire => _wireOptions ??= new ModelReaderWriterOptions("W", true);

        private static ModelReaderWriterOptions? _jsonOptions;
        /// <summary>
        /// Default options for writing models into JSON format.
        /// </summary>
        public static ModelReaderWriterOptions Json => _jsonOptions ??= new ModelReaderWriterOptions("J", true);

        private static ModelReaderWriterOptions? _xmlOptions;
        /// <summary>
        /// Default options for writing models into XML format.
        /// </summary>
        public static ModelReaderWriterOptions Xml => _xmlOptions ??= new ModelReaderWriterOptions("X", true);

        /// <summary>
        /// Initializes a new instance of <see cref="ModelReaderWriterOptions"/>.
        /// </summary>
        /// <param name="format">The format to read and write models.</param>
        public ModelReaderWriterOptions (string format)
            : this(format, false)
        {
        }

        private ModelReaderWriterOptions(string format, bool isFrozen)
        {
            Format = format;
            _isFrozen = isFrozen;
        }

        /// <summary>
        /// Gets the format to read and write the model.
        /// </summary>
        public string Format { get; }
    }
}
