// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Convert doubles to and from JSON.  Search allows INF, -INF, and NaN as
    /// string values.
    /// </summary>
    internal class SearchDoubleConverter : JsonConverter<double>
    {
        public static SearchDoubleConverter Shared { get; } =
            new SearchDoubleConverter();

        public override double Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(options != null);

            if (reader.TokenType == JsonTokenType.String)
            {
                switch (reader.GetString())
                {
                    case Constants.InfValue:
                        return double.PositiveInfinity;
                    case Constants.NegativeInfValue:
                        return double.NegativeInfinity;
                    case Constants.NanValue:
                        return double.NaN;
                    default:
                        throw new JsonException();
                }
            }
            return reader.GetDouble();
        }

        public override void Write(
            Utf8JsonWriter writer,
            double value,
            JsonSerializerOptions options)
        {
            Argument.AssertNotNull(writer, nameof(writer));
            Debug.Assert(options != null);

            if (double.IsPositiveInfinity(value))
            {
                writer.WriteStringValue(Constants.InfValue);
            }
            else if (double.IsNegativeInfinity(value))
            {
                writer.WriteStringValue(Constants.NegativeInfValue);
            }
            else if (double.IsNaN(value))
            {
                writer.WriteStringValue(Constants.NanValue);
            }
            else
            {
                writer.WriteNumberValue(value);
            }
        }
    }
}
