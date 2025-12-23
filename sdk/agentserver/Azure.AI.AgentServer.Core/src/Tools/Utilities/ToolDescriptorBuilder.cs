// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Builds FoundryTool objects from raw tool data.
/// </summary>
internal static class ToolDescriptorBuilder
{
    /// <summary>
    /// Builds tool descriptors from raw tool data.
    /// </summary>
    /// <param name="rawTools">Raw tool data from API.</param>
    /// <param name="source">Source of the tools.</param>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <returns>List of built tool descriptors.</returns>
    public static IReadOnlyList<FoundryTool> BuildDescriptors(
        IEnumerable<Dictionary<string, object?>> rawTools,
        ToolSource source,
        HashSet<string> existingNames)
    {
        var descriptors = new List<FoundryTool>();

        foreach (var raw in rawTools)
        {
            var (name, description) = ToolMetadataExtractor.ExtractNameDescription(raw);
            if (string.IsNullOrEmpty(name))
            {
                continue;
            }

            var key = ToolMetadataExtractor.DeriveToolKey(raw, source);
            var resolvedName = NameResolver.EnsureUniqueName(name, existingNames);
            var inputSchema = ToolMetadataExtractor.ExtractInputSchema(raw);
            var toolDefinition = raw.TryGetValue("tool_definition", out var td) && td is ToolDefinition tDef
                ? tDef
                : null;

            var descriptor = new FoundryTool
            {
                Key = key,
                Name = resolvedName,
                Description = description ?? string.Empty,
                Source = source,
                Metadata = raw,
                InputSchema = inputSchema,
                ToolDefinition = toolDefinition
            };

            descriptors.Add(descriptor);
            existingNames.Add(resolvedName);
        }

        return descriptors;
    }
}
