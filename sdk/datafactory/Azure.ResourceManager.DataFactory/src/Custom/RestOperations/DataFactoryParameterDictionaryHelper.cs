// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory
{
    // The MPG C# generator emits `IDictionary<string, BinaryData>.ToRequestContent(parameters)`
    // for the pipeline-run body parameter, which is invalid C#. This helper provides the
    // serialization the generator should have emitted (writing each BinaryData value as a raw
    // JSON token under its key), matching the baseline AutoRest output.
    internal static class DataFactoryParameterDictionaryHelper
    {
        internal static RequestContent ToRequestContent(IDictionary<string, BinaryData> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();
                foreach (KeyValuePair<string, BinaryData> item in parameters)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    using JsonDocument document = JsonDocument.Parse(item.Value.ToMemory());
                    document.RootElement.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            return RequestContent.Create(stream.ToArray());
        }
    }
}
