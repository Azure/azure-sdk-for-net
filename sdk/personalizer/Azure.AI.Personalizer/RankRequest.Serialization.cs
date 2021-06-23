// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer.Models
{
    public partial class RankRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ContextFeatures != null)
            {
                writer.WritePropertyName("contextFeatures");
                writer.WriteStartArray();
                foreach (var item in ContextFeatures)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("actions");
            writer.WriteStartArray();
            foreach (var item in Actions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (ExcludedActions != null)
            {
                writer.WritePropertyName("excludedActions");
                writer.WriteStartArray();
                foreach (var item in ExcludedActions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (EventId != null)
            {
                writer.WritePropertyName("eventId");
                writer.WriteStringValue(EventId);
            }
            if (DeferActivation != null)
            {
                writer.WritePropertyName("deferActivation");
                writer.WriteBooleanValue(DeferActivation.Value);
            }
            writer.WriteEndObject();
        }
    }
}
