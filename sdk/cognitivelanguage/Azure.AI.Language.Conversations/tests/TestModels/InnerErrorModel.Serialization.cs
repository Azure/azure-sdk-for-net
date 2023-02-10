// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class InnerErrorModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("code");
            writer.WriteStringValue(Code.ToString());
            writer.WritePropertyName("message");
            writer.WriteStringValue(Message);
            if (Optional.IsCollectionDefined(Details))
            {
                writer.WritePropertyName("details");
                writer.WriteStartObject();
                foreach (var item in Details)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Target))
            {
                writer.WritePropertyName("target");
                writer.WriteStringValue(Target);
            }
            if (Optional.IsDefined(Innererror))
            {
                writer.WritePropertyName("innererror");
                writer.WriteObjectValue(Innererror);
            }
            writer.WriteEndObject();
        }

        internal static InnerErrorModel DeserializeInnerErrorModel(JsonElement element)
        {
            InnerErrorCode code = default;
            string message = default;
            Optional<IDictionary<string, string>> details = default;
            Optional<string> target = default;
            Optional<InnerErrorModel> innererror = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = new InnerErrorCode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    details = dictionary;
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    innererror = DeserializeInnerErrorModel(property.Value);
                    continue;
                }
            }
            return new InnerErrorModel(code, message, Optional.ToDictionary(details), target.Value, innererror.Value);
        }
    }
}
