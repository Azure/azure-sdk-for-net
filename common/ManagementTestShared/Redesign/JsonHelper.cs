// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    internal static class JsonHelper
    {
        private static readonly JsonWriterOptions PrettyJsonOptions = new JsonWriterOptions() { Indented = true };
        private static readonly JsonWriterOptions CompactJsonOptions = new JsonWriterOptions();

        /// <summary>
        /// This methods serialize the complete resource data to string.
        /// </summary>
        /// <param name="data"> Resource data that implements <see cref="IUtf8JsonSerializable"/>. </param>
        /// <returns> Json string represent the data. </returns>
        public static string SerializeToString(IUtf8JsonSerializable data, bool indented = false)
        {
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, indented ? PrettyJsonOptions : CompactJsonOptions);
            writer.WriteObjectValue(data);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// This methods serialize the data properties to string under "properties" tag.
        /// Please note if data has top level properties needed that goes outside of "properties",
        /// use <see cref="JsonHelper.SerializeToString"/> instead.
        /// </summary>
        /// <param name="data"> data that implements <see cref="IUtf8JsonSerializable"/>. </param>
        /// <returns> Json string represent the data object's properties. </returns>
        public static string SerializePropertiesToString(IUtf8JsonSerializable data, bool indented = false)
        {
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, indented ? PrettyJsonOptions : CompactJsonOptions);
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(data);
            writer.WriteEndObject();
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
