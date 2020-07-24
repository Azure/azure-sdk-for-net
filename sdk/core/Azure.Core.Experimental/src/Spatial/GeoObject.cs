// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// A base type for all spatial types.
    /// </summary>
    public abstract class GeoObject
    {
        internal static readonly IReadOnlyDictionary<string, object?> DefaultProperties = new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());
        private string? _serialized;

        /// <summary>
        /// Initializes a new instance of <see cref="GeoObject"/>.
        /// </summary>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        protected GeoObject(GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties)
        {
            Argument.AssertNotNull(additionalProperties, nameof(additionalProperties));

            BoundingBox = boundingBox;
            AdditionalProperties = additionalProperties;
        }

        /// <summary>
        /// Represents information about the coordinate range of the <see cref="GeoObject"/>.
        /// </summary>
        public GeoBoundingBox? BoundingBox { get; }

        /// <summary>
        /// Gets a dictionary of additional properties associated with the <see cref="GeoObject"/>.
        /// </summary>
        public IReadOnlyDictionary<string, object?> AdditionalProperties { get; }

        /// <summary>
        /// Converts an instance of <see cref="GeoObject"/> to a GeoJSON representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (_serialized == null)
            {
                using MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
                GeoJsonConverter.Write(writer, this);
                _serialized = Encoding.UTF8.GetString(stream.ToArray());
            }

            return _serialized;
        }

        /// <summary>
        /// Parses an instance of see <see cref="GeoObject"/> from provided JSON representation.
        /// </summary>
        /// <param name="json">The GeoJSON representation of an object.</param>
        /// <returns>The resulting <see cref="GeoObject"/> object.</returns>
        public static GeoObject Parse(string json)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            return GeoJsonConverter.Read(jsonDocument.RootElement);
        }
    }
}