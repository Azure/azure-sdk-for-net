// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Result of classifying a build error against the deterministic fix registry.
/// </summary>
public sealed class ClassifiedError
{
    /// <summary>
    /// The original build error.
    /// </summary>
    [JsonPropertyName("error")]
    public BuildError Error { get; set; } = new();

    /// <summary>
    /// Whether this error can be fixed deterministically.
    /// </summary>
    [JsonPropertyName("isDeterministic")]
    public bool IsDeterministic { get; set; }

    /// <summary>
    /// The tool to use for fixing this error, if deterministic.
    /// </summary>
    [JsonPropertyName("toolName")]
    public string? ToolName { get; set; }

    /// <summary>
    /// The arguments to pass to the tool, if deterministic.
    /// </summary>
    [JsonPropertyName("toolArgs")]
    public Dictionary<string, string>? ToolArgs { get; set; }

    /// <summary>
    /// Human-readable reason for the classification.
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = string.Empty;
}
