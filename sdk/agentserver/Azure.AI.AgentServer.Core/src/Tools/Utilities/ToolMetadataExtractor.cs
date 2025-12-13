// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Extracts metadata from raw tool data.
/// </summary>
internal static class ToolMetadataExtractor
{
    /// <summary>
    /// Extracts name and description from raw tool data.
    /// </summary>
    /// <param name="raw">The raw tool data.</param>
    /// <returns>A tuple containing the name and description.</returns>
    public static (string? Name, string? Description) ExtractNameDescription(
        IReadOnlyDictionary<string, object?> raw)
    {
        var name = TryGetValue(raw, "name", "id", "tool_name", "definition.name", "tool.name");
        var description = TryGetValue(raw, "description", "long_description",
            "definition.description", "tool.description");

        return (name, description);
    }

    /// <summary>
    /// Derives a unique key for a tool.
    /// </summary>
    /// <param name="raw">The raw tool data.</param>
    /// <param name="source">The tool source.</param>
    /// <returns>A unique tool key.</returns>
    public static string DeriveToolKey(IReadOnlyDictionary<string, object?> raw, ToolSource source)
    {
        var candidate = TryGetValue(raw, "id", "name", "tool_name");
        return candidate != null
            ? $"{source}:{candidate}"
            : $"{source}:{raw.GetHashCode()}";
    }

    /// <summary>
    /// Extracts input schema from raw tool data.
    /// </summary>
    /// <param name="raw">The raw tool data.</param>
    /// <returns>The input schema if found, otherwise null.</returns>
    public static IReadOnlyDictionary<string, object?>? ExtractInputSchema(
        IReadOnlyDictionary<string, object?> raw)
    {
        // Try direct properties first
        foreach (var key in new[] { "input_schema", "inputSchema", "schema", "parameters" })
        {
            if (raw.TryGetValue(key, out var value) && value is Dictionary<string, object?> dict)
            {
                return dict;
            }
        }

        // Try nested
        if (raw.TryGetValue("definition", out var def) && def is Dictionary<string, object?> defDict)
        {
            return ExtractInputSchema(defDict);
        }

        if (raw.TryGetValue("tool", out var tool) && tool is Dictionary<string, object?> toolDict)
        {
            return ExtractInputSchema(toolDict);
        }

        return null;
    }

    /// <summary>
    /// Extracts metadata schema from raw tool data.
    /// </summary>
    /// <param name="raw">The raw tool data.</param>
    /// <returns>The metadata schema if found, otherwise null.</returns>
    public static IReadOnlyDictionary<string, object?>? ExtractMetadataSchema(
        IReadOnlyDictionary<string, object?> raw)
    {
        foreach (var key in new[] { "_meta", "metadata", "meta" })
        {
            if (raw.TryGetValue(key, out var value) && value is Dictionary<string, object?> dict)
            {
                return dict;
            }
        }
        return null;
    }

    private static string? TryGetValue(IReadOnlyDictionary<string, object?> dict, params string[] keys)
    {
        foreach (var key in keys)
        {
            if (key.Contains('.'))
            {
                // Handle nested properties like "definition.name"
                var parts = key.Split('.');
                object? current = dict;
                foreach (var part in parts)
                {
                    if (current is IReadOnlyDictionary<string, object?> currentDict &&
                        currentDict.TryGetValue(part, out var next))
                    {
                        current = next;
                    }
                    else
                    {
                        current = null;
                        break;
                    }
                }
                if (current != null)
                {
                    return current.ToString();
                }
            }
            else if (dict.TryGetValue(key, out var value) && value != null)
            {
                return value.ToString();
            }
        }
        return null;
    }
}
