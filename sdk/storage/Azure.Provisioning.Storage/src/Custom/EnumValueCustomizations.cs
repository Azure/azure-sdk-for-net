// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// TypeSpec orders these values differently; preserve the shipped numeric values.
[assembly: CodeGenEnumValue("StoragePublicAccessType", "None", 0)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Container", 1)]
[assembly: CodeGenEnumValue("StoragePublicAccessType", "Blob", 2)]
