// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationCallingOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language");
                writer.WriteStringValue(Language);
            }
            if (Optional.IsDefined(Verbose))
            {
                writer.WritePropertyName("verbose");
                writer.WriteBooleanValue(Verbose.Value);
            }
            if (Optional.IsDefined(IsLoggingEnabled))
            {
                writer.WritePropertyName("isLoggingEnabled");
                writer.WriteBooleanValue(IsLoggingEnabled.Value);
            }
            writer.WriteEndObject();
        }
    }
}
