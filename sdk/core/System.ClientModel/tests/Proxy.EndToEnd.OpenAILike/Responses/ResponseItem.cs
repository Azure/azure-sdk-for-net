// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace OpenAILike.Responses
{
    /// <summary>Mock input item for <see cref="CreateResponseOptions"/>.</summary>
    public class ResponseItem
    {
        private readonly string _role;
        private readonly string _text;

        private ResponseItem(string role, string text)
        {
            _role = role;
            _text = text;
        }

        public static ResponseItem CreateUserMessageItem(string text) => new("user", text);

        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteString("type"u8, "message");
            writer.WriteString("role"u8, _role);
            writer.WriteString("content"u8, _text);
            writer.WriteEndObject();
        }
    }
}
