// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of the commit_iteration tool.
/// </summary>
public sealed class CommitIterationResult
{
    /// <summary>Whether a valid commit was found (or fallback created).</summary>
    public bool Success { get; set; }

    /// <summary>The resolved commit SHA (when Success is true).</summary>
    public string? Commit { get; set; }

    /// <summary>Human-readable message describing what happened.</summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// When true, indicates the tool exhausted all remote candidates and needs a local specs path
    /// to create a fallback commit. The caller should ask the user for the path and re-call with localSpecsPath.
    /// </summary>
    public bool NeedsLocalSpecsPath { get; set; }
}
