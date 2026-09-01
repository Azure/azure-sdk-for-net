// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Materializes OpenAI models from their wire form. Several of them expose no public
/// constructor, so tests build them the same way the service reads them.
/// </summary>
internal static class OpenAIJson
{
    public static T Read<T>(BinaryData json)
        where T : class, IJsonModel<T>
        => ModelReaderWriter.Read<T>(json, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default)!;

    public static T Read<T>(string json)
        where T : class, IJsonModel<T>
        => Read<T>(BinaryData.FromString(json));

    /// <summary>Reads a JSON array of response items.</summary>
    public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> Items(BinaryData json)
    {
        var items = new System.Collections.Generic.List<OpenAI.Responses.ResponseItem>();
        using var document = System.Text.Json.JsonDocument.Parse(json);
        foreach (var element in document.RootElement.EnumerateArray())
        {
            items.Add(Read<OpenAI.Responses.ResponseItem>(element.GetRawText()));
        }

        return items;
    }

    /// <summary>Reads a JSON array of response items.</summary>
    public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> Items(string json)
        => Items(BinaryData.FromString(json));
}
