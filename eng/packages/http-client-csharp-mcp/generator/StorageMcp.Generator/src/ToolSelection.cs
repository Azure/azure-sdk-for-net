// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace StorageMcp.Generator;

public sealed record ToolSelection(
    string OperationId,
    string Id,
    string[] Group,
    string Name,
    string Title,
    string Binding,
    string[] AmbientParameters,
    bool UseDescriptionOverride,
    SafetyOverrides Safety);
