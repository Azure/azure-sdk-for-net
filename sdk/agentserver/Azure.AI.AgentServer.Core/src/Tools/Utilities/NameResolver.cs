// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Resolves tool names to ensure uniqueness.
/// </summary>
internal static class NameResolver
{
    /// <summary>
    /// Ensures a tool name is unique by adding a numeric suffix if needed.
    /// </summary>
    /// <param name="proposedName">The proposed tool name.</param>
    /// <param name="existingNames">Set of existing tool names.</param>
    /// <returns>A unique tool name.</returns>
    public static string EnsureUniqueName(string proposedName, HashSet<string> existingNames)
    {
        if (!existingNames.Contains(proposedName))
        {
            return proposedName;
        }

        var suffix = 1;
        while (true)
        {
            var candidate = $"{proposedName}_{suffix}";
            if (!existingNames.Contains(candidate))
            {
                return candidate;
            }
            suffix++;
        }
    }
}
