// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.Net.ClientModel.Core
{
    /// <summary>
    /// Provides the client options for reading and writing models.
    /// </summary>
    public class ModelReaderWriterOptions
    {
        private static readonly IReadOnlyDictionary<ModelReaderWriterFormat, ModelReaderWriterOptions> _singletonMap = new Dictionary<ModelReaderWriterFormat, ModelReaderWriterOptions>()
        {
            { ModelReaderWriterFormat.Json, new ModelReaderWriterOptions(ModelReaderWriterFormat.Json, true) },
            { ModelReaderWriterFormat.Wire, new ModelReaderWriterOptions(ModelReaderWriterFormat.Wire, true) }
        };

        /// <summary>
        /// Default options for writing models into the format the serivce is expecting.
        /// </summary>
        public static readonly ModelReaderWriterOptions DefaultWireOptions = _singletonMap[ModelReaderWriterFormat.Wire];

        /// <summary>
        /// Default options for writing models into the JSON format.
        /// </summary>
        public static readonly ModelReaderWriterOptions DefaultJsonOptions = _singletonMap[ModelReaderWriterFormat.Json];

        public static ModelReaderWriterOptions GetOptions(ModelReaderWriterFormat format)
            => _singletonMap.TryGetValue(format, out ModelReaderWriterOptions? options) ? options! : new ModelReaderWriterOptions(format);

        private bool _isFrozen;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelReaderWriterOptions" /> class. Defaults to format <see cref="ModelReaderWriterFormat.Json"/>.
        /// </summary>
        public ModelReaderWriterOptions() : this(ModelReaderWriterFormat.Json, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelReaderWriterOptions" /> class.
        /// </summary>
        /// <param name="format">String that determines <see cref="ModelReaderWriterFormat"/> of written model..</param>
        public ModelReaderWriterOptions(ModelReaderWriterFormat format) : this(format, false) { }

        private ModelReaderWriterOptions(ModelReaderWriterFormat format, bool isFrozen)
        {
            Format = format;
            _isFrozen = isFrozen;
        }

        /// <summary>
        /// Gets the <see cref="ModelReaderWriterFormat"/> that determines format of written model.
        /// </summary>
        public ModelReaderWriterFormat Format { get; }
    }
}
