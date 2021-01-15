// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        internal IReadOnlyDictionary<string, object?> CustomProperties { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoObject"/>.
        /// </summary>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        internal GeoObject(GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties)
        {
            Argument.AssertNotNull(customProperties, nameof(customProperties));

            BoundingBox = boundingBox;
            CustomProperties = customProperties;
        }

        /// <summary>
        /// Gets the GeoJSON type of this object.
        /// </summary>
        public abstract GeoObjectType Type { get; }

        /// <summary>
        /// Represents information about the coordinate range of the <see cref="GeoObject"/>.
        /// </summary>
        public GeoBoundingBox? BoundingBox { get; }

        /// <summary>
        /// Tries to get a value of a custom property associated with the <see cref="GeoObject"/>.
        /// </summary>
        public bool TryGetCustomProperty(string name, out object? value) => CustomProperties.TryGetValue(name, out value);

        /// <summary>
        /// Converts an instance of <see cref="GeoObject"/> to a GeoJSON representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            WriteTo(writer);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
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

        /// <summary>
        /// Serializes this instance using the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
#pragma warning disable AZC0014 // do not expose Json types in public APIs
        public void WriteTo(Utf8JsonWriter writer)
#pragma warning restore AZC0014
        {
            Argument.AssertNotNull(writer, nameof(writer));
            GeoJsonConverter.Write(writer, this);
        }
    }
}