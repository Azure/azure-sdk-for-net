// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI
{
    internal class ChatMessageConverter : JsonConverter<ChatMessage>
    {
        public override ChatMessage Read(ref Utf8JsonReader reader, Type _, JsonSerializerOptions __)
        {
            Dictionary<string, string> dictionary
                = JsonSerializer.Deserialize<Dictionary<string, string>>(ref reader);
            dictionary.TryGetValue("role", out string role);
            dictionary.TryGetValue("content", out string content);
            return new ChatMessage(role, content);
        }

        public override void Write(Utf8JsonWriter writer, ChatMessage value, JsonSerializerOptions __)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary["role"] = value.Role.ToString();
            dictionary["content"] = value.Content.ToString();
            JsonSerializer.Serialize(writer, dictionary);
        }
    }
}
