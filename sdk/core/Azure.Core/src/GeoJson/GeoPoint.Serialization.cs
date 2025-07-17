// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    /// <example>
    /// Creating a point:
    /// <code snippet="Snippet:CreatePoint" language="csharp">
    /// var point = new GeoPoint(-122.091954, 47.607148);
    /// </code>
    /// </example>
    public sealed partial class GeoPoint : IJsonModel<GeoPoint>
    {
        private const string PointType = "Point";
        private const string TypeProperty = "type";
        private const string GeometriesProperty = "geometries";
        private const string CoordinatesProperty = "coordinates";
        // cspell:ignore bbox
        private const string BBoxProperty = "bbox";

        void IJsonModel<GeoPoint>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoPoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GeoPoint)} does not support '{format}' format.");
            }

            GeoJsonConverter.Write(writer, this);
        }

        GeoPoint? IJsonModel<GeoPoint>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoPoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GeoPoint)} does not support '{format}' format.");
            }

            var document = JsonDocument.ParseValue(ref reader);
            return Create(document.RootElement);
        }

        BinaryData IPersistableModel<GeoPoint>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoPoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GeoPoint)} does not support '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, AzureCoreContext.Default);
        }

        GeoPoint? IPersistableModel<GeoPoint>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoPoint>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(GeoPoint)} does not support '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            var element = document.RootElement;
            return Create(element);
        }

        private static GeoPoint Create(JsonElement element)
        {
            JsonElement typeProperty = GeoJsonConverter.GetRequiredProperty(element, TypeProperty);

            string? type = typeProperty.GetString();

            GeoBoundingBox? boundingBox = GeoJsonConverter.ReadBoundingBox(element);

            IReadOnlyDictionary<string, object?> additionalProperties = GeoJsonConverter.ReadAdditionalProperties(element);
            JsonElement coordinates = GeoJsonConverter.GetRequiredProperty(element, CoordinatesProperty);

            switch (type)
            {
                case PointType:
                    return new GeoPoint(GeoJsonConverter.ReadCoordinate(coordinates), boundingBox, additionalProperties);
                default:
                    throw new NotSupportedException($"Type '{type}' is not GeoPoint");
            }
        }

        string IPersistableModel<GeoPoint>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
