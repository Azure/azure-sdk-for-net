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
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <returns>List of built tool descriptors.</returns>
    public static IReadOnlyList<ResolvedFoundryTool> BuildDescriptors(
        IEnumerable<Dictionary<string, object?>> rawTools,
        FoundryToolSource source,
        HashSet<string> existingNames)
    {
        var descriptors = new List<ResolvedFoundryTool>();

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
            var foundryTool = raw.TryGetValue("foundry_tool", out var td) && td is FoundryTool tDef
                ? tDef
                : null;

            var descriptor = new ResolvedFoundryTool
            {
                Key = key,
                Name = resolvedName,
                Description = description ?? string.Empty,
                Source = source,
                Metadata = raw,
                InputSchema = inputSchema,
                FoundryTool = foundryTool
            };

            descriptors.Add(descriptor);
            existingNames.Add(resolvedName);
        }

        return descriptors;
    }
}
