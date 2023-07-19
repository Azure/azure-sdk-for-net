// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A collection of extension methods for JsonWriter.
    /// </summary>
    /// <remarks>
    /// More complex objects will written by calling the extension methods for simpler objects. For example, a Polygon will
    /// be output to the writer by outputting the LineStrings which compose its rings. In turn, a LineString will be outbut
    /// to the writer by outputting its GeographyPoints.
    /// </remarks>
    internal static class JsonWriterExtensions
    {
        public static void WriteGeography(
            this JsonWriter writer,
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
            this JsonWriter writer,
            GeographyPoint geography)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.PointTypeName);
            writer.WritePropertyName(GeoJsonConstants.CoordinatesPropertyName);
            writer.WriteStartArray();
            writer.WriteValue(geography.Longitude);
            writer.WriteValue(geography.Latitude);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this JsonWriter writer,
            GeographyLineString geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.LineStringTypeName);

            WritePointArray(writer, geography.Points, GeoJsonConstants.CoordinatesPropertyName);

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this JsonWriter writer,
            GeographyPolygon geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.PolygonTypeName);

            writer.WritePropertyName(GeoJsonConstants.CoordinatesPropertyName);
            writer.WriteStartArray();

            foreach (GeographyLineString ring in geography.Rings)
            {
                WritePointArray(writer, ring.Points);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this JsonWriter writer,
            GeographyMultiPoint geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.MultiPointTypeName);

            WritePointArray(writer, geography.Points, GeoJsonConstants.CoordinatesPropertyName);

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this JsonWriter writer,
            GeographyMultiLineString geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.MultiLineStringTypeName);

            writer.WritePropertyName(GeoJsonConstants.CoordinatesPropertyName);
            writer.WriteStartArray();

            foreach (GeographyLineString lineString in geography.LineStrings)
            {
                WritePointArray(writer, lineString.Points);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WriteGeography(
            this JsonWriter writer,
            GeographyMultiPolygon geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.MultiPolygonTypeName);

            writer.WritePropertyName(GeoJsonConstants.CoordinatesPropertyName);
            writer.WriteStartArray();

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
            JsonWriter writer,
            GeographyCollection geography)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(GeoJsonConstants.TypePropertyName);
            writer.WriteValue(GeoJsonConstants.GeometryCollectionTypeName);

            writer.WritePropertyName(GeoJsonConstants.GeometriesPropertyName);
            writer.WriteStartArray();

            foreach (Geography child in geography.Geographies)
            {
                WriteGeography(writer, child);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        private static void WritePointArray(
            JsonWriter writer,
            IEnumerable<GeographyPoint> points,
            string propertyName = null)
        {
            if (propertyName != null)
            {
                writer.WritePropertyName(GeoJsonConstants.CoordinatesPropertyName);
            }

            writer.WriteStartArray();

            foreach (GeographyPoint point in points)
            {
                writer.WriteStartArray();
                writer.WriteValue(point.Longitude);
                writer.WriteValue(point.Latitude);
                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}
