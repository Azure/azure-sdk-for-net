// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: centralizes legacy serialization behavior used by hand-written compatibility
    // models whose wire shape differs from the latest generated model hierarchy.
    internal static class MachineLearningSerializationHelpers
    {
        public static RequestContent CreateEnumerableContent<T>(IEnumerable<T> values)
            where T : IJsonModel<T>
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (T item in values)
            {
                if (item is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    item.Write(writer, ModelSerializationExtensions.WireOptions);
                }
            }
            writer.WriteEndArray();
            writer.Flush();
            return RequestContent.Create(BinaryData.FromBytes(stream.ToArray()));
        }

        public static RequestContent CreateStringEnumerableContent(IEnumerable<string> values)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartArray();
            foreach (string item in values)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.Flush();
            return RequestContent.Create(BinaryData.FromBytes(stream.ToArray()));
        }
    }
}
