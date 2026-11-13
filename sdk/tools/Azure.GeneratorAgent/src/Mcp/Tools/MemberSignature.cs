// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Represents a member signature found in generated code.
/// </summary>
public sealed class MemberSignature
{
    public List<string> ParameterTypes { get; set; } = [];
}
