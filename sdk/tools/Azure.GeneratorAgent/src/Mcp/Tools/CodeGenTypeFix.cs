// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Describes a CodeGenType fix that was applied.
/// </summary>
public record CodeGenTypeFix(string FilePath, string CustomTypeName, string GeneratedTypeName);
