// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    [CodeGenSerialization(nameof(EntraIdConfig), "entraIdConfig",
        SerializationValueHook = nameof(WriteEntraIdConfig), DeserializationValueHook = nameof(ReadEntraIdConfig))]
    internal partial class AccountPropertiesPatch
    {
        // Keep the legacy model instance for older API versions without referencing its type in generated code.
        public object EntraIdConfig { get; set; }

        private void WriteEntraIdConfig(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
#pragma warning disable CS0618
            writer.WriteObjectValue((EntraIdConfigPatch)EntraIdConfig, options);
#pragma warning restore CS0618
        }

        private static void ReadEntraIdConfig(JsonProperty property, ref object value, ModelReaderWriterOptions options)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }

#pragma warning disable CS0618
            value = EntraIdConfigPatch.DeserializeEntraIdConfigPatch(property.Value, options);
#pragma warning restore CS0618
        }
    }
}
