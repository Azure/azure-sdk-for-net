// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    /// <summary>
    /// Workaround helpers that build <see cref="RequestContent"/> for body parameter types that the
    /// MPG/http-client-csharp-mgmt generator emits incorrect <c>ToRequestContent</c> calls for
    /// (array body parameters and scalar <see cref="DateTimeOffset"/> body parameters).
    /// </summary>
    internal static class BillingRequestContentHelper
    {
        public static RequestContent ToRequestContent<T>(IEnumerable<T> items) where T : System.ClientModel.Primitives.IPersistableModel<T>
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (T item in items)
            {
                if (item is null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                BinaryData binary = ((System.ClientModel.Primitives.IPersistableModel<T>)item).Write(System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
                using JsonDocument doc = JsonDocument.Parse(binary);
                doc.RootElement.WriteTo(writer);
            }
            writer.WriteEndArray();
            writer.Flush();
            stream.Position = 0;
            return RequestContent.Create(stream.ToArray());
        }

        public static RequestContent ToRequestContent(DateTimeOffset value)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStringValue(value, "O");
            writer.Flush();
            stream.Position = 0;
            return RequestContent.Create(stream.ToArray());
        }
    }
}
