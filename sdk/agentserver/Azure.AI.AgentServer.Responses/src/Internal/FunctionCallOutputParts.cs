// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Models;
using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Preserves the array form of a <c>function_call_output</c> item's <c>output</c>.
/// <para>
/// The wire protocol allows <c>output</c> to be either a string or an array of
/// <c>input_text</c>, <c>input_image</c> and <c>input_file</c> parts, but
/// <see cref="FunctionCallOutputResponseItem"/> models it only as a string and its reader
/// rejects the array form. Before a payload is read, every such array is replaced with the
/// newline-joined text of its text parts, so <see cref="FunctionCallOutputResponseItem.FunctionOutput"/>
/// still exposes the text. After the read, the original array is written back to the item's
/// <c>$.output</c> patch, which the OpenAI writer emits in place of the string. Image and file
/// parts therefore survive persistence, history replay and egress unchanged.
/// </para>
/// </summary>
internal static class FunctionCallOutputParts
{
    private static readonly byte[] OutputPath = "$.output"u8.ToArray();

    /// <summary>
    /// Replaces every array-form <c>function_call_output</c> output in <paramref name="data"/>
    /// with its flattened text.
    /// </summary>
    /// <param name="data">The serialized payload; replaced with the rewritten payload when anything changed.</param>
    /// <returns>The JSON location and original parts of every rewritten output, or <see langword="null"/> when nothing changed.</returns>
    public static List<(object[] Path, JsonArray Parts)>? Flatten(ref BinaryData data)
    {
        if (data.ToMemory().Span.IndexOf("function_call_output"u8) < 0)
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

        List<(object[] Path, JsonArray Parts)>? found = null;
        Walk(root, new List<object>(), ref found);
        if (found is not null)
        {
            data = BinaryData.FromString(root!.ToJsonString());
        }

        return found;
    }

    /// <summary>
    /// Writes the parts captured by <see cref="Flatten"/> back onto the matching
    /// <see cref="FunctionCallOutputResponseItem"/> instances in <paramref name="model"/>.
    /// Locations the model graph does not expose are left with the flattened text.
    /// </summary>
    /// <param name="model">The model read from the flattened payload.</param>
    /// <param name="flattened">The locations and parts returned by <see cref="Flatten"/>.</param>
    public static void Restore(object? model, List<(object[] Path, JsonArray Parts)> flattened)
    {
        foreach (var (path, parts) in flattened)
        {
            object? target = model;
            foreach (var segment in path)
            {
                target = Step(target, segment);
            }

            if (target is FunctionCallOutputResponseItem item)
            {
                SetParts(item, parts);
            }
        }
    }

    /// <summary>
    /// Makes <paramref name="item"/> serialize <paramref name="parts"/> as its <c>output</c>
    /// in place of its string output.
    /// </summary>
    /// <param name="item">The function call output item.</param>
    /// <param name="parts">The content parts to emit.</param>
    public static void SetParts(FunctionCallOutputResponseItem item, JsonArray parts)
        => item.Patch.Set(OutputPath, BinaryData.FromString(parts.ToJsonString()).ToMemory().Span);

    /// <summary>
    /// Interprets a <c>function_call_output</c> output given as JSON: a JSON string yields its
    /// value, an array of content parts yields its flattened text plus the parts, and anything
    /// else (including text that is not JSON) yields the UTF-8 text unchanged.
    /// </summary>
    /// <param name="output">The output value.</param>
    /// <param name="parts">The content parts when <paramref name="output"/> is an array; otherwise <see langword="null"/>.</param>
    /// <returns>The string output.</returns>
    public static string FromJson(BinaryData output, out JsonArray? parts)
    {
        parts = null;
        JsonNode? node;
        try
        {
            node = JsonNode.Parse(output.ToMemory().Span.IsEmpty ? "\"\""u8 : output.ToMemory().Span);
        }
        catch (JsonException)
        {
            return output.ToString();
        }

        switch (node)
        {
            case JsonValue value when value.TryGetValue<string>(out var text):
                return text;
            case JsonArray array:
                parts = array;
                return FlattenText(array);
            default:
                return output.ToString();
        }
    }

    /// <summary>Joins the text of an output's content parts the way the string form carries it.</summary>
    /// <param name="parts">The content parts.</param>
    /// <returns>The newline-joined text of every part that has one.</returns>
    public static string FlattenText(JsonArray parts)
    {
        var texts = new List<string>();
        foreach (var part in parts)
        {
            if (part is JsonObject partObject && partObject["text"] is JsonValue partText &&
                partText.TryGetValue<string>(out var text))
            {
                texts.Add(text);
            }
        }

        return string.Join("\n", texts);
    }

    private static void Walk(JsonNode? node, List<object> path, ref List<(object[] Path, JsonArray Parts)>? found)
    {
        switch (node)
        {
            case JsonObject obj:
                if (obj["type"] is JsonValue type && type.TryGetValue<string>(out var itemType) &&
                    itemType == "function_call_output" && obj["output"] is JsonArray parts)
                {
                    obj["output"] = FlattenText(parts);
                    (found ??= new()).Add((path.ToArray(), parts));
                    return;
                }

                foreach (var property in obj.ToArray())
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

    private static object? Step(object? current, object segment) => (current, segment) switch
    {
        (IList list, int index) => index < list.Count ? list[index] : null,
        (CreateResponseOptions options, "input") => options.InputItems,
        (ResponseResult response, "output") => response.OutputItems,
        (AgentsPagedResultOutputItem page, "data") => page.Data,
        (StreamingResponseOutputItemAddedUpdate update, "item") => update.Item,
        (StreamingResponseOutputItemDoneUpdate update, "item") => update.Item,
        (StreamingResponseUpdate update, "response") =>
            update.GetType().GetProperty(nameof(StreamingResponseCreatedUpdate.Response))?.GetValue(update),
        _ => null,
    };
}
