// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Describes a single fix operation for batch processing.
/// The JSON schema matches <see cref="ClassifiedError"/> so that
/// <c>build_and_classify</c> output can be fed directly into <c>batch_fix</c>.
/// </summary>
public sealed class FixOperation
{
    [JsonPropertyName("toolName")]
    public string ToolName { get; set; } = string.Empty;

    [JsonPropertyName("toolArgs")]
    public Dictionary<string, string> ToolArgs { get; set; } = new();
}
