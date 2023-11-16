// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace OpenAI;

public class Choice
{
    public string? Text { get; internal set; }
    public int Index { get; internal set; }

    internal static Choice Deserialize(JsonElement choiceJson)
    {
        Choice choice = new Choice();
        choice.Index = choiceJson.GetProperty("index").GetInt32();
        choice.Text = choiceJson.GetProperty("text").GetString();
        return choice;
    }
}
