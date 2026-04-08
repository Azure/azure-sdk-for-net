// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of adding a [CodeGenSuppress] attribute.
/// </summary>
public record SuppressResult(string FilePath, string Attribute, bool AlreadyPresent);
