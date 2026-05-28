// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core.GeoJson;

namespace Azure.Search.Documents
{
    internal static class JsonElementExtensions
    {
        /// <summary>
        /// We parse dates using variations of the round-trip format with
        /// different sub-second precision.
        /// </summary>
        private const string DateTimeInputFormatPrefix = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        private static readonly string[] s_dateTimeInputFormats = new[]
        {
            DateTimeInputFormatPrefix + "zzz",
            DateTimeInputFormatPrefix + "K",
            DateTimeInputFormatPrefix + "'.'fzzz",
            DateTimeInputFormatPrefix + "'.'fK",
            DateTimeInputFormatPrefix + "'.'ffzzz",
            DateTimeInputFormatPrefix + "'.'ffK",
            DateTimeInputFormatPrefix + "'.'fffzzz",
            DateTimeInputFormatPrefix + "'.'fffK",
            DateTimeInputFormatPrefix + "'.'ffffzzz",
            DateTimeInputFormatPrefix + "'.'ffffK",
            DateTimeInputFormatPrefix + "'.'fffffzzz",
            DateTimeInputFormatPrefix + "'.'fffffK",
            DateTimeInputFormatPrefix + "'.'ffffffzzz",
            DateTimeInputFormatPrefix + "'.'ffffffK",
            DateTimeInputFormatPrefix + "'.'fffffffzzz",
            DateTimeInputFormatPrefix + "'.'fffffffK"
        };

        /// <summary>
        /// Get a stream representation of a JsonElement.  This is an
        /// inefficient hack to let us rip out nested sub-documents
        /// representing different model types and pass them to
        /// ObjectSerializer.
        /// </summary>
        /// <param name="element">The JsonElement.</param>
        /// <returns>The JsonElement's content wrapped in a Stream.</returns>
        public static Stream ToStream(this JsonElement element) =>
            new MemoryStream(
                Encoding.UTF8.GetBytes(
                    element.GetRawText()));

        /// <summary>
        /// Convert a JSON value into a .NET object relative to Search's EDM
        /// types.
        /// </summary>
        /// <param name="element">The JSON element.</param>
        /// <returns>A corresponding .NET value.</returns>
        public static object GetSearchObject(this JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString() switch
                    {
                        Constants.NanValue => double.NaN,
                        Constants.InfValue => double.PositiveInfinity,
                        Constants.NegativeInfValue => double.NegativeInfinity,
                        string text =>
                            DateTimeOffset.TryParseExact(
                                    text,
                                    s_dateTimeInputFormats,
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.RoundtripKind,
                                    out DateTimeOffset date) ?
                                (object)date :
                                (object)text
                    };
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    { return intValue; }
                    if (element.TryGetInt64(out long longValue))
                    { return longValue; }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, jsonProperty.Value.GetSearchObject());
                    }
                    // Check if we've got a Point instead of a complex type
                    if (dictionary.TryGetValue("type", out object type) &&
                        type is string typeName &&
                        string.Equals(typeName, "Point", StringComparison.Ordinal) &&
                        dictionary.TryGetValue("coordinates", out object coordArray) &&
                        coordArray is double[] coords &&
                        (coords.Length == 2 || coords.Length == 3))
                    {
                        double longitude = coords[0];
                        double latitude = coords[1];
                        double? altitude = coords.Length == 3 ? (double?)coords[2] : null;
                        // TODO: Should we also pull in other PointGeography properties?
                        return new GeoPoint(new GeoPosition(longitude, latitude, altitude));
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(item.GetSearchObject());
                    }
                    return list.ToArray();
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }
    }
}