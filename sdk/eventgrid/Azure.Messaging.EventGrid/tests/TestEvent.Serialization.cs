// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Tests
{
    internal partial class TestEvent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(id);
            writer.WritePropertyName("topic");
            writer.WriteStringValue(topic);
            writer.WritePropertyName("subject");
            writer.WriteStringValue(subject);
            writer.WritePropertyName("eventType");
            writer.WriteStringValue(eventType);
            writer.WritePropertyName("eventTime");
            writer.WriteStringValue(eventTime, "O");
            writer.WritePropertyName("dataVersion");
            writer.WriteStringValue(dataVersion);
            writer.WriteEndObject();
        }
    }
}
