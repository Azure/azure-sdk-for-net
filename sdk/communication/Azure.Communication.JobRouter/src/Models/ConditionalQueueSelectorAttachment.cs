// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ConditionalQueueSelectorAttachment")]
    public partial class ConditionalQueueSelectorAttachment : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("condition"u8);
            writer.WriteObjectValue(Condition);
            writer.WritePropertyName("queueSelectors"u8);
            writer.WriteStartArray();
            foreach (var item in QueueSelectors)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
