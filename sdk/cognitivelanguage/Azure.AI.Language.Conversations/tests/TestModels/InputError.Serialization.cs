// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class InputError : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("error");
            writer.WriteObjectValue(Error);
            writer.WriteEndObject();
        }

        internal static InputError DeserializeInputError(JsonElement element)
        {
            string id = default;
            Error error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    error = Error.DeserializeError(property.Value);
                    continue;
                }
            }
            return new InputError(id, error);
        }
    }
}
