// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Platform.OpenAI
{
    public class Completions
    {
        public IReadOnlyList<Choice> Choices { get; internal set; }
        public DateTimeOffset Created { get; internal set; }
        public string Id { get; internal set; }

        internal static Completions Deserialize(JsonElement element)
        {
            Completions completions = new();
            completions.Id = element.GetProperty("id").GetString();
            completions.Created = DateTimeOffset.FromUnixTimeSeconds(element.GetProperty("created").GetInt64());

            List<Choice> choices = new();
            foreach (JsonElement choiceJson in element.GetProperty("choices").EnumerateArray())
            {
                choices.Add(Choice.Deserialize(choiceJson));
            }
            completions.Choices = choices;
            return completions;
        }
    }
}
