// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of a single fix operation.
/// </summary>
public record FixResult(bool Success, string Tool, string? Message);
