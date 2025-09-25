// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace
{
    [CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(WriteIdentity), DeserializationValueHook = nameof(ReadIdentity))]
    public partial class DynatraceMonitorData
    {
        internal void WriteIdentity(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var serializeOptions = new JsonSerializerOptions { Converters = { new DynatraceManagedServiceIdentityTypeConverter() } };
            JsonSerializer.Serialize(writer, Identity, serializeOptions);
        }

        internal static void ReadIdentity(JsonProperty property, ref ResourceManager.Models.ManagedServiceIdentity identity)
        {
            var serializeOptions = new JsonSerializerOptions { Converters = { new DynatraceManagedServiceIdentityTypeConverter() } };
            identity = JsonSerializer.Deserialize<ResourceManager.Models.ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
        }
    }
}
