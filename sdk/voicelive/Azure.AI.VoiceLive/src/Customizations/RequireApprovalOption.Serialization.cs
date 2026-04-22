// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Serialization support for <see cref="RequireApprovalOption"/>.
    /// </summary>
    public partial class RequireApprovalOption : IJsonModel<RequireApprovalOption>
    {
        void IJsonModel<RequireApprovalOption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeRequireApprovalOption(this, writer, options);

        RequireApprovalOption IJsonModel<RequireApprovalOption>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRequireApprovalOption(document.RootElement, options);
        }

        BinaryData IPersistableModel<RequireApprovalOption>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, null);
        }

        RequireApprovalOption IPersistableModel<RequireApprovalOption>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBinaryData(data);

        string IPersistableModel<RequireApprovalOption>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static void SerializeRequireApprovalOption(RequireApprovalOption instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (instance.ApprovalType.HasValue)
            {
                // Simple case: "never" or "always"
                writer.WriteStringValue(instance.ApprovalType.Value.ToString());
            }
            else
            {
                // Per-tool case: {"always": [...], "never": [...]}
                writer.WriteStartObject();
                if (instance.AlwaysRequireApproval is { Count: > 0 })
                {
                    writer.WritePropertyName("always"u8);
                    writer.WriteStartArray();
                    foreach (string tool in instance.AlwaysRequireApproval)
                    {
                        writer.WriteStringValue(tool);
                    }
                    writer.WriteEndArray();
                }
                if (instance.NeverRequireApproval is { Count: > 0 })
                {
                    writer.WritePropertyName("never"u8);
                    writer.WriteStartArray();
                    foreach (string tool in instance.NeverRequireApproval)
                    {
                        writer.WriteStringValue(tool);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
        }

        internal static RequireApprovalOption DeserializeRequireApprovalOption(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.String)
            {
                return new RequireApprovalOption(new MCPApprovalType(element.GetString()));
            }
            if (element.ValueKind == JsonValueKind.Object)
            {
                List<string> always = null;
                List<string> never = null;

                foreach (var prop in element.EnumerateObject())
                {
                    if (prop.NameEquals("always"u8) && prop.Value.ValueKind == JsonValueKind.Array)
                    {
                        always = new List<string>();
                        foreach (var item in prop.Value.EnumerateArray())
                        {
                            always.Add(item.GetString());
                        }
                    }
                    else if (prop.NameEquals("never"u8) && prop.Value.ValueKind == JsonValueKind.Array)
                    {
                        never = new List<string>();
                        foreach (var item in prop.Value.EnumerateArray())
                        {
                            never.Add(item.GetString());
                        }
                    }
                }

                return new RequireApprovalOption(always, never);
            }
            return null;
        }

        internal static RequireApprovalOption FromBinaryData(BinaryData bytes)
        {
            if (bytes is null)
            {
                return new RequireApprovalOption();
            }
            using JsonDocument document = JsonDocument.Parse(bytes);
            return DeserializeRequireApprovalOption(document.RootElement);
        }
    }
}
