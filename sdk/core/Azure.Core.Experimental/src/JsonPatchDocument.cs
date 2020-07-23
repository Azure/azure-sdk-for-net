// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

#pragma warning disable 1591

namespace Azure.Core.JsonPatch
{
    public class JsonPatchDocument
    {
        public JsonPatchDocument()
        {
            Operations = new Collection<JsonPatchOperation>();
        }

        public Collection<JsonPatchOperation> Operations { get; }

        public void AppendAdd(string path, string rawJsonValue)
        {
            Operations.Add(new JsonPatchOperation(JsonPatchOperationKind.Add, path, null,rawJsonValue));
        }

        public void AppendCopy(string from, string path, string rawJsonValue)
        {
            Operations.Add(new JsonPatchOperation(JsonPatchOperationKind.Copy, path, from, rawJsonValue));
        }

        public void AppendMove(string from, string path, string rawJsonValue)
        {
            Operations.Add(new JsonPatchOperation(JsonPatchOperationKind.Move, path, from, rawJsonValue));
        }

        public void AppendRemove(string path)
        {
            Operations.Add(new JsonPatchOperation(JsonPatchOperationKind.Remove, path, null, null));
        }

        public void AppendTest(string path, string rawJsonValue)
        {
            Operations.Add(new JsonPatchOperation(JsonPatchOperationKind.Test, path, null, rawJsonValue));
        }

        public override string ToString()
        {
            using var memoryStream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                WriteTo(writer);
            }
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        internal void WriteTo(Utf8JsonWriter writer)
        {
            writer.WriteStartArray();
            foreach (var operation in Operations)
            {
                writer.WriteStartObject();
                writer.WriteString("op", operation.Kind.ToString());
                writer.WriteString("path", operation.Path);
                if (operation.From != null)
                {
                    writer.WriteString("path", operation.From);
                }
                if (operation.RawJsonValue != null)
                {
                    using var parsedValue = JsonDocument.Parse(operation.RawJsonValue);
                    writer.WritePropertyName("value");
                    parsedValue.WriteTo(writer);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
    }
}