// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class TaskState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("lastUpdateDateTime");
            writer.WriteStringValue(LastUpdateDateTime, "O");
            writer.WritePropertyName("status");
            writer.WriteStringValue(Status.ToString());
            writer.WriteEndObject();
        }

        internal static TaskState DeserializeTaskState(JsonElement element)
        {
            DateTimeOffset lastUpdateDateTime = default;
            State status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lastUpdateDateTime"))
                {
                    lastUpdateDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = new State(property.Value.GetString());
                    continue;
                }
            }
            return new TaskState(lastUpdateDateTime, status);
        }
    }
}
