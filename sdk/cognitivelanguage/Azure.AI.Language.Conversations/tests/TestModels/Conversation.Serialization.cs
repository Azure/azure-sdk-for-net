// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class Conversation : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("language");
            writer.WriteStringValue(Language);
            writer.WritePropertyName("modality");
            writer.WriteStringValue(Modality.ToString());
            if (Optional.IsDefined(Domain))
            {
                writer.WritePropertyName("domain");
                writer.WriteStringValue(Domain.Value.ToString());
            }
            writer.WriteEndObject();
        }
    }
}
