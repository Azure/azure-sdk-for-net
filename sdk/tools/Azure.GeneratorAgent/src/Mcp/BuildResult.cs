// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.GeneratorAgent.Mcp;

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
    /// The process exit code.
    /// </summary>
    [JsonPropertyName("exitCode")]
    public int ExitCode { get; set; }

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
