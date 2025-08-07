// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A collection of extension methods for Utf8JsonWriter. More complex objects will written by calling the extension methods
    /// for simpler objects. For example, a Polygon will be output to the writer by outputting the LineStrings which compose its
    /// rings. In turn, a LineString will be output to the writer by outputting its GeographyPoints
    /// </summary>
    internal static class Utf8JsonWriterExtensions
    {
        private static readonly JsonEncodedText s_CoordinatesPropertyNameBytes = JsonEncodedText.Encode(GeoJsonConstants.CoordinatesPropertyName);
        private static readonly JsonEncodedText s_TypePropertyNameBytes = JsonEncodedText.Encode(GeoJsonConstants.TypePropertyName);
        private static readonly JsonEncodedText s_GeometriesPropertyNameBytes = JsonEncodedText.Encode(GeoJsonConstants.GeometriesPropertyName);

        public static void WriteGeography(
            this Utf8JsonWriter writer,
            Geography geography)
        {
            if (geography is GeographyPoint point)
            {
                WriteGeography(writer, point);
            }

            else if (geography is GeographyLineString lineString)
            {
                WriteGeography(writer, lineString);
            }

            else if (geography is GeographyPolygon polygon)
            {
                WriteGeography(writer, polygon);
            }

            else if (geography is GeographyMultiPoint multiPoint)
            {
                WriteGeography(writer, multiPoint);
            }

            else if (geography is GeographyMultiLineString multiLineString)
            {
                WriteGeography(writer, multiLineString);
            }

            else if (geography is GeographyMultiPolygon multiPolygon)
            {
                WriteGeography(writer, multiPolygon);
            }

            else if (geography is GeographyCollection collection)
            {
                WriteGeography(writer, collection);
            }
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyPoint geography)
        {
            writer.WriteStartObject();
            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.PointTypeName);
            writer.WriteStartArray(s_CoordinatesPropertyNameBytes);
            writer.WriteNumberValue(geography.Longitude);
            writer.WriteNumberValue(geography.Latitude);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyLineString geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.LineStringTypeName);

            WritePointArray(writer, geography.Points, s_CoordinatesPropertyNameBytes);

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyPolygon geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.PolygonTypeName);

            writer.WriteStartArray(s_CoordinatesPropertyNameBytes);

            foreach (GeographyLineString ring in geography.Rings)
            {
                WritePointArray(writer, ring.Points);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyMultiPoint geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.MultiPointTypeName);

            WritePointArray(writer, geography.Points, s_CoordinatesPropertyNameBytes);

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyMultiLineString geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.MultiLineStringTypeName);

            writer.WriteStartArray(s_CoordinatesPropertyNameBytes);

            foreach (GeographyLineString lineString in geography.LineStrings)
            {
                WritePointArray(writer, lineString.Points);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this Utf8JsonWriter writer,
            GeographyMultiPolygon geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.MultiPolygonTypeName);

            writer.WriteStartArray(s_CoordinatesPropertyNameBytes);

            foreach (GeographyPolygon polygon in geography.Polygons)
            {
                writer.WriteStartArray();

                foreach (var item in polygon.Rings)
                {
                    WritePointArray(writer, item.Points);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            Utf8JsonWriter writer,
            GeographyCollection geography)
        {
            writer.WriteStartObject();

            writer.WriteString(s_TypePropertyNameBytes, GeoJsonConstants.GeometryCollectionTypeName);

            writer.WriteStartArray(s_GeometriesPropertyNameBytes);

            foreach (Geography child in geography.Geographies)
            {
                WriteGeography(writer, child);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WritePointArray(
            Utf8JsonWriter writer,
            IEnumerable<GeographyPoint> points,
            JsonEncodedText? propertyName = null)
        {
            if (propertyName == null)
            {
                writer.WriteStartArray();
            }

            else
            {
                writer.WriteStartArray(s_CoordinatesPropertyNameBytes);
            }

            foreach (GeographyPoint point in points)
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(point.Longitude);
                writer.WriteNumberValue(point.Latitude);
                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}
