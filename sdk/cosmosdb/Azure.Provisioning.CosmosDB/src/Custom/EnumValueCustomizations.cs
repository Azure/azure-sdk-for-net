// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// CUSTOMIZATION: Restore the legacy PointInTimeRestore enum value omitted by the stable TypeSpec projection.
[assembly: CodeGenEnumValue(
    "CosmosDBAccountCreateMode",
    "PointInTimeRestore",
    2,
    WireName = "PointInTimeRestore",
    EditorBrowsableNever = true)]
