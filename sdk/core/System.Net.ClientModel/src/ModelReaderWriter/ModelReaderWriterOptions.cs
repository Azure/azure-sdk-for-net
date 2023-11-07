// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.Net.ClientModel
{
    /// <summary>
    /// Provides the client options for reading and writing models.
    /// </summary>
    public class ModelReaderWriterOptions
    {
        private static readonly Dictionary<ModelReaderWriterFormat, ModelReaderWriterOptions> _singletonMap = new Dictionary<ModelReaderWriterFormat, ModelReaderWriterOptions>();

        private bool _isFrozen;

        private static ModelReaderWriterOptions? _wireOptions;
        /// <summary>
        /// Default options for writing models into the format the serivce is expecting.
        /// </summary>
        public static ModelReaderWriterOptions GetWireOptions() => _wireOptions ??= new ModelReaderWriterOptions("W", true) { IncludeAdditionalProperties = false, IncludeReadOnlyProperties = false };

        /// <summary>
        /// .
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ModelReaderWriterOptions GetDataOptions(ModelReaderWriterFormat format = default)
        {
            if (format.Equals(default))
                format = ModelReaderWriterFormat.Json;

            if (!_singletonMap.TryGetValue(format, out var options))
            {
                options = new ModelReaderWriterOptions(format.ToString(), true);
                _singletonMap[format] = options;
            }

            return options;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ModelReaderWriterOptions GetOptions(ModelReaderWriterFormat format = default)
        {
            if (format.Equals(default))
                format = ModelReaderWriterFormat.Json;

            if (format == "W")
                return GetWireOptions();

            return new ModelReaderWriterOptions(format.ToString(), false);
        }

        private ModelReaderWriterOptions(string format, bool isFrozen)
        {
            Format = format;
            _isFrozen = isFrozen;
        }

        /// <summary>
        /// Gets the <see cref="ModelReaderWriterFormat"/> that determines format of written model.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// .
        /// </summary>
        public bool IncludeReadOnlyProperties { get; set; } = true;

        /// <summary>
        /// .
        /// </summary>
        public bool IncludeAdditionalProperties { get; set; } = true;
    }
}
