// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class KnowledgeBaseAnswerDialog
    {
        internal static KnowledgeBaseAnswerDialog DeserializeKnowledgeBaseAnswerDialog(JsonElement element)
        {
            Optional<bool> isContextOnly = default;
            Optional<IReadOnlyList<KnowledgeBaseAnswerPrompt>> prompts = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isContextOnly"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isContextOnly = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("prompts"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<KnowledgeBaseAnswerPrompt> array = new List<KnowledgeBaseAnswerPrompt>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(KnowledgeBaseAnswerPrompt.DeserializeKnowledgeBaseAnswerPrompt(item));
                    }
                    prompts = array;
                    continue;
                }
            }
            return new KnowledgeBaseAnswerDialog(Optional.ToNullable(isContextOnly), Optional.ToList(prompts));
        }
    }
}
