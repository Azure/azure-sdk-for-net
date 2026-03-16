// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Represents a single build error or warning parsed from MSBuild output.
/// </summary>
public sealed class BuildError
{
    /// <summary>
    /// The file path where the error occurred.
    /// </summary>
    [JsonPropertyName("filePath")]
    public string FilePath { get; set; } = string.Empty;

    /// <summary>
    /// The line number of the error (1-based).
    /// </summary>
    [JsonPropertyName("line")]
    public int Line { get; set; }

    /// <summary>
    /// The column number of the error (1-based).
    /// </summary>
    [JsonPropertyName("column")]
    public int Column { get; set; }

    /// <summary>
    /// The error or warning code (e.g., CS0246, CS1061).
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// The error or warning message text.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Whether this is an error or a warning.
    /// </summary>
    [JsonPropertyName("severity")]
    public string Severity { get; set; } = "error";

    /// <summary>
    /// Whether the error is in a Generated/ path.
    /// </summary>
    [JsonPropertyName("isGenerated")]
    public bool IsGenerated { get; set; }
}

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

/// <summary>
/// Result of a build operation.
/// </summary>
public sealed class BuildResult
{
    /// <summary>
    /// Whether the build succeeded.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// The parsed build errors.
    /// </summary>
    [JsonPropertyName("errors")]
    public List<BuildError> Errors { get; set; } = [];

    /// <summary>
    /// The raw build output (truncated).
    /// </summary>
    [JsonPropertyName("rawOutput")]
    public string RawOutput { get; set; } = string.Empty;
}
