// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Provides deterministic path validation to prevent modifications to Generated/ directories.
/// All MCP tools that modify files MUST call <see cref="ValidateNotGenerated"/> before writing.
/// </summary>
internal static class GeneratedPathGuard
{
    private static readonly char[] s_separators = [Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar];

    /// <summary>
    /// Checks whether <paramref name="filePath"/> resides inside a directory named "Generated".
    /// Uses segment-level matching to avoid false positives (e.g., "MyGenerated/" won't match).
    /// </summary>
    internal static bool IsInGeneratedDirectory(string filePath)
    {
        var normalized = Path.GetFullPath(filePath);
        var segments = normalized.Split(s_separators, StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < segments.Length - 1; i++) // -1: last segment is the filename
        {
            if (string.Equals(segments[i], "Generated", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns an error message if <paramref name="filePath"/> is inside a Generated/ directory;
    /// otherwise returns <c>null</c>.
    /// </summary>
    internal static string? ValidateNotGenerated(string filePath)
    {
        return IsInGeneratedDirectory(filePath)
            ? $"Refusing to modify file in Generated/ directory: {Path.GetFullPath(filePath)}. " +
              "Generated code must not be edited directly — fix the generator input or custom code instead."
            : null;
    }
}
