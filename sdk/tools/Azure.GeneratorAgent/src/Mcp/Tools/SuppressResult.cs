// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of adding a [CodeGenSuppress] attribute.
/// </summary>
public sealed class SuppressResult
{
    public string FilePath { get; set; } = string.Empty;
    public string Attribute { get; set; } = string.Empty;
    public bool AlreadyPresent { get; set; }
}
