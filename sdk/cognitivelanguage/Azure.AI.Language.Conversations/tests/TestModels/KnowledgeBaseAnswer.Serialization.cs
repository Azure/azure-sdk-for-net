// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class KnowledgeBaseAnswer
    {
        internal static KnowledgeBaseAnswer DeserializeKnowledgeBaseAnswer(JsonElement element)
        {
            Optional<IReadOnlyList<string>> questions = default;
            Optional<string> answer = default;
            Optional<double> confidenceScore = default;
            Optional<int> id = default;
            Optional<string> source = default;
            Optional<IReadOnlyDictionary<string, string>> metadata = default;
            Optional<KnowledgeBaseAnswerDialog> dialog = default;
            Optional<AnswerSpan> answerSpan = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("questions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    questions = array;
                    continue;
                }
                if (property.NameEquals("answer"))
                {
                    answer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("confidenceScore"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    confidenceScore = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("source"))
                {
                    source = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("metadata"))
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
                    metadata = dictionary;
                    continue;
                }
                if (property.NameEquals("dialog"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dialog = KnowledgeBaseAnswerDialog.DeserializeKnowledgeBaseAnswerDialog(property.Value);
                    continue;
                }
                if (property.NameEquals("answerSpan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    answerSpan = AnswerSpan.DeserializeAnswerSpan(property.Value);
                    continue;
                }
            }
            return new KnowledgeBaseAnswer(Optional.ToList(questions), answer.Value, Optional.ToNullable(confidenceScore), Optional.ToNullable(id), source.Value, Optional.ToDictionary(metadata), dialog.Value, answerSpan.Value);
        }
    }
}
