// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Convert dates to and from JSON.  They're expected to be in 8601 UTC.
    /// </summary>
    internal class SearchDateTimeConverter : JsonConverter<DateTime>
    {
        public static SearchDateTimeConverter Shared { get; } =
            new SearchDateTimeConverter();

        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert != null);
            Debug.Assert(options != null);

            string text = reader.GetString();
            return DateTime.Parse(text, CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options)
        {
            Argument.AssertNotNull(writer, nameof(writer));
            Debug.Assert(options != null);
            writer.WriteStringValue(JsonSerialization.Date(value, CultureInfo.InvariantCulture));
        }
    }
}
