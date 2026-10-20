// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally to support boolean serialization and deserialization from a string value property.
namespace Azure.ResourceManager.WebPubSub.Models
{
    [CodeGenSerialization(nameof(IsEnabled), SerializationValueHook = nameof(SerializationIsEnabled), DeserializationValueHook = nameof(DeserializeIsEnabled))]
    public partial class LiveTraceCategory
    {
        /// <summary> Indicates whether the live trace category is enabled. </summary>
        [CodeGenMember("IsEnabled")]
        [WirePath("enabled")]
        public bool? IsEnabled { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializationIsEnabled(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(IsEnabled.HasValue ? IsEnabled.Value.ToString().ToLower(new System.Globalization.CultureInfo("en-us")) : null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeIsEnabled(JsonProperty property, ref bool? isEnabled)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            isEnabled = bool.Parse(property.Value.GetString());
        }
    }
}
