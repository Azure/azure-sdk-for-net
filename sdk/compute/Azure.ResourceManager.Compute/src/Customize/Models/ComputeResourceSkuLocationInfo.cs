// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // TEMPORARY: this piece of customized code replaces the ExtendedLocationType with the one in resourcemanager
    public partial class ComputeResourceSkuLocationInfo
    {
        /// <summary> The type of the extended location. </summary>
        [CodeGenMember("ExtendedLocationType")]
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteExtendedLocationType), DeserializationValueHook = nameof(ReadExtendedLocationType))]
        public Azure.ResourceManager.Resources.Models.ExtendedLocationType? ExtendedLocationType { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteExtendedLocationType(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(ExtendedLocationType.Value.ToString());
        }

        // deserialization hook for required property
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadExtendedLocationType(JsonProperty property, ref Optional<Azure.ResourceManager.Resources.Models.ExtendedLocationType> type)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            type = new Azure.ResourceManager.Resources.Models.ExtendedLocationType(property.Value.GetString());
        }
    }
}
