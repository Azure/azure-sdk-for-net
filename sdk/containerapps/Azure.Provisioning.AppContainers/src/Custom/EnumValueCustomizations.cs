// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve the enum ordinals shipped by the reflection-based generator because the TypeSpec declaration order differs.
[assembly: CodeGenEnumValue("ContainerAppIdentitySettingsLifeCycle", "Init", 0)]
[assembly: CodeGenEnumValue("ContainerAppIdentitySettingsLifeCycle", "None", 2)]
