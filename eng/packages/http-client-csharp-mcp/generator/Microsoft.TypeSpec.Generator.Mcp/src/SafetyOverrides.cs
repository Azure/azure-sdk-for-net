// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.TypeSpec.Generator.Mcp;

public sealed record SafetyOverrides(bool? Destructive = null, bool? Idempotent = null, bool? ReadOnly = null, bool? OpenWorld = null)
{
    public ToolSafety Apply(ToolSafety defaults) => new(
        Destructive ?? defaults.Destructive,
        Idempotent ?? defaults.Idempotent,
        ReadOnly ?? defaults.ReadOnly,
        OpenWorld ?? defaults.OpenWorld);
}
