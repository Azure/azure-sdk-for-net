// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// A single rule that maps an error code + message pattern to a deterministic fix.
/// </summary>
public sealed class FixRule
{
    /// <summary>
    /// The C# error code this rule matches (e.g., "CS0246", "CS1061"). Null matches any code.
    /// </summary>
    public string? ErrorCode { get; init; }

    /// <summary>
    /// Regex pattern to match against the error message.
    /// </summary>
    public Regex MessagePattern { get; init; } = null!;

    /// <summary>
    /// The MCP tool name to invoke for this fix. Null for non-deterministic hint-only rules.
    /// </summary>
    public string? ToolName { get; init; }

    /// <summary>
    /// Whether this rule provides a deterministic (tool-based) fix or just a classification hint.
    /// Defaults to true for backward compatibility. Set to false for ApiCompat hint rules.
    /// </summary>
    public bool IsDeterministic { get; init; } = true;

    /// <summary>
    /// Human-readable description of what this rule fixes.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Function that extracts tool arguments from the error and regex match.
    /// </summary>
    public Func<BuildError, Match, Dictionary<string, string>> ExtractArgs { get; init; } = (_, _) => new();
}
