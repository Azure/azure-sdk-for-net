// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Builds ResolvedFoundryTool objects from raw tool data.
/// </summary>
internal static class ToolDescriptorBuilder
{
    /// <summary>
    /// Builds tool descriptors from raw tool data.
    /// </summary>
    /// <param name="rawTools">Raw tool data from API.</param>
    /// <param name="source">Source of the tools.</param>
    /// <returns>List of built tool descriptors.</returns>
    public static IReadOnlyList<ResolvedFoundryTool> BuildDescriptors(
        IEnumerable<Dictionary<string, object?>> rawTools,
        FoundryToolSource source)
    {
        var descriptors = new List<ResolvedFoundryTool>();

        foreach (var raw in rawTools)
        {
            var (name, description) = ToolMetadataExtractor.ExtractNameDescription(raw);
            if (string.IsNullOrEmpty(name))
            {
                continue;
            }

            var inputSchema = ToolMetadataExtractor.ExtractInputSchema(raw);
            var foundryTool = raw.TryGetValue("foundry_tool", out var td) && td is FoundryTool tDef
                ? tDef
                : null;

            var descriptor = new ResolvedFoundryTool
            {
                Name = name,
                Description = description ?? string.Empty,
                Metadata = raw,
                InputSchema = inputSchema,
                FoundryTool = foundryTool
            };

            descriptors.Add(descriptor);
        }

        return descriptors;
    }
}
