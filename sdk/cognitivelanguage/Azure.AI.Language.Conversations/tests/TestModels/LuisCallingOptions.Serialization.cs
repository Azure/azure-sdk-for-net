// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class LuisCallingOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Verbose))
            {
                writer.WritePropertyName("verbose");
                writer.WriteBooleanValue(Verbose.Value);
            }
            if (Optional.IsDefined(Log))
            {
                writer.WritePropertyName("log");
                writer.WriteBooleanValue(Log.Value);
            }
            if (Optional.IsDefined(ShowAllIntents))
            {
                writer.WritePropertyName("show-all-intents");
                writer.WriteBooleanValue(ShowAllIntents.Value);
            }
            if (Optional.IsDefined(TimezoneOffset))
            {
                writer.WritePropertyName("timezoneOffset");
                writer.WriteNumberValue(TimezoneOffset.Value);
            }
            if (Optional.IsDefined(SpellCheck))
            {
                writer.WritePropertyName("spellCheck");
                writer.WriteBooleanValue(SpellCheck.Value);
            }
            if (Optional.IsDefined(BingSpellCheckSubscriptionKey))
            {
                writer.WritePropertyName("bing-spell-check-subscription-key");
                writer.WriteStringValue(BingSpellCheckSubscriptionKey);
            }
            writer.WriteEndObject();
        }
    }
}
