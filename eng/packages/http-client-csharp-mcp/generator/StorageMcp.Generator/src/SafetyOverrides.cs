// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace StorageMcp.Generator;

public sealed record SafetyOverrides(bool? Destructive, bool? Idempotent, bool? ReadOnly, bool? OpenWorld)
{
    public ToolSafety Apply(ToolSafety defaults) => new(
        Destructive ?? defaults.Destructive,
        Idempotent ?? defaults.Idempotent,
        ReadOnly ?? defaults.ReadOnly,
        OpenWorld ?? defaults.OpenWorld);
}
