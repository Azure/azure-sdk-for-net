// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    [CodeGenSerialization(nameof(EnableSubvolumes), "enableSubvolumes",
        SerializationValueHook = nameof(WriteEnableSubvolumes), DeserializationValueHook = nameof(ReadEnableSubvolumes))]
    internal partial class VolumeProperties
    {
        // The current service version omits this member, but callers can still opt into the legacy version.
        public SubvolumeEnablement? EnableSubvolumes { get; set; }

        private void WriteEnableSubvolumes(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(EnableSubvolumes.Value.Value);

        private static void ReadEnableSubvolumes(JsonProperty property, ref SubvolumeEnablement? value)
        {
            value = property.Value.GetString() is string text ? new SubvolumeEnablement(text) : null;
        }
    }
}
