// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI
{
    internal class ChatRoleConverter : JsonConverter<ChatRole>
    {
        public override ChatRole Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions __)
            => new ChatRole(reader.GetString());

        public override void Write(Utf8JsonWriter writer, ChatRole value, JsonSerializerOptions _)
            => writer.WriteStringValue(value.ToString());
    }
}
