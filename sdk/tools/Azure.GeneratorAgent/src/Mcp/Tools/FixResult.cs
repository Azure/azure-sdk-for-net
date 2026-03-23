// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of a single fix operation.
/// </summary>
public sealed class FixResult
{
    public bool Success { get; set; }
    public string Tool { get; set; } = string.Empty;
    public string? Message { get; set; }
}
