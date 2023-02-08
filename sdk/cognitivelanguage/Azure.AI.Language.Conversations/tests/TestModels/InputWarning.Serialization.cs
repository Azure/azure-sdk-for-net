// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class InputWarning : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("code");
            writer.WriteStringValue(Code);
            writer.WritePropertyName("message");
            writer.WriteStringValue(Message);
            if (Optional.IsDefined(TargetRef))
            {
                writer.WritePropertyName("targetRef");
                writer.WriteStringValue(TargetRef);
            }
            writer.WriteEndObject();
        }

        internal static InputWarning DeserializeInputWarning(JsonElement element)
        {
            string code = default;
            string message = default;
            Optional<string> targetRef = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetRef"))
                {
                    targetRef = property.Value.GetString();
                    continue;
                }
            }
            return new InputWarning(code, message, targetRef.Value);
        }
    }
}
