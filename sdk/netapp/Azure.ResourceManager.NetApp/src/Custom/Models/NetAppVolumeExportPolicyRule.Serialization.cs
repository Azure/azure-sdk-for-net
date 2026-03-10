// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeExportPolicyRule : IJsonModel<NetAppVolumeExportPolicyRule>
    {
        void IJsonModel<NetAppVolumeExportPolicyRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Rules))
            {
                writer.WritePropertyName("rules"u8);
                writer.WriteStartArray();
                foreach (var item in Rules)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static NetAppVolumeExportPolicyRule DeserializeNetAppVolumeExportPolicyRule(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            var result = new NetAppVolumeExportPolicyRule();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("rules"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        result.Rules.Add(ExportPolicyRule.DeserializeExportPolicyRule(item, options));
                    }
                    continue;
                }
            }
            return result;
        }

        NetAppVolumeExportPolicyRule IJsonModel<NetAppVolumeExportPolicyRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetAppVolumeExportPolicyRule(document.RootElement, options);
        }

        BinaryData IPersistableModel<NetAppVolumeExportPolicyRule>.Write(ModelReaderWriterOptions options)
        {
            var buffer = new System.IO.MemoryStream();
            using var writer = new Utf8JsonWriter(buffer);
            ((IJsonModel<NetAppVolumeExportPolicyRule>)this).Write(writer, options);
            writer.Flush();
            return new BinaryData(buffer.GetBuffer().AsMemory(0, (int)buffer.Position));
        }

        NetAppVolumeExportPolicyRule IPersistableModel<NetAppVolumeExportPolicyRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var document = JsonDocument.Parse(data);
            return DeserializeNetAppVolumeExportPolicyRule(document.RootElement, options);
        }

        string IPersistableModel<NetAppVolumeExportPolicyRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
