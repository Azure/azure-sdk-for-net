// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Adds JSON serialization support so that <c>BinaryData.FromObjectAsJson(MCPApprovalType.Never)</c>
    /// correctly serializes to <c>"never"</c> on the wire instead of an empty object.
    /// </summary>
    [JsonConverter(typeof(MCPApprovalTypeJsonConverter))]
    public readonly partial struct MCPApprovalType
    {
        internal class MCPApprovalTypeJsonConverter : JsonConverter<MCPApprovalType>
        {
            public override MCPApprovalType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new MCPApprovalType(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, MCPApprovalType value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
