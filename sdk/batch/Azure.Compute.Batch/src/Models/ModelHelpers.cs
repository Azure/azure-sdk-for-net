// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Compute.Batch.Models
{
    public static class ModelHelpers
    {
        public static RequestContent ToRequestContent(object modelContent)
        {
            Utf8JsonRequestContent content = new();
            content.JsonWriter.WriteObjectValue(modelContent);
            return content;
        }

        public static RequestContent ToRequestContent(IEnumerable<object> items)
        {
            Utf8JsonRequestContent content = new();
            Utf8JsonWriter writer = content.JsonWriter;

            writer.WriteStartArray();
            foreach (object item in items)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.Flush();
            using MemoryStream stream = new MemoryStream();
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
            content.WriteTo(stream, new System.Threading.CancellationToken());
            string json = Encoding.UTF8.GetString(stream.ToArray());
            string contents = reader.ReadToEnd();
            return content;
        }
    }
}
