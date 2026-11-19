// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json;
using System.Text.Json.Nodes;
using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Preserves the string form of <c>output</c> on <c>custom_tool_call_output</c> items.
/// <para>
/// The wire protocol allows <c>output</c> to be either a string or an array of content parts, but
/// <see cref="CustomToolCallOutputItem"/> reads a string into a single <c>input_text</c> part and
/// writes it back as an array, changing the wire shape on round-trip. After a payload is read,
/// every string <c>output</c> is written back to the item's <c>$.output</c> patch, which the OpenAI
/// writer emits in place of the parsed parts. <see cref="CustomToolCallOutputItem.Output"/> still
/// returns the parsed part.
/// </para>
/// </summary>
internal static class CustomToolCallOutputString
{
    private static readonly byte[] OutputPath = "$.output"u8.ToArray();

    /// <summary>
    /// Finds every string <c>output</c> on <c>custom_tool_call_output</c> items in <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The serialized payload; not modified.</param>
    /// <returns>The JSON location and serialized string of every match, or <see langword="null"/> when there is none.</returns>
    public static List<(object[] Path, string Output)>? Capture(BinaryData data)
    {
        if (data.ToMemory().Span.IndexOf("custom_tool_call_output"u8) < 0)
        {
            return null;
        }

        JsonNode? root;
        try
        {
            root = JsonNode.Parse(data.ToStream());
        }
        catch (JsonException)
        {
            return null;
        }

        List<(object[] Path, string Output)>? found = null;
        Walk(root, new List<object>(), ref found);
        return found;
    }

    /// <summary>
    /// Writes the values captured by <see cref="Capture"/> back onto the matching items in <paramref name="model"/>.
    /// </summary>
    /// <param name="model">The model read from the payload.</param>
    /// <param name="captured">The locations and values returned by <see cref="Capture"/>.</param>
    public static void Restore(object? model, List<(object[] Path, string Output)> captured)
    {
#pragma warning disable OPENAI001
        foreach (var (path, output) in captured)
        {
            if (FunctionCallOutputParts.Navigate(model, path) is CustomToolCallOutputItem item)
            {
                item.Patch.Set(OutputPath, BinaryData.FromString(output).ToMemory().Span);
            }
        }
#pragma warning restore OPENAI001
    }

    private static void Walk(JsonNode? node, List<object> path, ref List<(object[] Path, string Output)>? found)
    {
        switch (node)
        {
            case JsonObject obj:
                if (obj["type"] is JsonValue type && type.TryGetValue<string>(out var itemType) &&
                    itemType == "custom_tool_call_output" &&
                    obj["output"] is JsonValue output && output.GetValueKind() == JsonValueKind.String)
                {
                    (found ??= new()).Add((path.ToArray(), output.ToJsonString()));
                    return;
                }

                foreach (var property in obj)
                {
                    path.Add(property.Key);
                    Walk(property.Value, path, ref found);
                    path.RemoveAt(path.Count - 1);
                }

                break;

            case JsonArray array:
                for (var i = 0; i < array.Count; i++)
                {
                    path.Add(i);
                    Walk(array[i], path, ref found);
                    path.RemoveAt(path.Count - 1);
                }

                break;
        }
    }
}
