// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Converts a <see cref="GeoObject"/> value from and to JSON in GeoJSON format.
    /// </summary>
    internal sealed class GeoJsonConverter : JsonConverter<GeoObject>
    {
        private const string PointType = "Point";
        private const string LineStringType = "LineString";
        private const string MultiPointType = "MultiPoint";
        private const string PolygonType = "Polygon";
        private const string MultiLineStringType = "MultiLineString";
        private const string MultiPolygonType = "MultiPolygon";
        private const string GeometryCollectionType = "GeometryCollection";
        private const string TypeProperty = "type";
        private const string GeometriesProperty = "geometries";
        private const string CoordinatesProperty = "coordinates";
        // cspell:ignore bbox
        private const string BBoxProperty = "bbox";

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(GeoObject).IsAssignableFrom(typeToConvert);
        }

        /// <inheritdoc />
        public override GeoObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var document = JsonDocument.ParseValue(ref reader);
            return Read(document.RootElement);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, GeoObject value, JsonSerializerOptions options)
        {
            Write(writer, value);
        }

        internal static GeoObject Read(JsonElement element)
        {
            JsonElement typeProperty = GetRequiredProperty(element, TypeProperty);

            string? type = typeProperty.GetString();

            GeoBoundingBox? boundingBox = ReadBoundingBox(element);

            if (type == GeometryCollectionType)
            {
                var geometries = new List<GeoObject>();
                foreach (var geometry in GetRequiredProperty(element, GeometriesProperty).EnumerateArray())
                {
                    geometries.Add(Read(geometry));
                }

                return new GeoCollection(geometries, boundingBox, ReadAdditionalProperties(element, GeometriesProperty));
            }

            IReadOnlyDictionary<string, object?> additionalProperties = ReadAdditionalProperties(element);
            JsonElement coordinates = GetRequiredProperty(element, CoordinatesProperty);

            switch (type)
            {
                case PointType:
                    return new GeoPoint(ReadCoordinate(coordinates), boundingBox, additionalProperties);
                case LineStringType:
                    return new GeoLineString(ReadCoordinates(coordinates), boundingBox, additionalProperties);
                case MultiPointType:
                    var points = new List<GeoPoint>();
                    foreach (GeoPosition coordinate in ReadCoordinates(coordinates))
                    {
                        points.Add(new GeoPoint(coordinate, null, GeoObject.DefaultProperties));
                    }

                    return new GeoPointCollection(points, boundingBox, additionalProperties);

                case PolygonType:
                    var rings = new List<GeoLinearRing>();
                    foreach (JsonElement ringArray in coordinates.EnumerateArray())
                    {
                        rings.Add(new GeoLinearRing(ReadCoordinates(ringArray)));
                    }

                    return new GeoPolygon(rings, boundingBox, additionalProperties);

                case MultiLineStringType:
                    var lineStrings = new List<GeoLineString>();
                    foreach (JsonElement ringArray in coordinates.EnumerateArray())
                    {
                        lineStrings.Add(new GeoLineString(ReadCoordinates(ringArray), null, GeoObject.DefaultProperties));
                    }

                    return new GeoLineStringCollection(lineStrings, boundingBox, additionalProperties);

                case MultiPolygonType:

                    var polygons = new List<GeoPolygon>();
                    foreach (JsonElement polygon in coordinates.EnumerateArray())
                    {
                        var polygonRings = new List<GeoLinearRing>();
                        foreach (JsonElement ringArray in polygon.EnumerateArray())
                        {
                            polygonRings.Add(new GeoLinearRing(ReadCoordinates(ringArray)));
                        }

                        polygons.Add(new GeoPolygon(polygonRings));
                    }

                    return new GeoPolygonCollection(polygons, boundingBox, additionalProperties);

                default:
                    throw new NotSupportedException($"Unsupported geometry type '{type}' ");
            }
        }

        internal static GeoBoundingBox? ReadBoundingBox(in JsonElement element)
        {
            GeoBoundingBox? bbox = null;

            if (element.TryGetProperty(BBoxProperty, out JsonElement bboxElement))
            {
                // According to RFC 7946, the bbox member is optional. If one is provided, it MUST
                // be an array and cannot be null.
                // The code below is intentionally lenient and allows a null value to be treated
                // as if the bbox member was omitted. The GeoObject.BoundingBox property is already
                // set to null when there is no bbox, so setting it to null when the GeoJSON data has
                // a null bbox does not impact the behavior of the GeoObject class.
                // This was done to be compatible with third-party GeoJSON serializers. There are some
                // GeoJSON serializer packages in the broader community that either don't follow this
                // part of the spec, or interpret optional as being equal to nullable.
                // Note: The Azure.Core serializer follows the spec and never writes "bbox": null
                if (bboxElement.ValueKind == JsonValueKind.Null)
                {
                    return null;
                }

                var arrayLength = bboxElement.GetArrayLength();

                switch (arrayLength)
                {
                    case 4:
                        bbox = new GeoBoundingBox(
                            bboxElement[0].GetDouble(),
                            bboxElement[1].GetDouble(),
                            bboxElement[2].GetDouble(),
                            bboxElement[3].GetDouble()
                        );
                        break;
                    case 6:
                        bbox = new GeoBoundingBox(
                            bboxElement[0].GetDouble(),
                            bboxElement[1].GetDouble(),
                            bboxElement[3].GetDouble(),
                            bboxElement[4].GetDouble(),
                            bboxElement[2].GetDouble(),
                            bboxElement[5].GetDouble()
                        );
                        break;
                    default:
                        throw new JsonException("Only 2 or 3 element coordinates supported");
                }
            }

            return bbox;
        }

        internal static IReadOnlyDictionary<string, object?> ReadAdditionalProperties(in JsonElement element, string knownProperty = CoordinatesProperty)
        {
            Dictionary<string, object?>? additionalProperties = null;
            foreach (var property in element.EnumerateObject())
            {
                var propertyName = property.Name;
                if (propertyName.Equals(TypeProperty, StringComparison.Ordinal) ||
                    propertyName.Equals(BBoxProperty, StringComparison.Ordinal) ||
                    propertyName.Equals(knownProperty, StringComparison.Ordinal))
                {
                    continue;
                }

                additionalProperties ??= new Dictionary<string, object?>();
                additionalProperties.Add(propertyName, ReadAdditionalPropertyValue(property.Value));
            }

            return additionalProperties ?? GeoObject.DefaultProperties;
        }

        private static object? ReadAdditionalPropertyValue(in JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }
                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object?>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, ReadAdditionalPropertyValue(jsonProperty.Value));
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(ReadAdditionalPropertyValue(item));
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }

        internal static IReadOnlyList<GeoPosition> ReadCoordinates(JsonElement coordinatesElement)
        {
            GeoPosition[] coordinates = new GeoPosition[coordinatesElement.GetArrayLength()];

            int i = 0;
            foreach (JsonElement coordinate in coordinatesElement.EnumerateArray())
            {
                 coordinates[i] = ReadCoordinate(coordinate);
                 i++;
            }

            return coordinates;
        }

        internal static GeoPosition ReadCoordinate(JsonElement coordinate)
        {
            var arrayLength = coordinate.GetArrayLength();
            if (arrayLength < 2 || arrayLength > 3)
            {
                throw new JsonException("Only 2 or 3 element coordinates supported");
            }

            var lon = coordinate[0].GetDouble();
            var lat = coordinate[1].GetDouble();
            double? altitude = null;

            if (arrayLength > 2)
            {
                altitude = coordinate[2].GetDouble();
            }

            return new GeoPosition(lon, lat, altitude);
        }

        internal static void Write(Utf8JsonWriter writer, GeoObject value)
        {
            void WritePositionValues(GeoPosition type)
            {
                writer.WriteNumberValue(type.Longitude);
                writer.WriteNumberValue(type.Latitude);
                if (type.Altitude != null)
                {
                    writer.WriteNumberValue(type.Altitude.Value);
                }
            }

            void WriteType(string type)
            {
                writer.WriteString(TypeProperty, type);
            }

            void WritePosition(GeoPosition type)
            {
                writer.WriteStartArray();
                WritePositionValues(type);

                writer.WriteEndArray();
            }

            void WritePositions(GeoArray<GeoPosition> positions)
            {
                writer.WriteStartArray();
                foreach (var position in positions)
                {
                    WritePosition(position);
                }

                writer.WriteEndArray();
            }

            writer.WriteStartObject();
            switch (value)
            {
                case GeoPoint point:
                    WriteType(PointType);
                    writer.WritePropertyName(CoordinatesProperty);
                    WritePosition(point.Coordinates);
                    break;

                case GeoLineString lineString:
                    WriteType(LineStringType);
                    writer.WritePropertyName(CoordinatesProperty);
                    WritePositions(lineString.Coordinates);
                    break;

                case GeoPolygon polygon:
                    WriteType(PolygonType);
                    writer.WritePropertyName(CoordinatesProperty);
                    writer.WriteStartArray();
                    foreach (var ring in polygon.Rings)
                    {
                        WritePositions(ring.Coordinates);
                    }

                    writer.WriteEndArray();
                    break;

                case GeoPointCollection multiPoint:
                    WriteType(MultiPointType);
                    writer.WritePropertyName(CoordinatesProperty);
                    writer.WriteStartArray();
                    foreach (var point in multiPoint.Points)
                    {
                        WritePosition(point.Coordinates);
                    }

                    writer.WriteEndArray();
                    break;

                case GeoLineStringCollection multiLineString:
                    WriteType(MultiLineStringType);
                    writer.WritePropertyName(CoordinatesProperty);
                    writer.WriteStartArray();
                    foreach (var lineString in multiLineString.Lines)
                    {
                        WritePositions(lineString.Coordinates);
                    }

                    writer.WriteEndArray();
                    break;

                case GeoPolygonCollection multiPolygon:
                    WriteType(MultiPolygonType);
                    writer.WritePropertyName(CoordinatesProperty);
                    writer.WriteStartArray();
                    foreach (var polygon in multiPolygon.Polygons)
                    {
                        writer.WriteStartArray();
                        foreach (var polygonRing in polygon.Rings)
                        {
                            WritePositions(polygonRing.Coordinates);
                        }
                        writer.WriteEndArray();
                    }

                    writer.WriteEndArray();
                    break;

                case GeoCollection geometryCollection:
                    WriteType(GeometryCollectionType);
                    writer.WritePropertyName(GeometriesProperty);
                    writer.WriteStartArray();
                    foreach (var geometry in geometryCollection.Geometries)
                    {
                        Write(writer, geometry);
                    }

                    writer.WriteEndArray();
                    break;

                default:
                    throw new NotSupportedException($"Geometry type '{value?.GetType()}' not supported");
            }

            if (value.BoundingBox is GeoBoundingBox bbox)
            {
                writer.WritePropertyName(BBoxProperty);
                writer.WriteStartArray();
                writer.WriteNumberValue(bbox.West);
                writer.WriteNumberValue(bbox.South);
                if (bbox.MinAltitude != null)
                {
                    writer.WriteNumberValue(bbox.MinAltitude.Value);
                }
                writer.WriteNumberValue(bbox.East);
                writer.WriteNumberValue(bbox.North);
                if (bbox.MaxAltitude != null)
                {
                    writer.WriteNumberValue(bbox.MaxAltitude.Value);
                }
                writer.WriteEndArray();
            }

            foreach (var additionalProperty in value.CustomProperties)
            {
                writer.WritePropertyName(additionalProperty.Key);
                WriteAdditionalPropertyValue(writer, additionalProperty.Value);
            }

            writer.WriteEndObject();
        }
        internal static void WriteAdditionalPropertyValue(Utf8JsonWriter writer, object? value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case double d:
                    writer.WriteNumberValue(d);
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case long l:
                    writer.WriteNumberValue(l);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case IEnumerable<KeyValuePair<string, object?>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object?> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        WriteAdditionalPropertyValue(writer, pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object?> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object? item in objectEnumerable)
                    {
                        WriteAdditionalPropertyValue(writer, item);
                    }
                    writer.WriteEndArray();
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }

        internal static JsonElement GetRequiredProperty(JsonElement element, string name)
        {
            if (!element.TryGetProperty(name, out JsonElement property))
            {
                throw new JsonException($"GeoJSON object expected to have '{name}' property.");
            }

            return property;
        }
    }
}
