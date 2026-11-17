// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json;
using System.Text.Json.Nodes;
using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Preserves the object form of <c>created_by</c> on <c>custom_tool_call</c> and
/// <c>custom_tool_call_output</c> items.
/// <para>
/// The wire protocol allows <c>created_by</c> to be either a string or a <c>CreatedBy</c> object,
/// but OpenAI's <see cref="ResponseItem"/> reader dispatches these item kinds to
/// <see cref="CustomToolCallItem"/> and <see cref="CustomToolCallOutputItem"/>, which read
/// <c>created_by</c> only as a string and throw on the object form
/// (openai/openai-dotnet#1498). Before a payload is read, every such object is removed; after the
/// read, it is written back to the item's <c>$.created_by</c> patch, which the OpenAI writer emits
/// once and <c>ResponseItem.CreatedBy</c> returns. Remove this once the OpenAI reader accepts the
/// object form.
/// </para>
/// </summary>
internal static class CustomToolCallCreatedBy
{
    private static readonly byte[] CreatedByPath = "$.created_by"u8.ToArray();

    /// <summary>
    /// Removes every object-form <c>created_by</c> from <c>custom_tool_call</c> and
    /// <c>custom_tool_call_output</c> items in <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The serialized payload; replaced with the rewritten payload when anything changed.</param>
    /// <returns>The JSON location and original value of every removed <c>created_by</c>, or <see langword="null"/> when nothing changed.</returns>
    public static List<(object[] Path, JsonObject CreatedBy)>? Strip(ref BinaryData data)
    {
        if (!MayContain(data.ToMemory().Span))
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

        List<(object[] Path, JsonObject CreatedBy)>? found = null;
        Walk(root, new List<object>(), ref found);
        if (found is not null)
        {
            data = BinaryData.FromString(root!.ToJsonString());
        }

        return found;
    }

    /// <summary>
    /// Writes the values captured by <see cref="Strip"/> back onto the matching OpenAI custom tool
    /// call items in <paramref name="model"/>.
    /// </summary>
    /// <param name="model">The model read from the stripped payload.</param>
    /// <param name="stripped">The locations and values returned by <see cref="Strip"/>.</param>
    public static void Restore(object? model, List<(object[] Path, JsonObject CreatedBy)> stripped)
    {
#pragma warning disable OPENAI001
        foreach (var (path, createdBy) in stripped)
        {
            if (FunctionCallOutputParts.Navigate(model, path) is ResponseItem item and (CustomToolCallItem or CustomToolCallOutputItem))
            {
                item.Patch.Set(CreatedByPath, BinaryData.FromString(createdBy.ToJsonString()).ToMemory().Span);
            }
        }
#pragma warning restore OPENAI001
    }

    /// <summary>Returns whether a payload may contain a custom tool call item.</summary>
    /// <param name="utf8Json">The serialized payload.</param>
    /// <returns><see langword="true"/> when the payload mentions <c>custom_tool_call</c>.</returns>
    public static bool MayContain(ReadOnlySpan<byte> utf8Json) => utf8Json.IndexOf("custom_tool_call"u8) >= 0;

    private static void Walk(JsonNode? node, List<object> path, ref List<(object[] Path, JsonObject CreatedBy)>? found)
    {
        switch (node)
        {
            case JsonObject obj:
                if (obj["type"] is JsonValue type && type.TryGetValue<string>(out var itemType) &&
                    itemType is "custom_tool_call" or "custom_tool_call_output" &&
                    obj["created_by"] is JsonObject createdBy)
                {
                    obj.Remove("created_by");
                    (found ??= new()).Add((path.ToArray(), createdBy));
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
}
