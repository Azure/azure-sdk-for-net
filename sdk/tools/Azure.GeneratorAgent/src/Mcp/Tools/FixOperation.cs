// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Describes a single fix operation for batch processing.
/// </summary>
public sealed class FixOperation
{
    public string Tool { get; set; } = string.Empty;
    public Dictionary<string, string> Args { get; set; } = new();
}
