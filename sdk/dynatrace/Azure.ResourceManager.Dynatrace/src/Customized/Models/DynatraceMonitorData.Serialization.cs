// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.ResourceManager.Dynatrace.Models;

namespace Azure.ResourceManager.Dynatrace
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Identity), SerializationValueHook = nameof(WriteIdentity), DeserializationValueHook = nameof(ReadIdentity))]
    public partial class DynatraceMonitorData
    {
        internal void WriteIdentity(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ResourceManager.Models.ManagedServiceIdentity>)Identity).Write(writer, options.Format == "W" ? ModelSerializationExtensions.WireV3Options : ModelSerializationExtensions.JsonV3Options);
        }

        internal static void ReadIdentity(JsonProperty property, ref ResourceManager.Models.ManagedServiceIdentity identity)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

            identity = ModelReaderWriter.Read<ResourceManager.Models.ManagedServiceIdentity>(new System.BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireV3Options, AzureResourceManagerDynatraceContext.Default);
        }
    }
}