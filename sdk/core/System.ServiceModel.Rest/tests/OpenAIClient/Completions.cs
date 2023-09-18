// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI;

public class Completions
{
    public IReadOnlyList<Choice> Choices { get; internal set; }
    public DateTimeOffset Created { get; internal set; }
    public string Id { get; internal set; }

    internal static Completions Deserialize(BinaryData data)
    {
        using JsonDocument document = JsonDocument.Parse(data);
        JsonElement json = document.RootElement;
        var completions = new Completions();
        completions.Id = json.GetProperty("id").GetString();
        completions.Created = DateTimeOffset.FromUnixTimeSeconds(json.GetProperty("created").GetInt64());

        var choices = new List<Choice>();
        foreach (JsonElement choiceJson in json.GetProperty("choices").EnumerateArray())
        {
            choices.Add(Choice.Deserialize(choiceJson));
        }
        completions.Choices = choices;
        return completions;
    }
}
