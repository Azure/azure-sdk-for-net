// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of tspconfig.yaml validation.
/// </summary>
public sealed class TspConfigValidationResult
{
    public bool Success { get; set; }
    public bool IsValid { get; set; }
    public string Reason { get; set; } = string.Empty;
    public List<string> Issues { get; set; } = [];
}
