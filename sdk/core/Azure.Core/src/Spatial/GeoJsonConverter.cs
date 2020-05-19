// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public class GeoJsonConverter : JsonConverter<Geometry>
    {
        private const string PointType = "Point";
        private const string LineStringType = "LineString";
        private const string MultiPointType = "MultiPoint";
        private const string PolygonType = "Polygon";
        private const string MultiLineStringType = "MultiLineString";
        private const string MultiPolygonType = "MultiPolygon";
        private const string GeometryCollectionType = "GeometryCollection";
        private const string TypeProperty = "type";

        /// <inheritdoc />
        public override Geometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var document = JsonDocument.ParseValue(ref reader);
            return Read(document.RootElement);
        }

        internal static Geometry Read(JsonElement element)
        {
            var typeProperty = GetRequiredProperty(element, TypeProperty);

            var type = typeProperty.GetString();

            if (type == GeometryCollectionType)
            {
                var geometries = new List<Geometry>();
                foreach (var geometry in GetRequiredProperty(element, "geometries").EnumerateArray())
                {
                    geometries.Add(Read(geometry));
                }

                return new GeometryCollection(geometries);
            }

            var coordinates = GetRequiredProperty(element, "coordinates");

            switch (type)
            {
                case PointType:
                    return new Point(ReadCoordinate(coordinates));
                case LineStringType:
                    return new LineString(ReadCoordinates(coordinates));
                case MultiPointType:
                    var points = new List<Point>();
                    foreach (var coordinate in ReadCoordinates(coordinates))
                    {
                        points.Add(new Point(coordinate));
                    }

                    return new MultiPoint(points);

                case PolygonType:
                    var rings = new List<LineString>();
                    foreach (var ringArray in coordinates.EnumerateArray())
                    {
                        rings.Add(new LineString(ReadCoordinates(ringArray)));
                    }

                    return new Polygon(rings);

                case MultiLineStringType:
                    var lineStrings = new List<LineString>();
                    foreach (var ringArray in coordinates.EnumerateArray())
                    {
                        lineStrings.Add(new LineString(ReadCoordinates(ringArray)));
                    }

                    return new MultiLineString(lineStrings);

                case MultiPolygonType:

                    var polygons = new List<Polygon>();
                    foreach (var polygon in coordinates.EnumerateArray())
                    {
                        var polygonRings = new List<LineString>();
                        foreach (var ringArray in polygon.EnumerateArray())
                        {
                            polygonRings.Add(new LineString(ReadCoordinates(ringArray)));
                        }

                        polygons.Add(new Polygon(polygonRings));
                    }

                    return new MultiPolygon(polygons);

                default:
                    throw new NotSupportedException($"Unsupported geometry type '{type}' ");
            }
        }

        private static IEnumerable<Position> ReadCoordinates(JsonElement coordinates)
        {
            foreach (JsonElement coordinate in coordinates.EnumerateArray())
            {
                yield return ReadCoordinate(coordinate);
            }
        }

        private static Position ReadCoordinate(JsonElement coordinate)
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

            return new Position(lon, lat, altitude);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, Geometry value, JsonSerializerOptions options)
        {
            Write(writer, value);
        }

        internal static void Write(Utf8JsonWriter writer, Geometry value)
        {
            void WriteType(string type)
            {
                writer.WriteString(TypeProperty, type);
            }

            void WritePosition(Position type)
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(type.Longitude);
                writer.WriteNumberValue(type.Latitude);
                if (type.Altitude != null)
                {
                    writer.WriteNumberValue(type.Altitude.Value);
                }

                writer.WriteEndArray();
            }

            void WritePositions(IEnumerable<Position> positions)
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
                case Point point:
                    WriteType(PointType);
                    writer.WritePropertyName("coordinates");
                    WritePosition(point.Position);
                    break;

                case LineString lineString:
                    WriteType(LineStringType);
                    writer.WritePropertyName("coordinates");
                    WritePositions(lineString.Positions);
                    break;

                case Polygon polygon:
                    WriteType(PolygonType);
                    writer.WritePropertyName("coordinates");
                    foreach (var ring in polygon.Rings)
                    {
                        WritePositions(ring.Positions);
                    }
                    break;

                case MultiPoint multiPoint:
                    WriteType(MultiPointType);
                    writer.WritePropertyName("coordinates");
                    writer.WriteStartArray();
                    foreach (var point in multiPoint.Points)
                    {
                        WritePosition(point.Position);
                    }
                    writer.WriteEndArray();
                    break;

                case MultiLineString multiLineString:
                    WriteType(MultiPointType);
                    writer.WritePropertyName("coordinates");
                    writer.WriteStartArray();
                    foreach (var lineString in multiLineString.LineStrings)
                    {
                        WritePositions(lineString.Positions);
                    }
                    writer.WriteEndArray();
                    break;

                case MultiPolygon multiPolygon:
                    WriteType(MultiPointType);
                    writer.WritePropertyName("coordinates");
                    writer.WriteStartArray();
                    foreach (var polygon in multiPolygon.Polygons)
                    {
                        foreach (var polygonRing in polygon.Rings)
                        {
                            WritePositions(polygonRing.Positions);
                        }
                    }
                    writer.WriteEndArray();
                    break;

                case GeometryCollection geometryCollection:
                    WriteType(GeometryCollectionType);
                    writer.WritePropertyName("geometries");
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

            writer.WriteEndObject();
        }

        private static JsonElement GetRequiredProperty(JsonElement element, string name)
        {
            if (!element.TryGetProperty(name, out JsonElement property))
            {
                throw new JsonException($"GeoJSON object expected to have '{name}' property.");
            }

            return property;
        }
    }
}