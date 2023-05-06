// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("LiveEventInput")]

namespace Azure.ResourceManager.Media.Models
{
    public partial class LiveEventInput : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("streamingProtocol"u8);
            writer.WriteStringValue(StreamingProtocol.ToString());
            if (Optional.IsDefined(AccessControl))
            {
                if (AccessControl != null)
                {
                    writer.WritePropertyName("accessControl"u8);
                    writer.WriteObjectValue(AccessControl);
                }
                else
                {
                    writer.WriteNull("accessControl");
                }
            }
            if (Optional.IsDefined(KeyFrameIntervalDuration))
            {
                writer.WritePropertyName("keyFrameIntervalDuration"u8);
                writer.WriteStringValue(KeyFrameIntervalDuration.Value, "P");
            }
            if (Optional.IsDefined(AccessToken))
            {
                writer.WritePropertyName("accessToken"u8);
                writer.WriteStringValue(AccessToken);
            }
            if (Optional.IsCollectionDefined(Endpoints))
            {
                writer.WritePropertyName("endpoints"u8);
                writer.WriteStartArray();
                foreach (var item in Endpoints)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static LiveEventInput DeserializeLiveEventInput(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LiveEventInputProtocol streamingProtocol = default;
            Optional<LiveEventInputAccessControl> accessControl = default;
            Optional<TimeSpan> keyFrameIntervalDuration = default;
            Optional<string> accessToken = default;
            Optional<IList<LiveEventEndpoint>> endpoints = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("streamingProtocol"u8))
                {
                    streamingProtocol = new LiveEventInputProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("accessControl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        accessControl = null;
                        continue;
                    }
                    accessControl = LiveEventInputAccessControl.DeserializeLiveEventInputAccessControl(property.Value);
                    continue;
                }
                if (property.NameEquals("keyFrameIntervalDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    if (property.Value.ValueKind == JsonValueKind.String && String.IsNullOrWhiteSpace(property.Value.GetString()))
                    {
                        keyFrameIntervalDuration = default;
                        continue;
                    }
                    keyFrameIntervalDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("accessToken"u8))
                {
                    accessToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<LiveEventEndpoint> array = new List<LiveEventEndpoint>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(LiveEventEndpoint.DeserializeLiveEventEndpoint(item));
                    }
                    endpoints = array;
                    continue;
                }
            }
            return new LiveEventInput(streamingProtocol, accessControl.Value, Optional.ToNullable(keyFrameIntervalDuration), accessToken.Value, Optional.ToList(endpoints));
        }
    }
}
