// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationEntity
    {
        internal static ConversationEntity DeserializeConversationEntity(JsonElement element)
        {
            string category = default;
            string text = default;
            int offset = default;
            int length = default;
            float confidenceScore = default;
            Optional<IReadOnlyList<BaseResolution>> resolutions = default;
            Optional<IReadOnlyList<BaseExtraInformation>> extraInformation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("category"))
                {
                    category = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offset"))
                {
                    offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    length = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("confidenceScore"))
                {
                    confidenceScore = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("resolutions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<BaseResolution> array = new List<BaseResolution>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BaseResolution.DeserializeBaseResolution(item));
                    }
                    resolutions = array;
                    continue;
                }
                if (property.NameEquals("extraInformation"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<BaseExtraInformation> array = new List<BaseExtraInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BaseExtraInformation.DeserializeBaseExtraInformation(item));
                    }
                    extraInformation = array;
                    continue;
                }
            }
            return new ConversationEntity(category, text, offset, length, confidenceScore, Optional.ToList(resolutions), Optional.ToList(extraInformation));
        }
    }
}
