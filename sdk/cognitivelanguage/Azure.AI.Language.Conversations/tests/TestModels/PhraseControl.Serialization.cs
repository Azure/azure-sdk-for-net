// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class PhraseControl : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("targetPhrase");
            writer.WriteStringValue(TargetPhrase);
            writer.WritePropertyName("strategy");
            writer.WriteStringValue(Strategy.ToSerialString());
            writer.WriteEndObject();
        }

        internal static PhraseControl DeserializePhraseControl(JsonElement element)
        {
            string targetPhrase = default;
            PhraseControlStrategy strategy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("targetPhrase"))
                {
                    targetPhrase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("strategy"))
                {
                    strategy = property.Value.GetString().ToPhraseControlStrategy();
                    continue;
                }
            }
            return new PhraseControl(targetPhrase, strategy);
        }
    }
}
