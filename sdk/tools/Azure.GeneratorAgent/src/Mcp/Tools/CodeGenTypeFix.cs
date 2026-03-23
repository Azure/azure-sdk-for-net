// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Describes a CodeGenType fix that was applied.
/// </summary>
public sealed class CodeGenTypeFix
{
    public string FilePath { get; init; } = string.Empty;
    public string CustomTypeName { get; init; } = string.Empty;
    public string GeneratedTypeName { get; init; } = string.Empty;
}
