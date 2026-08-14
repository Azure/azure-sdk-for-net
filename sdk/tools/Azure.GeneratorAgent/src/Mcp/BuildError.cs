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
