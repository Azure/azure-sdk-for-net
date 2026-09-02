// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Batch
{
    [CodeGenSerialization(nameof(Location), SerializationValueHook = nameof(WriteLocation), DeserializationValueHook = nameof(ReadLocation))]
    public partial class BatchAccountData
    {
        private void WriteLocation(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Location.HasValue)
            {
                writer.WriteStringValue(Location.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        private static void ReadLocation(JsonProperty property, ref AzureLocation? location)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                location = new AzureLocation(property.Value.GetString());
            }
        }
    }
}
